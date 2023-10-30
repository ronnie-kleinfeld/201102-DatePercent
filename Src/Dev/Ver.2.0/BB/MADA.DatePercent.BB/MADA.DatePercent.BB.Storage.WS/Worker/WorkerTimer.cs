using System;
using System.Timers;
using MADA.Log.Api.Net;
using System.Reflection;

namespace MADA.DatePercent.BB.Storage.WS.Worker
{
    public class WorkerTimer
    {
        #region Singleton
        private static WorkerTimer m_instance;

        public static WorkerTimer Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new WorkerTimer();
                }

                return m_instance;
            }
        }
        #endregion
        #region Members
        private Timer m_timer10Second;
        private Timer m_timerMinute;
        private Timer m_timerHour;

        private LogonUserWorker m_logonUserWorker;
        private DatabaseFixupWorker m_databaseFixupWorker;
        #endregion
        #region Class
        private WorkerTimer()
        {
            try
            {
                m_timer10Second = new Timer(10000);
                m_timer10Second.Elapsed += new ElapsedEventHandler(m_timer10Second_Elapsed);

                m_timerMinute = new Timer(60000);
                m_timerMinute.Elapsed += new ElapsedEventHandler(m_timerMinute_Elapsed);

                m_timerHour = new Timer(3600000);
                m_timerHour.Elapsed += new ElapsedEventHandler(m_timerHour_Elapsed);

                Logger.Instance.WriteProcess("TimerHandler Init", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
        #region Methods
        public void Start()
        {
            try
            {
                m_logonUserWorker = new LogonUserWorker();
                m_databaseFixupWorker = new DatabaseFixupWorker();

                DoEvery10Seconds();
                DoEveryMinute();
                DoEveryHour();

                m_timer10Second.Enabled = true;
                m_timerMinute.Enabled = true;
                m_timerHour.Enabled = true;

                Logger.Instance.WriteProcess("TimerHandler Started", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        public void Stop()
        {
            try
            {
                m_timerHour.Enabled = false;
                m_timerMinute.Enabled = false;
                m_timer10Second.Enabled = false;

                m_databaseFixupWorker.Dispose();
                m_databaseFixupWorker = null;

                m_logonUserWorker.Dispose();
                m_logonUserWorker = null;

                Logger.Instance.WriteProcess("TimerHandler Stoped", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        public void DoEvery10Seconds()
        {
            try
            {
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        public void DoEveryMinute()
        {
            try
            {
                m_logonUserWorker.DoWork(false);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        public void DoEveryHour()
        {
            try
            {
                m_databaseFixupWorker.DoWork(true);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
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
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
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
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
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
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
    }
}