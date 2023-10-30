using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace MADA.DatePercent.BB.WL.WS.WS
{
    /// <summary>
    /// Summary description for GlobalWSOLD
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class GlobalWSOLD : System.Web.Services.WebService
    {
        /*
        #region SessionController
        #region Framework
        [WebMethod]
        public FS GFS(string p_strSID)
        {
            FS frameworkStatus;

            try
            {
                SessionHandler sessionHandler = new SessionHandler(p_strSID);
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);
                procPT_LOGONUpdateAgeByLGN_USER_ID.ExecuteNonQuery(iSessionID);

                frameworkStatus = new FS();
                frameworkStatus._C = ApplicationHandler.Instance.LogonCounter;

                DataSet ds = new DataSet();
                procPT_LOGONSelectRMNByLGN_USER_ID.LoadDataSet(ds, Constants.LOAD_DATASET_TABLE_NAME, iSessionID);
                frameworkStatus._R = (int)ds.Tables[0].Rows[0]["LGN_RMN_REQUEST_COUNT"];
                frameworkStatus._M = (int)ds.Tables[0].Rows[0]["LGN_RMN_MESSAGE_COUNT"];
                frameworkStatus._N = (int)ds.Tables[0].Rows[0]["LGN_RMN_NOTIFICATION_COUNT"];
            }
            catch
            {
                frameworkStatus = null;
            }

            return frameworkStatus;
        }
        [WebMethod]
        public DataSet FrameworkGetApplication(string p_strSID)
        {
            try
            {
                if (ApplicationHandler.Instance.m_dsFlexApplication == null)
                {
                    ApplicationHandler.Instance.m_dsFlexApplication = new DataSet();

                    string strColumnPrefix;
                    string strCodeColumn;
                    string strDescriptionColumn;

                    foreach (DataTable dt in ApplicationHandler.Instance.Tables)
                    {
                        // flex ApplicationHandler requires only the following tables
                        switch (dt.TableName)
                        {
                            //m_acLinkTypeSMapParameterVisible = Serializer.DeSerializeArrayCollection(event, "T_LINK_TYPE_ENUM_SMapParameterVisible");
                            case "T_DOMAIN_TYPE_ENUM":
                            case "T_LINK_ACTION_TYPE_ENUM":
                            case "T_LINK_TYPE_ENUM":
                            case "T_PROP_MATCH_SEX_TYPE":
                            case "T_PROP_SEX_TYPE_ENUM":
                            case "T_PROP_ZODIAC_SIGN_TYPE":
                            case "T_CULTURE_DATE_FORMAT_TYPE_ENUM":
                            case "T_DISTANCE_UNITS_TYPE_ENUM":
                                DataTable dtNew = dt.Copy();

                                strColumnPrefix = dt.Columns[0].ColumnName.Substring(0, 3);
                                strCodeColumn = strColumnPrefix + "_CODE";
                                strDescriptionColumn = strColumnPrefix + "_DESCRIPTION";

                                if (dtNew.Columns.Contains(strCodeColumn) && dtNew.Columns.Contains(strDescriptionColumn))
                                {
                                    dtNew.Columns.Add("label", typeof(string));
                                    dtNew.Columns.Add("data", typeof(string));

                                    foreach (DataRow dr in dtNew.Rows)
                                    {
                                        dr["data"] = dr[strCodeColumn];
                                        dr["label"] = dr[strDescriptionColumn];
                                    }
                                }

                                ApplicationHandler.Instance.m_dsFlexApplication.Tables.Add(dtNew);
                                break;
                        }
                    }

                    procPT_LINK_TYPE_ENUMSelectByLKT_SMAP_PARAMETER_VISIBLETrue.LoadDataSet(ApplicationHandler.Instance.m_dsFlexApplication, tblT_LINK_TYPE_ENUM._Name + "_SMapParameterVisible");

                    ApplicationHandler.Instance.m_dsFlexApplication = Serializer.SerializeToFlex(ApplicationHandler.Instance.m_dsFlexApplication);

                    ApplicationHandler.Instance.m_dsFlexApplication.Tables.Add(ApplicationHandler.Instance.T_SERIALIZER.Copy());
                    ApplicationHandler.Instance.m_dsFlexApplication.AcceptChanges();
                }

                return ApplicationHandler.Instance.m_dsFlexApplication;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return null;
            }
        }
        [WebMethod]
        public DataSet FrameworkGetSession(string p_strSID, string p_strDetailsID)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);
                procPT_LOGONInsertIntoUpdateByLGN_USER_ID.ExecuteNonQuery(iSessionID);

                SessionHandler sessionHandler = new SessionHandler(p_strSID);
                sessionHandler.UserInit(iSessionID, null, null);
                sessionHandler.EMailInit(iSessionID, null, null);
                sessionHandler.ListInit(iSessionID);
                sessionHandler.LocationInitCurrent(iSessionID, null, null);
                sessionHandler.PhotoInit(iSessionID, null, null);
                sessionHandler.PropInterestsInit(iSessionID);
                sessionHandler.PropLanguageInit(iSessionID);
                sessionHandler.PropRelationshipInit(iSessionID);
                sessionHandler.SettingInit(iSessionID, null, null);
                sessionHandler.DetailsUserInit(p_strDetailsID);

                Logger.Instance.WriteProcess("Got session:" + iSessionID, MethodBase.GetCurrentMethod(), p_strSID);
                Logger.Instance.Write(sessionHandler, MethodBase.GetCurrentMethod(), p_strSID);

                DataSet ds = new DataSet();
                foreach (DataTable dtOriginal in sessionHandler.Tables)
                {
                    try
                    {
                        DataTable dtNew = dtOriginal.Copy();
                        ds.Tables.Add(dtNew);
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                    }
                }
                ds = Serializer.SerializeToFlex(ds);
                ds.AcceptChanges();
                return ds;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }
        #endregion
        #region Profile
        [WebMethod]
        public string ProfileDeleteMember(string p_strSID)
        {
            try
            {
                SessionHandler sessionHandler = new SessionHandler(p_strSID);
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);
                sessionHandler.DeleteMember(iSessionID);

                return ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return ResultCode.FAILED;
            }
        }

        [WebMethod]
        public string ProfileUpdateMyDetails(string p_strSID, object p_oProperties,
            string p_strEmail, System.DateTime p_dtUSR_PROP_BIRTHDATE, int p_iTimezoneOffset, bool p_bSubscribe,
            object p_oLanguage, object p_oInterests, object p_oRelationship)
        {
            try
            {
                SessionHandler sessionHandler = new SessionHandler(p_strSID);
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                Database db = DatabaseFactory.CreateDatabase();

                using (DbConnection con = db.CreateConnection())
                {
                    con.Open();
                    DbTransaction trn = con.BeginTransaction();
                    Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);

                    try
                    {
                        // update properties
                        SqlCommand cmd = procPT_USERUpdateProfileByUSR_ID.SqlCommand();
                        cmd.Parameters["@USR_ID"].Value = iSessionID;

                        // update birthday because need to change timezone
                        cmd.Parameters["@USR_PROP_BIRTHDATE"].Value = p_dtUSR_PROP_BIRTHDATE.AddMinutes(-p_iTimezoneOffset);

                        DataTable dtProperties = MADA.Data.DataTable.FlexArrayCollectionToDataTable(p_oProperties);
                        foreach (DataRow dr in dtProperties.Rows)
                        {
                            if (dr["Data"].ToString() == "null" || dr["Data"].ToString() == "0")
                            {
                                cmd.Parameters["@" + dr["ColumnName"].ToString()].Value = DBNull.Value;
                            }
                            else
                            {
                                cmd.Parameters["@" + dr["ColumnName"].ToString()].Value = dr["Data"];
                            }
                        }

                        int i = db.ExecuteNonQuery(cmd, trn);

                        // untispam
                        if (p_bSubscribe)
                        {
                            procAPT_EMAIL_UNTISPAMDeleteByEMM_EMAIL.ExecuteNonQuery(p_strEmail);
                        }
                        else
                        {
                            procPT_EMAIL_UNTISPAMInsertInto.ExecuteNonQuery(p_strEmail);
                        }

                        // update email
                        object oUSE_ID;
                        procAPT_USER_EMAILInsertIntoUpdateByUSE_USER_ID.ExecuteNonQuery(null, p_strEmail, null, iSessionID, out oUSE_ID, db, trn);

                        // update languages
                        procAPT_USER_PROP_LANGUAGEDeleteByULG_USER_ID.ExecuteNonQuery(iSessionID, db, trn);
                        DataTable dtLanguages = MADA.Data.DataTable.FlexArrayCollectionToDataTable(p_oLanguage);
                        if (dtLanguages != null)
                        {
                            object oULG_ID;
                            foreach (DataRow dr in dtLanguages.Rows)
                            {
                                procAPT_USER_PROP_LANGUAGEInsertInto.ExecuteNonQuery(null, int.Parse(dr["Data"].ToString()), iSessionID, out oULG_ID, db, trn);
                            }
                        }

                        // update interests
                        procAPT_USER_PROP_INTERESTSDeleteByUIT_USER_ID.ExecuteNonQuery(iSessionID, db, trn);
                        DataTable dtInterests = MADA.Data.DataTable.FlexArrayCollectionToDataTable(p_oInterests);
                        if (dtInterests != null)
                        {
                            object oINT_ID;
                            foreach (DataRow dr in dtInterests.Rows)
                            {
                                procAPT_USER_PROP_INTERESTSInsertInto.ExecuteNonQuery(null, int.Parse(dr["Data"].ToString()), iSessionID, out oINT_ID, db, trn);
                            }
                        }

                        // update relationships
                        procAPT_USER_PROP_RELATIONSHIPDeleteByURL_USER_ID.ExecuteNonQuery(iSessionID, db, trn);
                        DataTable dtRelationship = MADA.Data.DataTable.FlexArrayCollectionToDataTable(p_oRelationship);
                        if (dtRelationship != null)
                        {
                            object oURL_ID;
                            foreach (DataRow dr in dtRelationship.Rows)
                            {
                                procAPT_USER_PROP_RELATIONSHIPInsertInto.ExecuteNonQuery(null, int.Parse(dr["Data"].ToString()), iSessionID, out oURL_ID, db, trn);
                            }
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
            catch (Exception ex)
            {
                Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string ProfileUpdateMyPhotos(string p_strSID, object p_oPhotos)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                Database db = DatabaseFactory.CreateDatabase();

                using (DbConnection con = db.CreateConnection())
                {
                    con.Open();
                    DbTransaction trn = con.BeginTransaction();
                    Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);

                    try
                    {
                        procAPT_USER_PHOTODeleteByUPH_USER_ID.ExecuteNonQuery(iSessionID, db, trn);
                        DataTable dtPhotos = MADA.Data.DataTable.FlexArrayCollectionToDataTable(p_oPhotos);
                        if (dtPhotos == null)
                        {
                            throw new Exception("Photos ArrayCollection from flex is null");
                        }
                        else
                        {
                            object oUPH_ID;
                            foreach (DataRow dr in dtPhotos.Rows)
                            {
                                procAPT_USER_PHOTOInsertInto.ExecuteNonQuery(
                                    null, false, dr["UPH_ORIGINAL_URL"].ToString(), dr["UPH_SMALL_URL"].ToString(), dr["UPH_THUMB_URL"].ToString(), iSessionID, out oUPH_ID, db, trn);
                            }
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
            catch (Exception ex)
            {
                Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string ProfileUpdateMyLocation(string p_strSID, string p_strIP, string p_strAddress, decimal p_decLat, decimal p_decLng)
        {
            try
            {
                SessionHandler sessionHandler = new SessionHandler(p_strSID);
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                Database db = DatabaseFactory.CreateDatabase();

                using (DbConnection con = db.CreateConnection())
                {
                    con.Open();
                    DbTransaction trn = con.BeginTransaction();
                    Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);

                    try
                    {
                        sessionHandler.LocationInsertIntoUpdate(iSessionID, T_USER_LOCATION_TYPE_ENUM.EditProfile, p_strIP, p_strAddress, p_decLat, p_decLng, db, trn);

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
            catch (Exception ex)
            {
                Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return BE.ResultCode.FAILED;
            }
        }

        [WebMethod]
        public string CreateDefaultAllUserSettings(string p_strSID)
        {
            try
            {
                SessionHandler sessionHandler = new SessionHandler(p_strSID);
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);
                sessionHandler.SettingSetDefaults(iSessionID, null, null);

                return ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return ResultCode.FAILED;
            }
        }
        #endregion
        #region Share
        [WebMethod]
        public string ShareAddEmailCredentials(string p_strSID, string p_strCreditPointsEmail, string p_strCreditPointsPassword)
        {
            try
            {
                processor processorClass = new processor();
                string strSecretKey = processorClass.getSecretKey(HttpContext.Current, BE.Constants.STES_CODES_SIGNATURE_KEY);
                Logger.Instance.WriteInformation("strSecretKey:" + strSecretKey, MethodBase.GetCurrentMethod(), p_strSID);

                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);
                ApplicationHandler.Instance.AddEmailCredentials(p_strCreditPointsEmail, p_strCreditPointsPassword, iSessionID, strSecretKey);

                return BE.ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string ShareInviteAFriend(string p_strSID, string p_strEMail, string p_strUid)
        {
            int iSessionID = SessionHandler.SessionGetUserID(p_strSID);
            return InviteeHandler.Invite(p_strEMail, p_strUid, iSessionID, p_strEMail, T_USER_INVITEE_TYPE_ENUM.Added);
        }
        #endregion
        #region Setting
        [WebMethod]
        public DataSet GetSetting(string p_strSID)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);
                procPT_LOGONDeleteAndInsertInto.ExecuteNonQuery(iSessionID);

                SessionHandler sessionHandler = new SessionHandler(p_strSID);
                sessionHandler.SettingInit(iSessionID, null, null);

                Logger.Instance.WriteProcess("Got settings:" + iSessionID, MethodBase.GetCurrentMethod(), p_strSID);

                DataSet ds = new DataSet();
                foreach (DataTable dtOriginal in sessionHandler.Tables)
                {
                    DataTable dtNew = dtOriginal.Copy();
                    ds.Tables.Add(dtNew);
                }
                ds = Serializer.SerializeToFlex(ds);
                ds.AcceptChanges();
                return ds;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }

        [WebMethod]
        public string SettingSetBool(string p_strSID, int p_iSettingType, bool p_b)
        {
            SessionHandler sessionHandler = new SessionHandler(p_strSID);
            int iSessionID = SessionHandler.SessionGetUserID(p_strSID);
            return sessionHandler.SettingSetBool(iSessionID, p_iSettingType, p_b, null, null);
        }
        [WebMethod]
        public string SettingSetDateTime(string p_strSID, int p_iSettingType, System.DateTime p_dt)
        {
            SessionHandler sessionHandler = new SessionHandler(p_strSID);
            int iSessionID = SessionHandler.SessionGetUserID(p_strSID);
            return sessionHandler.SettingSetDateTime(iSessionID, p_iSettingType, p_dt, null, null);
        }
        [WebMethod]
        public string SettingSetInt(string p_strSID, int p_iSettingType, int p_i)
        {
            SessionHandler sessionHandler = new SessionHandler(p_strSID);
            int iSessionID = SessionHandler.SessionGetUserID(p_strSID);
            return sessionHandler.SettingSetInt(iSessionID, p_iSettingType, p_i, null, null);
        }
        [WebMethod]
        public string SettingSetString(string p_strSID, int p_iSettingType, string p_str)
        {
            SessionHandler sessionHandler = new SessionHandler(p_strSID);
            int iSessionID = SessionHandler.SessionGetUserID(p_strSID);
            return sessionHandler.SettingSetString(iSessionID, p_iSettingType, p_str, null, null);
        }
        [WebMethod]
        public string SettingSet(string p_strSID, int p_iSettingType, bool p_b, System.DateTime p_dt, int p_i, string p_str)
        {
            SessionHandler sessionHandler = new SessionHandler(p_strSID);
            int iSessionID = SessionHandler.SessionGetUserID(p_strSID);
            return sessionHandler.SettingSet(iSessionID, p_iSettingType, p_b, p_dt, p_i, p_str, null, null);
        }

        [WebMethod]
        public string SettingDeleteBySessionID(string p_strSID)
        {
            SessionHandler sessionHandler = new SessionHandler(p_strSID);
            int iSessionID = SessionHandler.SessionGetUserID(p_strSID);
            return sessionHandler.SettingDeleteBySessionID(iSessionID);
        }
        [WebMethod]
        public string SettingDeleteBySessionIDAndType(string p_strSID, int p_iUSS_USER_SETTING_TYPE)
        {
            SessionHandler sessionHandler = new SessionHandler(p_strSID);
            int iSessionID = SessionHandler.SessionGetUserID(p_strSID);
            return sessionHandler.SettingDeleteBySessionIDAndType(iSessionID, p_iUSS_USER_SETTING_TYPE);
        }

        [WebMethod]
        public string SettingReset(string p_strSID)
        {
            SessionHandler sessionHandler = new SessionHandler(p_strSID);
            int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

            return sessionHandler.ResetSettings(iSessionID);
        }
        #endregion
        #endregion
        #region DetailsController
        #region Global
        [WebMethod]
        public string DoDetailsShare(string p_strSID, string p_strFBUID, int p_iSharedDetailsID, string p_strGetterEMails, string p_strGetterText)
        {
            string strResult;

            try
            {
                string p_strGetterEMail = p_strGetterEMails;
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);
                EMailHandler.ComposeEmailBoxDetailsShare(iSessionID, p_strSID, p_iSharedDetailsID, p_strGetterEMail, p_strGetterText);

                InviteeHandler.Invite(p_strGetterEMail, p_strFBUID, iSessionID, p_strGetterEMail, T_USER_INVITEE_TYPE_ENUM.Added);

                strResult = BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                strResult = BE.ResultCode.FAILED;
            }

            return strResult;
        }

        [WebMethod]
        public DataSet GetDetailsData(string p_strSID, int p_iDetailsID)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                DataSet ds = new DataSet();
                procPT_USERSelectByUSR_ID.LoadDataSet(ds, tblT_USER._Name, p_iDetailsID);
                procPT_LISTSelectByLSU_DETAILS_USER_IDLST_SESSION_USER_ID.LoadDataSet(ds, tblT_LIST_USER._Name, iSessionID, p_iDetailsID);
                ListHandler.AddDetailsIDAsRecent(iSessionID, p_iDetailsID);
                return Serializer.SerializeToFlex(ds);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }

        [WebMethod]
        public DataSet GetProperties(string p_strSID, int p_iDetailsID, double p_decLatSession, double p_decLngSession)
        {
            try
            {
                DataSet ds = new DataSet();
                procPT_USERSelectPropByUSR_ID.LoadDataSet(ds, tblT_USER._Name, p_iDetailsID);
                procPT_USER_LOCATIONSelectByUSL_USER_ID.LoadDataSet(ds, tblT_USER_LOCATION._Name, p_iDetailsID);
                procPT_USER_PROP_LANGUAGESelectByULG_USER_ID.LoadDataSet(ds, tblT_USER_PROP_LANGUAGE._Name, p_iDetailsID);
                procPT_USER_PROP_INTERESTSSelectByUIT_USER_ID.LoadDataSet(ds, tblT_USER_PROP_INTERESTS._Name, p_iDetailsID);
                procPT_USER_PROP_RELATIONSHIPSelectByURL_USER_ID.LoadDataSet(ds, tblT_USER_PROP_RELATIONSHIP._Name, p_iDetailsID);

                // calculate the distance for each location
                foreach (DataRow dr in ds.Tables[tblT_USER_LOCATION._Name].Rows)
                {
                    try
                    {
                        LatLng latLngSession = new LatLng(p_decLatSession, p_decLngSession);
                        LatLng latLngDetails = new LatLng(Double.Parse(dr["USL_LAT"].ToString()), Double.Parse(dr["USL_LNG"].ToString()));

                        double dblDistance = Math.Abs(GPS.Distance(latLngSession, latLngDetails, MADA.BE.DistanceUnitsEnum.Kilometers));
                        dr["Distance"] = dblDistance;
                    }
                    catch (System.Exception ex)
                    {
                        Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                    }
                }

                return Serializer.SerializeToFlex(ds);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }

        [WebMethod]
        public DataSet GetPhotos(string p_strSID, int p_iDetailsID, int p_iBatchLength)
        {
            try
            {
                DataSet ds = new DataSet();
                procPT_USER_PHOTOSelectByUPH_USER_ID_Batch.LoadDataSet(ds, tblT_USER_PHOTO._Name, p_iBatchLength, p_iDetailsID);
                return Serializer.SerializeToFlex(ds);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }
        [WebMethod]
        public string SetPhotoIOError(string p_strSID, int p_iUserPhotoID)
        {
            string strResult;

            try
            {
                procPT_USER_PHOTOSetIOErrorByUPH_ID.ExecuteNonQuery(p_iUserPhotoID);

                strResult = BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                strResult = BE.ResultCode.FAILED;
            }

            return strResult;
        }

        [WebMethod]
        public string AddEmail(string p_strSID, string p_strEmail)
        {
            string strResult;

            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                object oUSE_ID;
                procAPT_USER_EMAILInsertInto.ExecuteNonQuery(p_strEmail, null, iSessionID, out oUSE_ID);

                strResult = BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                strResult = BE.ResultCode.FAILED;
            }

            return strResult;
        }
        #endregion
        #region Link
        [WebMethod]
        public DataSet GetLinkData(string p_strSID, int p_iDetailsID)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                DataSet ds = new DataSet();
                procAPT_USER_LINKSelectByULK_DETAILS_USER_IDULK_USER_ID.LoadDataSet(ds, tblT_USER_LINK._Name, p_iDetailsID, iSessionID);
                return Serializer.SerializeToFlex(ds);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }

        private T_LINK_TYPE_ENUM GetUserLink(string p_strSID, int p_iDetailsID, Database p_db, DbTransaction p_trn)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                LinkDataSet ds = new LinkDataSet();
                procAPT_USER_LINKSelectByULK_DETAILS_USER_IDULK_USER_ID.LoadDataSet(ds, tblT_USER_LINK._Name, p_iDetailsID, iSessionID, p_db, p_trn);
                if (ds.T_USER_LINK.Rows.Count == 0)
                {
                    return T_LINK_TYPE_ENUM.Exists;
                }
                else
                {
                    return (T_LINK_TYPE_ENUM)ds.T_USER_LINK[0].ULK_LINK_TYPE;
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return T_LINK_TYPE_ENUM.Exists;
            }
        }
        [WebMethod]
        public string ValidateUserLink(string p_strSID, int p_iDetailsID, System.DateTime p_dt, int p_iTimezoneOffset)
        {
            string strResult;

            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                Database db = DatabaseFactory.CreateDatabase();

                using (DbConnection con = db.CreateConnection())
                {
                    con.Open();
                    DbTransaction trn = con.BeginTransaction();
                    Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);

                    try
                    {
                        T_LINK_TYPE_ENUM enmSessionLinkType = GetUserLink(p_strSID, p_iDetailsID, db, trn);
                        if (enmSessionLinkType == T_LINK_TYPE_ENUM.Exists)
                        {
                            // new link - set to Viewed
                            object oULK_ID;
                            procAPT_USER_LINKInsertInto.ExecuteNonQuery(p_dt.AddMinutes(-p_iTimezoneOffset), p_iDetailsID, null, (int)T_LINK_ACTION_TYPE_ENUM.Exists2Viewed,
                                (int)T_LINK_TYPE_ENUM.Viewed, iSessionID, out oULK_ID, db, trn);
                            if (oULK_ID == null)
                            {
                                trn.Rollback();
                                return "Failed to insert new link";
                            }

                            /*
                            if (ApplicationHandler.Instance.T_LINK_ACTION_TYPE_ENUM.FindByLAT_CODE((int)T_LINK_ACTION_TYPE_ENUM.Exists2Viewed) != null)
                            {
                                // new link - send RN and Email of Exists2Viewed
                                T_RMN_TYPE_ENUM enmRMNType = (T_RMN_TYPE_ENUM)ApplicationHandler.Instance.T_LINK_ACTION_TYPE_ENUM.FindByLAT_CODE((int)T_LINK_ACTION_TYPE_ENUM.Exists2Viewed).LAT_RMN_TYPE;
                                strResult = CommHandler.SendRMN(enmRMNType, p_iSessionID, p_iDetailsID, ApplicationHandler.Instance.T_RMN_TYPE_ENUM.FindByRMT_CODE((int)enmRMNType).RMT_TEXT,
                                    p_dt.AddMinutes(-p_iTimezoneOffset), db, trn);
                                if (strResult != BE.ResultCode.SUCCESS)
                                {
                                    trn.Rollback();
                                    return "Failed to send the RN";
                                }
                            }
                            */

                            /*
                            if (ApplicationHandler.Instance.T_LINK_ACTION_TYPE_ENUM.FindByLAT_CODE((int)T_LINK_ACTION_TYPE_ENUM.Exists2Viewed) != null)
                            {
                                T_EMAIL_BOX_TYPE_ENUM enmEMailBoxType = (T_EMAIL_BOX_TYPE_ENUM)ApplicationHandler.Instance.T_LINK_ACTION_TYPE_ENUM.FindByLAT_CODE((int)T_LINK_ACTION_TYPE_ENUM.Exists2Viewed).LAT_EMAIL_BOX_TYPE;
                                strResult = EMailHandler.ComposeEmailBox(enmEMailBoxType, p_iSessionID, p_iDetailsID, string.Empty, string.Empty, -1, db, trn);

                                if (strResult != BE.ResultCode.SUCCESS)
                                {
                                    trn.Rollback();
                                    return "Failed to compose email";
                                }
                            }
                            */
        /*
                        }
                        else
                        {
                            if (ApplicationHandler.Instance.T_LINK_ACTION_TYPE_ENUM.FindByLAT_CODE((int)T_LINK_ACTION_TYPE_ENUM.Viewed) != null)
                            {
                                // new link - send RN and Email of Viewed
                                T_RMN_TYPE_ENUM enmRMNType = (T_RMN_TYPE_ENUM)ApplicationHandler.Instance.T_LINK_ACTION_TYPE_ENUM.FindByLAT_CODE((int)T_LINK_ACTION_TYPE_ENUM.Viewed).LAT_RMN_TYPE;
                                strResult = CommHandler.SendRMN(enmRMNType, iSessionID, p_iDetailsID, ApplicationHandler.Instance.T_RMN_TYPE_ENUM.FindByRMT_CODE((int)enmRMNType).RMT_TEXT,
                                    p_dt.AddMinutes(-p_iTimezoneOffset), db, trn);
                                if (strResult != BE.ResultCode.SUCCESS)
                                {
                                    trn.Rollback();
                                    return "Failed to send the RN";
                                }
                            }

                            /*
                            if (ApplicationHandler.Instance.T_LINK_ACTION_TYPE_ENUM.FindByLAT_CODE((int)T_LINK_ACTION_TYPE_ENUM.Exists2Viewed) != null)
                            {
                                T_EMAIL_BOX_TYPE_ENUM enmEMailBoxType = (T_EMAIL_BOX_TYPE_ENUM)ApplicationHandler.Instance.T_LINK_ACTION_TYPE_ENUM.FindByLAT_CODE((int)T_LINK_ACTION_TYPE_ENUM.Exists2Viewed).LAT_EMAIL_BOX_TYPE;
                                strResult = EMailHandler.ComposeEmailBox(enmEMailBoxType, p_iSessionID, p_iDetailsID, string.Empty, string.Empty, -1, db, trn);

                                if (strResult != BE.ResultCode.SUCCESS)
                                {
                                    trn.Rollback();
                                    return "Failed to compose email";
                                }
                            }
                            */
    /*
                        }

                        trn.Commit();
                        Logger.Instance.WriteCommitTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);
                        return BE.ResultCode.SUCCESS;
                    }
                    catch (System.Exception ex)
                    {
                        trn.Rollback();
                        Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), p_strSID);
                        strResult = BE.ResultCode.FAILED;
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
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                strResult = BE.ResultCode.FAILED;
            }

            return strResult;
        }
        [WebMethod]
        public string DoLinkAction(string p_strSID, int p_iDetailsID, int p_iLinkActionType, System.DateTime p_dt, int p_iTimezoneOffset)
        {
            string strResult;

            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                Database db = DatabaseFactory.CreateDatabase();

                using (DbConnection con = db.CreateConnection())
                {
                    con.Open();
                    DbTransaction trn = con.BeginTransaction();
                    Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);

                    try
                    {
                        T_LINK_TYPE_ENUM enmDetailsLinkType = GetUserLink(p_strSID, p_iDetailsID, db, trn); // IMPORTANT: this need to be reveresed - see the name of the variable
                        T_LINK_TYPE_ENUM enmNewSessionlLinkType = T_LINK_TYPE_ENUM.Exists;
                        bool bSetDetailsLinkType = false;
                        T_LINK_TYPE_ENUM enmNewDetailsLinkType = T_LINK_TYPE_ENUM.Exists;
                        bool bSendRN = false;
                        bool bSendEmail = false;
                        bool bDeleteDetailsInLists = false;

                        switch ((T_LINK_ACTION_TYPE_ENUM)p_iLinkActionType)
                        {
                            case T_LINK_ACTION_TYPE_ENUM.Exists2Viewed:
                                enmNewSessionlLinkType = T_LINK_TYPE_ENUM.Viewed;
                                bSetDetailsLinkType = false;
                                bSendRN = true;
                                bSendEmail = true;
                                break;
                            case T_LINK_ACTION_TYPE_ENUM.Viewed2Requesting:
                                enmNewSessionlLinkType = T_LINK_TYPE_ENUM.Requesting;
                                if (enmDetailsLinkType != T_LINK_TYPE_ENUM.Deleted && enmDetailsLinkType != T_LINK_TYPE_ENUM.Rejected)
                                {
                                    bSetDetailsLinkType = true;
                                    enmNewDetailsLinkType = T_LINK_TYPE_ENUM.Requested;
                                }
                                else
                                {
                                    bSetDetailsLinkType = false;
                                }
                                bSendRN = true;
                                bSendEmail = true;
                                break;
                            case T_LINK_ACTION_TYPE_ENUM.Requesting2Requesting:
                                enmNewSessionlLinkType = T_LINK_TYPE_ENUM.Requesting;
                                if (enmDetailsLinkType != T_LINK_TYPE_ENUM.Deleted && enmDetailsLinkType != T_LINK_TYPE_ENUM.Rejected)
                                {
                                    bSetDetailsLinkType = true;
                                    enmNewDetailsLinkType = T_LINK_TYPE_ENUM.Requested;
                                }
                                else
                                {
                                    bSetDetailsLinkType = false;
                                }
                                bSendRN = true;
                                bSendEmail = true;
                                break;
                            case T_LINK_ACTION_TYPE_ENUM.Viewed2Deleted:
                                enmNewSessionlLinkType = T_LINK_TYPE_ENUM.Deleted;
                                bSetDetailsLinkType = false;
                                bSendRN = false;
                                bSendEmail = false;
                                bDeleteDetailsInLists = true;
                                break;
                            case T_LINK_ACTION_TYPE_ENUM.Requesting2Deleted:
                                enmNewSessionlLinkType = T_LINK_TYPE_ENUM.Deleted;
                                bSetDetailsLinkType = false;
                                bSendRN = false;
                                bSendEmail = false;
                                bDeleteDetailsInLists = true;
                                break;
                            case T_LINK_ACTION_TYPE_ENUM.Deleted2Viewed:
                                enmNewSessionlLinkType = T_LINK_TYPE_ENUM.Viewed;
                                bSetDetailsLinkType = false;
                                bSendRN = true;
                                bSendEmail = true;
                                break;
                            case T_LINK_ACTION_TYPE_ENUM.Requested2Approved:
                                enmNewSessionlLinkType = T_LINK_TYPE_ENUM.Approved;
                                bSetDetailsLinkType = true;
                                enmNewDetailsLinkType = T_LINK_TYPE_ENUM.Approvee;
                                bSendRN = true;
                                bSendEmail = true;
                                break;
                            case T_LINK_ACTION_TYPE_ENUM.Requested2Rejected:
                                enmNewSessionlLinkType = T_LINK_TYPE_ENUM.Rejected;
                                bSetDetailsLinkType = true;
                                enmNewDetailsLinkType = T_LINK_TYPE_ENUM.Rejectee;
                                bSendRN = true;
                                bSendEmail = true;
                                break;
                            case T_LINK_ACTION_TYPE_ENUM.Approved2Deleted:
                                enmNewSessionlLinkType = T_LINK_TYPE_ENUM.Deleted;
                                bSetDetailsLinkType = false;
                                bSendRN = false;
                                bSendEmail = false;
                                bDeleteDetailsInLists = true;
                                break;
                            case T_LINK_ACTION_TYPE_ENUM.Rejected2Viewed:
                                enmNewSessionlLinkType = T_LINK_TYPE_ENUM.Viewed;
                                bSetDetailsLinkType = false;
                                bSendRN = true;
                                bSendEmail = true;
                                break;
                            case T_LINK_ACTION_TYPE_ENUM.Requesting2Approvee:
                                // action done in Requested2Approved
                                break;
                            case T_LINK_ACTION_TYPE_ENUM.Requesting2Rejectee:
                                // action done in Requested2Rejected
                                break;
                            case T_LINK_ACTION_TYPE_ENUM.Approvee2Deleted:
                                enmNewSessionlLinkType = T_LINK_TYPE_ENUM.Deleted;
                                bSetDetailsLinkType = false;
                                bSendRN = false;
                                bSendEmail = false;
                                //bDeleteDetailsInLists = true;
                                break;
                            case T_LINK_ACTION_TYPE_ENUM.Rejectee2Viewed:
                                enmNewSessionlLinkType = T_LINK_TYPE_ENUM.Viewed;
                                bSetDetailsLinkType = false;
                                bSendRN = true;
                                bSendEmail = true;
                                break;
                            default:
                                throw new IndexOutOfRangeException("T_LINK_ACTION_TYPE_ENUM switch out of range");
                        }

                        // set session link type
                        procAPT_USER_LINKUpdateByULK_DETAILS_USER_IDULK_USER_ID.ExecuteNonQuery(
                            p_dt.AddMinutes(-p_iTimezoneOffset), p_iDetailsID, null, p_iLinkActionType, (int)enmNewSessionlLinkType, iSessionID, db, trn);

                        // set details link type - IMPORTANT: this need to be reveresed - see the name of the variable
                        if (bSetDetailsLinkType)
                        {
                            if (enmDetailsLinkType == T_LINK_TYPE_ENUM.Exists)
                            {
                                object oULK_ID;
                                procAPT_USER_LINKInsertInto.ExecuteNonQuery(
                                    p_dt.AddMinutes(-p_iTimezoneOffset), iSessionID, null, p_iLinkActionType, (int)enmNewDetailsLinkType, p_iDetailsID, out oULK_ID, db, trn);
                            }
                            else
                            {
                                procAPT_USER_LINKUpdateByULK_DETAILS_USER_IDULK_USER_ID.ExecuteNonQuery(
                                    p_dt.AddMinutes(-p_iTimezoneOffset), iSessionID, null, p_iLinkActionType, (int)enmNewDetailsLinkType, p_iDetailsID, db, trn);
                            }
                        }

                        if (bSendRN && ApplicationHandler.Instance.T_LINK_ACTION_TYPE_ENUM.FindByLAT_CODE(p_iLinkActionType) != null)
                        {
                            T_RMN_TYPE_ENUM enmRMNType = (T_RMN_TYPE_ENUM)ApplicationHandler.Instance.T_LINK_ACTION_TYPE_ENUM.FindByLAT_CODE(p_iLinkActionType).LAT_RMN_TYPE;
                            strResult = CommHandler.SendRMN(enmRMNType, iSessionID, p_iDetailsID, ApplicationHandler.Instance.T_RMN_TYPE_ENUM.FindByRMT_CODE((int)enmRMNType).RMT_TEXT,
                                p_dt.AddMinutes(-p_iTimezoneOffset), db, trn);
                            if (strResult != BE.ResultCode.SUCCESS)
                            {
                                trn.Rollback();
                                return "Failed to send the RN";
                            }
                        }

                        if (bSendEmail)
                        {
                            // used below
                        }
                        /*
                        if (bSendEmail && ApplicationHandler.Instance.T_LINK_ACTION_TYPE_ENUM.FindByLAT_CODE((int)T_LINK_ACTION_TYPE_ENUM.Exists2Viewed) != null)
                        {
                            T_EMAIL_BOX_TYPE_ENUM enmEMailBoxType = (T_EMAIL_BOX_TYPE_ENUM)ApplicationHandler.Instance.T_LINK_ACTION_TYPE_ENUM.FindByLAT_CODE(p_iLinkActionType).LAT_EMAIL_BOX_TYPE;
                            strResult = EMailHandler.ComposeEmailBox(enmEMailBoxType, p_iSessionID, p_iDetailsID, string.Empty, string.Empty, -1, db, trn);

                            if (strResult != BE.ResultCode.SUCCESS)
                            {
                                trn.Rollback();
                                return "Failed to compose email";
                            }
                        }
                        */
/*
                        if (bDeleteDetailsInLists)
                        {
                            procPT_LIST_USERDeleteByLST_SESSION_USER_IDLSU_DETAILS_USER_ID.ExecuteNonQuery(iSessionID, p_iDetailsID, db, trn);
                        }

                        trn.Commit();
                        Logger.Instance.WriteCommitTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);
                        return BE.ResultCode.SUCCESS;
                    }
                    catch (System.Exception ex)
                    {
                        trn.Rollback();
                        Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), p_strSID);
                        strResult = BE.ResultCode.FAILED;
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
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                strResult = BE.ResultCode.FAILED;
            }

            return strResult;
        }
        #endregion
        #region Comm
        [WebMethod]
        public DataSet GetRMNs(string p_strSID, int p_iRMT_RTT_TYPE_TYPE, int p_iBatchLength)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                DataSet ds = new DataSet();
                procPT_RMNSelectRMNByRMNTypeTypeSessionIDBatch.LoadDataSet(ds, BE.Constants.LOAD_DATASET_TABLE_NAME, p_iBatchLength, p_iRMT_RTT_TYPE_TYPE, iSessionID);
                return Serializer.SerializeToFlex(ds);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }
        [WebMethod]
        public DataSet GetCommunicateUnread(string p_strSID, int p_iDetailsID)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                DataSet ds = new DataSet();
                procAPT_USER_LINKSelectByULK_DETAILS_USER_IDULK_USER_ID.LoadDataSet(ds, tblT_USER_LINK._Name, p_iDetailsID, iSessionID);
                procPT_RMNSelectCommunicateUnread.LoadDataSet(ds, tblT_RMN._Name, p_iDetailsID, iSessionID);
                return Serializer.SerializeToFlex(ds);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }
        [WebMethod]
        public DataSet GetCommunicateBatch(string p_strSID, int p_iDetailsID, int p_iMaxRMN_ID, int p_iBatchLength)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                DataSet ds = new DataSet();
                procPT_RMNSelectCommunicateBatch.LoadDataSet(ds, tblT_RMN._Name, p_iBatchLength, p_iDetailsID, p_iMaxRMN_ID, iSessionID);
                return Serializer.SerializeToFlex(ds);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }

        [WebMethod]
        public DataSet GetTwinks(string p_strSID)
        {
            try
            {
                DataSet ds = new DataSet();
                procPT_TWINK_TYPESelect.LoadDataSet(ds, "T_TWINK_TYPE");
                procPT_TWINKSelect.LoadDataSet(ds, "T_TWINK");
                return Serializer.SerializeToFlex(ds);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }

        [WebMethod]
        public string Delete(string p_strSID, int p_iRMN_ID)
        {
            try
            {
                procAPT_RMNDeleteByRMN_ID.ExecuteNonQuery(p_iRMN_ID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return BE.ResultCode.FAILED;
            }
        }

        [WebMethod]
        public string MarkAsRead(string p_strSID, int p_iRMN_ID)
        {
            return MarkAsReadUnRead(p_strSID, true, p_iRMN_ID);
        }
        [WebMethod]
        public string MarkAsUnRead(string p_strSID, int p_iRMN_ID)
        {
            return MarkAsReadUnRead(p_strSID, false, p_iRMN_ID);
        }
        private string MarkAsReadUnRead(string p_strSID, Boolean p_bRead, int p_iRMN_ID)
        {
            try
            {
                if (p_bRead)
                {
                    procPT_RMNMarkAsReadByRMN_ID.ExecuteNonQuery(p_iRMN_ID);
                    Logger.Instance.WriteInformation("RMN_ID " + p_iRMN_ID + " marked as read.", MethodBase.GetCurrentMethod(), p_strSID);
                }
                else
                {
                    procPT_RMNMarkAsUnReadByRMN_ID.ExecuteNonQuery(p_iRMN_ID);
                    Logger.Instance.WriteInformation("RMN_ID " + p_iRMN_ID + " marked as un read.", MethodBase.GetCurrentMethod(), p_strSID);
                }
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }

        [WebMethod]
        public string SendTwink(string p_strSID, int p_iDetailsID, System.DateTime p_dtRMN_SENT_DATETIME, int p_iTimezoneOffset, string p_strTwink)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                Database db = DatabaseFactory.CreateDatabase();

                using (DbConnection con = db.CreateConnection())
                {
                    con.Open();
                    DbTransaction trn = con.BeginTransaction();
                    Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);

                    try
                    {
                        if (CommHandler.SendRMN(T_RMN_TYPE_ENUM.Twink, iSessionID, p_iDetailsID, p_strTwink, p_dtRMN_SENT_DATETIME.AddMinutes(-p_iTimezoneOffset), db, trn) ==
                            BE.ResultCode.FAILED)
                        {
                            throw new Exception("Failed to send twink");
                        }
                        /*
                        if (EMailHandler.ComposeEmailBox(T_EMAIL_BOX_TYPE_ENUM.Twink, p_iSessionID, p_iDetailsID, p_strTwink, string.Empty, -1, db, trn) == BE.ResultCode.FAILED)
                        {
                            throw new Exception("Failed to send email");
                        }
                        */
        /*
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
            catch (Exception ex)
            {
                Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string SendText(string p_strSID, int p_iDetailsID, System.DateTime p_dtRMN_SENT_DATETIME, int p_iTimezoneOffset, string p_strRMN_TEXT)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                Database db = DatabaseFactory.CreateDatabase();

                using (DbConnection con = db.CreateConnection())
                {
                    con.Open();
                    DbTransaction trn = con.BeginTransaction();
                    Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);

                    try
                    {
                        if (CommHandler.SendRMN(T_RMN_TYPE_ENUM.Text, iSessionID, p_iDetailsID, p_strRMN_TEXT, p_dtRMN_SENT_DATETIME.AddMinutes(-p_iTimezoneOffset), db, trn) ==
                            BE.ResultCode.FAILED)
                        {
                            throw new Exception("Failed to send twink");
                        }
                        /*
                        if (EMailHandler.ComposeEmailBox(T_EMAIL_BOX_TYPE_ENUM.Text, p_iSessionID, p_iDetailsID, p_strRMN_TEXT, string.Empty, -1, db, trn) == BE.ResultCode.FAILED)
                        {
                            throw new Exception("Failed to send email");
                        }
                        */
/*
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
            catch (Exception ex)
            {
                Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return BE.ResultCode.FAILED;
            }
        }
        #endregion
        #region Share
        [WebMethod]
        public bool HasInvited(string p_strSID)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                Database db = DatabaseFactory.CreateDatabase();

                using (DbConnection con = db.CreateConnection())
                {
                    con.Open();

                    try
                    {
                        int iCount = (int)db.ExecuteScalar(procPT_USER_INVITEESelectCountByUSI_INVITER_USER_ID.SqlCommand(iSessionID));

                        return iCount > 0;
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), p_strSID);
                        return false;
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
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return false;
            }
        }
        #endregion
        #endregion
        #region ListController
        [WebMethod]
        public DataSet ListGetListData(string p_strSID, int p_iListID, int p_iBatchLength, decimal p_decLatSession, decimal p_decLngSession)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                DataSet ds = new DataSet();
                procAPT_LISTSelectByLST_ID.LoadDataSet(ds, tblT_LIST._Name, p_iListID);
                procPT_LIST_USERSelectBySessionIDListIDBatch.LoadDataSet(ds, tblT_LIST_USER._Name, p_iBatchLength, p_iListID, iSessionID);

                GPS.Distance(ds.Tables[tblT_LIST_USER._Name].Rows, "Distance", p_decLatSession, p_decLngSession, MADA.BE.DistanceUnitsEnum.Kilometers);

                return Serializer.SerializeToFlex(ds);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }
        [WebMethod]
        public DataSet ListGetListsData(string p_strSID)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                DataSet ds = new DataSet();
                procPT_LISTsSelectByLST_SESSION_USER_ID.LoadDataSet(ds, tblT_LIST._Name, iSessionID);
                procPT_LISTSelectByLST_SESSION_USER_ID.LoadDataSet(ds, tblT_LIST._Name + "ForSession", iSessionID);
                return Serializer.SerializeToFlex(ds);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }
        [WebMethod]
        public int ListCreateNewList(string p_strSID, string p_strDescription, string p_strComment)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                object oLST_ID;
                procAPT_LISTInsertInto.ExecuteNonQuery(p_strComment, p_strDescription, null, (int)T_RESULT_VIEW_TYPE_ENUM.Photos, iSessionID,
                    (int)T_LIST_TYPE_ENUM.Custom, out oLST_ID);
                if (oLST_ID == null)
                {
                    throw new Exception("Failed to insert custom list into T_LIST");
                }
                else
                {
                    return (int)oLST_ID;
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return -1;
            }
        }
        [WebMethod]
        public string ListAddDetailsIDAsFavorites(string p_strSID, int p_iDetailsID)
        {
            int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

            return BL.ListHandler.AddDetailsIDAsFavorites(iSessionID, p_iDetailsID);
        }
        [WebMethod]
        public string ListDeleteList(string p_strSID, int p_iListID)
        {
            try
            {
                int iListID = procAPT_LISTDeleteByLST_ID.ExecuteNonQuery(p_iListID);

                if (iListID == 1)
                {
                    return BE.ResultCode.SUCCESS;
                }
                else
                {
                    return BE.ResultCode.FAILED;
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string ListDeleteMemberFromList(string p_strSID, int p_iListID, int p_iDetailsID)
        {
            try
            {
                procAPT_LIST_USERDeleteByLSU_DETAILS_USER_IDLSU_LIST_ID.ExecuteNonQuery(p_iDetailsID, p_iListID);
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string ListUpdateListResultView(string p_strSID, int p_iLST_ID, int p_iLST_RESULT_VIEW_TYPE_CODE)
        {
            try
            {
                procPT_LISTUpdateResultView.ExecuteNonQuery(p_iLST_ID, p_iLST_RESULT_VIEW_TYPE_CODE);

                return ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return ResultCode.FAILED;
            }
        }

        [WebMethod]
        public int ListAddToExistingList(string p_strSID, int p_iDetailsID, int p_iSavedSearchID, int p_iSelectedListID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                using (DbConnection con = db.CreateConnection())
                {
                    con.Open();
                    DbTransaction trn = con.BeginTransaction();
                    Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);

                    try
                    {
                        ListAddMembers(p_strSID, p_iDetailsID, p_iSavedSearchID, p_iSelectedListID, db, trn);

                        trn.Commit();
                        Logger.Instance.WriteCommitTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);
                        return p_iSelectedListID;
                    }
                    catch (System.Exception ex)
                    {
                        trn.Rollback();
                        Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), p_strSID);
                        return -1;
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
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return -1;
            }
        }
        [WebMethod]
        public int ListAddToNewList(string p_strSID, int p_iDetailsID, int p_iSavedSearchID, string p_strDescription)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                Database db = DatabaseFactory.CreateDatabase();

                using (DbConnection con = db.CreateConnection())
                {
                    con.Open();
                    DbTransaction trn = con.BeginTransaction();
                    Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);

                    try
                    {
                        object oLST_ID;
                        procAPT_LISTInsertInto.ExecuteNonQuery(p_strDescription, p_strDescription, null, (int)T_RESULT_VIEW_TYPE_ENUM.Photos, iSessionID,
                            (int)T_LIST_TYPE_ENUM.Custom, out oLST_ID, db, trn);
                        int iListID;
                        if (oLST_ID == null)
                        {
                            throw new Exception("Failed to insert custom list into T_LIST");
                        }
                        else
                        {
                            iListID = (int)oLST_ID;
                        }

                        ListAddMembers(p_strSID, p_iDetailsID, p_iSavedSearchID, iListID, db, trn);

                        trn.Commit();
                        Logger.Instance.WriteCommitTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);
                        return iListID;
                    }
                    catch (System.Exception ex)
                    {
                        trn.Rollback();
                        Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), p_strSID);
                        return -1;
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
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return -1;
            }
        }
        private string ListAddMembers(string p_strSID, int p_iDetailsID, int p_iSavedSearchID, int p_iSelectedListID, Database p_db, DbTransaction p_trn)
        {
            try
            {
                if (p_iDetailsID != -1)
                {
                    //  add local to list
                    object oLSU_ID;
                    int iResult = procAPT_LIST_USERInsertInto.ExecuteNonQuery(p_iDetailsID, null, p_iSelectedListID, out oLSU_ID, p_db, p_trn);
                    if (iResult == 0)
                    {
                        throw new Exception("Failed to insert member into T_LIST_USER");
                    }
                    else
                    {
                        return BE.ResultCode.SUCCESS;
                    }
                }
                else if (p_iSavedSearchID != -1)
                {
                    //  get members
                    //  add to list
                    throw new NotImplementedException();

                    //return inserted members count, 0 for none, -1 for exception;
                }
                else
                {
                    throw new IndexOutOfRangeException(p_iDetailsID.ToString() + "-" + p_iSavedSearchID.ToString());
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return BE.ResultCode.FAILED;
            }
        }
        #endregion
        #region SearchController
        [WebMethod]
        public DataSet SMapSearch(
            string p_strSID,
            int p_iBatchLength,
            string p_strText,
            bool m_bDoProximitySearch,
            decimal p_decVisibleWest, decimal p_decVisibleEast, decimal p_decVisibleNorth, decimal p_decVisibleSouth, decimal p_decNull,
            bool p_bLogon,
            System.DateTime p_dtNow, decimal p_decAgeFrom, decimal p_decAgeTo,
            string p_strSex,
            string p_strStatus,
            decimal p_decHeightFrom, decimal p_decHeightTo,
            decimal p_decWeightFrom, decimal p_decWeightTo,
            string p_strReligion,
            string p_strRace,
            string p_strEducation,
            bool p_bGetUnlinked, string p_strLink)
        {
            try
            {
                Logger.Instance.WriteInformation("SMapSearch begin:" + p_strSID, MethodBase.GetCurrentMethod(), p_strSID);
                Logger.Instance.WriteInformation("p_strSID:" + p_strSID, MethodBase.GetCurrentMethod(), p_strSID);
                Logger.Instance.WriteInformation("p_iBatchLength:" + p_iBatchLength, MethodBase.GetCurrentMethod(), p_strSID);
                Logger.Instance.WriteInformation("p_strText:" + p_strText, MethodBase.GetCurrentMethod(), p_strSID);
                Logger.Instance.WriteInformation("m_bDoProximitySearch:" + m_bDoProximitySearch, MethodBase.GetCurrentMethod(), p_strSID);
                Logger.Instance.WriteInformation("p_decVisibleWest:" + p_decVisibleWest, MethodBase.GetCurrentMethod(), p_strSID);
                Logger.Instance.WriteInformation("p_decVisibleEast:" + p_decVisibleEast, MethodBase.GetCurrentMethod(), p_strSID);
                Logger.Instance.WriteInformation("p_decVisibleNorth:" + p_decVisibleNorth, MethodBase.GetCurrentMethod(), p_strSID);
                Logger.Instance.WriteInformation("p_decVisibleSouth:" + p_decVisibleSouth, MethodBase.GetCurrentMethod(), p_strSID);
                Logger.Instance.WriteInformation("p_decNull:" + p_decNull, MethodBase.GetCurrentMethod(), p_strSID);
                Logger.Instance.WriteInformation("p_bLogon:" + p_bLogon, MethodBase.GetCurrentMethod(), p_strSID);
                Logger.Instance.WriteInformation("p_dtNow:" + p_dtNow, MethodBase.GetCurrentMethod(), p_strSID);
                Logger.Instance.WriteInformation("p_decAgeFrom:" + p_decAgeFrom, MethodBase.GetCurrentMethod(), p_strSID);
                Logger.Instance.WriteInformation("p_decAgeTo:" + p_decAgeTo, MethodBase.GetCurrentMethod(), p_strSID);
                Logger.Instance.WriteInformation("p_strSex:" + p_strSex, MethodBase.GetCurrentMethod(), p_strSID);
                Logger.Instance.WriteInformation("p_strStatus:" + p_strStatus, MethodBase.GetCurrentMethod(), p_strSID);

                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                if (p_iBatchLength > ApplicationHandler.Instance.MaxRowsOnSPSelect)
                {
                    p_iBatchLength = ApplicationHandler.Instance.MaxRowsOnSPSelect;
                }

                // select clause
                string strSelectClause = "SELECT TOP (" + p_iBatchLength + ") USR_ID, USR_V_NAME, USR_PROP_SEX_CODE, USR_PROP_BIRTHDATE, USR_PROP_STATUS_CODE, LGN_USER_ID, ULK_LINK_TYPE, USR_PIC_URL, USL_LAT, USL_LNG, T_USER_SETTINGVisibility.USS_INT as Visibility";

                // count clause
                string strCountClause = "SELECT Count(USR_ID) AS Length";

                // from clause
                StringBuilder sbFromClause = new StringBuilder();
                sbFromClause.Append(" FROM T_USER");
                sbFromClause.Append(" LEFT OUTER JOIN T_USER_LOCATION ON USL_USER_ID = USR_ID AND USL_USER_LOCATION_TYPE = 10");
                sbFromClause.Append(" LEFT OUTER JOIN T_USER_SETTING as T_USER_SETTINGVisibility ON USS_USER_SETTING_TYPE = 40 AND USR_ID = USS_USER_ID");

                // logon
                if (p_bLogon)
                {
                    sbFromClause.Append(" JOIN T_LOGON ON USR_ID = LGN_USER_ID");
                }
                else
                {
                    sbFromClause.Append(" LEFT OUTER JOIN T_LOGON ON USR_ID = LGN_USER_ID");
                }

                // link
                sbFromClause.Append(" LEFT OUTER JOIN T_USER_LINK ON USR_ID = ULK_DETAILS_USER_ID");
                sbFromClause.Append(" AND ULK_USER_ID = " + iSessionID);

                // order by clause
                string strOrderBy = " ORDER BY USR_ID DESC";

                // where clause
                StringBuilder sbWhereClause = new StringBuilder();
                // id
                sbWhereClause.Append(" WHERE USR_ID <> " + iSessionID);

                // text
                if (p_strText != string.Empty)
                {
                    //sbCommandText.Append(" AND (USR_NAME LIKE '%" + p_strText + "%' OR USR_V_NAME LIKE '%" + p_strText + "%')");
                    sbWhereClause.Append(" AND USR_V_NAME LIKE '%" + p_strText + "%'");
                }

                if (p_strLink != "-1")
                {
                    if (p_bGetUnlinked)
                    {
                        sbWhereClause.Append(" AND (ULK_LINK_TYPE in (" + p_strLink + ") OR ULK_LINK_TYPE IS NULL)");
                    }
                    else
                    {
                        sbWhereClause.Append(" AND ULK_LINK_TYPE in (" + p_strLink + ")");
                    }
                }

                // height range
                if (p_decHeightFrom == BL.ApplicationHandler.T_PROP_HEIGHT_TYPEMin() && p_decHeightTo == BL.ApplicationHandler.T_PROP_HEIGHT_TYPEMax())
                {
                    //sbWhereClause.Append(" AND USR_PROP_HEIGHT_CODE is null");
                }
                else if (p_decHeightFrom == BL.ApplicationHandler.T_PROP_HEIGHT_TYPEMin())
                {
                    sbWhereClause.Append(" AND (USR_PROP_HEIGHT_CODE <= '" + p_decHeightTo + "' OR USR_PROP_HEIGHT_CODE is null)");
                }
                else if (p_decHeightTo == BL.ApplicationHandler.T_PROP_HEIGHT_TYPEMax())
                {
                    sbWhereClause.Append(" AND (USR_PROP_HEIGHT_CODE >= '" + p_decHeightFrom + "' OR USR_PROP_HEIGHT_CODE is null)");
                }
                else
                {
                    sbWhereClause.Append(" AND (USR_PROP_HEIGHT_CODE BETWEEN " + p_decHeightFrom + " AND " + p_decHeightTo + " OR USR_PROP_HEIGHT_CODE is null)");
                }

                // weight range
                if (p_decWeightFrom == BL.ApplicationHandler.T_PROP_WEIGHT_TYPEMin() && p_decWeightTo == BL.ApplicationHandler.T_PROP_WEIGHT_TYPEMax())
                {
                    //sbWhereClause.Append(" AND USR_PROP_WEIGHT_CODE is null");
                }
                else if (p_decWeightFrom == BL.ApplicationHandler.T_PROP_WEIGHT_TYPEMin())
                {
                    sbWhereClause.Append(" AND (USR_PROP_WEIGHT_CODE <= '" + p_decWeightTo + "' OR USR_PROP_WEIGHT_CODE is null)");
                }
                else if (p_decWeightTo == BL.ApplicationHandler.T_PROP_WEIGHT_TYPEMax())
                {
                    sbWhereClause.Append(" AND (USR_PROP_WEIGHT_CODE >= '" + p_decWeightFrom + "' OR USR_PROP_WEIGHT_CODE is null)");
                }
                else
                {
                    sbWhereClause.Append(" AND (USR_PROP_WEIGHT_CODE BETWEEN " + p_decWeightFrom + " AND " + p_decWeightTo + " OR USR_PROP_WEIGHT_CODE is null)");
                }

                if (p_strSex != "-1")
                {
                    if (p_strSex == "-1,1")
                    {
                        sbWhereClause.Append(" AND USR_PROP_SEX_CODE = 1");
                    }
                    else if (p_strSex == "-1,2")
                    {
                        sbWhereClause.Append(" AND USR_PROP_SEX_CODE = 2");
                    }
                }

                if (p_strStatus != "-1")
                {
                    sbWhereClause.Append(" AND (USR_PROP_STATUS_CODE in (" + p_strStatus + ") OR USR_PROP_STATUS_CODE is null)");
                }

                if (p_strReligion != "-1")
                {
                    sbWhereClause.Append(" AND (USR_PROP_RELIGION_CODE in (" + p_strReligion + ") OR USR_PROP_RELIGION_CODE is null)");
                }

                if (p_strRace != "-1")
                {
                    sbWhereClause.Append(" AND (USR_PROP_RACE_CODE in (" + p_strRace + ") OR USR_PROP_RACE_CODE is null)");
                }

                if (p_strEducation != "-1")
                {
                    sbWhereClause.Append(" AND (USR_PROP_EDUCATION_CODE in (" + p_strEducation + ") OR USR_PROP_EDUCATION_CODE is null)");
                }

                // age range
                if (p_decAgeFrom == BL.ApplicationHandler.T_PROP_AGE_RANGE_TYPEMin() && p_decAgeTo == BL.ApplicationHandler.T_PROP_AGE_RANGE_TYPEMax())
                {
                    // do nothing, all age range, birthday is not nullable
                }
                else if (p_decAgeFrom == BL.ApplicationHandler.T_PROP_AGE_RANGE_TYPEMin())
                {
                    string strDateTo = p_dtNow.Year - p_decAgeFrom + "-" + p_dtNow.Month + "-" + p_dtNow.Day;
                    sbWhereClause.Append(" AND USR_PROP_BIRTHDATE <= '" + strDateTo + "'");
                }
                else if (p_decAgeTo == BL.ApplicationHandler.T_PROP_AGE_RANGE_TYPEMax())
                {
                    string strDateFrom = p_dtNow.Year - p_decAgeTo + "-" + p_dtNow.Month + "-" + p_dtNow.Day;
                    sbWhereClause.Append(" AND USR_PROP_BIRTHDATE >= '" + strDateFrom + "'");
                }
                else
                {
                    string strDateFrom = p_dtNow.Year - p_decAgeTo + "-" + p_dtNow.Month + "-" + p_dtNow.Day;
                    string strDateTo = p_dtNow.Year - p_decAgeFrom + "-" + p_dtNow.Month + "-" + p_dtNow.Day;
                    sbWhereClause.Append(" AND USR_PROP_BIRTHDATE BETWEEN '" + strDateFrom + "' AND '" + strDateTo + "'");
                }

                // proximity
                if (m_bDoProximitySearch)
                {
                    //USL_LNG
                    string strWhereLngLocation1 = string.Empty;
                    string strWhereLngLocation2 = string.Empty;
                    if (p_decVisibleWest == p_decVisibleEast)
                    {
                        strWhereLngLocation1 = "USL_LNG = " + p_decVisibleWest;
                    }
                    else if (p_decVisibleWest < 0)
                    {
                        if (p_decVisibleEast > p_decVisibleWest && p_decVisibleEast < 0)
                        {
                            strWhereLngLocation1 = "USL_LNG >= " + p_decVisibleWest + " AND USL_LNG <= " + p_decVisibleEast;
                        }
                        else if (p_decVisibleEast >= 0 && p_decVisibleEast <= 180)
                        {
                            strWhereLngLocation1 = "USL_LNG >= " + p_decVisibleWest + " AND USL_LNG <= " + p_decVisibleEast;
                        }
                        else if (p_decVisibleEast >= -180 && p_decVisibleEast < p_decVisibleWest)
                        {
                            strWhereLngLocation1 = "USL_LNG >= " + p_decVisibleWest + " AND USL_LNG <= 180";
                            strWhereLngLocation2 = "USL_LNG >= -180 AND USL_LNG <= " + p_decVisibleEast;
                        }
                        else
                        {
                            Logger.Instance.WriteCritical("p_decVisibleEast out of bounds:" + p_decVisibleEast, MethodBase.GetCurrentMethod(), p_strSID);
                        }
                    }
                    else if (p_decVisibleWest >= 0)
                    {
                        if (p_decVisibleEast > p_decVisibleWest && p_decVisibleEast <= 180)
                        {
                            strWhereLngLocation1 = "USL_LNG >= " + p_decVisibleWest + " AND USL_LNG <= " + p_decVisibleEast;
                        }
                        else if (p_decVisibleEast < p_decVisibleWest)
                        {
                            strWhereLngLocation1 = "USL_LNG >= " + p_decVisibleWest + " AND USL_LNG <= 180";
                            strWhereLngLocation2 = "USL_LNG >= -180 AND USL_LNG <= " + p_decVisibleEast;
                        }
                        else
                        {
                            Logger.Instance.WriteCritical("p_decVisibleEast out of bounds:" + p_decVisibleEast, MethodBase.GetCurrentMethod(), p_strSID);
                        }
                    }

                    //USL_LAT
                    string strWhereLatLocation = string.Empty;
                    if (p_decVisibleNorth == p_decVisibleSouth)
                    {
                        strWhereLatLocation = "USL_LAT = " + p_decVisibleNorth;
                    }
                    else if (p_decVisibleNorth > p_decVisibleSouth)
                    {
                        strWhereLatLocation = "USL_LAT >= " + p_decVisibleSouth + " AND USL_LAT <= " + p_decVisibleNorth;
                    }
                    else
                    {
                        strWhereLatLocation = "USL_LAT >= " + p_decVisibleNorth + " AND USL_LAT <= " + p_decVisibleSouth;
                    }

                    if (strWhereLngLocation2 == string.Empty)
                    {
                        sbWhereClause.Append(" AND " + strWhereLngLocation1);
                    }
                    else
                    {
                        sbWhereClause.Append(" AND (" + strWhereLngLocation1 + " OR " + strWhereLngLocation2 + ") AND " + strWhereLatLocation);
                    }
                }

                // execute command
                DataSet ds = new DataSet();

                Database db = DatabaseFactory.CreateDatabase();
                using (DbConnection con = db.CreateConnection())
                {
                    con.Open();

                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = strSelectClause + sbFromClause.ToString() + sbWhereClause.ToString() + strOrderBy;
                        Logger.Instance.WriteInformation("CommandText:" + cmd.CommandText, MethodBase.GetCurrentMethod(), p_strSID);
                        db.LoadDataSet(cmd, ds, "T_RESULTS");

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = strCountClause + sbFromClause.ToString() + sbWhereClause.ToString();
                        Logger.Instance.WriteInformation("CommandText:" + cmd.CommandText, MethodBase.GetCurrentMethod(), p_strSID);
                        db.LoadDataSet(cmd, ds, "TableLength");
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                        ds = null;
                    }
                    finally
                    {
                        if (con != null)
                        {
                            con.Close();
                        }
                    }
                }

                //Logger.Instance.Write(ds, MethodBase.GetCurrentMethod(), p_strSID);

                return Serializer.SerializeToFlex(ds);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }
        #endregion
        #region Facebook
        [WebMethod]
        public DataTable FacebookGetPhotos(string p_strSID, string p_strToken)
        {
            try
            {
                DataTable dtFacebook = FacebookUtil.GetFbFqlPhotos(p_strSID, p_strToken);

                DataSet ds = new DataSet();
                procAPT_USER_PHOTOSelectByUPH_ID.LoadDataSet(ds, tblT_USER_PHOTO._Name, -1);

                foreach (DataRow dr in dtFacebook.Rows)
                {
                    DataRow drNew = ds.Tables[tblT_USER_PHOTO._Name].NewRow();
                    drNew[tblT_USER_PHOTO.colUPH_ID._Name] = dr[tblT_USER_PHOTO.colUPH_ID._Name];
                    drNew[tblT_USER_PHOTO.colUPH_IO_ERROR._Name] = dr[tblT_USER_PHOTO.colUPH_IO_ERROR._Name];
                    drNew[tblT_USER_PHOTO.colUPH_ORIGINAL_URL._Name] = dr[tblT_USER_PHOTO.colUPH_ORIGINAL_URL._Name];
                    drNew[tblT_USER_PHOTO.colUPH_SMALL_URL._Name] = dr[tblT_USER_PHOTO.colUPH_SMALL_URL._Name];
                    drNew[tblT_USER_PHOTO.colUPH_THUMB_URL._Name] = dr[tblT_USER_PHOTO.colUPH_THUMB_URL._Name];
                    drNew[tblT_USER_PHOTO.colUPH_USER_ID._Name] = dr[tblT_USER_PHOTO.colUPH_USER_ID._Name];

                    ds.Tables[tblT_USER_PHOTO._Name].Rows.Add(drNew);
                }

                return ds.Tables[tblT_USER_PHOTO._Name];
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }
        #endregion
        #region FAQController
        [WebMethod]
        public DataSet GetFAQs(string p_strSID)
        {
            try
            {
                DataSet ds = new DataSet();
                procPT_FAQ_TYPESelect.LoadDataSet(ds, "T_FAQ_TYPE");
                procAPT_FAQSelect.LoadDataSet(ds, "T_FAQ");
                return Serializer.SerializeToFlex(ds);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }
        #endregion
        #region SupportController
        [WebMethod]
        public DataSet SupportGetTicket(string p_strSID, int p_iTicketID)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                DataSet ds = new DataSet();
                Database db = DatabaseFactory.CreateDatabase();

                using (DbConnection con = db.CreateConnection())
                {
                    con.Open();
                    DbTransaction trn = con.BeginTransaction();
                    Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);

                    try
                    {
                        procAPT_TICKETSelectByTKT_ID.LoadDataSet(ds, tblT_TICKET._Name, p_iTicketID, db, trn);
                        procPT_TICKET_THREADSelectByTTT_TICKET_ID.LoadDataSet(ds, tblT_TICKET_THREAD._Name, p_iTicketID, db, trn);

                        // check that globalID has authorization for this ticket
                        if (iSessionID != ApplicationHandler.Instance.DatePercentUserID)
                        {
                            if ((int)ds.Tables[tblT_TICKET._Name].Rows[0][tblT_TICKET.colTKT_OPENER_USER_ID._Name] != iSessionID)
                            {
                                throw new Exception("Member not authorized for this ticket.");
                            }
                        }

                        trn.Commit();
                        return Serializer.SerializeToFlex(ds);
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), p_strSID);
                        trn.Rollback();
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
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }
        [WebMethod]
        public DataSet SupportGetTickets(string p_strSID)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                Logger.Instance.WriteInformation("ronnie", MethodBase.GetCurrentMethod(), p_strSID);
                DataSet ds = new DataSet();

                if (iSessionID == ApplicationHandler.Instance.DatePercentUserID)
                {
                    procPT_TICKETSelect.LoadDataSet(ds, tblT_TICKET._Name);
                }
                else
                {
                    procPT_TICKETSelectByTKT_OPENER_USER_ID.LoadDataSet(ds, tblT_TICKET._Name, iSessionID);
                }

                return Serializer.SerializeToFlex(ds);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
        }
        [WebMethod]
        public string SupportInsertNewTicket(string p_strSID, string p_strSubject, string p_strBody, System.DateTime p_dt, int p_iTimezoneOffset)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                Database db = DatabaseFactory.CreateDatabase();

                using (DbConnection con = db.CreateConnection())
                {
                    con.Open();
                    DbTransaction trn = con.BeginTransaction();
                    Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);

                    try
                    {
                        object oTKT_ID;
                        procAPT_TICKETInsertInto.ExecuteNonQuery(null, true, iSessionID, p_strSubject, out oTKT_ID, db, trn);
                        if (oTKT_ID == null)
                        {
                            throw new Exception("Failed to insert new ticket.");
                        }
                        int iTKT_ID = (int)oTKT_ID;

                        object oTTT_ID;
                        procAPT_TICKET_THREADInsertInto.ExecuteNonQuery(p_strBody, null, iTKT_ID, p_dt.AddMinutes(-p_iTimezoneOffset), iSessionID, out oTTT_ID, db, trn);
                        if (oTTT_ID == null)
                        {
                            throw new Exception("Failed to insert new ticket thread.");
                        }

                        EMailHandler.ComposeEmailBox(p_strSID, T_EMAIL_BOX_TYPE_ENUM.NewTicket, iSessionID, ApplicationHandler.Instance.DatePercentUserID, p_strSubject, string.Empty, iTKT_ID, db, trn);

                        Logger.Instance.WriteCommitTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);
                        trn.Commit();
                        return ResultCode.SUCCESS;
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), p_strSID);
                        trn.Rollback();
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
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string SupportInsertNewTicketThread(string p_strSID, int p_iTicketID, int p_iOpenerUserID, string p_strBody, System.DateTime p_dt, int p_iTimezoneOffset)
        {
            try
            {
                int iSessionID = SessionHandler.SessionGetUserID(p_strSID);

                Database db = DatabaseFactory.CreateDatabase();

                using (DbConnection con = db.CreateConnection())
                {
                    con.Open();
                    DbTransaction trn = con.BeginTransaction();
                    Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);

                    try
                    {
                        object oTTT_ID;
                        procAPT_TICKET_THREADInsertInto.ExecuteNonQuery(p_strBody, null, p_iTicketID, p_dt.AddMinutes(-p_iTimezoneOffset), iSessionID, out oTTT_ID, db, trn);
                        if (oTTT_ID == null)
                        {
                            throw new Exception("Failed to insert new ticket thread.");
                        }

                        procPT_TICKETUpdateIsOpenedByTKT_ID.ExecuteNonQuery(p_iTicketID, db, trn);

                        if (iSessionID == p_iOpenerUserID)
                        {
                            EMailHandler.ComposeEmailBox(p_strSID, T_EMAIL_BOX_TYPE_ENUM.TicketReopened, iSessionID, ApplicationHandler.Instance.DatePercentUserID, p_strBody, string.Empty, p_iTicketID, db, trn);
                        }
                        else
                        {
                            EMailHandler.ComposeEmailBox(p_strSID, T_EMAIL_BOX_TYPE_ENUM.TicketResponded, iSessionID, p_iOpenerUserID, p_strBody, string.Empty, p_iTicketID, db, trn);
                        }

                        Logger.Instance.WriteCommitTrn(System.Reflection.MethodBase.GetCurrentMethod(), p_strSID);
                        trn.Commit();
                        return ResultCode.SUCCESS;
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), p_strSID);
                        trn.Rollback();
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
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string SupportCloseTicket(string p_strSID, int p_iTicketID)
        {
            try
            {
                procPT_TICKETUpdateIsClosedByTKT_ID.ExecuteNonQuery(p_iTicketID);

                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return ResultCode.FAILED;
            }
        }
        #endregion
        #region Common
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
        */
    }
}
