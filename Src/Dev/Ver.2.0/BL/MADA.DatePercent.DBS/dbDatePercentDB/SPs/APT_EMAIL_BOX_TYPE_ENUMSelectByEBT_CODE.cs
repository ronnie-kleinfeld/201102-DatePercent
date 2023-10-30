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
public class procAPT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE
{
public const string _Name = "APT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE";
public const string _Caption = "APT_ EMAIL_ BOX_ TYPE_ ENUMSelect By EBT_ CODE";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
System.Nullable<int> p_iEBT_CODE)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE";
SqlParameterCollection(cmd.Parameters, p_iEBT_CODE);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parEBT_CODE._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, System.Nullable<int> p_iEBT_CODE)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parEBT_CODE._SqlParameter(p_iEBT_CODE));
}
public class parEBT_CODE
{
public const string _Name = "@EBT_CODE";
public const string _Caption = "@ EBT_ CODE";
public const string _ParentName = "APT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE.DefaultView.[0].@EBT_CODE";
public const string _BindDataReader = "[@EBT_CODE]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@EBT_CODE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@EBT_CODE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class inEBT_CODE : parEBT_CODE {}
public class rsAPT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE
{
public const string _Name = "APT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE";
public const string _Caption = "APT_ EMAIL_ BOX_ TYPE_ ENUMSelect By EBT_ CODE";
public const string _ParentName = "APT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE";
public class slcEBT_CLICK_HERE_TO
{
public const string _Name = "EBT_CLICK_HERE_TO";
public const string _Caption = "EBT_ CLICK_ HERE_ TO";
public const string _ParentName = "APT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcEBT_CODE
{
public const string _Name = "EBT_CODE";
public const string _Caption = "EBT_ CODE";
public const string _ParentName = "APT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcEBT_COUNTER
{
public const string _Name = "EBT_COUNTER";
public const string _Caption = "EBT_ COUNTER";
public const string _ParentName = "APT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcEBT_DESCRIPTION
{
public const string _Name = "EBT_DESCRIPTION";
public const string _Caption = "EBT_ DESCRIPTION";
public const string _ParentName = "APT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcEBT_HOLD_TIME_MINUTES
{
public const string _Name = "EBT_HOLD_TIME_MINUTES";
public const string _Caption = "EBT_ HOLD_ TIME_ MINUTES";
public const string _ParentName = "APT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcEBT_PATH
{
public const string _Name = "EBT_PATH";
public const string _Caption = "EBT_ PATH";
public const string _ParentName = "APT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
}
public class slcEBT_PIC_URL
{
public const string _Name = "EBT_PIC_URL";
public const string _Caption = "EBT_ PIC_ URL";
public const string _ParentName = "APT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcEBT_QUERY_STRING
{
public const string _Name = "EBT_QUERY_STRING";
public const string _Caption = "EBT_ QUERY_ STRING";
public const string _ParentName = "APT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcEBT_SUBJECT
{
public const string _Name = "EBT_SUBJECT";
public const string _Caption = "EBT_ SUBJECT";
public const string _ParentName = "APT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcValueCode
{
public const string _Name = "ValueCode";
public const string _Caption = "Value Code";
public const string _ParentName = "APT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcValueName
{
public const string _Name = "ValueName";
public const string _Caption = "Value Name";
public const string _ParentName = "APT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcValueNameEnum
{
public const string _Name = "ValueNameEnum";
public const string _Caption = "Value Name Enum";
public const string _ParentName = "APT_EMAIL_BOX_TYPE_ENUMSelectByEBT_CODE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<int> p_iEBT_CODE)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_iEBT_CODE);
db.LoadDataSet(cmd, p_ds, p_strTableName);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<int> p_iEBT_CODE,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_iEBT_CODE);
p_db.LoadDataSet(cmd, p_ds, p_strTableName, p_trn);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
