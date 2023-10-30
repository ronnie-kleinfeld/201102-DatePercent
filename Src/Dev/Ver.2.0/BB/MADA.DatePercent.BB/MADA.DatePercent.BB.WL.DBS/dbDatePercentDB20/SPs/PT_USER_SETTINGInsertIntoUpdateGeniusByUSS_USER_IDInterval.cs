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
public class procPT_USER_SETTINGInsertIntoUpdateGeniusByUSS_USER_IDInterval
{
public const string _Name = "PT_USER_SETTINGInsertIntoUpdateGeniusByUSS_USER_IDInterval";
public const string _Caption = "PT_ USER_ SETTINGInsert Into Update Genius By USS_ USER_ IDInterval";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_USER_SETTINGInsertIntoUpdateGeniusByUSS_USER_IDInterval";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
System.Nullable<int> p_iIntervalHour, System.Nullable<int> p_iUSS_USER_ID)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_USER_SETTINGInsertIntoUpdateGeniusByUSS_USER_IDInterval";
SqlParameterCollection(cmd.Parameters, p_iIntervalHour, p_iUSS_USER_ID);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parIntervalHour._SqlParameter());
p_oSqlParameterCollection.Add(parUSS_USER_ID._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, System.Nullable<int> p_iIntervalHour, System.Nullable<int> p_iUSS_USER_ID)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parIntervalHour._SqlParameter(p_iIntervalHour));
p_oSqlParameterCollection.Add(parUSS_USER_ID._SqlParameter(p_iUSS_USER_ID));
}
public class parIntervalHour
{
public const string _Name = "@IntervalHour";
public const string _Caption = "@ Interval Hour";
public const string _ParentName = "PT_USER_SETTINGInsertIntoUpdateGeniusByUSS_USER_IDInterval";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_USER_SETTINGInsertIntoUpdateGeniusByUSS_USER_IDInterval.DefaultView.[0].@IntervalHour";
public const string _BindDataReader = "[@IntervalHour]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@IntervalHour", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@IntervalHour", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSS_USER_ID
{
public const string _Name = "@USS_USER_ID";
public const string _Caption = "@ USS_ USER_ ID";
public const string _ParentName = "PT_USER_SETTINGInsertIntoUpdateGeniusByUSS_USER_IDInterval";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_USER_SETTINGInsertIntoUpdateGeniusByUSS_USER_IDInterval.DefaultView.[0].@USS_USER_ID";
public const string _BindDataReader = "[@USS_USER_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USS_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USS_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class inIntervalHour : parIntervalHour {}
public class inUSS_USER_ID : parUSS_USER_ID {}
public static int ExecuteNonQuery(
System.Nullable<int> p_iIntervalHour, System.Nullable<int> p_iUSS_USER_ID)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_iIntervalHour, p_iUSS_USER_ID);
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
System.Nullable<int> p_iIntervalHour, System.Nullable<int> p_iUSS_USER_ID,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_iIntervalHour, p_iUSS_USER_ID);
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
