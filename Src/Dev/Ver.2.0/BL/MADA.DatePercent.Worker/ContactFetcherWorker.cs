using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using MADA.DatePercent.BL;
using MADA.DatePercent.DBS.dbDatePercentDB.SPs;
using MADA.DatePercent.DBS.dbDatePercentDB.Tables;
using MADA.ContactFetcher;
using MADA.Log.Api.Net;

namespace MADA.DatePercent.Worker
{
    public class ContactFetcherWorker : WorkerDBBase
    {
        #region Properties
        protected override string WorkerName
        {
            get
            {
                return "ContactFetcherWorker";
            }
        }
        #endregion
        #region Class
        public ContactFetcherWorker()
            : base()
        {
        }
        public override void Dispose()
        {
            base.Dispose();
        }
        #endregion
        #region Methods
        public override void DoWork(bool p_bLogWorkerName)
        {
            base.DoWork(p_bLogWorkerName);

            if (m_bAvaliableToWork)
            {
                m_bAvaliableToWork = false;

                ApplicationHandler.EmailRow drEmail = null;
                try
                {
                    Logger.Instance.WriteInformation("Started", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                    if (ApplicationHandler.Instance.GetEmailCount == 0)
                    {
                        Logger.Instance.WriteInformation("No contacts to fetch", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }
                    else
                    {
                        Logger.Instance.WriteProcess("Got " + ApplicationHandler.Instance.GetEmailCount + " contacts to fetch", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }

                    while (ApplicationHandler.Instance.GetEmailCount > 0)
                    {
                        DbTransaction trn = null;

                        try
                        {
                            drEmail = ApplicationHandler.Instance.GetEmail();
                            Logger.Instance.WriteProcess("Fetching contacts for email=" + drEmail.UserName, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                            Logger.Instance.Write(drEmail, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                            trn = m_con.BeginTransaction();
                            Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                            // parse email and get domain type
                            string[] a_strDomain = drEmail.UserName.Split('@');
                            string strDomain = a_strDomain[1].ToUpper();
                            Logger.Instance.WriteInformation("Domain: " + strDomain, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                            ApplicationHandler.T_DOMAIN_TYPE_ENUMRow drDomainType = null;
                            foreach (ApplicationHandler.T_DOMAIN_TYPE_ENUMRow dr in ApplicationHandler.Instance.T_DOMAIN_TYPE_ENUM)
                            {
                                try
                                {
                                    if (dr.DMT_DOMAIN.ToUpper() == strDomain.Substring(0, dr.DMT_DOMAIN.Length))
                                    {
                                        drDomainType = dr;
                                        break;
                                    }
                                }
                                catch
                                {
                                }
                            }
                            if (drDomainType == null)
                            {
                                Logger.Instance.WriteProcess("Domain not found for email:" + drEmail.UserName, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                            }
                            else
                            {
                                Logger.Instance.WriteInformation("Got domain: " + drDomainType.DMT_CODE + "-" + drDomainType.DMT_DOMAIN, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                            }

                            // fetch contacts
                            int iMaxDMT_CODE = -1;
                            ContactsDataSet dsContacts = null;
                            if (drDomainType == null)
                            {
                                Logger.Instance.WriteInformation("Domain not found", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                                iMaxDMT_CODE = MADA.Data.DataTable.MaxIDByOrderBy(ApplicationHandler.Instance.T_DOMAIN_TYPE_ENUM, tblT_DOMAIN_TYPE_ENUM.colDMT_CODE._Name,
                                    tblT_DOMAIN_TYPE_ENUM.colDMT_CODE._Name);
                                procAPT_DOMAIN_TYPE_ENUMInsertInto.ExecuteNonQuery(iMaxDMT_CODE + 1, strDomain, strDomain, 0, string.Empty, string.Empty, m_db, trn);
                                Logger.Instance.WriteInformation("Insert new domain", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                                ApplicationHandler.Instance.RefershT_DOMAIN_TYPE_ENUM();
                                Logger.Instance.WriteInformation("ApplicationHandler refreshed", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                            }
                            else
                            {
                                Logger.Instance.Write(drDomainType, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                                T_CONTACT_FETCHER_TYPE_ENUM enmContactFetcherType = (T_CONTACT_FETCHER_TYPE_ENUM)drDomainType.DMT_FETCHER_CODE;
                                switch (enmContactFetcherType)
                                {
                                    case T_CONTACT_FETCHER_TYPE_ENUM.Online:
                                        Logger.Instance.WriteInformation("Online", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                                        // gmail is online via Google.GData.AuthSub in GMail.htm web page
                                        break;
                                    case T_CONTACT_FETCHER_TYPE_ENUM.StesCodes:
                                        dsContacts = ContactFetcher.StesCodes.DoFetch(drDomainType.DMT_SERVICE_NAME, drEmail.UserName, drEmail.Password, drEmail.SecretKey);
                                        Logger.Instance.WriteInformation("StesCodes", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                                        break;
                                    case T_CONTACT_FETCHER_TYPE_ENUM.Unkonwn:
                                        // unkonw fetcher - try all
                                        Logger.Instance.WriteInformation("Unkonwn", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                                        dsContacts = ContactFetcher.StesCodes.DoFetch(drDomainType.DMT_SERVICE_NAME, drEmail.UserName, drEmail.Password, drEmail.SecretKey);
                                        break;
                                    default:
                                        Logger.Instance.WriteSwitchOutOfRange(enmContactFetcherType.ToString(), System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                                        break;
                                }
                            }
                            Logger.Instance.WriteInformation("Fetcher done", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                            // insert invitees
                            if (dsContacts == null)
                            {
                                Logger.Instance.WriteCritical("Failed to get contacts for email=" + drEmail.UserName, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                                throw new Exception("Failed to get contacts for email=" + drEmail.UserName);
                            }
                            else
                            {
                                Logger.Instance.WriteProcess("Fetched " + dsContacts.Contact.Count + " contacts for email=" + drEmail.UserName,
                                    System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                                if (iMaxDMT_CODE != -1)
                                {
                                    procPT_DOMAIN_TYPE_ENUMUpdateDMT_FETCHERByDMT_CODE.ExecuteNonQuery(iMaxDMT_CODE, dsContacts.DomainType[0].FetcherName, m_db, trn);
                                }
                                Logger.Instance.WriteInformation("iMaxDMT_CODE:" + iMaxDMT_CODE, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                                Logger.Instance.WriteInformation("Invite started", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                                foreach (ContactFetcher.ContactsDataSet.ContactRow drContact in dsContacts.Contact.Rows)
                                {
                                    try
                                    {
                                        Logger.Instance.WriteInformation("Inviting:" + drContact.Email, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                                        InviteeHandler.Invite(drContact.Email, string.Empty, drEmail.UserID, drContact.Name,
                                            T_USER_INVITEE_TYPE_ENUM.Added, m_db, trn);
                                    }
                                    catch (Exception ex)
                                    {
                                        Logger.Instance.WriteRollbackTrn(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                                    }
                                }
                                Logger.Instance.WriteInformation("Invite ended", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                                Logger.Instance.WriteProcess("New " + dsContacts.Contact.Count + " invitations in T_USER_INVITEE",
                                    System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                            }

                            trn.Commit();
                            Logger.Instance.WriteCommitTrn(System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                        }
                        catch (Exception ex)
                        {
                            Logger.Instance.WriteRollbackTrn(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                            trn.Rollback();
                            RestartDB();
                        }
                        finally
                        {
                            if (drEmail != null)
                            {
                                ApplicationHandler.Instance.RemoveEmail(drEmail);
                            }
                        }
                    }
                    Logger.Instance.WriteInformation("Ended", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                }
                finally
                {
                    m_bAvaliableToWork = true;
                }
            }
        }
        #endregion
    }
}