using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using MADA.Log.Api.Net;
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.SPs;
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.Tables;
using System.Reflection;

namespace MADA.DatePercent.BB.WL.BL
{
    public class ListHandler
    {
        public static string AddDetailsIDAsFavorites(int p_iSessionID, int p_iDetailsID)
        {
            string strResult;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                using (DbConnection con = db.CreateConnection())
                {
                    con.Open();
                    DbTransaction trn = con.BeginTransaction();
                    Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                    try
                    {
                        // check if global has a favorites list
                        int iListID = GetListID(p_iSessionID, T_LIST_TYPE_ENUM.FavoritesMembers, db, trn);

                        // check if local exists in list id
                        int iListUserID = GetListUserID(iListID, p_iDetailsID, db, trn);
                        if (iListUserID == -1)
                        {
                            object oLSU_ID;
                            procAPT_LIST_USERInsertInto.ExecuteNonQuery(p_iDetailsID, null, iListID, out oLSU_ID, db, trn);
                            strResult = BE.ResultCode.ADDED;
                        }
                        else
                        {
                            strResult = BE.ResultCode.EXISTS;
                        }

                        trn.Commit();
                        Logger.Instance.WriteCommitTrn(System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }
                    catch (System.Exception ex)
                    {
                        trn.Rollback();
                        Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                        return BE.ResultCode.FAILED;
                    }
                    finally
                    {
                        if (con != null)
                        {
                            con.Close();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                strResult = BE.ResultCode.FAILED;
            }

            return strResult;
        }
        public static string AddDetailsIDAsRecent(int p_iSessionID, int p_iDetailsID)
        {
            string strResult;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                using (DbConnection con = db.CreateConnection())
                {
                    con.Open();
                    DbTransaction trn = con.BeginTransaction();
                    Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                    try
                    {
                        // check if global has a recent list
                        int iListID = GetListID(p_iSessionID, T_LIST_TYPE_ENUM.RecentMembers, db, trn);

                        // check if local exists in list id
                        int iListUserID = GetListUserID(iListID, p_iDetailsID, db, trn);
                        if (iListUserID != -1)
                        {
                            // remove
                            procAPT_LIST_USERDeleteByLSU_DETAILS_USER_IDLSU_LIST_ID.ExecuteNonQuery(p_iDetailsID, iListID);
                        }

                        //  insert
                        object oLSU_ID;
                        procAPT_LIST_USERInsertInto.ExecuteNonQuery(p_iDetailsID, null, iListID, out oLSU_ID, db, trn);

                        trn.Commit();
                        Logger.Instance.WriteCommitTrn(System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                        return BE.ResultCode.SUCCESS;
                    }
                    catch (System.Exception ex)
                    {
                        trn.Rollback();
                        Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                        strResult = BE.ResultCode.FAILED;
                    }
                    finally
                    {
                        if (con != null)
                        {
                            con.Close();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                strResult = BE.ResultCode.FAILED;
            }

            return strResult;
        }

        public static int GetListID(int p_iSessionID, T_LIST_TYPE_ENUM p_enmListType, Database p_db, DbTransaction p_trn)
        {
            int iResult;

            try
            {
                // check if global has a recent list
                DataSet ds = new DataSet();
                procAPT_LISTSelectByLST_SESSION_USER_IDLST_TYPE_CODE.LoadDataSet(ds, tblT_LIST._Name, p_iSessionID, (int)p_enmListType);
                if (ds.Tables[tblT_LIST._Name].Rows.Count == 0)
                {
                    //  no  - insert and get id
                    object oLST_ID;
                    procAPT_LISTInsertInto.ExecuteNonQuery(ApplicationHandler.GetListTypeEnumRow(p_enmListType).LTT_COMMENT,
                        ApplicationHandler.GetListTypeEnumRow(p_enmListType).LTT_DESCRIPTION, null, (int)T_RESULT_VIEW_TYPE_ENUM.Photos, p_iSessionID,
                        (int)p_enmListType, out oLST_ID);
                    if (oLST_ID == null)
                    {
                        throw new Exception("Failed to insert " + p_enmListType + " into T_LIST");
                    }
                    else
                    {
                        iResult = (int)oLST_ID;
                    }
                }
                else
                {
                    //  yes - get id
                    iResult = (int)ds.Tables[tblT_LIST._Name].Rows[0][tblT_LIST.colLST_ID._Name];
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                throw ex;
            }

            return iResult;
        }
        public static int GetListUserID(int p_iListID, int p_iDetailsID, Database p_db, DbTransaction p_trn)
        {
            int iResult;

            try
            {
                DataSet ds = new DataSet();
                procAPT_LIST_USERSelectByLSU_DETAILS_USER_IDLSU_LIST_ID.LoadDataSet(ds, tblT_LIST_USER._Name, p_iDetailsID, p_iListID);
                if (ds.Tables[tblT_LIST_USER._Name].Rows.Count == 0)
                {
                    iResult = -1;
                }
                else
                {
                    iResult = (int)ds.Tables[tblT_LIST_USER._Name].Rows[0][tblT_LIST_USER.colLSU_ID._Name];
                }
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                throw ex;
            }

            return iResult;
        }
    }
}