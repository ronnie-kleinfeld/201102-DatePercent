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
public class procPT_USERUpdateUSR_DONT_ASK_INVITATION_SENTByUSL_SID
{
public const string _Name = "PT_USERUpdateUSR_DONT_ASK_INVITATION_SENTByUSL_SID";
public const string _Caption = "PT_ USERUpdate USR_ DONT_ ASK_ INVITATION_ SENTBy USL_ SID";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_USERUpdateUSR_DONT_ASK_INVITATION_SENTByUSL_SID";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
string p_strUSL_SID)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_USERUpdateUSR_DONT_ASK_INVITATION_SENTByUSL_SID";
SqlParameterCollection(cmd.Parameters, p_strUSL_SID);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUSL_SID._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, string p_strUSL_SID)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUSL_SID._SqlParameter(p_strUSL_SID));
}
public class parUSL_SID
{
public const string _Name = "@USL_SID";
public const string _Caption = "@ USL_ SID";
public const string _ParentName = "PT_USERUpdateUSR_DONT_ASK_INVITATION_SENTByUSL_SID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_USERUpdateUSR_DONT_ASK_INVITATION_SENTByUSL_SID.DefaultView.[0].@USL_SID";
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
public class inUSL_SID : parUSL_SID {}
public static int ExecuteNonQuery(
string p_strUSL_SID)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_strUSL_SID);
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
string p_strUSL_SID,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_strUSL_SID);
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
