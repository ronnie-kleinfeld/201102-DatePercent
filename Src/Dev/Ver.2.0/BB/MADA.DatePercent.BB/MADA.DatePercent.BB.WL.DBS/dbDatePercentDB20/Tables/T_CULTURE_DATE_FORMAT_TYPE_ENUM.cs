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
public class tblT_CULTURE_DATE_FORMAT_TYPE_ENUM
{
public const string _Name = "T_CULTURE_DATE_FORMAT_TYPE_ENUM";
public const string _Caption = "T_ CULTURE_ DATE_ FORMAT_ TYPE_ ENUM";

public class colCDF_CODE
{
public const string _Name = "CDF_CODE";
public const string _Caption = "CDF_ CODE";
public const string _Description = "";
public const string _ParentName = "T_CULTURE_DATE_FORMAT_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = true;
public const string _BindDataAdapter = "T_CULTURE_DATE_FORMAT_TYPE_ENUM.DefaultView.[0].CDF_CODE";
public const string _BindDataReader = "[CDF_CODE]";
}
public class colCDF_DESCRIPTION
{
public const string _Name = "CDF_DESCRIPTION";
public const string _Caption = "CDF_ DESCRIPTION";
public const string _Description = "";
public const string _ParentName = "T_CULTURE_DATE_FORMAT_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_CULTURE_DATE_FORMAT_TYPE_ENUM.DefaultView.[0].CDF_DESCRIPTION";
public const string _BindDataReader = "[CDF_DESCRIPTION]";
}
public class colCDF_FORMAT
{
public const string _Name = "CDF_FORMAT";
public const string _Caption = "CDF_ FORMAT";
public const string _Description = "";
public const string _ParentName = "T_CULTURE_DATE_FORMAT_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_CULTURE_DATE_FORMAT_TYPE_ENUM.DefaultView.[0].CDF_FORMAT";
public const string _BindDataReader = "[CDF_FORMAT]";
}
public class colValueCode
{
public const string _Name = "ValueCode";
public const string _Caption = "Value Code";
public const string _Description = "";
public const string _ParentName = "T_CULTURE_DATE_FORMAT_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = true;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_CULTURE_DATE_FORMAT_TYPE_ENUM.DefaultView.[0].ValueCode";
public const string _BindDataReader = "[ValueCode]";
}
public class colValueName
{
public const string _Name = "ValueName";
public const string _Caption = "Value Name";
public const string _Description = "";
public const string _ParentName = "T_CULTURE_DATE_FORMAT_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = true;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_CULTURE_DATE_FORMAT_TYPE_ENUM.DefaultView.[0].ValueName";
public const string _BindDataReader = "[ValueName]";
}
public class colValueNameEnum
{
public const string _Name = "ValueNameEnum";
public const string _Caption = "Value Name Enum";
public const string _Description = "";
public const string _ParentName = "T_CULTURE_DATE_FORMAT_TYPE_ENUM";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_CULTURE_DATE_FORMAT_TYPE_ENUM.DefaultView.[0].ValueNameEnum";
public const string _BindDataReader = "[ValueNameEnum]";
}
public class idxPK_T_CULTURE_DATE_FORMAT_TYPE_ENUM
{
public const string _Name = "PK_T_CULTURE_DATE_FORMAT_TYPE_ENUM";
public const string _Caption = "PK_ T_ CULTURE_ DATE_ FORMAT_ TYPE_ ENUM";
public const string _ParentName = "T_CULTURE_DATE_FORMAT_TYPE_ENUM";
public const bool _IsPrimaryKey = true;

public class ixcCDF_CODE : colCDF_CODE {}
}
public class pkxPK_T_CULTURE_DATE_FORMAT_TYPE_ENUM : idxPK_T_CULTURE_DATE_FORMAT_TYPE_ENUM {}
}
}
