using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using MADA.Log.Api.Net;
using MADA.DatePercent.BB.BE;
using System.Reflection;

namespace MADA.DatePercent.BB.NLB.WS.WS
{
    /// <summary>
    /// Summary description for NlbWS
    /// </summary>
    [WebService(Namespace = "http://www.datepercent.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class NlbWS : System.Web.Services.WebService
    {
        [WebMethod]
        public int GetIISServerID(string p_strSessionID, string p_strIP)
        {
            try
            {
                Logger.Instance.WriteInformation("GetIISServerID", MethodBase.GetCurrentMethod(), p_strSessionID);

                int iServerID = ApplicationHandler.Instance.GetIISServerID(p_strIP);
                //Logger.Instance.WriteProcess("iServerID:" + iServerID, MethodBase.GetCurrentMethod(), p_strSessionID);

                return iServerID;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSessionID);
                return -1;
            }
        }

        [WebMethod]
        public string UpdateIISServerUsersCount(string p_strSessionID, int p_iIISServerID, int p_iUsersCount)
        {
            try
            {
                Logger.Instance.WriteInformation("IISServerID:" + p_iIISServerID + " UsersCount:" + p_iUsersCount, MethodBase.GetCurrentMethod(), p_strSessionID);

                ApplicationHandler.Instance.SetIISUsersCount(p_iIISServerID, p_iUsersCount);

                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSessionID);
                return ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string UpdateBLServerUsersCount(string p_strSessionID, int p_iBLServerID, int p_iUsersCount)
        {
            try
            {
                Logger.Instance.WriteInformation("BLServerID:" + p_iBLServerID + " UsersCount:" + p_iUsersCount, MethodBase.GetCurrentMethod(), p_strSessionID);

                ApplicationHandler.Instance.SetBLUsersCount(p_iBLServerID, p_iUsersCount);

                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSessionID);
                return ResultCode.FAILED;
            }
        }

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
    }
}