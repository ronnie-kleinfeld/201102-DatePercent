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
public class procAPT_EMAIL_HISTORYSelectByEMH_GETTER_EMAIL
{
public const string _Name = "APT_EMAIL_HISTORYSelectByEMH_GETTER_EMAIL";
public const string _Caption = "APT_ EMAIL_ HISTORYSelect By EMH_ GETTER_ EMAIL";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_EMAIL_HISTORYSelectByEMH_GETTER_EMAIL";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
string p_strEMH_GETTER_EMAIL)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_EMAIL_HISTORYSelectByEMH_GETTER_EMAIL";
SqlParameterCollection(cmd.Parameters, p_strEMH_GETTER_EMAIL);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parEMH_GETTER_EMAIL._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, string p_strEMH_GETTER_EMAIL)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parEMH_GETTER_EMAIL._SqlParameter(p_strEMH_GETTER_EMAIL));
}
public class parEMH_GETTER_EMAIL
{
public const string _Name = "@EMH_GETTER_EMAIL";
public const string _Caption = "@ EMH_ GETTER_ EMAIL";
public const string _ParentName = "APT_EMAIL_HISTORYSelectByEMH_GETTER_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_EMAIL_HISTORYSelectByEMH_GETTER_EMAIL.DefaultView.[0].@EMH_GETTER_EMAIL";
public const string _BindDataReader = "[@EMH_GETTER_EMAIL]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@EMH_GETTER_EMAIL", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@EMH_GETTER_EMAIL", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class inEMH_GETTER_EMAIL : parEMH_GETTER_EMAIL {}
public class rsAPT_EMAIL_HISTORYSelectByEMH_GETTER_EMAIL
{
public const string _Name = "APT_EMAIL_HISTORYSelectByEMH_GETTER_EMAIL";
public const string _Caption = "APT_ EMAIL_ HISTORYSelect By EMH_ GETTER_ EMAIL";
public const string _ParentName = "APT_EMAIL_HISTORYSelectByEMH_GETTER_EMAIL";
public class slcEMH_BODY
{
public const string _Name = "EMH_BODY";
public const string _Caption = "EMH_ BODY";
public const string _ParentName = "APT_EMAIL_HISTORYSelectByEMH_GETTER_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2147483647;
}
public class slcEMH_DATETIME
{
public const string _Name = "EMH_DATETIME";
public const string _Caption = "EMH_ DATETIME";
public const string _ParentName = "APT_EMAIL_HISTORYSelectByEMH_GETTER_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.DateTime;
public const Int32 _Length = -1;
}
public class slcEMH_GETTER_EMAIL
{
public const string _Name = "EMH_GETTER_EMAIL";
public const string _Caption = "EMH_ GETTER_ EMAIL";
public const string _ParentName = "APT_EMAIL_HISTORYSelectByEMH_GETTER_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcEMH_GETTER_NAME
{
public const string _Name = "EMH_GETTER_NAME";
public const string _Caption = "EMH_ GETTER_ NAME";
public const string _ParentName = "APT_EMAIL_HISTORYSelectByEMH_GETTER_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcEMH_ID
{
public const string _Name = "EMH_ID";
public const string _Caption = "EMH_ ID";
public const string _ParentName = "APT_EMAIL_HISTORYSelectByEMH_GETTER_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcEMH_SUBJECT
{
public const string _Name = "EMH_SUBJECT";
public const string _Caption = "EMH_ SUBJECT";
public const string _ParentName = "APT_EMAIL_HISTORYSelectByEMH_GETTER_EMAIL";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,string p_strEMH_GETTER_EMAIL)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_strEMH_GETTER_EMAIL);
db.LoadDataSet(cmd, p_ds, p_strTableName);}
catch (System.Exception ex)
{
MADA.DatePercent.SMTP.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,string p_strEMH_GETTER_EMAIL,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_strEMH_GETTER_EMAIL);
p_db.LoadDataSet(cmd, p_ds, p_strTableName, p_trn);}
catch (System.Exception ex)
{
MADA.DatePercent.SMTP.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
