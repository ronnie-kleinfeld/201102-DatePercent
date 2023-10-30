package Handler
{
	import Data.Presents.PresentDataCollection;
	
	import Utils.AS3.ArrayCollectionHandler;
	import Utils.AS3.Serializer;
	import Utils.Log.Logger;
	
	import flash.events.Event;
	import flash.events.EventDispatcher;
	
	import mx.collections.ArrayCollection;
	import mx.rpc.events.FaultEvent;
	import mx.rpc.events.ResultEvent;
	
	import services.flexws.FlexWS;
	
	public class AppHandler extends EventDispatcher
	{
		// singleton
		private static var s_dsInstance:AppHandler;
		
		public static function get Instance():AppHandler
		{
			if (s_dsInstance == null)
			{
				s_dsInstance = new AppHandler();
			}
			
			return s_dsInstance;
		}
		
		// members
		public static const FILLED:String = "FILLED";
		public static const FAULT:String = "FAULT";
		
		public var RootUrl:String = "http://" + ParHandler.Instance.BLServer + "/";
		public var RootFlexUrl:String = "http://" + ParHandler.Instance.BLServer + "/Flex/";
		public var RootWS:String = "http://" + ParHandler.Instance.BLServer + "/ws/";
		
		protected var m_ws:FlexWS;
		protected var m_bFilled:Boolean = false;
		
		private var m_acSerializer:ArrayCollection;
		
		private var m_acSexTypeEnum:ArrayCollection;
		private var m_acDistanceUnitsTypeEnum:ArrayCollection;
		private var m_acLocaleType:ArrayCollection;
		
		private var m_acDomainTypeEnum:ArrayCollection;
		
		private var m_presentDataCollection:PresentDataCollection;
		
		// properties
		public function get Filled():Boolean
		{
			return m_bFilled;
		}
		public function get Presents():PresentDataCollection
		{
			return m_presentDataCollection;
		}
		
		// class
		public function AppHandler():void
		{
			super();
			
			m_presentDataCollection = new PresentDataCollection();
		}
		
		// fill
		public function ApplicationFill():void
		{
			Logger.Instance.WriteProcess("Fill", "ApplicationHandler");
			
			m_ws = new FlexWS();
			m_ws.addEventListener(ResultEvent.RESULT, m_ws_RESULT);
			m_ws.addEventListener(FaultEvent.FAULT, m_ws_FAULT);
			m_ws.ApplicationFill(ParHandler.Instance.SID);
		}
		protected function m_ws_RESULT(event:ResultEvent):void
		{
			try
			{
				Logger.Instance.WriteEvent(event, "ApplicationHandler");
				
				m_acSerializer = Serializer.GetWSArrayCollection(event, "T_SERIALIZER");
				
				m_acSexTypeEnum = Serializer.DeSerializeArrayCollection(event, "T_SEX_TYPE_ENUM");
				m_acDistanceUnitsTypeEnum = Serializer.DeSerializeArrayCollection(event, "T_DISTANCE_UNITS_TYPE_ENUM");
				m_acLocaleType = Serializer.DeSerializeArrayCollection(event, "T_LOCALE_TYPE");
				
				//m_acDomainTypeEnum = Serializer.DeSerializeArrayCollection(event, "T_DOMAIN_TYPE_ENUM");
				
				m_bFilled = true;
				dispatchEvent(new Event(FILLED));
			}
			catch (error:Error)
			{
				Logger.Instance.WriteError(error, "ApplicationHandler");
				dispatchEvent(new Event(FAULT));
			}
		}
		protected function m_ws_FAULT(event:FaultEvent):void
		{
			Logger.Instance.WriteFaultEvent(event, "ApplicationHandler");
			dispatchEvent(new Event(FAULT));
		}
		
		public function GetSerializerByDescription(p_strSRL_KEY:String):String
		{
			var strResult:String;
			
			try
			{
				strResult = ArrayCollectionHandler.GetRowByColumnValue(m_acSerializer, "SRL_KEY_1", p_strSRL_KEY)["SRL_DESCRIPTION"];
			}
			catch (error:Error)
			{
				Logger.Instance.WriteError(error, "ApplicationHandler missing a srl key - need to refresh the applicationHandler of the flex");
				strResult = p_strSRL_KEY;
			}
			
			return strResult;
		}

		public function get GetDomainTypeEnum():ArrayCollection
		{
			return m_acDomainTypeEnum;
		}
		public function GetDomainTypeDefault():Object
		{
			return ArrayCollectionHandler.GetRowByColumnValue(GetDomainTypeEnum, "DMT_DESCRIPTION", "DEFAULT");
		}
		
		public function get GetDistanceUnitsTypeEnum():ArrayCollection
		{
			return m_acDistanceUnitsTypeEnum;
		}
		
		public function get GetLocaleType():ArrayCollection
		{
			return m_acLocaleType;
		}
		public function get GetLocale():Object
		{
			return ArrayCollectionHandler.GetRowByColumnValue(GetLocaleType, "LCL_LOCALE", ParHandler.Instance.Locale);
		}
	}
}