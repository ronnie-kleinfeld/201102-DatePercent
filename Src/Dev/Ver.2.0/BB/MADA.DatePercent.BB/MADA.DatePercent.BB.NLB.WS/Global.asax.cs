using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using MADA.DatePercent.BB.NLB.WS.Properties;
using MADA.Log.Api.Net;
using MADA.DatePercent.SMTP.Api.Net;
using System.Reflection;

namespace MADA.DatePercent.BB.NLB.WS
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            try
            {
                Logger.Instance.Init("NLB Server", Settings.Default.LogInformation, Settings.Default.LogProcess);

                Logger.Instance.WriteProcess("Application_Start", MethodBase.GetCurrentMethod(), Environment.MachineName);
                Logger.Instance.WriteProcess("Environment.MachineName=" + System.Environment.MachineName, MethodBase.GetCurrentMethod(), Environment.MachineName);

                ApplicationHandler.Instance.Refresh();

                Logger.Instance.WriteProcess("Ended", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (System.Exception ex)
            {
                Mailer.Instance.Compose(Environment.MachineName, Environment.MachineName, "rk@datepercent.com", Environment.MachineName, "CRITICAL MADA.DatePercent.NLB.Web", "<hr/>Global::Application_Start()<hr/>Exception='" + ex.Message + "'<hr/>");
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        protected void Application_End(object sender, EventArgs e)
        {
            try
            {
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
                Logger.Instance.WriteProcess("Session_Start", MethodBase.GetCurrentMethod(), Environment.MachineName);

                ApplicationHandler.Instance.IncreaseSession();
            }
            catch (System.Exception ex)
            {
                Mailer.Instance.Compose(Environment.MachineName, Environment.MachineName, "rk@datepercent.com", Environment.MachineName, "CRITICAL MADA.DatePercent.NLB.Web", "<hr/>Global::Application_Start()<hr/>Exception='" + ex.Message + "'<hr/>");
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        protected void Session_End(object sender, EventArgs e)
        {
            try
            {
                ApplicationHandler.Instance.DecreaseSession();

                Logger.Instance.WriteProcess("Application_End", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
    }
}