namespace MADA.DatePercent.BE
{
    public sealed class Constants
    {
        public const string UICanvasPageUrl   = "http://apps.facebook.com/date-percent/";
        public const string RootUrl           = "http://www.datepercent.com/";
        public const string RootFlexUrl       = "http://www.datepercent.com/Flex/";
        public const string FB_APP_ID         = "224260514289069";
        public const string FB_SECRET         = "1f6f75a1373e4150431ce274087b8587";

        //public const string UICanvasPageUrl = "http://apps.facebook.com/date-percent-lh/";
        //public const string RootUrl = "http://localhost:2631/";
        //public const string RootFlexUrl = "http://localhost:2631/Flex/";
        //public const string FB_APP_ID = "244125612293062";
        //public const string FB_SECRET = "f2454d078f087d9ecc3ef5b26a612b51";

        public const string FB_ACCESS_TOKEN_KEY = "geroghlijklhsdjf";

        public const string STES_CODES_SIGNATURE_KEY = "tx_135da7a1-714f-4450-bbf1-3c5e97f9a3ce";

        public const string DATE_PERCENT_UID = "EFCCA098-D661-4CD5-99EF-E9AAD2591318";

        public const string LOAD_DATASET_TABLE_NAME = "Table";
        public const string HTML_TITLE = "DatePercent";

        public const string SID_KEY = "fowijgerjgljktr";
        public const string USER_EXISTS_URL_KEY = "dpexists";
        public const string REFERRER_URL_KEY = "referrer";
        public const string DETAILS_UID_URL_KEY = "webnrejklwnfklw";
        public const string DELETE_UID_URL_KEY = "ioputweporihjkl";
        public const string UNSUBSCRIBE_UID_URL_KEY = "podjfgkljenrngj";
        public const string EMAIL_URL_KEY = "EMail";
        public const string SUPPORT_ID_KEY = "ioyusdlkgjlkwje";
        public const string UID_URL_KEY = "oqwvfijiowieiju";
        public const string INVITE_ID_KEY = "wuefhwenfoasidi";

        public const string UIDefaultUrl = RootUrl + "Default.aspx";
        public const string UIRedirectToAppUrl = RootUrl + "RedirectToApp.htm";
        public const string UIResUrl = RootUrl + "res/";
        public const string UIResNoImageUrl = RootUrl + "res/male.jpg";
        public const string UIResNoImageMaleUrl = RootUrl + "res/male.jpg";
        public const string UIResNoImageFemaleUrl = RootUrl + "res/female.jpg";
        public const string UIResLogo36x36Url = RootUrl + "res/36x36.png";
        public const string UIRegistrationGMailUrl = RootUrl + "Registration/GMail.htm";
        public const string UIRegistrationUnsubscribeUrl = RootUrl + "Registration/Unsubscribe.aspx";
        public const string UIGoodbyeUrl = RootUrl + "public/Goodbye.aspx";
        public const string UIUnauthorisedUrl = RootUrl + "public/Unauthorised.aspx";
        public const string EMailWrapperHtml = "<div dir='ltr'><%Divs%><br /><div style='padding-left: 10px; padding-top: 5px; width: 100%; color: rgb(59, 89, 152); font-size: 12px; text-align: left; height: 23px;'>© Copyright 2011 <a href='<%UIRedirectToAppUrl%>' style='color: rgb(59, 89, 152);' target='_blank'>DatePercent Ltd</a>. All rights reserved.</div><div style='padding: 6px; text-align: left; font-family: Verdana, Arial, sans-serif; color: rgb(98, 122, 173); font-size: 10px;'>This email was intended for <a style='color: rgb(98, 122, 173);' href='mailto:<%EMB_GETTER_EMAIL%>' target='_blank'><%EMB_GETTER_EMAIL%></a>.<br />Click <a style='color: rgb(59, 89, 152);' href='<%UIRegistrationUnsubscribeUrl%>?<%UNSUBSCRIBE_UID_URL_KEY%>=<%UNSUBSCRIBE_UID_URL_VALUE%>' target='_blank'>here</a> to unsubscribe.</div></div>";
        public const string EMailBoxHtml = "<div dir='ltr' style='text-align: left;'><div style='width: 100%; color: rgb(59, 89, 152); font-family: Verdana, Arial, sans-serif; font-size: 14px; text-align: left; height: 23px;'><%EBT_SUBJECT%></div><a href='<%EBT_PATH%><%EBT_QUERY_STRING%>' target='_blank'><img style='width: 133px; height: 100px;' src='<%EBT_PIC_URL%>' alt='Click here to <%EBT_CLICK_HERE_TO%>' /></a><div style='padding-left: 10px; padding-top: 5px; width: 100%; color: rgb(59, 89, 152); font-family: Verdana, Arial, sans-serif; font-size: 12px; text-align: left;'><em><%UserText%></em></div><div style='padding-left: 10px; padding-top: 5px; width: 100%; color: rgb(59, 89, 152); font-family: Verdana, Arial, sans-serif; font-size: 13px; text-align: left;'>Click <a href='<%EBT_PATH%><%EBT_QUERY_STRING%>' target='_blank'>here</a> to <%EBT_CLICK_HERE_TO%></div><br /></div>";
    }
}