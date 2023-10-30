//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by the Database Schema tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
//
//     Exception should be handled in a higher layer.
//
//     generation time: 20/12/2011 16:10
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MADA.DatePercent.SMTP.DBS.dbSmtpDB.SPs
{
public class procsp_creatediagram
{
public const string _Name = "sp_creatediagram";
public const string _Caption = "sp_creatediagram";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "sp_creatediagram";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
byte[] p_a_btdefinition, string p_strdiagramname, System.Nullable<int> p_iowner_id, System.Nullable<int> p_iversion)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "sp_creatediagram";
SqlParameterCollection(cmd.Parameters, p_a_btdefinition, p_strdiagramname, p_iowner_id, p_iversion);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(pardefinition._SqlParameter());
p_oSqlParameterCollection.Add(pardiagramname._SqlParameter());
p_oSqlParameterCollection.Add(parowner_id._SqlParameter());
p_oSqlParameterCollection.Add(parversion._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, byte[] p_a_btdefinition, string p_strdiagramname, System.Nullable<int> p_iowner_id, System.Nullable<int> p_iversion)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(pardefinition._SqlParameter(p_a_btdefinition));
p_oSqlParameterCollection.Add(pardiagramname._SqlParameter(p_strdiagramname));
p_oSqlParameterCollection.Add(parowner_id._SqlParameter(p_iowner_id));
p_oSqlParameterCollection.Add(parversion._SqlParameter(p_iversion));
}
public class pardefinition
{
public const string _Name = "@definition";
public const string _Caption = "@definition";
public const string _ParentName = "sp_creatediagram";
public const SqlDbType _SqlDbType = SqlDbType.VarBinary;
public const Int32 _Length = -1;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "sp_creatediagram.DefaultView.[0].@definition";
public const string _BindDataReader = "[@definition]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@definition", -1, -1, -1, SqlDbType.VarBinary, "byte[]", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(byte[] Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@definition", -1, -1, -1, SqlDbType.VarBinary, "byte[]", ParameterDirection.Input, true, false, "", Value);
}
}
public class pardiagramname
{
public const string _Name = "@diagramname";
public const string _Caption = "@diagramname";
public const string _ParentName = "sp_creatediagram";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 128;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "sp_creatediagram.DefaultView.[0].@diagramname";
public const string _BindDataReader = "[@diagramname]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@diagramname", 128, -1, 128, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@diagramname", 128, -1, 128, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parowner_id
{
public const string _Name = "@owner_id";
public const string _Caption = "@owner_id";
public const string _ParentName = "sp_creatediagram";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "sp_creatediagram.DefaultView.[0].@owner_id";
public const string _BindDataReader = "[@owner_id]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@owner_id", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@owner_id", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parversion
{
public const string _Name = "@version";
public const string _Caption = "@version";
public const string _ParentName = "sp_creatediagram";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "sp_creatediagram.DefaultView.[0].@version";
public const string _BindDataReader = "[@version]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@version", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@version", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class indefinition : pardefinition {}
public class indiagramname : pardiagramname {}
public class inowner_id : parowner_id {}
public class inversion : parversion {}
public static int ExecuteNonQuery(
byte[] p_a_btdefinition, string p_strdiagramname, System.Nullable<int> p_iowner_id, System.Nullable<int> p_iversion)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_a_btdefinition, p_strdiagramname, p_iowner_id, p_iversion);
int iResult = db.ExecuteNonQuery(cmd);

return iResult;
}
catch (System.Exception ex)
{
MADA.DatePercent.SMTP.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static int ExecuteNonQuery(
byte[] p_a_btdefinition, string p_strdiagramname, System.Nullable<int> p_iowner_id, System.Nullable<int> p_iversion,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_a_btdefinition, p_strdiagramname, p_iowner_id, p_iversion);
int iResult = p_db.ExecuteNonQuery(cmd, p_trn);

return iResult;
}
catch (System.Exception ex)
{
MADA.DatePercent.SMTP.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
