package Data.Member
{
	import Data.Base.ObjectBase;
	import Data.MemberData;
	
	import Handler.SesHandler;
	
	public class FavoriteData extends ObjectBase
	{
		public function get Member():MemberData
		{
			return SesHandler.Instance.Session.Members.FindItemMemberDataByID(this.ID);
		}
		
		public function FavoriteData(p_iID:int)
		{
			super(p_iID);
		}
	}
}