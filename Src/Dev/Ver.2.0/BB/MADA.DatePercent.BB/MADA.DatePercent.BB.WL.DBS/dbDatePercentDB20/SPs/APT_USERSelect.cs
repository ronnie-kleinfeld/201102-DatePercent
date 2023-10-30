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
public class procAPT_USERSelect
{
public const string _Name = "APT_USERSelect";
public const string _Caption = "APT_ USERSelect";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_USERSelect";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
}
public class rsAPT_USERSelect
{
public const string _Name = "APT_USERSelect";
public const string _Caption = "APT_ USERSelect";
public const string _ParentName = "APT_USERSelect";
public class slcUSR_ADDED_DATETIME
{
public const string _Name = "USR_ADDED_DATETIME";
public const string _Caption = "USR_ ADDED_ DATETIME";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.DateTime;
public const Int32 _Length = -1;
}
public class slcUSR_ID
{
public const string _Name = "USR_ID";
public const string _Caption = "USR_ ID";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_LOCALE
{
public const string _Name = "USR_LOCALE";
public const string _Caption = "USR_ LOCALE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcUSR_NAME
{
public const string _Name = "USR_NAME";
public const string _Caption = "USR_ NAME";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcUSR_PIC_URL
{
public const string _Name = "USR_PIC_URL";
public const string _Caption = "USR_ PIC_ URL";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
}
public class slcUSR_PROFILE_URL
{
public const string _Name = "USR_PROFILE_URL";
public const string _Caption = "USR_ PROFILE_ URL";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
}
public class slcUSR_PROP_ABOUT_ME
{
public const string _Name = "USR_PROP_ABOUT_ME";
public const string _Caption = "USR_ PROP_ ABOUT_ ME";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
}
public class slcUSR_PROP_AGE_RANGE_FROM_CODE
{
public const string _Name = "USR_PROP_AGE_RANGE_FROM_CODE";
public const string _Caption = "USR_ PROP_ AGE_ RANGE_ FROM_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_AGE_RANGE_TO_CODE
{
public const string _Name = "USR_PROP_AGE_RANGE_TO_CODE";
public const string _Caption = "USR_ PROP_ AGE_ RANGE_ TO_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_BIRTHDATE
{
public const string _Name = "USR_PROP_BIRTHDATE";
public const string _Caption = "USR_ PROP_ BIRTHDATE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.DateTime;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_BODY_STYLE_CODE
{
public const string _Name = "USR_PROP_BODY_STYLE_CODE";
public const string _Caption = "USR_ PROP_ BODY_ STYLE_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_CUSTODY_CODE
{
public const string _Name = "USR_PROP_CUSTODY_CODE";
public const string _Caption = "USR_ PROP_ CUSTODY_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_DRINK_CODE
{
public const string _Name = "USR_PROP_DRINK_CODE";
public const string _Caption = "USR_ PROP_ DRINK_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_EDUCATION_CODE
{
public const string _Name = "USR_PROP_EDUCATION_CODE";
public const string _Caption = "USR_ PROP_ EDUCATION_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_EYE_CODE
{
public const string _Name = "USR_PROP_EYE_CODE";
public const string _Caption = "USR_ PROP_ EYE_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_HAIR_CODE
{
public const string _Name = "USR_PROP_HAIR_CODE";
public const string _Caption = "USR_ PROP_ HAIR_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_HAVE_KIDS_CODE
{
public const string _Name = "USR_PROP_HAVE_KIDS_CODE";
public const string _Caption = "USR_ PROP_ HAVE_ KIDS_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_HEIGHT_CODE
{
public const string _Name = "USR_PROP_HEIGHT_CODE";
public const string _Caption = "USR_ PROP_ HEIGHT_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_MATCH_DRINK_CODE
{
public const string _Name = "USR_PROP_MATCH_DRINK_CODE";
public const string _Caption = "USR_ PROP_ MATCH_ DRINK_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_MATCH_HAVE_KIDS_CODE
{
public const string _Name = "USR_PROP_MATCH_HAVE_KIDS_CODE";
public const string _Caption = "USR_ PROP_ MATCH_ HAVE_ KIDS_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_MATCH_SEX_CODE
{
public const string _Name = "USR_PROP_MATCH_SEX_CODE";
public const string _Caption = "USR_ PROP_ MATCH_ SEX_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_MATCH_SMOKE_CODE
{
public const string _Name = "USR_PROP_MATCH_SMOKE_CODE";
public const string _Caption = "USR_ PROP_ MATCH_ SMOKE_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_MATCH_WANT_KIDS_CODE
{
public const string _Name = "USR_PROP_MATCH_WANT_KIDS_CODE";
public const string _Caption = "USR_ PROP_ MATCH_ WANT_ KIDS_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_MY_IDEAL_MATCH
{
public const string _Name = "USR_PROP_MY_IDEAL_MATCH";
public const string _Caption = "USR_ PROP_ MY_ IDEAL_ MATCH";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
}
public class slcUSR_PROP_OCCUPATION_CODE
{
public const string _Name = "USR_PROP_OCCUPATION_CODE";
public const string _Caption = "USR_ PROP_ OCCUPATION_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_RACE_CODE
{
public const string _Name = "USR_PROP_RACE_CODE";
public const string _Caption = "USR_ PROP_ RACE_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_RELIGION_CODE
{
public const string _Name = "USR_PROP_RELIGION_CODE";
public const string _Caption = "USR_ PROP_ RELIGION_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_SEX_CODE
{
public const string _Name = "USR_PROP_SEX_CODE";
public const string _Caption = "USR_ PROP_ SEX_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_SMOKE_CODE
{
public const string _Name = "USR_PROP_SMOKE_CODE";
public const string _Caption = "USR_ PROP_ SMOKE_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_STATUS_CODE
{
public const string _Name = "USR_PROP_STATUS_CODE";
public const string _Caption = "USR_ PROP_ STATUS_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_WANT_KIDS_CODE
{
public const string _Name = "USR_PROP_WANT_KIDS_CODE";
public const string _Caption = "USR_ PROP_ WANT_ KIDS_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_WEIGHT_CODE
{
public const string _Name = "USR_PROP_WEIGHT_CODE";
public const string _Caption = "USR_ PROP_ WEIGHT_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PROP_ZODIAC_SIGN_CODE
{
public const string _Name = "USR_PROP_ZODIAC_SIGN_CODE";
public const string _Caption = "USR_ PROP_ ZODIAC_ SIGN_ CODE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_SUBSCRIBE
{
public const string _Name = "USR_SUBSCRIBE";
public const string _Caption = "USR_ SUBSCRIBE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = -1;
}
public class slcUSR_TIMEZONE
{
public const string _Name = "USR_TIMEZONE";
public const string _Caption = "USR_ TIMEZONE";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_UID
{
public const string _Name = "USR_UID";
public const string _Caption = "USR_ UID";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcUSR_V_NAME
{
public const string _Name = "USR_V_NAME";
public const string _Caption = "USR_ V_ NAME";
public const string _ParentName = "APT_USERSelect";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 10;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand();
db.LoadDataSet(cmd, p_ds, p_strTableName);}
catch (System.Exception ex)
{
MADA.DatePercent.BB.WL.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand();
p_db.LoadDataSet(cmd, p_ds, p_strTableName, p_trn);}
catch (System.Exception ex)
{
MADA.DatePercent.BB.WL.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
