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
using MADA.Common.Security.Cryptography;
using MADA.DatePercent.BL;
using MADA.Log.Api.Net;

namespace MADA.DatePercent.WL.Registration.Login
{
    public partial class Login : System.Web.UI.Page
    {
        public string m_strMessage = string.Empty;
        public string m_strRootFlexUrl = Constants.RootFlexUrl;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Logger.Instance.WriteInformation("Started", System.Reflection.MethodBase.GetCurrentMethod(), string.Empty);
                Logger.Instance.WriteProcess("Request.Url:" + Request.Url, System.Reflection.MethodBase.GetCurrentMethod(), string.Empty);

                checkBoxKeepMeLoggedIn.Checked = true;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), string.Empty);
                Response.Redirect(Constants.UIDefaultUrl + Request.Url.Query, false);
            }
        }

        protected void linkButtonLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                Logger.Instance.WriteProcess("LogIn", System.Reflection.MethodBase.GetCurrentMethod(), string.Empty);
                string strEMail = textBoxEMail.Text;
                Logger.Instance.WriteProcess("EMail:" + strEMail, System.Reflection.MethodBase.GetCurrentMethod(), string.Empty);
                string strPassworkHash = SHA1.Encript(textBoxPassword.Text);
                Logger.Instance.WriteProcess("Password Hash:" + strPassworkHash, System.Reflection.MethodBase.GetCurrentMethod(), string.Empty);
                bool bKeepMeLoggedIn = checkBoxKeepMeLoggedIn.Checked;
                Logger.Instance.WriteProcess("Keep me logged in:" + bKeepMeLoggedIn, System.Reflection.MethodBase.GetCurrentMethod(), string.Empty);
                if (strEMail == string.Empty || strPassworkHash == string.Empty)
                {
                    m_strMessage = "EMail and Password are required";
                }
                else
                {
                    string strUserUID = string.Empty;// = SecurityHandler.GetUserUID(strEMail, strPassworkHash);
                    if (strUserUID == string.Empty)
                    {
                        m_strMessage = "Invalid EMail and Password";
                    }
                    else
                    {
                        m_strMessage = string.Empty;
                        FormsAuthentication.RedirectFromLoginPage(strUserUID, bKeepMeLoggedIn);
                        Response.Redirect(Constants.UIDefaultUrl + Request.Url.Query, false);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), string.Empty);
                Response.Redirect(Constants.UIDefaultUrl + Request.Url.Query, false);
            }
        }
    }
}