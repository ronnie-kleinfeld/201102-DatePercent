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
public class tblT_SERIALIZER
{
public const string _Name = "T_SERIALIZER";
public const string _Caption = "T_ SERIALIZER";

public class colSRL_DESCRIPTION
{
public const string _Name = "SRL_DESCRIPTION";
public const string _Caption = "SRL_ DESCRIPTION";
public const string _Description = "";
public const string _ParentName = "T_SERIALIZER";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = true;
public const string _BindDataAdapter = "T_SERIALIZER.DefaultView.[0].SRL_DESCRIPTION";
public const string _BindDataReader = "[SRL_DESCRIPTION]";
}
public class colSRL_KEY_1
{
public const string _Name = "SRL_KEY_1";
public const string _Caption = "SRL_ KEY_1";
public const string _Description = "";
public const string _ParentName = "T_SERIALIZER";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 5;
public const bool _IsNullable = true;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_SERIALIZER.DefaultView.[0].SRL_KEY_1";
public const string _BindDataReader = "[SRL_KEY_1]";
}
public class colSRL_KEY_2
{
public const string _Name = "SRL_KEY_2";
public const string _Caption = "SRL_ KEY_2";
public const string _Description = "";
public const string _ParentName = "T_SERIALIZER";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 5;
public const bool _IsNullable = true;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_SERIALIZER.DefaultView.[0].SRL_KEY_2";
public const string _BindDataReader = "[SRL_KEY_2]";
}
public class idxPK_T_SERIALIZER
{
public const string _Name = "PK_T_SERIALIZER";
public const string _Caption = "PK_ T_ SERIALIZER";
public const string _ParentName = "T_SERIALIZER";
public const bool _IsPrimaryKey = true;

public class ixcSRL_DESCRIPTION : colSRL_DESCRIPTION {}
}
public class pkxPK_T_SERIALIZER : idxPK_T_SERIALIZER {}
}
}
