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
public class procAPT_USER_LOCATIONSelect
{
public const string _Name = "APT_USER_LOCATIONSelect";
public const string _Caption = "APT_ USER_ LOCATIONSelect";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_USER_LOCATIONSelect";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
}
public class rsAPT_USER_LOCATIONSelect
{
public const string _Name = "APT_USER_LOCATIONSelect";
public const string _Caption = "APT_ USER_ LOCATIONSelect";
public const string _ParentName = "APT_USER_LOCATIONSelect";
public class slcUSL_ADDRESS
{
public const string _Name = "USL_ADDRESS";
public const string _Caption = "USL_ ADDRESS";
public const string _ParentName = "APT_USER_LOCATIONSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcUSL_ID
{
public const string _Name = "USL_ID";
public const string _Caption = "USL_ ID";
public const string _ParentName = "APT_USER_LOCATIONSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSL_IP
{
public const string _Name = "USL_IP";
public const string _Caption = "USL_ IP";
public const string _ParentName = "APT_USER_LOCATIONSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 15;
}
public class slcUSL_LAT
{
public const string _Name = "USL_LAT";
public const string _Caption = "USL_ LAT";
public const string _ParentName = "APT_USER_LOCATIONSelect";
public const SqlDbType _SqlDbType = SqlDbType.Decimal;
public const Int32 _Length = -1;
}
public class slcUSL_LNG
{
public const string _Name = "USL_LNG";
public const string _Caption = "USL_ LNG";
public const string _ParentName = "APT_USER_LOCATIONSelect";
public const SqlDbType _SqlDbType = SqlDbType.Decimal;
public const Int32 _Length = -1;
}
public class slcUSL_USER_ID
{
public const string _Name = "USL_USER_ID";
public const string _Caption = "USL_ USER_ ID";
public const string _ParentName = "APT_USER_LOCATIONSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSL_USER_LOCATION_TYPE
{
public const string _Name = "USL_USER_LOCATION_TYPE";
public const string _Caption = "USL_ USER_ LOCATION_ TYPE";
public const string _ParentName = "APT_USER_LOCATIONSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
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
