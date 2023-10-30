package Data.Member
{
	import Data.Base.CollectionBase;
	import Data.Base.CollectionEvent;
	
	import mx.collections.ArrayCollection;
	
	public class BreakingNewsDataCollection extends CollectionBase
	{
		public function AddItemBreakingNewsData(p_breakingNewsData:BreakingNewsData):void
		{
			if (FindItemBreakingNewsDataByID(p_breakingNewsData.ID) == null)
			{
				this.AddItem(p_breakingNewsData);
			}
			else
			{
				dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_ALLREADY_EXISTS, this, p_breakingNewsData));				
			}
		}
		public function AddItemBreakingNewsDataAt(p_breakingNewsData:BreakingNewsData, p_iIndex:int):void
		{
			if (FindItemBreakingNewsDataByID(p_breakingNewsData.ID) == null)
			{
				this.AddItemAt(p_breakingNewsData, p_iIndex);
			}
			else
			{
				dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_ALLREADY_EXISTS, this, p_breakingNewsData));				
			}
		}
		
		public function RemoveItemBreakingNewsData(p_breakingNewsData:BreakingNewsData):BreakingNewsData
		{
			return BreakingNewsData(this.RemoveItemAt(this.FindItemIndexByID(p_breakingNewsData.ID)));
		}
		public function RemoveItemBreakingNewsDataByID(p_iID:int):BreakingNewsData
		{
			return BreakingNewsData(this.RemoveItemAt(this.FindItemIndexByID(p_iID)));
		}
		
		public function FindItemBreakingNewsDataByID(p_iID:int):BreakingNewsData
		{
			var breakingNewsData:BreakingNewsData;
			for (var i:int = 0; i < this.Length; i++)
			{
				breakingNewsData = BreakingNewsData(this.getItemAt(i));
				if (breakingNewsData.ID == p_iID)
				{
					return breakingNewsData;
				}
			}
			
			return null;
		}
		public function FindItemBreakingNewsDataByIndex(p_iIndex:int):BreakingNewsData
		{
			return BreakingNewsData(this.getItemAt(p_iIndex));
		}
		
		public function Fill(p_ac:ArrayCollection):void
		{
			for (var i:int = 0; i < p_ac.length; i++)
			{
				var oUser:Object = p_ac.getItemAt(i);
				if (FindItemBreakingNewsDataByID(oUser.USR_ID) == null)
				{
					AddItemBreakingNewsData(new BreakingNewsData(oUser.USR_ID));
				}
			}
		}
	}
}