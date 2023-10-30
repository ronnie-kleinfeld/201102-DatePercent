package Platform.Map.MemberMarker
{
	import flash.events.Event;
	import flash.events.MouseEvent;
	
	public class MemberMarkerEvent extends Event
	{
		public static const ITEM_ROLL_OVER:String = "ITEM_ROLL_OVER";
		public static const CLICK:String = "CLICK";
		
		private var m_memberMarker:MemberMarker;
		private var m_event:MouseEvent;
		
		public function get GetMemberMarker():MemberMarker
		{
			return m_memberMarker;
		}
		public function get GetMouseEvent():MouseEvent
		{
			return m_event;
		}
		
		public function MemberMarkerEvent(type:String, p_memberMarker:MemberMarker, p_event:MouseEvent, bubbles:Boolean=false, cancelable:Boolean=false)
		{
			super(type, bubbles, cancelable);
			m_memberMarker = p_memberMarker;
			m_event = p_event;
		}
		public function Dispose():void
		{
			m_event = null;
			m_memberMarker = null;
		}
	}
}