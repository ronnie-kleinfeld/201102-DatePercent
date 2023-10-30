package Data.Member
{
	import Data.Base.CollectionBase;
	import Data.Base.CollectionEvent;
	
	public class ActiveDataCollection extends CollectionBase
	{
		public function AddItemActiveData(p_activeData:ActiveData):void
		{
			var activeData:ActiveData = FindItemActiveDataByID(p_activeData.ID);
			if (activeData == null)
			{
				this.AddItem(p_activeData);
			}
			else
			{
				activeData.ACTION = p_activeData.ACTION;
				dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_ALLREADY_EXISTS, this, p_activeData));				
			}
		}
		public function AddItemActiveDataAt(p_activeData:ActiveData, p_iIndex:int):void
		{
			if (FindItemActiveDataByID(p_activeData.ID) == null)
			{
				this.AddItemAt(p_activeData, p_iIndex);
			}
			else
			{
				dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_ALLREADY_EXISTS, this, p_activeData));				
			}
		}
		
		public function RemoveItemActiveData(p_activeData:ActiveData):ActiveData
		{
			return ActiveData(this.RemoveItemAt(this.FindItemIndexByID(p_activeData.ID)));
		}
		public function RemoveItemActiveDataByID(p_iID:int):ActiveData
		{
			return ActiveData(this.RemoveItemAt(this.FindItemIndexByID(p_iID)));
		}
		
		public function FindItemActiveDataByID(p_iID:int):ActiveData
		{
			var activeData:ActiveData;
			for (var i:int = 0; i < this.Length; i++)
			{
				activeData = ActiveData(this.getItemAt(i));
				if (activeData.ID == p_iID)
				{
					return activeData;
				}
			}
			
			return null;
		}
		public function FindItemActiveDataByIndex(p_iIndex:int):ActiveData
		{
			return ActiveData(this.getItemAt(p_iIndex));
		}
	}
}