using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using MADA.Log.Api.Net;

namespace MADA.DatePercent.Worker
{
    public abstract class WorkerBase
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
            Logger.Instance.WriteProcess(WorkerName + "::Init", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
        }
        public virtual void Dispose()
        {
            Logger.Instance.WriteProcess(WorkerName + "::Disposed", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
        }

        public virtual void DoWork(bool p_bLogWorkerName)
        {
            if (p_bLogWorkerName)
            {
                Logger.Instance.WriteProcess(WorkerName + "::DoWork", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
    }
}