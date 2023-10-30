using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MADA.DatePercent.BB.Storage.DBS.dbStorageDB.SPs;

namespace MADA.DatePercent.BB.Storage.WS.Worker
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
                procPT_USER_LOGONIncreaseAge.ExecuteNonQuery();
                procPT_USER_LOGONDeleteAged.ExecuteNonQuery();
                procPT_USER_LOGONDeleteAged.ExecuteNonQuery();
                procPT_USER_LOCAL_MEMBERDeleteAged.ExecuteNonQuery();
                procPT_USER_LOGONSetFlagUSL_HAS_INBOX.ExecuteNonQuery();

                // breaking news
                LogonUserDataSet ds = new LogonUserDataSet();
                procPT_USER_LOGONSetFlagUSL_HAS_BREAKING_NEWSGetUsers.LoadDataSet(ds, ds.PT_USER_LOGONSetFlagUSL_HAS_BREAKING_NEWSGetUsers.TableName);
                foreach (LogonUserDataSet.PT_USER_LOGONSetFlagUSL_HAS_BREAKING_NEWSGetUsersRow dr in ds.PT_USER_LOGONSetFlagUSL_HAS_BREAKING_NEWSGetUsers.Rows)
                {
                    try
                    {
                        ds.PT_USER_LOGONSetFlagUSL_HAS_BREAKING_NEWSCheckBreakingNews.Clear();
                        procPT_USER_LOGONSetFlagUSL_HAS_BREAKING_NEWSCheckBreakingNews.LoadDataSet(ds, ds.PT_USER_LOGONSetFlagUSL_HAS_BREAKING_NEWSCheckBreakingNews.TableName,
                            dr.USL_FETCHED_LOGON_ID, dr.USR_ID, dr.USR_LAT, dr.USR_LNG, dr.USR_RADIUS_KM, dr.USR_SEX_CODE);

                        if (ds.PT_USER_LOGONSetFlagUSL_HAS_BREAKING_NEWSCheckBreakingNews[0].Counter > 0)
                        {
                            procPT_USER_LOGONSetFlagUSL_HAS_BREAKING_NEWSSetFlag.ExecuteNonQuery(dr.USL_ID);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }
        #endregion
    }
}