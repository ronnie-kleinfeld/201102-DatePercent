using System;
using System.Reflection;
using MADA.DatePercent.BB.BE;
using MADA.Log.Api.Net;

namespace MADA.DatePercent.BB.NLB.WS.Flex
{
    public partial class FBLoginPost : System.Web.UI.Page
    {
        public string m_strFBAccessTokenKey = Constants.FB_ACCESS_TOKEN_KEY;
        public string m_strCanvasPageUrl = Constants.UICanvasPageUrl;

        protected void Page_Load(object sender, EventArgs e)
        {
            Logger.Instance.WriteInformation("Page_Load", MethodBase.GetCurrentMethod(), string.Empty);
        }
    }
}