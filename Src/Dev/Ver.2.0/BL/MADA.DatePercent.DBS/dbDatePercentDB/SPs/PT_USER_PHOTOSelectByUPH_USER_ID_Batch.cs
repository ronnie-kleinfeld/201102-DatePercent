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
public class procPT_USER_PHOTOSelectByUPH_USER_ID_Batch
{
public const string _Name = "PT_USER_PHOTOSelectByUPH_USER_ID_Batch";
public const string _Caption = "PT_ USER_ PHOTOSelect By UPH_ USER_ ID_ Batch";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_USER_PHOTOSelectByUPH_USER_ID_Batch";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
System.Nullable<int> p_iBatchLength, System.Nullable<int> p_iUPH_USER_ID)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_USER_PHOTOSelectByUPH_USER_ID_Batch";
SqlParameterCollection(cmd.Parameters, p_iBatchLength, p_iUPH_USER_ID);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parBatchLength._SqlParameter());
p_oSqlParameterCollection.Add(parUPH_USER_ID._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, System.Nullable<int> p_iBatchLength, System.Nullable<int> p_iUPH_USER_ID)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parBatchLength._SqlParameter(p_iBatchLength));
p_oSqlParameterCollection.Add(parUPH_USER_ID._SqlParameter(p_iUPH_USER_ID));
}
public class parBatchLength
{
public const string _Name = "@BatchLength";
public const string _Caption = "@ Batch Length";
public const string _ParentName = "PT_USER_PHOTOSelectByUPH_USER_ID_Batch";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_USER_PHOTOSelectByUPH_USER_ID_Batch.DefaultView.[0].@BatchLength";
public const string _BindDataReader = "[@BatchLength]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@BatchLength", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@BatchLength", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUPH_USER_ID
{
public const string _Name = "@UPH_USER_ID";
public const string _Caption = "@ UPH_ USER_ ID";
public const string _ParentName = "PT_USER_PHOTOSelectByUPH_USER_ID_Batch";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_USER_PHOTOSelectByUPH_USER_ID_Batch.DefaultView.[0].@UPH_USER_ID";
public const string _BindDataReader = "[@UPH_USER_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@UPH_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@UPH_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class inBatchLength : parBatchLength {}
public class inUPH_USER_ID : parUPH_USER_ID {}
public class rsPT_USER_PHOTOSelectByUPH_USER_ID_Batch
{
public const string _Name = "PT_USER_PHOTOSelectByUPH_USER_ID_Batch";
public const string _Caption = "PT_ USER_ PHOTOSelect By UPH_ USER_ ID_ Batch";
public const string _ParentName = "PT_USER_PHOTOSelectByUPH_USER_ID_Batch";
public class slcUPH_ID
{
public const string _Name = "UPH_ID";
public const string _Caption = "UPH_ ID";
public const string _ParentName = "PT_USER_PHOTOSelectByUPH_USER_ID_Batch";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUPH_IO_ERROR
{
public const string _Name = "UPH_IO_ERROR";
public const string _Caption = "UPH_ IO_ ERROR";
public const string _ParentName = "PT_USER_PHOTOSelectByUPH_USER_ID_Batch";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = -1;
}
public class slcUPH_ORIGINAL_URL
{
public const string _Name = "UPH_ORIGINAL_URL";
public const string _Caption = "UPH_ ORIGINAL_ URL";
public const string _ParentName = "PT_USER_PHOTOSelectByUPH_USER_ID_Batch";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
}
public class slcUPH_SMALL_URL
{
public const string _Name = "UPH_SMALL_URL";
public const string _Caption = "UPH_ SMALL_ URL";
public const string _ParentName = "PT_USER_PHOTOSelectByUPH_USER_ID_Batch";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
}
public class slcUPH_THUMB_URL
{
public const string _Name = "UPH_THUMB_URL";
public const string _Caption = "UPH_ THUMB_ URL";
public const string _ParentName = "PT_USER_PHOTOSelectByUPH_USER_ID_Batch";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
}
public class slcUPH_USER_ID
{
public const string _Name = "UPH_USER_ID";
public const string _Caption = "UPH_ USER_ ID";
public const string _ParentName = "PT_USER_PHOTOSelectByUPH_USER_ID_Batch";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
}
public class rsPT_USER_PHOTOSelectByUPH_USER_ID_Batch1
{
public const string _Name = "PT_USER_PHOTOSelectByUPH_USER_ID_Batch1";
public const string _Caption = "PT_ USER_ PHOTOSelect By UPH_ USER_ ID_ Batch1";
public const string _ParentName = "PT_USER_PHOTOSelectByUPH_USER_ID_Batch";
public class slcLength
{
public const string _Name = "Length";
public const string _Caption = "Length";
public const string _ParentName = "PT_USER_PHOTOSelectByUPH_USER_ID_Batch";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<int> p_iBatchLength, System.Nullable<int> p_iUPH_USER_ID)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_iBatchLength, p_iUPH_USER_ID);
db.LoadDataSet(cmd, p_ds, p_strTableName);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<int> p_iBatchLength, System.Nullable<int> p_iUPH_USER_ID,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_iBatchLength, p_iUPH_USER_ID);
p_db.LoadDataSet(cmd, p_ds, p_strTableName, p_trn);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
