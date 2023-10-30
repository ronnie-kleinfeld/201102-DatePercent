//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by the Database Schema tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
//
//     Exception should be handled in a higher layer.
//
//     generation time: 29/03/2012 14:43
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MADA.DatePercent.BB.Storage.DBS.dbStorageDB.SPs
{
public class procAPT_USER_LINK_TYPE_ENUMSelect
{
public const string _Name = "APT_USER_LINK_TYPE_ENUMSelect";
public const string _Caption = "APT_ USER_ LINK_ TYPE_ ENUMSelect";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_USER_LINK_TYPE_ENUMSelect";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
}
public class rsAPT_USER_LINK_TYPE_ENUMSelect
{
public const string _Name = "APT_USER_LINK_TYPE_ENUMSelect";
public const string _Caption = "APT_ USER_ LINK_ TYPE_ ENUMSelect";
public const string _ParentName = "APT_USER_LINK_TYPE_ENUMSelect";
public class slcUST_CODE
{
public const string _Name = "UST_CODE";
public const string _Caption = "UST_ CODE";
public const string _ParentName = "APT_USER_LINK_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUST_DESCRIPTION
{
public const string _Name = "UST_DESCRIPTION";
public const string _Caption = "UST_ DESCRIPTION";
public const string _ParentName = "APT_USER_LINK_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcValueCode
{
public const string _Name = "ValueCode";
public const string _Caption = "Value Code";
public const string _ParentName = "APT_USER_LINK_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcValueName
{
public const string _Name = "ValueName";
public const string _Caption = "Value Name";
public const string _ParentName = "APT_USER_LINK_TYPE_ENUMSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcValueNameEnum
{
public const string _Name = "ValueNameEnum";
public const string _Caption = "Value Name Enum";
public const string _ParentName = "APT_USER_LINK_TYPE_ENUMSelect";
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
MADA.DatePercent.BB.Storage.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
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
MADA.DatePercent.BB.Storage.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
