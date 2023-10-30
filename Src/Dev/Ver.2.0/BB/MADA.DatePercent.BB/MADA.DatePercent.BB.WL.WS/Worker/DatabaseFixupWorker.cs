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
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.SPs;
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.Tables;
using System.Reflection;

namespace MADA.DatePercent.BB.WL.WS.Worker
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

                procPT_RMNDeleteLost.ExecuteNonQuery();
                Logger.Instance.WriteProcess("procPT_RMNDeleteLost", MethodBase.GetCurrentMethod(), Environment.MachineName);

                procPT_USER_LINKDeleteLost.ExecuteNonQuery();
                Logger.Instance.WriteProcess("procPT_USER_LINKDeleteLost", MethodBase.GetCurrentMethod(), Environment.MachineName);

                procPT_USER_PHOTODeleteWhereUPH_IO_ERRORIsTrue.ExecuteNonQuery();
                Logger.Instance.WriteProcess("procPT_USER_PHOTODeleteWhereUPH_IO_ERRORIsTrue", MethodBase.GetCurrentMethod(), Environment.MachineName);

                procPT_USER_LOCATIONUpdaet00.ExecuteNonQuery();
                Logger.Instance.WriteProcess("procPT_USER_LOCATIONUpdaet00", MethodBase.GetCurrentMethod(), Environment.MachineName);

                procPT_USER_SETTINGCreateDefaultUSS_BIT.ExecuteNonQuery(true, (int)T_USER_SETTING_TYPE_ENUM.DoNotShowLocationChangedPopBox);
                procPT_USER_SETTINGCreateDefaultUSS_INT.ExecuteNonQuery(1, (int)T_USER_SETTING_TYPE_ENUM.CultureDateFormat);
                procPT_USER_SETTINGCreateDefaultUSS_INT.ExecuteNonQuery(1, (int)T_USER_SETTING_TYPE_ENUM.DistanceUnits);
                procPT_USER_SETTINGCreateDefaultUSS_INT.ExecuteNonQuery(10, (int)T_USER_SETTING_TYPE_ENUM.ResultsCount);
                procPT_USER_SETTINGCreateDefaultUSS_INT.ExecuteNonQuery(1, (int)T_USER_SETTING_TYPE_ENUM.VisibilityCode);
                procPT_USER_SETTINGCreateDefaultUSS_DATETIME.ExecuteNonQuery(System.DateTime.Now, (int)T_USER_SETTING_TYPE_ENUM.NextGenius);
                procPT_USER_SETTINGCreateDefaultUSS_BIT.ExecuteNonQuery(false, (int)T_USER_SETTING_TYPE_ENUM.UserOkedSharedPopBox);
                procPT_USER_SETTINGCreateDefaultUSS_BIT.ExecuteNonQuery(false, (int)T_USER_SETTING_TYPE_ENUM.UserOkedLocationPopBox);
                Logger.Instance.WriteProcess("procPT_USER_SETTINGCreateDefaultUSS_***", MethodBase.GetCurrentMethod(), Environment.MachineName);

                procPT_USER_SETTINGInsertNewGeniusInterval.ExecuteNonQuery();
                Logger.Instance.WriteProcess("procPT_USER_SETTINGInsertNewGeniusInterval", MethodBase.GetCurrentMethod(), Environment.MachineName);

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