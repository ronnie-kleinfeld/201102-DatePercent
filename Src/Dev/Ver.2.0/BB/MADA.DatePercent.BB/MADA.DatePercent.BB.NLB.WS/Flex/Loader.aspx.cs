using System;
using System.Reflection;
using MADA.DatePercent.BB.BE;
using MADA.Log.Api.Net;
using System.Web;
using System.Xml;
using System.Net;
using System.IO;
using System.Data;
using MADA.DatePercent.SMTP.Api.Net;

namespace MADA.DatePercent.BB.NLB.WS.Flex
{
    public partial class Loader : System.Web.UI.Page
    {
        public string m_strRootFlexUrl = Constants.RootFlexUrl;
        public string m_strSID;
        public string m_strIISServer;
        public string m_strBLServer;
        public string m_strToken;
        public string m_strLocale;
        public string m_strAnimationApp;

        protected void Page_Load(object sender, EventArgs e)
        {
            Logger.Instance.WriteInformation("Page_Load", MethodBase.GetCurrentMethod(), string.Empty);

            // url.request
            //http://apps.facebook.com/datepercent_vtwo_lh/?p=v&
            //IIS=4&
            //BL=5&
            //geroghlijklhsdjf=AAAD1vkyFJfsBAP1XvF9MZCcN8MDLs2hkW99M5CBkgFqj8uZBh7Vzx9ZCGST7IUpPepwPFsgyMypGQcoq1SXlyFDjy4q9iQjP1TXy17miwZDZD

            m_strSID = HttpContext.Current.Session.SessionID;
            Logger.Instance.WriteInformation("m_strSID:" + m_strSID, MethodBase.GetCurrentMethod(), m_strSID);

            m_strIISServer = "www." + ApplicationHandler.Instance.T_SERVER_IIS.FindBySRV_ID(Int32.Parse(Request.QueryString["IIS"])).SRV_REG_DNS;
            //m_strIISServer = "localhost:63332";
            Logger.Instance.WriteInformation("m_strIISServer:" + m_strIISServer, MethodBase.GetCurrentMethod(), m_strSID);

            m_strBLServer = "www." + ApplicationHandler.Instance.T_SERVER_BL.FindBySRV_ID(Int32.Parse(Request.QueryString["BL"])).SRV_REG_DNS;
            //m_strBLServer = "localhost:63335";
            Logger.Instance.WriteInformation("m_strBLServer:" + m_strBLServer, MethodBase.GetCurrentMethod(), m_strSID);

            m_strToken = Request.QueryString[Constants.FB_ACCESS_TOKEN_KEY].ToString();
            Logger.Instance.WriteInformation("m_strToken:" + m_strToken, MethodBase.GetCurrentMethod(), m_strSID);

            NLBWS.info.datepercent.www.NLBWS nlbWS = new NLBWS.info.datepercent.www.NLBWS();
            nlbWS.SessionInit(m_strSID, m_strToken);

            DataSet dsUser = new DataSet();
            dsUser.ReadXml(new XmlNodeReader(GetFbGraphApi(m_strSID, "https://api.facebook.com/method/fql.query?query=select uid,locale from user where uid=me()&access_token=" + m_strToken)));
            Logger.Instance.Write(dsUser, MethodBase.GetCurrentMethod(), m_strSID);
            
            DataRow drUser = dsUser.Tables["user"].Rows[0];
            Logger.Instance.Write(drUser, MethodBase.GetCurrentMethod(), m_strSID);
            
            string strFBLocale = drUser["locale"].ToString();
            Logger.Instance.WriteInformation("strFBLocale:" + strFBLocale, MethodBase.GetCurrentMethod(), m_strSID);

            string strLocale = ApplicationHandler.Instance.GetLocale(strFBLocale);
            Logger.Instance.WriteInformation("strLocale:" + strLocale, MethodBase.GetCurrentMethod(), m_strSID);

            NLBWS.info.datepercent.www.NLBWS nlbws = new MADA.DatePercent.BB.NLB.WS.NLBWS.info.datepercent.www.NLBWS();
            string strDBLocale = nlbws.GetLocale(drUser["uid"].ToString());
            Logger.Instance.WriteInformation("strDBLocale:" + strDBLocale, MethodBase.GetCurrentMethod(), m_strSID);

            if (strDBLocale == string.Empty)
            {
                m_strLocale = strLocale;
            }
            else
            {
                m_strLocale = strDBLocale;
            }

            switch (m_strLocale.Substring(0, 2).ToUpper())
            {
                case "EN":
                    m_strAnimationApp = "AnimationEN";
                    break;
                case "HE":
                    m_strAnimationApp = "AnimationHE";
                    break;
                default:
                    Logger.Instance.WriteSwitchOutOfRange(m_strLocale, MethodBase.GetCurrentMethod(), m_strSID);
                    m_strAnimationApp = "AnimationEN";
                    break;
            }
        }

        private static XmlDocument GetFbGraphApi(string p_strSID, string p_strGraphApiUri)
        {
            WebRequest webRequest;
            WebResponse webResponse = null;
            StreamReader streamReader = null;

            try
            {
                Uri objUrl = new System.Uri(p_strGraphApiUri);
                string strResponse = string.Empty;

                webRequest = WebRequest.Create(objUrl);
                webResponse = webRequest.GetResponse();

                streamReader = new StreamReader(webResponse.GetResponseStream());
                strResponse = streamReader.ReadToEnd();

                if (strResponse.Contains("<error_msg>Error validating access token:"))
                {
                    Mailer.Instance.Compose("ACCESS_TOKEN is missing", "");
                    Logger.Instance.WriteCritical("Invalid FB ACCESS TOKEN for SID:" + p_strSID, MethodBase.GetCurrentMethod(), p_strSID);
                    return null;
                }
                else
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.InnerXml = strResponse;
                    return xmlDocument;
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSID);
                return null;
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
                if (webResponse != null)
                {
                    webResponse.Close();
                }
            }
        }
    }
}