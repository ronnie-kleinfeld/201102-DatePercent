using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using MADA.DatePercent.BL;
using MADA.DatePercent.Worker;
using MADA.Log.Api.Net;

namespace MADA.DatePercent.Worker
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
        private Timer m_timer10Second;
        private Timer m_timerMinute;
        private Timer m_timerHour;

        private MailComposerWorker m_mailComposerWorker;
        private MailSenderWorker m_mailSenderWorker;
        private InviteeWorker m_inviteeWorker;
        private LogonUserWorker m_logonUserWorker;
        private DatabaseFixupWorker m_databaseFixupWorker;
        private ContactFetcherWorker m_contactFetcherWorker;
        private RMNEMailNotifierWorker m_rmnEMailNotifierWorker;
        private GeniusWorker m_geniusWorker;
        #endregion
        #region Class
        private TimerHandler()
        {
            try
            {
                m_timer10Second = new Timer(10000);
                m_timer10Second.Elapsed += new ElapsedEventHandler(m_timer10Second_Elapsed);

                m_timerMinute = new Timer(60000);
                m_timerMinute.Elapsed += new ElapsedEventHandler(m_timerMinute_Elapsed);

                m_timerHour = new Timer(3600000);
                m_timerHour.Elapsed += new ElapsedEventHandler(m_timerHour_Elapsed);

                Logger.Instance.WriteProcess("TimerHandler Init", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
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
                m_mailComposerWorker = new MailComposerWorker();
                m_mailSenderWorker = new MailSenderWorker();
                m_inviteeWorker = new InviteeWorker();
                m_logonUserWorker = new LogonUserWorker();
                m_databaseFixupWorker = new DatabaseFixupWorker();
                m_contactFetcherWorker = new ContactFetcherWorker();
                m_rmnEMailNotifierWorker = new RMNEMailNotifierWorker();
                m_geniusWorker = new GeniusWorker();

                DoEvery10Seconds();
                DoEveryMinute();
                DoEveryHour();

                m_timer10Second.Enabled = true;
                m_timerMinute.Enabled = true;
                m_timerHour.Enabled = true;

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
                m_timerHour.Enabled = false;
                m_timerMinute.Enabled = false;
                m_timer10Second.Enabled = false;

                m_geniusWorker.Dispose();
                m_geniusWorker = null;

                m_rmnEMailNotifierWorker.Dispose();
                m_rmnEMailNotifierWorker = null;

                m_databaseFixupWorker.Dispose();
                m_databaseFixupWorker = null;

                m_inviteeWorker.Dispose();
                m_inviteeWorker = null;

                m_logonUserWorker.Dispose();
                m_logonUserWorker = null;

                m_mailSenderWorker.Dispose();
                m_mailSenderWorker = null;

                m_mailComposerWorker.Dispose();
                m_mailComposerWorker = null;

                m_contactFetcherWorker.Dispose();
                m_contactFetcherWorker = null;

                Logger.Instance.WriteProcess("TimerHandler Stoped", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        public void DoEvery10Seconds()
        {
            try
            {
                m_logonUserWorker.DoWork(false);
                m_contactFetcherWorker.DoWork(false);
                m_mailComposerWorker.DoWork(false);
                m_mailSenderWorker.DoWork(false);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        public void DoEveryMinute()
        {
            try
            {
                m_inviteeWorker.DoWork(true);
                //m_activationWorker.DoWork(true);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        public void DoEveryHour()
        {
            try
            {
                //m_geniusWorker.DoWork(true);
                m_rmnEMailNotifierWorker.DoWork(true);
                //m_profileUpdatedWorker.DoWork(true);
                m_databaseFixupWorker.DoWork(true);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
        #region Events
        private void m_timer10Second_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                DoEvery10Seconds();
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        private void m_timerMinute_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                DoEveryMinute();
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        private void m_timerHour_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                DoEveryHour();
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
    }
}