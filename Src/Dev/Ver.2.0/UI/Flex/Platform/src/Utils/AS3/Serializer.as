package Utils.AS3
{
	import Handler.AppHandler;
	
	import mx.collections.ArrayCollection;
	import mx.rpc.events.ResultEvent;
	
	public class Serializer
	{
		public static function DeSerializeObject(p_resultEvent:ResultEvent, p_strTableName:String):Object
		{
			var oResult:Object;
			
			try
			{
				oResult = DeSerializeArrayCollection(p_resultEvent, p_strTableName).getItemAt(0);
			}
			catch (error:Error)
			{
				oResult = null;
			}
			
			return oResult;
		}
		public static function DeSerializeArrayCollection(p_resultEvent:ResultEvent, p_strTableName:String):ArrayCollection
		{
			var acResult:mx.collections.ArrayCollection;
			
			try
			{
				acResult = DeSerializeFromWebService(p_resultEvent.result.Tables[p_strTableName].Rows);
			}
			catch (error:Error)
			{
				acResult = null;
			}
			
			return acResult;
		}
		
		public static function DeSerializeFromWebService(p_acWS:ArrayCollection):ArrayCollection
		{
			var oItemWS:Object;
			var oObjectWS:Object;
			
			var acFlex:ArrayCollection = new ArrayCollection();
			var oItemFlex:Object;
			
			for (var i:int = 0; i < p_acWS.length; i++)
			{
				oItemWS = p_acWS.getItemAt(i);
				
				oItemFlex = new Object();
				
				for (oObjectWS in oItemWS)
				{
					try
					{
						oItemFlex[AppHandler.Instance.GetSerializerByDescription(oObjectWS.toString())] = oItemWS[oObjectWS];
					}
					catch (error:Error)
					{
						oItemFlex[AppHandler.Instance.GetSerializerByDescription(oObjectWS.toString())] = "";
					}
				}
				
				acFlex.addItem(oItemFlex);
			}
			
			return acFlex;
		}
		public static function GetWSArrayCollection(p_resultEvent:ResultEvent, p_strTableName:String):ArrayCollection
		{
			var acResult:mx.collections.ArrayCollection;
			
			try
			{
				acResult = p_resultEvent.result.Tables[p_strTableName].Rows;
			}
			catch (error:Error)
			{
				acResult = null;
			}
			
			return acResult;
		}
	}
}