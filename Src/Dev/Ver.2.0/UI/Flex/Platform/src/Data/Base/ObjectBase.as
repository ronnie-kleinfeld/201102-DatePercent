package Data.Base
{
	import flash.events.EventDispatcher;
	
	public class ObjectBase extends EventDispatcher
	{
		[Bindable] public var ID:int;
		
		public function ObjectBase(p_iID:int)
		{
			ID = p_iID;
		}
		public function Dispose():void
		{
		}
	}
}