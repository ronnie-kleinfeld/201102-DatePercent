using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MADA.DatePercent.SMTP.DBS.dbSmtpDB.SPs;
using MADA.Log.Api.Net;
using MADA.BE;

namespace MADA.DatePercent.SMTP.WS
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Logger.Instance.WriteInformation("Page_Load", System.Reflection.MethodBase.GetCurrentMethod(), "MADA.DatePercent.SMTP.WS");
        }

        protected void btnStop_Click(object sender, EventArgs e)
        {
            Logger.Instance.WriteInformation("btnStop_Click", System.Reflection.MethodBase.GetCurrentMethod(), "MADA.DatePercent.SMTP.WS");
            TimerHandler.Instance.Stop();
        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            Logger.Instance.WriteInformation("btnStart_Click", System.Reflection.MethodBase.GetCurrentMethod(), "MADA.DatePercent.SMTP.WS");
            TimerHandler.Instance.Start();
        }

        protected void btnDoWork_Click(object sender, EventArgs e)
        {
            Logger.Instance.WriteInformation("btnDoWork_Click", System.Reflection.MethodBase.GetCurrentMethod(), "MADA.DatePercent.SMTP.WS");
            TimerHandler.Instance.DoTimer();
        }

        protected void btnSendTestEMail_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.Instance.WriteInformation("btnSendTestEMail_Click", System.Reflection.MethodBase.GetCurrentMethod(), "MADA.DatePercent.SMTP.WS");
                object EML_ID;
                procAPT_EMAILInsertInto.ExecuteNonQuery("Test body", "rk@datepercent.com", "Test getter", null, "Test sender", "Test eMail", out EML_ID);
                Logger.Instance.WriteInformation("AddEmail", System.Reflection.MethodBase.GetCurrentMethod(), "MADA.DatePercent.SMTP.WS");
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), "MADA.DatePercent.SMTP.WS");
            }
        }
    }
}