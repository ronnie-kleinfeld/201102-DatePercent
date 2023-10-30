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
public class procAPT_SERVERUpdateBySRV_ID
{
public const string _Name = "APT_SERVERUpdateBySRV_ID";
public const string _Caption = "APT_ SERVERUpdate By SRV_ ID";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_SERVERUpdateBySRV_ID";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
string p_strSRV_DB_CONTROL_PANEL, string p_strSRV_DB_COST, string p_strSRV_DB_DNS, string p_strSRV_DB_NAME, string p_strSRV_HOST_APP_POOL_URL, System.Nullable<int> p_iSRV_HOST_CODE, string p_strSRV_HOST_CONTROL_PANEL_1, string p_strSRV_HOST_CONTROL_PANEL_2, string p_strSRV_HOST_COST, System.Nullable<decimal> p_decSRV_HOST_LAT, System.Nullable<decimal> p_decSRV_HOST_LNG, string p_strSRV_HOST_LOCATION, string p_strSRV_HOST_PDF, System.Nullable<int> p_iSRV_ID, System.Nullable<bool> p_bSRV_IS_SSL, System.Nullable<int> p_iSRV_REG_CODE, string p_strSRV_REG_DNS, string p_strSRV_REG_DNS_CONTROL_PANEL, string p_strSRV_REG_DNS_COST, string p_strSRV_REG_SUB_DOMAIN_NAME, System.Nullable<int> p_iSRV_SERVER_TYPE)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_SERVERUpdateBySRV_ID";
SqlParameterCollection(cmd.Parameters, p_strSRV_DB_CONTROL_PANEL, p_strSRV_DB_COST, p_strSRV_DB_DNS, p_strSRV_DB_NAME, p_strSRV_HOST_APP_POOL_URL, p_iSRV_HOST_CODE, p_strSRV_HOST_CONTROL_PANEL_1, p_strSRV_HOST_CONTROL_PANEL_2, p_strSRV_HOST_COST, p_decSRV_HOST_LAT, p_decSRV_HOST_LNG, p_strSRV_HOST_LOCATION, p_strSRV_HOST_PDF, p_iSRV_ID, p_bSRV_IS_SSL, p_iSRV_REG_CODE, p_strSRV_REG_DNS, p_strSRV_REG_DNS_CONTROL_PANEL, p_strSRV_REG_DNS_COST, p_strSRV_REG_SUB_DOMAIN_NAME, p_iSRV_SERVER_TYPE);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parSRV_DB_CONTROL_PANEL._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_DB_COST._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_DB_DNS._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_DB_NAME._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_HOST_APP_POOL_URL._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_HOST_CODE._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_HOST_CONTROL_PANEL_1._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_HOST_CONTROL_PANEL_2._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_HOST_COST._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_HOST_LAT._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_HOST_LNG._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_HOST_LOCATION._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_HOST_PDF._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_ID._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_IS_SSL._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_REG_CODE._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_REG_DNS._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_REG_DNS_CONTROL_PANEL._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_REG_DNS_COST._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_REG_SUB_DOMAIN_NAME._SqlParameter());
p_oSqlParameterCollection.Add(parSRV_SERVER_TYPE._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, string p_strSRV_DB_CONTROL_PANEL, string p_strSRV_DB_COST, string p_strSRV_DB_DNS, string p_strSRV_DB_NAME, string p_strSRV_HOST_APP_POOL_URL, System.Nullable<int> p_iSRV_HOST_CODE, string p_strSRV_HOST_CONTROL_PANEL_1, string p_strSRV_HOST_CONTROL_PANEL_2, string p_strSRV_HOST_COST, System.Nullable<decimal> p_decSRV_HOST_LAT, System.Nullable<decimal> p_decSRV_HOST_LNG, string p_strSRV_HOST_LOCATION, string p_strSRV_HOST_PDF, System.Nullable<int> p_iSRV_ID, System.Nullable<bool> p_bSRV_IS_SSL, System.Nullable<int> p_iSRV_REG_CODE, string p_strSRV_REG_DNS, string p_strSRV_REG_DNS_CONTROL_PANEL, string p_strSRV_REG_DNS_COST, string p_strSRV_REG_SUB_DOMAIN_NAME, System.Nullable<int> p_iSRV_SERVER_TYPE)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parSRV_DB_CONTROL_PANEL._SqlParameter(p_strSRV_DB_CONTROL_PANEL));
p_oSqlParameterCollection.Add(parSRV_DB_COST._SqlParameter(p_strSRV_DB_COST));
p_oSqlParameterCollection.Add(parSRV_DB_DNS._SqlParameter(p_strSRV_DB_DNS));
p_oSqlParameterCollection.Add(parSRV_DB_NAME._SqlParameter(p_strSRV_DB_NAME));
p_oSqlParameterCollection.Add(parSRV_HOST_APP_POOL_URL._SqlParameter(p_strSRV_HOST_APP_POOL_URL));
p_oSqlParameterCollection.Add(parSRV_HOST_CODE._SqlParameter(p_iSRV_HOST_CODE));
p_oSqlParameterCollection.Add(parSRV_HOST_CONTROL_PANEL_1._SqlParameter(p_strSRV_HOST_CONTROL_PANEL_1));
p_oSqlParameterCollection.Add(parSRV_HOST_CONTROL_PANEL_2._SqlParameter(p_strSRV_HOST_CONTROL_PANEL_2));
p_oSqlParameterCollection.Add(parSRV_HOST_COST._SqlParameter(p_strSRV_HOST_COST));
p_oSqlParameterCollection.Add(parSRV_HOST_LAT._SqlParameter(p_decSRV_HOST_LAT));
p_oSqlParameterCollection.Add(parSRV_HOST_LNG._SqlParameter(p_decSRV_HOST_LNG));
p_oSqlParameterCollection.Add(parSRV_HOST_LOCATION._SqlParameter(p_strSRV_HOST_LOCATION));
p_oSqlParameterCollection.Add(parSRV_HOST_PDF._SqlParameter(p_strSRV_HOST_PDF));
p_oSqlParameterCollection.Add(parSRV_ID._SqlParameter(p_iSRV_ID));
p_oSqlParameterCollection.Add(parSRV_IS_SSL._SqlParameter(p_bSRV_IS_SSL));
p_oSqlParameterCollection.Add(parSRV_REG_CODE._SqlParameter(p_iSRV_REG_CODE));
p_oSqlParameterCollection.Add(parSRV_REG_DNS._SqlParameter(p_strSRV_REG_DNS));
p_oSqlParameterCollection.Add(parSRV_REG_DNS_CONTROL_PANEL._SqlParameter(p_strSRV_REG_DNS_CONTROL_PANEL));
p_oSqlParameterCollection.Add(parSRV_REG_DNS_COST._SqlParameter(p_strSRV_REG_DNS_COST));
p_oSqlParameterCollection.Add(parSRV_REG_SUB_DOMAIN_NAME._SqlParameter(p_strSRV_REG_SUB_DOMAIN_NAME));
p_oSqlParameterCollection.Add(parSRV_SERVER_TYPE._SqlParameter(p_iSRV_SERVER_TYPE));
}
public class parSRV_DB_CONTROL_PANEL
{
public const string _Name = "@SRV_DB_CONTROL_PANEL";
public const string _Caption = "@ SRV_ DB_ CONTROL_ PANEL";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_DB_CONTROL_PANEL";
public const string _BindDataReader = "[@SRV_DB_CONTROL_PANEL]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_DB_CONTROL_PANEL", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_DB_CONTROL_PANEL", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_DB_COST
{
public const string _Name = "@SRV_DB_COST";
public const string _Caption = "@ SRV_ DB_ COST";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_DB_COST";
public const string _BindDataReader = "[@SRV_DB_COST]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_DB_COST", 50, -1, 50, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_DB_COST", 50, -1, 50, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_DB_DNS
{
public const string _Name = "@SRV_DB_DNS";
public const string _Caption = "@ SRV_ DB_ DNS";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_DB_DNS";
public const string _BindDataReader = "[@SRV_DB_DNS]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_DB_DNS", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_DB_DNS", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_DB_NAME
{
public const string _Name = "@SRV_DB_NAME";
public const string _Caption = "@ SRV_ DB_ NAME";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_DB_NAME";
public const string _BindDataReader = "[@SRV_DB_NAME]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_DB_NAME", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_DB_NAME", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_HOST_APP_POOL_URL
{
public const string _Name = "@SRV_HOST_APP_POOL_URL";
public const string _Caption = "@ SRV_ HOST_ APP_ POOL_ URL";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_HOST_APP_POOL_URL";
public const string _BindDataReader = "[@SRV_HOST_APP_POOL_URL]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_HOST_APP_POOL_URL", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_HOST_APP_POOL_URL", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_HOST_CODE
{
public const string _Name = "@SRV_HOST_CODE";
public const string _Caption = "@ SRV_ HOST_ CODE";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_HOST_CODE";
public const string _BindDataReader = "[@SRV_HOST_CODE]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_HOST_CODE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_HOST_CODE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_HOST_CONTROL_PANEL_1
{
public const string _Name = "@SRV_HOST_CONTROL_PANEL_1";
public const string _Caption = "@ SRV_ HOST_ CONTROL_ PANEL_1";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_HOST_CONTROL_PANEL_1";
public const string _BindDataReader = "[@SRV_HOST_CONTROL_PANEL_1]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_HOST_CONTROL_PANEL_1", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_HOST_CONTROL_PANEL_1", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_HOST_CONTROL_PANEL_2
{
public const string _Name = "@SRV_HOST_CONTROL_PANEL_2";
public const string _Caption = "@ SRV_ HOST_ CONTROL_ PANEL_2";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_HOST_CONTROL_PANEL_2";
public const string _BindDataReader = "[@SRV_HOST_CONTROL_PANEL_2]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_HOST_CONTROL_PANEL_2", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_HOST_CONTROL_PANEL_2", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_HOST_COST
{
public const string _Name = "@SRV_HOST_COST";
public const string _Caption = "@ SRV_ HOST_ COST";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_HOST_COST";
public const string _BindDataReader = "[@SRV_HOST_COST]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_HOST_COST", 50, -1, 50, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_HOST_COST", 50, -1, 50, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_HOST_LAT
{
public const string _Name = "@SRV_HOST_LAT";
public const string _Caption = "@ SRV_ HOST_ LAT";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.Decimal;
public const Int32 _Length = 9;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_HOST_LAT";
public const string _BindDataReader = "[@SRV_HOST_LAT]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_HOST_LAT", 18, 12, 9, SqlDbType.Decimal, "decimal", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<decimal> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_HOST_LAT", 18, 12, 9, SqlDbType.Decimal, "decimal", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_HOST_LNG
{
public const string _Name = "@SRV_HOST_LNG";
public const string _Caption = "@ SRV_ HOST_ LNG";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.Decimal;
public const Int32 _Length = 9;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_HOST_LNG";
public const string _BindDataReader = "[@SRV_HOST_LNG]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_HOST_LNG", 18, 12, 9, SqlDbType.Decimal, "decimal", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<decimal> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_HOST_LNG", 18, 12, 9, SqlDbType.Decimal, "decimal", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_HOST_LOCATION
{
public const string _Name = "@SRV_HOST_LOCATION";
public const string _Caption = "@ SRV_ HOST_ LOCATION";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_HOST_LOCATION";
public const string _BindDataReader = "[@SRV_HOST_LOCATION]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_HOST_LOCATION", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_HOST_LOCATION", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_HOST_PDF
{
public const string _Name = "@SRV_HOST_PDF";
public const string _Caption = "@ SRV_ HOST_ PDF";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_HOST_PDF";
public const string _BindDataReader = "[@SRV_HOST_PDF]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_HOST_PDF", 50, -1, 50, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_HOST_PDF", 50, -1, 50, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_ID
{
public const string _Name = "@SRV_ID";
public const string _Caption = "@ SRV_ ID";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_ID";
public const string _BindDataReader = "[@SRV_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_IS_SSL
{
public const string _Name = "@SRV_IS_SSL";
public const string _Caption = "@ SRV_ IS_ SSL";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = 1;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_IS_SSL";
public const string _BindDataReader = "[@SRV_IS_SSL]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_IS_SSL", 1, -1, 1, SqlDbType.Bit, "bool", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<bool> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_IS_SSL", 1, -1, 1, SqlDbType.Bit, "bool", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_REG_CODE
{
public const string _Name = "@SRV_REG_CODE";
public const string _Caption = "@ SRV_ REG_ CODE";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_REG_CODE";
public const string _BindDataReader = "[@SRV_REG_CODE]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_REG_CODE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_REG_CODE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_REG_DNS
{
public const string _Name = "@SRV_REG_DNS";
public const string _Caption = "@ SRV_ REG_ DNS";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_REG_DNS";
public const string _BindDataReader = "[@SRV_REG_DNS]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_REG_DNS", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_REG_DNS", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_REG_DNS_CONTROL_PANEL
{
public const string _Name = "@SRV_REG_DNS_CONTROL_PANEL";
public const string _Caption = "@ SRV_ REG_ DNS_ CONTROL_ PANEL";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_REG_DNS_CONTROL_PANEL";
public const string _BindDataReader = "[@SRV_REG_DNS_CONTROL_PANEL]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_REG_DNS_CONTROL_PANEL", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_REG_DNS_CONTROL_PANEL", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_REG_DNS_COST
{
public const string _Name = "@SRV_REG_DNS_COST";
public const string _Caption = "@ SRV_ REG_ DNS_ COST";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_REG_DNS_COST";
public const string _BindDataReader = "[@SRV_REG_DNS_COST]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_REG_DNS_COST", 50, -1, 50, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_REG_DNS_COST", 50, -1, 50, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_REG_SUB_DOMAIN_NAME
{
public const string _Name = "@SRV_REG_SUB_DOMAIN_NAME";
public const string _Caption = "@ SRV_ REG_ SUB_ DOMAIN_ NAME";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_REG_SUB_DOMAIN_NAME";
public const string _BindDataReader = "[@SRV_REG_SUB_DOMAIN_NAME]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_REG_SUB_DOMAIN_NAME", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_REG_SUB_DOMAIN_NAME", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parSRV_SERVER_TYPE
{
public const string _Name = "@SRV_SERVER_TYPE";
public const string _Caption = "@ SRV_ SERVER_ TYPE";
public const string _ParentName = "APT_SERVERUpdateBySRV_ID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_SERVERUpdateBySRV_ID.DefaultView.[0].@SRV_SERVER_TYPE";
public const string _BindDataReader = "[@SRV_SERVER_TYPE]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_SERVER_TYPE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@SRV_SERVER_TYPE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class inSRV_DB_CONTROL_PANEL : parSRV_DB_CONTROL_PANEL {}
public class inSRV_DB_COST : parSRV_DB_COST {}
public class inSRV_DB_DNS : parSRV_DB_DNS {}
public class inSRV_DB_NAME : parSRV_DB_NAME {}
public class inSRV_HOST_APP_POOL_URL : parSRV_HOST_APP_POOL_URL {}
public class inSRV_HOST_CODE : parSRV_HOST_CODE {}
public class inSRV_HOST_CONTROL_PANEL_1 : parSRV_HOST_CONTROL_PANEL_1 {}
public class inSRV_HOST_CONTROL_PANEL_2 : parSRV_HOST_CONTROL_PANEL_2 {}
public class inSRV_HOST_COST : parSRV_HOST_COST {}
public class inSRV_HOST_LAT : parSRV_HOST_LAT {}
public class inSRV_HOST_LNG : parSRV_HOST_LNG {}
public class inSRV_HOST_LOCATION : parSRV_HOST_LOCATION {}
public class inSRV_HOST_PDF : parSRV_HOST_PDF {}
public class inSRV_ID : parSRV_ID {}
public class inSRV_IS_SSL : parSRV_IS_SSL {}
public class inSRV_REG_CODE : parSRV_REG_CODE {}
public class inSRV_REG_DNS : parSRV_REG_DNS {}
public class inSRV_REG_DNS_CONTROL_PANEL : parSRV_REG_DNS_CONTROL_PANEL {}
public class inSRV_REG_DNS_COST : parSRV_REG_DNS_COST {}
public class inSRV_REG_SUB_DOMAIN_NAME : parSRV_REG_SUB_DOMAIN_NAME {}
public class inSRV_SERVER_TYPE : parSRV_SERVER_TYPE {}
public static int ExecuteNonQuery(
string p_strSRV_DB_CONTROL_PANEL, string p_strSRV_DB_COST, string p_strSRV_DB_DNS, string p_strSRV_DB_NAME, string p_strSRV_HOST_APP_POOL_URL, System.Nullable<int> p_iSRV_HOST_CODE, string p_strSRV_HOST_CONTROL_PANEL_1, string p_strSRV_HOST_CONTROL_PANEL_2, string p_strSRV_HOST_COST, System.Nullable<decimal> p_decSRV_HOST_LAT, System.Nullable<decimal> p_decSRV_HOST_LNG, string p_strSRV_HOST_LOCATION, string p_strSRV_HOST_PDF, System.Nullable<int> p_iSRV_ID, System.Nullable<bool> p_bSRV_IS_SSL, System.Nullable<int> p_iSRV_REG_CODE, string p_strSRV_REG_DNS, string p_strSRV_REG_DNS_CONTROL_PANEL, string p_strSRV_REG_DNS_COST, string p_strSRV_REG_SUB_DOMAIN_NAME, System.Nullable<int> p_iSRV_SERVER_TYPE)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_strSRV_DB_CONTROL_PANEL, p_strSRV_DB_COST, p_strSRV_DB_DNS, p_strSRV_DB_NAME, p_strSRV_HOST_APP_POOL_URL, p_iSRV_HOST_CODE, p_strSRV_HOST_CONTROL_PANEL_1, p_strSRV_HOST_CONTROL_PANEL_2, p_strSRV_HOST_COST, p_decSRV_HOST_LAT, p_decSRV_HOST_LNG, p_strSRV_HOST_LOCATION, p_strSRV_HOST_PDF, p_iSRV_ID, p_bSRV_IS_SSL, p_iSRV_REG_CODE, p_strSRV_REG_DNS, p_strSRV_REG_DNS_CONTROL_PANEL, p_strSRV_REG_DNS_COST, p_strSRV_REG_SUB_DOMAIN_NAME, p_iSRV_SERVER_TYPE);
int iResult = db.ExecuteNonQuery(cmd);

return iResult;
}
catch (System.Exception ex)
{
MADA.DatePercent.BB.NLB.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static int ExecuteNonQuery(
string p_strSRV_DB_CONTROL_PANEL, string p_strSRV_DB_COST, string p_strSRV_DB_DNS, string p_strSRV_DB_NAME, string p_strSRV_HOST_APP_POOL_URL, System.Nullable<int> p_iSRV_HOST_CODE, string p_strSRV_HOST_CONTROL_PANEL_1, string p_strSRV_HOST_CONTROL_PANEL_2, string p_strSRV_HOST_COST, System.Nullable<decimal> p_decSRV_HOST_LAT, System.Nullable<decimal> p_decSRV_HOST_LNG, string p_strSRV_HOST_LOCATION, string p_strSRV_HOST_PDF, System.Nullable<int> p_iSRV_ID, System.Nullable<bool> p_bSRV_IS_SSL, System.Nullable<int> p_iSRV_REG_CODE, string p_strSRV_REG_DNS, string p_strSRV_REG_DNS_CONTROL_PANEL, string p_strSRV_REG_DNS_COST, string p_strSRV_REG_SUB_DOMAIN_NAME, System.Nullable<int> p_iSRV_SERVER_TYPE,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_strSRV_DB_CONTROL_PANEL, p_strSRV_DB_COST, p_strSRV_DB_DNS, p_strSRV_DB_NAME, p_strSRV_HOST_APP_POOL_URL, p_iSRV_HOST_CODE, p_strSRV_HOST_CONTROL_PANEL_1, p_strSRV_HOST_CONTROL_PANEL_2, p_strSRV_HOST_COST, p_decSRV_HOST_LAT, p_decSRV_HOST_LNG, p_strSRV_HOST_LOCATION, p_strSRV_HOST_PDF, p_iSRV_ID, p_bSRV_IS_SSL, p_iSRV_REG_CODE, p_strSRV_REG_DNS, p_strSRV_REG_DNS_CONTROL_PANEL, p_strSRV_REG_DNS_COST, p_strSRV_REG_SUB_DOMAIN_NAME, p_iSRV_SERVER_TYPE);
int iResult = p_db.ExecuteNonQuery(cmd, p_trn);

return iResult;
}
catch (System.Exception ex)
{
MADA.DatePercent.BB.NLB.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
