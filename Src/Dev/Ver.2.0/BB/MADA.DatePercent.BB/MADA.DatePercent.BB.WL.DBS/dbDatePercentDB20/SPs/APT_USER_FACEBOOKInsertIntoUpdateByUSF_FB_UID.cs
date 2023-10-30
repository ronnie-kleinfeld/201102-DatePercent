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

namespace MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.SPs
{
public class procAPT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID
{
public const string _Name = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const string _Caption = "APT_ USER_ FACEBOOKInsert Into Update By USF_ FB_ UID";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
System.Nullable<int> p_iiScopeIdentity, System.Nullable<DateTime> p_dtUSF_BIRTHDAY, string p_strUSF_FB_BIRTHDAY_DATE, string p_strUSF_FB_EMAIL, string p_strUSF_FB_FIRST_NAME, string p_strUSF_FB_LAST_NAME, string p_strUSF_FB_LOCALE, string p_strUSF_FB_MIDDLE_NAME, string p_strUSF_FB_NAME, string p_strUSF_FB_PIC, string p_strUSF_FB_PROFILE_URL, string p_strUSF_FB_SEX, string p_strUSF_FB_TIMEZONE, string p_strUSF_FB_UID, string p_strUSF_FB_USERNAME, System.Nullable<int> p_iUSF_ID, System.Nullable<int> p_iUSF_SEX_TYPE, string p_strUSF_THIRD_PARTY_ID, string p_strUSF_UID, System.Nullable<int> p_iUSF_USER_ID)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
SqlParameterCollection(cmd.Parameters, p_iiScopeIdentity, p_dtUSF_BIRTHDAY, p_strUSF_FB_BIRTHDAY_DATE, p_strUSF_FB_EMAIL, p_strUSF_FB_FIRST_NAME, p_strUSF_FB_LAST_NAME, p_strUSF_FB_LOCALE, p_strUSF_FB_MIDDLE_NAME, p_strUSF_FB_NAME, p_strUSF_FB_PIC, p_strUSF_FB_PROFILE_URL, p_strUSF_FB_SEX, p_strUSF_FB_TIMEZONE, p_strUSF_FB_UID, p_strUSF_FB_USERNAME, p_iUSF_ID, p_iUSF_SEX_TYPE, p_strUSF_THIRD_PARTY_ID, p_strUSF_UID, p_iUSF_USER_ID);
return cmd;
}
public static void SqlCommandOutput(
System.Data.SqlClient.SqlCommand p_cmd,
out object p_iiScopeIdentity)
{
p_iiScopeIdentity = p_cmd.Parameters["@iScopeIdentity"].Value;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(pariScopeIdentity._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_BIRTHDAY._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_FB_BIRTHDAY_DATE._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_FB_EMAIL._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_FB_FIRST_NAME._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_FB_LAST_NAME._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_FB_LOCALE._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_FB_MIDDLE_NAME._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_FB_NAME._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_FB_PIC._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_FB_PROFILE_URL._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_FB_SEX._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_FB_TIMEZONE._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_FB_UID._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_FB_USERNAME._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_ID._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_SEX_TYPE._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_THIRD_PARTY_ID._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_UID._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_USER_ID._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, System.Nullable<int> p_iiScopeIdentity, System.Nullable<DateTime> p_dtUSF_BIRTHDAY, string p_strUSF_FB_BIRTHDAY_DATE, string p_strUSF_FB_EMAIL, string p_strUSF_FB_FIRST_NAME, string p_strUSF_FB_LAST_NAME, string p_strUSF_FB_LOCALE, string p_strUSF_FB_MIDDLE_NAME, string p_strUSF_FB_NAME, string p_strUSF_FB_PIC, string p_strUSF_FB_PROFILE_URL, string p_strUSF_FB_SEX, string p_strUSF_FB_TIMEZONE, string p_strUSF_FB_UID, string p_strUSF_FB_USERNAME, System.Nullable<int> p_iUSF_ID, System.Nullable<int> p_iUSF_SEX_TYPE, string p_strUSF_THIRD_PARTY_ID, string p_strUSF_UID, System.Nullable<int> p_iUSF_USER_ID)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(pariScopeIdentity._SqlParameter());
p_oSqlParameterCollection.Add(parUSF_BIRTHDAY._SqlParameter(p_dtUSF_BIRTHDAY));
p_oSqlParameterCollection.Add(parUSF_FB_BIRTHDAY_DATE._SqlParameter(p_strUSF_FB_BIRTHDAY_DATE));
p_oSqlParameterCollection.Add(parUSF_FB_EMAIL._SqlParameter(p_strUSF_FB_EMAIL));
p_oSqlParameterCollection.Add(parUSF_FB_FIRST_NAME._SqlParameter(p_strUSF_FB_FIRST_NAME));
p_oSqlParameterCollection.Add(parUSF_FB_LAST_NAME._SqlParameter(p_strUSF_FB_LAST_NAME));
p_oSqlParameterCollection.Add(parUSF_FB_LOCALE._SqlParameter(p_strUSF_FB_LOCALE));
p_oSqlParameterCollection.Add(parUSF_FB_MIDDLE_NAME._SqlParameter(p_strUSF_FB_MIDDLE_NAME));
p_oSqlParameterCollection.Add(parUSF_FB_NAME._SqlParameter(p_strUSF_FB_NAME));
p_oSqlParameterCollection.Add(parUSF_FB_PIC._SqlParameter(p_strUSF_FB_PIC));
p_oSqlParameterCollection.Add(parUSF_FB_PROFILE_URL._SqlParameter(p_strUSF_FB_PROFILE_URL));
p_oSqlParameterCollection.Add(parUSF_FB_SEX._SqlParameter(p_strUSF_FB_SEX));
p_oSqlParameterCollection.Add(parUSF_FB_TIMEZONE._SqlParameter(p_strUSF_FB_TIMEZONE));
p_oSqlParameterCollection.Add(parUSF_FB_UID._SqlParameter(p_strUSF_FB_UID));
p_oSqlParameterCollection.Add(parUSF_FB_USERNAME._SqlParameter(p_strUSF_FB_USERNAME));
p_oSqlParameterCollection.Add(parUSF_ID._SqlParameter(p_iUSF_ID));
p_oSqlParameterCollection.Add(parUSF_SEX_TYPE._SqlParameter(p_iUSF_SEX_TYPE));
p_oSqlParameterCollection.Add(parUSF_THIRD_PARTY_ID._SqlParameter(p_strUSF_THIRD_PARTY_ID));
p_oSqlParameterCollection.Add(parUSF_UID._SqlParameter(p_strUSF_UID));
p_oSqlParameterCollection.Add(parUSF_USER_ID._SqlParameter(p_iUSF_USER_ID));
}
public class pariScopeIdentity
{
public const string _Name = "@iScopeIdentity";
public const string _Caption = "@i Scope Identity";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@iScopeIdentity";
public const string _BindDataReader = "[@iScopeIdentity]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Output;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameter("@iScopeIdentity", 10, 0, 4, SqlDbType.Int, ParameterDirection.Output, true);
}
}
public class parUSF_BIRTHDAY
{
public const string _Name = "@USF_BIRTHDAY";
public const string _Caption = "@ USF_ BIRTHDAY";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.DateTime;
public const Int32 _Length = 8;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@USF_BIRTHDAY";
public const string _BindDataReader = "[@USF_BIRTHDAY]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_BIRTHDAY", 23, 3, 8, SqlDbType.DateTime, "DateTime", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<DateTime> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_BIRTHDAY", 23, 3, 8, SqlDbType.DateTime, "DateTime", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSF_FB_BIRTHDAY_DATE
{
public const string _Name = "@USF_FB_BIRTHDAY_DATE";
public const string _Caption = "@ USF_ FB_ BIRTHDAY_ DATE";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@USF_FB_BIRTHDAY_DATE";
public const string _BindDataReader = "[@USF_FB_BIRTHDAY_DATE]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_BIRTHDAY_DATE", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_BIRTHDAY_DATE", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSF_FB_EMAIL
{
public const string _Name = "@USF_FB_EMAIL";
public const string _Caption = "@ USF_ FB_ EMAIL";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@USF_FB_EMAIL";
public const string _BindDataReader = "[@USF_FB_EMAIL]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_EMAIL", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_EMAIL", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSF_FB_FIRST_NAME
{
public const string _Name = "@USF_FB_FIRST_NAME";
public const string _Caption = "@ USF_ FB_ FIRST_ NAME";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@USF_FB_FIRST_NAME";
public const string _BindDataReader = "[@USF_FB_FIRST_NAME]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_FIRST_NAME", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_FIRST_NAME", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSF_FB_LAST_NAME
{
public const string _Name = "@USF_FB_LAST_NAME";
public const string _Caption = "@ USF_ FB_ LAST_ NAME";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@USF_FB_LAST_NAME";
public const string _BindDataReader = "[@USF_FB_LAST_NAME]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_LAST_NAME", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_LAST_NAME", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSF_FB_LOCALE
{
public const string _Name = "@USF_FB_LOCALE";
public const string _Caption = "@ USF_ FB_ LOCALE";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@USF_FB_LOCALE";
public const string _BindDataReader = "[@USF_FB_LOCALE]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_LOCALE", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_LOCALE", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSF_FB_MIDDLE_NAME
{
public const string _Name = "@USF_FB_MIDDLE_NAME";
public const string _Caption = "@ USF_ FB_ MIDDLE_ NAME";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@USF_FB_MIDDLE_NAME";
public const string _BindDataReader = "[@USF_FB_MIDDLE_NAME]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_MIDDLE_NAME", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_MIDDLE_NAME", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSF_FB_NAME
{
public const string _Name = "@USF_FB_NAME";
public const string _Caption = "@ USF_ FB_ NAME";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@USF_FB_NAME";
public const string _BindDataReader = "[@USF_FB_NAME]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_NAME", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_NAME", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSF_FB_PIC
{
public const string _Name = "@USF_FB_PIC";
public const string _Caption = "@ USF_ FB_ PIC";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@USF_FB_PIC";
public const string _BindDataReader = "[@USF_FB_PIC]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_PIC", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_PIC", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSF_FB_PROFILE_URL
{
public const string _Name = "@USF_FB_PROFILE_URL";
public const string _Caption = "@ USF_ FB_ PROFILE_ URL";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@USF_FB_PROFILE_URL";
public const string _BindDataReader = "[@USF_FB_PROFILE_URL]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_PROFILE_URL", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_PROFILE_URL", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSF_FB_SEX
{
public const string _Name = "@USF_FB_SEX";
public const string _Caption = "@ USF_ FB_ SEX";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 10;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@USF_FB_SEX";
public const string _BindDataReader = "[@USF_FB_SEX]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_SEX", 10, -1, 10, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_SEX", 10, -1, 10, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSF_FB_TIMEZONE
{
public const string _Name = "@USF_FB_TIMEZONE";
public const string _Caption = "@ USF_ FB_ TIMEZONE";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@USF_FB_TIMEZONE";
public const string _BindDataReader = "[@USF_FB_TIMEZONE]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_TIMEZONE", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_TIMEZONE", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSF_FB_UID
{
public const string _Name = "@USF_FB_UID";
public const string _Caption = "@ USF_ FB_ UID";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@USF_FB_UID";
public const string _BindDataReader = "[@USF_FB_UID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_UID", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_UID", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSF_FB_USERNAME
{
public const string _Name = "@USF_FB_USERNAME";
public const string _Caption = "@ USF_ FB_ USERNAME";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@USF_FB_USERNAME";
public const string _BindDataReader = "[@USF_FB_USERNAME]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_USERNAME", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_FB_USERNAME", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSF_ID
{
public const string _Name = "@USF_ID";
public const string _Caption = "@ USF_ ID";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@USF_ID";
public const string _BindDataReader = "[@USF_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSF_SEX_TYPE
{
public const string _Name = "@USF_SEX_TYPE";
public const string _Caption = "@ USF_ SEX_ TYPE";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@USF_SEX_TYPE";
public const string _BindDataReader = "[@USF_SEX_TYPE]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_SEX_TYPE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_SEX_TYPE", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSF_THIRD_PARTY_ID
{
public const string _Name = "@USF_THIRD_PARTY_ID";
public const string _Caption = "@ USF_ THIRD_ PARTY_ ID";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@USF_THIRD_PARTY_ID";
public const string _BindDataReader = "[@USF_THIRD_PARTY_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_THIRD_PARTY_ID", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_THIRD_PARTY_ID", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSF_UID
{
public const string _Name = "@USF_UID";
public const string _Caption = "@ USF_ UID";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@USF_UID";
public const string _BindDataReader = "[@USF_UID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_UID", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_UID", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class parUSF_USER_ID
{
public const string _Name = "@USF_USER_ID";
public const string _Caption = "@ USF_ USER_ ID";
public const string _ParentName = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = 4;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USER_FACEBOOKInsertIntoUpdateByUSF_FB_UID.DefaultView.[0].@USF_USER_ID";
public const string _BindDataReader = "[@USF_USER_ID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(System.Nullable<int> Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USF_USER_ID", 10, 0, 4, SqlDbType.Int, "int", ParameterDirection.Input, true, false, "", Value);
}
}
public class inUSF_BIRTHDAY : parUSF_BIRTHDAY {}
public class inUSF_FB_BIRTHDAY_DATE : parUSF_FB_BIRTHDAY_DATE {}
public class inUSF_FB_EMAIL : parUSF_FB_EMAIL {}
public class inUSF_FB_FIRST_NAME : parUSF_FB_FIRST_NAME {}
public class inUSF_FB_LAST_NAME : parUSF_FB_LAST_NAME {}
public class inUSF_FB_LOCALE : parUSF_FB_LOCALE {}
public class inUSF_FB_MIDDLE_NAME : parUSF_FB_MIDDLE_NAME {}
public class inUSF_FB_NAME : parUSF_FB_NAME {}
public class inUSF_FB_PIC : parUSF_FB_PIC {}
public class inUSF_FB_PROFILE_URL : parUSF_FB_PROFILE_URL {}
public class inUSF_FB_SEX : parUSF_FB_SEX {}
public class inUSF_FB_TIMEZONE : parUSF_FB_TIMEZONE {}
public class inUSF_FB_UID : parUSF_FB_UID {}
public class inUSF_FB_USERNAME : parUSF_FB_USERNAME {}
public class inUSF_ID : parUSF_ID {}
public class inUSF_SEX_TYPE : parUSF_SEX_TYPE {}
public class inUSF_THIRD_PARTY_ID : parUSF_THIRD_PARTY_ID {}
public class inUSF_UID : parUSF_UID {}
public class inUSF_USER_ID : parUSF_USER_ID {}
public class outiScopeIdentity : pariScopeIdentity {}
public static int ExecuteNonQuery(
System.Nullable<int> p_iiScopeIdentity, System.Nullable<DateTime> p_dtUSF_BIRTHDAY, string p_strUSF_FB_BIRTHDAY_DATE, string p_strUSF_FB_EMAIL, string p_strUSF_FB_FIRST_NAME, string p_strUSF_FB_LAST_NAME, string p_strUSF_FB_LOCALE, string p_strUSF_FB_MIDDLE_NAME, string p_strUSF_FB_NAME, string p_strUSF_FB_PIC, string p_strUSF_FB_PROFILE_URL, string p_strUSF_FB_SEX, string p_strUSF_FB_TIMEZONE, string p_strUSF_FB_UID, string p_strUSF_FB_USERNAME, System.Nullable<int> p_iUSF_ID, System.Nullable<int> p_iUSF_SEX_TYPE, string p_strUSF_THIRD_PARTY_ID, string p_strUSF_UID, System.Nullable<int> p_iUSF_USER_ID,out object p_iiScopeIdentityOut)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_iiScopeIdentity, p_dtUSF_BIRTHDAY, p_strUSF_FB_BIRTHDAY_DATE, p_strUSF_FB_EMAIL, p_strUSF_FB_FIRST_NAME, p_strUSF_FB_LAST_NAME, p_strUSF_FB_LOCALE, p_strUSF_FB_MIDDLE_NAME, p_strUSF_FB_NAME, p_strUSF_FB_PIC, p_strUSF_FB_PROFILE_URL, p_strUSF_FB_SEX, p_strUSF_FB_TIMEZONE, p_strUSF_FB_UID, p_strUSF_FB_USERNAME, p_iUSF_ID, p_iUSF_SEX_TYPE, p_strUSF_THIRD_PARTY_ID, p_strUSF_UID, p_iUSF_USER_ID);
int iResult = db.ExecuteNonQuery(cmd);
SqlCommandOutput(cmd, out p_iiScopeIdentityOut);

return iResult;
}
catch (System.Exception ex)
{
MADA.DatePercent.BB.WL.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static int ExecuteNonQuery(
System.Nullable<int> p_iiScopeIdentity, System.Nullable<DateTime> p_dtUSF_BIRTHDAY, string p_strUSF_FB_BIRTHDAY_DATE, string p_strUSF_FB_EMAIL, string p_strUSF_FB_FIRST_NAME, string p_strUSF_FB_LAST_NAME, string p_strUSF_FB_LOCALE, string p_strUSF_FB_MIDDLE_NAME, string p_strUSF_FB_NAME, string p_strUSF_FB_PIC, string p_strUSF_FB_PROFILE_URL, string p_strUSF_FB_SEX, string p_strUSF_FB_TIMEZONE, string p_strUSF_FB_UID, string p_strUSF_FB_USERNAME, System.Nullable<int> p_iUSF_ID, System.Nullable<int> p_iUSF_SEX_TYPE, string p_strUSF_THIRD_PARTY_ID, string p_strUSF_UID, System.Nullable<int> p_iUSF_USER_ID,out object p_iiScopeIdentityOut,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_iiScopeIdentity, p_dtUSF_BIRTHDAY, p_strUSF_FB_BIRTHDAY_DATE, p_strUSF_FB_EMAIL, p_strUSF_FB_FIRST_NAME, p_strUSF_FB_LAST_NAME, p_strUSF_FB_LOCALE, p_strUSF_FB_MIDDLE_NAME, p_strUSF_FB_NAME, p_strUSF_FB_PIC, p_strUSF_FB_PROFILE_URL, p_strUSF_FB_SEX, p_strUSF_FB_TIMEZONE, p_strUSF_FB_UID, p_strUSF_FB_USERNAME, p_iUSF_ID, p_iUSF_SEX_TYPE, p_strUSF_THIRD_PARTY_ID, p_strUSF_UID, p_iUSF_USER_ID);
int iResult = p_db.ExecuteNonQuery(cmd, p_trn);
SqlCommandOutput(cmd, out p_iiScopeIdentityOut);

return iResult;
}
catch (System.Exception ex)
{
MADA.DatePercent.BB.WL.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
