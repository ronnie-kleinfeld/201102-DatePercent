//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by the Database Schema tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
//
//     Exception should be handled in a higher layer.
//
//     generation time: 27/03/2012 13:20
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MADA.DatePercent.BB.NLB.DBS.dbNlbDB.SPs
{
public class procPT_IP_LAT_LNGSelectTopNToValidate
{
public const string _Name = "PT_IP_LAT_LNGSelectTopNToValidate";
public const string _Caption = "PT_ IP_ LAT_ LNGSelect Top NTo Validate";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_IP_LAT_LNGSelectTopNToValidate";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
System.Nullable<int> p_iTopCount)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_IP_LAT_LNGSelectTopNToValidate";
SqlParameterCollection(cmd.Parameters, p_iTopCount);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parTopCount._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, System.Nullable<int> p_iTopCount)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parTopCount._SqlParameter(p_iTopCount));
}
public class parTopCount
{
public const string _Name = "@TopCount";
public const string _Caption = "@ Top Count";
public const string _ParentName = "PT_IP_LAT_LNGSelectTopNToValidate";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_IP_LAT_LNGSelectTopNToValidate.DefaultView.[0].@TopCount";
public const string _BindDataReader = "[@TopCount]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@TopCount", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@TopCount", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class inTopCount : parTopCount {}
public class rsPT_IP_LAT_LNGSelectTopNToValidate
{
public const string _Name = "PT_IP_LAT_LNGSelectTopNToValidate";
public const string _Caption = "PT_ IP_ LAT_ LNGSelect Top NTo Validate";
public const string _ParentName = "PT_IP_LAT_LNGSelectTopNToValidate";
public class slcIPL_BL_SERVER_ID
{
public const string _Name = "IPL_BL_SERVER_ID";
public const string _Caption = "IPL_ BL_ SERVER_ ID";
public const string _ParentName = "PT_IP_LAT_LNGSelectTopNToValidate";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcIPL_IIS_SERVER_ID
{
public const string _Name = "IPL_IIS_SERVER_ID";
public const string _Caption = "IPL_ IIS_ SERVER_ ID";
public const string _ParentName = "PT_IP_LAT_LNGSelectTopNToValidate";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcIPL_IP
{
public const string _Name = "IPL_IP";
public const string _Caption = "IPL_ IP";
public const string _ParentName = "PT_IP_LAT_LNGSelectTopNToValidate";
public const SqlDbType _SqlDbType = SqlDbType.BigInt;
public const Int32 _Length = -1;
}
public class slcIPL_LAT
{
public const string _Name = "IPL_LAT";
public const string _Caption = "IPL_ LAT";
public const string _ParentName = "PT_IP_LAT_LNGSelectTopNToValidate";
public const SqlDbType _SqlDbType = SqlDbType.Decimal;
public const Int32 _Length = -1;
}
public class slcIPL_LNG
{
public const string _Name = "IPL_LNG";
public const string _Caption = "IPL_ LNG";
public const string _ParentName = "PT_IP_LAT_LNGSelectTopNToValidate";
public const SqlDbType _SqlDbType = SqlDbType.Decimal;
public const Int32 _Length = -1;
}
public class slcIPL_VALIDATE
{
public const string _Name = "IPL_VALIDATE";
public const string _Caption = "IPL_ VALIDATE";
public const string _ParentName = "PT_IP_LAT_LNGSelectTopNToValidate";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = -1;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<int> p_iTopCount)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_iTopCount);
db.LoadDataSet(cmd, p_ds, p_strTableName);}
catch (System.Exception ex)
{
MADA.DatePercent.BB.NLB.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<int> p_iTopCount,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_iTopCount);
p_db.LoadDataSet(cmd, p_ds, p_strTableName, p_trn);}
catch (System.Exception ex)
{
MADA.DatePercent.BB.NLB.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
