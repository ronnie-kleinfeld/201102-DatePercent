using System;
using System.Collections.Generic;
using System.Text;
using MADA.ContactFetcher.com.stescodes.www;

namespace MADA.ContactFetcher
{
    public class StesCodes
    {
        public static ContactsDataSet DoFetch(string p_strServiceName, string p_strUserName, string p_strPassword, string p_strSecretKet)
        {
            ContactsDataSet ds = new ContactsDataSet();
            ds.DomainType.AddDomainTypeRow("StesCodes");

            stescodescontactgrabber stescodescontactgrabber = new stescodescontactgrabber();
            contactdetails[] a_contactdetails = stescodescontactgrabber.GrabContacts(p_strServiceName, p_strUserName, p_strPassword, p_strSecretKet);

            foreach (contactdetails contactdetails in a_contactdetails)
            {
                ds.Contact.AddContactRow(contactdetails.name, contactdetails.email);
            }

            return ds;
        }
    }
}