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
public class procAPT_EMAIL_UNTISPAMDeleteByEMM_EMAIL
{
public const string _Name = "APT_EMAIL_UNTISPAMDeleteByEMM_EMAIL";
public const string _Caption = "APT_ EMAIL_ UNTISPAMDelete By EMM_ EMAIL";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_EMAIL_UNTISPAMDeleteByEMM_EMAIL";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
string p_strEMM_EMAIL)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_EMAIL_UNTISPAMDeleteByEMM_EMAIL";
SqlParameterCollection(cmd.Parameters, p_strEMM_EMAIL);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parEMM_EMAIL._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, string p_strEMM_EMAIL)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parEMM_EMAIL._SqlParameter(p_strEMM_EMAIL));
}
public class parEMM_EMAIL
{
public const string _Name = "@EMM_EMAIL";
public const string _Caption = "@ EMM_ EMAIL";
public const string _ParentName = "APT_EMAIL_UNTISPAMDeleteByEMM_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_EMAIL_UNTISPAMDeleteByEMM_EMAIL.DefaultView.[0].@EMM_EMAIL";
public const string _BindDataReader = "[@EMM_EMAIL]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@EMM_EMAIL", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@EMM_EMAIL", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class inEMM_EMAIL : parEMM_EMAIL {}
public static int ExecuteNonQuery(
string p_strEMM_EMAIL)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_strEMM_EMAIL);
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
string p_strEMM_EMAIL,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_strEMM_EMAIL);
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
