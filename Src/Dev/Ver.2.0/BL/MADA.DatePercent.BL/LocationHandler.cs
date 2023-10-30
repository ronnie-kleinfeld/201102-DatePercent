using System;
using System.Collections.Generic;
using System.Text;
using MADA.Common.DataType;
using MADA.DatePercent.DBS.dbDatePercentDB.SPs;
using System.Net;
using System.IO;
using MADA.Log.Api.Net;
using MADA.DatePercent.DBS.dbDatePercentDB.Tables;

namespace MADA.DatePercent.BL
{
    public class LocationHandler
    {
        public static Location GetLocation(string p_strSessionID, string p_strIP)
        {
            try
            {
                object oMIP_ID;

                try
                {
                    if (p_strIP == "127.0.0.1")
                    {
                        procAPT_MAX_MIND_TRACKINGInsertInto.ExecuteNonQuery(null, System.DateTime.Now, p_strIP, string.Empty, -1, -1, string.Empty, "IP is 127.0.0.1", out oMIP_ID);
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
                        Logger.Instance.WriteInformation("GeoLocation=" + strResponse, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                        streamReader.Close();
                        webResponse.Close();

                        if (strResponse == ",,,,,IP_NOT_FOUND")
                        {
                            procAPT_MAX_MIND_TRACKINGInsertInto.ExecuteNonQuery(null, System.DateTime.Now, p_strIP, strUri, -1, -1, strResponse, "MaxMind WS result: IP not found", out oMIP_ID);
                            throw new Exception("MaxMind WS result: IP not found");
                        }
                        else
                        {
                            //US,NY,New York,40.742100,-74.001801
                            Location location = new Location(p_strIP, strResponse);

                            procAPT_MAX_MIND_TRACKINGInsertInto.ExecuteNonQuery(null, System.DateTime.Now, p_strIP, strUri, (decimal)location.GetLatLng.Lat,
                                (decimal)location.GetLatLng.Lng, strResponse, "MaxMind WS result: success", out oMIP_ID);
                            Logger.Instance.WriteProcess("MaxMind WS result: success", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                            return location;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), p_strSessionID);
                    return Location.DefaultLocation();
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), p_strSessionID);
                return Location.DefaultLocation();
            }
        }
    }
}