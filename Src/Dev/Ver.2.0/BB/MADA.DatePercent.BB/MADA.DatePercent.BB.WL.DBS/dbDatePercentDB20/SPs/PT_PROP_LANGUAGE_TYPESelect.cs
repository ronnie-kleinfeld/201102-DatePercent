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
public class procPT_PROP_LANGUAGE_TYPESelect
{
public const string _Name = "PT_PROP_LANGUAGE_TYPESelect";
public const string _Caption = "PT_ PROP_ LANGUAGE_ TYPESelect";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_PROP_LANGUAGE_TYPESelect";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
}
public class rsPT_PROP_LANGUAGE_TYPESelect
{
public const string _Name = "PT_PROP_LANGUAGE_TYPESelect";
public const string _Caption = "PT_ PROP_ LANGUAGE_ TYPESelect";
public const string _ParentName = "PT_PROP_LANGUAGE_TYPESelect";
public class slcdata
{
public const string _Name = "data";
public const string _Caption = "data";
public const string _ParentName = "PT_PROP_LANGUAGE_TYPESelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slclabel
{
public const string _Name = "label";
public const string _Caption = "label";
public const string _ParentName = "PT_PROP_LANGUAGE_TYPESelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcLNG_CODE
{
public const string _Name = "LNG_CODE";
public const string _Caption = "LNG_ CODE";
public const string _ParentName = "PT_PROP_LANGUAGE_TYPESelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcLNG_DESCRIPTION
{
public const string _Name = "LNG_DESCRIPTION";
public const string _Caption = "LNG_ DESCRIPTION";
public const string _ParentName = "PT_PROP_LANGUAGE_TYPESelect";
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
