package Data.Member
{
	import Data.Base.ObjectBase;
	import Data.MemberData;
	
	import Handler.SesHandler;
	
	public class CommData extends ObjectBase
	{
		private var m_iSenderMemberID:int;
		private var m_iGetterMemberID:int;
		private var m_iCommTypeCode:int;
		private var m_strText:String;
		private var m_iWinkTypeCode:int;
		private var m_dtSentDateTime:Date;
		private var m_iPresentTypeCode:int;
		public var IsRead:Boolean;
		
		public function get SenderMemberID():int
		{
			return m_iSenderMemberID;
		}
		public function get SenderMember():MemberData
		{
			return SesHandler.Instance.Session.Members.FindItemMemberDataByID(m_iSenderMemberID);
		}
		public function get GetterMemberID():int
		{
			return m_iGetterMemberID;
		}
		public function get GetterMember():MemberData
		{
			return SesHandler.Instance.Session.Members.FindItemMemberDataByID(m_iGetterMemberID);
		}
		public function get CommTypeCode():int
		{
			return m_iCommTypeCode;
		}
		public function get SentDateTime():Date
		{
			return m_dtSentDateTime;
		}
		public function get Text():String
		{
			return m_strText;
		}
		public function get WinkTypeCode():int
		{
			return m_iWinkTypeCode;
		}
		public function get PresentTypeCode():int
		{
			return m_iPresentTypeCode;
		}
		
		public function CommData(p_iID:int, p_iSenderMemberID:int, p_iGetterMemberID:int, p_iCommTypeCode:int, p_dtSentDateTime:Date, p_strText:String, p_iWinkTypeCode:int, p_iPresentTypeCode:int, p_bIsRead:Boolean)
		{
			super(p_iID);
			
			m_iSenderMemberID = p_iSenderMemberID;
			m_iGetterMemberID = p_iGetterMemberID;
			m_iCommTypeCode = p_iCommTypeCode;
			m_dtSentDateTime = p_dtSentDateTime;
			m_strText = p_strText;
			m_iWinkTypeCode = p_iWinkTypeCode;
			m_iPresentTypeCode = p_iPresentTypeCode;
			IsRead = p_bIsRead;
		}
	}
}