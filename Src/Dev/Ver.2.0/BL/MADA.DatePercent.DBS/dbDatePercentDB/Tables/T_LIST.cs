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
public class tblT_LIST
{
public const string _Name = "T_LIST";
public const string _Caption = "T_ LIST";

public class colLST_COMMENT
{
public const string _Name = "LST_COMMENT";
public const string _Caption = "LST_ COMMENT";
public const string _Description = "";
public const string _ParentName = "T_LIST";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_LIST.DefaultView.[0].LST_COMMENT";
public const string _BindDataReader = "[LST_COMMENT]";
}
public class colLST_DESCRIPTION
{
public const string _Name = "LST_DESCRIPTION";
public const string _Caption = "LST_ DESCRIPTION";
public const string _Description = "";
public const string _ParentName = "T_LIST";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_LIST.DefaultView.[0].LST_DESCRIPTION";
public const string _BindDataReader = "[LST_DESCRIPTION]";
}
public class colLST_ID
{
public const string _Name = "LST_ID";
public const string _Caption = "LST_ ID";
public const string _Description = "";
public const string _ParentName = "T_LIST";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = true;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = true;
public const string _BindDataAdapter = "T_LIST.DefaultView.[0].LST_ID";
public const string _BindDataReader = "[LST_ID]";
}
public class colLST_RESULT_VIEW_TYPE_CODE
{
public const string _Name = "LST_RESULT_VIEW_TYPE_CODE";
public const string _Caption = "LST_ RESULT_ VIEW_ TYPE_ CODE";
public const string _Description = "";
public const string _ParentName = "T_LIST";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_LIST.DefaultView.[0].LST_RESULT_VIEW_TYPE_CODE";
public const string _BindDataReader = "[LST_RESULT_VIEW_TYPE_CODE]";
}
public class colLST_SESSION_USER_ID
{
public const string _Name = "LST_SESSION_USER_ID";
public const string _Caption = "LST_ SESSION_ USER_ ID";
public const string _Description = "";
public const string _ParentName = "T_LIST";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_LIST.DefaultView.[0].LST_SESSION_USER_ID";
public const string _BindDataReader = "[LST_SESSION_USER_ID]";
}
public class colLST_TYPE_CODE
{
public const string _Name = "LST_TYPE_CODE";
public const string _Caption = "LST_ TYPE_ CODE";
public const string _Description = "";
public const string _ParentName = "T_LIST";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_LIST.DefaultView.[0].LST_TYPE_CODE";
public const string _BindDataReader = "[LST_TYPE_CODE]";
}
public class idcLST_ID : colLST_ID {}
public class idxIX_T_LIST_LST_GLOBAL_USER_ID
{
public const string _Name = "IX_T_LIST_LST_GLOBAL_USER_ID";
public const string _Caption = "IX_ T_ LIST_ LST_ GLOBAL_ USER_ ID";
public const string _ParentName = "T_LIST";
public const bool _IsPrimaryKey = false;

public class ixcLST_SESSION_USER_ID : colLST_SESSION_USER_ID {}
}
public class idxIX_T_LIST_LST_GLOBAL_USER_ID_LST_RESULT_VIEW_TYPE_CODE
{
public const string _Name = "IX_T_LIST_LST_GLOBAL_USER_ID_LST_RESULT_VIEW_TYPE_CODE";
public const string _Caption = "IX_ T_ LIST_ LST_ GLOBAL_ USER_ ID_ LST_ RESULT_ VIEW_ TYPE_ CODE";
public const string _ParentName = "T_LIST";
public const bool _IsPrimaryKey = false;

public class ixcLST_RESULT_VIEW_TYPE_CODE : colLST_RESULT_VIEW_TYPE_CODE {}
public class ixcLST_SESSION_USER_ID : colLST_SESSION_USER_ID {}
}
public class idxIX_T_LIST_LST_GLOBAL_USER_ID_LST_TYPE_CODE
{
public const string _Name = "IX_T_LIST_LST_GLOBAL_USER_ID_LST_TYPE_CODE";
public const string _Caption = "IX_ T_ LIST_ LST_ GLOBAL_ USER_ ID_ LST_ TYPE_ CODE";
public const string _ParentName = "T_LIST";
public const bool _IsPrimaryKey = false;

public class ixcLST_SESSION_USER_ID : colLST_SESSION_USER_ID {}
public class ixcLST_TYPE_CODE : colLST_TYPE_CODE {}
}
public class idxPK_T_LIST
{
public const string _Name = "PK_T_LIST";
public const string _Caption = "PK_ T_ LIST";
public const string _ParentName = "T_LIST";
public const bool _IsPrimaryKey = true;

public class ixcLST_ID : colLST_ID {}
}
public class pkxPK_T_LIST : idxPK_T_LIST {}
}
}
