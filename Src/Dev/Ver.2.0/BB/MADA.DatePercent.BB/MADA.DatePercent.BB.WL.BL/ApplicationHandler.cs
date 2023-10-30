using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using System.Data;
using System.Timers;
using System.Data.Common;
using System;
using MADA.Log.Api.Net;
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.Tables;
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.SPs;
using System.Reflection;

namespace MADA.DatePercent.BB.WL.BL
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
        private Database m_db;
        private DbConnection m_con;

        private Timer m_timer;

        private SqlCommand m_cmdLogonCounter;
        private int m_iLogonCounter;

        public DataSet m_dsFlexApplication = null;

        private int m_iSerializerKey1 = -1;
        private int m_iSerializerKey2 = -1;

        Random m_random = new Random(Environment.TickCount);
        #endregion
        #region Methods
        private void Init()
        {
            try
            {
                Logger.Instance.WriteProcess("Started", MethodBase.GetCurrentMethod(), Environment.MachineName);

                m_db = DatabaseFactory.CreateDatabase();
                m_con = m_db.CreateConnection();
                m_con.Open();

                m_timer = new Timer();
                m_timer.Interval = 1000;
                m_timer.Elapsed += new ElapsedEventHandler(m_timer_Elapsed);

                m_cmdLogonCounter = new SqlCommand();
                m_cmdLogonCounter.CommandText = procPT_LOGONCount._Name;
                m_cmdLogonCounter.CommandType = CommandType.StoredProcedure;

                m_timer.Start();

                Logger.Instance.WriteProcess("Ended", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                MADA.Common.Net.Mail.SendEMail("DATEPERCENT CRITICAL",
                    "<hr/>MADA.DatePercent.BL::ApplicationHandler::Init()<hr/>Failed to connect to the database through Microsoft DataApplicationBlock<hr/>web.config is missing or set to localhost?<hr/>Exception='" + ex.Message + "'<hr/>");
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }

        public void Refresh()
        {
            Logger.Instance.WriteProcess("Started", MethodBase.GetCurrentMethod(), Environment.MachineName);

            string strTableName = string.Empty;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                this.Clear();

                foreach (DataTable dt in this.Tables)
                {
                    strTableName = dt.TableName;

                    switch (dt.TableName)
                    {
                        case "Email":                   //
                        case "DatePercent_T_USER":      // not a database table, I use this iN the contact fetcher worker
                            break;
                        default:
                            cmd.CommandText = "SELECT * from " + dt.TableName;
                            m_db.LoadDataSet(cmd, this, dt.TableName);
                            break;
                    }

                    Logger.Instance.WriteInformation("Table " + dt.TableName + "loaded", MethodBase.GetCurrentMethod(), Environment.MachineName);
                }

                RefreshLogonCounter();
                GenearteNewKeysSet1();
                procAPT_USERSelectByUSR_UID.LoadDataSet(this, this.DatePercent_T_USER.TableName, "EFCCA098-D661-4CD5-99EF-E9AAD2591318");

                Logger.Instance.WriteProcess("Ended", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.WriteCritical("ApplicationHandler Table loadeing failed at table:" + strTableName + ". " + ex.Message, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        public void RefershT_DOMAIN_TYPE_ENUM()
        {
            try
            {
                ApplicationHandler.Instance.T_DOMAIN_TYPE_ENUM.Clear();
                procAPT_DOMAIN_TYPE_ENUMSelect.LoadDataSet(ApplicationHandler.Instance, tblT_DOMAIN_TYPE_ENUM._Name);

                Logger.Instance.WriteInformation("RefershT_DOMAIN_TYPE_ENUM", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
        #region Events
        void m_timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                RefreshLogonCounter();
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
        #region Logon Counter
        public int LogonCounter
        {
            get
            {
                if (m_iLogonCounter < 3000)
                {
                    return m_random.Next(3000, 3010);
                }
                else
                {
                    return m_iLogonCounter;
                }
            }
            set
            {
                m_iLogonCounter = value;
            }
        }

        public void RefreshLogonCounter()
        {
            try
            {
                LogonCounter = (int)m_db.ExecuteScalar(m_cmdLogonCounter);
            }
            catch
            {
                // T_LOGON is empty so return of cmd is null, probably some server error, don't update the logon counter
            }
        }
        #endregion
        #region DatePercentUser
        public DatePercent_T_USERRow DatePercentUser
        {
            get
            {
                try
                {
                    return DatePercent_T_USER[0];
                }
                catch
                {
                    Logger.Instance.WriteCritical("RONNIE: Ronnie's UID (EFCCA098-D661-4CD5-99EF-E9AAD2591318) is missing in the database.", MethodBase.GetCurrentMethod(), Environment.MachineName);
                    procAPT_USERSelectByUSR_UID.LoadDataSet(this, this.DatePercent_T_USER.TableName, "EFCCA098-D661-4CD5-99EF-E9AAD2591318");//Ronnie
                    return null;
                }
            }
        }
        public int DatePercentUserID
        {
            get
            {
                return DatePercentUser.USR_ID;
            }
        }
        #endregion
        #region T_SETTING
        public int MaxRowsOnSPSelect
        {
            get
            {
                return this.T_SETTING[0].SET_MAX_ROWS_ON_SP_SELECT;
            }
        }
        #endregion
        #region ContactFetcher.Email
        public void AddEmailCredentials(string p_strUserName, string p_strPassword, int p_iUserID, string p_strSecretKey)
        {
            this.Email.AddEmailRow(p_strUserName, p_strPassword, p_iUserID, p_strSecretKey);
        }
        public int GetEmailCount
        {
            get
            {
                return this.Email.Count;
            }
        }
        public EmailRow GetEmail()
        {
            if (GetEmailCount == 0)
            {
                return null;
            }
            else
            {
                return Email[0];
            }
        }
        public void RemoveEmail(EmailRow p_drEmail)
        {
            this.Email.RemoveEmailRow(p_drEmail);
        }
        #endregion
        #region T_SERIALIZER
        public string SerializerKey1
        {
            get
            {
                if (m_iSerializerKey1 == -1)
                {
                    Random random = new Random(System.Environment.TickCount);
                    m_iSerializerKey1 = random.Next(0, 500);
                }

                return "_" + m_iSerializerKey1++;
            }
        }
        public string SerializerKey2
        {
            get
            {
                if (m_iSerializerKey2 == -1)
                {
                    Random random = new Random(System.Environment.TickCount * 2);
                    m_iSerializerKey2 = random.Next(0, 500);
                }

                return "_" + m_iSerializerKey2++;
            }
        }
        private void GenearteNewKeysSet1()
        {
            m_iSerializerKey1 = -1;

            foreach (T_SERIALIZERRow dr in T_SERIALIZER.Rows)
            {
                dr.SRL_KEY_1 = SerializerKey1;
            }
        }
        private void GenearteNewKeysSet2()
        {
            m_iSerializerKey1 = -2;

            foreach (T_SERIALIZERRow dr in T_SERIALIZER.Rows)
            {
                dr.SRL_KEY_2 = SerializerKey2;
            }
        }
        #endregion
        #region Tables
        public static T_LIST_TYPE_ENUMRow GetListTypeEnumRow(T_LIST_TYPE_ENUM p_enmListType)
        {
            return Instance.T_LIST_TYPE_ENUM.FindByLTT_CODE((int)p_enmListType);
        }

        public static int T_PROP_SEX_TYPE_ENUMCount()
        {
            return Instance.T_PROP_SEX_TYPE_ENUM.Rows.Count;
        }
        public static int T_PROP_STATUS_TYPECount()
        {
            return Instance.T_PROP_STATUS_TYPE.Rows.Count;
        }
        public static int T_PROP_RELIGION_TYPECount()
        {
            return Instance.T_PROP_RELIGION_TYPE.Rows.Count;
        }
        public static int T_PROP_RACE_TYPECount()
        {
            return Instance.T_PROP_RACE_TYPE.Rows.Count;
        }
        public static int T_PROP_EDUCATION_TYPECount()
        {
            return Instance.T_PROP_EDUCATION_TYPE.Rows.Count;
        }
        public static int T_LINK_TYPE_ENUMCount()
        {
            return Instance.T_LINK_TYPE_ENUM.Rows.Count;
        }

        public static int T_PROP_AGE_RANGE_TYPEMin()
        {
            return Instance.T_PROP_AGE_RANGE_TYPE[0].AGR_CODE;
        }
        public static int T_PROP_AGE_RANGE_TYPEMax()
        {
            return Instance.T_PROP_AGE_RANGE_TYPE[Instance.T_PROP_AGE_RANGE_TYPE.Rows.Count - 1].AGR_CODE;
        }

        public static int T_PROP_HEIGHT_TYPEMin()
        {
            return Instance.T_PROP_HEIGHT_TYPE[0].HGT_CODE;
        }
        public static int T_PROP_HEIGHT_TYPEMax()
        {
            return Instance.T_PROP_HEIGHT_TYPE[Instance.T_PROP_HEIGHT_TYPE.Rows.Count - 1].HGT_CODE;
        }

        public static int T_PROP_WEIGHT_TYPEMin()
        {
            return Instance.T_PROP_WEIGHT_TYPE[0].WGT_CODE;
        }
        public static int T_PROP_WEIGHT_TYPEMax()
        {
            return Instance.T_PROP_WEIGHT_TYPE[Instance.T_PROP_WEIGHT_TYPE.Rows.Count - 1].WGT_CODE;
        }
        #endregion
    }
}