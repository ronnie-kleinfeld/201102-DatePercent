package Data.Member
{
	import Data.Base.CollectionBase;
	
	import mx.collections.ArrayCollection;
	
	public class InboxDataCollection extends CollectionBase
	{
		public function AddItemInboxData(p_inboxData:InboxData):void
		{
			this.AddItem(p_inboxData);
		}
		public function AddItemInboxDataAt(p_inboxData:InboxData, p_iIndex:int):void
		{
			this.AddItemAt(p_inboxData, p_iIndex);
		}
		
		public function RemoveItemInboxData(p_inboxData:InboxData):InboxData
		{
			return InboxData(this.RemoveItemAt(this.FindItemIndexByID(p_inboxData.ID)));
		}
		public function RemoveItemInboxDataByID(p_iID:int):InboxData
		{
			return InboxData(this.RemoveItemAt(this.FindItemIndexByID(p_iID)));
		}
		public function RemoveItemInboxDataByMemberID(p_iMemberID:int):InboxData
		{
			return InboxData(this.RemoveItem(this.FindItemInboxDataByMemberID(p_iMemberID)));
		}
		
		public function FindItemInboxDataByID(p_iID:int):InboxData
		{
			var inboxData:InboxData;
			for (var i:int = 0; i < this.Length; i++)
			{
				inboxData = InboxData(this.getItemAt(i));
				if (inboxData.ID == p_iID)
				{
					return inboxData;
				}
			}
			
			return null;
		}
		public function FindItemInboxDataByMemberID(p_iMemberID:int):InboxData
		{
			var inboxData:InboxData;
			for (var i:int = 0; i < this.Length; i++)
			{
				inboxData = InboxData(this.getItemAt(i));
				if (inboxData.MemberID == p_iMemberID)
				{
					return inboxData;
				}
			}
			
			return null;
		}
		public function FindItemInboxDataByIndex(p_iIndex:int):InboxData
		{
			return InboxData(this.getItemAt(p_iIndex));
		}
		
		public function get UniqueLengthByMemberID():int
		{
			var ac:ArrayCollection = new ArrayCollection();
			
			var iMemberID:int;
			for (var i:int = 0; i < this.Length; i++)
			{
				iMemberID = this.FindItemInboxDataByIndex(i).MemberID;
				if (ac.getItemIndex(iMemberID) == -1)
				{
					ac.addItem(iMemberID);
				}
			}
			
			return ac.length;
		}
		
		public function Fill(p_ac:ArrayCollection):void
		{
			for (var i:int = 0; i < p_ac.length; i++)
			{
				var oInboxData:Object = p_ac.getItemAt(i);
				if (FindItemInboxDataByID(oInboxData.USI_ID) == null)
				{
					AddItemInboxData(new InboxData(
						oInboxData.USI_ID,
						oInboxData.USI_SENDER_USER_ID,
						oInboxData.USI_COMM_TYPE_CODE,
						oInboxData.USI_TEXT,
						oInboxData.USI_WINK_CODE,
						oInboxData.USI_PRESENT_CODE));
				}
			}
		}
	}
}