using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MADA.DatePercent.SMTP.Api.Net.Tester.GreetingCard2012DataSetTableAdapters;

namespace MADA.DatePercent.SMTP.Api.Net.Tester
{
    public partial class GreetingCard2012Form : Form
    {
        public GreetingCard2012Form()
        {
            InitializeComponent();
        }

        private void GreetingCard2012Form_Load(object sender, EventArgs e)
        {
            try
            {
                GreetingCard2012DataSet ds = new GreetingCard2012DataSet();
                V_USER_EMAILSTableAdapter ta = new MADA.DatePercent.SMTP.Api.Net.Tester.GreetingCard2012DataSetTableAdapters.V_USER_EMAILSTableAdapter();
                ta.Fill(ds.V_USER_EMAILS);

                foreach (GreetingCard2012DataSet.V_USER_EMAILSRow dr in ds.V_USER_EMAILS.Rows)
                {
                    try
                    {
                        MADA.DatePercent.SMTP.Api.Net.Mailer.Instance.Compose("GreetingCard2012",
                            "DatePercent",
                            dr.USE_EMAIL, dr.USR_NAME, //"rk@datepercent.com", "Ronnie Kleinfeld",
                            "Season Greetings from Datepercent",
                            "<a href='http://apps.facebook.com/date-percent/?ref=GreetingCards2012'><img src='http://www.datepercent.com/res/GreetingCard2012.jpg'/></a>");
                    }
                    catch (Exception ex)
                    {
                        string str = ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }
    }
}