using System;
using System.Collections.Generic;
using System.Text;
using MADA.DatePercent.DBS.dbDatePercentDB.Tables;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using MADA.DatePercent.DBS.dbDatePercentDB.SPs;
using MADA.Log.Api.Net;

namespace MADA.DatePercent.BL
{
    public class CommHandler
    {
        public static string SendRMN(T_RMN_TYPE_ENUM p_enmRMN_RMT_TYPE, int p_iSessionID, int p_iDetailsID, string p_strRMN_TEXT, DateTime p_dtRMN_SENT_DATETIME, Database p_db, DbTransaction p_trn)
        {
            try
            {
                object oRMN_ID;

                if (p_db == null)
                {
                    procPT_RMNInsertInto.ExecuteNonQuery(p_iDetailsID, null, (int)p_enmRMN_RMT_TYPE, p_dtRMN_SENT_DATETIME, p_strRMN_TEXT, p_iSessionID, out oRMN_ID);
                }
                else
                {
                    procPT_RMNInsertInto.ExecuteNonQuery(p_iDetailsID, null, (int)p_enmRMN_RMT_TYPE, p_dtRMN_SENT_DATETIME, p_strRMN_TEXT, p_iSessionID, out oRMN_ID, p_db, p_trn);
                }
                if (oRMN_ID == null)
                {
                    Logger.Instance.WriteInformation("failed to insert new T_RMN", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                    return BE.ResultCode.ERR_RMN_FAILED_TO_INSERT_NEW_T_RMN;
                }
                else
                {
                    Logger.Instance.WriteInformation("RMN added to T_RMN:" + oRMN_ID, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                }

                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
        }
    }
}