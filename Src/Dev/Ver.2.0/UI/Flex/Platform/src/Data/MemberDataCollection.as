package Data
{
	import Data.Base.CollectionBase;
	import Data.Member.CommData;
	import Data.Member.FriendData;
	import Data.Member.LikeData;
	import Data.Member.PhotoData;
	
	import Handler.SesHandler;
	
	import Utils.Log.Logger;
	
	import flash.utils.getQualifiedClassName;
	
	import mx.collections.ArrayCollection;
	
	public class MemberDataCollection extends CollectionBase
	{
		public function AddItemMemberData(p_memberData:MemberData):void
		{
			this.AddItem(p_memberData);
		}
		public function AddItemMemberDataAt(p_memberData:MemberData, p_iIndex:int):void
		{
			this.AddItemAt(p_memberData, p_iIndex);
		}
		
		public function RemoveItemMemberData(p_memberData:MemberData):MemberData
		{
			return MemberData(this.RemoveItemAt(this.FindItemIndexByID(p_memberData.ID)));
		}
		public function RemoveItemMemberDataByID(p_iID:int):MemberData
		{
			return MemberData(this.RemoveItemAt(this.FindItemIndexByID(p_iID)));
		}
		
		public function FindItemMemberDataByID(p_iID:int):MemberData
		{
			var memberData:MemberData;
			for (var i:int = 0; i < this.Length; i++)
			{
				memberData = MemberData(this.getItemAt(i));
				if (memberData.ID == p_iID)
				{
					return memberData;
				}
			}
			
			return null;
		}
		public function FindItemMemberDataByIndex(p_iIndex:int):MemberData
		{
			return MemberData(this.getItemAt(p_iIndex));
		}
		
		public function Fill(p_ac:ArrayCollection):void
		{
			var oUser:Object;
			var memberData:MemberData;
			for (var i:int = 0; i < p_ac.length; i++)
			{
				oUser = p_ac.getItemAt(i);
				memberData = FindItemMemberDataByID(oUser.USR_ID);
				
				if (memberData == null)
				{
					memberData = new MemberData(oUser.USR_ID, false);
					memberData.FillMember(oUser);
					AddItemMemberData(memberData);
				}
			}
		}
		public function FillMultipleMembersPhotos(p_ac:ArrayCollection):void
		{
			var oPhoto:Object;
			var memberData:MemberData;
			for (var i:int = 0; i < p_ac.length; i++)
			{
				oPhoto = p_ac.getItemAt(i);
				memberData = FindItemMemberDataByID(oPhoto.USP_USER_ID);
				
				if (memberData == null)
				{
					Logger.Instance.WriteCritical("Photo ID:" + oPhoto.USP_ID + " with no Member", "", flash.utils.getQualifiedClassName(this));
				}
				else
				{
					memberData.Photos.AddItemPhotoData(new PhotoData(
						oPhoto.USP_ID,
						oPhoto.USP_FB_PID,
						oPhoto.USP_FB_PIC_URL,
						oPhoto.USP_FB_PIC_URL));
				}
			}
		}
		public function FillMultipleMembersLikes(p_ac:ArrayCollection):void
		{
			var oLike:Object;
			var memberData:MemberData;
			for (var i:int = 0; i < p_ac.length; i++)
			{
				oLike = p_ac.getItemAt(i);
				memberData = FindItemMemberDataByID(oLike.USK_USER_ID);
				
				if (memberData == null)
				{
					Logger.Instance.WriteCritical("Like ID:" + oLike.USK_ID + " with no Member", "", flash.utils.getQualifiedClassName(this));
				}
				else
				{
					memberData.Likes.AddItemLikeData(new LikeData(
						oLike.USK_ID,
						oLike.USK_FB_OBJECT_ID,
						oLike.USK_FB_NAME,
						new PhotoData(-1, "", oLike.USK_FB_PIC_URL, oLike.USK_FB_PICX_URL),
						SesHandler.Instance.Session.Me.Likes.FindItemLikeDataByObjectID(oLike.USK_FB_OBJECT_ID) != null));
				}
			}
		}
		public function FillMultipleMembersFriends(p_ac:ArrayCollection):void
		{
			var oFriend:Object;
			var memberData:MemberData;
			for (var i:int = 0; i < p_ac.length; i++)
			{
				oFriend = p_ac.getItemAt(i);
				memberData = FindItemMemberDataByID(oFriend.USF_USER_ID);
				
				if (memberData == null)
				{
					Logger.Instance.WriteCritical("Friend ID:" + oFriend.USF_ID + " with no Member", "", flash.utils.getQualifiedClassName(this));
				}
				else
				{
					memberData.Friends.AddItemFriendData(new FriendData(
						oFriend.USF_ID,
						oFriend.USR_FB_UID,
						new PhotoData(-1, "", oFriend.USR_FB_PIC_URL, oFriend.USR_FB_PICX_URL),
						oFriend.USR_SEX_CODE,
						SesHandler.Instance.Session.Me.Friends.FindItemFriendDataByID(oFriend.USR_FB_UID) != null));
				}
			}
		}
		public function FillMultipleMembersComms(p_ac:ArrayCollection):void
		{
			var oComm:Object;
			var memberData:MemberData;
			for (var i:int = 0; i < p_ac.length; i++)
			{
				oComm = p_ac.getItemAt(i);
				if (oComm.USC_SENDER_USER_ID == SesHandler.Instance.Session.Me.ID)
				{
					memberData = FindItemMemberDataByID(oComm.USC_GETTER_USER_ID);
				}
				else 
				{
					memberData = FindItemMemberDataByID(oComm.USC_SENDER_USER_ID);
				}
				if (memberData == null)
				{
					Logger.Instance.WriteCritical("oComm ID:" + oComm.USC_ID + " with no Member", "", flash.utils.getQualifiedClassName(this));
				}
				else
				{
					if (memberData.Comms.FindItemCommDataByID(oComm.USC_ID) == null)
					{
						memberData.Comms.AddItemCommData(new CommData(
							oComm.USC_ID,
							oComm.USC_SENDER_USER_ID,
							oComm.USC_GETTER_USER_ID,
							oComm.USC_COMM_TYPE_CODE,
							oComm.USC_SENT_DATETIME,
							oComm.USC_TEXT,
							oComm.USC_WINK_CODE,
							oComm.USC_PRESENT_CODE,
							oComm.USC_IS_READ));	
					}
				}
			}
			
			CalculateCommCounts();
		}
		
		public function CalculateDatePercentage():void
		{
			var numHighDatePercentage:Number = 0;
			
			var numDatePercentage:Number = 0;
			var i:int;
			for (i = 0; i < this.Length; i++)
			{
				numDatePercentage = MemberData(this.getItemAt(i)).CalculateDatePercentage();
				if (numDatePercentage > numHighDatePercentage)
				{
					numHighDatePercentage = numDatePercentage;
				}
			}
			
			for (i = 0; i < this.Length; i++)
			{
				MemberData(this.getItemAt(i)).CalculateDatePercentageFactor(100 / numHighDatePercentage);
			}
		}
		
		public function CalculateCommCounts():void
		{
			for (var i:int = 0; i < this.Length; i++)
			{
				MemberData(this.getItemAt(i)).CalculateCommCounts();
			}
		}
		
		public function DoUpdateAllMembersLikesInCommon():void
		{
			for (var i:int = 0; i < this.Length; i++)
			{
				var memberData:MemberData = FindItemMemberDataByIndex(i);
				for (var j:int = 0; j < memberData.Likes.Length; j++)
				{
					var likeData:LikeData = memberData.Likes.FindItemLikeDataByIndex(j);
					likeData.IsLikesInCommon = SesHandler.Instance.Session.Me.Likes.FindItemLikeDataByObjectID(likeData.ObjectID) != null;
				}				
			}
		}
	}
}