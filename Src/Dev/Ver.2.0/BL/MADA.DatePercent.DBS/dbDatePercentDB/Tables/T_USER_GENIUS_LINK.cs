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
public class tblT_USER_GENIUS_LINK
{
public const string _Name = "T_USER_GENIUS_LINK";
public const string _Caption = "T_ USER_ GENIUS_ LINK";

public class colUGL_DETAILS_USER_ID
{
public const string _Name = "UGL_DETAILS_USER_ID";
public const string _Caption = "UGL_ DETAILS_ USER_ ID";
public const string _Description = "";
public const string _ParentName = "T_USER_GENIUS_LINK";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_USER_GENIUS_LINK.DefaultView.[0].UGL_DETAILS_USER_ID";
public const string _BindDataReader = "[UGL_DETAILS_USER_ID]";
}
public class colUGL_ID
{
public const string _Name = "UGL_ID";
public const string _Caption = "UGL_ ID";
public const string _Description = "";
public const string _ParentName = "T_USER_GENIUS_LINK";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = true;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = true;
public const string _BindDataAdapter = "T_USER_GENIUS_LINK.DefaultView.[0].UGL_ID";
public const string _BindDataReader = "[UGL_ID]";
}
public class colUGL_USER_ID
{
public const string _Name = "UGL_USER_ID";
public const string _Caption = "UGL_ USER_ ID";
public const string _Description = "";
public const string _ParentName = "T_USER_GENIUS_LINK";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_USER_GENIUS_LINK.DefaultView.[0].UGL_USER_ID";
public const string _BindDataReader = "[UGL_USER_ID]";
}
public class idcUGL_ID : colUGL_ID {}
public class idxIX_T_USER_GENIUS_LINK_UGL_USER_ID_UGL_DETAILS_USER_ID
{
public const string _Name = "IX_T_USER_GENIUS_LINK_UGL_USER_ID_UGL_DETAILS_USER_ID";
public const string _Caption = "IX_ T_ USER_ GENIUS_ LINK_ UGL_ USER_ ID_ UGL_ DETAILS_ USER_ ID";
public const string _ParentName = "T_USER_GENIUS_LINK";
public const bool _IsPrimaryKey = false;

public class ixcUGL_DETAILS_USER_ID : colUGL_DETAILS_USER_ID {}
public class ixcUGL_USER_ID : colUGL_USER_ID {}
}
public class idxPK_T_USER_GENIUS_LINK
{
public const string _Name = "PK_T_USER_GENIUS_LINK";
public const string _Caption = "PK_ T_ USER_ GENIUS_ LINK";
public const string _ParentName = "T_USER_GENIUS_LINK";
public const bool _IsPrimaryKey = true;

public class ixcUGL_ID : colUGL_ID {}
}
public class pkxPK_T_USER_GENIUS_LINK : idxPK_T_USER_GENIUS_LINK {}
}
}
