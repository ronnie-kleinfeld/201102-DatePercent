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
public class procPT_USERSelectPropByUSR_ID
{
public const string _Name = "PT_USERSelectPropByUSR_ID";
public const string _Caption = "PT_ USERSelect Prop By USR_ ID";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_USERSelectPropByUSR_ID";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
System.Nullable<int> p_iUSR_ID)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "PT_USERSelectPropByUSR_ID";
SqlParameterCollection(cmd.Parameters, p_iUSR_ID);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUSR_ID._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, System.Nullable<int> p_iUSR_ID)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUSR_ID._SqlParameter(p_iUSR_ID));
}
public class parUSR_ID
{
public const string _Name = "@USR_ID";
public const string _Caption = "@ USR_ ID";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "PT_USERSelectPropByUSR_ID.DefaultView.[0].@USR_ID";
public const string _BindDataReader = "[@USR_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USR_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USR_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class inUSR_ID : parUSR_ID {}
public class rsPT_USERSelectPropByUSR_ID
{
public const string _Name = "PT_USERSelectPropByUSR_ID";
public const string _Caption = "PT_ USERSelect Prop By USR_ ID";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public class slcBDY_DESCRIPTION
{
public const string _Name = "BDY_DESCRIPTION";
public const string _Caption = "BDY_ DESCRIPTION";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcCTD_DESCRIPTION
{
public const string _Name = "CTD_DESCRIPTION";
public const string _Caption = "CTD_ DESCRIPTION";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcDRK_DESCRIPTION
{
public const string _Name = "DRK_DESCRIPTION";
public const string _Caption = "DRK_ DESCRIPTION";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcDRK_DESCRIPTION_MATCH
{
public const string _Name = "DRK_DESCRIPTION_MATCH";
public const string _Caption = "DRK_ DESCRIPTION_ MATCH";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcEDU_DESCRIPTION
{
public const string _Name = "EDU_DESCRIPTION";
public const string _Caption = "EDU_ DESCRIPTION";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcEYE_DESCRIPTION
{
public const string _Name = "EYE_DESCRIPTION";
public const string _Caption = "EYE_ DESCRIPTION";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcHAR_DESCRIPTION
{
public const string _Name = "HAR_DESCRIPTION";
public const string _Caption = "HAR_ DESCRIPTION";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcHGT_DESCRIPTION
{
public const string _Name = "HGT_DESCRIPTION";
public const string _Caption = "HGT_ DESCRIPTION";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcHKD_DESCRIPTION
{
public const string _Name = "HKD_DESCRIPTION";
public const string _Caption = "HKD_ DESCRIPTION";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcHKD_DESCRIPTION_MATCH
{
public const string _Name = "HKD_DESCRIPTION_MATCH";
public const string _Caption = "HKD_ DESCRIPTION_ MATCH";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcOCU_DESCRIPTION
{
public const string _Name = "OCU_DESCRIPTION";
public const string _Caption = "OCU_ DESCRIPTION";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcRCE_DESCRIPTION
{
public const string _Name = "RCE_DESCRIPTION";
public const string _Caption = "RCE_ DESCRIPTION";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcRCS_DESCRIPTION
{
public const string _Name = "RCS_DESCRIPTION";
public const string _Caption = "RCS_ DESCRIPTION";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcRLG_DESCRIPTION
{
public const string _Name = "RLG_DESCRIPTION";
public const string _Caption = "RLG_ DESCRIPTION";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcSEX_DESCRIPTION
{
public const string _Name = "SEX_DESCRIPTION";
public const string _Caption = "SEX_ DESCRIPTION";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcSMK_DESCRIPTION
{
public const string _Name = "SMK_DESCRIPTION";
public const string _Caption = "SMK_ DESCRIPTION";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcSMK_DESCRIPTION_MATCH
{
public const string _Name = "SMK_DESCRIPTION_MATCH";
public const string _Caption = "SMK_ DESCRIPTION_ MATCH";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcSXI_DESCRIPTION
{
public const string _Name = "SXI_DESCRIPTION";
public const string _Caption = "SXI_ DESCRIPTION";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcUSR_ID
{
public const string _Name = "USR_ID";
public const string _Caption = "USR_ ID";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_NAME
{
public const string _Name = "USR_NAME";
public const string _Caption = "USR_ NAME";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcUSR_PIC_URL
{
public const string _Name = "USR_PIC_URL";
public const string _Caption = "USR_ PIC_ URL";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
}
public class slcUSR_PROP_ABOUT_ME
{
public const string _Name = "USR_PROP_ABOUT_ME";
public const string _Caption = "USR_ PROP_ ABOUT_ ME";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
}
public class slcUSR_PROP_AGE_RANGE_FROM_CODE
{
public const string _Name = "USR_PROP_AGE_RANGE_FROM_CODE";
public const string _Caption = "USR_ PROP_ AGE_ RANGE_ FROM_ CODE";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_AGE_RANGE_TO_CODE
{
public const string _Name = "USR_PROP_AGE_RANGE_TO_CODE";
public const string _Caption = "USR_ PROP_ AGE_ RANGE_ TO_ CODE";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_BIRTHDATE
{
public const string _Name = "USR_PROP_BIRTHDATE";
public const string _Caption = "USR_ PROP_ BIRTHDATE";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.DateTime;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_MY_IDEAL_MATCH
{
public const string _Name = "USR_PROP_MY_IDEAL_MATCH";
public const string _Caption = "USR_ PROP_ MY_ IDEAL_ MATCH";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
}
public class slcUSR_PROP_SEX_CODE
{
public const string _Name = "USR_PROP_SEX_CODE";
public const string _Caption = "USR_ PROP_ SEX_ CODE";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_V_NAME
{
public const string _Name = "USR_V_NAME";
public const string _Caption = "USR_ V_ NAME";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 10;
}
public class slcVisibility
{
public const string _Name = "Visibility";
public const string _Caption = "Visibility";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcWGT_DESCRIPTION
{
public const string _Name = "WGT_DESCRIPTION";
public const string _Caption = "WGT_ DESCRIPTION";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcWKD_DESCRIPTION
{
public const string _Name = "WKD_DESCRIPTION";
public const string _Caption = "WKD_ DESCRIPTION";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcWKD_DESCRIPTION_MATCH
{
public const string _Name = "WKD_DESCRIPTION_MATCH";
public const string _Caption = "WKD_ DESCRIPTION_ MATCH";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcZDC_DESCRIPTION
{
public const string _Name = "ZDC_DESCRIPTION";
public const string _Caption = "ZDC_ DESCRIPTION";
public const string _ParentName = "PT_USERSelectPropByUSR_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<int> p_iUSR_ID)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_iUSR_ID);
db.LoadDataSet(cmd, p_ds, p_strTableName);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,System.Nullable<int> p_iUSR_ID,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_iUSR_ID);
p_db.LoadDataSet(cmd, p_ds, p_strTableName, p_trn);}
catch (System.Exception ex)
{
MADA.DatePercent.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
