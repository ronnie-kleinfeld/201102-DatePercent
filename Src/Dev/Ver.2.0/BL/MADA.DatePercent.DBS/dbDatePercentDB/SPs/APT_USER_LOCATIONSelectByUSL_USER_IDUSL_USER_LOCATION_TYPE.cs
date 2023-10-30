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
public class procAPT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE
{
public const string _Name = "APT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE";
public const string _Caption = "APT_ USER_ LOCATIONSelect By USL_ USER_ IDUSL_ USER_ LOCATION_ TYPE";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
System.Nullable<int> p_iUSL_USER_ID, System.Nullable<int> p_iUSL_USER_LOCATION_TYPE)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE";
SqlParameterCollection(cmd.Parameters, p_iUSL_USER_ID, p_iUSL_USER_LOCATION_TYPE);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUSL_USER_ID._SqlParameter());
p_oSqlParameterCollection.Add(parUSL_USER_LOCATION_TYPE._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, System.Nullable<int> p_iUSL_USER_ID, System.Nullable<int> p_iUSL_USER_LOCATION_TYPE)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUSL_USER_ID._SqlParameter(p_iUSL_USER_ID));
p_oSqlParameterCollection.Add(parUSL_USER_LOCATION_TYPE._SqlParameter(p_iUSL_USER_LOCATION_TYPE));
}
public class parUSL_USER_ID
{
public const string _Name = "@USL_USER_ID";
public const string _Caption = "@ USL_ USER_ ID";
public const string _ParentName = "APT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE.DefaultView.[0].@USL_USER_ID";
public const string _BindDataReader = "[@USL_USER_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USL_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USL_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSL_USER_LOCATION_TYPE
{
public const string _Name = "@USL_USER_LOCATION_TYPE";
public const string _Caption = "@ USL_ USER_ LOCATION_ TYPE";
public const string _ParentName = "APT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE.DefaultView.[0].@USL_USER_LOCATION_TYPE";
public const string _BindDataReader = "[@USL_USER_LOCATION_TYPE]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USL_USER_LOCATION_TYPE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USL_USER_LOCATION_TYPE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class inUSL_USER_ID : parUSL_USER_ID {}
public class inUSL_USER_LOCATION_TYPE : parUSL_USER_LOCATION_TYPE {}
public class rsAPT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE
{
public const string _Name = "APT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE";
public const string _Caption = "APT_ USER_ LOCATIONSelect By USL_ USER_ IDUSL_ USER_ LOCATION_ TYPE";
public const string _ParentName = "APT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE";
public class slcUSL_ADDRESS
{
public const string _Name = "USL_ADDRESS";
public const string _Caption = "USL_ ADDRESS";
public const string _ParentName = "APT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcUSL_ID
{
public const string _Name = "USL_ID";
public const string _Caption = "USL_ ID";
public const string _ParentName = "APT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSL_IP
{
public const string _Name = "USL_IP";
public const string _Caption = "USL_ IP";
public const string _ParentName = "APT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 15;
}
public class slcUSL_LAT
{
public const string _Name = "USL_LAT";
public const string _Caption = "USL_ LAT";
public const string _ParentName = "APT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Decimal;
public const Int32 _Length = -1;
}
public class slcUSL_LNG
{
public const string _Name = "USL_LNG";
public const string _Caption = "USL_ LNG";
public const string _ParentName = "APT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Decimal;
public const Int32 _Length = -1;
}
public class slcUSL_USER_ID
{
public const string _Name = "USL_USER_ID";
public const string _Caption = "USL_ USER_ ID";
public const string _ParentName = "APT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSL_USER_LOCATION_TYPE
{
public const string _Name = "USL_USER_LOCATION_TYPE";
public const string _Caption = "USL_ USER_ LOCATION_ TYPE";
public const string _ParentName = "APT_USER_LOCATIONSelectByUSL_USER_IDUSL_USER_LOCATION_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<int> p_iUSL_USER_ID, System.Nullable<int> p_iUSL_USER_LOCATION_TYPE)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_iUSL_USER_ID, p_iUSL_USER_LOCATION_TYPE);
db.LoadDataSet(cmd, p_ds, p_strTableName);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<int> p_iUSL_USER_ID, System.Nullable<int> p_iUSL_USER_LOCATION_TYPE,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_iUSL_USER_ID, p_iUSL_USER_LOCATION_TYPE);
p_db.LoadDataSet(cmd, p_ds, p_strTableName, p_trn);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
