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

namespace MADA.DatePercent.BB.NLB.WS.ContactFetcher
{
    public partial class GMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}

/*
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
using MADA.DatePercent.DBS.dbDatePercentDB.Tables;
using System.Net;
using MADA.DatePercent.BL;
using System.Xml;
using System.IO;
using MADA.DatePercent.BE;
using MADA.Log.Api.Net;

namespace MADA.DatePercent.WL.Registration
{
    public partial class GMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Logger.Instance.WriteProcess("access_token:" + Request.QueryString["access_token"], MethodBase.GetCurrentMethod(), string.Empty);

                if (Request.QueryString["access_token"] != null)
                {
                    GetContacts(Request.QueryString["access_token"]);
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), string.Empty);
            }
        }

        private void GetContacts(string p_strAccessToken)
        {
            Logger.Instance.WriteProcess("GetContacts start:", MethodBase.GetCurrentMethod(), string.Empty);

            WebRequest webRequest;
            WebResponse webResponse = null;
            StreamReader streamReader = null;

            try
            {
                string strUri = "https://www.google.com/m8/feeds/contacts/default/full?max-results=10000&oauth_token=" + p_strAccessToken;
                Uri objUrl = new System.Uri(strUri);
                string strResponse = string.Empty;

                webRequest = WebRequest.Create(objUrl);
                webResponse = webRequest.GetResponse();

                streamReader = new StreamReader(webResponse.GetResponseStream());
                strResponse = streamReader.ReadToEnd();

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.InnerXml = strResponse;

                Logger.Instance.WriteProcess("Got XML:" + xmlDocument.InnerXml, MethodBase.GetCurrentMethod(), string.Empty);

                DataSet ds = new DataSet();
                string strEMailOwner = string.Empty;
                string strUID = string.Empty;
                string strTitle;
                string strEMail;
                foreach (XmlElement xmlElement in xmlDocument.DocumentElement)
                {
                    if (xmlElement.Name == "id")
                    {
                        strEMailOwner = xmlElement.InnerXml;
                        procPT_USERSelectByUSE_EMAIL.LoadDataSet(ds, tblT_USER._Name, strEMailOwner);
                        try
                        {
                            strUID = ds.Tables[tblT_USER._Name].Rows[0]["USR_UID"].ToString();
                        }
                        catch
                        {
                            strUID = "EFCCA098-D661-4CD5-99EF-E9AAD2591318";
                        }
                        Logger.Instance.WriteProcess("Got ID:" + strEMailOwner, MethodBase.GetCurrentMethod(), string.Empty);
                    }
                    else if (xmlElement.Name == "entry")
                    {
                        strTitle = string.Empty;
                        strEMail = string.Empty;
                        foreach (XmlElement xmlElementEntry in xmlElement)
                        {
                            if (xmlElementEntry.Name == "title")
                            {
                                strTitle = xmlElementEntry.InnerXml;
                            }
                            else if (xmlElementEntry.Name == "gd:email")
                            {
                                strEMail = xmlElementEntry.Attributes["address"].Value;
                            }
                        }
                        if (strTitle == string.Empty)
                        {
                            strTitle = strEMail;
                        }
                        Logger.Instance.WriteProcess("Got entry:" + strTitle + "-" + strEMail, MethodBase.GetCurrentMethod(), string.Empty);

                        if (strEMail != string.Empty)
                        {
                            try
                            {
                                Logger.Instance.WriteProcess("Write invitee:" + strTitle + strEMail, MethodBase.GetCurrentMethod(), string.Empty);
                                InviteeHandler.Invite(strEMail, strUID, -1, strTitle, T_USER_INVITEE_TYPE_ENUM.Added);
                            }
                            catch (Exception ex)
                            {
                                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), string.Empty);
                            }
                        }
                    }
                }

                Logger.Instance.WriteProcess("XML read done", MethodBase.GetCurrentMethod(), string.Empty);
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), string.Empty);
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
*/