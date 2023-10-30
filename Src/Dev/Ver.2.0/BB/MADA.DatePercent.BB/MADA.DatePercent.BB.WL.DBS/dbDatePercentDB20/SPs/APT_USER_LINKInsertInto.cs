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
public class procAPT_USER_LINKInsertInto
{
public const string _Name = "APT_USER_LINKInsertInto";
public const string _Caption = "APT_ USER_ LINKInsert Into";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_USER_LINKInsertInto";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
System.Nullable<DateTime> p_dtULK_DATE_TIME, System.Nullable<int> p_iULK_DETAILS_USER_ID, System.Nullable<int> p_iULK_ID, System.Nullable<int> p_iULK_LINK_ACTION_TYPE, System.Nullable<int> p_iULK_LINK_TYPE, System.Nullable<int> p_iULK_USER_ID)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_USER_LINKInsertInto";
SqlParameterCollection(cmd.Parameters, p_dtULK_DATE_TIME, p_iULK_DETAILS_USER_ID, p_iULK_ID, p_iULK_LINK_ACTION_TYPE, p_iULK_LINK_TYPE, p_iULK_USER_ID);
return cmd;
}
public static void SqlCommandOutput(
System.Data.SqlClient.SqlCommand p_cmd,
out object p_iULK_ID)
{
p_iULK_ID = p_cmd.Parameters["@ULK_ID"].Value;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parULK_DATE_TIME._SqlParameter());
p_oSqlParameterCollection.Add(parULK_DETAILS_USER_ID._SqlParameter());
p_oSqlParameterCollection.Add(parULK_ID._SqlParameter());
p_oSqlParameterCollection.Add(parULK_LINK_ACTION_TYPE._SqlParameter());
p_oSqlParameterCollection.Add(parULK_LINK_TYPE._SqlParameter());
p_oSqlParameterCollection.Add(parULK_USER_ID._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, System.Nullable<DateTime> p_dtULK_DATE_TIME, System.Nullable<int> p_iULK_DETAILS_USER_ID, System.Nullable<int> p_iULK_ID, System.Nullable<int> p_iULK_LINK_ACTION_TYPE, System.Nullable<int> p_iULK_LINK_TYPE, System.Nullable<int> p_iULK_USER_ID)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parULK_DATE_TIME._SqlParameter(p_dtULK_DATE_TIME));
p_oSqlParameterCollection.Add(parULK_DETAILS_USER_ID._SqlParameter(p_iULK_DETAILS_USER_ID));
p_oSqlParameterCollection.Add(parULK_ID._SqlParameter());
p_oSqlParameterCollection.Add(parULK_LINK_ACTION_TYPE._SqlParameter(p_iULK_LINK_ACTION_TYPE));
p_oSqlParameterCollection.Add(parULK_LINK_TYPE._SqlParameter(p_iULK_LINK_TYPE));
p_oSqlParameterCollection.Add(parULK_USER_ID._SqlParameter(p_iULK_USER_ID));
}
public class parULK_DATE_TIME
{
public const string _Name = "@ULK_DATE_TIME";
public const string _Caption = "@ ULK_ DATE_ TIME";
public const string _ParentName = "APT_USER_LINKInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.DateTime;
public const Int32 _Length = 8;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_LINKInsertInto.DefaultView.[0].@ULK_DATE_TIME";
public const string _BindDataReader = "[@ULK_DATE_TIME]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@ULK_DATE_TIME", 23, 3, 8, SqlDbType.DateTime, "DateTime", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<DateTime> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@ULK_DATE_TIME", 23, 3, 8, SqlDbType.DateTime, "DateTime", ParameterDirection.Input, true, false, "", Value);
}
}
public class parULK_DETAILS_USER_ID
{
public const string _Name = "@ULK_DETAILS_USER_ID";
public const string _Caption = "@ ULK_ DETAILS_ USER_ ID";
public const string _ParentName = "APT_USER_LINKInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_LINKInsertInto.DefaultView.[0].@ULK_DETAILS_USER_ID";
public const string _BindDataReader = "[@ULK_DETAILS_USER_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@ULK_DETAILS_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@ULK_DETAILS_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parULK_ID
{
public const string _Name = "@ULK_ID";
public const string _Caption = "@ ULK_ ID";
public const string _ParentName = "APT_USER_LINKInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_LINKInsertInto.DefaultView.[0].@ULK_ID";
public const string _BindDataReader = "[@ULK_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Output;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameter("@ULK_ID", 10, 0, 4, SqlDbType.Int, ParameterDirection.Output, true);
}
}
public class parULK_LINK_ACTION_TYPE
{
public const string _Name = "@ULK_LINK_ACTION_TYPE";
public const string _Caption = "@ ULK_ LINK_ ACTION_ TYPE";
public const string _ParentName = "APT_USER_LINKInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_LINKInsertInto.DefaultView.[0].@ULK_LINK_ACTION_TYPE";
public const string _BindDataReader = "[@ULK_LINK_ACTION_TYPE]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@ULK_LINK_ACTION_TYPE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@ULK_LINK_ACTION_TYPE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parULK_LINK_TYPE
{
public const string _Name = "@ULK_LINK_TYPE";
public const string _Caption = "@ ULK_ LINK_ TYPE";
public const string _ParentName = "APT_USER_LINKInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_LINKInsertInto.DefaultView.[0].@ULK_LINK_TYPE";
public const string _BindDataReader = "[@ULK_LINK_TYPE]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@ULK_LINK_TYPE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@ULK_LINK_TYPE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parULK_USER_ID
{
public const string _Name = "@ULK_USER_ID";
public const string _Caption = "@ ULK_ USER_ ID";
public const string _ParentName = "APT_USER_LINKInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_LINKInsertInto.DefaultView.[0].@ULK_USER_ID";
public const string _BindDataReader = "[@ULK_USER_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@ULK_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@ULK_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class inULK_DATE_TIME : parULK_DATE_TIME {}
public class inULK_DETAILS_USER_ID : parULK_DETAILS_USER_ID {}
public class inULK_LINK_ACTION_TYPE : parULK_LINK_ACTION_TYPE {}
public class inULK_LINK_TYPE : parULK_LINK_TYPE {}
public class inULK_USER_ID : parULK_USER_ID {}
public class outULK_ID : parULK_ID {}
public static int ExecuteNonQuery(
System.Nullable<DateTime> p_dtULK_DATE_TIME, System.Nullable<int> p_iULK_DETAILS_USER_ID, System.Nullable<int> p_iULK_ID, System.Nullable<int> p_iULK_LINK_ACTION_TYPE, System.Nullable<int> p_iULK_LINK_TYPE, System.Nullable<int> p_iULK_USER_ID,out object p_iULK_IDOut)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_dtULK_DATE_TIME, p_iULK_DETAILS_USER_ID, p_iULK_ID, p_iULK_LINK_ACTION_TYPE, p_iULK_LINK_TYPE, p_iULK_USER_ID);
int iResult = db.ExecuteNonQuery(cmd);
SqlCommandOutput(cmd, out p_iULK_IDOut);

return iResult;
}
catch (System.Exception ex)
{
MADA.DatePercent.BB.WL.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static int ExecuteNonQuery(
System.Nullable<DateTime> p_dtULK_DATE_TIME, System.Nullable<int> p_iULK_DETAILS_USER_ID, System.Nullable<int> p_iULK_ID, System.Nullable<int> p_iULK_LINK_ACTION_TYPE, System.Nullable<int> p_iULK_LINK_TYPE, System.Nullable<int> p_iULK_USER_ID,out object p_iULK_IDOut,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_dtULK_DATE_TIME, p_iULK_DETAILS_USER_ID, p_iULK_ID, p_iULK_LINK_ACTION_TYPE, p_iULK_LINK_TYPE, p_iULK_USER_ID);
int iResult = p_db.ExecuteNonQuery(cmd, p_trn);
SqlCommandOutput(cmd, out p_iULK_IDOut);

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
