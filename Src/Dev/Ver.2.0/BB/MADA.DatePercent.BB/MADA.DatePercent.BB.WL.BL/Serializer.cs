using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MADA.Log.Api.Net;
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.SPs;
using System.Reflection;

namespace MADA.DatePercent.BB.WL.BL
{
    public class Serializer
    {
        private Serializer()
        {
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
    }
}