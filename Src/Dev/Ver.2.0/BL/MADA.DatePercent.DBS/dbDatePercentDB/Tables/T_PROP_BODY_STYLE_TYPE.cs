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
public class tblT_PROP_BODY_STYLE_TYPE
{
public const string _Name = "T_PROP_BODY_STYLE_TYPE";
public const string _Caption = "T_ PROP_ BODY_ STYLE_ TYPE";

public class colBDY_CODE
{
public const string _Name = "BDY_CODE";
public const string _Caption = "BDY_ CODE";
public const string _Description = "";
public const string _ParentName = "T_PROP_BODY_STYLE_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = true;
public const string _BindDataAdapter = "T_PROP_BODY_STYLE_TYPE.DefaultView.[0].BDY_CODE";
public const string _BindDataReader = "[BDY_CODE]";
}
public class colBDY_DESCRIPTION
{
public const string _Name = "BDY_DESCRIPTION";
public const string _Caption = "BDY_ DESCRIPTION";
public const string _Description = "";
public const string _ParentName = "T_PROP_BODY_STYLE_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = true;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_PROP_BODY_STYLE_TYPE.DefaultView.[0].BDY_DESCRIPTION";
public const string _BindDataReader = "[BDY_DESCRIPTION]";
}
public class idxPK_T_BODY_STYLE_TYPE
{
public const string _Name = "PK_T_BODY_STYLE_TYPE";
public const string _Caption = "PK_ T_ BODY_ STYLE_ TYPE";
public const string _ParentName = "T_PROP_BODY_STYLE_TYPE";
public const bool _IsPrimaryKey = true;

public class ixcBDY_CODE : colBDY_CODE {}
}
public class pkxPK_T_BODY_STYLE_TYPE : idxPK_T_BODY_STYLE_TYPE {}
}
}
