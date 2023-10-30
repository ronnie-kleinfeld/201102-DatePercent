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
public class procAPT_CULTURE_DATE_FORMAT_TYPE_ENUMSelect
{
public const string _Name = "APT_CULTURE_DATE_FORMAT_TYPE_ENUMSelect";
public const string _Caption = "APT_ CULTURE_ DATE_ FORMAT_ TYPE_ ENUMSelect";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_CULTURE_DATE_FORMAT_TYPE_ENUMSelect";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
}
public class rsAPT_CULTURE_DATE_FORMAT_TYPE_ENUMSelect
{
public const string _Name = "APT_CULTURE_DATE_FORMAT_TYPE_ENUMSelect";
public const string _Caption = "APT_ CULTURE_ DATE_ FORMAT_ TYPE_ ENUMSelect";
public const string _ParentName = "APT_CULTURE_DATE_FORMAT_TYPE_ENUMSelect";
public class slcCDF_CODE
{
public const string _Name = "CDF_CODE";
public const string _Caption = "CDF_ CODE";
public const string _ParentName = "APT_CULTURE_DATE_FORMAT_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcCDF_DESCRIPTION
{
public const string _Name = "CDF_DESCRIPTION";
public const string _Caption = "CDF_ DESCRIPTION";
public const string _ParentName = "APT_CULTURE_DATE_FORMAT_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcCDF_FORMAT
{
public const string _Name = "CDF_FORMAT";
public const string _Caption = "CDF_ FORMAT";
public const string _ParentName = "APT_CULTURE_DATE_FORMAT_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcValueCode
{
public const string _Name = "ValueCode";
public const string _Caption = "Value Code";
public const string _ParentName = "APT_CULTURE_DATE_FORMAT_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcValueName
{
public const string _Name = "ValueName";
public const string _Caption = "Value Name";
public const string _ParentName = "APT_CULTURE_DATE_FORMAT_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcValueNameEnum
{
public const string _Name = "ValueNameEnum";
public const string _Caption = "Value Name Enum";
public const string _ParentName = "APT_CULTURE_DATE_FORMAT_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
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
