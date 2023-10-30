package Utils.AS3
{
	import mx.collections.ArrayCollection;
	
	public class ArrayCollectionHandler
	{
		public static function GetRowByColumnValue(p_ac:ArrayCollection, p_strColumnName:String, p_oValue:Object):Object
		{
			var oResult:Object;
			
			try
			{
				for (var i:int = 0; i < p_ac.length; i++)
				{
					if (p_ac.getItemAt(i)[p_strColumnName] == p_oValue)
					{
						oResult = p_ac.getItemAt(i);
						break;
					}
				}
			}
			catch (error:Error)
			{
				oResult = null;
			}
			
			return oResult;
		}
	}
}