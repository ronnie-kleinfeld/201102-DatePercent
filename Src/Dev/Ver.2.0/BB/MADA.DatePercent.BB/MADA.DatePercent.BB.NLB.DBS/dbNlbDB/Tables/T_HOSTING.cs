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

namespace MADA.DatePercent.BB.NLB.DBS.dbNlbDB.Tables
{
public class tblT_HOSTING
{
public const string _Name = "T_HOSTING";
public const string _Caption = "T_ HOSTING";

public class colHST_DESCRIPTION
{
public const string _Name = "HST_DESCRIPTION";
public const string _Caption = "HST_ DESCRIPTION";
public const string _Description = "";
public const string _ParentName = "T_HOSTING";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_HOSTING.DefaultView.[0].HST_DESCRIPTION";
public const string _BindDataReader = "[HST_DESCRIPTION]";
}
public class colHST_ID
{
public const string _Name = "HST_ID";
public const string _Caption = "HST_ ID";
public const string _Description = "";
public const string _ParentName = "T_HOSTING";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = true;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = true;
public const string _BindDataAdapter = "T_HOSTING.DefaultView.[0].HST_ID";
public const string _BindDataReader = "[HST_ID]";
}
public class colHST_WEB_SITE
{
public const string _Name = "HST_WEB_SITE";
public const string _Caption = "HST_ WEB_ SITE";
public const string _Description = "";
public const string _ParentName = "T_HOSTING";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_HOSTING.DefaultView.[0].HST_WEB_SITE";
public const string _BindDataReader = "[HST_WEB_SITE]";
}
public class idcHST_ID : colHST_ID {}
public class idxPK_T_HOSTING
{
public const string _Name = "PK_T_HOSTING";
public const string _Caption = "PK_ T_ HOSTING";
public const string _ParentName = "T_HOSTING";
public const bool _IsPrimaryKey = true;

public class ixcHST_ID : colHST_ID {}
}
public class pkxPK_T_HOSTING : idxPK_T_HOSTING {}
}
}
