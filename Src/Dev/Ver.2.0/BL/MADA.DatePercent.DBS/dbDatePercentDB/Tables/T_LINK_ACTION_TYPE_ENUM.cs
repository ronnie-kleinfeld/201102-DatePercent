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
public class tblT_LINK_ACTION_TYPE_ENUM
{
public const string _Name = "T_LINK_ACTION_TYPE_ENUM";
public const string _Caption = "T_ LINK_ ACTION_ TYPE_ ENUM";

public class colLAT_BUTTON_SIZE_CODE
{
public const string _Name = "LAT_BUTTON_SIZE_CODE";
public const string _Caption = "LAT_ BUTTON_ SIZE_ CODE";
public const string _Description = "";
public const string _ParentName = "T_LINK_ACTION_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_LINK_ACTION_TYPE_ENUM.DefaultView.[0].LAT_BUTTON_SIZE_CODE";
public const string _BindDataReader = "[LAT_BUTTON_SIZE_CODE]";
}
public class colLAT_CODE
{
public const string _Name = "LAT_CODE";
public const string _Caption = "LAT_ CODE";
public const string _Description = "";
public const string _ParentName = "T_LINK_ACTION_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = true;
public const string _BindDataAdapter = "T_LINK_ACTION_TYPE_ENUM.DefaultView.[0].LAT_CODE";
public const string _BindDataReader = "[LAT_CODE]";
}
public class colLAT_DESCRIPTION
{
public const string _Name = "LAT_DESCRIPTION";
public const string _Caption = "LAT_ DESCRIPTION";
public const string _Description = "";
public const string _ParentName = "T_LINK_ACTION_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_LINK_ACTION_TYPE_ENUM.DefaultView.[0].LAT_DESCRIPTION";
public const string _BindDataReader = "[LAT_DESCRIPTION]";
}
public class colLAT_EMAIL_BOX_TYPE
{
public const string _Name = "LAT_EMAIL_BOX_TYPE";
public const string _Caption = "LAT_ EMAIL_ BOX_ TYPE";
public const string _Description = "";
public const string _ParentName = "T_LINK_ACTION_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_LINK_ACTION_TYPE_ENUM.DefaultView.[0].LAT_EMAIL_BOX_TYPE";
public const string _BindDataReader = "[LAT_EMAIL_BOX_TYPE]";
}
public class colLAT_NAME
{
public const string _Name = "LAT_NAME";
public const string _Caption = "LAT_ NAME";
public const string _Description = "";
public const string _ParentName = "T_LINK_ACTION_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = true;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_LINK_ACTION_TYPE_ENUM.DefaultView.[0].LAT_NAME";
public const string _BindDataReader = "[LAT_NAME]";
}
public class colLAT_RMN_TYPE
{
public const string _Name = "LAT_RMN_TYPE";
public const string _Caption = "LAT_ RMN_ TYPE";
public const string _Description = "";
public const string _ParentName = "T_LINK_ACTION_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_LINK_ACTION_TYPE_ENUM.DefaultView.[0].LAT_RMN_TYPE";
public const string _BindDataReader = "[LAT_RMN_TYPE]";
}
public class colLAT_SOURCE_LINK_TYPE
{
public const string _Name = "LAT_SOURCE_LINK_TYPE";
public const string _Caption = "LAT_ SOURCE_ LINK_ TYPE";
public const string _Description = "";
public const string _ParentName = "T_LINK_ACTION_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_LINK_ACTION_TYPE_ENUM.DefaultView.[0].LAT_SOURCE_LINK_TYPE";
public const string _BindDataReader = "[LAT_SOURCE_LINK_TYPE]";
}
public class colLAT_TARGET_LINK_TYPE
{
public const string _Name = "LAT_TARGET_LINK_TYPE";
public const string _Caption = "LAT_ TARGET_ LINK_ TYPE";
public const string _Description = "";
public const string _ParentName = "T_LINK_ACTION_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_LINK_ACTION_TYPE_ENUM.DefaultView.[0].LAT_TARGET_LINK_TYPE";
public const string _BindDataReader = "[LAT_TARGET_LINK_TYPE]";
}
public class colLAT_TEXT
{
public const string _Name = "LAT_TEXT";
public const string _Caption = "LAT_ TEXT";
public const string _Description = "";
public const string _ParentName = "T_LINK_ACTION_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = true;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_LINK_ACTION_TYPE_ENUM.DefaultView.[0].LAT_TEXT";
public const string _BindDataReader = "[LAT_TEXT]";
}
public class colValueCode
{
public const string _Name = "ValueCode";
public const string _Caption = "Value Code";
public const string _Description = "";
public const string _ParentName = "T_LINK_ACTION_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = true;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_LINK_ACTION_TYPE_ENUM.DefaultView.[0].ValueCode";
public const string _BindDataReader = "[ValueCode]";
}
public class colValueName
{
public const string _Name = "ValueName";
public const string _Caption = "Value Name";
public const string _Description = "";
public const string _ParentName = "T_LINK_ACTION_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = true;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_LINK_ACTION_TYPE_ENUM.DefaultView.[0].ValueName";
public const string _BindDataReader = "[ValueName]";
}
public class colValueNameEnum
{
public const string _Name = "ValueNameEnum";
public const string _Caption = "Value Name Enum";
public const string _Description = "";
public const string _ParentName = "T_LINK_ACTION_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = true;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_LINK_ACTION_TYPE_ENUM.DefaultView.[0].ValueNameEnum";
public const string _BindDataReader = "[ValueNameEnum]";
}
public class idxPK_T_LINK_ACTION_TYPE
{
public const string _Name = "PK_T_LINK_ACTION_TYPE";
public const string _Caption = "PK_ T_ LINK_ ACTION_ TYPE";
public const string _ParentName = "T_LINK_ACTION_TYPE_ENUM";
public const bool _IsPrimaryKey = true;

public class ixcLAT_CODE : colLAT_CODE {}
}
public class pkxPK_T_LINK_ACTION_TYPE : idxPK_T_LINK_ACTION_TYPE {}
}
}
