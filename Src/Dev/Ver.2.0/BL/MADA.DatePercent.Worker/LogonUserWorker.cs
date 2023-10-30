using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using MADA.DatePercent.BL;
using MADA.DatePercent.DBS.dbDatePercentDB.SPs;
using MADA.DatePercent.DBS.dbDatePercentDB.Tables;

namespace MADA.DatePercent.Worker
{
    public class LogonUserWorker : WorkerBase
    {
        #region Properties
        protected override string WorkerName
        {
            get
            {
                return "LogonUserWorker";
            }
        }
        #endregion
        #region Class
        public LogonUserWorker()
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

            try
            {
                procPT_LOGONUpdateIncreaseAge.ExecuteNonQuery();
                procPT_LOGONDeleteAged.ExecuteNonQuery();
                procPT_LOGONUpdateRMNCounters.ExecuteNonQuery();
            }
            catch
            {
            }
        }
        #endregion
    }
}