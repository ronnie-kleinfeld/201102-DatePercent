using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using MADA.DatePercent.SMTP.DBS.dbSmtpDB.SPs;
using MADA.Log.Api.Net;
using MADA.BE;

namespace MADA.DatePercent.SMTP.WS
{
    /// <summary>
    /// Summary description for SmtpWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class SmtpWS : System.Web.Services.WebService
    {
        [WebMethod]
        public string Compose(string p_strSessionID, string p_strEML_SENDER_NAME, string p_strEML_GETTER_EMAIL, string p_strEML_GETTER_NAME, string p_strEML_SUBJECT, string p_strEML_BODY)
        {
            try
            {
                object EML_ID;
                procAPT_EMAILInsertInto.ExecuteNonQuery(p_strEML_BODY, p_strEML_GETTER_EMAIL, p_strEML_GETTER_NAME, null, p_strEML_SENDER_NAME, p_strEML_SUBJECT, out EML_ID);
                Logger.Instance.WriteInformation("AddEmail", System.Reflection.MethodBase.GetCurrentMethod(), p_strSessionID);

                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), p_strSessionID);
                return ResultCode.FAILED;
            }
        }
        [WebMethod]
        public string Ping()
        {
            try
            {
                return ResultCode.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), "Ping");
                return ResultCode.FAILED;
            }
        }
    }
}