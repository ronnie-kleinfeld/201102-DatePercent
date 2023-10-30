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
public class procAPT_LINK_TYPE_ENUMSelect
{
public const string _Name = "APT_LINK_TYPE_ENUMSelect";
public const string _Caption = "APT_ LINK_ TYPE_ ENUMSelect";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_LINK_TYPE_ENUMSelect";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
}
public class rsAPT_LINK_TYPE_ENUMSelect
{
public const string _Name = "APT_LINK_TYPE_ENUMSelect";
public const string _Caption = "APT_ LINK_ TYPE_ ENUMSelect";
public const string _ParentName = "APT_LINK_TYPE_ENUMSelect";
public class slcLKT_CODE
{
public const string _Name = "LKT_CODE";
public const string _Caption = "LKT_ CODE";
public const string _ParentName = "APT_LINK_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcLKT_DESCRIPTION
{
public const string _Name = "LKT_DESCRIPTION";
public const string _Caption = "LKT_ DESCRIPTION";
public const string _ParentName = "APT_LINK_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcLKT_LINK_ACTION_TYPE_1
{
public const string _Name = "LKT_LINK_ACTION_TYPE_1";
public const string _Caption = "LKT_ LINK_ ACTION_ TYPE_1";
public const string _ParentName = "APT_LINK_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcLKT_LINK_ACTION_TYPE_2
{
public const string _Name = "LKT_LINK_ACTION_TYPE_2";
public const string _Caption = "LKT_ LINK_ ACTION_ TYPE_2";
public const string _ParentName = "APT_LINK_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcLKT_SMAP_PARAMETER_VISIBLE
{
public const string _Name = "LKT_SMAP_PARAMETER_VISIBLE";
public const string _Caption = "LKT_ SMAP_ PARAMETER_ VISIBLE";
public const string _ParentName = "APT_LINK_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = -1;
}
public class slcLKT_SMAP_PARAMETER_VISIBLE_DESCRIPTION
{
public const string _Name = "LKT_SMAP_PARAMETER_VISIBLE_DESCRIPTION";
public const string _Caption = "LKT_ SMAP_ PARAMETER_ VISIBLE_ DESCRIPTION";
public const string _ParentName = "APT_LINK_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcLKT_SMAP_PARAMETER_VISIBLE_ORDER_BY
{
public const string _Name = "LKT_SMAP_PARAMETER_VISIBLE_ORDER_BY";
public const string _Caption = "LKT_ SMAP_ PARAMETER_ VISIBLE_ ORDER_ BY";
public const string _ParentName = "APT_LINK_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcLKT_SRC
{
public const string _Name = "LKT_SRC";
public const string _Caption = "LKT_ SRC";
public const string _ParentName = "APT_LINK_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcLKT_TEXT
{
public const string _Name = "LKT_TEXT";
public const string _Caption = "LKT_ TEXT";
public const string _ParentName = "APT_LINK_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcValueCode
{
public const string _Name = "ValueCode";
public const string _Caption = "Value Code";
public const string _ParentName = "APT_LINK_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcValueName
{
public const string _Name = "ValueName";
public const string _Caption = "Value Name";
public const string _ParentName = "APT_LINK_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcValueNameEnum
{
public const string _Name = "ValueNameEnum";
public const string _Caption = "Value Name Enum";
public const string _ParentName = "APT_LINK_TYPE_ENUMSelect";
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
