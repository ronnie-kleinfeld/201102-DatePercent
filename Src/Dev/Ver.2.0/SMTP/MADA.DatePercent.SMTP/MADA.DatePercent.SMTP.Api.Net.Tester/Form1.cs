using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MADA.DatePercent.SMTP.Api.Net.Tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Mailer.Instance.Compose("session test", "sender name test", "rk@datepercent.com", "getter name test", "subject test", "body test");
        }
    }
}