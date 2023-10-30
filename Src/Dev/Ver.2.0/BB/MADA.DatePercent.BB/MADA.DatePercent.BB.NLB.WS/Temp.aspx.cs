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
using System.Diagnostics;

namespace MADA.DatePercent.BB.NLB.WS
{
    public partial class Temp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessInfo processInfo = new ProcessInfo();
            System.Diagnostics.PerformanceCounter cpuUsage = new System.Diagnostics.PerformanceCounter();
            cpuUsage.CategoryName = "Processor";
            cpuUsage.CounterName = "% Processor Time";
            cpuUsage.InstanceName = "_Total";

            float f = cpuUsage.NextValue();
        }
    }
}
