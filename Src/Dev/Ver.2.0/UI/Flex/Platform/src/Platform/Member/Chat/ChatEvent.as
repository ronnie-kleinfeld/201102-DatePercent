package Platform.Member.Chat
{
	import flash.events.Event;
	
	public class ChatEvent extends Event
	{
		public static const TEXT_ADD:String = "TEXT_ADD";
		
		public function ChatEvent(type:String, bubbles:Boolean=false, cancelable:Boolean=false)
		{
			super(type, bubbles, cancelable);
		}
	}
}