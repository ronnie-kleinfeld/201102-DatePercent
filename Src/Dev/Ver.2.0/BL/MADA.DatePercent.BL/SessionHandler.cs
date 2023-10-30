using System.Web;
using System;
using MADA.DatePercent.BE;
using System.Net;
using System.IO;
using System.Xml;
using System.Data;
using MADA.DatePercent.DBS.dbDatePercentDB.SPs;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using MADA.DatePercent.DBS.dbDatePercentDB.Tables;
using MADA.Log.Api.Net;
using MADA.Common.DataType;
namespace MADA.DatePercent.BL
{
    public partial class SessionHandler
    {
        #region Members
        private string m_strLoggerSessionID;
        #endregion
        #region Properties
        public string LoggerSessionID
        {
            get
            {
                return m_strLoggerSessionID;
            }
        }
        #endregion
        #region Class
        public SessionHandler(string p_strLoggerSessionID)
            : this()
        {
            m_strLoggerSessionID = p_strLoggerSessionID;
        }
        #endregion
        #region User
        public string UserInit(int p_iSessionID, Database p_db, DbTransaction p_trn)
        {
            try
            {
                if (p_db == null && p_trn == null)
                {
                    procAPT_USERSelectByUSR_ID.LoadDataSet(this, T_USER.TableName, p_iSessionID);
                }
                else
                {
                    procAPT_USERSelectByUSR_ID.LoadDataSet(this, T_USER.TableName, p_iSessionID, p_db, p_trn);
                }

                if (UserRow.IsUSR_PIC_URLNull())
                {
                    UserRow.USR_PIC_URL = GetDefaultPicUrl;
                }
                else if (UserRow.USR_PIC_URL == "")
                {
                    UserRow.USR_PIC_URL = GetDefaultPicUrl;
                }

                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return ResultCode.FAILED;
            }
        }

        public SessionHandler.T_USERRow UserRow
        {
            get
            {
                return T_USER[0];
            }
        }
        public int ID
        {
            get
            {
                return UserRow.USR_ID;
            }
        }
        public string UID
        {
            get
            {
                return UserRow.USR_UID;
            }
        }
        public bool UserExists
        {
            get
            {
                return T_USER.Rows.Count > 0;
            }
        }
        private string GetDefaultPicUrl
        {
            get
            {
                try
                {
                    switch (UserRow.USR_PROP_SEX_CODE)
                    {
                        case 2:
                            return Constants.UIResNoImageFemaleUrl;
                        default:
                            return Constants.UIResNoImageMaleUrl;
                    }
                }
                catch
                {
                    return Constants.UIResNoImageMaleUrl;
                }
            }
        }

