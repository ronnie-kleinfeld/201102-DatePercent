package Platform.Member
{
	import Data.MemberData;
	
	import flash.events.Event;
	
	public class MemberPopBoxEvent extends Event
	{
		public static const OPEN_MEMBER_POP_BOX:String = "OPEN_MEMBER_POP_BOX";
		
		private var m_memberData:MemberData;
		
		public function get Member():MemberData
		{
			return m_memberData;
		}
		
		public function MemberPopBoxEvent(type:String, p_memberData:MemberData, bubbles:Boolean=false, cancelable:Boolean=false)
		{
			super(type, bubbles, cancelable);
			m_memberData = p_memberData;
		}
		public function Dispose():void
		{
			m_memberData = null;
		}
	}
}