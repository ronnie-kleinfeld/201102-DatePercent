using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using MADA.DatePercent.BL;
using System.Reflection;

namespace MADA.DatePercent.WL.Temp
{
    /// <summary>
    /// Summary description for Testing
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Testing : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            string str = "Facebook token:146562955421093|2.AQC-2iKPg02xy5Sq.3600.1312722000.1-689887907|WmPayErm6MwJxlRlVQGLKvFbUM8";
            string strUID = str.Split('|')[1];
            strUID = strUID.Substring(strUID.LastIndexOf('-') + 1);

            return strUID;
        }
    }
}