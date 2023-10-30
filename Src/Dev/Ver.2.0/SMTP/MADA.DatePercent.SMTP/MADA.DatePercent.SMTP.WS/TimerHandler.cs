using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Timers;
using MADA.Log.Api.Net;

namespace MADA.DatePercent.SMTP.WS
{
    public class TimerHandler
    {
        #region Singleton
        private static TimerHandler m_instance;

        public static TimerHandler Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new TimerHandler();
                }

                return m_instance;
            }
        }
        #endregion
        #region Members
        private Timer m_timer;

        private MailSenderWorker m_mailSenderWorker;
        #endregion
        #region Class
        private TimerHandler()
        {
            try
            {
                m_timer = new Timer(Properties.Settings.Default.TimerInterval);
                m_timer.Elapsed += new ElapsedEventHandler(m_timer_Elapsed);

                Logger.Instance.WriteProcess("TimerHandler Init", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        public void Dispose()
        {
            try
            {
                m_timer.Stop();
                m_timer = null;

                Logger.Instance.WriteProcess("TimerHandler Disposed", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
        #region Methods
        public void Start()
        {
            try
            {
                m_mailSenderWorker = new MailSenderWorker();

                DoTimer();
                m_timer.Enabled = true;

                Logger.Instance.WriteProcess("TimerHandler Started", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        public void Stop()
        {
            try
            {
                m_timer.Enabled = false;

                m_mailSenderWorker.Dispose();
                m_mailSenderWorker = null;

                Logger.Instance.WriteProcess("TimerHandler Stoped", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        public void DoTimer()
        {
            try
            {
                m_mailSenderWorker.DoWork();
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
        #region Events
        private void m_timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                DoTimer();
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
    }
}