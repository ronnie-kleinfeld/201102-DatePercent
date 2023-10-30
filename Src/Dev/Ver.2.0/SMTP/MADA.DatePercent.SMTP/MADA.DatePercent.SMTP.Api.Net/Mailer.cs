using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Timers;
using System.Text;
using MADA.BE;
using MADA.DatePercent.SMTP.Api.Net.com.dp68457.www;

namespace MADA.DatePercent.SMTP.Api.Net
{
    public sealed class Mailer
    {
        #region Singleton
        private static Mailer m_instance;

        public static Mailer Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new Mailer();
                }

                return m_instance;
            }
        }
        #endregion
        #region Members
        private SmtpDataSet m_ds;
        private SmtpWS m_smtpWS;
        private Timer m_timer;
        #endregion
        #region Class
        public Mailer()
        {
            try
            {
                m_ds = new SmtpDataSet();

                m_smtpWS = new SmtpWS();

                m_timer = new Timer();
                m_timer.Interval = 1000;
                m_timer.Elapsed += new ElapsedEventHandler(m_timer_Elapsed);
                m_timer.Enabled = true;
            }
            catch (Exception ex)
            {
                MADA.Common.Net.Mail.SendEMail("LOGGER CRITICAL",
                    "<hr/>MADA.DatePercent.SMTP.Api.Net:Init failed.<hr/>Web Service is missing or server down?<hr/>WS Server='" + m_smtpWS.Url + "'<hr/>Exception='" + ex.Message + "'<hr/>");
            }
        }
        #endregion
        #region Timer
        private void m_timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SmtpDataSet.T_EMAILRow dr = null;

            try
            {
                lock (m_ds.T_EMAIL)
                {
                    while (m_ds.T_EMAIL.Rows.Count > 0)
                    {
                        try
                        {
                            dr = m_ds.T_EMAIL[0];
                            m_smtpWS.Compose(dr.SessionID, dr.EML_SENDER_NAME, dr.EML_GETTER_EMAIL, dr.EML_GETTER_NAME, dr.EML_SUBJECT, dr.EML_BODY);
                        }
                        catch (RowNotInTableException)
                        {
                            m_ds.Clear();
                        }
                        finally
                        {
                            m_ds.T_EMAIL.RemoveT_EMAILRow(dr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // another try-catch because the event log might be full
                try
                {
                    System.Diagnostics.EventLog.WriteEntry(
                        "MADA.Log",
                        "MADA.Log failed to write to the database." + System.Environment.NewLine + ex.Message,
                        System.Diagnostics.EventLogEntryType.Error);
                }
                catch
                {
                }
            }

            // delete the last row or we have an infinite loop in case of an exception
            try
            {
                m_ds.T_EMAIL.Clear();
            }
            catch
            {
            }
        }
        #endregion
        #region Compose
        private string Origin(System.Reflection.MethodBase p_oMethodBase)
        {
            return Environment.MachineName + "::" + p_oMethodBase.DeclaringType.Name + "::" + p_oMethodBase.Name;
        }

        public string Compose(string p_strEML_SUBJECT, string p_strEML_BODY)
        {
            return Compose(Environment.MachineName, Environment.MachineName, "rk@datepercent.com", Environment.MachineName, p_strEML_SUBJECT, p_strEML_BODY);
        }
        public string Compose(string p_strSessionID, string p_strEML_SENDER_NAME, string p_strEML_GETTER_EMAIL, string p_strEML_GETTER_NAME, string p_strEML_SUBJECT, string p_strEML_BODY)
        {
            try
            {
                m_ds.T_EMAIL.AddT_EMAILRow(p_strSessionID, p_strEML_SENDER_NAME, p_strEML_GETTER_EMAIL, p_strEML_GETTER_NAME, p_strEML_SUBJECT, p_strEML_BODY);

                return ResultCode.SUCCESS;
            }
            catch (ArgumentException)
            {
                m_ds.T_EMAIL.AddT_EMAILRow(
                    p_strSessionID,
                    MADA.Common.DataType.String.TrimToLength(p_strEML_SENDER_NAME, 255),
                    MADA.Common.DataType.String.TrimToLength(p_strEML_GETTER_EMAIL, 255),
                    MADA.Common.DataType.String.TrimToLength(p_strEML_GETTER_NAME, 255),
                    MADA.Common.DataType.String.TrimToLength(p_strEML_SUBJECT, 255),
                    MADA.Common.DataType.String.TrimToLength(p_strEML_BODY, 255));

                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                // another try-catch because the event log might be full
                try
                {
                    System.Diagnostics.EventLog.WriteEntry(
                        "MADA.Log",
                        "MADA.Log failed to write to the database." + System.Environment.NewLine + ex.Message,
                        System.Diagnostics.EventLogEntryType.Error);
                }
                catch
                {
                }
                return ResultCode.FAILED;
            }
        }
        #endregion
    }
}