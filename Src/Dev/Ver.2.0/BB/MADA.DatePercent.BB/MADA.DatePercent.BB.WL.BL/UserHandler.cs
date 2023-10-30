using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Web;
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.SPs;

namespace MADA.DatePercent.BB.WL.BL
{
    public class UserHandler
    {
        public static int GetUserIDByUserUID(string p_strUserUID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection con = db.CreateConnection())
            {
                con.Open();
                try
                {
                    return (int)db.ExecuteScalar(procPT_USERSelectUSR_IDByUSR_UID.SqlCommand(p_strUserUID));
                }
                catch
                {
                    return -1;
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }
        }
        public static string GetUserUIDByUserID(int p_iUserID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection con = db.CreateConnection())
            {
                con.Open();
                try
                {
                    return db.ExecuteScalar(procPT_USERSelectUSR_UIDByUSR_ID.SqlCommand(p_iUserID)).ToString();
                }
                catch
                {
                    return string.Empty;
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }
        }
    }
}