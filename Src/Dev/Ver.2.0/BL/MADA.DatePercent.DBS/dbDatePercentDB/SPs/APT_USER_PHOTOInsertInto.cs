//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by the Database Schema tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
//
//     Exception should be handled in a higher layer.
//
//     generation time: 07/12/2011 12:25
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MADA.DatePercent.DBS.dbDatePercentDB.SPs
{
public class procAPT_USER_PHOTOInsertInto
{
public const string _Name = "APT_USER_PHOTOInsertInto";
public const string _Caption = "APT_ USER_ PHOTOInsert Into";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_USER_PHOTOInsertInto";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
System.Nullable<int> p_iUPH_ID, System.Nullable<bool> p_bUPH_IO_ERROR, string p_strUPH_ORIGINAL_URL, string p_strUPH_SMALL_URL, string p_strUPH_THUMB_URL, System.Nullable<int> p_iUPH_USER_ID)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_USER_PHOTOInsertInto";
SqlParameterCollection(cmd.Parameters, p_iUPH_ID, p_bUPH_IO_ERROR, p_strUPH_ORIGINAL_URL, p_strUPH_SMALL_URL, p_strUPH_THUMB_URL, p_iUPH_USER_ID);
return cmd;
}
public static void SqlCommandOutput(
System.Data.SqlClient.SqlCommand p_cmd,
out object p_iUPH_ID)
{
p_iUPH_ID = p_cmd.Parameters["@UPH_ID"].Value;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUPH_ID._SqlParameter());
p_oSqlParameterCollection.Add(parUPH_IO_ERROR._SqlParameter());
p_oSqlParameterCollection.Add(parUPH_ORIGINAL_URL._SqlParameter());
p_oSqlParameterCollection.Add(parUPH_SMALL_URL._SqlParameter());
p_oSqlParameterCollection.Add(parUPH_THUMB_URL._SqlParameter());
p_oSqlParameterCollection.Add(parUPH_USER_ID._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, System.Nullable<int> p_iUPH_ID, System.Nullable<bool> p_bUPH_IO_ERROR, string p_strUPH_ORIGINAL_URL, string p_strUPH_SMALL_URL, string p_strUPH_THUMB_URL, System.Nullable<int> p_iUPH_USER_ID)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUPH_ID._SqlParameter());
p_oSqlParameterCollection.Add(parUPH_IO_ERROR._SqlParameter(p_bUPH_IO_ERROR));
p_oSqlParameterCollection.Add(parUPH_ORIGINAL_URL._SqlParameter(p_strUPH_ORIGINAL_URL));
p_oSqlParameterCollection.Add(parUPH_SMALL_URL._SqlParameter(p_strUPH_SMALL_URL));
p_oSqlParameterCollection.Add(parUPH_THUMB_URL._SqlParameter(p_strUPH_THUMB_URL));
p_oSqlParameterCollection.Add(parUPH_USER_ID._SqlParameter(p_iUPH_USER_ID));
}
public class parUPH_ID
{
public const string _Name = "@UPH_ID";
public const string _Caption = "@ UPH_ ID";
public const string _ParentName = "APT_USER_PHOTOInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_PHOTOInsertInto.DefaultView.[0].@UPH_ID";
public const string _BindDataReader = "[@UPH_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Output;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameter("@UPH_ID", 10, 0, 4, SqlDbType.Int, ParameterDirection.Output, true);
}
}
public class parUPH_IO_ERROR
{
public const string _Name = "@UPH_IO_ERROR";
public const string _Caption = "@ UPH_ IO_ ERROR";
public const string _ParentName = "APT_USER_PHOTOInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = 1;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_PHOTOInsertInto.DefaultView.[0].@UPH_IO_ERROR";
public const string _BindDataReader = "[@UPH_IO_ERROR]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@UPH_IO_ERROR", 1, -1, 1, SqlDbType.Bit, "bool", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<bool> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@UPH_IO_ERROR", 1, -1, 1, SqlDbType.Bit, "bool", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUPH_ORIGINAL_URL
{
public const string _Name = "@UPH_ORIGINAL_URL";
public const string _Caption = "@ UPH_ ORIGINAL_ URL";
public const string _ParentName = "APT_USER_PHOTOInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_PHOTOInsertInto.DefaultView.[0].@UPH_ORIGINAL_URL";
public const string _BindDataReader = "[@UPH_ORIGINAL_URL]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@UPH_ORIGINAL_URL", 2000, -1, 2000, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@UPH_ORIGINAL_URL", 2000, -1, 2000, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUPH_SMALL_URL
{
public const string _Name = "@UPH_SMALL_URL";
public const string _Caption = "@ UPH_ SMALL_ URL";
public const string _ParentName = "APT_USER_PHOTOInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_PHOTOInsertInto.DefaultView.[0].@UPH_SMALL_URL";
public const string _BindDataReader = "[@UPH_SMALL_URL]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@UPH_SMALL_URL", 2000, -1, 2000, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@UPH_SMALL_URL", 2000, -1, 2000, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUPH_THUMB_URL
{
public const string _Name = "@UPH_THUMB_URL";
public const string _Caption = "@ UPH_ THUMB_ URL";
public const string _ParentName = "APT_USER_PHOTOInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_PHOTOInsertInto.DefaultView.[0].@UPH_THUMB_URL";
public const string _BindDataReader = "[@UPH_THUMB_URL]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@UPH_THUMB_URL", 2000, -1, 2000, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@UPH_THUMB_URL", 2000, -1, 2000, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUPH_USER_ID
{
public const string _Name = "@UPH_USER_ID";
public const string _Caption = "@ UPH_ USER_ ID";
public const string _ParentName = "APT_USER_PHOTOInsertInto";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_PHOTOInsertInto.DefaultView.[0].@UPH_USER_ID";
public const string _BindDataReader = "[@UPH_USER_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@UPH_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@UPH_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class inUPH_IO_ERROR : parUPH_IO_ERROR {}
public class inUPH_ORIGINAL_URL : parUPH_ORIGINAL_URL {}
public class inUPH_SMALL_URL : parUPH_SMALL_URL {}
public class inUPH_THUMB_URL : parUPH_THUMB_URL {}
public class inUPH_USER_ID : parUPH_USER_ID {}
public class outUPH_ID : parUPH_ID {}
public static int ExecuteNonQuery(
System.Nullable<int> p_iUPH_ID, System.Nullable<bool> p_bUPH_IO_ERROR, string p_strUPH_ORIGINAL_URL, string p_strUPH_SMALL_URL, string p_strUPH_THUMB_URL, System.Nullable<int> p_iUPH_USER_ID,out object p_iUPH_IDOut)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_iUPH_ID, p_bUPH_IO_ERROR, p_strUPH_ORIGINAL_URL, p_strUPH_SMALL_URL, p_strUPH_THUMB_URL, p_iUPH_USER_ID);
int iResult = db.ExecuteNonQuery(cmd);
SqlCommandOutput(cmd, out p_iUPH_IDOut);

return iResult;
}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static int ExecuteNonQuery(
System.Nullable<int> p_iUPH_ID, System.Nullable<bool> p_bUPH_IO_ERROR, string p_strUPH_ORIGINAL_URL, string p_strUPH_SMALL_URL, string p_strUPH_THUMB_URL, System.Nullable<int> p_iUPH_USER_ID,out object p_iUPH_IDOut,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_iUPH_ID, p_bUPH_IO_ERROR, p_strUPH_ORIGINAL_URL, p_strUPH_SMALL_URL, p_strUPH_THUMB_URL, p_iUPH_USER_ID);
int iResult = p_db.ExecuteNonQuery(cmd, p_trn);
SqlCommandOutput(cmd, out p_iUPH_IDOut);

return iResult;
}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
