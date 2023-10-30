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
using MADA.DatePercent.BE;
using MADA.DatePercent.BL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using MADA.Log.Api.Net;
using MADA.Common.DataType;
using MADA.DatePercent.DBS.dbDatePercentDB.SPs;

namespace MADA.DatePercent.WL.Flex
{
    public partial class Loader : System.Web.UI.Page
    {
        private const int FB_FQL_USER_RETRY = 10;

        public string m_strRootFlexUrl = Constants.RootFlexUrl;
        public string m_strSID;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Url.Query.Contains(Constants.FB_ACCESS_TOKEN_KEY))
                {
                    string strFBUID = string.Empty;
                    Logger.Instance.WriteInformation("Started", System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);

                    //access_token=244125612293062%7C2.AQABTdkCexQH3Kn8.3600.1314284400.1-689887907%7CbAIoJgWgRnmvVvak7OVKzI4prLM
                    string strToken = Request.QueryString[Constants.FB_ACCESS_TOKEN_KEY];
                    Logger.Instance.WriteProcess("strToken:" + strToken, System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);
                    if (strToken == null || strToken == "undefined")
                    {
                        Response.Redirect(Constants.UIRedirectToAppUrl, false);
                    }

                    FacebookDataSet.T_USER_FACEBOOKRow drFbFqlUser = null;
                    for (int i = 0; i < FB_FQL_USER_RETRY; i++)
                    {
                        drFbFqlUser = FacebookUtil.GetFbFqlUser(string.Empty, strToken);
                        try
                        {
                            strFBUID = drFbFqlUser.USF_FB_UID;
                            break;
                        }
                        catch
                        {
                        }
                    }
                    try
                    {
                        strFBUID = drFbFqlUser.USF_FB_UID;
                    }
                    catch
                    {
                        Logger.Instance.WriteProcess("GetFbFqlUser api failed. Retrying...", System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);
                        Response.Redirect(Constants.UIRedirectToAppUrl, false);
                    }
                    Logger.Instance.WriteProcess("FBUID:" + strFBUID, System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);
                    Logger.Instance.Write(drFbFqlUser, System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);

                    string strIP = MADA.Web.HttpContext.HttpContext.GetIP();
                    Logger.Instance.WriteProcess("IP:" + strIP, System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);
                    Location location = LocationHandler.GetLocation(strFBUID, strIP);

                    // RSVP New Year event
                    FacebookUtil.RSVPEvent(strFBUID, "279115852133162", strToken);
                    Logger.Instance.WriteInformation("RSVP New Year event", System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);

                    Database db = DatabaseFactory.CreateDatabase();
                    using (DbConnection con = db.CreateConnection())
                    {
                        con.Open();
                        DbTransaction trn = con.BeginTransaction();
                        Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);

                        try
                        {
                            FacebookDataSet.T_USER_FACEBOOKRow drFbDbUser = FacebookUtil.GetFbDbUser(strFBUID, db, trn);
                            bool bFbDbUserExists = drFbDbUser != null;
                            Logger.Instance.WriteProcess("FbDbUserExists:" + bFbDbUserExists, System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);

                            SessionHandler sessionHandler = new SessionHandler(strFBUID);

                            bool bUserExists;
                            if (bFbDbUserExists)
                            {
                                sessionHandler.UserInit(drFbDbUser.USF_USER_ID, db, trn);
                                bUserExists = sessionHandler.UserExists;
                            }
                            else
                            {
                                bUserExists = false;
                            }
                            Logger.Instance.WriteProcess("UserExists:" + bUserExists, System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);

                            sessionHandler.EMailInit(drFbFqlUser.USF_FB_EMAIL, db, trn);
                            bool bEMailExists = !sessionHandler.EMailIsEmpty;
                            Logger.Instance.WriteProcess("EMailExists:" + bEMailExists, System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);

                            int iUSR_ID;
                            bool bSendEMail;
                            if (bUserExists && bFbDbUserExists)
                            {
                                // user exists, update email, update fb
                                iUSR_ID = sessionHandler.ID;
                                sessionHandler.UserUpdateFromFqlUser(iUSR_ID, drFbFqlUser, db, trn);
                                sessionHandler.EMailInsertIntoUpdate(iUSR_ID, drFbFqlUser.USF_FB_EMAIL, db, trn);
                                FacebookUtil.InsertIntoUpdate(strFBUID, drFbFqlUser, iUSR_ID, db, trn);
                                bSendEMail = false;
                                Logger.Instance.WriteProcess("user exists, update email, update fb done:" + iUSR_ID, System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);
                            }
                            else if (!bUserExists && !bFbDbUserExists && bEMailExists)
                            {
                                // user exists but in the old system, add fb, link to old user
                                iUSR_ID = sessionHandler.T_USER_EMAIL[0].USE_USER_ID;
                                sessionHandler.UserUpdateFromFqlUser(iUSR_ID, drFbFqlUser, db, trn);
                                sessionHandler.EMailInsertIntoUpdate(iUSR_ID, drFbFqlUser.USF_FB_EMAIL, db, trn);
                                FacebookUtil.InsertIntoUpdate(strFBUID, drFbFqlUser, iUSR_ID, db, trn);
                                bSendEMail = true;
                                Logger.Instance.WriteProcess("user exists but in the old system, add fb, link to old user:" + iUSR_ID, System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);
                            }
                            else
                            {
                                // new
                                iUSR_ID = sessionHandler.UserInsertIntoUpdate(drFbFqlUser, db, trn);
                                sessionHandler.EMailInsertIntoUpdate(iUSR_ID, drFbFqlUser.USF_FB_EMAIL, db, trn);
                                sessionHandler.SettingSetDefaults(iUSR_ID, db, trn);
                                FacebookUtil.InsertIntoUpdate(strFBUID, drFbFqlUser, iUSR_ID, db, trn);
                                bSendEMail = true;
                                Logger.Instance.WriteProcess("new:" + iUSR_ID, System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);
                            }
                            Logger.Instance.WriteProcess("SendEMail:" + bSendEMail, System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);

                            sessionHandler.LocationInsertIntoUpdate(iUSR_ID, location, db, trn);
                            sessionHandler.LocationInitCurrent(iUSR_ID, db, trn);

                            m_strSID = HttpContext.Current.Session.SessionID;
                            sessionHandler.SessionDoLogin(m_strSID, iUSR_ID, db, trn);

                            Logger.Instance.WriteInformation("FB_UID:" + strFBUID, System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);
                            Logger.Instance.WriteInformation("USR_ID:" + iUSR_ID, System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);
                            Logger.Instance.WriteInformation("SID:" + m_strSID, System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);

                            trn.Commit();
                            Logger.Instance.WriteCommitTrn(System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);

                            if (bSendEMail && iUSR_ID != -1)
                            {
                                object oEML_ID;
                                procAPT_EMAILInsertInto.ExecuteNonQuery(
                                    "New user:<br/>" +
                                    "ID:" + iUSR_ID + "<br/>" +
                                    "UID:" + drFbFqlUser.USF_FB_UID + "<br/>" +
                                    "Name:" + drFbFqlUser.USF_FB_NAME + "<br/>" +
                                    "EMail:" + drFbFqlUser.USF_FB_EMAIL + "<br/>" +
                                    "Sex:" + drFbFqlUser.USF_FB_SEX + "<br/>" +
                                    "Birthday:" + drFbFqlUser.USF_BIRTHDAY.ToShortDateString() + "<br/>" +
                                    "IP:" + strIP + "<br/>" +
                                    "Location:" + location.ToString() + "<br/>" +
                                    "<a href='" + drFbFqlUser.USF_FB_PROFILE_URL + "'>Profile Url<a/><br/>" +
                                    "<img src='" + drFbFqlUser.USF_FB_PIC + "' />",
                                    "rk@datepercent.com",
                                    "rk@datepercent.com",
                                    null,
                                    "DatePercent Ltd",
                                    "New user:" + drFbFqlUser.USF_FB_NAME,
                                    out oEML_ID);
                                procAPT_EMAILInsertInto.ExecuteNonQuery(
                                    "New user:<br/>" +
                                    "ID:" + iUSR_ID + "<br/>" +
                                    "UID:" + drFbFqlUser.USF_FB_UID + "<br/>" +
                                    "Name:" + drFbFqlUser.USF_FB_NAME + "<br/>" +
                                    "EMail:" + drFbFqlUser.USF_FB_EMAIL + "<br/>" +
                                    "Sex:" + drFbFqlUser.USF_FB_SEX + "<br/>" +
                                    "Birthday:" + drFbFqlUser.USF_BIRTHDAY.ToShortDateString() + "<br/>" +
                                    "IP:" + strIP + "<br/>" +
                                    "Location:" + location.ToString() + "<br/>" +
                                    "<a href='" + drFbFqlUser.USF_FB_PROFILE_URL + "'>Profile Url<a/><br/>" +
                                    "<img src='" + drFbFqlUser.USF_FB_PIC + "' />",
                                    "tal.kleinfeld@gmail.com",
                                    "tal.kleinfeld@gmail.com",
                                    null,
                                    "DatePercent Ltd",
                                    "New user:" + drFbFqlUser.USF_FB_NAME,
                                    out oEML_ID);
                                Logger.Instance.WriteProcess("Email sent", System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);
                            }

                            Logger.Instance.WriteInformation("Ended", System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);

                            // goto html to load the swf
                        }
                        catch (Exception ex)
                        {
                            trn.Rollback();
                            Logger.Instance.WriteRollbackTrn(ex, System.Reflection.MethodBase.GetCurrentMethod(), strFBUID);
                            throw;
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
                else
                {
                    // goto oAuth
                    Response.Redirect(Constants.RootUrl + "Flex/FBLogin.aspx" + Request.Url.Query, false);
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                Response.Redirect(Constants.UIRedirectToAppUrl, false);
            }
        }
    }
}