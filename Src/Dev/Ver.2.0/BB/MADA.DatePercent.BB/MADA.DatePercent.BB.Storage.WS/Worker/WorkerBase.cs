using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MADA.Log.Api.Net;
using System.Reflection;

namespace MADA.DatePercent.BB.Storage.WS.Worker
{
    public class WorkerBase
    {
    #region Members
        protected internal Boolean m_bAvaliableToWork = true;
        #endregion
        #region Properties
        protected virtual string WorkerName
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        #endregion
        #region Class
        public WorkerBase()
        {
            Logger.Instance.WriteProcess(WorkerName + "::Init", MethodBase.GetCurrentMethod(), Environment.MachineName);
        }
        public virtual void Dispose()
        {
            Logger.Instance.WriteProcess(WorkerName + "::Disposed", MethodBase.GetCurrentMethod(), Environment.MachineName);
        }

        public virtual void DoWork(bool p_bLogWorkerName)
        {
            if (p_bLogWorkerName)
            {
                Logger.Instance.WriteProcess(WorkerName + "::DoWork", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
    }
}