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

namespace MADA.DatePercent.WL.Public
{
    public partial class RedirerctToShareOnFacebook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strSID;
            try
            {
                strSID = Request.QueryString[Constants.SID_KEY];
            }
            catch
            {
                strSID = "";
            }

            Logger.Instance.WriteInformation("RedirerctToShareOnFacebook", System.Reflection.MethodBase.GetCurrentMethod(), strSID);

            Response.Redirect("http://www.facebook.com/dialog/apprequests" +
                "?app_id=" + Constants.FB_APP_ID +
                "&redirect_uri=" + Constants.UIRedirectToAppUrl +
                "&message=Would you like to join me to DatePercent app?");
        }
    }
}