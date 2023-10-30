package Data.Member
{
	import Data.Base.ObjectBase;
	import Data.MemberData;
	
	import Handler.SesHandler;
	
	public class BreakingNewsData extends ObjectBase
	{
		public function get Member():MemberData
		{
			return SesHandler.Instance.Session.Members.FindItemMemberDataByID(this.ID);
		}
		
		public function BreakingNewsData(p_iID:int)
		{
			super(p_iID);
		}
	}
}