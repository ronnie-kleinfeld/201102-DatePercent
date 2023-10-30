using System;
using System.Reflection;
using MADA.DatePercent.BB.BE;
using MADA.Log.Api.Net;

namespace MADA.DatePercent.BB.NLB.WS.Flex
{
    public partial class FBLogin : System.Web.UI.Page
    {
        public string m_strFBAppID = Constants.FB_APP_ID;
        public string m_strRootFlexUrl = Constants.RootFlexUrl;

        protected void Page_Load(object sender, EventArgs e)
        {
            Logger.Instance.WriteInformation("Page_Load", MethodBase.GetCurrentMethod(), string.Empty);
        }
    }
}