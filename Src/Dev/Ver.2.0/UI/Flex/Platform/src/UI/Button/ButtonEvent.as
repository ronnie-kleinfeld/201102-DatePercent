package UI.Button
{
	import flash.events.Event;
	
	public class ButtonEvent extends Event
	{
		public static const CLICKED:String = "CLICKED";
		
		private var m_button:ButtonBase;
		
		public function get GetButton():ButtonBase
		{
			return m_button;
		}
		
		public function ButtonEvent(type:String, p_button:ButtonBase, bubbles:Boolean=false, cancelable:Boolean=false)
		{
			super(type, bubbles, cancelable);
			m_button = p_button;
		}
		public function Dispose():void
		{
			m_button = null;
		}
	}
}