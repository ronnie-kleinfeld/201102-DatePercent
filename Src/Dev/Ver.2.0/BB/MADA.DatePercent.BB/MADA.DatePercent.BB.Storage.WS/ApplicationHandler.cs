using MADA.Log.Api.Net;
using System;
using MADA.DatePercent.SMTP.Api.Net;
using System.Reflection;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using MADA.DatePercent.BB.Storage.DBS.dbStorageDB.SPs;

namespace MADA.DatePercent.BB.Storage.WS
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

        public DataSet m_dsFlexApplication = null;

        private int m_iSessionCount;

        private int m_iSerializerKey1 = -1;
        private int m_iSerializerKey2 = -1;
        Random m_random = new Random(Environment.TickCount);
        #endregion
        #region Properties
        public DataSet FlexApplication
        {
            get
            {
                if (m_dsFlexApplication == null)
                {
                    m_dsFlexApplication = new DataSet();

                    string strColumnPrefix;
                    string strCodeColumn;
                    string strDescriptionColumn;

                    foreach (DataTable dt in this.Tables)
                    {
                        // flex ApplicationHandler requires only the following tables
                        switch (dt.TableName)
                        {
                            case "T_DISTANCE_UNITS_TYPE_ENUM":
                            case "T_SEX_TYPE_ENUM":
                            case "T_LOCALE_TYPE":
                                DataTable dtNew = dt.Copy();

                                strColumnPrefix = dt.Columns[0].ColumnName.Substring(0, 3);
                                strCodeColumn = strColumnPrefix + "_CODE";
                                strDescriptionColumn = strColumnPrefix + "_DESCRIPTION";

                                if (dtNew.Columns.Contains(strCodeColumn) && dtNew.Columns.Contains(strDescriptionColumn))
                                {
                                    dtNew.Columns.Add("label", typeof(string));
                                    dtNew.Columns.Add("data", typeof(string));

                                    foreach (DataRow dr in dtNew.Rows)
                                    {
                                        dr["data"] = dr[strCodeColumn];
                                        dr["label"] = dr[strDescriptionColumn];
                                    }
                                }

                                m_dsFlexApplication.Tables.Add(dtNew);
                                break;
                        }
                    }

                    m_dsFlexApplication = SerializeToFlex(ApplicationHandler.Instance.m_dsFlexApplication);

                    m_dsFlexApplication.Tables.Add(ApplicationHandler.Instance.T_SERIALIZER.Copy());
                    m_dsFlexApplication.AcceptChanges();
                }

                return m_dsFlexApplication;
            }
        }
        #endregion
        #region Class
        private void Init()
        {
            try
            {
                Logger.Instance.WriteProcess("Started", MethodBase.GetCurrentMethod(), Environment.MachineName);

                m_db = DatabaseFactory.CreateDatabase();
                m_con = m_db.CreateConnection();
                m_con.Open();

                Logger.Instance.WriteProcess("Ended", MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            catch (Exception ex)
            {
                Mailer.Instance.Compose(Environment.MachineName, Environment.MachineName, "rk@datepercent.com", Environment.MachineName, "DATEPERCENT CRITICAL",
                    "<hr/>MADA.DatePercent.BL::ApplicationHandler::Init()<hr/>Failed to connect to the database through Microsoft DataApplicationBlock<hr/>web.config is missing or set to localhost?<hr/>Exception='" + ex.Message + "'<hr/>");
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
        }
        #endregion
        #region Methods
        public void Refresh()
        {
            Logger.Instance.WriteProcess("Started", MethodBase.GetCurrentMethod(), Environment.MachineName);

            this.Clear();

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
                        case "mail":
                            break;
                        default:
                            cmd.CommandText = "SELECT * from " + dt.TableName;
                            m_db.LoadDataSet(cmd, this, dt.TableName);
                            break;
                    }

                    Logger.Instance.WriteInformation("Table " + dt.TableName + "loaded", MethodBase.GetCurrentMethod(), Environment.MachineName);
                    Logger.Instance.Write(dt, MethodBase.GetCurrentMethod(), Environment.MachineName);
                }

                GenearteNewKeysSet1();

                FlexApplication.Clear();
                m_dsFlexApplication = null;
                DataSet ds = FlexApplication;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.WriteCritical("ApplicationHandler Table loadeing failed at table:" + strTableName + ". " + ex.Message, MethodBase.GetCurrentMethod(), Environment.MachineName);
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }
            finally
            {
                Logger.Instance.WriteProcess("Ended", MethodBase.GetCurrentMethod(), Environment.MachineName);
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
        public static DataSet SerializeToFlex(System.Data.DataSet p_ds)
        {
            try
            {
                p_ds.AcceptChanges();

                ApplicationHandler.T_SERIALIZERRow drSerializer;

                // tables
                foreach (DataTable dt in p_ds.Tables)
                {
                    // columns
                    foreach (DataColumn dc in dt.Columns)
                    {
                        // columnName
                        drSerializer = ApplicationHandler.Instance.T_SERIALIZER.FindBySRL_DESCRIPTION(dc.ColumnName);
                        if (drSerializer == null)
                        {
                            procAPT_SERIALIZERInsertInto.ExecuteNonQuery(dc.ColumnName, "", "");

                            drSerializer = ApplicationHandler.Instance.T_SERIALIZER.NewT_SERIALIZERRow();
                            drSerializer.SRL_DESCRIPTION = dc.ColumnName;
                            drSerializer.SRL_KEY_1 = ApplicationHandler.Instance.SerializerKey1;
                            drSerializer.SRL_KEY_2 = ApplicationHandler.Instance.SerializerKey2;
                            ApplicationHandler.Instance.T_SERIALIZER.AddT_SERIALIZERRow(drSerializer);
                        }
                        dc.ColumnName = drSerializer.SRL_KEY_1;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
            }

            return p_ds;
        }
        #endregion
    }
}