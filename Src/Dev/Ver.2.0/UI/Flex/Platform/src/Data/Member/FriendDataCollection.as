package Data.Member
{
	import Data.Base.CollectionBase;
	
	import mx.collections.ArrayCollection;
	
	public class FriendDataCollection extends CollectionBase
	{
		public function AddItemFriendData(p_friendData:FriendData):void
		{
			this.AddItem(p_friendData);
		}
		public function AddItemFriendDataAt(p_friendData:FriendData, p_iIndex:int):void
		{
			this.AddItemAt(p_friendData, p_iIndex);
		}
		
		public function RemoveItemFriendData(p_friendData:FriendData):FriendData
		{
			return FriendData(this.RemoveItemAt(this.FindItemIndexByID(p_friendData.ID)));
		}
		public function RemoveItemFriendDataByID(p_iID:int):FriendData
		{
			return FriendData(this.RemoveItemAt(this.FindItemIndexByID(p_iID)));
		}
		
		public function FindItemFriendDataByID(p_iID:int):FriendData
		{
			var friendData:FriendData;
			for (var i:int = 0; i < this.Length; i++)
			{
				friendData = FriendData(this.getItemAt(i));
				if (friendData.ID == p_iID)
				{
					return friendData;
				}
			}
			
			return null;
		}
		public function FindItemFriendDataByFBUid(p_strFBUid:String):FriendData
		{
			var friendData:FriendData;
			for (var i:int = 0; i < this.Length; i++)
			{
				friendData = FriendData(this.getItemAt(i));
				if (friendData.FBUid == p_strFBUid)
				{
					return friendData;
				}
			}
			
			return null;
		}
		public function FindItemFriendDataByIndex(p_iIndex:int):FriendData
		{
			return FriendData(this.getItemAt(p_iIndex));
		}
		
		public function Fill(p_ac:ArrayCollection):void
		{
			for (var i:int = 0; i < p_ac.length; i++)
			{
				var oFriend:Object = p_ac.getItemAt(i);
				if (FindItemFriendDataByID(oFriend.USF_ID) == null)
				{
					AddItemFriendData(new FriendData(
						oFriend.USF_ID,
						oFriend.USR_FB_UID,
						new PhotoData(-1, "", oFriend.USR_FB_PIC_URL, oFriend.USR_FB_PICX_URL),
						oFriend.USR_SEX_CODE,
						false));
				}
			}
		}
		public function get CommonLength():int
		{
			var iResult:int = 0;
			
			for (var i:int = 0; i < this.length; i++)
			{
				var friendData:FriendData = FriendData(this.getItemAt(i));
				if (friendData.IsMutualFriends)
				{
					iResult++;
				}
			}
			
			return iResult;
		}
	}
}