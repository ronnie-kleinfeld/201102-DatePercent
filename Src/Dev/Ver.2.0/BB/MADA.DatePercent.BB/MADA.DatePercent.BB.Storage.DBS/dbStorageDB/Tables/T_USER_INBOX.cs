//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by the Database Schema tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
//
//     Exception should be handled in a higher layer.
//
//     generation time: 29/03/2012 14:43
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MADA.DatePercent.BB.Storage.DBS.dbStorageDB.Tables
{
public class tblT_USER_INBOX
{
public const string _Name = "T_USER_INBOX";
public const string _Caption = "T_ USER_ INBOX";

public class colUSI_COMM_TYPE_CODE
{
public const string _Name = "USI_COMM_TYPE_CODE";
public const string _Caption = "USI_ COMM_ TYPE_ CODE";
public const string _Description = "";
public const string _ParentName = "T_USER_INBOX";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_USER_INBOX.DefaultView.[0].USI_COMM_TYPE_CODE";
public const string _BindDataReader = "[USI_COMM_TYPE_CODE]";
}
public class colUSI_ID
{
public const string _Name = "USI_ID";
public const string _Caption = "USI_ ID";
public const string _Description = "";
public const string _ParentName = "T_USER_INBOX";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = true;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = true;
public const string _BindDataAdapter = "T_USER_INBOX.DefaultView.[0].USI_ID";
public const string _BindDataReader = "[USI_ID]";
}
public class colUSI_PRESENT_CODE
{
public const string _Name = "USI_PRESENT_CODE";
public const string _Caption = "USI_ PRESENT_ CODE";
public const string _Description = "";
public const string _ParentName = "T_USER_INBOX";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_USER_INBOX.DefaultView.[0].USI_PRESENT_CODE";
public const string _BindDataReader = "[USI_PRESENT_CODE]";
}
public class colUSI_SENDER_USER_ID
{
public const string _Name = "USI_SENDER_USER_ID";
public const string _Caption = "USI_ SENDER_ USER_ ID";
public const string _Description = "";
public const string _ParentName = "T_USER_INBOX";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_USER_INBOX.DefaultView.[0].USI_SENDER_USER_ID";
public const string _BindDataReader = "[USI_SENDER_USER_ID]";
}
public class colUSI_TEXT
{
public const string _Name = "USI_TEXT";
public const string _Caption = "USI_ TEXT";
public const string _Description = "";
public const string _ParentName = "T_USER_INBOX";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_USER_INBOX.DefaultView.[0].USI_TEXT";
public const string _BindDataReader = "[USI_TEXT]";
}
public class colUSI_USER_ID
{
public const string _Name = "USI_USER_ID";
public const string _Caption = "USI_ USER_ ID";
public const string _Description = "";
public const string _ParentName = "T_USER_INBOX";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_USER_INBOX.DefaultView.[0].USI_USER_ID";
public const string _BindDataReader = "[USI_USER_ID]";
}
public class colUSI_WINK_CODE
{
public const string _Name = "USI_WINK_CODE";
public const string _Caption = "USI_ WINK_ CODE";
public const string _Description = "";
public const string _ParentName = "T_USER_INBOX";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_USER_INBOX.DefaultView.[0].USI_WINK_CODE";
public const string _BindDataReader = "[USI_WINK_CODE]";
}
public class idcUSI_ID : colUSI_ID {}
public class idxIX_T_USER_INBOX_USI_USER_ID
{
public const string _Name = "IX_T_USER_INBOX_USI_USER_ID";
public const string _Caption = "IX_ T_ USER_ INBOX_ USI_ USER_ ID";
public const string _ParentName = "T_USER_INBOX";
public const bool _IsPrimaryKey = false;

public class ixcUSI_USER_ID : colUSI_USER_ID {}
}
public class idxPK_T_USER_INBOX
{
public const string _Name = "PK_T_USER_INBOX";
public const string _Caption = "PK_ T_ USER_ INBOX";
public const string _ParentName = "T_USER_INBOX";
public const bool _IsPrimaryKey = true;

public class ixcUSI_ID : colUSI_ID {}
}
public class pkxPK_T_USER_INBOX : idxPK_T_USER_INBOX {}
}
}
