using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using MADA.Data;
using System.Web;
using MADA.Log.Api.Net;
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.Tables;
using MADA.DatePercent.BB.WL.BE;
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.SPs;
using System.Reflection;

namespace MADA.DatePercent.BB.WL.BL
{
    public class EMailHandler
    {
        public static string ComposeEmailBoxDetailsShare(
            int p_iSessionID, string p_strLoggerSessionID,
            int p_iSharedDetailsID, string p_strGetterEMail, string p_strGetterText)
        {
            try
            {
                Logger.Instance.WriteInformation("Started", MethodBase.GetCurrentMethod(), p_strLoggerSessionID);

                EMailHandlerDetailsShareDataSet ds = new EMailHandlerDetailsShareDataSet();

                ApplicationHandler.T_EMAIL_BOX_TYPE_ENUMRow drEmailBoxType = ApplicationHandler.Instance.T_EMAIL_BOX_TYPE_ENUM.FindByEBT_CODE((int)T_EMAIL_BOX_TYPE_ENUM.DetailsShare);
                Logger.Instance.Write(drEmailBoxType, MethodBase.GetCurrentMethod(), p_strLoggerSessionID);

                string strSubject = drEmailBoxType.EBT_SUBJECT;

                string strBoxHtml = Constants.EMailBoxHtml;
                Logger.Instance.WriteProcess("EMailBoxHtml init:" + strBoxHtml, MethodBase.GetCurrentMethod(), p_strLoggerSessionID);

                strBoxHtml = strBoxHtml.Replace("<%EBT_PATH%>", drEmailBoxType.EBT_PATH);
                strBoxHtml = strBoxHtml.Replace("<%EBT_QUERY_STRING%>", drEmailBoxType.EBT_QUERY_STRING);
                strBoxHtml = strBoxHtml.Replace("<%EBT_PIC_URL%>", drEmailBoxType.EBT_PIC_URL);
                strBoxHtml = strBoxHtml.Replace("<%EBT_SUBJECT%>", drEmailBoxType.EBT_SUBJECT);
                strBoxHtml = strBoxHtml.Replace("<%EBT_CLICK_HERE_TO%>", drEmailBoxType.EBT_CLICK_HERE_TO);
                strBoxHtml = strBoxHtml.Replace("<%UIRedirectToAppUrl%>", Constants.UIRedirectToAppUrl);
                strBoxHtml = strBoxHtml.Replace("<%DETAILS_UID_URL_KEY%>", Constants.DETAILS_UID_URL_KEY);

                string strSenderName;
                string strSenderPhotoUrl = Constants.UIResNoImageUrl;

                procAPT_USERSelectByUSR_ID.LoadDataSet(ds, ds.T_USER_Sender.TableName, p_iSessionID);
                procAPT_USERSelectByUSR_ID.LoadDataSet(ds, ds.T_USER_SharedDetails.TableName, p_iSharedDetailsID);

                strSenderName = ds.T_USER_Sender[0].USR_NAME;

                if (ds.T_USER_Sender[0].IsUSR_PIC_URLNull())
                {
                    strSenderPhotoUrl = Constants.UIResNoImageUrl;
                }
                else if (ds.T_USER_Sender[0].USR_PIC_URL == string.Empty)
                {
                    strSenderPhotoUrl = Constants.UIResNoImageUrl;
                }
                else
                {
                    strSenderPhotoUrl = ds.T_USER_Sender[0].USR_PIC_URL;
                }

                strBoxHtml = strBoxHtml.Replace("<%DETAILS_UID_URL_VALUE%>", ds.T_USER_SharedDetails[0].USR_UID.ToString());
                strBoxHtml = strBoxHtml.Replace("<%UIWebResUrl%>", Constants.UIResUrl);
                strSubject = strSubject.Replace("<%SenderName%>", strSenderName);
                strBoxHtml = strBoxHtml.Replace("<%SenderName%>", strSenderName);
                strBoxHtml = strBoxHtml.Replace("<%USR_PIC_URL%>", strSenderPhotoUrl);
                strBoxHtml = strBoxHtml.Replace("<%UserText%>", p_strGetterText);

                DateTime dtPublishDateTime = DateTime.Now.AddMinutes(drEmailBoxType.EBT_HOLD_TIME_MINUTES);

                Logger.Instance.WriteInformation("EMailBoxHtml subject:" + strSubject, MethodBase.GetCurrentMethod(), p_strLoggerSessionID);
                Logger.Instance.WriteInformation("EMailBoxHtml ready:" + strBoxHtml, MethodBase.GetCurrentMethod(), p_strLoggerSessionID);

                object oEMB_ID;
                procAPT_EMAIL_BOXInsertInto.ExecuteNonQuery(strBoxHtml, p_strGetterEMail, p_strGetterEMail, string.Empty, null, dtPublishDateTime, string.Empty, strSenderName, strSubject, out oEMB_ID);
                Logger.Instance.WriteProcess("EMailBox added to T_EMAIL_BOX", MethodBase.GetCurrentMethod(), p_strLoggerSessionID);

                procPT_EMAIL_BOX_TYPE_ENUMIncrementCounter.LoadDataSet(ds, BE.Constants.LOAD_DATASET_TABLE_NAME, (int)T_EMAIL_BOX_TYPE_ENUM.DetailsShare);
                Logger.Instance.WriteInformation("EMailBoxType DetailsShare incremented", MethodBase.GetCurrentMethod(), p_strLoggerSessionID);

                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strLoggerSessionID);
                throw;
            }
            finally
            {
                Logger.Instance.WriteInformation("Ended", MethodBase.GetCurrentMethod(), p_strLoggerSessionID);
            }
        }

