using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using MADA.DatePercent.BB.BE;
using MADA.Log.Api.Net;
using System.Reflection;
using MADA.DatePercent.BB.Storage.DBS.dbStorageDB.SPs;
using MADA.DatePercent.BB.Storage.DBS.dbStorageDB.Tables;

namespace MADA.DatePercent.BB.Storage.WS.WS
{
    /// <summary>
    /// Summary description for NLBWS
    /// </summary>
    [WebService(Namespace = "http://www.datepercent.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class NLBWS : System.Web.Services.WebService
    {
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
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return ResultCode.FAILED;
            }
        }
        #endregion
        #region Session
        [WebMethod]
        public string SessionInit(string p_strSID, string p_strToken)
        {
            try
            {
                int iUserID = FacebookHandler.Instance.PreFillFbUser(p_strSID, p_strToken);
                Logger.Instance.WriteInformation("iUserID:" + iUserID, MethodBase.GetCurrentMethod(), p_strSID);

                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return BE.ResultCode.FAILED;
            }
        }
        #endregion
        #region Locale
        [WebMethod]
        public string GetLocale(string p_strFBUid)
        {
            try
            {
                DataSet ds = new DataSet();
                procAPT_USERSelectByUSR_FB_UID.LoadDataSet(ds, tblT_USER._Name, p_strFBUid);
                return ApplicationHandler.Instance.T_LOCALE_TYPE.FindByLCL_CODE(Int32.Parse(ds.Tables[0].Rows[0][tblT_USER.colUSR_LOCALE_CODE._Name].ToString())).LCL_LOCALE;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return string.Empty;
            }
        }
        #endregion
    }
}