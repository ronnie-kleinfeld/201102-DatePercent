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
public class tblT_PROP_OCCUPATION_TYPE
{
public const string _Name = "T_PROP_OCCUPATION_TYPE";
public const string _Caption = "T_ PROP_ OCCUPATION_ TYPE";

public class colOCU_CODE
{
public const string _Name = "OCU_CODE";
public const string _Caption = "OCU_ CODE";
public const string _Description = "";
public const string _ParentName = "T_PROP_OCCUPATION_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = true;
public const string _BindDataAdapter = "T_PROP_OCCUPATION_TYPE.DefaultView.[0].OCU_CODE";
public const string _BindDataReader = "[OCU_CODE]";
}
public class colOCU_DESCRIPTION
{
public const string _Name = "OCU_DESCRIPTION";
public const string _Caption = "OCU_ DESCRIPTION";
public const string _Description = "";
public const string _ParentName = "T_PROP_OCCUPATION_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = true;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_PROP_OCCUPATION_TYPE.DefaultView.[0].OCU_DESCRIPTION";
public const string _BindDataReader = "[OCU_DESCRIPTION]";
}
public class idxPK_T_PROP_OCCUPATION_TYPE
{
public const string _Name = "PK_T_PROP_OCCUPATION_TYPE";
public const string _Caption = "PK_ T_ PROP_ OCCUPATION_ TYPE";
public const string _ParentName = "T_PROP_OCCUPATION_TYPE";
public const bool _IsPrimaryKey = true;

public class ixcOCU_CODE : colOCU_CODE {}
}
public class pkxPK_T_PROP_OCCUPATION_TYPE : idxPK_T_PROP_OCCUPATION_TYPE {}
}
}
