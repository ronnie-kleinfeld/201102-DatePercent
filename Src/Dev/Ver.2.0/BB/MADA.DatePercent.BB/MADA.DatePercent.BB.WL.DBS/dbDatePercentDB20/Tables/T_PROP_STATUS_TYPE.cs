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

namespace MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.Tables
{
public class tblT_PROP_STATUS_TYPE
{
public const string _Name = "T_PROP_STATUS_TYPE";
public const string _Caption = "T_ PROP_ STATUS_ TYPE";

public class colRCS_CODE
{
public const string _Name = "RCS_CODE";
public const string _Caption = "RCS_ CODE";
public const string _Description = "";
public const string _ParentName = "T_PROP_STATUS_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = true;
public const string _BindDataAdapter = "T_PROP_STATUS_TYPE.DefaultView.[0].RCS_CODE";
public const string _BindDataReader = "[RCS_CODE]";
}
public class colRCS_DESCRIPTION
{
public const string _Name = "RCS_DESCRIPTION";
public const string _Caption = "RCS_ DESCRIPTION";
public const string _Description = "";
public const string _ParentName = "T_PROP_STATUS_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = true;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_PROP_STATUS_TYPE.DefaultView.[0].RCS_DESCRIPTION";
public const string _BindDataReader = "[RCS_DESCRIPTION]";
}
public class idxPK_T_RELATIONSHIP_CURRENT_STATUS_TYPE
{
public const string _Name = "PK_T_RELATIONSHIP_CURRENT_STATUS_TYPE";
public const string _Caption = "PK_ T_ RELATIONSHIP_ CURRENT_ STATUS_ TYPE";
public const string _ParentName = "T_PROP_STATUS_TYPE";
public const bool _IsPrimaryKey = true;

public class ixcRCS_CODE : colRCS_CODE {}
}
public class pkxPK_T_RELATIONSHIP_CURRENT_STATUS_TYPE : idxPK_T_RELATIONSHIP_CURRENT_STATUS_TYPE {}
}
}
