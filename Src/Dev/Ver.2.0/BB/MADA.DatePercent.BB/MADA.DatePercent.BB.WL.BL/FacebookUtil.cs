using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using MADA.Log.Api.Net;
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.SPs;
using MADA.DatePercent.BB.WL.BE;
using System.Reflection;

namespace MADA.DatePercent.BB.WL.BL
{
    public class FacebookUtil
    {
        public static string InsertIntoUpdate(string p_strSID, FacebookDataSet.T_USER_FACEBOOKRow p_drFbFqlUser, int p_iUSR_ID, Database p_db, DbTransaction p_trn)
        {
            try
            {
                object oUSF_ID;
                procAPT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.ExecuteNonQuery(
                    null,
                    p_drFbFqlUser.USF_BIRTHDAY,
                    p_drFbFqlUser.USF_FB_BIRTHDAY_DATE,
                    p_drFbFqlUser.USF_FB_EMAIL,
                    p_drFbFqlUser.USF_FB_FIRST_NAME,
                    p_drFbFqlUser.USF_FB_LAST_NAME,
                    p_drFbFqlUser.USF_FB_LOCALE,
                    p_drFbFqlUser.USF_FB_MIDDLE_NAME,
                    p_drFbFqlUser.USF_FB_NAME,
                    p_drFbFqlUser.USF_FB_PIC,
                    p_drFbFqlUser.USF_FB_PROFILE_URL,
                    p_drFbFqlUser.USF_FB_SEX,
                        p_drFbFqlUser.USF_FB_TIMEZONE,
                    p_drFbFqlUser.USF_FB_UID,
                    p_drFbFqlUser.USF_FB_USERNAME,
                    null,
                    p_drFbFqlUser.USF_SEX_TYPE,
                    p_drFbFqlUser.USF_THIRD_PARTY_ID,
                    p_drFbFqlUser.USF_UID,
                    p_iUSR_ID,
                    out oUSF_ID,
                    p_db, p_trn);
                Logger.Instance.WriteProcess("Success", MethodBase.GetCurrentMethod(), p_strSID);

                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return ResultCode.FAILED;
            }
        }

        public static FacebookDataSet.T_USER_FACEBOOKRow GetFbDbUser(string p_strFBUID, Database p_db, DbTransaction p_trn)
        {
            try
            {
                Logger.Instance.WriteProcess("p_strFBUID:" + p_strFBUID, MethodBase.GetCurrentMethod(), p_strFBUID);
                FacebookDataSet ds = new FacebookDataSet();

                procAPT_USER_FACEBOOKSelectByUSF_FB_UID.LoadDataSet(ds, ds.T_USER_FACEBOOK.TableName, p_strFBUID, p_db, p_trn);
                if (ds.T_USER_FACEBOOK.Rows.Count > 0)
                {
                    Logger.Instance.Write(ds.T_USER_FACEBOOK[0], MethodBase.GetCurrentMethod(), p_strFBUID);
                    return ds.T_USER_FACEBOOK[0];
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strFBUID);
                return null;
            }
        }

