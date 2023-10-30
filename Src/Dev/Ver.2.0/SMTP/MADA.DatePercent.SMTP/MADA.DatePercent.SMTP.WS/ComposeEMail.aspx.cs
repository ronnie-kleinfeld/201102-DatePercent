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
using MADA.DatePercent.SMTP.DBS.dbSmtpDB.SPs;
using MADA.Log.Api.Net;

namespace MADA.DatePercent.SMTP.WS
{
    public partial class ComposeEMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCompose_Click(object sender, EventArgs e)
        {
            try
            {
                ComposeEMailDataSet m_ds = null;
                string strGetterName = textBoxGetterName.Text;

                object EML_ID;
                if (textAreaGetterEMail.Value.Contains("\r\n"))
                {
                    string[] a_strGetterEMail = textAreaGetterEMail.Value.Replace("\r\n", "\n").Split('\n');

                    foreach (string strGetterEMail in a_strGetterEMail)
                    {
                        if (checkboxDoNotSendDuplicates.Checked)
                        {
                            procAPT_EMAIL_HISTORYSelectByEMH_GETTER_EMAIL.LoadDataSet(m_ds, m_ds.T_EMAIL_HISTORY.TableName, strGetterEMail);

                            if (m_ds.T_EMAIL_HISTORY.Rows.Count == 0)
                            {
                                procAPT_EMAILInsertInto.ExecuteNonQuery(textAreaBody.Value, strGetterEMail, strGetterName, null, textBoxSenderName.Text, textBoxSubject.Text, out EML_ID);
                            }
                            m_ds = null;
                        }
                        else
                        {
                            procAPT_EMAILInsertInto.ExecuteNonQuery(textAreaBody.Value, strGetterEMail, strGetterName, null, textBoxSenderName.Text, textBoxSubject.Text, out EML_ID);
                        }
                    }
                }
                else
                {
                    procAPT_EMAILInsertInto.ExecuteNonQuery(textAreaBody.Value, textAreaGetterEMail.Value, strGetterName, null, textBoxSenderName.Text, textBoxSubject.Text, out EML_ID);
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), "MADA.DatePercent.SMTP.WS");
            }
        }
    }
}
