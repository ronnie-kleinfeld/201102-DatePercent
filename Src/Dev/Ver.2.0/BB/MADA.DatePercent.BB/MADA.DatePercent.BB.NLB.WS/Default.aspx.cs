using System;
using System.Reflection;
using MADA.Common.DataType;
using MADA.DatePercent.BB.BE;
using MADA.DatePercent.BB.BL;
using MADA.DatePercent.BB.NLB.DBS.dbNlbDB.SPs;
using MADA.DatePercent.SMTP.Api.Net;
using MADA.Log.Api.Net;
using System.Data;
using System.Xml;
using System.Net;
using System.IO;

namespace MADA.DatePercent.BB.NLB.WS
{
    public partial class Default : System.Web.UI.Page
    {
        public string m_strRedirectUrl;
        public string m_strIIS_BL;
        public string m_strLocale;

        protected void Page_Load(object sender, EventArgs e)
        {
            Logger.Instance.WriteProcess("Page_Load:" + Request.Url, MethodBase.GetCurrentMethod(), Environment.MachineName);

            try
            {
                if (Request.Url.Query.Contains(Constants.FB_ACCESS_TOKEN_KEY))
                {
                    // goto oAuth
                    Response.Redirect(Constants.RootUrl + "Flex/Loader.aspx" + Request.Url.Query, false);
                }
                else
                {
                    string strIP = MADA.Web.HttpContext.HttpContext.GetIP();
                    Logger.Instance.WriteInformation("strIP:" + strIP, MethodBase.GetCurrentMethod(), Environment.MachineName);
                    long longIP = MADA.Common.Net.IP.ToLong(strIP);
                    Logger.Instance.WriteInformation("longIP:" + longIP, MethodBase.GetCurrentMethod(), Environment.MachineName);

                    ApplicationHandler.T_IP_LAT_LNGRow drIPL = ApplicationHandler.Instance.T_IP_LAT_LNG.FindByIPL_IP(longIP);
                    if (drIPL == null)
                    {
                        Logger.Instance.WriteInformation("longIP not found", MethodBase.GetCurrentMethod(), Environment.MachineName);

                        Location location = LocationHandler.GetLocation(Environment.MachineName, strIP);
                        Logger.Instance.WriteInformation("location:" + location.ToString(), MethodBase.GetCurrentMethod(), Environment.MachineName);

                        int iIISServer = ApplicationHandler.Instance.GetIISServerID(location);
                        Logger.Instance.WriteInformation("iIISServer:" + iIISServer, MethodBase.GetCurrentMethod(), Environment.MachineName);

                        int iBLServer = ApplicationHandler.Instance.GetBLServerID(location);
                        Logger.Instance.WriteInformation("iBLServer:" + iBLServer, MethodBase.GetCurrentMethod(), Environment.MachineName);

                        object o;
                        procAPT_IP_LAT_LNGInsertIntoUpdateByIPL_IP.ExecuteNonQuery(iBLServer, iIISServer, longIP, location.GetLat, location.GetLng, true, null, out o);

                        drIPL = ApplicationHandler.Instance.T_IP_LAT_LNG.AddT_IP_LAT_LNGRow(longIP, location.GetLat, location.GetLng, iIISServer, iBLServer, false);
                    }
                    else
                    {
                        procPT_IP_LAT_LNGUpdateToValidateByIPL_IP.ExecuteNonQuery(longIP);
                    }
                    Logger.Instance.Write(drIPL, MethodBase.GetCurrentMethod(), Environment.MachineName);

                    ApplicationHandler.T_SERVER_IISRow drServerIIS = ApplicationHandler.Instance.T_SERVER_IIS.FindBySRV_ID(drIPL.IPL_IIS_SERVER_ID);
                    Logger.Instance.Write(drServerIIS, MethodBase.GetCurrentMethod(), Environment.MachineName);
                    ApplicationHandler.T_SERVER_BLRow drServerBL = ApplicationHandler.Instance.T_SERVER_BL.FindBySRV_ID(drIPL.IPL_BL_SERVER_ID);
                    Logger.Instance.Write(drServerBL, MethodBase.GetCurrentMethod(), Environment.MachineName);

                    m_strRedirectUrl = Constants.RootFlexUrl + "FBLogin.aspx";
                    m_strIIS_BL = "IIS=" + drServerIIS.SRV_ID + "&BL=" + drServerBL.SRV_ID;
                    Logger.Instance.WriteProcess("m_strRedirectUrl:" + m_strRedirectUrl, MethodBase.GetCurrentMethod(), Environment.MachineName);
                    Logger.Instance.WriteProcess("m_strIIS_BL:" + m_strIIS_BL, MethodBase.GetCurrentMethod(), Environment.MachineName);

                    Logger.Instance.WriteInformation("Ended", MethodBase.GetCurrentMethod(), Environment.MachineName);
                }
            }
            catch (Exception ex)
            {
                Mailer.Instance.Compose("NLB.WS.Default FAILED!!!", "<hr/>NLB.WS.Default FAILED!!!<hr/>" + System.Reflection.MethodBase.GetCurrentMethod() + "<hr/>" + ex.Message);
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
   }
}