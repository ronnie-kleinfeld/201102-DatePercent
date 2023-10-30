using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Xml;

namespace MADA.DatePercent.BL
{
    public class Facebook
    {
        public static NameValueCollection FBUserToNameValueCollection(Object p_oFBUser)
        {
            Array ar_oFBUser = (Array)p_oFBUser;

            NameValueCollection col = new NameValueCollection();

            object oFBUser;
            XmlElement xmlElement;
            for (int i = 0; i < ar_oFBUser.Length; i++)
            {
                oFBUser = ar_oFBUser.GetValue(i);
                xmlElement = (XmlElement)oFBUser;

                col.Add(xmlElement.LocalName, xmlElement.InnerXml);
            }

            return col;
        }

        public static bool IsApproved(int p_iLinkType)
        {
            return p_iLinkType == 6 || p_iLinkType == 8;
        }
        public static string DoEncriptions(string p_strText)
        {
            string strResult = p_strText;

            strResult = DoEncription(strResult, ' ');
            strResult = DoEncription(strResult, '-');
            strResult = DoEncription(strResult, '+');
            strResult = DoEncription(strResult, ',');
            strResult = DoEncription(strResult, '\\');
            strResult = DoEncription(strResult, '/');
            strResult = DoEncription(strResult, '=');
            strResult = DoEncription(strResult, '_');
            strResult = DoEncription(strResult, '~');
            strResult = DoEncription(strResult, '.');

            return strResult;
        }
        private static string DoEncription(string p_strText, char p_chSep)
        {
            string strResult = string.Empty;

            string[] a_strText = p_strText.Split(p_chSep);
            if (a_strText.Length > 1)
            {
                foreach (string strText in a_strText)
                {
                    if (strText.Length > 0)
                    {
                        strResult += strText.Substring(0, 1);
                    }
                }
            }
            else
            {
                strResult = p_strText;
            }

            return strResult;
        }
    }
}