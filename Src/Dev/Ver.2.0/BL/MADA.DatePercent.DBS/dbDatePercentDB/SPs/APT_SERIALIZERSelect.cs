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
public class procAPT_SERIALIZERSelect
{
public const string _Name = "APT_SERIALIZERSelect";
public const string _Caption = "APT_ SERIALIZERSelect";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_SERIALIZERSelect";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
}
public class rsAPT_SERIALIZERSelect
{
public const string _Name = "APT_SERIALIZERSelect";
public const string _Caption = "APT_ SERIALIZERSelect";
public const string _ParentName = "APT_SERIALIZERSelect";
public class slcSRL_DESCRIPTION
{
public const string _Name = "SRL_DESCRIPTION";
public const string _Caption = "SRL_ DESCRIPTION";
public const string _ParentName = "APT_SERIALIZERSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcSRL_KEY_1
{
public const string _Name = "SRL_KEY_1";
public const string _Caption = "SRL_ KEY_1";
public const string _ParentName = "APT_SERIALIZERSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 5;
}
public class slcSRL_KEY_2
{
public const string _Name = "SRL_KEY_2";
public const string _Caption = "SRL_ KEY_2";
public const string _ParentName = "APT_SERIALIZERSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 5;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand();
db.LoadDataSet(cmd, p_ds, p_strTableName);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand();
p_db.LoadDataSet(cmd, p_ds, p_strTableName, p_trn);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
