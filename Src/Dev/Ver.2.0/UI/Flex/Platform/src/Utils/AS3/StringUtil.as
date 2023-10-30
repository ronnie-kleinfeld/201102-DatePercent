package Utils.AS3
{
	public class StringUtil
	{
		public static function ReplaceAll(p_strSource:String, p_str1:String, p_str2:String):String
		{
			var strNew:String = p_strSource.replace(p_str1, p_str2);
			if (strNew != p_strSource)
			{
				return ReplaceAll(strNew, p_str1, p_str2);
			}
			else
			{
				return strNew
			}
		}
	}
}