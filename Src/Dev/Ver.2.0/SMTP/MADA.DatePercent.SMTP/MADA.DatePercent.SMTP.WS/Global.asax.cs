using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using MADA.Log.Api.Net;
using MADA.DatePercent.SMTP.WS.Properties;

namespace MADA.DatePercent.SMTP.WS
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            try
            {
                Logger.Instance.Init("SMTP Server", Settings.Default.LogInformation, Settings.Default.LogProcess);

                Logger.Instance.WriteProcess("Started", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                Logger.Instance.WriteProcess("Application_Start", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                Logger.Instance.WriteProcess("Environment.MachineName=" + System.Environment.MachineName, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                TimerHandler.Instance.Start();

                Logger.Instance.WriteProcess("Ended", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (System.Exception ex)
            {
                MADA.Common.Net.Mail.SendEMail("CRITICAL MADA.DatePercent.SMTP.WS", "<hr/>Global::Application_Start()<hr/>Exception='" + ex.Message + "'<hr/>");
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        protected void Application_End(object sender, EventArgs e)
        {
            try
            {
                TimerHandler.Instance.Dispose();

                Logger.Instance.WriteProcess("Application_End", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
    }
}