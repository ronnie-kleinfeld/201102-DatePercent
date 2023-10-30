using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Timers;
using MADA.DatePercent.BL;
using MADA.DatePercent.DBS.dbDatePercentDB.SPs;
using MADA.Log.Api.Net;

namespace MADA.DatePercent.Worker
{
    public class MailSenderWorker : WorkerDBBase
    {
        #region Members
        private MailAddress m_mailAddressSender;
        private SmtpClient m_smtpClient;
        private NetworkCredential m_networkCredential;
        #endregion
        #region Properties
        protected override string WorkerName
        {
            get
            {
                return "MailSenderWorker";
            }
        }
        #endregion
        #region Class
        public MailSenderWorker()
            : base()
        {
            try
            {
                Logger.Instance.WriteInformation("Started", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                Logger.Instance.WriteInformation("Environment.MachineName=" + System.Environment.MachineName, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                if (Environment.MachineName == "DEV")
                {
                    m_smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    m_smtpClient.EnableSsl = true;
                    m_mailAddressSender = new MailAddress("ronnie.yad2@gmail.com", "Ronnie Yad2");
                    m_networkCredential = new NetworkCredential("ronnie.yad2@gmail.com", "shira633", "");
                }
                else
                {
                    m_smtpClient = new SmtpClient("localhost", 25);
                    m_smtpClient.EnableSsl = false;
                    m_mailAddressSender = new MailAddress("mailer@datepercent.com", "DatePercent");
                    m_networkCredential = new NetworkCredential("mailer@datepercent.com", "dp633");
                }
                Logger.Instance.WriteInformation("mailer:" + m_mailAddressSender.Address, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                Logger.Instance.WriteInformation("smtp:" + m_smtpClient.Host, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                Logger.Instance.WriteInformation("port:" + m_smtpClient.Port, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                Logger.Instance.WriteInformation("EnableSsl=" + m_smtpClient.EnableSsl, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                m_smtpClient.Credentials = m_networkCredential;

                Logger.Instance.WriteProcess("Init", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                object oEMH_ID;
                procPT_EMAIL_HISTORYInsertInto.ExecuteNonQuery(
                    "This email test the smtp of the MailSenderWorker. If this email arrived here it's ok.",
                    "mailer@datepercent.com",
                    "mailer@datepercent.com",
                    null,
                    Environment.MachineName + "::MailSenderWorker::MailSenderWorker() mail tester",
                    out oEMH_ID);

                MailMessage mailMessage = new MailMessage(m_mailAddressSender, new MailAddress("mailer@datepercent.com", "mailer@datepercent.com"));
                mailMessage.Subject = Environment.MachineName + "::MailSenderWorker::MailSenderWorker() mail tester";
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = "This email test the smtp of the MailSenderWorker. If this email arrived here it's ok.";
                m_smtpClient.Send(mailMessage);

                Logger.Instance.WriteProcess("SMTP validation email sent", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                Logger.Instance.WriteInformation("Ended", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (SmtpException ex)
            {
                Logger.Instance.WriteCritical("SmtpException:" + ex.Message, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        public override void Dispose()
        {
            base.Dispose();

            m_networkCredential = null;
            m_smtpClient = null;
            m_mailAddressSender = null;
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

                    procPT_EMAILDeleteUntiSpam.ExecuteNonQuery();
                    Logger.Instance.WriteInformation("AntiSpam deleted", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                    DbTransaction trn = null;
                    bool bSendEMail;

                    MailSenderDataSet ds = new MailSenderDataSet();
                    procAPT_EMAILSelect.LoadDataSet(ds, ds.T_EMAIL.TableName);

                    foreach (MailSenderDataSet.T_EMAILRow dr in ds.T_EMAIL.Rows)
                    {
                        Logger.Instance.Write(dr, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                        try
                        {
                            trn = m_con.BeginTransaction();
                            Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                            bSendEMail = false;

                            if (dr.EML_GETTER_EMAIL.Contains("@teva"))
                            {
                                bSendEMail = false;
                            }
                            else if (dr.EML_GETTER_EMAIL == "ronnie.kleinfeld@gmail.com" ||
                                dr.EML_GETTER_EMAIL == "shira.kleinfeld@gmail.com" ||
                                dr.EML_GETTER_EMAIL == "roy.kleinfeld@gmail.com" ||
                                dr.EML_GETTER_EMAIL == "ronnie.kleinfeld@yahoo.com" ||
                                dr.EML_GETTER_EMAIL == "ronnie.yad2@gmail.com" ||
                                dr.EML_GETTER_EMAIL == "datepercent@gmail.com" ||
                                dr.EML_GETTER_EMAIL == "rk@iwhist.co.il" ||
                                dr.EML_GETTER_EMAIL == "rk@datepercent.com" ||
                                dr.EML_GETTER_EMAIL == "support@datepercent.com" ||
                                dr.EML_GETTER_EMAIL == "mailer@datepercent.com" ||
                                dr.EML_GETTER_EMAIL == "yarok.yarok.2@gmail.com" ||
                                dr.EML_GETTER_EMAIL == "kahol.kahol.2@gmail.com" ||
                                dr.EML_GETTER_EMAIL == "adom.adom2@gmail.com" ||
                                dr.EML_GETTER_EMAIL == "zahov.zahov@gmail.com")
                            {
                                bSendEMail = true;
                            }
                            else if (System.Environment.MachineName.ToUpper() == "WWW072")
                            {
                                bSendEMail = true;
                            }
                            Logger.Instance.WriteInformation("bSendEMail:" + bSendEMail, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                            procAPT_EMAILDeleteByEML_ID.ExecuteNonQuery(dr.EML_ID, m_db, trn);
                            Logger.Instance.WriteInformation("Deleted from T_EMAIL", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                            if (bSendEMail)
                            {
                                Logger.Instance.WriteInformation("In bSendEMail", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                                object oEMH_ID;
                                procPT_EMAIL_HISTORYInsertInto.ExecuteNonQuery(dr.EML_BODY, dr.EML_GETTER_EMAIL, dr.EML_GETTER_NAME, null, dr.EML_SUBJECT, out oEMH_ID, m_db, trn);
                                Logger.Instance.WriteInformation("Added to T_EMAIL_HISTORY", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                                m_mailAddressSender = new MailAddress("mailer@datepercent.com", dr.EML_SENDER_NAME + " via DataPercent");
                                MailMessage mailMessage = new MailMessage(m_mailAddressSender, new MailAddress(dr.EML_GETTER_EMAIL, dr.EML_GETTER_NAME));
                                mailMessage.Subject = dr.EML_SUBJECT;
                                mailMessage.IsBodyHtml = true;
                                mailMessage.Body = dr.EML_BODY;
                                Logger.Instance.WriteInformation("MailMessage ready", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                                m_smtpClient.Send(mailMessage);
                                Logger.Instance.WriteInformation("SMTP sent", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                            }

                            trn.Commit();
                            Logger.Instance.WriteCommitTrn(System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                        }
                        catch (Exception ex)
                        {
                            Logger.Instance.WriteRollbackTrn(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                            trn.Rollback();
                            procAPT_EMAILDeleteByEML_ID.ExecuteNonQuery(dr.EML_ID);
                            RestartDB();
                        }
                    }

                    if (ds.T_EMAIL.Rows.Count == 0)
                    {
                        Logger.Instance.WriteInformation("No EMail to send", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }
                    else
                    {
                        Logger.Instance.WriteProcess("Sent " + ds.T_EMAIL.Rows.Count + " EMails", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
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