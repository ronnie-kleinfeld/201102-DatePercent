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
public class procPT_RMNSelectCommunicateToNotifyByRMN_SENT_DATETIME
{
public const string _Name = "PT_RMNSelectCommunicateToNotifyByRMN_SENT_DATETIME";
public const string _Caption = "PT_ RMNSelect Communicate To Notify By RMN_ SENT_ DATETIME";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_RMNSelectCommunicateToNotifyByRMN_SENT_DATETIME";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
System.Nullable<DateTime> p_dtRMN_SENT_DATETIME)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_RMNSelectCommunicateToNotifyByRMN_SENT_DATETIME";
SqlParameterCollection(cmd.Parameters, p_dtRMN_SENT_DATETIME);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parRMN_SENT_DATETIME._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, System.Nullable<DateTime> p_dtRMN_SENT_DATETIME)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parRMN_SENT_DATETIME._SqlParameter(p_dtRMN_SENT_DATETIME));
}
public class parRMN_SENT_DATETIME
{
public const string _Name = "@RMN_SENT_DATETIME";
public const string _Caption = "@ RMN_ SENT_ DATETIME";
public const string _ParentName = "PT_RMNSelectCommunicateToNotifyByRMN_SENT_DATETIME";
public const SqlDbType _SqlDbType = SqlDbType.DateTime;
public const Int32 _Length = 8;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_RMNSelectCommunicateToNotifyByRMN_SENT_DATETIME.DefaultView.[0].@RMN_SENT_DATETIME";
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
public class inRMN_SENT_DATETIME : parRMN_SENT_DATETIME {}
public class rsPT_RMNSelectCommunicateToNotifyByRMN_SENT_DATETIME
{
public const string _Name = "PT_RMNSelectCommunicateToNotifyByRMN_SENT_DATETIME";
public const string _Caption = "PT_ RMNSelect Communicate To Notify By RMN_ SENT_ DATETIME";
public const string _ParentName = "PT_RMNSelectCommunicateToNotifyByRMN_SENT_DATETIME";
public class slcRMN_GETTER_EMAILED
{
public const string _Name = "RMN_GETTER_EMAILED";
public const string _Caption = "RMN_ GETTER_ EMAILED";
public const string _ParentName = "PT_RMNSelectCommunicateToNotifyByRMN_SENT_DATETIME";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = -1;
}
public class slcRMN_GETTER_READ
{
public const string _Name = "RMN_GETTER_READ";
public const string _Caption = "RMN_ GETTER_ READ";
public const string _ParentName = "PT_RMNSelectCommunicateToNotifyByRMN_SENT_DATETIME";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = -1;
}
public class slcRMN_GETTER_USER_ID
{
public const string _Name = "RMN_GETTER_USER_ID";
public const string _Caption = "RMN_ GETTER_ USER_ ID";
public const string _ParentName = "PT_RMNSelectCommunicateToNotifyByRMN_SENT_DATETIME";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcRMN_ID
{
public const string _Name = "RMN_ID";
public const string _Caption = "RMN_ ID";
public const string _ParentName = "PT_RMNSelectCommunicateToNotifyByRMN_SENT_DATETIME";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcRMN_RMT_TYPE
{
public const string _Name = "RMN_RMT_TYPE";
public const string _Caption = "RMN_ RMT_ TYPE";
public const string _ParentName = "PT_RMNSelectCommunicateToNotifyByRMN_SENT_DATETIME";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcRMN_SENDER_READ
{
public const string _Name = "RMN_SENDER_READ";
public const string _Caption = "RMN_ SENDER_ READ";
public const string _ParentName = "PT_RMNSelectCommunicateToNotifyByRMN_SENT_DATETIME";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = -1;
}
public class slcRMN_SENDER_USER_ID
{
public const string _Name = "RMN_SENDER_USER_ID";
public const string _Caption = "RMN_ SENDER_ USER_ ID";
public const string _ParentName = "PT_RMNSelectCommunicateToNotifyByRMN_SENT_DATETIME";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcRMN_SENT_DATETIME
{
public const string _Name = "RMN_SENT_DATETIME";
public const string _Caption = "RMN_ SENT_ DATETIME";
public const string _ParentName = "PT_RMNSelectCommunicateToNotifyByRMN_SENT_DATETIME";
public const SqlDbType _SqlDbType = SqlDbType.DateTime;
public const Int32 _Length = -1;
}
public class slcRMN_TEXT
{
public const string _Name = "RMN_TEXT";
public const string _Caption = "RMN_ TEXT";
public const string _ParentName = "PT_RMNSelectCommunicateToNotifyByRMN_SENT_DATETIME";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<DateTime> p_dtRMN_SENT_DATETIME)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_dtRMN_SENT_DATETIME);
db.LoadDataSet(cmd, p_ds, p_strTableName);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<DateTime> p_dtRMN_SENT_DATETIME,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_dtRMN_SENT_DATETIME);
p_db.LoadDataSet(cmd, p_ds, p_strTableName, p_trn);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
