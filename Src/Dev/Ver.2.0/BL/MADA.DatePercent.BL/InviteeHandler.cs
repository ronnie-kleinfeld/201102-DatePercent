using System;
using System.Collections.Generic;
using System.Text;
using MADA.DatePercent.DBS.dbDatePercentDB.SPs;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using MADA.DatePercent.DBS.dbDatePercentDB.Tables;
using MADA.Log.Api.Net;

namespace MADA.DatePercent.BL
{
    public class InviteeHandler
    {
        public static string Invite(
            string p_strUSI_EMAIL, string p_strUSI_INVITER_USER_UID, int p_iUSI_INVITER_USER_ID, string p_strUSI_NAME,
            T_USER_INVITEE_TYPE_ENUM p_enmUSI_USER_INVITEE_TYPE,
            Database p_db, DbTransaction p_trn)
        {
            try
            {
                object oUDI_ID;
                procPT_USER_INVITEEInsertInto.ExecuteNonQuery(
                    p_strUSI_EMAIL, null, p_iUSI_INVITER_USER_ID, p_strUSI_INVITER_USER_UID, p_strUSI_NAME,
                    (int)p_enmUSI_USER_INVITEE_TYPE,
                    out oUDI_ID,
                    p_db, p_trn);

                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                throw;
            }
        }
        public static string Invite(
            string p_strUSI_EMAIL, string p_strUSI_INVITER_USER_UID, int p_iUSI_INVITER_USER_ID, string p_strUSI_NAME,
            T_USER_INVITEE_TYPE_ENUM p_enmUSI_USER_INVITEE_TYPE)
        {
            try
            {
                object oUDI_ID;
                procPT_USER_INVITEEInsertInto.ExecuteNonQuery(
                    p_strUSI_EMAIL, null, p_iUSI_INVITER_USER_ID, p_strUSI_INVITER_USER_UID, p_strUSI_NAME,
                    (int)p_enmUSI_USER_INVITEE_TYPE,
                    out oUDI_ID);

                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                throw;
            }
        }
    }
}