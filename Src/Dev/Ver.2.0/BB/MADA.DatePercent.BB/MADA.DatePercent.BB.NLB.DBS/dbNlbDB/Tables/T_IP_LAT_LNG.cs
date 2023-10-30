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
public class tblT_IP_LAT_LNG
{
public const string _Name = "T_IP_LAT_LNG";
public const string _Caption = "T_ IP_ LAT_ LNG";

public class colIPL_BL_SERVER_ID
{
public const string _Name = "IPL_BL_SERVER_ID";
public const string _Caption = "IPL_ BL_ SERVER_ ID";
public const string _Description = "";
public const string _ParentName = "T_IP_LAT_LNG";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_IP_LAT_LNG.DefaultView.[0].IPL_BL_SERVER_ID";
public const string _BindDataReader = "[IPL_BL_SERVER_ID]";
}
public class colIPL_IIS_SERVER_ID
{
public const string _Name = "IPL_IIS_SERVER_ID";
public const string _Caption = "IPL_ IIS_ SERVER_ ID";
public const string _Description = "";
public const string _ParentName = "T_IP_LAT_LNG";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_IP_LAT_LNG.DefaultView.[0].IPL_IIS_SERVER_ID";
public const string _BindDataReader = "[IPL_IIS_SERVER_ID]";
}
public class colIPL_IP
{
public const string _Name = "IPL_IP";
public const string _Caption = "IPL_ IP";
public const string _Description = "";
public const string _ParentName = "T_IP_LAT_LNG";
public const SqlDbType _SqlDbType = SqlDbType.BigInt;
public const Int32 _Length = 8;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = true;
public const string _BindDataAdapter = "T_IP_LAT_LNG.DefaultView.[0].IPL_IP";
public const string _BindDataReader = "[IPL_IP]";
}
public class colIPL_LAT
{
public const string _Name = "IPL_LAT";
public const string _Caption = "IPL_ LAT";
public const string _Description = "";
public const string _ParentName = "T_IP_LAT_LNG";
public const SqlDbType _SqlDbType = SqlDbType.Decimal;
public const Int32 _Length = 9;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_IP_LAT_LNG.DefaultView.[0].IPL_LAT";
public const string _BindDataReader = "[IPL_LAT]";
}
public class colIPL_LNG
{
public const string _Name = "IPL_LNG";
public const string _Caption = "IPL_ LNG";
public const string _Description = "";
public const string _ParentName = "T_IP_LAT_LNG";
public const SqlDbType _SqlDbType = SqlDbType.Decimal;
public const Int32 _Length = 9;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_IP_LAT_LNG.DefaultView.[0].IPL_LNG";
public const string _BindDataReader = "[IPL_LNG]";
}
public class colIPL_VALIDATE
{
public const string _Name = "IPL_VALIDATE";
public const string _Caption = "IPL_ VALIDATE";
public const string _Description = "";
public const string _ParentName = "T_IP_LAT_LNG";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = 1;
public const bool _IsNullable = false;
public const bool _IsIdentity = false;
public const bool _IsComputed = false;
public const bool _IsPrimaryKey = false;
public const string _BindDataAdapter = "T_IP_LAT_LNG.DefaultView.[0].IPL_VALIDATE";
public const string _BindDataReader = "[IPL_VALIDATE]";
}
public class idxIX_T_IP_LAT_LNG_IPL_VALIDATE
{
public const string _Name = "IX_T_IP_LAT_LNG_IPL_VALIDATE";
public const string _Caption = "IX_ T_ IP_ LAT_ LNG_ IPL_ VALIDATE";
public const string _ParentName = "T_IP_LAT_LNG";
public const bool _IsPrimaryKey = false;

public class ixcIPL_VALIDATE : colIPL_VALIDATE {}
}
public class idxPK_T_IP_LAT_LNG
{
public const string _Name = "PK_T_IP_LAT_LNG";
public const string _Caption = "PK_ T_ IP_ LAT_ LNG";
public const string _ParentName = "T_IP_LAT_LNG";
public const bool _IsPrimaryKey = true;

public class ixcIPL_IP : colIPL_IP {}
}
public class pkxPK_T_IP_LAT_LNG : idxPK_T_IP_LAT_LNG {}
}
}
