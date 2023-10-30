using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using MADA.Log.Api.Net;

namespace MADA.DatePercent.Worker
{
    public abstract class WorkerDBBase : WorkerBase
    {
        #region Members
        protected internal Database m_db;
        protected internal DbConnection m_con;
        protected internal DbConnection m_trn;
        #endregion
        #region Class
        public WorkerDBBase()
            : base()
        {
            StartDB();
        }
        public override void Dispose()
        {
            base.Dispose();

            StopDB();
        }
        #endregion
        #region Methods
        protected internal void StartDB()
        {
            try
            {
                m_db = DatabaseFactory.CreateDatabase();
                m_con = m_db.CreateConnection();
                m_con.Open();

                Logger.Instance.WriteProcess(WorkerName + "::StartDB", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        protected internal void StopDB()
        {
            try
            {
                if (m_con != null && m_con.State == System.Data.ConnectionState.Open)
                {
                    m_con.Close();
                    m_con = null;
                }
                m_db = null;

                Logger.Instance.WriteProcess(WorkerName + "::StopDB", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        protected internal void RestartDB()
        {
            try
            {
                StopDB();
                StartDB();

                Logger.Instance.WriteCritical(WorkerName + "::RestartDB", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
    }
}