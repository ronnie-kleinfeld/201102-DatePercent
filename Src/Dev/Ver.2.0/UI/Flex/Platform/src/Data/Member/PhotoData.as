package Data.Member
{
	import Data.Base.ObjectBase;
	
	import Handler.ParHandler;
	
	import Utils.AS3.Const;
	
	public class PhotoData extends ObjectBase
	{
		private var m_strFBPid:String;
		[Bindable] public var Url:String;
		[Bindable] public var UrlX:String;
		
		public function get FBPid():String
		{
			return m_strFBPid;
		}
		
		public function PhotoData(p_iID:int, p_strFBPid:String, p_strUrl:String, p_strUrlX:String)
		{
			super(p_iID);
			
			m_strFBPid = p_strFBPid;
			if (p_strUrl == "")
			{
				Url = "http://" + ParHandler.Instance.IISServer + Const.NO_IMAGE_RELATIVE_PATH;
			}
			else
			{
				Url = p_strUrl;
			}
			if (p_strUrlX == "")
			{
				UrlX = p_strUrl;
			}
			else
			{
				UrlX = p_strUrlX;
			}
		}
	}
}