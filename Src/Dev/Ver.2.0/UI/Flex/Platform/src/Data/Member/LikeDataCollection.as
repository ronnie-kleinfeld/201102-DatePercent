package Data.Member
{
	import Data.Base.CollectionBase;
	
	import mx.collections.ArrayCollection;
	
	public class LikeDataCollection extends CollectionBase
	{
		public function AddItemLikeData(p_likeData:LikeData):void
		{
			this.AddItem(p_likeData);
		}
		public function AddItemLikeDataAt(p_likeData:LikeData, p_iIndex:int):void
		{
			this.AddItemAt(p_likeData, p_iIndex);
		}
		
		public function RemoveItemLikeData(p_likeData:LikeData):LikeData
		{
			return LikeData(this.RemoveItemAt(this.FindItemIndexByID(p_likeData.ID)));
		}
		public function RemoveItemLikeDataByID(p_iID:int):LikeData
		{
			return LikeData(this.RemoveItemAt(this.FindItemIndexByID(p_iID)));
		}
		
		public function FindItemLikeDataByID(p_iID:int):LikeData
		{
			var likeData:LikeData;
			for (var i:int = 0; i < this.Length; i++)
			{
				likeData = LikeData(this.getItemAt(i));
				if (likeData.ID == p_iID)
				{
					return likeData;
				}
			}
			
			return null;
		}
		public function FindItemLikeDataByObjectID(p_strObjectID:String):LikeData
		{
			var likeData:LikeData;
			for (var i:int = 0; i < this.Length; i++)
			{
				likeData = LikeData(this.getItemAt(i));
				if (likeData.ObjectID == p_strObjectID)
				{
					return likeData;
				}
			}
			
			return null;
		}
		public function FindItemLikeDataByIndex(p_iIndex:int):LikeData
		{
			return LikeData(this.getItemAt(p_iIndex));
		}
		public function Fill(p_ac:ArrayCollection):void
		{
			for (var i:int = 0; i < p_ac.length; i++)
			{
				var oLike:Object = p_ac.getItemAt(i);
				if (FindItemLikeDataByID(oLike.USK_ID) == null)
				{
					AddItemLikeData(new LikeData(oLike.USK_ID, oLike.USK_FB_OBJECT_ID, oLike.USK_FB_NAME, new PhotoData(-1, "", oLike.USK_FB_PIC_URL, oLike.USK_FB_PICX_URL), false));
				}
			}
		}
		public function get CommonLength():int
		{
			var iResult:int = 0;
			
			for (var i:int = 0; i < this.length; i++)
			{
				var likeData:LikeData = LikeData(this.getItemAt(i));
				if (likeData.IsLikesInCommon)
				{
					iResult++;
				}
			}
			
			return iResult;
		}
	}
}