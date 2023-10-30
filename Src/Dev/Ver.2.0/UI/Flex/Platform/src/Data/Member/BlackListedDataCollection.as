package Data.Member
{
	import Data.Base.CollectionBase;
	import Data.Base.CollectionEvent;
	import Data.MemberData;
	
	import Handler.SesHandler;
	
	import mx.collections.ArrayCollection;
	
	public class BlackListedDataCollection extends CollectionBase
	{
		public function AddItemBlackListedData(p_blackListedData:BlackListedData):void
		{
			if (FindItemBlackListedDataByID(p_blackListedData.ID) == null)
			{
				this.AddItem(p_blackListedData);
				RemoveMemberFromSession(p_blackListedData.Member);
			}
			else
			{
				dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_ALLREADY_EXISTS, this, p_blackListedData));				
			}
		}
		public function AddItemBlackListedDataAt(p_blackListedData:BlackListedData, p_iIndex:int):void
		{
			if (FindItemBlackListedDataByID(p_blackListedData.ID) == null)
			{
				this.AddItemAt(p_blackListedData, p_iIndex);
				RemoveMemberFromSession(p_blackListedData.Member);
			}
			else
			{
				dispatchEvent(new CollectionEvent(CollectionEvent.OBJECT_ALLREADY_EXISTS, this, p_blackListedData));				
			}
		}
		private function RemoveMemberFromSession(p_memberData:MemberData):void
		{
			try
			{
				var iMemberID:int = p_memberData.ID;
				SesHandler.Instance.Session.Inboxes.RemoveItemByID(iMemberID);
				SesHandler.Instance.Session.BreakingNews.RemoveItemByID(iMemberID);
				SesHandler.Instance.Session.MapMarkers.RemoveItemByID(iMemberID);
				SesHandler.Instance.Session.Actives.RemoveItemByID(iMemberID);
				SesHandler.Instance.Session.Favorites.RemoveItemByID(iMemberID);
			}
			catch (error:Error)
			{
			}
		}
		
		public function RemoveItemBlackListedData(p_o:BlackListedData):BlackListedData
		{
			return BlackListedData(this.RemoveItemAt(this.FindItemIndexByID(p_o.ID)));
		}
		public function RemoveItemBlackListedDataByID(p_iID:int):BlackListedData
		{
			return BlackListedData(this.RemoveItemAt(this.FindItemIndexByID(p_iID)));
		}
		
		public function FindItemBlackListedDataByID(p_iID:int):BlackListedData
		{
			var blackListedData:BlackListedData;
			for (var i:int = 0; i < this.Length; i++)
			{
				blackListedData = BlackListedData(this.getItemAt(i));
				if (blackListedData.ID == p_iID)
				{
					return blackListedData;
				}
			}
			
			return null;
		}
		public function FindItemBlackListedDataByIndex(p_iIndex:int):BlackListedData
		{
			return BlackListedData(this.getItemAt(p_iIndex));
		}
		public function Fill(p_ac:ArrayCollection):void
		{
			for (var i:int = 0; i < p_ac.length; i++)
			{
				var oBlackList:Object = p_ac.getItemAt(i);
				if (FindItemBlackListedDataByID(oBlackList.USB_BLACK_LIST_USER_ID) == null)
				{
					AddItemBlackListedData(new BlackListedData(oBlackList.USB_BLACK_LIST_USER_ID));
				}
			}
		}
	}
}