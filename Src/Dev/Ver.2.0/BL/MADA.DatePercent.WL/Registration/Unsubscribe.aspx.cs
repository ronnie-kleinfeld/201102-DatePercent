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
using MADA.DatePercent.BE;
using MADA.Log.Api.Net;

namespace MADA.DatePercent.WL.Registration
{
    public partial class Unsubscribe : System.Web.UI.Page
    {
        private UnsubscribeDataSet m_ds;
        public string m_strUsrFbPic;
        public string m_strEMail;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                m_ds = new UnsubscribeDataSet();

                m_strEMail = Request.QueryString[BE.Constants.EMAIL_URL_KEY].Replace("%40", "@");
                m_strUsrFbPic = Constants.UIResUrl + "rejected.jpg";

                procAPT_USER_EMAILSelectByUSE_EMAIL.LoadDataSet(m_ds, m_ds.T_USER_EMAIL.TableName, m_strEMail);
                procAPT_USER_INVITEESelectByUSI_EMAIL.LoadDataSet(m_ds, m_ds.T_USER_INVITEE.TableName, m_strEMail);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }

        protected void buttonUnsubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                procPT_EMAIL_UNTISPAMInsertInto.ExecuteNonQuery(m_strEMail);
                procPT_USER_INVITEEUpdateAsUnsubscribedByUSI_EMAIL.ExecuteNonQuery(m_strEMail);

                
                procPT_USERUpdateAsUnsubscribedByUSR_ID.ExecuteNonQuery(m_ds.T_USER_EMAIL[0].USE_USER_ID);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            finally
            {
                Response.Redirect(BE.Constants.UIGoodbyeUrl);
            }
        }
    }
}