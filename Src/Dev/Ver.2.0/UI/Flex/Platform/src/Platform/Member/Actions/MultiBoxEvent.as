package Platform.Member.Actions
{
	import flash.events.Event;
	
	public class MultiBoxEvent extends Event
	{
		private var m_strActionName:String;
		
		public function get ActionName():String
		{
			return m_strActionName;
		}
		
		public function MultiBoxEvent(type:String, p_strActionName:String, bubbles:Boolean=false, cancelable:Boolean=false)
		{
			super(type, bubbles, cancelable);
			m_strActionName = p_strActionName;
		}
	}
}