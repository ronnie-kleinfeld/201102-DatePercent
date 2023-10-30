package Data.Base
{
	import flash.events.Event;
	
	public class CollectionEvent extends Event
	{
		public static const OBJECT_ADDED:String = "OBJECT_ADDED";
		public static const OBJECT_ALLREADY_EXISTS:String = "OBJECT_ALLREADY_EXISTS";
		public static const OBJECT_REMOVE:String = "OBJECT_REMOVE";
		public static const OBJECT_REMOVED:String = "OBJECT_REMOVED";
		public static const COLLECTION_CHANGED:String = "COLLECTION_CHANGED";
		
		private var m_collectionBase:CollectionBase;
		private var m_objectBase:ObjectBase;
		private var m_iID:int;
		
		public function get CollectionData():CollectionBase
		{
			return m_collectionBase;
		}
		public function get ObjectData():ObjectBase
		{
			return m_objectBase;
		}
		public function get ID():int
		{
			return m_iID;
		}
		
		public function CollectionEvent(type:String, p_collectionBase:CollectionBase, p_objectBase:ObjectBase, p_iID:int=-1, bubbles:Boolean=false, cancelable:Boolean=false)
		{
			super(type, bubbles, cancelable);
			m_collectionBase = p_collectionBase;
			m_objectBase = p_objectBase;
			m_iID = p_iID;
		}
		public function Dispose():void
		{
			m_objectBase = null;
			m_collectionBase = null;
		}
	}
}