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
public class procAPT_USER_EMAILSelectByUSE_ID
{
public const string _Name = "APT_USER_EMAILSelectByUSE_ID";
public const string _Caption = "APT_ USER_ EMAILSelect By USE_ ID";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_USER_EMAILSelectByUSE_ID";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
System.Nullable<int> p_iUSE_ID)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_USER_EMAILSelectByUSE_ID";
SqlParameterCollection(cmd.Parameters, p_iUSE_ID);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUSE_ID._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, System.Nullable<int> p_iUSE_ID)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUSE_ID._SqlParameter(p_iUSE_ID));
}
public class parUSE_ID
{
public const string _Name = "@USE_ID";
public const string _Caption = "@ USE_ ID";
public const string _ParentName = "APT_USER_EMAILSelectByUSE_ID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_EMAILSelectByUSE_ID.DefaultView.[0].@USE_ID";
public const string _BindDataReader = "[@USE_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USE_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USE_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class inUSE_ID : parUSE_ID {}
public class rsAPT_USER_EMAILSelectByUSE_ID
{
public const string _Name = "APT_USER_EMAILSelectByUSE_ID";
public const string _Caption = "APT_ USER_ EMAILSelect By USE_ ID";
public const string _ParentName = "APT_USER_EMAILSelectByUSE_ID";
public class slcUSE_EMAIL
{
public const string _Name = "USE_EMAIL";
public const string _Caption = "USE_ EMAIL";
public const string _ParentName = "APT_USER_EMAILSelectByUSE_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcUSE_ID
{
public const string _Name = "USE_ID";
public const string _Caption = "USE_ ID";
public const string _ParentName = "APT_USER_EMAILSelectByUSE_ID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSE_USER_ID
{
public const string _Name = "USE_USER_ID";
public const string _Caption = "USE_ USER_ ID";
public const string _ParentName = "APT_USER_EMAILSelectByUSE_ID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<int> p_iUSE_ID)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_iUSE_ID);
db.LoadDataSet(cmd, p_ds, p_strTableName);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<int> p_iUSE_ID,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_iUSE_ID);
p_db.LoadDataSet(cmd, p_ds, p_strTableName, p_trn);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
