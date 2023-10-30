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
using MADA.DatePercent.BB.Storage.DBS.dbStorageDB.SPs;

namespace MADA.DatePercent.BB.Storage.WS.Worker
{
    public class DatabaseFixupWorker : WorkerBase
    {
        #region Properties
        protected override string WorkerName
        {
            get
            {
                return "DatabaseFixupWorker";
            }
        }
        #endregion
        #region Class
        public DatabaseFixupWorker()
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
                Logger.Instance.WriteInformation("Started", MethodBase.GetCurrentMethod(), Environment.MachineName);

                // procPT_USERUpdateUSR_CREDITS_BALANCEByUSR_ID
                DatabaseFixupDataSet ds = new DatabaseFixupDataSet();
                procAPT_USERSelect.LoadDataSet(ds, ds.T_USER.TableName);
                foreach (DatabaseFixupDataSet.T_USERRow dr in ds.T_USER.Rows)
                {
                    procPT_USERUpdateUSR_CREDITS_BALANCEByUSR_ID.ExecuteNonQuery(dr.USR_ID);
                }

                //procPT_RMNDeleteLost.ExecuteNonQuery();
                Logger.Instance.WriteProcess("procPT_RMNDeleteLost", MethodBase.GetCurrentMethod(), Environment.MachineName);

                //procPT_USER_LINKDeleteLost.ExecuteNonQuery();
                Logger.Instance.WriteProcess("procPT_USER_LINKDeleteLost", MethodBase.GetCurrentMethod(), Environment.MachineName);

                //procPT_USER_LOCATIONUpdaet00.ExecuteNonQuery();
                Logger.Instance.WriteProcess("procPT_USER_LOCATIONUpdaet00", MethodBase.GetCurrentMethod(), Environment.MachineName);

                Logger.Instance.WriteInformation("Ended", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
    }
}