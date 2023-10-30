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
public class tblT_PROP_SEX_TYPE_ENUM
{
public const string _Name = "T_PROP_SEX_TYPE_ENUM";
public const string _Caption = "T_ PROP_ SEX_ TYPE_ ENUM";

public class colSEX_CODE
{
public const string _Name = "SEX_CODE";
public const string _Caption = "SEX_ CODE";
public const string _Description = "";
public const string _ParentName = "T_PROP_SEX_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = true;
public const string _BindDataAdapter = "T_PROP_SEX_TYPE_ENUM.DefaultView.[0].SEX_CODE";
public const string _BindDataReader = "[SEX_CODE]";
}
public class colSEX_DESCRIPTION
{
public const string _Name = "SEX_DESCRIPTION";
public const string _Caption = "SEX_ DESCRIPTION";
public const string _Description = "";
public const string _ParentName = "T_PROP_SEX_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = true;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_PROP_SEX_TYPE_ENUM.DefaultView.[0].SEX_DESCRIPTION";
public const string _BindDataReader = "[SEX_DESCRIPTION]";
}
public class colValueCode
{
public const string _Name = "ValueCode";
public const string _Caption = "Value Code";
public const string _Description = "";
public const string _ParentName = "T_PROP_SEX_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = true;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_PROP_SEX_TYPE_ENUM.DefaultView.[0].ValueCode";
public const string _BindDataReader = "[ValueCode]";
}
public class colValueName
{
public const string _Name = "ValueName";
public const string _Caption = "Value Name";
public const string _Description = "";
public const string _ParentName = "T_PROP_SEX_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = true;
public const bool _IsIdentity = false;
public const bool _IsComputed = true;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_PROP_SEX_TYPE_ENUM.DefaultView.[0].ValueName";
public const string _BindDataReader = "[ValueName]";
}
public class colValueNameEnum
{
public const string _Name = "ValueNameEnum";
public const string _Caption = "Value Name Enum";
public const string _Description = "";
public const string _ParentName = "T_PROP_SEX_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = true;
public const bool _IsIdentity = false;
public const bool _IsComputed = true;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_PROP_SEX_TYPE_ENUM.DefaultView.[0].ValueNameEnum";
public const string _BindDataReader = "[ValueNameEnum]";
}
public class idxPK_T_SEX
{
public const string _Name = "PK_T_SEX";
public const string _Caption = "PK_ T_ SEX";
public const string _ParentName = "T_PROP_SEX_TYPE_ENUM";
public const bool _IsPrimaryKey = true;

public class ixcSEX_CODE : colSEX_CODE {}
}
public class pkxPK_T_SEX : idxPK_T_SEX {}
}
}
