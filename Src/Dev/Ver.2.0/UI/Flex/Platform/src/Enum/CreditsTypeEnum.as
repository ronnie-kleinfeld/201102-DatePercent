package Enum
{
	import Handler.LocHandler;
	
	import Handler.LocGeneratedCode;
	import Utils.Log.Logger;

	public class CreditsTypeEnum
	{
		public static const TRANSACTION_COMPLETED:int = 1;
		public static const TRANSACTION_REFUNDED:int = 2;
		public static const UNLIMITED_CHAT_WITH_A_MEMBER:int = 3;
		public static const SEND_A_PRESENT:int = 4;
		
		public static function CreditsLabel(p_iCreditsTypeCode:int):String
		{
			switch (p_iCreditsTypeCode)
			{
				case TRANSACTION_COMPLETED:
					return LocHandler.GS(LocGeneratedCode.Credits_Purchase);
					break;
				case TRANSACTION_REFUNDED:
					return LocHandler.GS(LocGeneratedCode.Credits_Refunded);
					break;
				case UNLIMITED_CHAT_WITH_A_MEMBER:
					return LocHandler.GS(LocGeneratedCode.Unlimited_chat_with_a_member);
					break;
				case SEND_A_PRESENT:
					return LocHandler.GS(LocGeneratedCode.Send_a_Present);
					break;
				default:
					Logger.Instance.WriteSwitchOutOfBoundError(p_iCreditsTypeCode.toString(), "CreditsTypeEnum");
					return "";
					break;
			}
		}
	}
}