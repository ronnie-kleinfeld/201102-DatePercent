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
public class procAPT_LISTSelectByLST_SESSION_USER_IDLST_TYPE_CODE
{
public const string _Name = "APT_LISTSelectByLST_SESSION_USER_IDLST_TYPE_CODE";
public const string _Caption = "APT_ LISTSelect By LST_ SESSION_ USER_ IDLST_ TYPE_ CODE";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_LISTSelectByLST_SESSION_USER_IDLST_TYPE_CODE";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
System.Nullable<int> p_iLST_SESSION_USER_ID, System.Nullable<int> p_iLST_TYPE_CODE)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_LISTSelectByLST_SESSION_USER_IDLST_TYPE_CODE";
SqlParameterCollection(cmd.Parameters, p_iLST_SESSION_USER_ID, p_iLST_TYPE_CODE);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parLST_SESSION_USER_ID._SqlParameter());
p_oSqlParameterCollection.Add(parLST_TYPE_CODE._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, System.Nullable<int> p_iLST_SESSION_USER_ID, System.Nullable<int> p_iLST_TYPE_CODE)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parLST_SESSION_USER_ID._SqlParameter(p_iLST_SESSION_USER_ID));
p_oSqlParameterCollection.Add(parLST_TYPE_CODE._SqlParameter(p_iLST_TYPE_CODE));
}
public class parLST_SESSION_USER_ID
{
public const string _Name = "@LST_SESSION_USER_ID";
public const string _Caption = "@ LST_ SESSION_ USER_ ID";
public const string _ParentName = "APT_LISTSelectByLST_SESSION_USER_IDLST_TYPE_CODE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_LISTSelectByLST_SESSION_USER_IDLST_TYPE_CODE.DefaultView.[0].@LST_SESSION_USER_ID";
public const string _BindDataReader = "[@LST_SESSION_USER_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@LST_SESSION_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@LST_SESSION_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parLST_TYPE_CODE
{
public const string _Name = "@LST_TYPE_CODE";
public const string _Caption = "@ LST_ TYPE_ CODE";
public const string _ParentName = "APT_LISTSelectByLST_SESSION_USER_IDLST_TYPE_CODE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_LISTSelectByLST_SESSION_USER_IDLST_TYPE_CODE.DefaultView.[0].@LST_TYPE_CODE";
public const string _BindDataReader = "[@LST_TYPE_CODE]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@LST_TYPE_CODE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@LST_TYPE_CODE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class inLST_SESSION_USER_ID : parLST_SESSION_USER_ID {}
public class inLST_TYPE_CODE : parLST_TYPE_CODE {}
public class rsAPT_LISTSelectByLST_SESSION_USER_IDLST_TYPE_CODE
{
public const string _Name = "APT_LISTSelectByLST_SESSION_USER_IDLST_TYPE_CODE";
public const string _Caption = "APT_ LISTSelect By LST_ SESSION_ USER_ IDLST_ TYPE_ CODE";
public const string _ParentName = "APT_LISTSelectByLST_SESSION_USER_IDLST_TYPE_CODE";
public class slcLST_COMMENT
{
public const string _Name = "LST_COMMENT";
public const string _Caption = "LST_ COMMENT";
public const string _ParentName = "APT_LISTSelectByLST_SESSION_USER_IDLST_TYPE_CODE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcLST_DESCRIPTION
{
public const string _Name = "LST_DESCRIPTION";
public const string _Caption = "LST_ DESCRIPTION";
public const string _ParentName = "APT_LISTSelectByLST_SESSION_USER_IDLST_TYPE_CODE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcLST_ID
{
public const string _Name = "LST_ID";
public const string _Caption = "LST_ ID";
public const string _ParentName = "APT_LISTSelectByLST_SESSION_USER_IDLST_TYPE_CODE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcLST_RESULT_VIEW_TYPE_CODE
{
public const string _Name = "LST_RESULT_VIEW_TYPE_CODE";
public const string _Caption = "LST_ RESULT_ VIEW_ TYPE_ CODE";
public const string _ParentName = "APT_LISTSelectByLST_SESSION_USER_IDLST_TYPE_CODE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcLST_SESSION_USER_ID
{
public const string _Name = "LST_SESSION_USER_ID";
public const string _Caption = "LST_ SESSION_ USER_ ID";
public const string _ParentName = "APT_LISTSelectByLST_SESSION_USER_IDLST_TYPE_CODE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcLST_TYPE_CODE
{
public const string _Name = "LST_TYPE_CODE";
public const string _Caption = "LST_ TYPE_ CODE";
public const string _ParentName = "APT_LISTSelectByLST_SESSION_USER_IDLST_TYPE_CODE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<int> p_iLST_SESSION_USER_ID, System.Nullable<int> p_iLST_TYPE_CODE)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_iLST_SESSION_USER_ID, p_iLST_TYPE_CODE);
db.LoadDataSet(cmd, p_ds, p_strTableName);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<int> p_iLST_SESSION_USER_ID, System.Nullable<int> p_iLST_TYPE_CODE,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_iLST_SESSION_USER_ID, p_iLST_TYPE_CODE);
p_db.LoadDataSet(cmd, p_ds, p_strTableName, p_trn);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
