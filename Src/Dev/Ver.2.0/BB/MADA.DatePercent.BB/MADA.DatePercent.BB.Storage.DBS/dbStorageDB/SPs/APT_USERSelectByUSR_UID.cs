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

namespace MADA.DatePercent.BB.Storage.DBS.dbStorageDB.SPs
{
public class procAPT_USERSelectByUSR_UID
{
public const string _Name = "APT_USERSelectByUSR_UID";
public const string _Caption = "APT_ USERSelect By USR_ UID";

public static SqlCommand SqlCommand()
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_USERSelectByUSR_UID";
SqlParameterCollection(cmd.Parameters);
return cmd;
}
public static SqlCommand SqlCommand(
string p_strUSR_UID)
{
System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
cmd.CommandType = CommandType.StoredProcedure;
cmd.CommandText = "APT_USERSelectByUSR_UID";
SqlParameterCollection(cmd.Parameters, p_strUSR_UID);
return cmd;
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUSR_UID._SqlParameter());
}
public static void SqlParameterCollection(
System.Data.SqlClient.SqlParameterCollection p_oSqlParameterCollection
, string p_strUSR_UID)
{
p_oSqlParameterCollection.Clear();
p_oSqlParameterCollection.Add(parUSR_UID._SqlParameter(p_strUSR_UID));
}
public class parUSR_UID
{
public const string _Name = "@USR_UID";
public const string _Caption = "@ USR_ UID";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
public const bool _IsNullable = true;
public const string _BindDataAdapter = "APT_USERSelectByUSR_UID.DefaultView.[0].@USR_UID";
public const string _BindDataReader = "[@USR_UID]";
public const ParameterDirection _ParameterDirection = ParameterDirection.Input;
public static SqlParameter _SqlParameter()
{
return DBS.Tools.CreateSqlParameterReferenceType("@USR_UID", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "");
}
public static SqlParameter _SqlParameter(string Value)
{
return DBS.Tools.CreateSqlParameterReferenceType("@USR_UID", 255, -1, 255, SqlDbType.NVarChar, "string", ParameterDirection.Input, true, false, "", Value);
}
}
public class inUSR_UID : parUSR_UID {}
public class rsAPT_USERSelectByUSR_UID
{
public const string _Name = "APT_USERSelectByUSR_UID";
public const string _Caption = "APT_ USERSelect By USR_ UID";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public class slcUSR_ADDED_TIMEDATE
{
public const string _Name = "USR_ADDED_TIMEDATE";
public const string _Caption = "USR_ ADDED_ TIMEDATE";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.DateTime;
public const Int32 _Length = -1;
}
public class slcUSR_BIRTHDAY
{
public const string _Name = "USR_BIRTHDAY";
public const string _Caption = "USR_ BIRTHDAY";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.DateTime;
public const Int32 _Length = -1;
}
public class slcUSR_CREDITS_BALANCE
{
public const string _Name = "USR_CREDITS_BALANCE";
public const string _Caption = "USR_ CREDITS_ BALANCE";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_DISTANCE_UNITS_CODE
{
public const string _Name = "USR_DISTANCE_UNITS_CODE";
public const string _Caption = "USR_ DISTANCE_ UNITS_ CODE";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_DONT_ASK_ADD_TO_FAVORITES
{
public const string _Name = "USR_DONT_ASK_ADD_TO_FAVORITES";
public const string _Caption = "USR_ DONT_ ASK_ ADD_ TO_ FAVORITES";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = -1;
}
public class slcUSR_DONT_ASK_BLOCK_MEMBER
{
public const string _Name = "USR_DONT_ASK_BLOCK_MEMBER";
public const string _Caption = "USR_ DONT_ ASK_ BLOCK_ MEMBER";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = -1;
}
public class slcUSR_DONT_ASK_FEEDBACK_SENT
{
public const string _Name = "USR_DONT_ASK_FEEDBACK_SENT";
public const string _Caption = "USR_ DONT_ ASK_ FEEDBACK_ SENT";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = -1;
}
public class slcUSR_DONT_ASK_INVITATION_SENT
{
public const string _Name = "USR_DONT_ASK_INVITATION_SENT";
public const string _Caption = "USR_ DONT_ ASK_ INVITATION_ SENT";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = -1;
}
public class slcUSR_DONT_ASK_PROFILE_UPDATED
{
public const string _Name = "USR_DONT_ASK_PROFILE_UPDATED";
public const string _Caption = "USR_ DONT_ ASK_ PROFILE_ UPDATED";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = -1;
}
public class slcUSR_DONT_ASK_REMOVE_FROM_BLACK_LIST
{
public const string _Name = "USR_DONT_ASK_REMOVE_FROM_BLACK_LIST";
public const string _Caption = "USR_ DONT_ ASK_ REMOVE_ FROM_ BLACK_ LIST";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = -1;
}
public class slcUSR_DONT_ASK_REMOVE_FROM_FAVORITES
{
public const string _Name = "USR_DONT_ASK_REMOVE_FROM_FAVORITES";
public const string _Caption = "USR_ DONT_ ASK_ REMOVE_ FROM_ FAVORITES";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = -1;
}
public class slcUSR_DONT_ASK_REMOVE_FROM_MY_PHOTOS
{
public const string _Name = "USR_DONT_ASK_REMOVE_FROM_MY_PHOTOS";
public const string _Caption = "USR_ DONT_ ASK_ REMOVE_ FROM_ MY_ PHOTOS";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = -1;
}
public class slcUSR_DONT_ASK_REPORT_SENT
{
public const string _Name = "USR_DONT_ASK_REPORT_SENT";
public const string _Caption = "USR_ DONT_ ASK_ REPORT_ SENT";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = -1;
}
public class slcUSR_DONT_ASK_TWINK_SENT
{
public const string _Name = "USR_DONT_ASK_TWINK_SENT";
public const string _Caption = "USR_ DONT_ ASK_ TWINK_ SENT";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.Bit;
public const Int32 _Length = -1;
}
public class slcUSR_FB_BIRTHDAY_DATE
{
public const string _Name = "USR_FB_BIRTHDAY_DATE";
public const string _Caption = "USR_ FB_ BIRTHDAY_ DATE";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 10;
}
public class slcUSR_FB_EMAIL
{
public const string _Name = "USR_FB_EMAIL";
public const string _Caption = "USR_ FB_ EMAIL";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcUSR_FB_FIRST_NAME
{
public const string _Name = "USR_FB_FIRST_NAME";
public const string _Caption = "USR_ FB_ FIRST_ NAME";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcUSR_FB_LAST_NAME
{
public const string _Name = "USR_FB_LAST_NAME";
public const string _Caption = "USR_ FB_ LAST_ NAME";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcUSR_FB_LOCALE
{
public const string _Name = "USR_FB_LOCALE";
public const string _Caption = "USR_ FB_ LOCALE";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 10;
}
public class slcUSR_FB_MIDDLE_NAME
{
public const string _Name = "USR_FB_MIDDLE_NAME";
public const string _Caption = "USR_ FB_ MIDDLE_ NAME";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 50;
}
public class slcUSR_FB_PIC_URL
{
public const string _Name = "USR_FB_PIC_URL";
public const string _Caption = "USR_ FB_ PIC_ URL";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
}
public class slcUSR_FB_PICX_URL
{
public const string _Name = "USR_FB_PICX_URL";
public const string _Caption = "USR_ FB_ PICX_ URL";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
}
public class slcUSR_FB_PROFILE_URL
{
public const string _Name = "USR_FB_PROFILE_URL";
public const string _Caption = "USR_ FB_ PROFILE_ URL";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
}
public class slcUSR_FB_SEX
{
public const string _Name = "USR_FB_SEX";
public const string _Caption = "USR_ FB_ SEX";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 6;
}
public class slcUSR_FB_THIRD_PARTY_ID
{
public const string _Name = "USR_FB_THIRD_PARTY_ID";
public const string _Caption = "USR_ FB_ THIRD_ PARTY_ ID";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcUSR_FB_UID
{
public const string _Name = "USR_FB_UID";
public const string _Caption = "USR_ FB_ UID";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
public class slcUSR_ID
{
public const string _Name = "USR_ID";
public const string _Caption = "USR_ ID";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_LAT
{
public const string _Name = "USR_LAT";
public const string _Caption = "USR_ LAT";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.Decimal;
public const Int32 _Length = -1;
}
public class slcUSR_LNG
{
public const string _Name = "USR_LNG";
public const string _Caption = "USR_ LNG";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.Decimal;
public const Int32 _Length = -1;
}
public class slcUSR_LOCALE_CODE
{
public const string _Name = "USR_LOCALE_CODE";
public const string _Caption = "USR_ LOCALE_ CODE";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_NICK_NAME
{
public const string _Name = "USR_NICK_NAME";
public const string _Caption = "USR_ NICK_ NAME";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 10;
}
public class slcUSR_OLD_USER_ID
{
public const string _Name = "USR_OLD_USER_ID";
public const string _Caption = "USR_ OLD_ USER_ ID";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_PIN_URL
{
public const string _Name = "USR_PIN_URL";
public const string _Caption = "USR_ PIN_ URL";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 2000;
}
public class slcUSR_RADIUS_KM
{
public const string _Name = "USR_RADIUS_KM";
public const string _Caption = "USR_ RADIUS_ KM";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_SEX_CODE
{
public const string _Name = "USR_SEX_CODE";
public const string _Caption = "USR_ SEX_ CODE";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.Int;
public const Int32 _Length = -1;
}
public class slcUSR_UID
{
public const string _Name = "USR_UID";
public const string _Caption = "USR_ UID";
public const string _ParentName = "APT_USERSelectByUSR_UID";
public const SqlDbType _SqlDbType = SqlDbType.NVarChar;
public const Int32 _Length = 255;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,string p_strUSR_UID)
{
try
{
Microsoft.Practices.EnterpriseLibrary.Data.Database db = DatabaseFactory.CreateDatabase();
SqlCommand cmd = SqlCommand(p_strUSR_UID);
db.LoadDataSet(cmd, p_ds, p_strTableName);}
catch (System.Exception ex)
{
MADA.DatePercent.BB.Storage.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
public static void LoadDataSet(System.Data.DataSet p_ds, string p_strTableName,string p_strUSR_UID,Microsoft.Practices.EnterpriseLibrary.Data.Database p_db,System.Data.Common.DbTransaction p_trn)
{
try
{
SqlCommand cmd = SqlCommand(p_strUSR_UID);
p_db.LoadDataSet(cmd, p_ds, p_strTableName, p_trn);}
catch (System.Exception ex)
{
MADA.DatePercent.BB.Storage.DBS.Tools.WriteToLog(ex, System.Reflection.MethodBase.GetCurrentMethod());
throw;
}
}
}
}
