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
using MADA.DatePercent.BE;
using MADA.Log.Api.Net;

namespace MADA.DatePercent.WL.Flex
{
    public partial class FBLoginPost : System.Web.UI.Page
    {
        public string m_strFBAccessTokenKey = Constants.FB_ACCESS_TOKEN_KEY;
        public string m_strCanvasPageUrl = Constants.UICanvasPageUrl;

        protected void Page_Load(object sender, EventArgs e)
        {
            Logger.Instance.WriteInformation("Page_Load", System.Reflection.MethodBase.GetCurrentMethod(), string.Empty);
        }
    }
}