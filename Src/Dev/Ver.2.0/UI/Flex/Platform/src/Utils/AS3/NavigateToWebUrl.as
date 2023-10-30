package Utils.AS3
{
	import Data.MemberData;
	
	import Handler.AppHandler;
	import Handler.ParHandler;
	
	import flash.net.URLRequest;
	import flash.net.navigateToURL;
	
	import mx.controls.Alert;
	
	public class NavigateToWebUrl
	{
		public static function RedirectToApp(p_bIsSelf:Boolean):void
		{
			DoURLRequest("http://www.datepercent.com", p_bIsSelf);
		}
		public static function PrivacyPolicy():void
		{
			DoURLRequest("http://www.datepercent.com/legal/PrivacyPolicy.pdf", false);
		}
		public static function TermsOfUse():void
		{
			DoURLRequest("http://www.datepercent.com/legal/EULA.pdf", false);
		}
		public static function ShareAppOnFacebook():void
		{
			// http://www.facebook.com/dialog/apprequests?app_id=270197676385787&message=I%20wanted%20to%20share%20this%20app%20with%20you&redirect_uri=http://apps.facebook.com/datepercent_vtwo_lh/
			DoURLRequest("http://www.facebook.com/dialog/apprequests?app_id=" + Const.FB_APP_ID + "&message=I%20wanted%20to%20share%20this%20app%20with%20you&redirect_uri=" + Const.FB_CANVAS_PAGE_URL, false);
		}
		public static function ShareMemberOnFacebook(p_memberData:MemberData):void
		{
			// http://www.facebook.com/dialog/apprequests?app_id=270197676385787&message=I%20wanted%20to%20share%20this%20memebr%20with%20you&redirect_uri=http://apps.facebook.com/datepercent_vtwo_lh/?DetailsUidUrl=CC2C5427-756D-485A-9863-755FB050652B
			DoURLRequest("http://www.facebook.com/dialog/apprequests?app_id=" + Const.FB_APP_ID + "&message=I%20wanted%20to%20share%20this%20member%20with%20you&redirect_uri=" + Const.FB_CANVAS_PAGE_URL + "?DetailsUidUrl=" + p_memberData.UID, false);
		}
		public static function GMailContacts(p_strQueryString:String):void
		{
			DoURLRequest(AppHandler.Instance.RootUrl + "Registration/GMail.htm" + p_strQueryString, false);
		}
		public static function OpenWebUrl(p_strUrl:String):void
		{
			DoURLRequest(p_strUrl, false);
		}
		
		private static function DoURLRequest(p_strUrl:String, p_bIsSelf:Boolean):void
		{
			if (p_bIsSelf)
			{
				navigateToURL(new URLRequest(p_strUrl), "_self");
			}
			else
			{
				navigateToURL(new URLRequest(p_strUrl), "_blank");
			}
		}
	}
}