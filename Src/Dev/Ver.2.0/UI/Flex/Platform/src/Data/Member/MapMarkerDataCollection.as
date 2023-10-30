package Data.Member
{
	import Data.Base.CollectionBase;
	import Data.Base.CollectionEvent;
	
	import mx.collections.ArrayCollection;
	
	public class MapMarkerDataCollection extends CollectionBase
	{
		public function AddItemMapMarkerData(p_mapMarkerData:MapMarkerData):void
		{
			if (FindItemMapMarkerDataByID(p_mapMarkerData.ID) == null)
			{
				this.AddItem(p_mapMarkerData);
			}
			else
			{
				dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_ALLREADY_EXISTS, this, p_mapMarkerData));				
			}
		}
		public function AddItemMapMarkerDataAt(p_mapMarkerData:MapMarkerData, p_iIndex:int):void
		{
			if (FindItemMapMarkerDataByID(p_mapMarkerData.ID) == null)
			{
				this.AddItemAt(p_mapMarkerData, p_iIndex);
			}
			else
			{
				dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_ALLREADY_EXISTS, this, p_mapMarkerData));				
			}
		}
		
		public function RemoveItemMapMarkerData(p_mapMarkerData:MapMarkerData):MapMarkerData
		{
			return MapMarkerData(this.RemoveItemAt(this.FindItemIndexByID(p_mapMarkerData.ID)));
		}
		public function RemoveItemMapMarkerDataByID(p_iID:int):MapMarkerData
		{
			return MapMarkerData(this.RemoveItemAt(this.FindItemIndexByID(p_iID)));
		}
		
		public function FindItemMapMarkerDataByID(p_iID:int):MapMarkerData
		{
			var mapMarkerData:MapMarkerData;
			for (var i:int = 0; i < this.Length; i++)
			{
				mapMarkerData = MapMarkerData(this.getItemAt(i));
				if (mapMarkerData.ID == p_iID)
				{
					return mapMarkerData;
				}
			}
			
			return null;
		}
		public function FindItemMapMarkerDataByIndex(p_iIndex:int):MapMarkerData
		{
			return MapMarkerData(this.getItemAt(p_iIndex));
		}
		
		public function FillNewMembers(p_ac:ArrayCollection):void
		{
			for (var i:int = 0; i < p_ac.length; i++)
			{
				var oUser:Object = p_ac.getItemAt(i);
				if (FindItemMapMarkerDataByID(oUser.USR_ID) == null)
				{
					AddItemMapMarkerData(new MapMarkerData(oUser.USR_ID));
				}
			}
		}
	}
}