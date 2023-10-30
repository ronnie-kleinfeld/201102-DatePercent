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
public class procAPT_TICKET_THREADSelectByTTT_TICKET_ID
{
public const string _Name = "APT_TICKET_THREADSelectByTTT_TICKET_ID";
public const string _Caption = "APT_ TICKET_ THREADSelect By TTT_ TICKET_ ID";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_TICKET_THREADSelectByTTT_TICKET_ID";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
System.Nullable<int> p_iTTT_TICKET_ID)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_TICKET_THREADSelectByTTT_TICKET_ID";
SqlParameterCollection(cmd.Parameters, p_iTTT_TICKET_ID);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parTTT_TICKET_ID._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, System.Nullable<int> p_iTTT_TICKET_ID)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parTTT_TICKET_ID._SqlParameter(p_iTTT_TICKET_ID));
}
public class parTTT_TICKET_ID
{
public const string _Name = "@TTT_TICKET_ID";
public const string _Caption = "@ TTT_ TICKET_ ID";
public const string _ParentName = "APT_TICKET_THREADSelectByTTT_TICKET_ID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_TICKET_THREADSelectByTTT_TICKET_ID.DefaultView.[0].@TTT_TICKET_ID";
public const string _BindDataReader = "[@TTT_TICKET_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@TTT_TICKET_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@TTT_TICKET_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class inTTT_TICKET_ID : parTTT_TICKET_ID {}
public class rsAPT_TICKET_THREADSelectByTTT_TICKET_ID
{
public const string _Name = "APT_TICKET_THREADSelectByTTT_TICKET_ID";
public const string _Caption = "APT_ TICKET_ THREADSelect By TTT_ TICKET_ ID";
public const string _ParentName = "APT_TICKET_THREADSelectByTTT_TICKET_ID";
public class slcTTT_BODY
{
public const string _Name = "TTT_BODY";
public const string _Caption = "TTT_ BODY";
public const string _ParentName = "APT_TICKET_THREADSelectByTTT_TICKET_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
}
public class slcTTT_ID
{
public const string _Name = "TTT_ID";
public const string _Caption = "TTT_ ID";
public const string _ParentName = "APT_TICKET_THREADSelectByTTT_TICKET_ID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcTTT_TICKET_ID
{
public const string _Name = "TTT_TICKET_ID";
public const string _Caption = "TTT_ TICKET_ ID";
public const string _ParentName = "APT_TICKET_THREADSelectByTTT_TICKET_ID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcTTT_WRITTEN_BY_DATETIME
{
public const string _Name = "TTT_WRITTEN_BY_DATETIME";
public const string _Caption = "TTT_ WRITTEN_ BY_ DATETIME";
public const string _ParentName = "APT_TICKET_THREADSelectByTTT_TICKET_ID";
public const SqlDbType _SqlDbType = SqlDbType.DateTime;
public const Int32 _Length = -1;
}
public class slcTTT_WRITTEN_BY_USER_ID
{
public const string _Name = "TTT_WRITTEN_BY_USER_ID";
public const string _Caption = "TTT_ WRITTEN_ BY_ USER_ ID";
public const string _ParentName = "APT_TICKET_THREADSelectByTTT_TICKET_ID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<int> p_iTTT_TICKET_ID)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_iTTT_TICKET_ID);
db.LoadDataSet(cmd, p_ds, p_strTableName);}
catch (System.Exception ex)
{
MADA.DatePercent.BB.WL.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<int> p_iTTT_TICKET_ID,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_iTTT_TICKET_ID);
p_db.LoadDataSet(cmd, p_ds, p_strTableName, p_trn);}
catch (System.Exception ex)
{
MADA.DatePercent.BB.WL.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
