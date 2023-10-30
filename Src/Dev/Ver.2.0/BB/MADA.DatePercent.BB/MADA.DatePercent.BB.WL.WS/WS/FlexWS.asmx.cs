using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using MADA.DatePercent.BB.WL.BL;
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.SPs;
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.Tables;
using MADA.Log.Api.Net;
using System.Reflection;

namespace MADA.DatePercent.BB.WL.WS.WS
{
    /// <summary>
    /// Summary description for FlexWS
    /// </summary>
    [WebService(Namespace = "http://www.datepercent.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class FlexWS : System.Web.Services.WebService
    {
        #region BreakingNewsBar
        // RadiusPopBox
        [WebMethod]
        public string SetRadius(string p_strSID, int p_iRadiusKm)
        {
            try
            {


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
        public string SetLocation(string p_strSID, decimal p_decLat, decimal p_decLng)
        {
            try
            {


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


                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }

        // Messages
        [WebMethod]
        public string DeleteMessage(string p_strSID, int p_iMessageID)
        {
            try
            {


                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string SetMessageAsRead(string p_strSID, int p_iMessageID)
        {
            try
            {


                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string SetMessageAsUnRead(string p_strSID, int p_iMessageID)
        {
            try
            {


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


                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }

        // Help
        [WebMethod]
        public string SendFeedback(string p_strSID, string p_strName, string p_strEMail, string p_strBody)
        {
            try
            {


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


                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }

        // Twink
        [WebMethod]
        public string SendTwink(string p_strSID, int p_iMemberID, int p_iTwinkTypeCode)
        {
            try
            {


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
        public string BlockMember(string p_strSID, int p_iMemberID)
        {
            try
            {


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
        public DataSet FillApplication(string p_strSID)
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
        public DataSet FillSessionMe(string p_strSID, string p_strDetailsID)
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
        [WebMethod]
        public DataSet FillSessionMembers(string p_strSID)
        {
            try
            {


                return null;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return null;
            }
        }
        #endregion
    }
}
