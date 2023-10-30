using System;
using System.Collections.Generic;
using System.Text;
using MADA.Common.DataType;
using System.Net;
using System.IO;
using MADA.Log.Api.Net;
using System.Reflection;

namespace MADA.DatePercent.BB.BL
{
    public class LocationHandler
    {
        public static Location GetLocation(string p_strSessionID, string p_strIP)
        {
            try
            {
                try
                {
                    if (p_strIP == "127.0.0.1")
                    {
                        throw new Exception("IP is 127.0.0.1");
                    }
                    else
                    {
                        string strUri = "http://geoip3.maxmind.com/b?l=HIgIKfnvD6kr&i=" + p_strIP;
                        Uri objUrl = new System.Uri(strUri);
                        WebRequest webRequest;
                        WebResponse webResponse;
                        StreamReader streamReader;
                        string strResponse = string.Empty;

                        webRequest = WebRequest.Create(objUrl);
                        webResponse = webRequest.GetResponse();

                        streamReader = new StreamReader(webResponse.GetResponseStream());
                        strResponse = streamReader.ReadToEnd();
                        Logger.Instance.WriteInformation("GeoLocation=" + strResponse, MethodBase.GetCurrentMethod(), Environment.MachineName);

                        streamReader.Close();
                        webResponse.Close();

                        if (strResponse == ",,,,,IP_NOT_FOUND")
                        {
                            throw new Exception("MaxMind WS result: IP not found");
                        }
                        else
                        {
                            //US,NY,New York,40.742100,-74.001801
                            Location location = new Location(p_strIP, strResponse);

                            Logger.Instance.WriteProcess("MaxMind WS result: success", MethodBase.GetCurrentMethod(), Environment.MachineName);

                            return location;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSessionID);
                    return Location.DefaultLocation();
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), p_strSessionID);
                return Location.DefaultLocation();
            }
        }
    }
}