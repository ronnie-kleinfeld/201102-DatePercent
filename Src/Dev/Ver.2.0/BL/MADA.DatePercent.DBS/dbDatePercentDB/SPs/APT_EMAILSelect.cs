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
public class procAPT_EMAILSelect
{
public const string _Name = "APT_EMAILSelect";
public const string _Caption = "APT_ EMAILSelect";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_EMAILSelect";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
}
public class rsAPT_EMAILSelect
{
public const string _Name = "APT_EMAILSelect";
public const string _Caption = "APT_ EMAILSelect";
public const string _ParentName = "APT_EMAILSelect";
public class slcEML_BODY
{
public const string _Name = "EML_BODY";
public const string _Caption = "EML_ BODY";
public const string _ParentName = "APT_EMAILSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2147483647;
}
public class slcEML_GETTER_EMAIL
{
public const string _Name = "EML_GETTER_EMAIL";
public const string _Caption = "EML_ GETTER_ EMAIL";
public const string _ParentName = "APT_EMAILSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcEML_GETTER_NAME
{
public const string _Name = "EML_GETTER_NAME";
public const string _Caption = "EML_ GETTER_ NAME";
public const string _ParentName = "APT_EMAILSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcEML_ID
{
public const string _Name = "EML_ID";
public const string _Caption = "EML_ ID";
public const string _ParentName = "APT_EMAILSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcEML_SENDER_NAME
{
public const string _Name = "EML_SENDER_NAME";
public const string _Caption = "EML_ SENDER_ NAME";
public const string _ParentName = "APT_EMAILSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcEML_SUBJECT
{
public const string _Name = "EML_SUBJECT";
public const string _Caption = "EML_ SUBJECT";
public const string _ParentName = "APT_EMAILSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
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
