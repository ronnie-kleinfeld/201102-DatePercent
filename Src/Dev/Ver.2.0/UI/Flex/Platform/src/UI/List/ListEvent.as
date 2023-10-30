package UI.List
{
	import flash.events.Event;
	
	public class ListEvent extends Event
	{
		public static const FILL_TIMER_FILLED:String = "FILL_TIMER_FILLED";
		public static const DO_FILL_STEP_FILLED:String = "DO_FILL_STEP_FILLED";
		
		private var m_list:ListBase;
		
		public function get List():ListBase
		{
			return m_list;
		}
		
		public function ListEvent(type:String, p_list:ListBase, bubbles:Boolean=false, cancelable:Boolean=false)
		{
			super(type, bubbles, cancelable);
			m_list = p_list;
		}
		public function Dispose():void
		{
			m_list = null;
		}
	}
}