        public int UserInsertIntoUpdate(FacebookDataSet.T_USER_FACEBOOKRow p_drFbFqlUser, Database p_db, DbTransaction p_trn)
        {
            try
            {
                object oUSR_ID;
                procPT_USERInsertInto.ExecuteNonQuery(
                    null,
                    p_drFbFqlUser.USF_FB_LOCALE,
                    p_drFbFqlUser.USF_FB_NAME,
                    p_drFbFqlUser.USF_FB_PIC,
                    p_drFbFqlUser.USF_FB_PROFILE_URL,
                    p_drFbFqlUser.USF_BIRTHDAY,
                    p_drFbFqlUser.USF_SEX_TYPE,
                    decimal.ToInt32(decimal.Floor(decimal.Parse(p_drFbFqlUser.USF_FB_TIMEZONE))),
                    Guid.NewGuid().ToString(),
                    Facebook.DoEncriptions(p_drFbFqlUser.USF_FB_NAME),
                    out oUSR_ID,
                    p_db, p_trn);
                if (oUSR_ID == null)
                {
                    throw new Exception("Failed to insert T_USER");
                }

                int iUSR_ID = (int)oUSR_ID;
                Logger.Instance.WriteProcess("New USR_ID:" + iUSR_ID, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);

                Logger.Instance.WriteProcess("Success", System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);

                return iUSR_ID;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return -1;
            }
        }
        public string UserUpdateFromFqlUser(int p_iUserID, FacebookDataSet.T_USER_FACEBOOKRow p_drFbFqlUser, Database p_db, DbTransaction p_trn)
        {
            try
            {
                procPT_USERUpdateFromFqlUserByUSR_ID.ExecuteNonQuery(
                    p_iUserID,
                    p_drFbFqlUser.USF_FB_LOCALE,
                    p_drFbFqlUser.USF_FB_PIC,
                    p_drFbFqlUser.USF_FB_PROFILE_URL,
                    decimal.ToInt32(decimal.Floor(decimal.Parse(p_drFbFqlUser.USF_FB_TIMEZONE))),
                    p_db, p_trn);
                Logger.Instance.WriteProcess("Success", System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);

                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return ResultCode.FAILED;
            }
        }
        public string DeleteMember(int p_iSessionID)
        {
            try
            {
                procAPT_USERDeleteByUSR_ID.ExecuteNonQuery(p_iSessionID);
                Logger.Instance.WriteCritical("Member deleted:" + p_iSessionID, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return ResultCode.FAILED;
            }
        }
        #endregion
        #region EMail
        public string EMailInit(int p_iSessionID, Database p_db, DbTransaction p_trn)
        {
            try
            {
                if (p_db == null && p_trn == null)
                {
                    procAPT_USER_EMAILSelectByUSE_USER_ID.LoadDataSet(this, T_USER_EMAIL.TableName, p_iSessionID);
                }
                else
                {
                    procAPT_USER_EMAILSelectByUSE_USER_ID.LoadDataSet(this, T_USER_EMAIL.TableName, p_iSessionID, p_db, p_trn);
                }

                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return ResultCode.FAILED;
            }
        }
        public string EMailInit(string p_strEMail, Database p_db, DbTransaction p_trn)
        {
            try
            {
                if (p_db == null && p_trn == null)
                {
                    procAPT_USER_EMAILSelectByUSE_EMAIL.LoadDataSet(this, T_USER_EMAIL.TableName, p_strEMail);
                }
                else
                {
                    procAPT_USER_EMAILSelectByUSE_EMAIL.LoadDataSet(this, T_USER_EMAIL.TableName, p_strEMail, p_db, p_trn);
                }

                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return ResultCode.FAILED;
            }
        }

        public bool EMailIsEmpty
        {
            get
            {
                return this.T_USER_EMAIL.Rows.Count == 0;
            }
        }
        public T_USER_EMAILRow EMailContains(string p_strEMail)
        {
            foreach (T_USER_EMAILRow drUserEMail in this.T_USER_EMAIL.Rows)
            {
                if (drUserEMail.USE_EMAIL == p_strEMail)
                {
                    return drUserEMail;
                }
            }

            return null;
        }

        public int EMailInsertIntoUpdate(int p_iSessionID, string p_strEMail, Database p_db, DbTransaction p_trn)
        {
            try
            {
                object oUSE_ID;
                if (p_db == null && p_trn == null)
                {
                    procAPT_USER_EMAILInsertIntoUpdateByUSE_USER_ID.ExecuteNonQuery(null, p_strEMail, null, p_iSessionID, out oUSE_ID);
                }
                else
                {
                    procAPT_USER_EMAILInsertIntoUpdateByUSE_USER_ID.ExecuteNonQuery(null, p_strEMail, null, p_iSessionID, out oUSE_ID, p_db, p_trn);
                }
                Logger.Instance.WriteProcess("Success:" + oUSE_ID.ToString(), System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);

                try
                {
                    return (int)oUSE_ID;
                }
                catch
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return -1;
            }
        }
        #endregion
        #region List
        public string ListInit(int p_iSessionID)
        {
            try
            {
                procPT_LISTSelectByLST_SESSION_USER_ID.LoadDataSet(this, this.tableT_LIST.TableName, p_iSessionID);
                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return ResultCode.FAILED;
            }
        }
        #endregion
        #region Location
        public string LocationInitCurrent(int p_iSessionID, Database p_db, DbTransaction p_trn)
        {
            try
            {
                if (p_db == null && p_trn == null)
                {
                    procAPT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE.LoadDataSet(this, T_USER_LOCATION.TableName, p_iSessionID,
                        (int)T_USER_LOCATION_TYPE_ENUM.Current);
                }
                else
                {
                    procAPT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE.LoadDataSet(this, T_USER_LOCATION.TableName, p_iSessionID,
                        (int)T_USER_LOCATION_TYPE_ENUM.Current, p_db, p_trn);
                }

                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return ResultCode.FAILED;
            }
        }

        public int LocationInsertIntoUpdate(int p_iSessionID, Location p_location, Database p_db, DbTransaction p_trn)
        {
            try
            {
                try
                {
                    return LocationInsertIntoUpdate(p_iSessionID, T_USER_LOCATION_TYPE_ENUM.FromIP, p_location.IP, p_location.Address,
                        (decimal)p_location.GetLatLng.Lat, (decimal)p_location.GetLatLng.Lng, p_db, p_trn);
                }
                catch (Exception ex)
                {
                    Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                    return LocationInsertIntoUpdate(p_iSessionID, T_USER_LOCATION_TYPE_ENUM.FromIP, "127.0.0.1", "Tour eiffel, 75007 Paris, France",
                        (decimal)48.8509924, (decimal)2.2782466, p_db, p_trn);
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return -1;
            }
        }
        public int LocationInsertIntoUpdate(int p_iSessionID, T_USER_LOCATION_TYPE_ENUM p_enmUserLocationType, string strIP, string p_strAddress,
            decimal p_decLat, decimal p_decLng, Database p_db, DbTransaction p_trn)
        {
            try
            {
                object oUSL_ID;
                procAPT_USER_LOCATIONInsertIntoUpdateByUSL_USER_IDUSL_USER_LOCATION_TYPE.ExecuteNonQuery(
                    null,
                    p_strAddress,
                    null,
                    strIP,
                    p_decLat,
                    p_decLng,
                    p_iSessionID,
                    (int)p_enmUserLocationType,
                    out oUSL_ID, p_db, p_trn);

                // T_USER_LOCATION_TYPE_ENUM.Current
                bool bUpdateAsCurrent = false;

                // 1st location
                DataSet ds = new DataSet();
                procAPT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE.LoadDataSet(ds, tblT_USER_LOCATION._Name, p_iSessionID,
                    (int)T_USER_LOCATION_TYPE_ENUM.Current, p_db, p_trn);
                bUpdateAsCurrent = ds.Tables[tblT_USER_LOCATION._Name].Rows.Count == 0;

                // Edit Profile
                bUpdateAsCurrent = bUpdateAsCurrent || p_enmUserLocationType == T_USER_LOCATION_TYPE_ENUM.EditProfile;

                if (bUpdateAsCurrent)
                {
                    procAPT_USER_LOCATIONInsertIntoUpdateByUSL_USER_IDUSL_USER_LOCATION_TYPE.ExecuteNonQuery(
                        null,
                        p_strAddress,
                        null,
                        strIP,
                        p_decLat,
                        p_decLng,
                        p_iSessionID,
                        (int)T_USER_LOCATION_TYPE_ENUM.Current,
                        out oUSL_ID, p_db, p_trn);
                }

                Logger.Instance.WriteProcess("Success", System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);

                return (int)oUSL_ID;
            }
            catch
            {
                return -1;
            }
        }
        #endregion
        #region Photo
        public string PhotoInit(int p_iSessionID, Database p_db, DbTransaction p_trn)
        {
            try
            {
                if (p_db == null && p_trn == null)
                {
                    procAPT_USER_PHOTOSelectByUPH_USER_ID.LoadDataSet(this, this.tableT_USER_PHOTO.TableName, p_iSessionID);
                }
                else
                {
                    procAPT_USER_PHOTOSelectByUPH_USER_ID.LoadDataSet(this, this.tableT_USER_PHOTO.TableName, p_iSessionID, p_db, p_trn);
                }

                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return ResultCode.FAILED;
            }
        }
        #endregion
        #region PropInterests
        public string PropInterestsInit(int p_iSessionID)
        {
            try
            {
                procAPT_USER_PROP_INTERESTSSelectByUIT_USER_ID.LoadDataSet(this, this.tableT_USER_PROP_INTERESTS.TableName, p_iSessionID);
                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return ResultCode.FAILED;
            }
        }
        #endregion
        #region PropLanguage
        public string PropLanguageInit(int p_iSessionID)
        {
            try
            {
                procAPT_USER_PROP_LANGUAGESelectByULG_USER_ID.LoadDataSet(this, this.tableT_USER_PROP_LANGUAGE.TableName, p_iSessionID);
                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return ResultCode.FAILED;
            }
        }
        #endregion
        #region PropRelationship
        public string PropRelationshipInit(int p_iSessionID)
        {
            try
            {
                procAPT_USER_PROP_RELATIONSHIPSelectByURL_USER_ID.LoadDataSet(this, this.tableT_USER_PROP_RELATIONSHIP.TableName, p_iSessionID);
                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return ResultCode.FAILED;
            }
        }
        #endregion
        #region Session
        public string SessionDoLogin(string p_strSID, int p_iUserID, Database p_db, DbTransaction p_trn)
        {
            try
            {
                procAPT_USER_SESSIONSelectByUSD_SID.LoadDataSet(this, this.T_USER_SESSION.TableName, p_strSID, p_db, p_trn);
                if (this.T_USER_SESSION.Rows.Count > 0)
                {
                    Logger.Instance.WriteProcess("Session Exists", System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);
                    return ResultCode.SUCCESS;
                }
                else
                {
                    object oUSD_ID;
                    procAPT_USER_SESSIONInsertInto.ExecuteNonQuery(null, p_strSID, p_iUserID, out oUSD_ID, p_db, p_trn);
                    if (oUSD_ID == null)
                    {
                        return ResultCode.FAILED;
                    }
                    else
                    {
                        Logger.Instance.WriteProcess("New Session", System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);
                        return ResultCode.SUCCESS;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return ResultCode.FAILED;
            }
        }
        public static int SessionGetUserID(string p_strSID)
        {
            SessionHandler sessionHandler;

            try
            {
                sessionHandler = new SessionHandler(p_strSID);

                procAPT_USER_SESSIONSelectByUSD_SID.LoadDataSet(sessionHandler, sessionHandler.T_USER_SESSION.TableName, p_strSID);

                if (sessionHandler.T_USER_SESSION.Rows.Count == 0)
                {
                    HttpContext.Current.Response.Redirect(Constants.UIRedirectToAppUrl, false);
                    return -1;
                }
                else
                {
                    return sessionHandler.T_USER_SESSION[0].USD_USER_ID;
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);
                return -1;
            }
            finally
            {
                sessionHandler = null;
            }
        }
        public string SessionDoLogout(string p_strSID)
        {
            try
            {
                procAPT_USER_SESSIONDeleteByUSD_SID.ExecuteNonQuery(p_strSID);
                return BE.ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return BE.ResultCode.FAILED;
            }
        }
        #endregion
        #region Setting
        public string SettingInit(int p_iSessionID, Database p_db, DbTransaction p_trn)
        {
            try
            {
                if (p_db == null && p_trn == null)
                {
                    procAPT_USER_SETTINGSelectByUSS_USER_ID.LoadDataSet(this, this.tableT_USER_SETTING.TableName, p_iSessionID);
                }
                else
                {
                    procAPT_USER_SETTINGSelectByUSS_USER_ID.LoadDataSet(this, this.tableT_USER_SETTING.TableName, p_iSessionID, p_db, p_trn);
                }

                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return ResultCode.FAILED;
            }
        }

        public string SettingSetDefaults(int p_iSessionID, Database p_db, DbTransaction p_trn)
        {
            try
            {
                SettingSetBool(p_iSessionID, (int)T_USER_SETTING_TYPE_ENUM.DoNotShowLocationChangedPopBox, true, p_db, p_trn);
                SettingSetInt(p_iSessionID, (int)T_USER_SETTING_TYPE_ENUM.CultureDateFormat, 1, p_db, p_trn);
                SettingSetInt(p_iSessionID, (int)T_USER_SETTING_TYPE_ENUM.DistanceUnits, 1, p_db, p_trn);
                SettingSetInt(p_iSessionID, (int)T_USER_SETTING_TYPE_ENUM.ResultsCount, 10, p_db, p_trn);
                SettingSetInt(p_iSessionID, (int)T_USER_SETTING_TYPE_ENUM.VisibilityCode, 1, p_db, p_trn);
                SettingSetDateTime(p_iSessionID, (int)T_USER_SETTING_TYPE_ENUM.NextGenius, System.DateTime.Now, p_db, p_trn);
                SettingSetBool(p_iSessionID, (int)T_USER_SETTING_TYPE_ENUM.UserOkedSharedPopBox, false, p_db, p_trn);
                SettingSetBool(p_iSessionID, (int)T_USER_SETTING_TYPE_ENUM.UserOkedLocationPopBox, false, p_db, p_trn);

                return BE.ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return BE.ResultCode.FAILED;
            }
        }
        public string ResetSettings(int p_iSessionID)
        {
            try
            {
                procAPT_USER_SETTINGDeleteByUSS_USER_ID.ExecuteNonQuery(p_iSessionID);
                return SettingSetDefaults(p_iSessionID, null, null);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return BE.ResultCode.FAILED;
            }
        }

        public string SettingSetBool(int p_iSessionID, int p_iSettingType, bool p_b, Database p_db, DbTransaction p_trn)
        {
            try
            {
                object oUSS_ID;
                if (p_db == null)
                {
                    procAPT_USER_SETTINGInsertIntoUpdateByUSS_USER_IDUSS_USER_SETTING_TYPE.ExecuteNonQuery(
                        null, p_b, null, null, null, null, p_iSessionID, p_iSettingType, out oUSS_ID);
                }
                else
                {
                    procAPT_USER_SETTINGInsertIntoUpdateByUSS_USER_IDUSS_USER_SETTING_TYPE.ExecuteNonQuery(
                        null, p_b, null, null, null, null, p_iSessionID, p_iSettingType, out oUSS_ID, p_db, p_trn);
                }

                return BE.ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return BE.ResultCode.FAILED;
            }
        }
        public string SettingSetDateTime(int p_iSessionID, int p_iSettingType, System.DateTime p_dt, Database p_db, DbTransaction p_trn)
        {
            try
            {
                object oUSS_ID;
                if (p_db == null)
                {
                    procAPT_USER_SETTINGInsertIntoUpdateByUSS_USER_IDUSS_USER_SETTING_TYPE.ExecuteNonQuery(
                        null, null, p_dt, null, null, null, p_iSessionID, p_iSettingType, out oUSS_ID);
                }
                else
                {
                    procAPT_USER_SETTINGInsertIntoUpdateByUSS_USER_IDUSS_USER_SETTING_TYPE.ExecuteNonQuery(
                        null, null, p_dt, null, null, null, p_iSessionID, p_iSettingType, out oUSS_ID, p_db, p_trn);
                }

                return BE.ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return BE.ResultCode.FAILED;
            }
        }
        public string SettingSetInt(int p_iSessionID, int p_iSettingType, int p_i, Database p_db, DbTransaction p_trn)
        {
            try
            {
                object oUSS_ID;
                if (p_db == null)
                {
                    procAPT_USER_SETTINGInsertIntoUpdateByUSS_USER_IDUSS_USER_SETTING_TYPE.ExecuteNonQuery(
                        null, null, null, null, p_i, null, p_iSessionID, p_iSettingType, out oUSS_ID);
                }
                else
                {
                    procAPT_USER_SETTINGInsertIntoUpdateByUSS_USER_IDUSS_USER_SETTING_TYPE.ExecuteNonQuery(
                        null, null, null, null, p_i, null, p_iSessionID, p_iSettingType, out oUSS_ID, p_db, p_trn);
                }

                return BE.ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return BE.ResultCode.FAILED;
            }
        }
        public string SettingSetString(int p_iSessionID, int p_iSettingType, string p_str, Database p_db, DbTransaction p_trn)
        {
            try
            {
                object oUSS_ID;
                if (p_db == null)
                {
                    procAPT_USER_SETTINGInsertIntoUpdateByUSS_USER_IDUSS_USER_SETTING_TYPE.ExecuteNonQuery(
                        null, null, null, null, null, p_str, p_iSessionID, p_iSettingType, out oUSS_ID);
                }
                else
                {
                    procAPT_USER_SETTINGInsertIntoUpdateByUSS_USER_IDUSS_USER_SETTING_TYPE.ExecuteNonQuery(
                        null, null, null, null, null, p_str, p_iSessionID, p_iSettingType, out oUSS_ID, p_db, p_trn);
                }

                return BE.ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return BE.ResultCode.FAILED;
            }
        }
        public string SettingSet(int p_iSessionID, int p_iSettingType, bool p_b, System.DateTime p_dt, int p_i, string p_str, Database p_db, DbTransaction p_trn)
        {
            try
            {
                object oUSS_ID;
                if (p_db == null)
                {
                    procAPT_USER_SETTINGInsertIntoUpdateByUSS_USER_IDUSS_USER_SETTING_TYPE.ExecuteNonQuery(
                        null, p_b, p_dt, null, p_i, p_str, p_iSessionID, p_iSettingType, out oUSS_ID);
                }
                else
                {
                    procAPT_USER_SETTINGInsertIntoUpdateByUSS_USER_IDUSS_USER_SETTING_TYPE.ExecuteNonQuery(
                        null, p_b, p_dt, null, p_i, p_str, p_iSessionID, p_iSettingType, out oUSS_ID, p_db, p_trn);
                }

                return BE.ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return BE.ResultCode.FAILED;
            }
        }

        public string SettingDeleteBySessionID(int p_iUSS_USER_ID)
        {
            try
            {
                procAPT_USER_SETTINGDeleteByUSS_USER_ID.ExecuteNonQuery(p_iUSS_USER_ID);
                return BE.ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return BE.ResultCode.FAILED;
            }
        }
        public string SettingDeleteBySessionIDAndType(int p_iUSS_USER_ID, int p_iUSS_USER_SETTING_TYPE)
        {
            try
            {
                procAPT_USER_SETTINGDeleteByUSS_USER_IDUSS_USER_SETTING_TYPE.ExecuteNonQuery(p_iUSS_USER_ID, p_iUSS_USER_SETTING_TYPE);
                return BE.ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return BE.ResultCode.FAILED;
            }
        }
        #endregion
        #region DetailsUser
        public string DetailsUserInit(string p_strDetailsID)
        {
            try
            {
                procAPT_USERSelectByUSR_UID.LoadDataSet(this, T_USER_Details.TableName, p_strDetailsID);
                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), LoggerSessionID);
                return ResultCode.FAILED;
            }
        }
        #endregion
    }
}