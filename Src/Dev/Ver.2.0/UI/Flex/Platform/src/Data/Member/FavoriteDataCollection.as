package Data.Member
{
	import Data.Base.CollectionBase;
	import Data.Base.CollectionEvent;
	
	import mx.collections.ArrayCollection;
	
	public class FavoriteDataCollection extends CollectionBase
	{
		public function AddItemFavoriteData(p_favoriteData:FavoriteData):void
		{
			if (FindItemFavoriteDataByID(p_favoriteData.ID) == null)
			{
				this.AddItem(p_favoriteData);
			}
			else
			{
				dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_ALLREADY_EXISTS, this, p_favoriteData));				
			}
		}
		public function AddItemFavoriteDataAt(p_favoriteData:FavoriteData, p_iIndex:int):void
		{
			if (FindItemFavoriteDataByID(p_favoriteData.ID) == null)
			{
				this.AddItemAt(p_favoriteData, p_iIndex);
			}
			else
			{
				dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_ALLREADY_EXISTS, this, p_favoriteData));				
			}
		}
		
		public function RemoveItemFavoriteData(p_favoriteData:FavoriteData):FavoriteData
		{
			return FavoriteData(this.RemoveItemAt(this.FindItemIndexByID(p_favoriteData.ID)));
		}
		public function RemoveItemFavoriteDataByID(p_iID:int):FavoriteData
		{
			return FavoriteData(this.RemoveItemAt(this.FindItemIndexByID(p_iID)));
		}
		
		public function FindItemFavoriteDataByID(p_iID:int):FavoriteData
		{
			var favoriteData:FavoriteData;
			for (var i:int = 0; i < this.Length; i++)
			{
				favoriteData = FavoriteData(this.getItemAt(i));
				if (favoriteData.ID == p_iID)
				{
					return favoriteData;
				}
			}
			
			return null;
		}
		public function FindItemFavoriteDataByIndex(p_iIndex:int):FavoriteData
		{
			return FavoriteData(this.getItemAt(p_iIndex));
		}
		public function Fill(p_ac:ArrayCollection):void
		{
			for (var i:int = 0; i < p_ac.length; i++)
			{
				var oFavorite:Object = p_ac.getItemAt(i);
				if (FindItemFavoriteDataByID(oFavorite.USV_FAVORITE_USER_ID) == null)
				{
					AddItemFavoriteData(new FavoriteData(oFavorite.USV_FAVORITE_USER_ID));
				}
			}
		}
	}
}