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
using MADA.DatePercent.DBS.dbDatePercentDB.SPs;
using MADA.DatePercent.BL;

namespace MADA.DatePercent.WL.Registration
{
    public partial class UserCount : System.Web.UI.Page
    {
        public string m_strCount;
        public string m_strLogonCount;

        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            
            procAPT_USERSelect.LoadDataSet(ds, "T_USER");
            m_strCount = ds.Tables["T_USER"].Rows.Count.ToString();

            m_strLogonCount = ApplicationHandler.Instance.LogonCounter.ToString();
        }
    }
}
