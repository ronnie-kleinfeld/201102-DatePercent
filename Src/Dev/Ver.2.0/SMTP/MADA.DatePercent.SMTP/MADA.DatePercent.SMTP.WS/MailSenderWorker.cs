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
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Net.Mail;
using System.Net;
using MADA.DatePercent.SMTP.DBS.dbSmtpDB.SPs;

namespace MADA.DatePercent.SMTP.WS
{
    public class MailSenderWorker
    {
        #region Members
        protected internal Boolean m_bAvaliableToWork = true;
        protected internal Database m_db;
        protected internal DbConnection m_con;
        private MailAddress m_mailAddressSender;
        private SmtpClient m_smtpClient;
        private NetworkCredential m_networkCredential;
        #endregion
        #region Class
        public MailSenderWorker()
        {
            Logger.Instance.WriteProcess("Init", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

            try
            {
                Logger.Instance.WriteInformation("Started", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                StartDB();

                Logger.Instance.WriteInformation("Environment.MachineName=" + System.Environment.MachineName, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                /*
                switch (System.Environment.MachineName.ToUpper())
                {
                    case "DEV":
                        m_smtpClient = new SmtpClient("smtp.gmail.com", 587);
                        m_smtpClient.EnableSsl = true;
                        m_mailAddressSender = new MailAddress("ronnie.yad2@gmail.com", "Ronnie Yad2");
                        m_networkCredential = new NetworkCredential("ronnie.yad2@gmail.com", "shira633", "");
                        break;
                    case "WIN-Y24UQAKH98A":
                        m_smtpClient = new SmtpClient("mail.dp68457.com", 25);
                        m_smtpClient.EnableSsl = false;
                        m_mailAddressSender = new MailAddress("mailer@datepercent.com", "DatePercent");
                        m_networkCredential = new NetworkCredential("mailer@dp68457.com", "dp633");
                        break;
                    case "WWW072":
                        m_smtpClient = new SmtpClient("mail.datepercent.info", 25);
                        m_smtpClient.EnableSsl = false;
                        m_mailAddressSender = new MailAddress("mailer@datepercent.com", "DatePercent");
                        m_networkCredential = new NetworkCredential("mailer@datepercent.info", "dp633");
                        break;
                    default:
                        m_smtpClient = new SmtpClient("smtp.gmail.com", 587);
                        m_smtpClient.EnableSsl = true;
                        m_mailAddressSender = new MailAddress("ronnie.yad2@gmail.com", "Ronnie Yad2");
                        m_networkCredential = new NetworkCredential("ronnie.yad2@gmail.com", "shira633", "");
                        Logger.Instance.WriteSwitchOutOfRange(System.Environment.MachineName.ToUpper(), System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                        break;
                }
                */
                m_smtpClient = new SmtpClient("mail.datepercent.info", 25);
                m_smtpClient.EnableSsl = false;
                m_mailAddressSender = new MailAddress("mailer@datepercent.com", "DatePercent");
                m_networkCredential = new NetworkCredential("mailer@datepercent.info", "dp633");

                Logger.Instance.WriteProcess("mailer:" + m_mailAddressSender.Address, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                Logger.Instance.WriteProcess("smtp:" + m_smtpClient.Host, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                Logger.Instance.WriteProcess("port:" + m_smtpClient.Port, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                Logger.Instance.WriteProcess("EnableSsl=" + m_smtpClient.EnableSsl, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

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
        public virtual void Dispose()
        {
            StopDB();

            m_networkCredential = null;
            m_smtpClient = null;
            m_mailAddressSender = null;

            Logger.Instance.WriteProcess("Disposed", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
        }

        protected internal void StartDB()
        {
            try
            {
                Logger.Instance.WriteInformation("Environment.MachineName=" + System.Environment.MachineName, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                switch (System.Environment.MachineName.ToUpper())
                {
                    case "DEV":
                        m_db = DatabaseFactory.CreateDatabase("ConnectionStringDev");
                        break;
                    case "WIN-Y24UQAKH98A":
                        m_db = DatabaseFactory.CreateDatabase("ConnectionStringProd");
                        break;
                    default:
                        Logger.Instance.WriteSwitchOutOfRange(System.Environment.MachineName.ToUpper(), System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                        break;
                }
                Logger.Instance.WriteProcess("ConnectionString:" + m_db.ConnectionStringWithoutCredentials, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                m_con = m_db.CreateConnection();
                m_con.Open();

                Logger.Instance.WriteProcess("StartDB", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        protected internal void StopDB()
        {
            try
            {
                if (m_con != null && m_con.State == System.Data.ConnectionState.Open)
                {
                    m_con.Close();
                    m_con = null;
                }
                m_db = null;

                Logger.Instance.WriteProcess("StopDB", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        protected internal void RestartDB()
        {
            try
            {
                StopDB();
                StartDB();

                Logger.Instance.WriteCritical("RestartDB", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }

        public virtual void DoWork()
        {
            if (m_bAvaliableToWork)
            {
                m_bAvaliableToWork = false;

                try
                {
                    Logger.Instance.WriteInformation("Started", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                    procPT_EMAILDeleteUntiSpam.ExecuteNonQuery();
                    Logger.Instance.WriteInformation("AntiSpam deleted", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                    bool bSendEMail;

                    MailSenderDataSet ds = new MailSenderDataSet();
                    procAPT_EMAILSelect.LoadDataSet(ds, ds.T_EMAIL.TableName);

                    MailMessage mailMessage = null;
                    foreach (MailSenderDataSet.T_EMAILRow dr in ds.T_EMAIL.Rows)
                    {
                        Logger.Instance.Write(dr, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                        try
                        {
                            Logger.Instance.WriteInformation("EMail Started", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

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
                            else
                            {
                                bSendEMail = true;
                            }
                            Logger.Instance.WriteInformation("bSendEMail:" + bSendEMail, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                            procAPT_EMAILDeleteByEML_ID.ExecuteNonQuery(dr.EML_ID);
                            Logger.Instance.WriteInformation("Deleted from T_EMAIL", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                            if (bSendEMail)
                            {
                                Logger.Instance.WriteInformation("In bSendEMail", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                                object oEMH_ID;
                                procPT_EMAIL_HISTORYInsertInto.ExecuteNonQuery(dr.EML_BODY, dr.EML_GETTER_EMAIL, dr.EML_GETTER_NAME, null, dr.EML_SUBJECT, out oEMH_ID);
                                Logger.Instance.WriteInformation("Added to T_EMAIL_HISTORY", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                                if (mailMessage == null)
                                {
                                    mailMessage = new MailMessage();
                                    m_mailAddressSender = new MailAddress("mailer@datepercent.com", dr.EML_SENDER_NAME);
                                    mailMessage.IsBodyHtml = true;
                                    mailMessage.From = m_mailAddressSender;
                                    mailMessage.Subject = dr.EML_SUBJECT;
                                    mailMessage.Body = dr.EML_BODY;
                                    Logger.Instance.WriteInformation("MailMessage ready", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                                }

                                if (ds.T_EMAIL.Rows.Count == 1)
                                {
                                    mailMessage.To.Add(new MailAddress(dr.EML_GETTER_EMAIL, dr.EML_GETTER_NAME));
                                    Logger.Instance.WriteInformation("MailMessage ready", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                                    m_smtpClient.Send(mailMessage);
                                    Logger.Instance.WriteInformation("SMTP sent", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                                    mailMessage = null;
                                    break;
                                }
                                else
                                {
                                    if (mailMessage.From.Address != m_mailAddressSender.Address ||
                                        mailMessage.From.DisplayName != m_mailAddressSender.DisplayName ||
                                        mailMessage.From.Host != m_mailAddressSender.Host ||
                                        mailMessage.From.User != m_mailAddressSender.User ||
                                        mailMessage.Subject != dr.EML_SUBJECT ||
                                        mailMessage.Body != dr.EML_BODY ||
                                        mailMessage.To.Count >= 10)
                                    {
                                        Logger.Instance.WriteInformation("MailMessage ready", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                                        m_smtpClient.Send(mailMessage);
                                        Logger.Instance.WriteInformation("SMTP sent", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                                        mailMessage = null;
                                        break;
                                    }
                                    else
                                    {
                                        mailMessage.To.Add(new MailAddress(dr.EML_GETTER_EMAIL, dr.EML_GETTER_NAME));
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                            procAPT_EMAILDeleteByEML_ID.ExecuteNonQuery(dr.EML_ID);
                            RestartDB();
                        }
                    }

                    if (mailMessage != null)
                    {
                        Logger.Instance.WriteInformation("MailMessage ready", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                        m_smtpClient.Send(mailMessage);
                        Logger.Instance.WriteInformation("SMTP sent", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
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