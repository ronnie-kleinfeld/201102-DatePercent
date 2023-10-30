using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using MADA.Log.Api.Net;
using MADA.DatePercent.BB.WL.BL;
using MADA.DatePercent.BB.WL.WS.Properties;
using MADA.DatePercent.BB.WL.WS.Worker;
using System.Reflection;

namespace MADA.DatePercent.BB.WL.WS
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            try
            {
                Logger.Instance.Init("DP Server", Settings.Default.LogInformation, Settings.Default.LogProcess);

                Logger.Instance.WriteProcess("Started", MethodBase.GetCurrentMethod(), Environment.MachineName);
                Logger.Instance.WriteProcess("Environment.MachineName=" + System.Environment.MachineName, MethodBase.GetCurrentMethod(), Environment.MachineName);

                ApplicationHandler.Instance.Refresh();

                TimerHandler.Instance.Start();

                Logger.Instance.WriteProcess("Ended", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (System.Exception ex)
            {
                MADA.Common.Net.Mail.SendEMail("DATEPERCENT CRITICAL", "<hr/>Global::Application_Start()<hr/>Exception='" + ex.Message + "'<hr/>");
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        protected void Application_End(object sender, EventArgs e)
        {
            try
            {
                TimerHandler.Instance.Stop();

                Logger.Instance.WriteProcess("Application_End", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            try
            {
                Logger.Instance.WriteProcess("Started", MethodBase.GetCurrentMethod(), string.Empty);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        protected void Session_End(object sender, EventArgs e)
        {
            try
            {
                Logger.Instance.WriteProcess("Ended", MethodBase.GetCurrentMethod(), string.Empty);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
    }
}