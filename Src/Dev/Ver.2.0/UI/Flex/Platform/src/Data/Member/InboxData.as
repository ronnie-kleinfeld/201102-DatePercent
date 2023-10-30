package Data.Member
{
	import Data.Base.ObjectBase;
	import Data.MemberData;
	
	import Handler.SesHandler;
	
	public class InboxData extends ObjectBase
	{
		private var m_iMemberID:int;
		private var m_iCommTypeCode:int;
		[Bindable] public var Text:String;
		private var m_iWinkTypeCode:int;
		private var m_iPresentTypeCode:int;
		
		public function get MemberID():int
		{
			return m_iMemberID;
		}
		public function get Member():MemberData
		{
			return SesHandler.Instance.Session.Members.FindItemMemberDataByID(m_iMemberID);
		}
		public function get CommTypeCode():int
		{
			return m_iCommTypeCode;
		}
		public function get WinkTypeCode():int
		{
			return m_iWinkTypeCode;
		}
		public function get PresentTypeCode():int
		{
			return m_iPresentTypeCode;
		}
		
		public function InboxData(p_iID:int, p_iMemberID:int, p_iCommTypeCode:int, p_strText:String, p_iWinkTypeCode:int, p_iPresentTypeCode:int)
		{
			super(p_iID);
			m_iMemberID = p_iMemberID;
			m_iCommTypeCode = p_iCommTypeCode;
			Text = p_strText;
			m_iWinkTypeCode = p_iWinkTypeCode;
			m_iPresentTypeCode = p_iPresentTypeCode;
		}
	}
}