using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MADA.Log.Api.Net;
using System.Reflection;
using MADA.Log.API.Net;
using MADA.DatePercent.BB.Storage.DBS.dbStorageDB.Tables;
using MADA.DatePercent.BB.Storage.DBS.dbStorageDB.SPs;
using MADA.DatePercent.SMTP.Api.Net;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace MADA.DatePercent.BB.Storage.WS.PayPal
{
    public partial class IPN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Logger.Instance.WriteInformation("IPN Recieved", MethodBase.GetCurrentMethod(), Environment.MachineName);
                Logger.Instance.Write(HttpContext.Current.Request.Params, MethodBase.GetCurrentMethod(), Environment.MachineName);
                //mc_gross=1.00 
                //payer_id=AM7MMHQK8X3CU 
                //payment_status=Completed 
                //first_name=Ronnie 
                //custom=64B5E548-DE79-48B4-9322-6024E9DCC03C%2bEAC7BEEB-E3DB-4739-9148-9A6163C8C7D4
                //payer_email=ronnie.kleinfeld%40gmail.com 
                //txn_id=05S63079VP587691H 
                //payer_business_name=DatePercent+Ltd 
                //last_name=Kleinfeld 
                //item_name=Unlimited+chat+with+a+member 
                //item_number=1 
                //residence_country=IL 
                //ipn_track_id=6ab2a6cfa81a4

                string strCustom = GetSafeParam("custom", string.Empty);
                string strPayerUserUID = strCustom.Split('+')[0];
                string strPayedForUserUID = strCustom.Split('+')[1];
                int iCredits = Int32.Parse(strCustom.Split('+')[3]);

                DataSet ds = new DataSet();
                procAPT_USERSelectByUSR_UID.LoadDataSet(ds, "T_USERPayerUserUID", strPayerUserUID);
                procAPT_USERSelectByUSR_UID.LoadDataSet(ds, "T_USERPayedForUserUID", strPayedForUserUID);

                int iPayerUserID = (int)ds.Tables["T_USERPayerUserUID"].Rows[0][tblT_USER.colUSR_ID._Name];
                int iPayedForUserID = (int)ds.Tables["T_USERPayedForUserUID"].Rows[0][tblT_USER.colUSR_ID._Name];

                string strItemNumber = GetSafeParam("item_number", string.Empty);
                string strPaymentStatus = GetSafeParam("payment_status", string.Empty);

                Database db = DatabaseFactory.CreateDatabase();

                using (DbConnection con = db.CreateConnection())
                {
                    con.Open();
                    DbTransaction trn = con.BeginTransaction();
                    Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                    object oUPT_ID;
                    procPT_USER_TRANSACTIONInsertInto.ExecuteNonQuery(
                        iCredits,
                        strCustom,
                        null,
                        HttpContext.Current.Request.Params.ToString(),
                        GetSafeParam("item_name", string.Empty),
                        strItemNumber,
                        Decimal.Parse(GetSafeParam("mc_fee", "0")),
                        Decimal.Parse(GetSafeParam("mc_gross", "0")),
                        GetSafeParam("ipn_track_id", string.Empty),
                        iPayedForUserID,
                        GetSafeParam("payer_business_name", string.Empty),
                        GetSafeParam("payer_email", string.Empty),
                        GetSafeParam("first_name", string.Empty),
                        strPayedForUserUID,
                        GetSafeParam("payer_id", string.Empty),
                        GetSafeParam("last_name", string.Empty),
                        strPayerUserUID,
                        strPaymentStatus,
                        GetSafeParam("residence_country", string.Empty),
                        GetSafeParam("txn_id", string.Empty),
                        iPayerUserID,
                        out oUPT_ID,
                        db, trn);
                    int iUPT_ID = -1;
                    if (oUPT_ID == null)
                    {
                        throw new Exception("Failed to insert new T_USER_TRANSACTION");
                    }
                    else
                    {
                        iUPT_ID = (int)oUPT_ID;
                    }
                    Logger.Instance.WriteInformation("procPT_USER_TRANSACTIONInsertInto", MethodBase.GetCurrentMethod(), Environment.MachineName);

                    try
                    {
                        switch (strPaymentStatus)
                        {
                            case "Completed":
                                switch (strItemNumber)
                                {
                                    case "1":
                                        procPT_USER_CREDITInsertIntoTransactionCompleted.ExecuteNonQuery(iUPT_ID, iCredits, iPayerUserID, db, trn);

                                        procPT_USER_LINKInsertIntoUpdateByUSL_LINKED_USER_IDUSL_USER_ID.ExecuteNonQuery((int)T_USER_LINK_TYPE_ENUM.Payed, iPayedForUserID, iPayerUserID);
                                        procPT_USER_LINKInsertIntoUpdateByUSL_LINKED_USER_IDUSL_USER_ID.ExecuteNonQuery((int)T_USER_LINK_TYPE_ENUM.PayedFor, iPayerUserID, iPayedForUserID);

                                        procPT_USER_LOGONUpdateUSL_LINK_UPDATEDByUSL_USER_ID.ExecuteNonQuery(true, iPayerUserID);
                                        procPT_USER_LOGONUpdateUSL_LINK_UPDATEDByUSL_USER_ID.ExecuteNonQuery(true, iPayedForUserID);

                                        Logger.Instance.WriteInformation("Completed-1", MethodBase.GetCurrentMethod(), Environment.MachineName);
                                        break;
                                    default:
                                        Logger.Instance.WriteSwitchOutOfRange("Unknown Item Number:" + strItemNumber, MethodBase.GetCurrentMethod(), Environment.MachineName);
                                        break;
                                }
                                break;
                            case "Refunded":
                                switch (strItemNumber)
                                {
                                    case "1":
                                        Mailer.Instance.Compose("An IPN refund was recieved",
                                            "An IPN refund was recieved<hr/>" +
                                            "Need to add a row to T_USER_CREDIT with USD_CREDIT_TYPE_CODE=2 and USD_CREDITS=refunded credits" + "<hr/>" +
                                            "INSERT INTO T_USER_CREDIT (USD_CREDIT_TYPE_CODE, USD_CREDITS, USD_REFUNDED_TRANSACTION_ID, USD_USER_ID) VALUES (2, 'xxx Credits To Refund xxx', " + iUPT_ID + ", " + iPayerUserID + ")" + "<hr/>");

                                        procAPT_USER_LINKDeleteByUSL_LINKED_USER_IDUSL_USER_ID.ExecuteNonQuery(iPayerUserID, iPayedForUserID);
                                        procAPT_USER_LINKDeleteByUSL_LINKED_USER_IDUSL_USER_ID.ExecuteNonQuery(iPayedForUserID, iPayerUserID);

                                        procPT_USER_LOGONUpdateUSL_LINK_UPDATEDByUSL_USER_ID.ExecuteNonQuery(true, iPayerUserID);
                                        procPT_USER_LOGONUpdateUSL_LINK_UPDATEDByUSL_USER_ID.ExecuteNonQuery(true, iPayedForUserID);

                                        Logger.Instance.WriteInformation("Refunded-1", MethodBase.GetCurrentMethod(), Environment.MachineName);
                                        break;
                                    default:
                                        Logger.Instance.WriteSwitchOutOfRange("Unknown Item Number:" + strItemNumber, MethodBase.GetCurrentMethod(), Environment.MachineName);
                                        break;
                                }
                                break;
                            default:
                                Logger.Instance.WriteSwitchOutOfRange("Unknown payment status:" + strPaymentStatus, MethodBase.GetCurrentMethod(), Environment.MachineName);
                                break;
                        }

                        trn.Commit();
                        Logger.Instance.WriteCommitTrn(System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }
                    catch (Exception ex)
                    {
                        trn.Rollback();
                        Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                        throw ex;
                    }
                    finally
                    {
                        if (con != null)
                        {
                            con.Close();
                        }

                        procPT_USERUpdateUSR_CREDITS_BALANCEByUSR_ID.ExecuteNonQuery(iPayerUserID);
                    }
                }
            }
            catch (Exception ex)
            {
                Mailer.Instance.Compose("Unresolved IPN",
                    "This is an IPN that had not been resolved by the IPN.aspx<hr/>" +
                    ex.Message + "<hr/>" +
                    "txn_id:" + GetSafeParam("txn_id", string.Empty) + "<hr/>" +
                    "ipn_track_id:" + GetSafeParam("ipn_track_id", string.Empty) + "<hr/>" +
                    "payment_status:" + GetSafeParam("payment_status", string.Empty) + "<hr/>" +
                    "payer_id:" + GetSafeParam("payer_id", string.Empty) + "<hr/>" +
                    "first_name:" + GetSafeParam("first_name", string.Empty) + "<hr/>" +
                    "last_name:" + GetSafeParam("last_name", string.Empty) + "<hr/>" +
                    "payer_email:" + GetSafeParam("payer_email", string.Empty) + "<hr/>" +
                    "payer_business_name:" + GetSafeParam("payer_business_name", string.Empty) + "<hr/>" +
                    "residence_country:" + GetSafeParam("residence_country", string.Empty) + "<hr/>" +
                    "mc_gross:" + GetSafeParam("mc_gross", "0") + "<hr/>" +
                    "mc_fee:" + GetSafeParam("mc_gross", "0") + "<hr/>" +
                    "item_name:" + GetSafeParam("item_name", string.Empty) + "<hr/>" +
                    "item_number:" + GetSafeParam("item_number", string.Empty) + "<hr/>" +
                    "custom:" + GetSafeParam("custom", string.Empty) + "<hr/>" +
                    HttpContext.Current.Request.Params.ToString() + "<hr/>");

                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }

        private string GetSafeParam(string p_strKey, string p_strDefault)
        {
            try
            {
                return HttpUtility.HtmlDecode(HttpContext.Current.Request.Params[p_strKey]);
            }
            catch
            {
                return p_strDefault;
            }
        }
    }
}