        public static FacebookDataSet.T_USER_FACEBOOKRow GetFbFqlUser(string p_strSID, string p_strToken)
        {
            try
            {
                Logger.Instance.WriteProcess("GetFbFqlUser Started", MethodBase.GetCurrentMethod(), p_strSID);
                Logger.Instance.WriteProcess("p_strToken:" + p_strToken, MethodBase.GetCurrentMethod(), p_strSID);

                FacebookDataSet ds = new FacebookDataSet();

                Logger.Instance.WriteProcess("Get FqlUser", MethodBase.GetCurrentMethod(), string.Empty);
                DataSet dsTemp = new DataSet();
                dsTemp.ReadXml(new XmlNodeReader(GetFbGraphApi(p_strSID, "https://api.facebook.com/method/fql.query?query=SELECT uid,third_party_id,first_name,middle_name,last_name,name,pic,timezone,birthday_date,locale,profile_url,username,sex,email FROM user WHERE uid=me()&access_token=" + p_strToken)));
                Logger.Instance.Write(dsTemp, MethodBase.GetCurrentMethod(), p_strSID);
                DataRow drFqlUser;
                try
                {
                    drFqlUser = dsTemp.Tables["user"].Rows[0];
                }
                catch
                {
                    return null;
                }
                if (drFqlUser == null)
                {
                    throw new Exception("Failed to get FqlUser");
                }
                Logger.Instance.Write(drFqlUser, MethodBase.GetCurrentMethod(), p_strSID);

                Logger.Instance.WriteProcess("Transform data", MethodBase.GetCurrentMethod(), p_strSID);
                DateTime dtFqlBirthday;
                try
                {
                    dtFqlBirthday = new DateTime(
                        int.Parse(drFqlUser["birthday_date"].ToString().Split('/')[2]),
                        int.Parse(drFqlUser["birthday_date"].ToString().Split('/')[0]),
                        int.Parse(drFqlUser["birthday_date"].ToString().Split('/')[1]));
                }
                catch (Exception ex)
                {
                    Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                    Logger.Instance.WriteCritical("birthday_date:" + drFqlUser["birthday_date"].ToString(), MethodBase.GetCurrentMethod(), p_strSID);
                    dtFqlBirthday = new DateTime(1990, 6, 15);
                }
                Logger.Instance.WriteInformation("dtFqlBirthday:" + dtFqlBirthday.ToString(), MethodBase.GetCurrentMethod(), p_strSID);

                int iFqlSex;
                switch (drFqlUser["sex"].ToString().ToUpper())
                {
                    case "FEMALE":
                        iFqlSex = 2;
                        break;
                    default:
                        iFqlSex = 1;
                        break;
                }
                Logger.Instance.WriteInformation("iFqlSex:" + iFqlSex, MethodBase.GetCurrentMethod(), p_strSID);

                Logger.Instance.WriteProcess("Convert to T_USER_FACEBOOK", MethodBase.GetCurrentMethod(), p_strSID);
                ds.T_USER_FACEBOOK.AddT_USER_FACEBOOKRow(
                    -1,
                    drFqlUser["uid"].ToString(),
                    drFqlUser["uid"].ToString(),
                    drFqlUser["third_party_id"].ToString(),
                    drFqlUser["first_name"].ToString(),
                    drFqlUser["middle_name"].ToString(),
                    drFqlUser["last_name"].ToString(),
                    drFqlUser["name"].ToString(),
                    drFqlUser["pic"].ToString(),
                    drFqlUser["timezone"].ToString(),
                    drFqlUser["birthday_date"].ToString(),
                    dtFqlBirthday,
                    drFqlUser["locale"].ToString(),
                    drFqlUser["profile_url"].ToString(),
                    drFqlUser["username"].ToString(),
                    drFqlUser["sex"].ToString(),
                    iFqlSex,
                    drFqlUser["email"].ToString());
                Logger.Instance.WriteProcess("T_USER_FACEBOOK Converted", MethodBase.GetCurrentMethod(), p_strSID);
                FacebookDataSet.T_USER_FACEBOOKRow drFacebookUser = ds.T_USER_FACEBOOK[0];
                Logger.Instance.WriteProcess("drFacebookUser:" + drFacebookUser.USF_FB_UID, MethodBase.GetCurrentMethod(), p_strSID);
                if (drFacebookUser == null)
                {
                    throw new Exception("Failed to convert to T_USER_FACEBOOKRow");
                }
                Logger.Instance.Write(drFacebookUser, MethodBase.GetCurrentMethod(), p_strSID);

                Logger.Instance.WriteProcess("GetFbFqlUser Return", MethodBase.GetCurrentMethod(), p_strSID);
                return drFacebookUser;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
            finally
            {
                Logger.Instance.WriteProcess("GetFbFqlUser Ended", MethodBase.GetCurrentMethod(), p_strSID);
            }
        }
        public static FacebookDataSet.T_USER_PHOTODataTable GetFbFqlPhotos(string p_strSID, string p_strToken)
        {
            try
            {
                FacebookDataSet ds = new FacebookDataSet();

                Logger.Instance.WriteProcess("Get FqlPhotos", MethodBase.GetCurrentMethod(), p_strSID);
                DataSet dsTemp = new DataSet();
                dsTemp.ReadXml(new XmlNodeReader(GetFbGraphApi(p_strSID, "https://api.facebook.com/method/fql.query?query=SELECT pid, src, src_small, src_big FROM photo WHERE aid IN (SELECT aid FROM album WHERE owner = me())&access_token=" + p_strToken)));
                Logger.Instance.WriteProcess("Photo count:" + dsTemp.Tables["photo"].Rows.Count, MethodBase.GetCurrentMethod(), p_strSID);
                foreach (DataRow dr in dsTemp.Tables["photo"].Rows)
                {
                    Logger.Instance.Write(dr, MethodBase.GetCurrentMethod(), p_strSID);
                    ds.T_USER_PHOTO.AddT_USER_PHOTORow(-1, dr["src_big"].ToString(), dr["src_small"].ToString(), dr["src"].ToString(), false);
                }

                return ds.T_USER_PHOTO;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }
        public static String RSVPEvent(string p_strSID, string p_strEventID, string p_strToken)
        {
            try
            {
                Logger.Instance.WriteProcess("RSVPEvent", MethodBase.GetCurrentMethod(), p_strSID);
                DataSet dsTemp = new DataSet();
                //https://api.facebook.com/method/events.rsvp?eid=279115852133162&rsvp_status=attending&access_token=...
                GetFbGraphApi(p_strSID, "https://api.facebook.com/method/events.rsvp?eid=" + p_strEventID + "&rsvp_status=attending&access_token=" + p_strToken);

                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return ResultCode.FAILED;
            }
        }
        public static DataSet GetFriends(string p_strSID, string p_strToken)
        {
            try
            {
                Logger.Instance.WriteProcess("GetFriends", MethodBase.GetCurrentMethod(), p_strSID);
                DataSet dsTemp = new DataSet();
                //https://api.facebook.com/method/friends.get?access_token=
                dsTemp.ReadXml(new XmlNodeReader(GetFbGraphApi(p_strSID, "https://api.facebook.com/method/friends.get?access_token=" + p_strToken)));
                Logger.Instance.WriteProcess("Friends count:" + dsTemp.Tables["friends_get_response"].Rows.Count, MethodBase.GetCurrentMethod(), p_strSID);

                return dsTemp;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }

        private static XmlDocument GetFbGraphApi(string p_strSID, string p_strGraphApiUri)
        {
            WebRequest webRequest;
            WebResponse webResponse = null;
            StreamReader streamReader = null;

            try
            {
                Uri objUrl = new System.Uri(p_strGraphApiUri);
                string strResponse = string.Empty;

                webRequest = WebRequest.Create(objUrl);
                webResponse = webRequest.GetResponse();

                streamReader = new StreamReader(webResponse.GetResponseStream());
                strResponse = streamReader.ReadToEnd();

                if (strResponse.Contains("<error_msg>Error validating access token:"))
                {
                    Logger.Instance.WriteCritical("Failed to validate the access token for SID:" + p_strSID, MethodBase.GetCurrentMethod(), p_strSID);
                    return null;
                }
                else
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.InnerXml = strResponse;
                    return xmlDocument;
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
                if (webResponse != null)
                {
                    webResponse.Close();
                }
            }
        }
    }
}