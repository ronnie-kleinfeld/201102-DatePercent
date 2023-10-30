using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.SPs;

namespace MADA.DatePercent.BB.WL.WS.Worker
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