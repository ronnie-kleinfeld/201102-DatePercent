using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MADA.DatePercent.BB.WL.BL;
using MADA.Log.Api.Net;
using System.Data.Common;
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.SPs;
using MADA.DatePercent.BB.WL.DBS.dbDatePercentDB20.Tables;
using MADA.ContactFetcher;
using System.Reflection;

namespace MADA.DatePercent.BB.WL.WS.Worker
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
                    Logger.Instance.WriteInformation("Started", MethodBase.GetCurrentMethod(), Environment.MachineName);

                    if (ApplicationHandler.Instance.GetEmailCount == 0)
                    {
                        Logger.Instance.WriteInformation("No contacts to fetch", MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }
                    else
                    {
                        Logger.Instance.WriteProcess("Got " + ApplicationHandler.Instance.GetEmailCount + " contacts to fetch", MethodBase.GetCurrentMethod(), Environment.MachineName);
                    }

                    while (ApplicationHandler.Instance.GetEmailCount > 0)
                    {
                        DbTransaction trn = null;

                        try
                        {
                            drEmail = ApplicationHandler.Instance.GetEmail();
                            Logger.Instance.WriteProcess("Fetching contacts for email=" + drEmail.UserName, MethodBase.GetCurrentMethod(), Environment.MachineName);
                            Logger.Instance.Write(drEmail, MethodBase.GetCurrentMethod(), Environment.MachineName);

                            trn = m_con.BeginTransaction();
                            Logger.Instance.WriteBeginTrn(System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);

                            // parse email and get domain type
                            string[] a_strDomain = drEmail.UserName.Split('@');
                            string strDomain = a_strDomain[1].ToUpper();
                            Logger.Instance.WriteInformation("Domain: " + strDomain, MethodBase.GetCurrentMethod(), Environment.MachineName);

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
                                Logger.Instance.WriteProcess("Domain not found for email:" + drEmail.UserName, MethodBase.GetCurrentMethod(), Environment.MachineName);
                            }
                            else
                            {
                                Logger.Instance.WriteInformation("Got domain: " + drDomainType.DMT_CODE + "-" + drDomainType.DMT_DOMAIN, MethodBase.GetCurrentMethod(), Environment.MachineName);
                            }

                            // fetch contacts
                            int iMaxDMT_CODE = -1;
                            ContactsDataSet dsContacts = null;
                            if (drDomainType == null)
                            {
                                Logger.Instance.WriteInformation("Domain not found", MethodBase.GetCurrentMethod(), Environment.MachineName);
                                iMaxDMT_CODE = MADA.Data.DataTable.MaxIDByOrderBy(ApplicationHandler.Instance.T_DOMAIN_TYPE_ENUM, tblT_DOMAIN_TYPE_ENUM.colDMT_CODE._Name,
                                    tblT_DOMAIN_TYPE_ENUM.colDMT_CODE._Name);
                                procAPT_DOMAIN_TYPE_ENUMInsertInto.ExecuteNonQuery(iMaxDMT_CODE + 1, strDomain, strDomain, 0, string.Empty, string.Empty, m_db, trn);
                                Logger.Instance.WriteInformation("Insert new domain", MethodBase.GetCurrentMethod(), Environment.MachineName);

                                ApplicationHandler.Instance.RefershT_DOMAIN_TYPE_ENUM();
                                Logger.Instance.WriteInformation("ApplicationHandler refreshed", MethodBase.GetCurrentMethod(), Environment.MachineName);
                            }
                            else
                            {
                                Logger.Instance.Write(drDomainType, MethodBase.GetCurrentMethod(), Environment.MachineName);

                                T_CONTACT_FETCHER_TYPE_ENUM enmContactFetcherType = (T_CONTACT_FETCHER_TYPE_ENUM)drDomainType.DMT_FETCHER_CODE;
                                switch (enmContactFetcherType)
                                {
                                    case T_CONTACT_FETCHER_TYPE_ENUM.Online:
                                        Logger.Instance.WriteInformation("Online", MethodBase.GetCurrentMethod(), Environment.MachineName);
                                        // gmail is online via Google.GData.AuthSub in GMail.htm web page
                                        break;
                                    case T_CONTACT_FETCHER_TYPE_ENUM.StesCodes:
                                        dsContacts = ContactFetcher.StesCodes.DoFetch(drDomainType.DMT_SERVICE_NAME, drEmail.UserName, drEmail.Password, drEmail.SecretKey);
                                        Logger.Instance.WriteInformation("StesCodes", MethodBase.GetCurrentMethod(), Environment.MachineName);
                                        break;
                                    case T_CONTACT_FETCHER_TYPE_ENUM.Unkonwn:
                                        // unkonw fetcher - try all
                                        Logger.Instance.WriteInformation("Unkonwn", MethodBase.GetCurrentMethod(), Environment.MachineName);
                                        dsContacts = ContactFetcher.StesCodes.DoFetch(drDomainType.DMT_SERVICE_NAME, drEmail.UserName, drEmail.Password, drEmail.SecretKey);
                                        break;
                                    default:
                                        Logger.Instance.WriteSwitchOutOfRange(enmContactFetcherType.ToString(), MethodBase.GetCurrentMethod(), Environment.MachineName);
                                        break;
                                }
                            }
                            Logger.Instance.WriteInformation("Fetcher done", MethodBase.GetCurrentMethod(), Environment.MachineName);

                            // insert invitees
                            if (dsContacts == null)
                            {
                                Logger.Instance.WriteCritical("Failed to get contacts for email=" + drEmail.UserName, MethodBase.GetCurrentMethod(), Environment.MachineName);
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
                                Logger.Instance.WriteInformation("iMaxDMT_CODE:" + iMaxDMT_CODE, MethodBase.GetCurrentMethod(), Environment.MachineName);

                                Logger.Instance.WriteInformation("Invite started", MethodBase.GetCurrentMethod(), Environment.MachineName);
                                foreach (ContactFetcher.ContactsDataSet.ContactRow drContact in dsContacts.Contact.Rows)
                                {
                                    try
                                    {
                                        Logger.Instance.WriteInformation("Inviting:" + drContact.Email, MethodBase.GetCurrentMethod(), Environment.MachineName);
                                        InviteeHandler.Invite(drContact.Email, string.Empty, drEmail.UserID, drContact.Name,
                                            T_USER_INVITEE_TYPE_ENUM.Added, m_db, trn);
                                    }
                                    catch (Exception ex)
                                    {
                                        Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
                                    }
                                }
                                Logger.Instance.WriteInformation("Invite ended", MethodBase.GetCurrentMethod(), Environment.MachineName);

                                Logger.Instance.WriteProcess("New " + dsContacts.Contact.Count + " invitations in T_USER_INVITEE",
                                    System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                            }

                            trn.Commit();
                            Logger.Instance.WriteCommitTrn(System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                        }
                        catch (Exception ex)
                        {
                            Logger.Instance.WriteRollbackTrn(ex, MethodBase.GetCurrentMethod(), Environment.MachineName);
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
                    Logger.Instance.WriteInformation("Ended", MethodBase.GetCurrentMethod(), Environment.MachineName);
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