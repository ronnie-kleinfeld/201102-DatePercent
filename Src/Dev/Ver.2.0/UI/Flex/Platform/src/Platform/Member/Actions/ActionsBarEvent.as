package Platform.Member.Actions
{
	import flash.events.Event;
	
	public class ActionsBarEvent extends Event
	{
		public static const DO_ACTION:String = "DO_ACTION";
		
		private var m_strActionName:String;
		private var m_bOpenMultiBox:Boolean;
		private var m_numMultiBoxWidth:Number;
		
		public function get ActionName():String
		{
			return m_strActionName;
		}
		public function get OpenMultiBox():Boolean
		{
			return m_bOpenMultiBox;
		}
		public function get MultiBoxWidth():Number
		{
			return m_numMultiBoxWidth;
		}
		
		public function ActionsBarEvent(type:String, p_strActionName:String, p_bOpenMultiBox:Boolean, p_numMultiBoxWidth:Number, bubbles:Boolean=false, cancelable:Boolean=false)
		{
			super(type, bubbles, cancelable);
			m_strActionName = p_strActionName;
			m_bOpenMultiBox = p_bOpenMultiBox;
			m_numMultiBoxWidth = p_numMultiBoxWidth;
		}
	}
}