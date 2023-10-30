package Data.Member
{
	import Data.Base.ObjectBase;
	import Data.MemberData;
	
	import Handler.SesHandler;
	
	public class BlackListedData extends ObjectBase
	{
		public function get Member():MemberData
		{
			return SesHandler.Instance.Session.Members.FindItemMemberDataByID(this.ID);
		}
		
		public function BlackListedData(p_iID:int)
		{
			super(p_iID);
		}
	}
}