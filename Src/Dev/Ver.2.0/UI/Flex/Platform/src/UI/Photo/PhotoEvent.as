package UI.Photo
{
	import flash.events.Event;
	
	public class PhotoEvent extends Event
	{
		public static const CLICKED:String = "CLICKED";
		public static const REMOVE_CLICKED:String = "REMOVE_CLICKED";
		
		private var m_photoBase:PhotoBase;
		
		public function get PhotoUI():PhotoBase
		{
			return m_photoBase;
		}
		
		public function PhotoEvent(type:String, p_photoBase:PhotoBase, bubbles:Boolean=false, cancelable:Boolean=false)
		{
			super(type, bubbles, cancelable);
			m_photoBase = p_photoBase;
		}
		public function Dispose():void
		{
			m_photoBase = null;
		}
	}
}