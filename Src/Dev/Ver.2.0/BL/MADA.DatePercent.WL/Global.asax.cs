using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using MADA.DatePercent.BL;
using MADA.DatePercent.Worker;
using MADA.DatePercent.WL.Properties;
using MADA.DatePercent.BE;
using MADA.Log.Api.Net;
using MADA.Log.API.Net;

namespace MADA.DatePercent.WL
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            try
            {
                Logger.Instance.Init("DP Server", Settings.Default.LogInformation, Settings.Default.LogProcess);
                
                Logger.Instance.WriteProcess("Started", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                Logger.Instance.WriteProcess("Environment.MachineName=" + System.Environment.MachineName, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                ApplicationHandler.Instance.Refresh();

                TimerHandler.Instance.Start();

                Logger.Instance.WriteProcess("Ended", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (System.Exception ex)
            {
                MADA.Common.Net.Mail.SendEMail("DATEPERCENT CRITICAL", "<hr/>Global::Application_Start()<hr/>Exception='" + ex.Message + "'<hr/>");
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        protected void Application_End(object sender, EventArgs e)
        {
            try
            {
                TimerHandler.Instance.Stop();

                Logger.Instance.WriteProcess("Application_End", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            try
            {
                Logger.Instance.WriteProcess("Started", System.Reflection.MethodBase.GetCurrentMethod(), string.Empty);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        protected void Session_End(object sender, EventArgs e)
        {
            try
            {
                Logger.Instance.WriteProcess("Ended", System.Reflection.MethodBase.GetCurrentMethod(), string.Empty);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
    }
}