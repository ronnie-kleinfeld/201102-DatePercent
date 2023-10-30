package UI.Box.MessageBox
{
	import flash.events.Event;
	
	public class MessageBoxEvent extends Event
	{
		private var m_funcPostMessageBox:Function;
		private var m_bDontAsk:Boolean;
		
		public function get PostMessageBox():Function
		{
			return m_funcPostMessageBox;
		}
		public function get DontAsk():Boolean
		{
			return m_bDontAsk;
		}
		
		public function MessageBoxEvent(type:String, p_funcPostMessageBox:Function, p_bDontAsk:Boolean, bubbles:Boolean=false, cancelable:Boolean=false)
		{
			super(type, bubbles, cancelable);
			m_funcPostMessageBox = p_funcPostMessageBox;
			m_bDontAsk = p_bDontAsk;
		}
		public function Dispose():void
		{
			m_funcPostMessageBox = null;
		}
	}
}