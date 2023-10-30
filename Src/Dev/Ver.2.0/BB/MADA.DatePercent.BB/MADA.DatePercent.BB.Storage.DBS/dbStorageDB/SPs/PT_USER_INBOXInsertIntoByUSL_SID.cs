//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by the Database Schema tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
//
//     Exception should be handled in a higher layer.
//
//     generation time: 29/03/2012 14:43
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MADA.DatePercent.BB.Storage.DBS.dbStorageDB.SPs
{
public class procPT_USER_INBOXInsertIntoByUSL_SID
{
public const string _Name = "PT_USER_INBOXInsertIntoByUSL_SID";
public const string _Caption = "PT_ USER_ INBOXInsert Into By USL_ SID";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_USER_INBOXInsertIntoByUSL_SID";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
System.Nullable<int> p_iUSI_COMM_TYPE_CODE, System.Nullable<int> p_iUSI_PRESENT_CODE, string p_strUSI_TEXT, System.Nullable<int> p_iUSI_USER_ID, System.Nullable<int> p_iUSI_WINK_CODE, string p_strUSL_SID)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_USER_INBOXInsertIntoByUSL_SID";
SqlParameterCollection(cmd.Parameters, p_iUSI_COMM_TYPE_CODE, p_iUSI_PRESENT_CODE, p_strUSI_TEXT, p_iUSI_USER_ID, p_iUSI_WINK_CODE, p_strUSL_SID);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUSI_COMM_TYPE_CODE._SqlParameter());
p_oSqlParameterCollection.Add(parUSI_PRESENT_CODE._SqlParameter());
p_oSqlParameterCollection.Add(parUSI_TEXT._SqlParameter());
p_oSqlParameterCollection.Add(parUSI_USER_ID._SqlParameter());
p_oSqlParameterCollection.Add(parUSI_WINK_CODE._SqlParameter());
p_oSqlParameterCollection.Add(parUSL_SID._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, System.Nullable<int> p_iUSI_COMM_TYPE_CODE, System.Nullable<int> p_iUSI_PRESENT_CODE, string p_strUSI_TEXT, System.Nullable<int> p_iUSI_USER_ID, System.Nullable<int> p_iUSI_WINK_CODE, string p_strUSL_SID)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUSI_COMM_TYPE_CODE._SqlParameter(p_iUSI_COMM_TYPE_CODE));
p_oSqlParameterCollection.Add(parUSI_PRESENT_CODE._SqlParameter(p_iUSI_PRESENT_CODE));
p_oSqlParameterCollection.Add(parUSI_TEXT._SqlParameter(p_strUSI_TEXT));
p_oSqlParameterCollection.Add(parUSI_USER_ID._SqlParameter(p_iUSI_USER_ID));
p_oSqlParameterCollection.Add(parUSI_WINK_CODE._SqlParameter(p_iUSI_WINK_CODE));
p_oSqlParameterCollection.Add(parUSL_SID._SqlParameter(p_strUSL_SID));
}
public class parUSI_COMM_TYPE_CODE
{
public const string _Name = "@USI_COMM_TYPE_CODE";
public const string _Caption = "@ USI_ COMM_ TYPE_ CODE";
public const string _ParentName = "PT_USER_INBOXInsertIntoByUSL_SID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_USER_INBOXInsertIntoByUSL_SID.DefaultView.[0].@USI_COMM_TYPE_CODE";
public const string _BindDataReader = "[@USI_COMM_TYPE_CODE]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USI_COMM_TYPE_CODE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USI_COMM_TYPE_CODE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSI_PRESENT_CODE
{
public const string _Name = "@USI_PRESENT_CODE";
public const string _Caption = "@ USI_ PRESENT_ CODE";
public const string _ParentName = "PT_USER_INBOXInsertIntoByUSL_SID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_USER_INBOXInsertIntoByUSL_SID.DefaultView.[0].@USI_PRESENT_CODE";
public const string _BindDataReader = "[@USI_PRESENT_CODE]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USI_PRESENT_CODE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USI_PRESENT_CODE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSI_TEXT
{
public const string _Name = "@USI_TEXT";
public const string _Caption = "@ USI_ TEXT";
public const string _ParentName = "PT_USER_INBOXInsertIntoByUSL_SID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_USER_INBOXInsertIntoByUSL_SID.DefaultView.[0].@USI_TEXT";
public const string _BindDataReader = "[@USI_TEXT]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USI_TEXT", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USI_TEXT", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSI_USER_ID
{
public const string _Name = "@USI_USER_ID";
public const string _Caption = "@ USI_ USER_ ID";
public const string _ParentName = "PT_USER_INBOXInsertIntoByUSL_SID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_USER_INBOXInsertIntoByUSL_SID.DefaultView.[0].@USI_USER_ID";
public const string _BindDataReader = "[@USI_USER_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USI_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USI_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSI_WINK_CODE
{
public const string _Name = "@USI_WINK_CODE";
public const string _Caption = "@ USI_ WINK_ CODE";
public const string _ParentName = "PT_USER_INBOXInsertIntoByUSL_SID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_USER_INBOXInsertIntoByUSL_SID.DefaultView.[0].@USI_WINK_CODE";
public const string _BindDataReader = "[@USI_WINK_CODE]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USI_WINK_CODE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USI_WINK_CODE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSL_SID
{
public const string _Name = "@USL_SID";
public const string _Caption = "@ USL_ SID";
public const string _ParentName = "PT_USER_INBOXInsertIntoByUSL_SID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_USER_INBOXInsertIntoByUSL_SID.DefaultView.[0].@USL_SID";
public const string _BindDataReader = "[@USL_SID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USL_SID", 50, -1, 50, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USL_SID", 50, -1, 50, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class inUSI_COMM_TYPE_CODE : parUSI_COMM_TYPE_CODE {}
public class inUSI_PRESENT_CODE : parUSI_PRESENT_CODE {}
public class inUSI_TEXT : parUSI_TEXT {}
public class inUSI_USER_ID : parUSI_USER_ID {}
public class inUSI_WINK_CODE : parUSI_WINK_CODE {}
public class inUSL_SID : parUSL_SID {}
public static int ExecuteNonQuery(
System.Nullable<int> p_iUSI_COMM_TYPE_CODE, System.Nullable<int> p_iUSI_PRESENT_CODE, string p_strUSI_TEXT, System.Nullable<int> p_iUSI_USER_ID, System.Nullable<int> p_iUSI_WINK_CODE, string p_strUSL_SID)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_iUSI_COMM_TYPE_CODE, p_iUSI_PRESENT_CODE, p_strUSI_TEXT, p_iUSI_USER_ID, p_iUSI_WINK_CODE, p_strUSL_SID);
int iResult = db.ExecuteNonQuery(cmd);

return iResult;
}
catch (System.Exception ex)
{
MADA.DatePercent.BB.Storage.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static int ExecuteNonQuery(
System.Nullable<int> p_iUSI_COMM_TYPE_CODE, System.Nullable<int> p_iUSI_PRESENT_CODE, string p_strUSI_TEXT, System.Nullable<int> p_iUSI_USER_ID, System.Nullable<int> p_iUSI_WINK_CODE, string p_strUSL_SID,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_iUSI_COMM_TYPE_CODE, p_iUSI_PRESENT_CODE, p_strUSI_TEXT, p_iUSI_USER_ID, p_iUSI_WINK_CODE, p_strUSL_SID);
int iResult = p_db.ExecuteNonQuery(cmd, p_trn);

return iResult;
}
catch (System.Exception ex)
{
MADA.DatePercent.BB.Storage.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
