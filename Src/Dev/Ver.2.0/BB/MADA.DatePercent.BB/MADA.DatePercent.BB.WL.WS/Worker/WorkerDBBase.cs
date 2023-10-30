using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using MADA.Log.Api.Net;
using System.Reflection;

namespace MADA.DatePercent.BB.WL.WS.Worker
{
    public class WorkerDBBase : WorkerBase
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

                Logger.Instance.WriteProcess(WorkerName + "::StartDB", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
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

                Logger.Instance.WriteProcess(WorkerName + "::StopDB", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        protected internal void RestartDB()
        {
            try
            {
                StopDB();
                StartDB();

                Logger.Instance.WriteCritical(WorkerName + "::RestartDB", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
    }
}