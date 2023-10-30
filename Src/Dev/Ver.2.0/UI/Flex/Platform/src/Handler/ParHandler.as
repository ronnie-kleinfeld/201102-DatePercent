// query string details
// m_oParameters = Object(this.loaderInfo.parameters);
// to access parameters of sample: file.html?key1=val1&mid=87893745
// m_oParameters.key1 returns val1
// m_oParameters.mid  returns 87893745
package Handler
{
	import Utils.AS3.Const;
	import Utils.AS3.ObjectUtil;
	import Utils.Log.Logger;
	
	import flash.display.LoaderInfo;
	
	public class ParHandler
	{
		// singleton
		private static var s_dsInstance:ParHandler;
		
		public static function get Instance():ParHandler
		{
			if (s_dsInstance == null)
			{
				s_dsInstance = new ParHandler();
			}
			
			return s_dsInstance;
		}
		
		// members
		private var m_oParameters:Object;
		private var m_loaderInfo:LoaderInfo;
		
		// class
		public function Init(p_oParameters:Object, p_loaderInfo:LoaderInfo):void
		{
			m_oParameters = p_oParameters;
			m_loaderInfo = p_loaderInfo;
			
			Logger.Instance.WriteInformation("SID:" + SID, "ParametersHandler:Init");
			Logger.Instance.WriteInformation("BLServer:" + BLServer, "ParametersHandler:Init");
			Logger.Instance.WriteInformation("Token:" + Token, "ParametersHandler:Init");
			Logger.Instance.WriteInformation("DetailsUidUrl:" + DetailsUidUrl, "ParametersHandler:Init");
			Logger.Instance.WriteInformation("InviteID:" + InviteID, "ParametersHandler:Init");
			Logger.Instance.WriteInformation("EMail:" + EMail, "ParametersHandler:Init");
			Logger.Instance.WriteInformation("SupportID:" + SupportID, "ParametersHandler:Init");
			Logger.Instance.WriteInformation("Locale:" + Locale, "ParametersHandler:Init");
		}
		
		// properties
		public function get SID():String
		{
			return Utils.AS3.ObjectUtil.GetStringValue(m_oParameters, "SID");
		}
		public function get IISServer():String
		{
			return Utils.AS3.ObjectUtil.GetStringValue(m_oParameters, "IISServer", "www.dp36524.com");
		}
		public function get BLServer():String
		{
			return Utils.AS3.ObjectUtil.GetStringValue(m_oParameters, "BLServer");
		}
		public function get Token():String
		{
			return Utils.AS3.ObjectUtil.GetStringValue(m_oParameters, "Token");
		}
		public function get DetailsUidUrl():String
		{
			return Utils.AS3.ObjectUtil.GetStringValue(m_oParameters, Const.DETAILS_UID_URL_KEY);
		}
		public function get InviteID():int
		{
			return Utils.AS3.ObjectUtil.GetIntValue(m_oParameters, Const.INVITE_ID_KEY);
		}
		public function get EMail():String
		{
			return Utils.AS3.ObjectUtil.GetStringValue(m_oParameters, Const.EMAIL_URL_KEY);
		}
		public function get SupportID():int
		{
			return Utils.AS3.ObjectUtil.GetIntValue(m_oParameters, Const.SUPPORT_ID_KEY);
		}
		public function get Locale():String
		{
			return Utils.AS3.ObjectUtil.GetStringValue(m_oParameters, "Locale", "en");
		}
	}
}