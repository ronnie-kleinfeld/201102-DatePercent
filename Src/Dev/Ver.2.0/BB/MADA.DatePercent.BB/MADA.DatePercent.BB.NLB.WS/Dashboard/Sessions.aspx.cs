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

namespace MADA.DatePercent.BB.NLB.WS.Dashboard
{
    public partial class Sessions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ApplicationHandler.Instance.RefresgIISUsersCount();
            gridViewIIS.DataSource = ApplicationHandler.Instance.PT_SERVERSelectBySRV_SERVER_TYPE_IIS;
            gridViewIIS.DataBind();

            ApplicationHandler.Instance.RefresgBLUsersCount();
            gridViewBL.DataSource = ApplicationHandler.Instance.PT_SERVERSelectBySRV_SERVER_TYPE_BL;
            gridViewBL.DataBind();
        }
    }
}