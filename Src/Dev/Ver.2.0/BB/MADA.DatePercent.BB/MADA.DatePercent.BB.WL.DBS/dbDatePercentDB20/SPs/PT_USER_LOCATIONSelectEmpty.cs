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
public class procPT_USER_LOCATIONSelectEmpty
{
public const string _Name = "PT_USER_LOCATIONSelectEmpty";
public const string _Caption = "PT_ USER_ LOCATIONSelect Empty";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_USER_LOCATIONSelectEmpty";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
}
public class rsPT_USER_LOCATIONSelectEmpty
{
public const string _Name = "PT_USER_LOCATIONSelectEmpty";
public const string _Caption = "PT_ USER_ LOCATIONSelect Empty";
public const string _ParentName = "PT_USER_LOCATIONSelectEmpty";
public class slcUSL_ADDRESS
{
public const string _Name = "USL_ADDRESS";
public const string _Caption = "USL_ ADDRESS";
public const string _ParentName = "PT_USER_LOCATIONSelectEmpty";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcUSL_ID
{
public const string _Name = "USL_ID";
public const string _Caption = "USL_ ID";
public const string _ParentName = "PT_USER_LOCATIONSelectEmpty";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSL_IP
{
public const string _Name = "USL_IP";
public const string _Caption = "USL_ IP";
public const string _ParentName = "PT_USER_LOCATIONSelectEmpty";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 15;
}
public class slcUSL_LAT
{
public const string _Name = "USL_LAT";
public const string _Caption = "USL_ LAT";
public const string _ParentName = "PT_USER_LOCATIONSelectEmpty";
public const SqlDbType _SqlDbType = SqlDbType.Decimal;
public const Int32 _Length = -1;
}
public class slcUSL_LNG
{
public const string _Name = "USL_LNG";
public const string _Caption = "USL_ LNG";
public const string _ParentName = "PT_USER_LOCATIONSelectEmpty";
public const SqlDbType _SqlDbType = SqlDbType.Decimal;
public const Int32 _Length = -1;
}
public class slcUSL_USER_ID
{
public const string _Name = "USL_USER_ID";
public const string _Caption = "USL_ USER_ ID";
public const string _ParentName = "PT_USER_LOCATIONSelectEmpty";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSL_USER_LOCATION_TYPE
{
public const string _Name = "USL_USER_LOCATION_TYPE";
public const string _Caption = "USL_ USER_ LOCATION_ TYPE";
public const string _ParentName = "PT_USER_LOCATIONSelectEmpty";
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
MADA.DatePercent.BB.WL.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
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
MADA.DatePercent.BB.WL.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
