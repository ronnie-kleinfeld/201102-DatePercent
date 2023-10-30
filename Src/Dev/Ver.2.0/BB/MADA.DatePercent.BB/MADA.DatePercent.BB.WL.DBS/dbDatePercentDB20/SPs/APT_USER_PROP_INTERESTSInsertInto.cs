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
public class procAPT_USER_PROP_INTERESTSInsertInto
{
public const string _Name = "APT_USER_PROP_INTERESTSInsertInto";
public const string _Caption = "APT_ USER_ PROP_ INTERESTSInsert Into";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_USER_PROP_INTERESTSInsertInto";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
System.Nullable<int> p_iUIT_ID, System.Nullable<int> p_iUIT_PROP_INTERESTS_CODE, System.Nullable<int> p_iUIT_USER_ID)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_USER_PROP_INTERESTSInsertInto";
SqlParameterCollection(cmd.Parameters, p_iUIT_ID, p_iUIT_PROP_INTERESTS_CODE, p_iUIT_USER_ID);
return cmd;
}
public static void SqlCommandOutput(
System.Data.SqlClient.SqlCommand p_cmd,
out object p_iUIT_ID)
{
p_iUIT_ID = p_cmd.Parameters["@UIT_ID"].Value;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUIT_ID._SqlParameter());
p_oSqlParameterCollection.Add(parUIT_PROP_INTERESTS_CODE._SqlParameter());
p_oSqlParameterCollection.Add(parUIT_USER_ID._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, System.Nullable<int> p_iUIT_ID, System.Nullable<int> p_iUIT_PROP_INTERESTS_CODE, System.Nullable<int> p_iUIT_USER_ID)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUIT_ID._SqlParameter());
p_oSqlParameterCollection.Add(parUIT_PROP_INTERESTS_CODE._SqlParameter(p_iUIT_PROP_INTERESTS_CODE));
p_oSqlParameterCollection.Add(parUIT_USER_ID._SqlParameter(p_iUIT_USER_ID));
}
public class parUIT_ID
{
public const string _Name = "@UIT_ID";
public const string _Caption = "@ UIT_ ID";
public const string _ParentName = "APT_USER_PROP_INTERESTSInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_PROP_INTERESTSInsertInto.DefaultView.[0].@UIT_ID";
public const string _BindDataReader = "[@UIT_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Output;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameter("@UIT_ID", 10, 0, 4, SqlDbType.Int, ParameterDirection.Output, true);
}
}
public class parUIT_PROP_INTERESTS_CODE
{
public const string _Name = "@UIT_PROP_INTERESTS_CODE";
public const string _Caption = "@ UIT_ PROP_ INTERESTS_ CODE";
public const string _ParentName = "APT_USER_PROP_INTERESTSInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_PROP_INTERESTSInsertInto.DefaultView.[0].@UIT_PROP_INTERESTS_CODE";
public const string _BindDataReader = "[@UIT_PROP_INTERESTS_CODE]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@UIT_PROP_INTERESTS_CODE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@UIT_PROP_INTERESTS_CODE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUIT_USER_ID
{
public const string _Name = "@UIT_USER_ID";
public const string _Caption = "@ UIT_ USER_ ID";
public const string _ParentName = "APT_USER_PROP_INTERESTSInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_PROP_INTERESTSInsertInto.DefaultView.[0].@UIT_USER_ID";
public const string _BindDataReader = "[@UIT_USER_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@UIT_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@UIT_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class inUIT_PROP_INTERESTS_CODE : parUIT_PROP_INTERESTS_CODE {}
public class inUIT_USER_ID : parUIT_USER_ID {}
public class outUIT_ID : parUIT_ID {}
public static int ExecuteNonQuery(
System.Nullable<int> p_iUIT_ID, System.Nullable<int> p_iUIT_PROP_INTERESTS_CODE, System.Nullable<int> p_iUIT_USER_ID,out object p_iUIT_IDOut)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_iUIT_ID, p_iUIT_PROP_INTERESTS_CODE, p_iUIT_USER_ID);
int iResult = db.ExecuteNonQuery(cmd);
SqlCommandOutput(cmd, out p_iUIT_IDOut);

return iResult;
}
catch (System.Exception ex)
{
MADA.DatePercent.BB.WL.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static int ExecuteNonQuery(
System.Nullable<int> p_iUIT_ID, System.Nullable<int> p_iUIT_PROP_INTERESTS_CODE, System.Nullable<int> p_iUIT_USER_ID,out object p_iUIT_IDOut,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_iUIT_ID, p_iUIT_PROP_INTERESTS_CODE, p_iUIT_USER_ID);
int iResult = p_db.ExecuteNonQuery(cmd, p_trn);
SqlCommandOutput(cmd, out p_iUIT_IDOut);

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
