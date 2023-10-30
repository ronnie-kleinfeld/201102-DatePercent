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

namespace MADA.DatePercent.DBS.dbDatePercentDB.Tables
{
public class tblT_FAQ_TYPE
{
public const string _Name = "T_FAQ_TYPE";
public const string _Caption = "T_ FAQ_ TYPE";

public class colFQT_CODE
{
public const string _Name = "FQT_CODE";
public const string _Caption = "FQT_ CODE";
public const string _Description = "";
public const string _ParentName = "T_FAQ_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = true;
public const string _BindDataAdapter = "T_FAQ_TYPE.DefaultView.[0].FQT_CODE";
public const string _BindDataReader = "[FQT_CODE]";
}
public class colFQT_DESCRIPTION
{
public const string _Name = "FQT_DESCRIPTION";
public const string _Caption = "FQT_ DESCRIPTION";
public const string _Description = "";
public const string _ParentName = "T_FAQ_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = true;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_FAQ_TYPE.DefaultView.[0].FQT_DESCRIPTION";
public const string _BindDataReader = "[FQT_DESCRIPTION]";
}
public class colFQT_DISABLED
{
public const string _Name = "FQT_DISABLED";
public const string _Caption = "FQT_ DISABLED";
public const string _Description = "";
public const string _ParentName = "T_FAQ_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = 1;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_FAQ_TYPE.DefaultView.[0].FQT_DISABLED";
public const string _BindDataReader = "[FQT_DISABLED]";
}
public class colFQT_ORDER_BY
{
public const string _Name = "FQT_ORDER_BY";
public const string _Caption = "FQT_ ORDER_ BY";
public const string _Description = "";
public const string _ParentName = "T_FAQ_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_FAQ_TYPE.DefaultView.[0].FQT_ORDER_BY";
public const string _BindDataReader = "[FQT_ORDER_BY]";
}
public class colFQT_SELECTED
{
public const string _Name = "FQT_SELECTED";
public const string _Caption = "FQT_ SELECTED";
public const string _Description = "";
public const string _ParentName = "T_FAQ_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = 1;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_FAQ_TYPE.DefaultView.[0].FQT_SELECTED";
public const string _BindDataReader = "[FQT_SELECTED]";
}
public class idxPK_T_FQT
{
public const string _Name = "PK_T_FQT";
public const string _Caption = "PK_ T_ FQT";
public const string _ParentName = "T_FAQ_TYPE";
public const bool _IsPrimaryKey = true;

public class ixcFQT_CODE : colFQT_CODE {}
}
public class pkxPK_T_FQT : idxPK_T_FQT {}
}
}
