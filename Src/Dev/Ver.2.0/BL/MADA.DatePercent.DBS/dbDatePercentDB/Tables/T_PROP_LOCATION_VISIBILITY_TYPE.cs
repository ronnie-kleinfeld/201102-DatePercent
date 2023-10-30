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
public class tblT_PROP_LOCATION_VISIBILITY_TYPE
{
public const string _Name = "T_PROP_LOCATION_VISIBILITY_TYPE";
public const string _Caption = "T_ PROP_ LOCATION_ VISIBILITY_ TYPE";

public class colLVS_CODE
{
public const string _Name = "LVS_CODE";
public const string _Caption = "LVS_ CODE";
public const string _Description = "";
public const string _ParentName = "T_PROP_LOCATION_VISIBILITY_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = true;
public const string _BindDataAdapter = "T_PROP_LOCATION_VISIBILITY_TYPE.DefaultView.[0].LVS_CODE";
public const string _BindDataReader = "[LVS_CODE]";
}
public class colLVS_COMMENT
{
public const string _Name = "LVS_COMMENT";
public const string _Caption = "LVS_ COMMENT";
public const string _Description = "";
public const string _ParentName = "T_PROP_LOCATION_VISIBILITY_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_PROP_LOCATION_VISIBILITY_TYPE.DefaultView.[0].LVS_COMMENT";
public const string _BindDataReader = "[LVS_COMMENT]";
}
public class colLVS_DESCRIPTION
{
public const string _Name = "LVS_DESCRIPTION";
public const string _Caption = "LVS_ DESCRIPTION";
public const string _Description = "";
public const string _ParentName = "T_PROP_LOCATION_VISIBILITY_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_PROP_LOCATION_VISIBILITY_TYPE.DefaultView.[0].LVS_DESCRIPTION";
public const string _BindDataReader = "[LVS_DESCRIPTION]";
}
public class colValueCode
{
public const string _Name = "ValueCode";
public const string _Caption = "Value Code";
public const string _Description = "";
public const string _ParentName = "T_PROP_LOCATION_VISIBILITY_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = true;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_PROP_LOCATION_VISIBILITY_TYPE.DefaultView.[0].ValueCode";
public const string _BindDataReader = "[ValueCode]";
}
public class colValueName
{
public const string _Name = "ValueName";
public const string _Caption = "Value Name";
public const string _Description = "";
public const string _ParentName = "T_PROP_LOCATION_VISIBILITY_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = true;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_PROP_LOCATION_VISIBILITY_TYPE.DefaultView.[0].ValueName";
public const string _BindDataReader = "[ValueName]";
}
public class colValueNameEnum
{
public const string _Name = "ValueNameEnum";
public const string _Caption = "Value Name Enum";
public const string _Description = "";
public const string _ParentName = "T_PROP_LOCATION_VISIBILITY_TYPE";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = true;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_PROP_LOCATION_VISIBILITY_TYPE.DefaultView.[0].ValueNameEnum";
public const string _BindDataReader = "[ValueNameEnum]";
}
public class idxPK_T_PROP_LOCATION_VISIBILITY_TYPE
{
public const string _Name = "PK_T_PROP_LOCATION_VISIBILITY_TYPE";
public const string _Caption = "PK_ T_ PROP_ LOCATION_ VISIBILITY_ TYPE";
public const string _ParentName = "T_PROP_LOCATION_VISIBILITY_TYPE";
public const bool _IsPrimaryKey = true;

public class ixcLVS_CODE : colLVS_CODE {}
}
public class pkxPK_T_PROP_LOCATION_VISIBILITY_TYPE : idxPK_T_PROP_LOCATION_VISIBILITY_TYPE {}
}
}
