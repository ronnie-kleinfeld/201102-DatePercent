package Platform.Location
{
	import flash.events.Event;
	
	public class LocationEvent extends Event
	{
		public static const FIND_LOCATION:String = "FIND_LOCATION";
		public static const CURRENT_LOCATION:String = "CURRENT_LOCATION";
		
		private var m_strLocation:String;
		
		public function get Location():String
		{
			return m_strLocation;
		}
		
		public function LocationEvent(type:String, p_strLocation:String, bubbles:Boolean=false, cancelable:Boolean=false)
		{
			super(type, bubbles, cancelable);
			m_strLocation = p_strLocation;
		}
	}
}