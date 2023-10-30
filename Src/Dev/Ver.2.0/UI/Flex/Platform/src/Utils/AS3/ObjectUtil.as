package Utils.AS3
{
	public class ObjectUtil
	{
		public static function GetStringValue(p_oObject:Object, p_strKey:String, p_strDefaultValue:String = ""):String
		{
			var strResult:String;
			
			try
			{
				strResult = p_oObject[p_strKey].toString();
			}
			catch (error:Error)
			{
				strResult = p_strDefaultValue;
			}
			
			return strResult;
		}
		public static function GetIntValue(p_oObject:Object, p_strKey:String, p_iDefaultValue:int = -1):int
		{
			var iResult:int;
			
			try
			{
				iResult = p_oObject[p_strKey].toString();
			}
			catch (error:Error)
			{
				iResult = p_iDefaultValue;
			}
			
			return iResult;
		}
	}
}