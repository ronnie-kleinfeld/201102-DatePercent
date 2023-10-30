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
public class tblT_RESULT_CODE
{
public const string _Name = "T_RESULT_CODE";
public const string _Caption = "T_ RESULT_ CODE";

public class colRST_CODE
{
public const string _Name = "RST_CODE";
public const string _Caption = "RST_ CODE";
public const string _Description = "";
public const string _ParentName = "T_RESULT_CODE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = true;
public const string _BindDataAdapter = "T_RESULT_CODE.DefaultView.[0].RST_CODE";
public const string _BindDataReader = "[RST_CODE]";
}
public class colRST_DESCRIPTION
{
public const string _Name = "RST_DESCRIPTION";
public const string _Caption = "RST_ DESCRIPTION";
public const string _Description = "";
public const string _ParentName = "T_RESULT_CODE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_RESULT_CODE.DefaultView.[0].RST_DESCRIPTION";
public const string _BindDataReader = "[RST_DESCRIPTION]";
}
public class colRST_VALUE
{
public const string _Name = "RST_VALUE";
public const string _Caption = "RST_ VALUE";
public const string _Description = "";
public const string _ParentName = "T_RESULT_CODE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = true;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_RESULT_CODE.DefaultView.[0].RST_VALUE";
public const string _BindDataReader = "[RST_VALUE]";
}
public class idxIX_T_RESULT_CODE_RST_VALUE
{
public const string _Name = "IX_T_RESULT_CODE_RST_VALUE";
public const string _Caption = "IX_ T_ RESULT_ CODE_ RST_ VALUE";
public const string _ParentName = "T_RESULT_CODE";
public const bool _IsPrimaryKey = false;

public class ixcRST_VALUE : colRST_VALUE {}
}
public class idxPK_T_RESULT_CODE
{
public const string _Name = "PK_T_RESULT_CODE";
public const string _Caption = "PK_ T_ RESULT_ CODE";
public const string _ParentName = "T_RESULT_CODE";
public const bool _IsPrimaryKey = true;

public class ixcRST_CODE : colRST_CODE {}
}
public class pkxPK_T_RESULT_CODE : idxPK_T_RESULT_CODE {}
}
}
