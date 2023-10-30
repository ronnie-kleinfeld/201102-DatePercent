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
public class procPT_RMNInsertInto
{
public const string _Name = "PT_RMNInsertInto";
public const string _Caption = "PT_ RMNInsert Into";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_RMNInsertInto";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
System.Nullable<int> p_iDetailsID, System.Nullable<int> p_iRMN_ID, System.Nullable<int> p_iRMN_RMT_TYPE, System.Nullable<DateTime> p_dtRMN_SENT_DATETIME, string p_strRMN_TEXT, System.Nullable<int> p_iSessionID)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_RMNInsertInto";
SqlParameterCollection(cmd.Parameters, p_iDetailsID, p_iRMN_ID, p_iRMN_RMT_TYPE, p_dtRMN_SENT_DATETIME, p_strRMN_TEXT, p_iSessionID);
return cmd;
}
public static void SqlCommandOutput(
System.Data.SqlClient.SqlCommand p_cmd,
out object p_iRMN_ID)
{
p_iRMN_ID = p_cmd.Parameters["@RMN_ID"].Value;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parDetailsID._SqlParameter());
p_oSqlParameterCollection.Add(parRMN_ID._SqlParameter());
p_oSqlParameterCollection.Add(parRMN_RMT_TYPE._SqlParameter());
p_oSqlParameterCollection.Add(parRMN_SENT_DATETIME._SqlParameter());
p_oSqlParameterCollection.Add(parRMN_TEXT._SqlParameter());
p_oSqlParameterCollection.Add(parSessionID._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, System.Nullable<int> p_iDetailsID, System.Nullable<int> p_iRMN_ID, System.Nullable<int> p_iRMN_RMT_TYPE, System.Nullable<DateTime> p_dtRMN_SENT_DATETIME, string p_strRMN_TEXT, System.Nullable<int> p_iSessionID)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parDetailsID._SqlParameter(p_iDetailsID));
p_oSqlParameterCollection.Add(parRMN_ID._SqlParameter());
p_oSqlParameterCollection.Add(parRMN_RMT_TYPE._SqlParameter(p_iRMN_RMT_TYPE));
p_oSqlParameterCollection.Add(parRMN_SENT_DATETIME._SqlParameter(p_dtRMN_SENT_DATETIME));
p_oSqlParameterCollection.Add(parRMN_TEXT._SqlParameter(p_strRMN_TEXT));
p_oSqlParameterCollection.Add(parSessionID._SqlParameter(p_iSessionID));
}
public class parDetailsID
{
public const string _Name = "@DetailsID";
public const string _Caption = "@ Details ID";
public const string _ParentName = "PT_RMNInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_RMNInsertInto.DefaultView.[0].@DetailsID";
public const string _BindDataReader = "[@DetailsID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@DetailsID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@DetailsID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parRMN_ID
{
public const string _Name = "@RMN_ID";
public const string _Caption = "@ RMN_ ID";
public const string _ParentName = "PT_RMNInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_RMNInsertInto.DefaultView.[0].@RMN_ID";
public const string _BindDataReader = "[@RMN_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Output;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameter("@RMN_ID", 10, 0, 4, SqlDbType.Int, ParameterDirection.Output, true);
}
}
public class parRMN_RMT_TYPE
{
public const string _Name = "@RMN_RMT_TYPE";
public const string _Caption = "@ RMN_ RMT_ TYPE";
public const string _ParentName = "PT_RMNInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_RMNInsertInto.DefaultView.[0].@RMN_RMT_TYPE";
public const string _BindDataReader = "[@RMN_RMT_TYPE]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@RMN_RMT_TYPE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@RMN_RMT_TYPE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parRMN_SENT_DATETIME
{
public const string _Name = "@RMN_SENT_DATETIME";
public const string _Caption = "@ RMN_ SENT_ DATETIME";
public const string _ParentName = "PT_RMNInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.DateTime;
public const Int32 _Length = 8;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_RMNInsertInto.DefaultView.[0].@RMN_SENT_DATETIME";
public const string _BindDataReader = "[@RMN_SENT_DATETIME]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@RMN_SENT_DATETIME", 23, 3, 8, SqlDbType.DateTime, "DateTime", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<DateTime> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@RMN_SENT_DATETIME", 23, 3, 8, SqlDbType.DateTime, "DateTime", ParameterDirection.Input, true, false, "", Value);
}
}
public class parRMN_TEXT
{
public const string _Name = "@RMN_TEXT";
public const string _Caption = "@ RMN_ TEXT";
public const string _ParentName = "PT_RMNInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_RMNInsertInto.DefaultView.[0].@RMN_TEXT";
public const string _BindDataReader = "[@RMN_TEXT]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@RMN_TEXT", 2000, -1, 2000, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@RMN_TEXT", 2000, -1, 2000, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSessionID
{
public const string _Name = "@SessionID";
public const string _Caption = "@ Session ID";
public const string _ParentName = "PT_RMNInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_RMNInsertInto.DefaultView.[0].@SessionID";
public const string _BindDataReader = "[@SessionID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SessionID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SessionID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class inDetailsID : parDetailsID {}
public class inRMN_RMT_TYPE : parRMN_RMT_TYPE {}
public class inRMN_SENT_DATETIME : parRMN_SENT_DATETIME {}
public class inRMN_TEXT : parRMN_TEXT {}
public class inSessionID : parSessionID {}
public class outRMN_ID : parRMN_ID {}
public static int ExecuteNonQuery(
System.Nullable<int> p_iDetailsID, System.Nullable<int> p_iRMN_ID, System.Nullable<int> p_iRMN_RMT_TYPE, System.Nullable<DateTime> p_dtRMN_SENT_DATETIME, string p_strRMN_TEXT, System.Nullable<int> p_iSessionID,out object p_iRMN_IDOut)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_iDetailsID, p_iRMN_ID, p_iRMN_RMT_TYPE, p_dtRMN_SENT_DATETIME, p_strRMN_TEXT, p_iSessionID);
int iResult = db.ExecuteNonQuery(cmd);
SqlCommandOutput(cmd, out p_iRMN_IDOut);

return iResult;
}
catch (System.Exception ex)
{
MADA.DatePercent.BB.WL.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static int ExecuteNonQuery(
System.Nullable<int> p_iDetailsID, System.Nullable<int> p_iRMN_ID, System.Nullable<int> p_iRMN_RMT_TYPE, System.Nullable<DateTime> p_dtRMN_SENT_DATETIME, string p_strRMN_TEXT, System.Nullable<int> p_iSessionID,out object p_iRMN_IDOut,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_iDetailsID, p_iRMN_ID, p_iRMN_RMT_TYPE, p_dtRMN_SENT_DATETIME, p_strRMN_TEXT, p_iSessionID);
int iResult = p_db.ExecuteNonQuery(cmd, p_trn);
SqlCommandOutput(cmd, out p_iRMN_IDOut);

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
