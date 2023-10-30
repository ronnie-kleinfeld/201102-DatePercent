package Data.Member
{
	import Data.Base.ObjectBase;
	import Data.MemberData;
	
	import Handler.SesHandler;
	
	public class CreditData extends ObjectBase
	{
		private var m_iCreditTypeCode:int;
		private var m_dtSentDateTime:Date;
		private var m_iCredits:int;
		private var m_iGetterMemberID:int;
		private var m_iPresentTypeCode:int;
		
		public function get CreditTypeCode():int
		{
			return m_iCreditTypeCode;
		}
		public function get SentDateTime():Date
		{
			return m_dtSentDateTime;
		}
		public function get Credits():int
		{
			return m_iCredits;
		}
		public function get GetterMemberID():int
		{
			return m_iGetterMemberID;
		}
		public function get GetterMember():MemberData
		{
			return SesHandler.Instance.Session.Members.FindItemMemberDataByID(m_iGetterMemberID);
		}
		public function get PresentTypeCode():int
		{
			return m_iPresentTypeCode;
		}
		
		public function CreditData(p_iID:int, p_iCreditTypeCode:int, p_dtSentDateTime:Date, p_iCredits:int, p_iGetterMemberID:int, p_iPresentTypeCode:int)
		{
			super(p_iID);
			
			m_iCreditTypeCode = p_iCreditTypeCode;
			m_dtSentDateTime = p_dtSentDateTime;
			m_iCredits = p_iCredits;
			m_iGetterMemberID = p_iGetterMemberID;
			m_iPresentTypeCode = p_iPresentTypeCode;
		}
	}
}