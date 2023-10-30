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
using System.Data.Common;
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.SPs;
using MADA.DatePercent.BB.WL.BL;
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.Tables;
using System.Reflection;

namespace MADA.DatePercent.BB.WL.WS.Worker
{
    public class InviteeWorker : WorkerDBBase
    {
        #region Properties
        protected override string WorkerName
        {
            get
            {
                return "InviteeWorker";
            }
        }
        #endregion
        #region Const
        public const int EMAIL_SENDING_INTERVAL_HOURS = 24 * 7;
        #endregion
        #region Class
        public InviteeWorker()
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

            if (m_bAvaliableToWork)
            {
                m_bAvaliableToWork = false;

                Logger.Instance.WriteInformation("Started", MethodBase.GetCurrentMethod(), Environment.MachineName);

                DbTransaction trn = m_con.BeginTransaction();
                Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                try
                {
                    DateTime dtCurrent = DateTime.Now;
                    DateTime dtLimitByInterval = dtCurrent.AddHours(-EMAIL_SENDING_INTERVAL_HOURS);

                    // update USI_INVITER_USER_ID for invitees that where added in gmail AutoSub web page
                    procPT_USER_INVITEEUpdateUSI_INVITER_USER_ID.ExecuteNonQuery(m_db, trn);
                    Logger.Instance.WriteInformation("GMail AuthSub updated", MethodBase.GetCurrentMethod(), Environment.MachineName);

                    InviteeDataSet dsInvitee = new InviteeDataSet();
                    procPT_USER_INVITEEProcessInvitees.LoadDataSet(dsInvitee, dsInvitee.T_USER_INVITEE.TableName, dtLimitByInterval, m_db, trn);
                    Logger.Instance.WriteInformation("ProcessInvitees done", MethodBase.GetCurrentMethod(), Environment.MachineName);

                    // added, not in T_USER_EMAIL / T_USER_INVITEE - compose invitee email
                    Logger.Instance.WriteInformation("Added invitees started", MethodBase.GetCurrentMethod(), Environment.MachineName);
                    foreach (InviteeDataSet.T_USER_INVITEERow drInvitee in dsInvitee.T_USER_INVITEE.Rows)
                    {
                        Logger.Instance.Write(drInvitee, MethodBase.GetCurrentMethod(), Environment.MachineName);

                        Logger.Instance.WriteInformation("ComposeEmailBoxInvitee:" + drInvitee.USI_ID, MethodBase.GetCurrentMethod(), Environment.MachineName);
                        EMailHandler.ComposeEmailBoxInvitee(T_EMAIL_BOX_TYPE_ENUM.Invite, drInvitee.USI_ID, m_db, trn);
                    }
                    Logger.Instance.WriteInformation("Added invitees ended", MethodBase.GetCurrentMethod(), Environment.MachineName);

                    if (dsInvitee.T_USER_INVITEE.Rows.Count == 0)
                    {
                        Logger.Instance.WriteInformation("No added invitees to invite", MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }
                    else
                    {
                        Logger.Instance.WriteProcess("Invited " + dsInvitee.T_USER_INVITEE.Rows.Count + " added invitees", MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }

                    trn.Commit();
                    Logger.Instance.WriteCommitTrn(System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                    Logger.Instance.WriteInformation("Ended", MethodBase.GetCurrentMethod(), Environment.MachineName);
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                    trn.Rollback();
                    RestartDB();
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