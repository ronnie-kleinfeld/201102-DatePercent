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
public class procPT_USER_INVITEESelectInvitedByUSI_EMAIL
{
public const string _Name = "PT_USER_INVITEESelectInvitedByUSI_EMAIL";
public const string _Caption = "PT_ USER_ INVITEESelect Invited By USI_ EMAIL";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_USER_INVITEESelectInvitedByUSI_EMAIL";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
string p_strUSI_EMAIL)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_USER_INVITEESelectInvitedByUSI_EMAIL";
SqlParameterCollection(cmd.Parameters, p_strUSI_EMAIL);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUSI_EMAIL._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, string p_strUSI_EMAIL)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUSI_EMAIL._SqlParameter(p_strUSI_EMAIL));
}
public class parUSI_EMAIL
{
public const string _Name = "@USI_EMAIL";
public const string _Caption = "@ USI_ EMAIL";
public const string _ParentName = "PT_USER_INVITEESelectInvitedByUSI_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_USER_INVITEESelectInvitedByUSI_EMAIL.DefaultView.[0].@USI_EMAIL";
public const string _BindDataReader = "[@USI_EMAIL]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USI_EMAIL", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USI_EMAIL", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class inUSI_EMAIL : parUSI_EMAIL {}
public class rsPT_USER_INVITEESelectInvitedByUSI_EMAIL
{
public const string _Name = "PT_USER_INVITEESelectInvitedByUSI_EMAIL";
public const string _Caption = "PT_ USER_ INVITEESelect Invited By USI_ EMAIL";
public const string _ParentName = "PT_USER_INVITEESelectInvitedByUSI_EMAIL";
public class slcUSI_EMAIL
{
public const string _Name = "USI_EMAIL";
public const string _Caption = "USI_ EMAIL";
public const string _ParentName = "PT_USER_INVITEESelectInvitedByUSI_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcUSI_ID
{
public const string _Name = "USI_ID";
public const string _Caption = "USI_ ID";
public const string _ParentName = "PT_USER_INVITEESelectInvitedByUSI_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSI_INVITEE_USER_ID
{
public const string _Name = "USI_INVITEE_USER_ID";
public const string _Caption = "USI_ INVITEE_ USER_ ID";
public const string _ParentName = "PT_USER_INVITEESelectInvitedByUSI_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSI_INVITER_USER_ID
{
public const string _Name = "USI_INVITER_USER_ID";
public const string _Caption = "USI_ INVITER_ USER_ ID";
public const string _ParentName = "PT_USER_INVITEESelectInvitedByUSI_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSI_INVITER_USER_UID
{
public const string _Name = "USI_INVITER_USER_UID";
public const string _Caption = "USI_ INVITER_ USER_ UID";
public const string _ParentName = "PT_USER_INVITEESelectInvitedByUSI_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcUSI_NAME
{
public const string _Name = "USI_NAME";
public const string _Caption = "USI_ NAME";
public const string _ParentName = "PT_USER_INVITEESelectInvitedByUSI_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcUSI_USER_INVITEE_DATETIME
{
public const string _Name = "USI_USER_INVITEE_DATETIME";
public const string _Caption = "USI_ USER_ INVITEE_ DATETIME";
public const string _ParentName = "PT_USER_INVITEESelectInvitedByUSI_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.DateTime;
public const Int32 _Length = -1;
}
public class slcUSI_USER_INVITEE_TYPE
{
public const string _Name = "USI_USER_INVITEE_TYPE";
public const string _Caption = "USI_ USER_ INVITEE_ TYPE";
public const string _ParentName = "PT_USER_INVITEESelectInvitedByUSI_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSI_USER_INVITEE_TYPE_DATETIME
{
public const string _Name = "USI_USER_INVITEE_TYPE_DATETIME";
public const string _Caption = "USI_ USER_ INVITEE_ TYPE_ DATETIME";
public const string _ParentName = "PT_USER_INVITEESelectInvitedByUSI_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.DateTime;
public const Int32 _Length = -1;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,string p_strUSI_EMAIL)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_strUSI_EMAIL);
db.LoadDataSet(cmd, p_ds, p_strTableName);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,string p_strUSI_EMAIL,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_strUSI_EMAIL);
p_db.LoadDataSet(cmd, p_ds, p_strTableName, p_trn);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
