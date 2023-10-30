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
public class procAPT_USER_SETTINGSelectByUSS_USER_IDUSS_USER_SETTING_TYPE
{
public const string _Name = "APT_USER_SETTINGSelectByUSS_USER_IDUSS_USER_SETTING_TYPE";
public const string _Caption = "APT_ USER_ SETTINGSelect By USS_ USER_ IDUSS_ USER_ SETTING_ TYPE";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_USER_SETTINGSelectByUSS_USER_IDUSS_USER_SETTING_TYPE";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
System.Nullable<int> p_iUSS_USER_ID, System.Nullable<int> p_iUSS_USER_SETTING_TYPE)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_USER_SETTINGSelectByUSS_USER_IDUSS_USER_SETTING_TYPE";
SqlParameterCollection(cmd.Parameters, p_iUSS_USER_ID, p_iUSS_USER_SETTING_TYPE);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUSS_USER_ID._SqlParameter());
p_oSqlParameterCollection.Add(parUSS_USER_SETTING_TYPE._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, System.Nullable<int> p_iUSS_USER_ID, System.Nullable<int> p_iUSS_USER_SETTING_TYPE)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUSS_USER_ID._SqlParameter(p_iUSS_USER_ID));
p_oSqlParameterCollection.Add(parUSS_USER_SETTING_TYPE._SqlParameter(p_iUSS_USER_SETTING_TYPE));
}
public class parUSS_USER_ID
{
public const string _Name = "@USS_USER_ID";
public const string _Caption = "@ USS_ USER_ ID";
public const string _ParentName = "APT_USER_SETTINGSelectByUSS_USER_IDUSS_USER_SETTING_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_SETTINGSelectByUSS_USER_IDUSS_USER_SETTING_TYPE.DefaultView.[0].@USS_USER_ID";
public const string _BindDataReader = "[@USS_USER_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USS_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USS_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSS_USER_SETTING_TYPE
{
public const string _Name = "@USS_USER_SETTING_TYPE";
public const string _Caption = "@ USS_ USER_ SETTING_ TYPE";
public const string _ParentName = "APT_USER_SETTINGSelectByUSS_USER_IDUSS_USER_SETTING_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_SETTINGSelectByUSS_USER_IDUSS_USER_SETTING_TYPE.DefaultView.[0].@USS_USER_SETTING_TYPE";
public const string _BindDataReader = "[@USS_USER_SETTING_TYPE]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USS_USER_SETTING_TYPE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USS_USER_SETTING_TYPE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class inUSS_USER_ID : parUSS_USER_ID {}
public class inUSS_USER_SETTING_TYPE : parUSS_USER_SETTING_TYPE {}
public class rsAPT_USER_SETTINGSelectByUSS_USER_IDUSS_USER_SETTING_TYPE
{
public const string _Name = "APT_USER_SETTINGSelectByUSS_USER_IDUSS_USER_SETTING_TYPE";
public const string _Caption = "APT_ USER_ SETTINGSelect By USS_ USER_ IDUSS_ USER_ SETTING_ TYPE";
public const string _ParentName = "APT_USER_SETTINGSelectByUSS_USER_IDUSS_USER_SETTING_TYPE";
public class slcUSS_BIT
{
public const string _Name = "USS_BIT";
public const string _Caption = "USS_ BIT";
public const string _ParentName = "APT_USER_SETTINGSelectByUSS_USER_IDUSS_USER_SETTING_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = -1;
}
public class slcUSS_DATETIME
{
public const string _Name = "USS_DATETIME";
public const string _Caption = "USS_ DATETIME";
public const string _ParentName = "APT_USER_SETTINGSelectByUSS_USER_IDUSS_USER_SETTING_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.DateTime;
public const Int32 _Length = -1;
}
public class slcUSS_ID
{
public const string _Name = "USS_ID";
public const string _Caption = "USS_ ID";
public const string _ParentName = "APT_USER_SETTINGSelectByUSS_USER_IDUSS_USER_SETTING_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSS_INT
{
public const string _Name = "USS_INT";
public const string _Caption = "USS_ INT";
public const string _ParentName = "APT_USER_SETTINGSelectByUSS_USER_IDUSS_USER_SETTING_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSS_NVARCHAR
{
public const string _Name = "USS_NVARCHAR";
public const string _Caption = "USS_ NVARCHAR";
public const string _ParentName = "APT_USER_SETTINGSelectByUSS_USER_IDUSS_USER_SETTING_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
}
public class slcUSS_USER_ID
{
public const string _Name = "USS_USER_ID";
public const string _Caption = "USS_ USER_ ID";
public const string _ParentName = "APT_USER_SETTINGSelectByUSS_USER_IDUSS_USER_SETTING_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSS_USER_SETTING_TYPE
{
public const string _Name = "USS_USER_SETTING_TYPE";
public const string _Caption = "USS_ USER_ SETTING_ TYPE";
public const string _ParentName = "APT_USER_SETTINGSelectByUSS_USER_IDUSS_USER_SETTING_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<int> p_iUSS_USER_ID, System.Nullable<int> p_iUSS_USER_SETTING_TYPE)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_iUSS_USER_ID, p_iUSS_USER_SETTING_TYPE);
db.LoadDataSet(cmd, p_ds, p_strTableName);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<int> p_iUSS_USER_ID, System.Nullable<int> p_iUSS_USER_SETTING_TYPE,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_iUSS_USER_ID, p_iUSS_USER_SETTING_TYPE);
p_db.LoadDataSet(cmd, p_ds, p_strTableName, p_trn);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
