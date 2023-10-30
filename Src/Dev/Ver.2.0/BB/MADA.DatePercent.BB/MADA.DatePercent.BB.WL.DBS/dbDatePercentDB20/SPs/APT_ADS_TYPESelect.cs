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
public class procAPT_ADS_TYPESelect
{
public const string _Name = "APT_ADS_TYPESelect";
public const string _Caption = "APT_ ADS_ TYPESelect";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_ADS_TYPESelect";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
}
public class rsAPT_ADS_TYPESelect
{
public const string _Name = "APT_ADS_TYPESelect";
public const string _Caption = "APT_ ADS_ TYPESelect";
public const string _ParentName = "APT_ADS_TYPESelect";
public class slcADS_CODE
{
public const string _Name = "ADS_CODE";
public const string _Caption = "ADS_ CODE";
public const string _ParentName = "APT_ADS_TYPESelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcADS_DESCRIPTION
{
public const string _Name = "ADS_DESCRIPTION";
public const string _Caption = "ADS_ DESCRIPTION";
public const string _ParentName = "APT_ADS_TYPESelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcADS_REGISTRATION_APP_IMAGE
{
public const string _Name = "ADS_REGISTRATION_APP_IMAGE";
public const string _Caption = "ADS_ REGISTRATION_ APP_ IMAGE";
public const string _ParentName = "APT_ADS_TYPESelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcADS_SPLASH_LOADER_IMAGE
{
public const string _Name = "ADS_SPLASH_LOADER_IMAGE";
public const string _Caption = "ADS_ SPLASH_ LOADER_ IMAGE";
public const string _ParentName = "APT_ADS_TYPESelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcADS_STARTER_IMAGE
{
public const string _Name = "ADS_STARTER_IMAGE";
public const string _Caption = "ADS_ STARTER_ IMAGE";
public const string _ParentName = "APT_ADS_TYPESelect";
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
