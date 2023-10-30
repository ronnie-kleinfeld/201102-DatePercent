package Data.Base
{
	import flash.events.Event;
	
	import mx.collections.ArrayCollection;
	
	[Event(name=CollectionEvent.OBJECT_ADDED, type=CollectionEvent)]
	[Event(name=CollectionEvent.OBJECT_ALLREADY_EXISTS, type=CollectionEvent)]
	[Event(name=CollectionEvent.OBJECT_REMOVE, type=CollectionEvent)]
	[Event(name=CollectionEvent.OBJECT_REMOVED, type=CollectionEvent)]
	public class CollectionBase extends ArrayCollection
	{
		public function CollectionBase()
		{
			super();
		}
		public function Dispose():void
		{
			while (this.Length > 0)
			{
				ObjectBase(RemoveItemAt(0)).Dispose();
			}
		}
		
		public function AddItem(p_objectBase:ObjectBase):void
		{
			this.addItem(p_objectBase);
			dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_ADDED, this, p_objectBase));
		}
		public function AddItemAt(p_objectBase:ObjectBase, p_iIndex:int):void
		{
			this.addItemAt(p_objectBase, p_iIndex);
			dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_ADDED, this, p_objectBase));
		}
		
		public function RemoveItem(p_objectBase:ObjectBase):ObjectBase
		{
			var objectBase:ObjectBase;
			
			try
			{
				dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_REMOVE, this, p_objectBase, p_objectBase.ID));
				this.removeItemAt(this.FindItemIndexByID(p_objectBase.ID));
				dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_REMOVED, this, p_objectBase));
				objectBase = p_objectBase;
			}
			catch (error:Error)
			{
				objectBase = null;
			}
			
			return objectBase;
		}
		public function RemoveItemAt(p_iIndex:int):ObjectBase
		{
			var objectBase:ObjectBase;
			
			try
			{
				objectBase = ObjectBase(this.FindItemByIndex(p_iIndex));
				dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_REMOVE, this, objectBase, objectBase.ID));
				objectBase = ObjectBase(this.removeItemAt(p_iIndex));
				dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_REMOVED, this, objectBase));
				return objectBase;
			}
			catch (error:Error)
			{
				objectBase = null;
			}
			
			return objectBase;
		}
		public function RemoveItemByID(p_iID:int):ObjectBase
		{
			var objectBase:ObjectBase;
			try
			{
				objectBase = ObjectBase(this.FindItemByID(p_iID));
				dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_REMOVE, this, objectBase, objectBase.ID));
				objectBase = ObjectBase(this.removeItemAt(this.FindItemIndexByID(p_iID)));
				dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_REMOVED, null, objectBase));
			}
			catch (error:Error)
			{
				objectBase = null;
			}
			return objectBase;
		}
		public function RemoveAll():void
		{
			var objectBase:ObjectBase;
			while (this.Length > 0)
			{
				objectBase = ObjectBase(this.getItemAt(0));
				dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_REMOVE, this, objectBase, objectBase.ID));
				removeItemAt(0);
				dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_REMOVED, this, objectBase));
			}
		}
		
		public function FindItemByID(p_iID:int):ObjectBase
		{
			var objectBase:ObjectBase;
			for (var i:int = 0; i < this.Length; i++)
			{
				objectBase = ObjectBase(this.getItemAt(i));
				if (objectBase.ID == p_iID)
				{
					return objectBase;
				}
			}
			
			return null;
		}
		public function FindItemIndexByID(p_iID:int):int
		{
			var objectBase:ObjectBase;
			for (var i:int = 0; i < this.Length; i++)
			{
				objectBase = ObjectBase(this.getItemAt(i));
				if (objectBase.ID == p_iID)
				{
					return i;
				}
			}
			
			return -1;
		}
		public function FindItemByIndex(p_iIndex:int):ObjectBase
		{
			return ObjectBase(this.getItemAt(p_iIndex));
		}
		
		public function get Length():int
		{
			return this.length;
		}
	}
}