using System;
using System.Collections.Generic;
using System.Text;
using MADA.Log.Api.Net;
using MADA.DatePercent.DBS.dbDatePercentDB.SPs;

namespace MADA.DatePercent.Worker
{
    public class GeniusWorker : WorkerDBBase
    {
        #region Const
        private const int INTERVAL_HOUR = 24;
        private const int DETAILS_PER_MAIL = 1;
        #endregion
        #region Properties
        protected override string WorkerName
        {
            get
            {
                return "GeniusWorker";
            }
        }
        #endregion
        #region Class
        public GeniusWorker()
            : base()
        {
            Logger.Instance.WriteInformation("Started", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);


            Logger.Instance.WriteInformation("Ended", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
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

                try
                {
                    Logger.Instance.WriteInformation("Started", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                    GeniusDataSet ds = new GeniusDataSet();
                    object oUGL_ID;

                    procPT_USER_SETTINGSelectGeniusDueGetDate.LoadDataSet(ds, ds.PT_USER_SETTINGSelect50DueGetDate.TableName);
                    foreach (GeniusDataSet.PT_USER_SETTINGSelect50DueGetDateRow drUser in ds.PT_USER_SETTINGSelect50DueGetDate.Rows)
                    {
                        Logger.Instance.Write(drUser, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                        ds.PT_USER_SETTINGSelect50DueGetDate.Clear();
                        procPT_USERSelectGeniusLinked.LoadDataSet(ds, ds.PT_USERSelectGeniusLinked.TableName, DETAILS_PER_MAIL, drUser.USS_USER_ID);
                        Logger.Instance.Write(ds.PT_USER_SETTINGSelect50DueGetDate, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                        foreach (GeniusDataSet.PT_USER_SETTINGSelect50DueGetDateRow drDetails in ds.PT_USER_SETTINGSelect50DueGetDate.Rows)
                        {
                            //  compose email box



                            procAPT_USER_GENIUS_LINKInsertInto.ExecuteNonQuery(drDetails.USS_USER_ID, null, drUser.USS_USER_ID, out oUGL_ID);
                        }

                        procPT_USER_SETTINGInsertIntoUpdateGeniusByUSS_USER_IDInterval.ExecuteNonQuery(INTERVAL_HOUR, drUser.USS_USER_ID);

                        Logger.Instance.WriteInformation("User Ended:" + drUser.USS_USER_ID, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }
                    
                    Logger.Instance.WriteInformation("Ended", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
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