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
public class tblT_SETTING
{
public const string _Name = "T_SETTING";
public const string _Caption = "T_ SETTING";

public class colSET_ID
{
public const string _Name = "SET_ID";
public const string _Caption = "SET_ ID";
public const string _Description = "PK. Should be equal to 1. MADA.Facedate.WS.Properties.Settings has a definition of SET_ID = 1";
public const string _ParentName = "T_SETTING";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = true;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = true;
public const string _BindDataAdapter = "T_SETTING.DefaultView.[0].SET_ID";
public const string _BindDataReader = "[SET_ID]";
}
public class colSET_MAX_ROWS_ON_SP_SELECT
{
public const string _Name = "SET_MAX_ROWS_ON_SP_SELECT";
public const string _Caption = "SET_ MAX_ ROWS_ ON_ SP_ SELECT";
public const string _Description = "";
public const string _ParentName = "T_SETTING";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_SETTING.DefaultView.[0].SET_MAX_ROWS_ON_SP_SELECT";
public const string _BindDataReader = "[SET_MAX_ROWS_ON_SP_SELECT]";
}
public class idcSET_ID : colSET_ID {}
public class idxPK_T_SETTING
{
public const string _Name = "PK_T_SETTING";
public const string _Caption = "PK_ T_ SETTING";
public const string _ParentName = "T_SETTING";
public const bool _IsPrimaryKey = true;

public class ixcSET_ID : colSET_ID {}
}
public class pkxPK_T_SETTING : idxPK_T_SETTING {}
}
}
