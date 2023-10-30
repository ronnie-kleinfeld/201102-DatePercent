package Data.Member
{
	import Data.Base.ObjectBase;
	
	public class FriendData extends ObjectBase
	{
		private var m_strFBUid:String;
		private var m_photoData:PhotoData;
		private var m_iSexCode:int = 1;
		private var m_bIsMutualFriends:Boolean;
		
		public function get FBUid():String
		{
			return m_strFBUid;
		}
		public function get Photo():PhotoData
		{
			return m_photoData;
		}
		public function get SexCode():int
		{
			return m_iSexCode;
		}
		public function get SexLabel():String
		{
			var strResult:String;
			
			switch (m_iSexCode)
			{
				case 1:
					strResult = "Male";
					break;
				case 2:
					strResult = "Female";
					break;
			}
			
			return strResult;
		}
		public function get IsMutualFriends():Boolean
		{
			return m_bIsMutualFriends;
		}
		
		public function FriendData(p_iID:int, p_strFBUid:String, p_photoData:PhotoData, p_iSexCode:int, p_bIsMutualFriends:Boolean)
		{
			super(p_iID);
			
			m_strFBUid = p_strFBUid;
			m_photoData = p_photoData;
			m_iSexCode = p_iSexCode;
			m_bIsMutualFriends = p_bIsMutualFriends;
		}
		public override function Dispose():void
		{
			super.Dispose();
			
			if (m_photoData != null)
			{
				m_photoData.Dispose();
				m_photoData = null;
			}
		}
	}
}