package Data.Member
{
	import Data.Base.ObjectBase;
	import Data.MemberData;
	
	import Handler.SesHandler;
	
	public class ActiveData extends ObjectBase
	{
		public static const Null:String = "Null";
		public static const MEMBER_CHAT:String = "MEMBER_CHAT";
		public static const MEMBER_DETAILS:String = "MEMBER_DETAILS";
		public static const SEND_PRESENT:String = "SEND_PRESENT";
		public static const SEND_WINK:String = "SEND_WINK";
			
		public var ACTION:String;
		
		public function get Member():MemberData
		{
			return SesHandler.Instance.Session.Members.FindItemMemberDataByID(this.ID);
		}
		
		public function ActiveData(p_iID:int, p_strACTION:String)
		{
			super(p_iID);
			
			ACTION = p_strACTION;
		}
	}
}