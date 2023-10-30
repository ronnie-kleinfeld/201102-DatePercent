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
public class procPT_USER_EMAILCountByUSE_EMAIL
{
public const string _Name = "PT_USER_EMAILCountByUSE_EMAIL";
public const string _Caption = "PT_ USER_ EMAILCount By USE_ EMAIL";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_USER_EMAILCountByUSE_EMAIL";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
string p_strUSE_EMAIL)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_USER_EMAILCountByUSE_EMAIL";
SqlParameterCollection(cmd.Parameters, p_strUSE_EMAIL);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUSE_EMAIL._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, string p_strUSE_EMAIL)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUSE_EMAIL._SqlParameter(p_strUSE_EMAIL));
}
public class parUSE_EMAIL
{
public const string _Name = "@USE_EMAIL";
public const string _Caption = "@ USE_ EMAIL";
public const string _ParentName = "PT_USER_EMAILCountByUSE_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_USER_EMAILCountByUSE_EMAIL.DefaultView.[0].@USE_EMAIL";
public const string _BindDataReader = "[@USE_EMAIL]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USE_EMAIL", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USE_EMAIL", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class inUSE_EMAIL : parUSE_EMAIL {}
public class rsPT_USER_EMAILCountByUSE_EMAIL
{
public const string _Name = "PT_USER_EMAILCountByUSE_EMAIL";
public const string _Caption = "PT_ USER_ EMAILCount By USE_ EMAIL";
public const string _ParentName = "PT_USER_EMAILCountByUSE_EMAIL";
public class slcColumn1
{
public const string _Name = "Column1";
public const string _Caption = "Column1";
public const string _ParentName = "PT_USER_EMAILCountByUSE_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,string p_strUSE_EMAIL)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_strUSE_EMAIL);
db.LoadDataSet(cmd, p_ds, p_strTableName);}
catch (System.Exception ex)
{
MADA.DatePercent.BB.WL.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,string p_strUSE_EMAIL,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_strUSE_EMAIL);
p_db.LoadDataSet(cmd, p_ds, p_strTableName, p_trn);}
catch (System.Exception ex)
{
MADA.DatePercent.BB.WL.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
