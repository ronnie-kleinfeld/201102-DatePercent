using System.Web.Services;
using System.ComponentModel;
using System.Data;
using MADA.Log.Api.Net;
using System.Reflection;
using System;
using MADA.DatePercent.BB.BE;
using MADA.DatePercent.BB.Storage.DBS.dbStorageDB.SPs;
using MADA.DatePercent.BB.Storage.DBS.dbStorageDB.Tables;
using MADA.DatePercent.SMTP.Api.Net;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Xml;
using System.Net;
using System.IO;
using MADA.Common.DataType;
using System.Data.SqlClient;

namespace MADA.DatePercent.BB.Storage.WS.WS
{
    /// <summary>
    /// Summary description for FlexWS
    /// </summary>
    [WebService(Namespace = "http://www.datepercent.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class FlexWS : System.Web.Services.WebService
    {
        #region SID
        private bool SIDExists(string p_strSID)
        {
            try
            {
                DataSet ds = new DataSet();
                procAPT_USER_LOGONSelectByUSL_SID.LoadDataSet(ds, tblT_USER_LOGON._Name, p_strSID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    Session.Abandon();
                    throw new Exception("SID not found");
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                Session.Abandon();
                throw new Exception("SID not found");
            }
        }
        #endregion
        #region Ping
        [WebMethod]
        public string Ping()
        {
            try
            {
                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), "Ping");
                return ResultCode.FAILED;
            }
        }
        #endregion
        #region BreakingNewsBar
        // RadiusPopBox
        [WebMethod]
        public string SetRadius(string p_strSID, int p_iRadiusKm)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USERUpdateUSR_RADIUS_KMByUSL_SID.ExecuteNonQuery(p_strSID, p_iRadiusKm);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        #endregion
        #region Location
        [WebMethod]
        public string GetLocation(string p_strSID, string p_strAddress)
        {
            try
            {
                SIDExists(p_strSID);
                string strUrl = "http://maps.google.com/maps/geo?output=xml&key=AIzaSyDUFoO2cv7XZZNOWQa1YB-JGhGpF-rCKAY&q=" + p_strAddress;

                WebClient webClient = new WebClient();
                string strXml;
                using (Stream stream = webClient.OpenRead(strUrl))
                {
                    StreamReader streamReader = new StreamReader(stream);
                    strXml = streamReader.ReadToEnd();
                }

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(strXml);
                XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
                XmlNode xmlNode = xmlDocument.GetElementsByTagName("coordinates")[0];

                if (xmlNode == null)
                {
                    return BE.ResultCode.FAILED;
                }
                else
                {
                    string[] coordinateArray = xmlNode.InnerText.Split(',');
                    if (coordinateArray.Length >= 2)
                    {
                        return coordinateArray[1].ToString() + "," + coordinateArray[0].ToString();
                    }
                    else
                    {
                        return BE.ResultCode.FAILED;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string SetLocation(string p_strSID, decimal p_decLat, decimal p_decLng)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USERUpdateUSR_LAT_USR_LNGByUSL_SID.ExecuteNonQuery(p_strSID, p_decLat, p_decLng);
                procPT_USER_LOCAL_MEMBERInsertIntoByUSL_SID.ExecuteNonQuery(p_strSID);

                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        #endregion
        #region TopBar
        // OnOffLine
        [WebMethod]
        public string SetOnLine(string p_strSID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USER_LOGONUpdateUSL_IS_ONLINEByUSL_SID.ExecuteNonQuery(true, p_strSID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string SetOffLine(string p_strSID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USER_LOGONUpdateUSL_IS_ONLINEByUSL_SID.ExecuteNonQuery(false, p_strSID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }

        // Share
        [WebMethod]
        public string ShareWithAFriend(string p_strSID, string p_strEMail, string p_strBody)
        {
            try
            {
                SIDExists(p_strSID);
                DataSet ds = new DataSet();
                procPT_USERSelectNameByUSL_SID.LoadDataSet(ds, tblT_USER._Name, p_strSID);
                string strFullName = ds.Tables[0].Rows[0]["FullName"].ToString();

                Mailer.Instance.Compose(p_strSID, strFullName, p_strEMail, p_strEMail, strFullName + " wanted to share DatePercent with you", p_strBody + "<br/>Click <a href='http://apps.facebook.com/datepercent_vtwo/?ref=ShareWithAFriend'>here</a> to login");

                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }

        // Inbox
        [WebMethod]
        public string DeleteMemberInbox(string p_strSID, int p_iMemberID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USER_INBOXDeleteByUSL_SID_USI_SENDER_USER_ID.ExecuteNonQuery(p_iMemberID, p_strSID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }

        // Settings
        [WebMethod]
        public string DeletePhoto(string p_strSID, int p_iPhotoID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USER_PHOTOUpdateByUSP_ID.ExecuteNonQuery(p_iPhotoID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string SetProfile(string p_strSID, string p_strNickName, int p_iDistanceUnitsTypeCode)
        {
            try
            {
                SIDExists(p_strSID);

                string strNickName = FacebookHandler.DoEncriptions(p_strNickName);

                DataSet ds = new DataSet();
                procPT_USERSelectFillByUSL_SID.LoadDataSet(ds, tblT_USER._Name, p_strSID);

                if (ds.Tables[0].Rows[0][tblT_USER.colUSR_FB_FIRST_NAME._Name].ToString().Contains(strNickName) ||
                    ds.Tables[0].Rows[0][tblT_USER.colUSR_FB_LAST_NAME._Name].ToString().Contains(strNickName) ||
                    ds.Tables[0].Rows[0][tblT_USER.colUSR_FB_MIDDLE_NAME._Name].ToString().Contains(strNickName) ||
                    ds.Tables[0].Rows[0][tblT_USER.colUSR_FB_EMAIL._Name].ToString().Contains(strNickName))
                {
                    strNickName = FacebookHandler.DoEncriptions(strNickName + " " + ds.Tables[0].Rows[0][tblT_USER.colUSR_FB_UID._Name].ToString());
                }

                procPT_USERUpdateMyProfileByUSL_SID.ExecuteNonQuery(p_strSID, p_iDistanceUnitsTypeCode, strNickName);

                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string SetLocale(string p_strSID, int p_iLocaleCode)
        {
            try
            {
                SIDExists(p_strSID);

                procPT_USERUpdateUSR_LOCALE_CODEByUSL_SID.ExecuteNonQuery(p_strSID, p_iLocaleCode);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public DataSet SessionFillCredits(string p_strSID)
        {
            try
            {
                SIDExists(p_strSID);
                DataSet ds = new DataSet();
                procPTSessionFillCreditsByUSL_SID.LoadDataSet(ds, tblT_USER_CREDIT._Name, p_strSID);

                ds.AcceptChanges();
                ds = ApplicationHandler.SerializeToFlex(ds);
                return ds;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return null;
            }
        }

        // Help
        [WebMethod]
        public string SendFeedback(string p_strSID, string p_strName, string p_strEMail, string p_strBody)
        {
            try
            {
                SIDExists(p_strSID);
                FlexDataSet ds = new FlexDataSet();
                procPT_USERSelectByUSL_SID.LoadDataSet(ds, ds.T_USER.TableName, p_strSID);
                FlexDataSet.T_USERRow dr = ds.T_USER[0];

                Mailer.Instance.Compose(p_strSID, "FeedbackModalBox", "support@datepercent.com", "DatePercent Support", p_strName + " Feedback",
                    "Name:" + p_strName + "<hr/>" +
                    "EMail:" + p_strEMail + "<hr/>" +
                    "Body:" + p_strBody.Replace("\n", "<br />") + "<hr/>" +
                    "SID:" + p_strSID + "<hr/>" +
                    "USR_ID:" + dr.USR_ID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string SendReport(string p_strSID, string p_strName, string p_strEMail, string p_strBody)
        {
            try
            {
                SIDExists(p_strSID);
                FlexDataSet ds = new FlexDataSet();
                procPT_USERSelectByUSL_SID.LoadDataSet(ds, ds.T_USER.TableName, p_strSID);
                FlexDataSet.T_USERRow dr = ds.T_USER[0];

                Mailer.Instance.Compose(p_strSID, "ReportModalBox", "support@datepercent.com", "DatePercent Support", p_strName + " Report",
                    "Name:" + p_strName + "<hr/>" +
                    "EMail:" + p_strEMail + "<hr/>" +
                    "Body:" + p_strBody.Replace("\n", "<br />") + "<hr/>" +
                    "SID:" + p_strSID + "<hr/>" +
                    "USR_ID:" + dr.USR_ID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        #endregion
        #region Member
        // Favorite Memebr
        [WebMethod]
        public string AddMemberToFavorites(string p_strSID, int p_iMemberID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USER_FAVORITEInsertInto.ExecuteNonQuery(p_strSID, p_iMemberID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string RemoveMemberFromFavorites(string p_strSID, int p_iMemberID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USER_FAVORITEDeleteByUSL_SIDUSV_FAVORITE_USER_ID.ExecuteNonQuery(p_strSID, p_iMemberID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }

        // Link
        [WebMethod]
        public string BuyUnlimitedChat(string p_strSID, int p_iMemberID)
        {
            Database db = DatabaseFactory.CreateDatabase();

            using (DbConnection con = db.CreateConnection())
            {
                con.Open();
                DbTransaction trn = con.BeginTransaction();
                Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);

                try
                {
                    SIDExists(p_strSID);
                    DataSet ds = new DataSet();
                    procPT_USERSelectByUSL_SID.LoadDataSet(ds, tblT_USER._Name, p_strSID);
                    int iUserID = (int)ds.Tables[0].Rows[0][tblT_USER.colUSR_ID._Name];
                    int iCreditBalance = (int)ds.Tables[0].Rows[0][tblT_USER.colUSR_CREDITS_BALANCE._Name];

                    if (iCreditBalance - 1 > 0)
                    {
                        procPT_USER_CREDITInsertIntoUnlimitedChatWithAMember.ExecuteNonQuery(1, p_iMemberID, iUserID, iUserID, db, trn);

                        procPT_USER_LINKInsertIntoUpdateByUSL_LINKED_USER_IDUSL_USER_ID.ExecuteNonQuery((int)T_USER_LINK_TYPE_ENUM.Payed, p_iMemberID, iUserID, db, trn);
                        procPT_USER_LINKInsertIntoUpdateByUSL_LINKED_USER_IDUSL_USER_ID.ExecuteNonQuery((int)T_USER_LINK_TYPE_ENUM.PayedFor, iUserID, p_iMemberID, db, trn);

                        procPT_USER_LOGONUpdateUSL_LINK_UPDATEDByUSL_USER_ID.ExecuteNonQuery(true, iUserID, db, trn);
                        procPT_USER_LOGONUpdateUSL_LINK_UPDATEDByUSL_USER_ID.ExecuteNonQuery(true, p_iMemberID, db, trn);

                        procPT_USERUpdateUSR_CREDITS_BALANCEByUSR_ID.ExecuteNonQuery(iUserID, db, trn);
                    }
                    else
                    {
                        Logger.Instance.WriteCritical("UNAUTHORIZED BuyUnlimitedChat request. USR_CREDITS_BALANCE:" + iCreditBalance, System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);
                        Mailer.Instance.Compose("UNAUTHORIZED BuyUnlimitedChat request. USR_CREDITS_BALANCE:" + iCreditBalance,
                            "UNAUTHORIZED BuyUnlimitedChat request. USR_CREDITS_BALANCE:" + iCreditBalance + "<hr/>" +
                            "iUserID:" + iUserID + "<hr/>" +
                            "p_iMemberID:" + p_iMemberID + "<hr/>" +
                            "p_strSID:" + p_strSID);
                        throw new Exception("UNAUTHORIZED BuyUnlimitedChat request. USR_CREDITS_BALANCE:" + iCreditBalance);
                    }

                    trn.Commit();
                    Logger.Instance.WriteCommitTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);
                    return BE.ResultCode.SUCCESS;
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), p_strSID);
                    return BE.ResultCode.FAILED;
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }
        }
        [WebMethod]
        public string BuyAPresent(string p_strSID, int p_iMemberID, int p_iPresentCode, int p_iPresentCost)
        {
            Database db = DatabaseFactory.CreateDatabase();

            using (DbConnection con = db.CreateConnection())
            {
                con.Open();
                DbTransaction trn = con.BeginTransaction();
                Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);

                try
                {
                    SIDExists(p_strSID);
                    DataSet ds = new DataSet();
                    procPT_USERSelectByUSL_SID.LoadDataSet(ds, tblT_USER._Name, p_strSID);
                    int iUserID = (int)ds.Tables[0].Rows[0][tblT_USER.colUSR_ID._Name];
                    int iCreditBalance = (int)ds.Tables[0].Rows[0][tblT_USER.colUSR_CREDITS_BALANCE._Name];

                    if (iCreditBalance - p_iPresentCost > 0)
                    {
                        procPT_USER_CREDITInsertIntoSendAPresent.ExecuteNonQuery(p_iPresentCost, p_iPresentCode, iUserID, db, trn);

                        procPT_USER_COMMInsertIntoByUSC_USER_ID.ExecuteNonQuery((int)T_USER_COMM_TYPE_ENUM.Present, p_iMemberID, p_iPresentCode, string.Empty, iUserID, -1, db, trn);

                        procPT_USER_LOGONUpdateUSL_HAS_INBOXByUSL_USER_ID.ExecuteNonQuery(true, iUserID, db, trn);
                        procPT_USER_LOGONUpdateUSL_HAS_INBOXByUSL_USER_ID.ExecuteNonQuery(true, p_iMemberID, db, trn);

                        procPT_USERUpdateUSR_CREDITS_BALANCEByUSR_ID.ExecuteNonQuery(iUserID, db, trn);
                    }
                    else
                    {
                        Logger.Instance.WriteCritical("UNAUTHORIZED BuyUnlimitedChat request. USR_CREDITS_BALANCE:" + iCreditBalance, System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);
                        Mailer.Instance.Compose("UNAUTHORIZED BuyUnlimitedChat request. USR_CREDITS_BALANCE:" + iCreditBalance,
                            "UNAUTHORIZED BuyUnlimitedChat request. USR_CREDITS_BALANCE:" + iCreditBalance + "<hr/>" +
                            "iUserID:" + iUserID + "<hr/>" +
                            "p_iMemberID:" + p_iMemberID + "<hr/>" +
                            "p_strSID:" + p_strSID);
                        throw new Exception("UNAUTHORIZED BuyUnlimitedChat request. USR_CREDITS_BALANCE:" + iCreditBalance);
                    }

                    trn.Commit();
                    Logger.Instance.WriteCommitTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);
                    return BE.ResultCode.SUCCESS;
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), p_strSID);
                    return BE.ResultCode.FAILED;
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }
        }
        [WebMethod]
        public bool IsLinked(string p_strSID, int p_iMemberID)
        {
            try
            {
                SIDExists(p_strSID);
                DataSet ds = new DataSet();
                procPT_USER_LINKSelectByUSL_SIDUSL_LINKED_USER_ID.LoadDataSet(ds, tblT_USER_LINK._Name, p_iMemberID, p_strSID);
                if (ds.Tables[tblT_USER_LINK._Name].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return false;
            }
        }

        // Comm
        [WebMethod]
        public string SendText(string p_strSID, int p_iMemberID, string p_strText)
        {
            try
            {
                SIDExists(p_strSID);
                DataSet ds = new DataSet();
                procPT_USER_LINKSelectByUSL_SIDUSL_LINKED_USER_ID.LoadDataSet(ds, tblT_USER_LINK._Name, p_iMemberID, p_strSID);
                T_USER_LINK_TYPE_ENUM enmLinkTypeCode = (T_USER_LINK_TYPE_ENUM)ds.Tables[0].Rows[0][tblT_USER_LINK.colUSL_LINK_TYPE_CODE._Name];
                if (enmLinkTypeCode == T_USER_LINK_TYPE_ENUM.Payed || enmLinkTypeCode == T_USER_LINK_TYPE_ENUM.PayedFor)
                {
                    procPT_USER_INBOXInsertIntoByUSL_SID.ExecuteNonQuery((int)T_USER_COMM_TYPE_ENUM.Text, -1, p_strText, p_iMemberID, -1, p_strSID);
                    procPT_USER_COMMInsertIntoByUSL_SID.ExecuteNonQuery((int)T_USER_COMM_TYPE_ENUM.Text, p_iMemberID, -1, p_strText, -1, p_strSID);

                    procPT_USER_LOGONUpdateUSL_HAS_INBOXByUSL_USER_ID.ExecuteNonQuery(true, p_iMemberID);

                    return BE.ResultCode.SUCCESS;
                }
                else
                {
                    Logger.Instance.WriteCritical("Unauthorized SendText from SID:" + p_strSID + " to MemberID:" + p_iMemberID, MethodBase.GetCurrentMethod(), Environment.MachineName);
                    return BE.ResultCode.FAILED;
                }
            }
            catch
            {
                Logger.Instance.WriteCritical("Unauthorized SendText from SID:" + p_strSID + " to MemberID:" + p_iMemberID, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string SendTwink(string p_strSID, int p_iMemberID, int p_iTwinkTypeCode)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USER_INBOXInsertIntoByUSL_SID.ExecuteNonQuery((int)T_USER_COMM_TYPE_ENUM.Wink, -1, string.Empty, p_iMemberID, p_iTwinkTypeCode, p_strSID);
                procPT_USER_COMMInsertIntoByUSL_SID.ExecuteNonQuery((int)T_USER_COMM_TYPE_ENUM.Wink, p_iMemberID, -1, string.Empty, p_iTwinkTypeCode, p_strSID);

                procPT_USER_LOGONUpdateUSL_HAS_INBOXByUSL_USER_ID.ExecuteNonQuery(true, p_iMemberID);

                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string SendPresent(string p_strSID, int p_iMemberID, int p_iPresentTypeCode)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USER_INBOXInsertIntoByUSL_SID.ExecuteNonQuery((int)T_USER_COMM_TYPE_ENUM.Present, p_iPresentTypeCode, string.Empty, p_iMemberID, -1, p_strSID);
                procPT_USER_COMMInsertIntoByUSL_SID.ExecuteNonQuery((int)T_USER_COMM_TYPE_ENUM.Present, p_iMemberID, p_iPresentTypeCode, string.Empty, -1, p_strSID);

                procPT_USER_LOGONUpdateUSL_HAS_INBOXByUSL_USER_ID.ExecuteNonQuery(true, p_iMemberID);

                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }

        [WebMethod]
        public string SetMemberCommAsRead(string p_strSID, int p_iMemberID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USER_COMMUpdateAsReadByUSL_SID.ExecuteNonQuery(p_strSID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }

        // Block Memebr
        [WebMethod]
        public string AddMemberFromBlackList(string p_strSID, int p_iMemberID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USER_BLACK_LISTInsertInto.ExecuteNonQuery(p_iMemberID, p_strSID);
                procPT_USER_FAVORITEDeleteByUSL_SIDUSV_FAVORITE_USER_ID.ExecuteNonQuery(p_strSID, p_iMemberID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string RemoveMemberFromBlackList(string p_strSID, int p_iMemberID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USER_BLACK_LISTDeleteByUSL_SIDUSB_BLACK_LIST_USER_ID.ExecuteNonQuery(p_iMemberID, p_strSID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }

        // Share Member
        [WebMethod]
        public string ShareMemberWithAFriend(string p_strSID, string p_strMemberUID, string p_strEMail, string p_strBody)
        {
            try
            {
                SIDExists(p_strSID);
                FlexDataSet dsUser = new FlexDataSet();
                procPT_USERSelectByUSL_SID.LoadDataSet(dsUser, dsUser.T_USER.TableName, p_strSID);
                FlexDataSet.T_USERRow drUser = dsUser.T_USER[0];

                FlexDataSet dsMember = new FlexDataSet();
                procPT_USERSelectByUSR_UID.LoadDataSet(dsMember, dsMember.T_USER.TableName, p_strMemberUID);
                FlexDataSet.T_USERRow drMember = dsMember.T_USER[0];

                Mailer.Instance.Compose(p_strSID,
                    drUser.USR_NICK_NAME,
                    p_strEMail, p_strEMail,
                    drUser.USR_NICK_NAME + " shared this member with you",
                    "<img src='" + drMember.USR_FB_PICX_URL + "' /><br />" +
                    "Message from " + drUser.USR_NICK_NAME + ": " + p_strBody.Replace("\n", "<br />") + "<br />" +
                    "Click <a href=''>here</a> to see this memebr profile");
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }

        // Dont Ask
        [WebMethod]
        public string DontAskRemoveFromFavorites(string p_strSID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USERUpdateUSR_DONT_ASK_REMOVE_FROM_FAVORITESByUSL_SID.ExecuteNonQuery(p_strSID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string DontAskAddToFavorites(string p_strSID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USERUpdateUSR_DONT_ASK_ADD_TO_FAVORITESByUSL_SID.ExecuteNonQuery(p_strSID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string DontAskBlockMember(string p_strSID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USERUpdateUSR_DONT_ASK_BLOCK_MEMBERByUSL_SID.ExecuteNonQuery(p_strSID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string DontAskRemoveFromBlackList(string p_strSID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USERUpdateUSR_DONT_ASK_REMOVE_FROM_BLACK_LISTByUSL_SID.ExecuteNonQuery(p_strSID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string DontAskRemoveFromMyPhotos(string p_strSID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USERUpdateUSR_DONT_ASK_REMOVE_FROM_MY_PHOTOSByUSL_SID.ExecuteNonQuery(p_strSID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string DontAskInvitationSend(string p_strSID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USERUpdateUSR_DONT_ASK_INVITATION_SENTByUSL_SID.ExecuteNonQuery(p_strSID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string DontAskFeedbackSent(string p_strSID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USERUpdateUSR_DONT_ASK_FEEDBACK_SENTByUSL_SID.ExecuteNonQuery(p_strSID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string DontAskReportSent(string p_strSID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USERUpdateUSR_DONT_ASK_REPORT_SENTByUSL_SID.ExecuteNonQuery(p_strSID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string DontAskProfileUpdated(string p_strSID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USERUpdateUSR_DONT_ASK_PROFILE_UPDATEDByUSL_SID.ExecuteNonQuery(p_strSID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string DontAskTwinkSent(string p_strSID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USERUpdateUSR_DONT_ASK_TWINK_SENTByUSL_SID.ExecuteNonQuery(p_strSID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        #endregion
        #region PlatformApp
        [WebMethod]
        public DataSet ApplicationFill(string p_strSID)
        {
            try
            {
                Logger.Instance.WriteInformation("p_strSID:" + p_strSID, MethodBase.GetCurrentMethod(), p_strSID);
                return ApplicationHandler.Instance.FlexApplication;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }

        [WebMethod]
        public DataSet SessionInit(string p_strSID, string p_strToken)
        {
            try
            {
                int iUserID = FacebookHandler.Instance.PreFillFbUser(p_strSID, p_strToken);
                Logger.Instance.WriteInformation("iUserID:" + iUserID, MethodBase.GetCurrentMethod(), p_strSID);

                object oUSL_ID;
                procAPT_USER_LOGONInsertIntoUpdateByUSL_SID.ExecuteNonQuery(null, 0, null, p_strSID, iUserID, out oUSL_ID);
                procPT_USER_LOGONUpdateUSL_FB_UPDATEDByUSL_USER_ID.ExecuteNonQuery(true, iUserID);
                procPT_USER_LOGONUpdateUSL_HAS_BREAKING_NEWSByUSL_USER_ID.ExecuteNonQuery(true, iUserID);
                procPT_USER_LOGONUpdateUSL_HAS_INBOXByUSL_USER_ID.ExecuteNonQuery(true, iUserID);
                procPT_USER_LOGONUpdateUSL_HAS_ONLINE_FAVORITESByUSL_USER_ID.ExecuteNonQuery(true, iUserID);
                procPT_USER_LOGONUpdateUSL_IS_ONLINEByUSL_USER_ID.ExecuteNonQuery(true, iUserID);
                procPT_USER_LOGONUpdateUSL_LINK_UPDATEDByUSL_USER_ID.ExecuteNonQuery(true, iUserID);
                Logger.Instance.WriteProcess("Session done", MethodBase.GetCurrentMethod(), p_strSID);

                procPT_USER_LOCAL_MEMBERInsertIntoByUSL_SID.ExecuteNonQuery(p_strSID);

                DataSet ds = new DataSet();
                procPT_USERSelectByUSL_SID.LoadDataSet(ds, tblT_USER._Name, p_strSID);
                procPTSessionInitByUSV_USER_ID.LoadDataSet(ds, "T_USER_FAVORITE", iUserID);

                ds.AcceptChanges();
                ds = ApplicationHandler.SerializeToFlex(ds);
                return ds;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }
        [WebMethod]
        public DataSet SessionFill(string p_strSID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USER_LOGONUpdateUSL_FB_UPDATEDByUSL_SID.ExecuteNonQuery(false, p_strSID);

                DataSet ds = new DataSet();
                procPT_USERSelectFillByUSL_SID.LoadDataSet(ds, tblT_USER._Name, p_strSID);
                int iUserID = (int)ds.Tables[0].Rows[0]["USR_ID"];
                Logger.Instance.WriteInformation("iUserID:" + iUserID, MethodBase.GetCurrentMethod(), p_strSID);

                procPTSessionFillByUSR_ID.LoadDataSet(ds, tblT_USER_PHOTO._Name, iUserID);

                ds.AcceptChanges();
                ds = ApplicationHandler.SerializeToFlex(ds);
                return ds;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }
        [WebMethod]
        public DataSet SessionFillOnlineMembers(string p_strSID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USER_LOGONUpdateUSL_HAS_BREAKING_NEWSByUSL_SID.ExecuteNonQuery(false, p_strSID);

                DataSet ds = new DataSet();
                procPTSessionFillMembersByUSL_SID.LoadDataSet(ds, tblT_USER._Name, p_strSID);

                int iNewFetchedLogonID;
                try
                {
                    iNewFetchedLogonID = (int)ds.Tables[ds.Tables.Count - 1].Rows[0][0];
                }
                catch
                {
                    iNewFetchedLogonID = -1;
                }
                procPT_USER_LOGONUpdateUSL_FETCHED_LOGON_IDByUSL_SID.ExecuteNonQuery(iNewFetchedLogonID, p_strSID);

                ds.AcceptChanges();
                ds = ApplicationHandler.SerializeToFlex(ds);
                return ds;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return null;
            }
        }
        [WebMethod]
        public DataSet SessionFillLocalMembers(string p_strSID)
        {
            try
            {
                SIDExists(p_strSID);
                DataSet ds = new DataSet();
                procPTSessionFillLocalMembersByUSL_SID.LoadDataSet(ds, tblT_USER._Name, p_strSID);

                int iNewFetchedLocalID;
                try
                {
                    iNewFetchedLocalID = (int)ds.Tables[ds.Tables.Count - 1].Rows[0][0];
                }
                catch
                {
                    iNewFetchedLocalID = -1;
                }
                procPT_USER_LOGONUpdateUSL_FETCHED_LOCAL_IDByUSL_SID.ExecuteNonQuery(iNewFetchedLocalID, p_strSID);

                ds.AcceptChanges();
                ds = ApplicationHandler.SerializeToFlex(ds);
                return ds;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return null;
            }
        }
        [WebMethod]
        public DataSet SessionFillInbox(string p_strSID)
        {
            try
            {
                SIDExists(p_strSID);
                procPT_USER_LOGONUpdateUSL_HAS_INBOXByUSL_SID.ExecuteNonQuery(false, p_strSID);

                DataSet ds = new DataSet();
                procPTSessionFillInboxByUSL_SID.LoadDataSet(ds, tblT_USER_INBOX._Name, p_strSID);

                ds.AcceptChanges();
                ds = ApplicationHandler.SerializeToFlex(ds);
                return ds;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return null;
            }
        }
        [WebMethod]
        public DataSet SessionFillCreditsBalance(string p_strSID)
        {
            try
            {
                DataSet ds = new DataSet();
                procPT_USERSelectByUSL_SID.LoadDataSet(ds, tblT_USER._Name, p_strSID);

                ds.AcceptChanges();
                ds = ApplicationHandler.SerializeToFlex(ds);
                return ds;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }

        [WebMethod]
        public PS GetPS(string p_strSID)
        {
            PS platformStatus;

            try
            {
                SIDExists(p_strSID);
                // reset age to 0
                procPT_USER_LOGONUpdateUSL_AGEByUSL_SID.ExecuteNonQuery(p_strSID);

                platformStatus = new PS();
                platformStatus._C = 0;// ApplicationHandler.Instance.LogonCounter; - Need to implement a LogonCounterService

                DataSet ds = new DataSet();
                procAPT_USER_LOGONSelectByUSL_SID.LoadDataSet(ds, "T", p_strSID);

                /// <summary>
                ///  1 - Has Messages
                ///  2 - Has Online Favorites
                ///  4 - Has Breaking News
                ///  8 - Me FB Updated
                /// 16 - Is Online
                /// 32 - Link Updated
                /// 64 - Credits Balance Updated
                /// </summary>
                if ((bool)ds.Tables[0].Rows[0][tblT_USER_LOGON.colUSL_HAS_INBOX._Name])
                {
                    platformStatus._BW += 1;
                    procPT_USER_LOGONUpdateUSL_HAS_INBOXByUSL_SID.ExecuteNonQuery(false, p_strSID);
                }
                if ((bool)ds.Tables[0].Rows[0][tblT_USER_LOGON.colUSL_HAS_ONLINE_FAVORITES._Name])
                {
                    platformStatus._BW += 2;
                    procPT_USER_LOGONUpdateUSL_HAS_ONLINE_FAVORITESByUSL_SID.ExecuteNonQuery(false, p_strSID);
                }
                if ((bool)ds.Tables[0].Rows[0][tblT_USER_LOGON.colUSL_HAS_BREAKING_NEWS._Name])
                {
                    platformStatus._BW += 4;
                    procPT_USER_LOGONUpdateUSL_HAS_BREAKING_NEWSByUSL_SID.ExecuteNonQuery(false, p_strSID);
                }
                if ((bool)ds.Tables[0].Rows[0][tblT_USER_LOGON.colUSL_FB_UPDATED._Name])
                {
                    platformStatus._BW += 8;
                    procPT_USER_LOGONUpdateUSL_FB_UPDATEDByUSL_SID.ExecuteNonQuery(false, p_strSID);
                }
                if ((bool)ds.Tables[0].Rows[0][tblT_USER_LOGON.colUSL_IS_ONLINE._Name])
                {
                    platformStatus._BW += 16;
                }
                if ((bool)ds.Tables[0].Rows[0][tblT_USER_LOGON.colUSL_LINK_UPDATED._Name])
                {
                    platformStatus._BW += 32;
                    procPT_USER_LOGONUpdateUSL_LINK_UPDATEDByUSL_SID.ExecuteNonQuery(false, p_strSID);
                }
                if ((bool)ds.Tables[0].Rows[0][tblT_USER_LOGON.colUSL_CREDITS_BALANCE_UPDATED._Name])
                {
                    platformStatus._BW += 64;
                    procPT_USER_LOGONUpdateUSL_CREDITS_BALANCE_UPDATEDByUSL_SID.ExecuteNonQuery(false, p_strSID);
                }
            }
            catch
            {
                platformStatus = null;
            }

            return platformStatus;
        }
        #endregion
    }
}