using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MADA.BE;
using MADA.Log.Api.Net;

namespace MADA.DatePercent.SMTP.WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;

                string strEMails = @"
";

                strEMails = strEMails.Replace("\r\n", ";");
                string[] a_strEmails = strEMails.Split(';');
                label3.Text = a_strEmails.Length.ToString();
                com.dp68457.www.SmtpWS smtpWS = new com.dp68457.www.SmtpWS();

                int i = 1;

                foreach (string email in a_strEmails)
                {
                    try
                    {
                        label1.Text = i.ToString();
                        label4.Text = email;
                        Application.DoEvents();
                        smtpWS.Compose(Environment.MachineName, "mailer@datepercent.con", email, email, "Hi from DatePercent",
                            "Hi," +
                            "<br/>" +
                            "A few month ago you logged into <a href='http://apps.facebook.com/datepercent_vtwo'>DatePercent</a> on Facebook" + "<br/>" +
                            "We recently launched a new version" + "<br/>" +
                            "<img src='http://www.datepercent.com/Res/Version.2.png' alt='Version 2'/>" + "<br/>" +
                            "<br/>" +
                            "Please click <a href='http://apps.facebook.com/datepercent_vtwo'>here</a> to log-in to <a href='http://apps.facebook.com/datepercent_vtwo'>DatePercent</a>" + "<br/>" +
                            "<br/>" +
                            "<br/>" +
                            "Regards," + "<br/>" +
                            "<a href='http://apps.facebook.com/datepercent_vtwo'>DatePercent</a> Team");
                    }
                    catch
                    {
                    }
                    finally
                    {
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), "Ping");
            }
        }
    }
}