        public static string ComposeEmailBox(
            int p_iSessionID, string p_strLoggerSessionID,
            T_EMAIL_BOX_TYPE_ENUM p_enmEmailBoxType, int p_iSenderUserID, int p_iGetterUserID, string p_strUserText, string p_strSenderEMail)
        {
            Database db = DatabaseFactory.CreateDatabase();

            using (DbConnection con = db.CreateConnection())
            {
                con.Open();
                DbTransaction trn = con.BeginTransaction();
                Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_iSessionID.ToString());

                try
                {
                    EMailHandler.ComposeEmailBox(p_strLoggerSessionID, p_enmEmailBoxType, p_iSenderUserID, p_iGetterUserID, p_strUserText, p_strSenderEMail, -1, db, trn);
                    trn.Commit();
                    Logger.Instance.WriteCommitTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strLoggerSessionID);
                    return ResultCode.SUCCESS;
                }
                catch (Exception ex)
                {
                    trn.Rollback();
                    Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), p_strLoggerSessionID);
                    return ResultCode.FAILED;
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

        public static string ComposeEmailBox(
            string p_strLoggerSessionID,
            T_EMAIL_BOX_TYPE_ENUM p_enmEmailBoxType,
            int p_iSenderUserID, int p_iGetterUserID, string p_strUserText, string p_strSenderEMail, int p_iTicketID,
            Database p_db, DbTransaction p_trn)
        {
            try
            {
                Logger.Instance.WriteInformation("Started", MethodBase.GetCurrentMethod(), p_strLoggerSessionID);

                EMailHandlerDataSet ds = new EMailHandlerDataSet();

                procAPT_USERSelectByUSR_ID.LoadDataSet(ds, ds.T_USER_Sender.TableName, p_iSenderUserID, p_db, p_trn);
                procAPT_USERSelectByUSR_ID.LoadDataSet(ds, ds.T_USER_Getter.TableName, p_iGetterUserID, p_db, p_trn);
                if (ds.T_USER_Getter[0].USR_SUBSCRIBE)
                {
                    Logger.Instance.WriteInformation("Getter user " + ds.T_USER_Getter[0].USR_NAME + " exists and subscribed to get emails", MethodBase.GetCurrentMethod(), p_strLoggerSessionID);

                    ApplicationHandler.T_EMAIL_BOX_TYPE_ENUMRow drEmailBoxType = ApplicationHandler.Instance.T_EMAIL_BOX_TYPE_ENUM.FindByEBT_CODE((int)p_enmEmailBoxType);
                    Logger.Instance.Write(drEmailBoxType, MethodBase.GetCurrentMethod(), p_strLoggerSessionID);

                    string strSubject = drEmailBoxType.EBT_SUBJECT;

                    string strBoxHtml = Constants.EMailBoxHtml;
                    Logger.Instance.WriteProcess("EMailBoxHtml init:" + strBoxHtml, MethodBase.GetCurrentMethod(), p_strLoggerSessionID);

                    strBoxHtml = strBoxHtml.Replace("<%EBT_PATH%>", drEmailBoxType.EBT_PATH);
                    strBoxHtml = strBoxHtml.Replace("<%EBT_QUERY_STRING%>", drEmailBoxType.EBT_QUERY_STRING);
                    strBoxHtml = strBoxHtml.Replace("<%EBT_PIC_URL%>", drEmailBoxType.EBT_PIC_URL);
                    strBoxHtml = strBoxHtml.Replace("<%UIWebResUrl%>", Constants.UIResUrl);
                    strBoxHtml = strBoxHtml.Replace("<%EBT_SUBJECT%>", drEmailBoxType.EBT_SUBJECT);
                    strBoxHtml = strBoxHtml.Replace("<%EBT_CLICK_HERE_TO%>", drEmailBoxType.EBT_CLICK_HERE_TO);
                    strBoxHtml = strBoxHtml.Replace("<%UIRedirectToAppUrl%>", Constants.UIRedirectToAppUrl);
                    strBoxHtml = strBoxHtml.Replace("<%DETAILS_UID_URL_KEY%>", Constants.DETAILS_UID_URL_KEY);
                    strBoxHtml = strBoxHtml.Replace("<%EMAIL_URL_KEY%>", Constants.EMAIL_URL_KEY);
                    strBoxHtml = strBoxHtml.Replace("<%SUPPORT_ID_KEY%>", Constants.SUPPORT_ID_KEY);

                    string strGetterUid = ds.T_USER_Getter[0].USR_UID;
                    string strGetterName = ds.T_USER_Getter[0].USR_NAME;
                    string strSenderName = ds.T_USER_Sender[0].USR_V_NAME;
                    string strSenderPhotoUrl = Constants.UIResNoImageUrl;

                    if (ds.T_USER_Sender[0].IsUSR_PIC_URLNull())
                    {
                        strSenderPhotoUrl = Constants.UIResNoImageUrl;
                    }
                    else if (ds.T_USER_Sender[0].USR_PIC_URL == string.Empty)
                    {
                        strSenderPhotoUrl = Constants.UIResNoImageUrl;
                    }
                    else
                    {
                        strSenderPhotoUrl = ds.T_USER_Sender[0].USR_PIC_URL;
                    }

                    strBoxHtml = strBoxHtml.Replace("<%SESSION_UID_URL_VALUE%>", ds.T_USER_Getter[0].USR_UID.ToString());
                    strBoxHtml = strBoxHtml.Replace("<%DETAILS_UID_URL_VALUE%>", ds.T_USER_Sender[0].USR_UID.ToString());
                    strBoxHtml = strBoxHtml.Replace("<%EMAIL_URL_VALUE%>", p_strSenderEMail);
                    strBoxHtml = strBoxHtml.Replace("<%SUPPORT_ID_VALUE%>", p_iTicketID.ToString());
                    strSubject = strSubject.Replace("<%SenderName%>", strSenderName);
                    strBoxHtml = strBoxHtml.Replace("<%SenderName%>", strSenderName);
                    if (p_strUserText == string.Empty)
                    {
                        strBoxHtml = strBoxHtml.Replace("<%UserText%>", string.Empty);
                    }
                    else
                    {
                        strBoxHtml = strBoxHtml.Replace("<%UserText%>", "'" + p_strUserText + "'");
                    }
                    strBoxHtml = strBoxHtml.Replace("<%USR_PIC_URL%>", strSenderPhotoUrl);

                    DateTime dtPublishDateTime = DateTime.Now.AddMinutes(drEmailBoxType.EBT_HOLD_TIME_MINUTES);

                    Logger.Instance.WriteInformation("EMailBoxHtml subject:" + strSubject, MethodBase.GetCurrentMethod(), p_strLoggerSessionID);
                    Logger.Instance.WriteInformation("EMailBoxHtml ready:" + strBoxHtml, MethodBase.GetCurrentMethod(), p_strLoggerSessionID);

                    procAPT_USER_EMAILSelectByUSE_USER_ID.LoadDataSet(ds, ds.T_USER_EMAIL_Getter.TableName, p_iGetterUserID, p_db, p_trn);
                    object oEMB_ID;

                    Logger.Instance.WriteInformation("User EMails started", MethodBase.GetCurrentMethod(), p_strLoggerSessionID);
                    foreach (EMailHandlerDataSet.T_USER_EMAIL_GetterRow drGetterEMail in ds.T_USER_EMAIL_Getter.Rows)
                    {
                        Logger.Instance.Write(drGetterEMail, MethodBase.GetCurrentMethod(), p_strLoggerSessionID);

                        procAPT_EMAIL_BOXInsertInto.ExecuteNonQuery(strBoxHtml, drGetterEMail.USE_EMAIL, strGetterName, strGetterUid, null, dtPublishDateTime, p_strSenderEMail, strSenderName, strSubject, out oEMB_ID, p_db, p_trn);
                        Logger.Instance.WriteProcess("EMailBox added to T_EMAIL_BOX", MethodBase.GetCurrentMethod(), p_strLoggerSessionID);

                        procPT_EMAIL_BOX_TYPE_ENUMIncrementCounter.LoadDataSet(ds, BE.Constants.LOAD_DATASET_TABLE_NAME, (int)p_enmEmailBoxType, p_db, p_trn);
                        Logger.Instance.WriteInformation("EMailBoxType " + drEmailBoxType.EBT_DESCRIPTION + " incremented", MethodBase.GetCurrentMethod(), p_strLoggerSessionID);
                    }
                    Logger.Instance.WriteInformation("User EMails ended", MethodBase.GetCurrentMethod(), p_strLoggerSessionID);

                    if (ds.T_USER_EMAIL_Getter.Rows.Count == 0)
                    {
                        Logger.Instance.WriteInformation("No EMailBox to compose", MethodBase.GetCurrentMethod(), p_strLoggerSessionID);
                    }
                    else
                    {
                        Logger.Instance.WriteProcess("Composed " + ds.T_USER_EMAIL_Getter.Rows.Count + " EMailBoxes", MethodBase.GetCurrentMethod(), p_strLoggerSessionID);
                    }

                    return BE.ResultCode.SUCCESS;
                }
                else
                {
                    Logger.Instance.WriteProcess("Member " + p_iGetterUserID + " not subscribed to get EMails", MethodBase.GetCurrentMethod(), p_strLoggerSessionID);
                    return BE.ResultCode.FAILED;
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strLoggerSessionID);
                throw;
            }
            finally
            {
                Logger.Instance.WriteInformation("Ended", MethodBase.GetCurrentMethod(), p_strLoggerSessionID);
            }
        }

        public static string ComposeEmailBoxInvitee(
            T_EMAIL_BOX_TYPE_ENUM p_enmEmailBoxType, int p_iUserInviteeID,
            Database p_db, DbTransaction p_trn)
        {
            try
            {
                Logger.Instance.WriteInformation("Started", MethodBase.GetCurrentMethod(), Environment.MachineName);

                EMailHandlerInviteDataSet ds = new EMailHandlerInviteDataSet();

                ApplicationHandler.T_EMAIL_BOX_TYPE_ENUMRow drEmailBoxType = ApplicationHandler.Instance.T_EMAIL_BOX_TYPE_ENUM.FindByEBT_CODE((int)p_enmEmailBoxType);
                Logger.Instance.Write(drEmailBoxType, MethodBase.GetCurrentMethod(), Environment.MachineName);

                string strSubject = drEmailBoxType.EBT_SUBJECT;

                string strBoxHtml = Constants.EMailBoxHtml;
                Logger.Instance.WriteProcess("EMailBoxHtml init:" + strBoxHtml, MethodBase.GetCurrentMethod(), Environment.MachineName);

                strBoxHtml = strBoxHtml.Replace("<%EBT_PATH%>", drEmailBoxType.EBT_PATH);
                strBoxHtml = strBoxHtml.Replace("<%EBT_QUERY_STRING%>", drEmailBoxType.EBT_QUERY_STRING);
                strBoxHtml = strBoxHtml.Replace("<%EBT_PIC_URL%>", drEmailBoxType.EBT_PIC_URL);
                strBoxHtml = strBoxHtml.Replace("<%EBT_SUBJECT%>", drEmailBoxType.EBT_SUBJECT);
                strBoxHtml = strBoxHtml.Replace("<%EBT_CLICK_HERE_TO%>", drEmailBoxType.EBT_CLICK_HERE_TO);
                strBoxHtml = strBoxHtml.Replace("<%UIRedirectToAppUrl%>", Constants.UIRedirectToAppUrl);
                strBoxHtml = strBoxHtml.Replace("<%DETAILS_UID_URL_KEY%>", Constants.DETAILS_UID_URL_KEY);
                strBoxHtml = strBoxHtml.Replace("<%EMAIL_URL_KEY%>", Constants.EMAIL_URL_KEY);
                strBoxHtml = strBoxHtml.Replace("<%INVITE_ID_KEY%>", Constants.INVITE_ID_KEY);

                string strGetterUid;
                string strGetterEMail;
                string strGetterName;
                string strSenderName;
                string strSenderPhotoUrl = Constants.UIResNoImageUrl;

                procAPT_USER_INVITEESelectByUSI_ID.LoadDataSet(ds, ds.T_USER_INVITEE.TableName, p_iUserInviteeID, p_db, p_trn);
                strGetterUid = new Guid().ToString();
                strGetterEMail = ds.T_USER_INVITEE[0].USI_EMAIL;
                strGetterName = ds.T_USER_INVITEE[0].USI_NAME;

                procAPT_USERSelectByUSR_ID.LoadDataSet(ds, ds.T_USER_Sender.TableName, ds.T_USER_INVITEE[0].USI_INVITER_USER_ID, p_db, p_trn);
                if (ds.T_USER_Sender.Rows.Count == 0)
                {
                    strSenderName = "A friend";
                    strSenderPhotoUrl = "256x256.png";
                }
                else
                {
                    strSenderName = ds.T_USER_Sender[0].USR_NAME;

                    if (ds.T_USER_Sender[0].IsUSR_PIC_URLNull())
                    {
                        strSenderPhotoUrl = "<%UIWebResUrl%>invite.jpg";
                    }
                    else if (ds.T_USER_Sender[0].USR_PIC_URL == string.Empty)
                    {
                        strSenderPhotoUrl = "<%UIWebResUrl%>invite.jpg";
                    }
                    else
                    {
                        strSenderPhotoUrl = ds.T_USER_Sender[0].USR_PIC_URL;
                    }
                }

                strBoxHtml = strBoxHtml.Replace("<%UIWebResUrl%>", Constants.UIResUrl);
                strBoxHtml = strBoxHtml.Replace("<%EMAIL_URL_VALUE%>", strGetterEMail);
                strBoxHtml = strBoxHtml.Replace("<%INVITE_ID_VALUE%>", p_iUserInviteeID.ToString());
                strSubject = strSubject.Replace("<%SenderName%>", strSenderName);
                strBoxHtml = strBoxHtml.Replace("<%SenderName%>", strSenderName);
                strBoxHtml = strBoxHtml.Replace("<%USR_PIC_URL%>", strSenderPhotoUrl);
                strBoxHtml = strBoxHtml.Replace("<%UserText%>", string.Empty);

                DateTime dtPublishDateTime = DateTime.Now.AddMinutes(drEmailBoxType.EBT_HOLD_TIME_MINUTES);

                Logger.Instance.WriteInformation("EMailBoxHtml subject:" + strSubject, MethodBase.GetCurrentMethod(), Environment.MachineName);
                Logger.Instance.WriteInformation("EMailBoxHtml ready:" + strBoxHtml, MethodBase.GetCurrentMethod(), Environment.MachineName);

                object oEMB_ID;
                procAPT_EMAIL_BOXInsertInto.ExecuteNonQuery(strBoxHtml, strGetterEMail, strGetterName, strGetterUid, null, dtPublishDateTime, string.Empty, strSenderName, strSubject, out oEMB_ID, p_db, p_trn);
                Logger.Instance.WriteProcess("EMailBox added to T_EMAIL_BOX", MethodBase.GetCurrentMethod(), Environment.MachineName);

                procPT_EMAIL_BOX_TYPE_ENUMIncrementCounter.LoadDataSet(ds, BE.Constants.LOAD_DATASET_TABLE_NAME, (int)p_enmEmailBoxType, p_db, p_trn);
                Logger.Instance.WriteInformation("EMailBoxType " + drEmailBoxType.EBT_DESCRIPTION + " incremented", MethodBase.GetCurrentMethod(), Environment.MachineName);

                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                throw;
            }
            finally
            {
                Logger.Instance.WriteInformation("Ended", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
    }
}