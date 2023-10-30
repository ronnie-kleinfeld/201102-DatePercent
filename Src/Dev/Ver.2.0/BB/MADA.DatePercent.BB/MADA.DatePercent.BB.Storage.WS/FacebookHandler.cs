using System.Timers;
using MADA.Log.Api.Net;
using System;
using System.Data;
using System.Xml;
using System.Net;
using System.IO;
using System.Reflection;
using MADA.DatePercent.BB.Storage.WS.Properties;
using MADA.DatePercent.SMTP.Api.Net;
using MADA.DatePercent.BB.Storage.DBS.dbStorageDB.SPs;
using MADA.Common.DataType;
using MADA.DatePercent.BB.BL;

namespace MADA.DatePercent.BB.Storage.WS
{
    // Facebook Query Language
    //http://developers.facebook.com/docs/reference/fql/
    // FQL Test Console
    //http://developers.facebook.com/docs/reference/rest/fql.query/
    // Graph API Explorer
    //https://developers.facebook.com/tools/explorer#!/tools/explorer?method=GET&path=689887907
    // Permissions
    //user_interests%2Cuser_photos%2Cuser_activities%2Cuser_groups%2Cuser_likes%2Cuser_birthday%2Cuser_events%2Cemail%2Crsvp_event%2Cread_stream
    partial class FacebookHandler
    {
        #region Singleton
        private static FacebookHandler s_dsInstance;
        public static FacebookHandler Instance
        {
            get
            {
                if (s_dsInstance == null)
                {
                    s_dsInstance = new FacebookHandler();
                    s_dsInstance.Init();
                }

                return s_dsInstance;
            }
        }
        #endregion
        #region Members
        private Timer m_timer;
        #endregion
        #region Class
        private void Init()
        {
            try
            {
                Logger.Instance.WriteProcess("Started", MethodBase.GetCurrentMethod(), Environment.MachineName);

                m_timer = new Timer();
                m_timer.Interval = 5000;
                m_timer.Elapsed += new ElapsedEventHandler(m_timer_Elapsed);
                m_timer.Start();

                Logger.Instance.WriteProcess("Ended", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Mailer.Instance.Compose("DATEPERCENT CRITICAL",
                    "<hr/>MADA.DatePercent.BL::FacebookHandler::Init()<hr/>Failed to connect to the database through Microsoft DataApplicationBlock<hr/>web.config is missing or set to localhost?<hr/>Exception='" + ex.Message + "'<hr/>");
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
        #region Methods
        private string FBSafeString(string p_strSID, DataRow p_dr, string p_strColumnName, string p_strDefaultValue)
        {
            string strResult;

            try
            {
                strResult = p_dr[p_strColumnName].ToString();
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                strResult = p_strDefaultValue;
            }

            //Logger.Instance.WriteInformation("strResult:" + strResult, MethodBase.GetCurrentMethod(), p_strSID);
            return strResult;
        }
        private string FBSafeNickName(string p_strSID, string p_strFirstName, string p_strLastName, int p_iUserID)
        {
            string strResult;

            try
            {
                strResult = DoEncriptions(p_strFirstName) + DoEncriptions(p_strLastName) + p_iUserID.ToString();
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                strResult = p_strFirstName + p_strLastName + p_iUserID.ToString();
            }

            //Logger.Instance.WriteInformation("strResult:" + strResult, MethodBase.GetCurrentMethod(), p_strSID);
            return strResult;
        }
        private System.DateTime FBbirthday_dateToDateTime(string p_strSID, DataRow p_dr)
        {
            System.DateTime dtBirthday;

            try
            {
                dtBirthday = new System.DateTime(
                    int.Parse(p_dr["birthday_date"].ToString().Split('/')[2]),
                    int.Parse(p_dr["birthday_date"].ToString().Split('/')[0]),
                    int.Parse(p_dr["birthday_date"].ToString().Split('/')[1]));
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                dtBirthday = new System.DateTime(1990, 6, 15);
            }

            //Logger.Instance.WriteInformation("dtBirthday:" + dtBirthday.ToString(), MethodBase.GetCurrentMethod(), p_strSID);
            return dtBirthday;
        }
        private int FBsexToInt(string p_strSID, DataRow p_dr)
        {
            int iSexCode;

            // gender
            //male|female
            switch (p_dr["sex"].ToString().ToUpper())
            {
                case "FEMALE":
                    iSexCode = 2;
                    break;
                default:
                    iSexCode = 1;
                    break;
            }

            //Logger.Instance.WriteInformation("iSexCode:" + iSexCode, MethodBase.GetCurrentMethod(), p_strSID);
            return iSexCode;
        }
        private string FBPicToUrl(string p_strSID, DataRow p_dr, string p_strColumnName, bool p_bIsPicX)
        {
            string strResult = string.Empty;

            try
            {
                strResult = p_dr[p_strColumnName].ToString();
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
            }
            if (strResult == string.Empty)
            {
                switch (FBsexToInt(p_strSID, p_dr))
                {
                    case 2:
                        if (p_bIsPicX)
                        {
                            strResult = "../Res/Platform/FemaleX.png";
                        }
                        else
                        {
                            strResult = "../Res/Platform/Female.png";
                        }
                        break;
                    default:
                        if (p_bIsPicX)
                        {
                            strResult = "../Res/Platform/MaleX.png";
                        }
                        else
                        {
                            strResult = "../Res/Platform/Male.png";
                        }
                        break;
                }
            }

            //Logger.Instance.WriteInformation("strResult:" + strResult, MethodBase.GetCurrentMethod(), p_strSID);
            return strResult;
        }

        public static string DoEncriptions(string p_strText)
        {
            string strResult = p_strText;

            strResult = DoEncription(strResult, ' ');
            strResult = DoEncription(strResult, '-');
            strResult = DoEncription(strResult, '+');
            strResult = DoEncription(strResult, ',');
            strResult = DoEncription(strResult, '\\');
            strResult = DoEncription(strResult, '/');
            strResult = DoEncription(strResult, '=');
            strResult = DoEncription(strResult, '_');
            strResult = DoEncription(strResult, '~');
            strResult = DoEncription(strResult, '.');

            return strResult;
        }
        private static string DoEncription(string p_strText, char p_chSep)
        {
            string strResult = string.Empty;

            string[] a_strText = p_strText.Split(p_chSep);
            if (a_strText.Length > 1)
            {
                foreach (string strText in a_strText)
                {
                    if (strText.Length > 0)
                    {
                        strResult += strText.Substring(0, 1);
                    }
                }
            }
            else
            {
                strResult = p_strText;
            }

            return strResult;
        }
        #endregion
        #region Events
        private void m_timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                m_timer.Stop();


                while (T_INCOMING_USERS.Rows.Count > 0)
                {
                    int iUserID;
                    string strToken;

                    T_INCOMING_USERSRow dr;
                    lock (T_INCOMING_USERS)
                    {
                        dr = T_INCOMING_USERS[0];
                        Logger.Instance.Write(dr, MethodBase.GetCurrentMethod(), string.Empty);
                        iUserID = dr.INU_USER_ID;
                        strToken = dr.INU_TOKEN;

                        T_INCOMING_USERS.RemoveT_INCOMING_USERSRow(dr);
                    }

                    try
                    {
                        // me
                        //select username,first_name,middle_name,last_name,name,pic_big,pic_square,profile_url,religion,birthday_date,sex,political,activities,interests,music,tv,movies,books,education_history,work_history,locale,email,games,work,education,sports,favorite_athletes,favorite_teams,inspirational_people,languages from user where uid=me()
                        DataSet dsUser = new DataSet();
                        dsUser.ReadXml(new XmlNodeReader(GetFbGraphApi(Environment.MachineName, "https://api.facebook.com/method/fql.query?query=select username,first_name,middle_name,last_name,name,pic_big,pic_square,profile_url,religion,birthday_date,sex,political,activities,interests,music,tv,movies,books,education_history,work_history,locale,email,games,work,education,sports,favorite_athletes,favorite_teams,inspirational_people,languages from user where uid=me()&access_token=" + strToken)));
                        /*
                            "username": "ronnie.kleinfeld",
                            "first_name": "Ronnie",
                            "middle_name": "",
                            "last_name": "Kleinfeld",
                            "name": "Ronnie Kleinfeld",
                            "pic_big": "http://profile.ak.fbcdn.net/hprofile-ak-snc4/275387_689887907_1672429002_n.jpg",
                            "pic_square": "http://profile.ak.fbcdn.net/hprofile-ak-snc4/275387_689887907_1672429002_q.jpg",
                            "profile_url": "http://www.facebook.com/ronnie.kleinfeld",
                            "birthday_date": "06/15/1970",
                            "sex": "male",
                            "locale": "en_US",
                            "email": "ronnie.kleinfeld@gmail.com",
                        */
                        DataRow drFqlUser = dsUser.Tables["user"].Rows[0];
                        Logger.Instance.Write(drFqlUser, MethodBase.GetCurrentMethod(), Environment.MachineName);
                        procPT_USERUpdateFBByUSR_ID.ExecuteNonQuery(
                            FBbirthday_dateToDateTime(Environment.MachineName, drFqlUser),
                            FBSafeString(Environment.MachineName, drFqlUser, "birthday_date", string.Empty),
                            FBSafeString(Environment.MachineName, drFqlUser, "email", string.Empty),
                            FBSafeString(Environment.MachineName, drFqlUser, "first_name", string.Empty),
                            FBSafeString(Environment.MachineName, drFqlUser, "last_name", string.Empty),
                            FBSafeString(Environment.MachineName, drFqlUser, "locale", string.Empty),
                            FBSafeString(Environment.MachineName, drFqlUser, "middle_name", string.Empty),
                            FBPicToUrl(Environment.MachineName, drFqlUser, "pic_big", false),
                            FBPicToUrl(Environment.MachineName, drFqlUser, "pic_square", true),
                            FBSafeString(Environment.MachineName, drFqlUser, "profile_url", string.Empty),
                            FBSafeString(Environment.MachineName, drFqlUser, "sex", string.Empty),
                            iUserID,
                            FBsexToInt(Environment.MachineName, drFqlUser));
                        Logger.Instance.WriteInformation("me done", MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.WriteCritical("user:" + ex.Message, MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }

                    try
                    {
                        // my profile photos
                        //select pid,src_big from photo where aid in (select aid, type from album where type='profile' and owner=me())
                        DataSet dsPhoto = new DataSet();
                        dsPhoto.ReadXml(new XmlNodeReader(GetFbGraphApi(Environment.MachineName, "https://api.facebook.com/method/fql.query?query=select pid,src_big from photo where aid in (select aid, type from album where type='profile' and owner=me())&access_token=" + strToken)));
                        /*
                            [
                                {
                                    "pid": "2963045998474432045",
                                    "src_big": "http://a3.sphotos.ak.fbcdn.net/hphotos-ak-snc3/25734_358491607907_689887907_3542573_2923893_n.jpg"
                                }
                            ]
                        */
                        DataTable dtPhoto = dsPhoto.Tables["photo"];
                        //Logger.Instance.Write(dtPhoto, MethodBase.GetCurrentMethod(), Environment.MachineName);
                        foreach (DataRow drPhoto in dtPhoto.Rows)
                        {
                            procPT_USER_PHOTOInsertIntoUpdateByUSP_FB_PID.ExecuteNonQuery(
                                FBPicToUrl(Environment.MachineName, drPhoto, "src_big", true),
                                FBSafeString(Environment.MachineName, drPhoto, "pid", string.Empty),
                                iUserID);
                            //Logger.Instance.WriteInformation("my profile photos done", MethodBase.GetCurrentMethod(), Environment.MachineName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.WriteCritical("photo:" + ex.Message, MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }

                    try
                    {
                        // my friends
                        //select uid,name,pic_big,pic_square,profile_url,sex,locale,email from user where uid in (select uid2 from friend where uid1 = me())
                        DataSet dsFriend = new DataSet();
                        dsFriend.ReadXml(new XmlNodeReader(GetFbGraphApi(Environment.MachineName, "https://api.facebook.com/method/fql.query?query=select uid,name,pic_big,pic_square,profile_url,sex,locale,email from user where uid in (select uid2 from friend where uid1 = me())&access_token=" + strToken)));
                        /*
                            [
                              {
                                "uid": 547928255,
                                "name": "Ziva Kaplan",
                                "pic_big": "http://profile.ak.fbcdn.net/static-ak/rsrc.php/v1/yp/r/yDnr5YfbJCH.gif",
                                "pic_square": "http://profile.ak.fbcdn.net/static-ak/rsrc.php/v1/y9/r/IB7NOFmPw2a.gif",
                                "profile_url": "http://www.facebook.com/profile.php?id=547928255",
                                "sex": "female",
                                "locale": "he_IL",
                                "email": null
                              }
                            ]
                        */
                        DataTable dtFriend = dsFriend.Tables["user"];
                        //Logger.Instance.Write(dtFriend, MethodBase.GetCurrentMethod(), Environment.MachineName);
                        foreach (DataRow drFriend in dtFriend.Rows)
                        {
                            procPT_USER_FRIENDInsertIntoUpdateByUSF_USER_IDUSR_FB_UID.ExecuteNonQuery(
                                iUserID,
                                FBSafeString(Environment.MachineName, drFriend, "email", string.Empty),
                                FBSafeString(Environment.MachineName, drFriend, "locale", string.Empty),
                                FBSafeString(Environment.MachineName, drFriend, "name", string.Empty),
                                FBPicToUrl(Environment.MachineName, drFriend, "pic_big", true),
                                FBPicToUrl(Environment.MachineName, drFriend, "pic_square", true),
                                FBSafeString(Environment.MachineName, drFriend, "profile_url", string.Empty),
                                FBSafeString(Environment.MachineName, drFriend, "sex", string.Empty),
                                FBSafeString(Environment.MachineName, drFriend, "uid", string.Empty),
                                FBsexToInt(Environment.MachineName, drFriend));
                            //Logger.Instance.WriteInformation("my friends done", MethodBase.GetCurrentMethod(), Environment.MachineName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.WriteCritical("user:" + ex.Message, MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }

                    try
                    {
                        // pages I like
                        //select page_id,name,pic_large,pic_square,page_url from page where page_id in (select page_id from page_fan where uid=me())
                        DataSet dsPage = new DataSet();
                        dsPage.ReadXml(new XmlNodeReader(GetFbGraphApi(Environment.MachineName, "https://api.facebook.com/method/fql.query?query=select page_id,name,pic_large,pic_square,page_url from page where page_id in (select page_id from page_fan where uid=me())&access_token=" + strToken)));
                        /*
                            [
                              {
                                "page_id": 406418575217,
                                "name": "Family Activities",
                                "pic_large": "http://profile.ak.fbcdn.net/static-ak/rsrc.php/v1/y4/r/GylKztrlHCg.png",
                                "pic_square": "http://profile.ak.fbcdn.net/static-ak/rsrc.php/v1/yS/r/SakaC0tDjfm.png",
                                "page_url": "http://www.facebook.com/pages/Family-Activities/406418575217"
                              }
                            ]
                        */
                        DataTable dtPage = dsPage.Tables["page"];
                        //Logger.Instance.Write(dtPage, MethodBase.GetCurrentMethod(), Environment.MachineName);
                        foreach (DataRow drPage in dtPage.Rows)
                        {
                            procPT_USER_LIKEInsertIntoUpdateByUSK_FB_OBJECT_IDUSK_USER_ID.ExecuteNonQuery(
                                FBSafeString(Environment.MachineName, drPage, "name", string.Empty),
                                FBSafeString(Environment.MachineName, drPage, "page_id", string.Empty),
                                FBSafeString(Environment.MachineName, drPage, "page_url", string.Empty),
                                FBPicToUrl(Environment.MachineName, drPage, "pic_large", true),
                                FBPicToUrl(Environment.MachineName, drPage, "pic_square", true),
                                iUserID);
                            //Logger.Instance.WriteInformation("pages I like done", MethodBase.GetCurrentMethod(), Environment.MachineName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.WriteCritical("page:" + ex.Message, MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }

                    try
                    {
                        // events I rsvp
                        //select eid,name,pic_big,pic_square from event where eid in (select eid from event_member where rsvp_status<>'declined' and uid=me())
                        DataSet dsEvent = new DataSet();
                        dsEvent.ReadXml(new XmlNodeReader(GetFbGraphApi(Environment.MachineName, "https://api.facebook.com/method/fql.query?query=select eid,name,pic_big,pic_square from event where eid in (select eid from event_member where rsvp_status<>'declined' and uid=me())&access_token=" + strToken)));
                        /*
                            [
                              {
                                "eid": 312977768744058,
                                "name": "asdfasdf walentynki",
                                "pic_big": "http://profile.ak.fbcdn.net/hprofile-ak-ash2/373675_312977768744058_55624433_n.jpg",
                                "pic_square": "http://profile.ak.fbcdn.net/hprofile-ak-ash2/373675_312977768744058_55624433_q.jpg"
                              }
                            ]
                        */
                        DataTable dtEvent = dsEvent.Tables["event"];
                        //Logger.Instance.Write(dtEvent, MethodBase.GetCurrentMethod(), Environment.MachineName);
                        foreach (DataRow drEvent in dtEvent.Rows)
                        {
                            procPT_USER_LIKEInsertIntoUpdateByUSK_FB_OBJECT_IDUSK_USER_ID.ExecuteNonQuery(
                                FBSafeString(Environment.MachineName, drEvent, "name", string.Empty),
                                FBSafeString(Environment.MachineName, drEvent, "eid", string.Empty),
                                string.Empty,
                                FBPicToUrl(Environment.MachineName, drEvent, "pic_big", true),
                                FBPicToUrl(Environment.MachineName, drEvent, "pic_square", true),
                                iUserID);
                            //Logger.Instance.WriteInformation("events I rsvp done", MethodBase.GetCurrentMethod(), Environment.MachineName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.WriteCritical("event:" + ex.Message, MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }

                    try
                    {
                        // groups I joined
                        //select gid,name,pic_big,icon34 from group where gid in (select gid from group_member where uid=me())
                        DataSet dsGroup = new DataSet();
                        dsGroup.ReadXml(new XmlNodeReader(GetFbGraphApi(Environment.MachineName, "https://api.facebook.com/method/fql.query?query=select gid,name,pic_big,icon34 from group where gid in (select gid from group_member where uid=me())&access_token=" + strToken)));
                        /*
                            [
                              {
                                "gid": 120439611391031,
                                "name": "Groups",
                                "pic_big": "http://profile.ak.fbcdn.net/hprofile-ak-snc4/157935_120439611391031_1624495724_n.jpg",
                                "icon34": "http://static.ak.fbcdn.net/rsrc.php/v1/yH/r/6-Zo5i7Axnb.png"
                              }
                            ]
                        */
                        DataTable dtGroup = dsGroup.Tables["group"];
                        //Logger.Instance.Write(dtGroup, MethodBase.GetCurrentMethod(), Environment.MachineName);
                        foreach (DataRow drGroup in dtGroup.Rows)
                        {
                            procPT_USER_LIKEInsertIntoUpdateByUSK_FB_OBJECT_IDUSK_USER_ID.ExecuteNonQuery(
                                FBSafeString(Environment.MachineName, drGroup, "name", string.Empty),
                                FBSafeString(Environment.MachineName, drGroup, "gid", string.Empty),
                                string.Empty,
                                FBPicToUrl(Environment.MachineName, drGroup, "pic_big", true),
                                FBPicToUrl(Environment.MachineName, drGroup, "icon34", true),
                                iUserID);
                            //Logger.Instance.WriteInformation("groups I joined done", MethodBase.GetCurrentMethod(), Environment.MachineName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.WriteCritical("group:" + ex.Message, MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }

                    try
                    {
                        // photos I like
                        //select pid,src_big from photo where object_id in (select object_id from like where user_id=me())
                        DataSet dsPhotoILike = new DataSet();
                        dsPhotoILike.ReadXml(new XmlNodeReader(GetFbGraphApi(Environment.MachineName, "https://api.facebook.com/method/fql.query?query=select pid,src_big from photo where object_id in (select object_id from like where user_id=me())&access_token=" + strToken)));
                        /*
                            [
                              {
                                "pid": "18978507165_11626128",
                                "src_big": "http://a8.sphotos.ak.fbcdn.net/hphotos-ak-ash4/308431_10150549547637166_18978507165_11626128_375581256_n.jpg"
                              }
                            ]
                        */
                        DataTable dtPhotoILike = dsPhotoILike.Tables["photo"];
                        //Logger.Instance.Write(dtPhotoILike, MethodBase.GetCurrentMethod(), Environment.MachineName);
                        foreach (DataRow drPhotoILike in dtPhotoILike.Rows)
                        {
                            procPT_USER_LIKEInsertIntoUpdateByUSK_FB_OBJECT_IDUSK_USER_ID.ExecuteNonQuery(
                                string.Empty,
                                FBSafeString(Environment.MachineName, drPhotoILike, "pid", string.Empty),
                                string.Empty,
                                FBPicToUrl(Environment.MachineName, drPhotoILike, "src_big", true),
                                FBPicToUrl(Environment.MachineName, drPhotoILike, "src_big", true),
                                iUserID);
                            //Logger.Instance.WriteInformation("photos I like done", MethodBase.GetCurrentMethod(), Environment.MachineName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.WriteCritical("photo:" + ex.Message, MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }

                    try
                    {
                        // applications I like
                        //select app_id,display_name,icon_url,logo_url from application where app_id in (select page_id from page_fan where uid=me())
                        DataSet dsApplication = new DataSet();
                        dsApplication.ReadXml(new XmlNodeReader(GetFbGraphApi(Environment.MachineName, "https://api.facebook.com/method/fql.query?query=select app_id,display_name,icon_url,logo_url from application where app_id in (select page_id from page_fan where uid=me())&access_token=" + strToken)));
                        /*
                            [
                              {
                                "app_id": "113869198637480",
                                "display_name": "Developer Site",
                                "icon_url": "http://photos-g.ak.fbcdn.net/photos-ak-snc1/v27562/20/113869198637480/app_2_113869198637480_3190.gif",
                                "logo_url": "http://photos-h.ak.fbcdn.net/photos-ak-snc1/v27562/20/113869198637480/app_1_113869198637480_4648.gif"
                              }
                            ]
                         */
                        DataTable dtApplication = dsApplication.Tables["app_info"];
                        //Logger.Instance.Write(dtApplication, MethodBase.GetCurrentMethod(), Environment.MachineName);
                        foreach (DataRow drApplication in dtApplication.Rows)
                        {
                            procPT_USER_LIKEInsertIntoUpdateByUSK_FB_OBJECT_IDUSK_USER_ID.ExecuteNonQuery(
                                FBSafeString(Environment.MachineName, drApplication, "display_name", string.Empty),
                                FBSafeString(Environment.MachineName, drApplication, "app_id", string.Empty),
                                string.Empty,
                                FBPicToUrl(Environment.MachineName, drApplication, "logo_url", true),
                                FBPicToUrl(Environment.MachineName, drApplication, "icon_url", true),
                                iUserID);
                            //Logger.Instance.WriteInformation("applications I like done", MethodBase.GetCurrentMethod(), Environment.MachineName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.WriteCritical("app_info:" + ex.Message, MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }

                    try
                    {
                        // rsvp events
                        GetFbGraphApi(Environment.MachineName, "https://api.facebook.com/method/events.rsvp?eid=380159572014704&rsvp_status=attending&access_token=" + strToken);
                        Logger.Instance.WriteProcess("RSVP New Year event", MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.WriteCritical("rsvp events:" + ex.Message, MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }

                    procPT_USER_LOGONUpdateUSL_FB_UPDATEDByUSL_USER_ID.ExecuteNonQuery(true, iUserID);
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            finally
            {
                m_timer.Start();
            }
        }
        #endregion
        #region GraphApi
        public string AddIncomingUser(string p_strSID, int p_iiUserID, string p_strToken)
        {
            try
            {
                lock (T_INCOMING_USERS)
                {
                    T_INCOMING_USERS.AddT_INCOMING_USERSRow(p_iiUserID, p_strToken);
                }

                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        public int PreFillFbUser(string p_strSID, string p_strToken)
        {
            try
            {
                Logger.Instance.WriteInformation("GetFbUser Started", MethodBase.GetCurrentMethod(), p_strToken);
                Logger.Instance.WriteProcess("p_strToken:" + p_strToken, MethodBase.GetCurrentMethod(), p_strToken);

                Logger.Instance.WriteProcess("Get FqlUser", MethodBase.GetCurrentMethod(), string.Empty);
                DataSet dsTemp = new DataSet();
                //select uid,first_name,middle_name,last_name,pic_big,pic_square,profile_url,birthday_date,sex,locale,email,third_party_id from user where uid=me()
                dsTemp.ReadXml(new XmlNodeReader(GetFbGraphApi(p_strSID, "https://api.facebook.com/method/fql.query?query=select uid,first_name,middle_name,last_name,pic_big,pic_square,profile_url,birthday_date,sex,locale,email,third_party_id from user where uid=me()&access_token=" + p_strToken)));
                /*
                    "uid": 689887907,
                    "first_name": "Ronnie",
                    "middle_name": "",
                    "last_name": "Kleinfeld",
                    "pic_big": "http://profile.ak.fbcdn.net/hprofile-ak-snc4/275387_689887907_1672429002_n.jpg",
                    "pic_square": "http://profile.ak.fbcdn.net/hprofile-ak-snc4/275387_689887907_1672429002_q.jpg",
                    "profile_url": "http://www.facebook.com/ronnie.kleinfeld",
                    "birthday_date": "06/15/1970",
                    "sex": "male",
                    "locale": "en_US",
                    "email": "ronnie.kleinfeld@gmail.com",
                    "third_party_id": "smAjCukeXl5RvoLYYZ7rQKmic0k"
                */
                Logger.Instance.Write(dsTemp, MethodBase.GetCurrentMethod(), p_strSID);

                DataRow drFqlUser;
                try
                {
                    drFqlUser = dsTemp.Tables["user"].Rows[0];
                }
                catch
                {
                    throw new Exception("Table user is missing or empty");
                }
                if (drFqlUser == null)
                {
                    throw new Exception("Failed to get FqlUser");
                }
                Logger.Instance.Write(drFqlUser, MethodBase.GetCurrentMethod(), p_strSID);

                string strFBUID = FBSafeString(p_strSID, drFqlUser, "uid", string.Empty);
                if (strFBUID == string.Empty)
                {
                    throw new Exception("FB uid is missing");
                }
                Logger.Instance.WriteInformation("strFBUID:" + strFBUID, MethodBase.GetCurrentMethod(), p_strSID);

                FacebookDataSet dsFacebook = new FacebookDataSet();
                procAPT_USERSelectByUSR_FB_UID.LoadDataSet(dsFacebook, dsFacebook.T_USER.TableName, strFBUID);

                int iUserID = -1;
                if (dsFacebook.T_USER.Rows.Count == 0)
                {
                    object oUSR_ID;
                    procPT_USERInsertIntoNewFBUser.ExecuteNonQuery(
                        FBSafeString(p_strSID, drFqlUser, "third_party_id", string.Empty),
                        strFBUID,
                        null,
                        FBSafeNickName(p_strSID, FBSafeString(p_strSID, drFqlUser, "first_name", string.Empty), FBSafeString(p_strSID, drFqlUser, "last_name", string.Empty), iUserID),
                        out oUSR_ID);
                    if (oUSR_ID == null)
                    {
                        throw new Exception("Failed to insert new user");
                    }
                    else
                    {
                        iUserID = (int)oUSR_ID;
                    }
                }
                else
                {
                    iUserID = dsFacebook.T_USER[0].USR_ID;
                }
                Logger.Instance.WriteProcess("iUserID:" + iUserID, MethodBase.GetCurrentMethod(), p_strSID);

                // location
                string strIP = MADA.Web.HttpContext.HttpContext.GetIP();
                Logger.Instance.WriteInformation("strIP:" + strIP, MethodBase.GetCurrentMethod(), p_strSID);
                long longIP = MADA.Common.Net.IP.ToLong(strIP);
                Logger.Instance.WriteInformation("longIP:" + longIP, MethodBase.GetCurrentMethod(), p_strSID);

                Location location = LocationHandler.GetLocation(p_strSID, strIP);
                Logger.Instance.WriteInformation("location:" + location.ToString(), MethodBase.GetCurrentMethod(), p_strSID);

                // Transform data
                Logger.Instance.WriteProcess("Transform data", MethodBase.GetCurrentMethod(), p_strSID);

                procPT_USERUpdateByUSR_ID.ExecuteNonQuery(
                    FBbirthday_dateToDateTime(p_strSID, drFqlUser),
                    FBSafeString(p_strSID, drFqlUser, "birthday_date", string.Empty),
                    FBSafeString(p_strSID, drFqlUser, "email", string.Empty),
                    FBSafeString(p_strSID, drFqlUser, "first_name", string.Empty),
                    FBSafeString(p_strSID, drFqlUser, "last_name", string.Empty),
                    FBSafeString(p_strSID, drFqlUser, "locale", string.Empty),
                    FBSafeString(p_strSID, drFqlUser, "middle_name", string.Empty),
                    FBPicToUrl(p_strSID, drFqlUser, "pic_big", false),
                    FBPicToUrl(p_strSID, drFqlUser, "pic_square", true),
                    FBSafeString(p_strSID, drFqlUser, "profile_url", string.Empty),
                    FBSafeString(p_strSID, drFqlUser, "sex", string.Empty),
                    iUserID,
                    location.GetLat, location.GetLng,
                    FBsexToInt(p_strSID, drFqlUser));
                Logger.Instance.WriteInformation("procPT_USERUpdateByUSR_ID done", MethodBase.GetCurrentMethod(), p_strSID);

                // add incoming user to get FB data on batch process
                FacebookHandler.Instance.AddIncomingUser(p_strSID, iUserID, p_strToken);
                Logger.Instance.WriteInformation("AddIncomingUser done", MethodBase.GetCurrentMethod(), p_strSID);

                return iUserID;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                throw ex;
            }
            finally
            {
                Logger.Instance.WriteProcess("GetFbUser Ended", MethodBase.GetCurrentMethod(), p_strSID);
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
                    Mailer.Instance.Compose("ACCESS_TOKEN is missing", "");
                    Logger.Instance.WriteCritical("Invalid FB ACCESS TOKEN for SID:" + p_strSID, MethodBase.GetCurrentMethod(), p_strSID);
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
        #endregion
    }
}