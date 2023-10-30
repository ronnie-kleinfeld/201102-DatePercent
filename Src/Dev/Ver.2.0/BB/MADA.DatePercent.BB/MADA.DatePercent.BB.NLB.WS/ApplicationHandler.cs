using MADA.Log.Api.Net;
using System;
using MADA.DatePercent.SMTP.Api.Net;
using MADA.DatePercent.BB.NLB.DBS.dbNlbDB.SPs;
using MADA.DatePercent.BB.NLB.DBS.dbNlbDB.Tables;
using System.Timers;
using System.Collections;
using MADA.Common.DataType;
using MADA.DatePercent.BB.BL;
using MADA.BE;
using MADA.Common.Math;
using MADA.DatePercent.BB.NLB.WS.Properties;
using System.Data;
using System.Net;
using System.Reflection;
namespace MADA.DatePercent.BB.NLB.WS
{
    partial class ApplicationHandler
    {
        #region Singleton
        private static ApplicationHandler s_dsInstance;
        public static ApplicationHandler Instance
        {
            get
            {
                if (s_dsInstance == null)
                {
                    s_dsInstance = new ApplicationHandler();
                    s_dsInstance.Init();
                }

                return s_dsInstance;
            }
        }
        #endregion
        #region Members
        private int m_iSessionCount;

        private Hashtable m_hashtableIIS;
        private Hashtable m_hashtableBL;

