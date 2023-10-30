using System;
using System.Collections.Generic;
using System.Text;

namespace MADA.ContactFetcher
{
    public class DomainName
    {
        public static ContactsDataSet DoFetch(string p_strUserName, string p_strPassword)
        {
            ContactsDataSet ds = new ContactsDataSet();
            ds.DomainType.AddDomainTypeRow("DomainName");

            // get the contacts


            return ds;
        }
    }
}