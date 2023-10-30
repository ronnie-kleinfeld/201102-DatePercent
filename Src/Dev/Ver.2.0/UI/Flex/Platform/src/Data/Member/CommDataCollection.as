package Data.Member
{
	import Data.Base.CollectionBase;
	
	import mx.collections.ArrayCollection;
	
	public class CommDataCollection extends CollectionBase
	{
		public function AddItemCommData(p_commData:CommData):void
		{
			this.AddItem(p_commData);
		}
		public function AddItemCommDataAt(p_commData:CommData, p_iIndex:int):void
		{
			this.AddItemAt(p_commData, p_iIndex);
		}
		
		public function RemoveItemCommData(p_commData:CommData):CommData
		{
			return CommData(this.RemoveItemAt(this.FindItemIndexByID(p_commData.ID)));
		}
		public function RemoveItemCommDataByID(p_iID:int):CommData
		{
			return CommData(this.RemoveItemAt(this.FindItemIndexByID(p_iID)));
		}
		
		public function FindItemCommDataByID(p_iID:int):CommData
		{
			var commData:CommData;
			for (var i:int = 0; i < this.Length; i++)
			{
				commData = CommData(this.getItemAt(i));
				if (commData.ID == p_iID)
				{
					return commData;
				}
			}
			
			return null;
		}
		public function FindItemCommDataByIndex(p_iIndex:int):CommData
		{
			return CommData(this.getItemAt(p_iIndex));
		}
	}
}