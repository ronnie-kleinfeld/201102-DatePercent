using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using MADA.DatePercent.BL;
using MADA.DatePercent.DBS.dbDatePercentDB.SPs;
using MADA.DatePercent.DBS.dbDatePercentDB.Tables;
using System.Data;
using MADA.Log.Api.Net;

namespace MADA.DatePercent.Worker
{
    public class RMNEMailNotifierWorker : WorkerDBBase
    {
        #region Const
        /// <summary>
        /// rmn are stored in the database till the member read them in the details.communication box. if the member didn't read for the CONST an email will be sent to the member
        /// </summary>
        private const int UNREAD_TIME_OUT_MINUTES = 1440;
        #endregion
        #region Properties
        protected override string WorkerName
        {
            get
            {
                return "RMNEMailNotifierWorker";
            }
        }
        #endregion
        #region Class
        public RMNEMailNotifierWorker()
            : base()
        {
        }
        public override void Dispose()
        {
            base.Dispose();
        }
        #endregion
        #region Methods
        public override void DoWork(bool p_bLogWorkerName)
        {
            base.DoWork(p_bLogWorkerName);

            if (m_bAvaliableToWork)
            {
                m_bAvaliableToWork = false;

                Logger.Instance.WriteInformation("Started", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                DbTransaction trn = m_con.BeginTransaction();
                Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                try
                {
                    RMNEMailNotifierDataSet ds = new RMNEMailNotifierDataSet();
                    procPT_RMNSelectCommunicateToNotifyByRMN_SENT_DATETIME.LoadDataSet(ds, ds.T_RMN.TableName, DateTime.Now.AddMinutes(-UNREAD_TIME_OUT_MINUTES), m_db, trn);

                    Logger.Instance.WriteInformation("RMN started", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                    foreach (RMNEMailNotifierDataSet.T_RMNRow drRMN in ds.T_RMN.Rows)
                    {
                        Logger.Instance.Write(drRMN, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                        EMailHandler.ComposeEmailBox(Environment.MachineName, (T_EMAIL_BOX_TYPE_ENUM)drRMN.RMN_RMT_TYPE, drRMN.RMN_SENDER_USER_ID,
                            drRMN.RMN_GETTER_USER_ID, drRMN.RMN_TEXT, string.Empty, -1, m_db, trn);
                        Logger.Instance.WriteInformation("ComposeEmailBox", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                        procPT_RMNUpdateRMN_GETTER_EMAILEDToTrueByRMN_ID.ExecuteNonQuery(drRMN.RMN_ID, m_db, trn);
                        Logger.Instance.WriteInformation("Update to true", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }
                    Logger.Instance.WriteInformation("RMN ended", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                    if (ds.T_RMN.Rows.Count == 0)
                    {
                        Logger.Instance.WriteInformation("No RMN to pack", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }
                    else
                    {
                        Logger.Instance.WriteProcess("Packed " + ds.T_RMN.Rows.Count + " RMNs", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }

                    trn.Commit();
                    Logger.Instance.WriteCommitTrn(System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                    Logger.Instance.WriteInformation("Ended", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteRollbackTrn(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                    trn.Rollback();
                    RestartDB();
                }
                finally
                {
                    m_bAvaliableToWork = true;
                }
            }
        }
        #endregion
    }
}