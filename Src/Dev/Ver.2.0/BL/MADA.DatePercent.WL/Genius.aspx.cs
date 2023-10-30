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

namespace MADA.DatePercent.WL
{
    public partial class Genius : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MADA.Web.HttpRequest.QueryString queryString = new MADA.Web.HttpRequest.QueryString(HttpContext.Current.Request.QueryString);
            string strUID = queryString.Get(BE.Constants.UID_URL_KEY, string.Empty).ToString();
            string strDetailsUID = queryString.Get(BE.Constants.DETAILS_UID_URL_KEY, string.Empty).ToString();

            DBS.dbDatePercentDB.SPs.procPT_USER_GENIUS_LINKInsertIntoByUID_DETAILS_UID.ExecuteNonQuery(strDetailsUID, strUID);

            // call loader and send uid params


        }
    }
}