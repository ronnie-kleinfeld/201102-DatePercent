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
public class tblT_USER_LINK
{
public const string _Name = "T_USER_LINK";
public const string _Caption = "T_ USER_ LINK";

public class colULK_DATE_TIME
{
public const string _Name = "ULK_DATE_TIME";
public const string _Caption = "ULK_ DATE_ TIME";
public const string _Description = "";
public const string _ParentName = "T_USER_LINK";
public const SqlDbType _SqlDbType = SqlDbType.DateTime;
public const Int32 _Length = 8;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_USER_LINK.DefaultView.[0].ULK_DATE_TIME";
public const string _BindDataReader = "[ULK_DATE_TIME]";
}
public class colULK_DETAILS_USER_ID
{
public const string _Name = "ULK_DETAILS_USER_ID";
public const string _Caption = "ULK_ DETAILS_ USER_ ID";
public const string _Description = "";
public const string _ParentName = "T_USER_LINK";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_USER_LINK.DefaultView.[0].ULK_DETAILS_USER_ID";
public const string _BindDataReader = "[ULK_DETAILS_USER_ID]";
}
public class colULK_ID
{
public const string _Name = "ULK_ID";
public const string _Caption = "ULK_ ID";
public const string _Description = "";
public const string _ParentName = "T_USER_LINK";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = true;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = true;
public const string _BindDataAdapter = "T_USER_LINK.DefaultView.[0].ULK_ID";
public const string _BindDataReader = "[ULK_ID]";
}
public class colULK_LINK_ACTION_TYPE
{
public const string _Name = "ULK_LINK_ACTION_TYPE";
public const string _Caption = "ULK_ LINK_ ACTION_ TYPE";
public const string _Description = "";
public const string _ParentName = "T_USER_LINK";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_USER_LINK.DefaultView.[0].ULK_LINK_ACTION_TYPE";
public const string _BindDataReader = "[ULK_LINK_ACTION_TYPE]";
}
public class colULK_LINK_TYPE
{
public const string _Name = "ULK_LINK_TYPE";
public const string _Caption = "ULK_ LINK_ TYPE";
public const string _Description = "";
public const string _ParentName = "T_USER_LINK";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_USER_LINK.DefaultView.[0].ULK_LINK_TYPE";
public const string _BindDataReader = "[ULK_LINK_TYPE]";
}
public class colULK_USER_ID
{
public const string _Name = "ULK_USER_ID";
public const string _Caption = "ULK_ USER_ ID";
public const string _Description = "";
public const string _ParentName = "T_USER_LINK";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_USER_LINK.DefaultView.[0].ULK_USER_ID";
public const string _BindDataReader = "[ULK_USER_ID]";
}
public class idcULK_ID : colULK_ID {}
public class idxIX_T_USER_LINK_ULK_USER_ID
{
public const string _Name = "IX_T_USER_LINK_ULK_USER_ID";
public const string _Caption = "IX_ T_ USER_ LINK_ ULK_ USER_ ID";
public const string _ParentName = "T_USER_LINK";
public const bool _IsPrimaryKey = false;

public class ixcULK_USER_ID : colULK_USER_ID {}
}
public class idxIX_T_USER_LINK_ULK_USER_ID_ULK_DETAILS_USER_ID
{
public const string _Name = "IX_T_USER_LINK_ULK_USER_ID_ULK_DETAILS_USER_ID";
public const string _Caption = "IX_ T_ USER_ LINK_ ULK_ USER_ ID_ ULK_ DETAILS_ USER_ ID";
public const string _ParentName = "T_USER_LINK";
public const bool _IsPrimaryKey = false;

public class ixcULK_DETAILS_USER_ID : colULK_DETAILS_USER_ID {}
public class ixcULK_USER_ID : colULK_USER_ID {}
}
public class idxPK_T_USER_LINK
{
public const string _Name = "PK_T_USER_LINK";
public const string _Caption = "PK_ T_ USER_ LINK";
public const string _ParentName = "T_USER_LINK";
public const bool _IsPrimaryKey = true;

public class ixcULK_ID : colULK_ID {}
}
public class pkxPK_T_USER_LINK : idxPK_T_USER_LINK {}
}
}
