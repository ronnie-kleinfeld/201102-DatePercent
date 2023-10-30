using MADA.Log.Api.Net;
using System;
using MADA.DatePercent.SMTP.Api.Net;
using System.Reflection;
namespace MADA.DatePercent.BB.BL.WS
{
    partial class ApplicationHandler
    {
        #region Singleton
        private static ApplicationHandler s_dsInstance;
        public static ApplicationHandler Instance
        {
            get
            {
                if (s_dsInstance == null)
                {
                    s_dsInstance = new ApplicationHandler();
                    s_dsInstance.Init();
                }

                return s_dsInstance;
            }
        }
        public static bool Exists
        {
            get
            {
                if (s_dsInstance == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        #endregion
        #region Methods
        private void Init()
        {
            try
            {
                Logger.Instance.WriteProcess("Started", MethodBase.GetCurrentMethod(), Environment.MachineName);



                Logger.Instance.WriteProcess("Ended", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Mailer.Instance.Compose(Environment.MachineName, Environment.MachineName, "rk@datepercent.com", Environment.MachineName, "DATEPERCENT CRITICAL",
                    "<hr/>MADA.DatePercent.BL::ApplicationHandler::Init()<hr/>Failed to connect to the database through Microsoft DataApplicationBlock<hr/>web.config is missing or set to localhost?<hr/>Exception='" + ex.Message + "'<hr/>");
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        public void Refresh()
        {
            try
            {
                Logger.Instance.WriteProcess("Started", MethodBase.GetCurrentMethod(), Environment.MachineName);



                Logger.Instance.WriteProcess("Ended", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
    }
}