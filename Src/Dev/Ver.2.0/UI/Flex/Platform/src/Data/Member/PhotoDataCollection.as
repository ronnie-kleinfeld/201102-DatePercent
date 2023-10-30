package Data.Member
{
	import Data.Base.CollectionBase;
	
	import mx.collections.ArrayCollection;
	
	public class PhotoDataCollection extends CollectionBase
	{
		public function AddItemPhotoData(p_photoData:PhotoData):void
		{
			this.AddItem(p_photoData);
		}
		public function AddItemPhotoDataAt(p_photoData:PhotoData, p_iIndex:int):void
		{
			this.AddItemAt(p_photoData, p_iIndex);
		}
		
		public function RemoveItemPhotoData(p_photoData:PhotoData):PhotoData
		{
			return PhotoData(this.RemoveItemAt(this.FindItemIndexByID(p_photoData.ID)));
		}
		public function RemoveItemPhotoDataByID(p_iID:int):PhotoData
		{
			return PhotoData(this.RemoveItemAt(this.FindItemIndexByID(p_iID)));
		}
		
		public function FindItemPhotoDataByID(p_iID:int):PhotoData
		{
			var photoData:PhotoData;
			for (var i:int = 0; i < this.Length; i++)
			{
				photoData = PhotoData(this.getItemAt(i));
				if (photoData.ID == p_iID)
				{
					return photoData;
				}
			}
			
			return null;
		}
		public function FindItemPhotoDataByPID(p_strPID:String):PhotoData
		{
			var photoData:PhotoData;
			for (var i:int = 0; i < this.Length; i++)
			{
				photoData = PhotoData(this.getItemAt(i));
				if (photoData.FBPid == p_strPID)
				{
					return photoData;
				}
			}
			
			return null;
		}
		public function FindItemPhotoDataByIndex(p_iIndex:int):PhotoData
		{
			return PhotoData(this.getItemAt(p_iIndex));
		}
		
		public function Fill(p_ac:ArrayCollection):void
		{
			for (var i:int = 0; i < p_ac.length; i++)
			{
				var oPhoto:Object = p_ac.getItemAt(i);
				if (FindItemPhotoDataByID(oPhoto.USP_ID) == null)
				{
					AddItemPhotoData(new PhotoData(oPhoto.USP_ID, oPhoto.USP_FB_PID, oPhoto.USP_FB_PIC_URL, oPhoto.USP_FB_PIC_URL));
				}
			}
		}
	}
}