        private Timer m_timer;
        #endregion
        #region Methods
        private void Init()
        {
            try
            {
                Logger.Instance.WriteInformation("Started", MethodBase.GetCurrentMethod(), Environment.MachineName);

                m_hashtableIIS = new Hashtable();
                m_hashtableBL = new Hashtable();

                m_timer = new Timer();
                m_timer.Interval = Settings.Default.TimerInterval;
                m_timer.Elapsed += new ElapsedEventHandler(m_timer_Elapsed);
                m_timer.Start();

                Logger.Instance.WriteInformation("Ended", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Mailer.Instance.Compose("DATEPERCENT CRITICAL",
                    "<hr/>MADA.DatePercent.BL::ApplicationHandler::Init()<hr/>Failed to connect to the database through Microsoft DataApplicationBlock<hr/>web.config is missing or set to localhost?<hr/>Exception='" + ex.Message + "'<hr/>");
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        public void Refresh()
        {
            try
            {
                Logger.Instance.WriteInformation("Started", MethodBase.GetCurrentMethod(), Environment.MachineName);

                this.Clear();
                procAPT_REGISTERSelect.LoadDataSet(this, this.tableT_REGISTER.TableName);
                procAPT_HOSTINGSelect.LoadDataSet(this, this.tableT_HOSTING.TableName);

                procAPT_FB_LOCALE_TYPESelect.LoadDataSet(this, this.tableT_FB_LOCALE_TYPE.TableName);

                procAPT_SERVERSelect.LoadDataSet(this, this.tableT_SERVER.TableName);

                bool bUpdated = false;
                Location location;
                foreach (T_SERVERRow dr in this.T_SERVER.Rows)
                {
                    if (dr.SRV_HOST_LAT == 0 || dr.SRV_HOST_LNG == 0)
                    {
                        location = LocationHandler.GetLocation(Environment.MachineName, dr.SRV_REG_DNS);
                        procPT_SERVERUpdateHostLatLngBySRV_ID.ExecuteNonQuery(location.GetLat, location.GetLng, dr.SRV_ID);
                        bUpdated = true;
                    }
                }

                if (bUpdated)
                {
                    this.T_SERVER.Clear();
                    procAPT_SERVERSelect.LoadDataSet(this, tableT_SERVER.TableName);
                }

                procAPT_SERVERSelectBySRV_SERVER_TYPE.LoadDataSet(this, tableT_SERVER_IIS.TableName, (int)T_SERVER_TYPE_ENUM.IIS);
                procAPT_SERVERSelectBySRV_SERVER_TYPE.LoadDataSet(this, tableT_SERVER_BL.TableName, (int)T_SERVER_TYPE_ENUM.BL);

                procPT_SERVERSelectBySRV_SERVER_TYPE.LoadDataSet(this, tablePT_SERVERSelectBySRV_SERVER_TYPE_IIS.TableName, (int)T_SERVER_TYPE_ENUM.IIS);
                foreach (PT_SERVERSelectBySRV_SERVER_TYPE_IISRow dr in PT_SERVERSelectBySRV_SERVER_TYPE_IIS.Rows)
                {
                    try
                    {
                        dr.IP = Dns.GetHostAddresses(dr.SRV_REG_DNS)[0].ToString();
                    }
                    catch
                    {
                    }
                }

                procPT_SERVERSelectBySRV_SERVER_TYPE.LoadDataSet(this, tablePT_SERVERSelectBySRV_SERVER_TYPE_BL.TableName, (int)T_SERVER_TYPE_ENUM.BL);
                foreach (PT_SERVERSelectBySRV_SERVER_TYPE_BLRow dr in PT_SERVERSelectBySRV_SERVER_TYPE_BL.Rows)
                {
                    try
                    {
                        dr.IP = Dns.GetHostAddresses(dr.SRV_REG_DNS)[0].ToString();
                    }
                    catch
                    {
                    }
                }

                procAPT_IP_LAT_LNGSelect.LoadDataSet(this, tableT_IP_LAT_LNG.TableName);

                m_hashtableIIS.Clear();
                foreach (T_SERVER_IISRow dr in T_SERVER_IIS.Rows)
                {
                    m_hashtableIIS.Add(dr.SRV_ID, 0);
                }

                m_hashtableBL.Clear();
                foreach (T_SERVER_BLRow dr in T_SERVER_BL.Rows)
                {
                    m_hashtableBL.Add(dr.SRV_ID, 0);
                }

                Logger.Instance.WriteInformation("Ended", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
        #region Events
        private void m_timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                m_timer.Stop();

                if (Settings.Default.DoValidateIPLatLng)
                {
                    DoValidateIPLatLng();
                }

                using (com.dp38745.www.LoggerWS wsLogger = new com.dp38745.www.LoggerWS())
                {
                    wsLogger.PingAsync();
                }
                using (com.dp68457.www.SmtpWS wsSmtp = new com.dp68457.www.SmtpWS())
                {
                    wsSmtp.PingAsync();
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            finally
            {
                m_timer.Start();
            }
        }
        #endregion
        #region Session
        public int SessionCount
        {
            get
            {
                return m_iSessionCount;
            }
        }
        public void IncreaseSession()
        {
            m_iSessionCount++;
        }
        public void DecreaseSession()
        {
            m_iSessionCount--;
        }
        #endregion
        #region T_FB_LOCALE_TYPE
        public string GetLocale(string p_strFBLocale)
        {
            foreach (T_FB_LOCALE_TYPERow dr in this.T_FB_LOCALE_TYPE.Rows)
            {
                if (dr.FBL_FB_LOCALE == p_strFBLocale)
                {
                    return dr.FBL_LOCALE;
                }
            }

            return "en";
        }
        #endregion
        #region T_SERVER
        public int GetIISServerID(string p_strIP)
        {
            int iResult = -1;

            foreach (PT_SERVERSelectBySRV_SERVER_TYPE_IISRow dr in PT_SERVERSelectBySRV_SERVER_TYPE_IIS.Rows)
            {
                if (dr.IP == p_strIP)
                {
                    iResult = dr.SRV_ID;
                    break;
                }
            }

            return iResult;
        }
        public int GetBLServerID(string p_strIP)
        {
            int iResult = -1;

            foreach (PT_SERVERSelectBySRV_SERVER_TYPE_BLRow dr in PT_SERVERSelectBySRV_SERVER_TYPE_BL.Rows)
            {
                if (dr.IP == p_strIP)
                {
                    iResult = dr.SRV_ID;
                    break;
                }
            }

            return iResult;
        }
        #endregion
        #region T_IP_LAT_LNG
        private void DoValidateIPLatLng()
        {
            try
            {
                T_IP_LAT_LNG_Validate.Clear();
                procPT_IP_LAT_LNGSelectTopNToValidate.LoadDataSet(this, T_IP_LAT_LNG_Validate.TableName, 50);

                foreach (T_IP_LAT_LNG_ValidateRow dr in T_IP_LAT_LNG_Validate.Rows)
                {
                    Logger.Instance.Write(dr, MethodBase.GetCurrentMethod(), Environment.MachineName);

                    string strIP = MADA.Common.Net.IP.ToString(dr.IPL_IP);
                    Location location = LocationHandler.GetLocation(Environment.MachineName, strIP);
                    Logger.Instance.WriteInformation("location:" + location.ToString(), MethodBase.GetCurrentMethod(), Environment.MachineName);

                    int iIISServer = ApplicationHandler.Instance.GetIISServerID(location);
                    Logger.Instance.WriteInformation("iIISServer:" + iIISServer, MethodBase.GetCurrentMethod(), Environment.MachineName);

                    int iBLServer = ApplicationHandler.Instance.GetBLServerID(location);
                    Logger.Instance.WriteInformation("iBLServer:" + iBLServer, MethodBase.GetCurrentMethod(), Environment.MachineName);

                    procAPT_IP_LAT_LNGUpdateByIPL_IP.ExecuteNonQuery(iBLServer, iIISServer, dr.IPL_IP, dr.IPL_LAT, dr.IPL_LNG, false);
                    Logger.Instance.WriteInformation("IPL_IP updated:" + dr.IPL_IP, MethodBase.GetCurrentMethod(), Environment.MachineName);
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        public int GetIISServerID(Location p_location)
        {
            int iResult;

            try
            {
                Logger.Instance.WriteInformation("Started", MethodBase.GetCurrentMethod(), Environment.MachineName);

                Logger.Instance.WriteInformation("p_location:" + p_location.ToString(), MethodBase.GetCurrentMethod(), Environment.MachineName);

                // get list of servers ordered by distnace from p_location
                SortedList sortedList = new SortedList();
                foreach (T_SERVER_IISRow dr in T_SERVER_IIS.Rows)
                {
                    double distance = GPS.Distance(p_location.GetLatLng, new LatLng(Double.Parse(dr.SRV_HOST_LAT.ToString()), Double.Parse(dr.SRV_HOST_LNG.ToString())),
                        DistanceUnitsEnum.Kilometers);

                    sortedList.Add(distance, dr.SRV_ID);
                }
                Logger.Instance.Write(sortedList, MethodBase.GetCurrentMethod(), Environment.MachineName);

                // get max number of servers in perimeter to check for min users count
                int iMaxIISServers = sortedList.Count;
                if (iMaxIISServers > Settings.Default.MaxIISServers)
                {
                    iMaxIISServers = Settings.Default.MaxIISServers;
                }

                // get server in perimeter with min number of users count
                int iMinServerID = T_SERVER_IIS[0].SRV_ID;
                int iMinUsersCount = int.MaxValue;
                int iServerID = iMinServerID;
                int iUsersCount = iMinUsersCount;
                for (int i = 0; i < iMaxIISServers; i++)
                {
                    iServerID = (int)sortedList.GetByIndex(i);
                    iUsersCount = (int)m_hashtableIIS[iServerID];
                    if (iUsersCount < iMinUsersCount)
                    {
                        iMinServerID = iServerID;
                        iMinUsersCount = iUsersCount;
                    }
                }
                Logger.Instance.WriteInformation("iMinServerID:" + iMinServerID, MethodBase.GetCurrentMethod(), Environment.MachineName);
                iResult = iMinServerID;

                Logger.Instance.WriteInformation("Ended", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                iResult = T_SERVER_IIS[0].SRV_ID;
            }

            return iResult;
        }
        public int GetBLServerID(Location p_location)
        {
            int iResult;

            try
            {
                Logger.Instance.WriteInformation("Started", MethodBase.GetCurrentMethod(), Environment.MachineName);

                Logger.Instance.WriteInformation("p_location:" + p_location.ToString(), MethodBase.GetCurrentMethod(), Environment.MachineName);

                // get list of servers ordered by distnace from p_location
                SortedList sortedList = new SortedList();
                foreach (T_SERVER_BLRow dr in T_SERVER_BL.Rows)
                {
                    double distance = GPS.Distance(p_location.GetLatLng, new LatLng(Double.Parse(dr.SRV_HOST_LAT.ToString()), Double.Parse(dr.SRV_HOST_LNG.ToString())),
                        DistanceUnitsEnum.Kilometers);

                    sortedList.Add(distance, dr.SRV_ID);
                }
                Logger.Instance.Write(sortedList, MethodBase.GetCurrentMethod(), Environment.MachineName);

                // get max number of servers in perimeter to check for min users count
                int iMaxBLServers = sortedList.Count;
                if (iMaxBLServers > Settings.Default.MaxBLServers)
                {
                    iMaxBLServers = Settings.Default.MaxBLServers;
                }

                // get server in perimeter with min number of users count
                int iMinServerID = T_SERVER_BL[0].SRV_ID;
                int iMinUsersCount = int.MaxValue;
                int iServerID = iMinServerID;
                int iUsersCount = iMinUsersCount;
                for (int i = 0; i < iMaxBLServers; i++)
                {
                    iServerID = (int)sortedList.GetByIndex(i);
                    iUsersCount = (int)m_hashtableBL[iServerID];
                    if (iUsersCount < iMinUsersCount)
                    {
                        iMinServerID = iServerID;
                        iMinUsersCount = iUsersCount;
                    }
                }
                Logger.Instance.WriteInformation("iMinServerID:" + iMinServerID, MethodBase.GetCurrentMethod(), Environment.MachineName);
                iResult = iMinServerID;

                Logger.Instance.WriteInformation("Ended", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                iResult = T_SERVER_BL[0].SRV_ID;
            }

            return iResult;
        }
        #endregion
        #region HashTables
        public void RefresgIISUsersCount()
        {
            try
            {
                lock (m_hashtableIIS)
                {
                    IDictionaryEnumerator enm = m_hashtableIIS.GetEnumerator();
                    while (enm.MoveNext())
                    {
                        object o2 = enm.Key;
                        int i2 = (int)o2;
                        PT_SERVERSelectBySRV_SERVER_TYPE_IISRow dr = this.PT_SERVERSelectBySRV_SERVER_TYPE_IIS.FindBySRV_ID(i2);
                        object o1 = enm.Value;
                        string str1 = o1.ToString();
                        dr.UsersCount = str1;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        public void SetIISUsersCount(int p_iIISServerID, int p_iUsersCount)
        {
            try
            {
                Logger.Instance.WriteInformation("IISServerID:" + p_iIISServerID + " UsersCount:" + p_iUsersCount, MethodBase.GetCurrentMethod(), Environment.MachineName);
                lock (m_hashtableIIS)
                {
                    m_hashtableIIS[p_iIISServerID] = p_iUsersCount;
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }

        public void RefresgBLUsersCount()
        {
            try
            {
                lock (m_hashtableBL)
                {
                    IDictionaryEnumerator enm = m_hashtableBL.GetEnumerator();
                    while (enm.MoveNext())
                    {
                        object o2 = enm.Key;
                        int i2 = (int)o2;
                        PT_SERVERSelectBySRV_SERVER_TYPE_BLRow dr = this.PT_SERVERSelectBySRV_SERVER_TYPE_BL.FindBySRV_ID(i2);
                        object o1 = enm.Value;
                        string str1 = o1.ToString();
                        dr.UsersCount = str1;
                    }
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        public void SetBLUsersCount(int p_iBLServerID, int p_iUsersCount)
        {
            try
            {
                Logger.Instance.WriteInformation("IISServerID:" + p_iBLServerID + " UsersCount:" + p_iUsersCount, MethodBase.GetCurrentMethod(), Environment.MachineName);
                lock (m_hashtableBL)
                {
                    m_hashtableBL[p_iBLServerID] = p_iUsersCount;
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
    }
}