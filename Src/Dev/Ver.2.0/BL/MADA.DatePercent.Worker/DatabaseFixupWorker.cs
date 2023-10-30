using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using MADA.DatePercent.BL;
using MADA.DatePercent.DBS.dbDatePercentDB.SPs;
using MADA.DatePercent.DBS.dbDatePercentDB.Tables;
using MADA.Log.Api.Net;

namespace MADA.DatePercent.Worker
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
                Logger.Instance.WriteInformation("Started", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                procPT_RMNDeleteLost.ExecuteNonQuery();
                Logger.Instance.WriteProcess("procPT_RMNDeleteLost", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                
                procPT_USER_LINKDeleteLost.ExecuteNonQuery();
                Logger.Instance.WriteProcess("procPT_USER_LINKDeleteLost", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                
                procPT_USER_PHOTODeleteWhereUPH_IO_ERRORIsTrue.ExecuteNonQuery();
                Logger.Instance.WriteProcess("procPT_USER_PHOTODeleteWhereUPH_IO_ERRORIsTrue", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                
                procPT_USER_LOCATIONUpdaet00.ExecuteNonQuery();
                Logger.Instance.WriteProcess("procPT_USER_LOCATIONUpdaet00", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                procPT_USER_SETTINGCreateDefaultUSS_BIT.ExecuteNonQuery(true, (int)T_USER_SETTING_TYPE_ENUM.DoNotShowLocationChangedPopBox);
                procPT_USER_SETTINGCreateDefaultUSS_INT.ExecuteNonQuery(1, (int)T_USER_SETTING_TYPE_ENUM.CultureDateFormat);
                procPT_USER_SETTINGCreateDefaultUSS_INT.ExecuteNonQuery(1, (int)T_USER_SETTING_TYPE_ENUM.DistanceUnits);
                procPT_USER_SETTINGCreateDefaultUSS_INT.ExecuteNonQuery(10, (int)T_USER_SETTING_TYPE_ENUM.ResultsCount);
                procPT_USER_SETTINGCreateDefaultUSS_INT.ExecuteNonQuery(1, (int)T_USER_SETTING_TYPE_ENUM.VisibilityCode);
                procPT_USER_SETTINGCreateDefaultUSS_DATETIME.ExecuteNonQuery(System.DateTime.Now, (int)T_USER_SETTING_TYPE_ENUM.NextGenius);
                procPT_USER_SETTINGCreateDefaultUSS_BIT.ExecuteNonQuery(false, (int)T_USER_SETTING_TYPE_ENUM.UserOkedSharedPopBox);
                procPT_USER_SETTINGCreateDefaultUSS_BIT.ExecuteNonQuery(false, (int)T_USER_SETTING_TYPE_ENUM.UserOkedLocationPopBox);
                Logger.Instance.WriteProcess("procPT_USER_SETTINGCreateDefaultUSS_***", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                procPT_USER_SETTINGInsertNewGeniusInterval.ExecuteNonQuery();
                Logger.Instance.WriteProcess("procPT_USER_SETTINGInsertNewGeniusInterval", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                Logger.Instance.WriteInformation("Ended", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
    }
}