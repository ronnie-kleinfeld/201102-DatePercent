package Data.Presents
{
	import Data.Base.CollectionBase;
	import Data.Member.PhotoData;
	
	import Handler.ParHandler;
	
	public class PresentDataCollection extends CollectionBase
	{
		public function PresentDataCollection()
		{
			super();
			
			AddItemPresentData(new PresentData(1, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/BlackCreature.png", ""), "Black Creature", 7));
			AddItemPresentData(new PresentData(2, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/CheeksCreature.png", ""), "Cheeks Creature", 9));
			AddItemPresentData(new PresentData(3, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/ChinaCreature.png", ""), "China Creature", 9));
			AddItemPresentData(new PresentData(4, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/Cookies.png", ""), "Cookies", 8));
			AddItemPresentData(new PresentData(5, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/Crown.png", ""), "Crown", 5));
			AddItemPresentData(new PresentData(6, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/DarkChocolateDonut.png", ""), "Dark Chocolate Donut", 12));
			AddItemPresentData(new PresentData(7, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/DomokunCreature.png", ""), "Domokun Creature", 10));
			AddItemPresentData(new PresentData(8, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/EarsCreature.png", ""), "Ears Creature", 10));
			AddItemPresentData(new PresentData(9, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/GlassesCreature.png", ""), "Glasses Creature", 10));
			AddItemPresentData(new PresentData(10, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/Halloween_ShyGhost.png", ""), "Halloween Shy Ghost", 7));
			AddItemPresentData(new PresentData(11, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/Halloween_Smile.png", ""), "Halloween Smile", 5));
			AddItemPresentData(new PresentData(12, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/Kitten.png", ""), "Kitten", 3));
			AddItemPresentData(new PresentData(13, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/NoseCreature.png", ""), "Nose Creature", 10));
			AddItemPresentData(new PresentData(14, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/PirateCreature.png", ""), "Pirate Creature", 10));
			AddItemPresentData(new PresentData(15, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/Puppy.png", ""), "Puppy", 9));
			AddItemPresentData(new PresentData(16, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/RoboticPet.png", ""), "Robotic Pet", 9));
			AddItemPresentData(new PresentData(17, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/ScarCreature.png", ""), "Scar Creature", 10));
			AddItemPresentData(new PresentData(18, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/SilverWeddingRing.png", ""), "Silver Wedding Ring", 15));
			AddItemPresentData(new PresentData(19, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/SmileCreature.png", ""), "Smile Creature", 10));
			AddItemPresentData(new PresentData(20, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/TheMoon.png", ""), "The Moon", 7));
			AddItemPresentData(new PresentData(21, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/Valentine_ChocolateBox.png", ""), "Valentine Chocolate", 14));
			AddItemPresentData(new PresentData(22, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/Xmas_Reindeer.png", ""), "Xmas Reindeer", 6));
			AddItemPresentData(new PresentData(23, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/Xmas_SantaGat.png", ""), "Xmas Santa Gat", 6));
			AddItemPresentData(new PresentData(24, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/Xmas_Sledge.png", ""), "Xmas Sledge", 5));
			AddItemPresentData(new PresentData(25, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/Xmas_Sock.png", ""), "Xmas Sock", 3));
			AddItemPresentData(new PresentData(26, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/Xmas_Star.png", ""), "Xmas Star", 3));
			AddItemPresentData(new PresentData(27, new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + "/Res/Platform/Present/Xmas_TreeBall.png", ""), "Xmas Tree Ball", 4));
		}
		
		public function AddItemPresentData(p_presentData:PresentData):void
		{
			this.AddItem(p_presentData);
		}
		public function AddItemPresentDataAt(p_presentData:PresentData, p_iIndex:int):void
		{
			this.AddItemAt(p_presentData, p_iIndex);
		}
		
		public function RemoveItemPresentData(p_presentData:PresentData):PresentData
		{
			return PresentData(this.RemoveItemAt(this.FindItemIndexByID(p_presentData.ID)));
		}
		public function RemoveItemPresentDataByID(p_iID:int):PresentData
		{
			return PresentData(this.RemoveItemAt(this.FindItemIndexByID(p_iID)));
		}
		
		public function FindItemPresentDataByID(p_iID:int):PresentData
		{
			var presentData:PresentData;
			for (var i:int = 0; i < this.Length; i++)
			{
				presentData = PresentData(this.getItemAt(i));
				if (presentData.ID == p_iID)
				{
					return presentData;
				}
			}
			
			return null;
		}
		public function FindItemPresentDataByIndex(p_iIndex:int):PresentData
		{
			return PresentData(this.getItemAt(p_iIndex));
		}
	}
}