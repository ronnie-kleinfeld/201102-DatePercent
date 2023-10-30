package Data.Base
{
	import flash.events.Event;
	
	public class ObjectEvent extends Event
	{
		public static const ZOOM_LEVEL_CHANGED:String = "ZOOM_LEVEL_CHANGED";
		
		private var m_objectBase:ObjectBase;
		
		public function get ObjectData():ObjectBase
		{
			return m_objectBase;
		}
		
		public function ObjectEvent(type:String, p_objectBase:ObjectBase, bubbles:Boolean=false, cancelable:Boolean=false)
		{
			super(type, bubbles, cancelable);
			m_objectBase = p_objectBase;
		}
		public function Dispose():void
		{
			m_objectBase = null;
		}
	}
}