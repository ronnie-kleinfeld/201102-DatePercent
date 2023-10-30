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
public class procAPT_HOSTINGSelect
{
public const string _Name = "APT_HOSTINGSelect";
public const string _Caption = "APT_ HOSTINGSelect";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_HOSTINGSelect";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
}
public class rsAPT_HOSTINGSelect
{
public const string _Name = "APT_HOSTINGSelect";
public const string _Caption = "APT_ HOSTINGSelect";
public const string _ParentName = "APT_HOSTINGSelect";
public class slcHST_DESCRIPTION
{
public const string _Name = "HST_DESCRIPTION";
public const string _Caption = "HST_ DESCRIPTION";
public const string _ParentName = "APT_HOSTINGSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcHST_ID
{
public const string _Name = "HST_ID";
public const string _Caption = "HST_ ID";
public const string _ParentName = "APT_HOSTINGSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcHST_WEB_SITE
{
public const string _Name = "HST_WEB_SITE";
public const string _Caption = "HST_ WEB_ SITE";
public const string _ParentName = "APT_HOSTINGSelect";
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
MADA.DatePercent.BB.NLB.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
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
MADA.DatePercent.BB.NLB.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
