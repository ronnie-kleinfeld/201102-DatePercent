//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by the Database Schema tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
//
//     Exception should be handled in a higher layer.
//
//     generation time: 27/12/2011 08:42
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.SPs
{
public class procPT_RMNDeleteLost
{
public const string _Name = "PT_RMNDeleteLost";
public const string _Caption = "PT_ RMNDelete Lost";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_RMNDeleteLost";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
}
public static int ExecuteNonQuery(
)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand();
int iResult = db.ExecuteNonQuery(cmd);

return iResult;
}
catch (System.Exception ex)
{
MADA.DatePercent.BB.WL.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static int ExecuteNonQuery(
Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand();
int iResult = p_db.ExecuteNonQuery(cmd, p_trn);

return iResult;
}
catch (System.Exception ex)
{
MADA.DatePercent.BB.WL.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
