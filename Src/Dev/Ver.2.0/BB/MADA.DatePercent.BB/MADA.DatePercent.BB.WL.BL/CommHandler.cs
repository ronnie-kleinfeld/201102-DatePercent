using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using MADA.Log.Api.Net;
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.SPs;
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.Tables;
using System.Reflection;

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
                    Logger.Instance.WriteInformation("failed to insert new T_RMN", MethodBase.GetCurrentMethod(), Environment.MachineName);
                    return MADA.DatePercent.BB.WL.BE.ResultCode.ERR_RMN_FAILED_TO_INSERT_NEW_T_RMN;
                }
                else
                {
                    Logger.Instance.WriteInformation("RMN added to T_RMN:" + oRMN_ID, MethodBase.GetCurrentMethod(), Environment.MachineName);
                }

                return MADA.DatePercent.BB.WL.BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                return MADA.DatePercent.BB.WL.BE.ResultCode.FAILED;
            }
        }
    }
}