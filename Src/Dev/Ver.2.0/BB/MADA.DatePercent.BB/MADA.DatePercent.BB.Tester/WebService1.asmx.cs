using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace MADA.DatePercent.BB.Tester
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://www.datepercent.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string IPConverter(string p_strIP)
        {
            long longIP = MADA.Common.Net.IP.ToLong(p_strIP);

            return longIP.ToString() + ":" + MADA.Common.Net.IP.ToString(longIP);
        }
    }
}