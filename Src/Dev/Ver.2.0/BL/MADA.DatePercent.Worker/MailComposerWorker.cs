using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Timers;
using MADA.DatePercent.BL;
using MADA.DatePercent.DBS.dbDatePercentDB.Tables;
using MADA.DatePercent.BE;
using MADA.DatePercent.DBS.dbDatePercentDB.SPs;
using System.Data;
using MADA.Log.Api.Net;

namespace MADA.DatePercent.Worker
{
    public class MailComposerWorker : WorkerDBBase
    {
        #region Members
        private string m_strBody;
        #endregion
        #region Properties
        protected override string WorkerName
        {
            get
            {
                return "MailComposerWorker";
            }
        }
        #endregion
        #region Class
        public MailComposerWorker()
            : base()
        {
            Logger.Instance.WriteInformation("Started", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

            m_strBody = Constants.EMailWrapperHtml;
            m_strBody = m_strBody.Replace("<%UIResLogo36x36Url%>", Constants.UIResLogo36x36Url);
            m_strBody = m_strBody.Replace("<%UIRedirectToAppUrl%>", Constants.UIRedirectToAppUrl);
            m_strBody = m_strBody.Replace("<%UIRegistrationUnsubscribeUrl%>", Constants.UIRegistrationUnsubscribeUrl);
            m_strBody = m_strBody.Replace("<%UNSUBSCRIBE_UID_URL_KEY%>", Constants.UNSUBSCRIBE_UID_URL_KEY);
            m_strBody = m_strBody.Replace("<%EMAIL_URL_KEY%>", Constants.EMAIL_URL_KEY);

            Logger.Instance.WriteProcess("EMailWrapperHtml init:" + m_strBody, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

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
                    MailComposerDataSet ds = new MailComposerDataSet();
                    procPT_EMAIL_BOXSelectLtEMB_PUBLISH_DATETIME.LoadDataSet(ds, ds.T_EMAIL_BOX.TableName, DateTime.Now);

                    Logger.Instance.WriteInformation("Started", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                    while (ds.T_EMAIL_BOX.Rows.Count > 0)
                    {
                        MailComposerDataSet.T_EMAIL_BOXRow drMailBox;
                        DataView dv;
                        string strGetterUid;
                        string strGetterEMail;
                        string strGetterName;
                        string strSubject;
                        string strBody;
                        StringBuilder sbDivs = null;

                        DbTransaction trn = null;

                        try
                        {
                            trn = m_con.BeginTransaction();
                            Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                            drMailBox = ds.T_EMAIL_BOX[0];
                            Logger.Instance.Write(drMailBox, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                            strGetterUid = drMailBox.EMB_GETTER_USER_UID.ToString();
                            strGetterEMail = drMailBox.EMB_GETTER_EMAIL;
                            strGetterName = drMailBox.EMB_GETTER_NAME;
                            Logger.Instance.WriteInformation("strGetterUid:" + strGetterUid, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                            Logger.Instance.WriteInformation("strGetterEMail:" + strGetterEMail, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                            Logger.Instance.WriteInformation("strGetterName:" + strGetterName, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                            dv = new DataView(ds.T_EMAIL_BOX);
                            dv.RowFilter = tblT_EMAIL_BOX.colEMB_GETTER_EMAIL._Name + "='" + strGetterEMail + "'";
                            Logger.Instance.WriteInformation("dv count:" + dv.Count, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                            strSubject = string.Empty;

                            strBody = m_strBody;
                            strBody = strBody.Replace("<%EMB_GETTER_EMAIL%>", strGetterEMail);
                            strBody = strBody.Replace("<%UNSUBSCRIBE_UID_URL_VALUE%>", strGetterUid);

                            sbDivs = new StringBuilder();

                            Logger.Instance.WriteInformation("dv started", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                            for (int i = 0; i < dv.Count; i++)
                            {
                                drMailBox = (MailComposerDataSet.T_EMAIL_BOXRow)dv[i].Row;
                                Logger.Instance.Write(drMailBox, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                                if (strSubject == string.Empty)
                                {
                                    strSubject = strGetterName + ", " + drMailBox.EMB_SUBJECT;
                                }
                                else if (strSubject != drMailBox.EMB_SUBJECT)
                                {
                                    strSubject = strGetterName + ", you have new messages";
                                }

                                sbDivs.Append(drMailBox.EMB_BOX_HTML);
                                if (i < dv.Count - 1)
                                {
                                    sbDivs.Append("<hr style='color: rgb(59, 89, 152);' />");
                                }

                                procAPT_EMAIL_BOXDeleteByEMB_ID.ExecuteNonQuery(drMailBox.EMB_ID, m_db, trn);
                            }
                            Logger.Instance.WriteInformation("dv ended", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                            strBody = strBody.Replace("<%Divs%>", sbDivs.ToString());

                            Logger.Instance.WriteInformation("strSubject:" + strSubject, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                            Logger.Instance.WriteInformation("strBody:" + strBody, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                            object oEML_ID;
                            procAPT_EMAILInsertInto.ExecuteNonQuery(strBody, strGetterEMail, strGetterName, null, drMailBox.EMB_SENDER_NAME, strSubject, out oEML_ID, m_db, trn);
                            Logger.Instance.WriteInformation("procAPT_EMAILInsertInto", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                            dv = null;
                            sbDivs = null;
                            ds.Clear();

                            trn.Commit();
                            Logger.Instance.WriteCommitTrn(System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                        }
                        catch (Exception ex)
                        {
                            Logger.Instance.WriteRollbackTrn(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                            trn.Rollback();
                            RestartDB();
                        }
                        finally
                        {
                            procPT_EMAIL_BOXSelectLtEMB_PUBLISH_DATETIME.LoadDataSet(ds, ds.T_EMAIL_BOX.TableName, DateTime.Now);
                            Logger.Instance.WriteInformation("procPT_EMAIL_BOXSelectLtEMB_PUBLISH_DATETIME", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                        }
                    }

                    if (ds.T_EMAIL_BOX.Rows.Count == 0)
                    {
                        Logger.Instance.WriteInformation("No EMailBoxes to compose", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }
                    else
                    {
                        Logger.Instance.WriteProcess("Composed " + ds.T_EMAIL_BOX.Rows.Count + " EMailsBoxes", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
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