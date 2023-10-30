//flash.utils.getQualifiedClassName(this));
package Utils.Log 
{
	import Utils.AS3.ResultCode;
	import Utils.AS3.StringUtil;
	
	import flash.events.Event;
	import flash.events.IOErrorEvent;
	import flash.events.TimerEvent;
	import flash.utils.Timer;
	
	import mx.collections.ArrayCollection;
	import mx.rpc.events.FaultEvent;
	import mx.rpc.soap.WebService;
	
	public class Logger
	{
		// singleton
		private static var m_instance:Logger;
		
		public static function get Instance():Logger
		{
			if (m_instance == null)
			{
				m_instance = new Logger();
			}
			
			return m_instance;
		}
		
		// const
		private const LINE_SEPERATOR:String = '~';
		private const SEPERATOR:String = ',';
		
		// members
		private var m_aSpoll:Array;
		private var m_wsLogger:WebService;
		private var m_timer:Timer;
		private var m_bLogInformation:Boolean = true;
		private var m_bLogProcess:Boolean = true;
		private var m_strApplicationName:String;
		private var m_strSessionUID:String = "Session UID not set";
		
		// class
		public function Init(p_strApplicationName:String, p_bLogInformation:Boolean, p_bLogProcess:Boolean, p_strSessionUID:String):void
		{
			m_aSpoll = new Array();
			
			m_wsLogger = new WebService();
			m_wsLogger.loadWSDL("http://www.dp38745.com/LoggerWS.asmx?WSDL");
			
			m_bLogInformation = p_bLogInformation;
			m_bLogProcess = p_bLogProcess;
			
			m_strApplicationName = p_strApplicationName;
			
			m_timer = new Timer(2000);
			m_timer.addEventListener(TimerEvent.TIMER, m_timer_TIMER);
			m_timer.start();
			
			if (p_strSessionUID == null)
			{
				m_strSessionUID = "Session UID is null";
			}
			else if (p_strSessionUID == "")
			{
				m_strSessionUID = "Session UID is empty";
			}
			else
			{
				m_strSessionUID = p_strSessionUID;
			}
		}
		
		// timer
		private function m_timer_TIMER(event:TimerEvent):void
		{
			WriteEvent(event, flash.utils.getQualifiedClassName(this));
			try
			{
				m_timer.stop();
				
				var strBatch:String = "";
				var strSessionUID:String = SafeString(m_strSessionUID);
				
				while (m_aSpoll.length > 0)
				{
					var logRow:LogRow = m_aSpoll.shift();
					
					var strQualifiedClassName:String = SafeString(logRow.QualifiedClassName);
					var strMessage:String = SafeString(logRow.Message);
					var strExtMessage:String = SafeString(logRow.ExtMessage);
					
					var strLine:String =
						logRow.LogType + SEPERATOR +
						strSessionUID + SEPERATOR +
						strQualifiedClassName + SEPERATOR +
						strMessage + SEPERATOR +
						strExtMessage + LINE_SEPERATOR;
					
					strBatch = strBatch + strLine;
				}
				
				m_wsLogger.LoggerWriteBatch(m_strApplicationName, strBatch);
			}
			catch (error:Error)
			{
				WriteError(error, flash.utils.getQualifiedClassName(this));
			}
			finally
			{
				m_timer.start();
			}
		}
		private function SafeString(p_str:String):String
		{
			var strResult:String;
			
			try
			{
				if (p_str == "null")
				{
					strResult = "";
				}
				else
				{
					strResult = p_str;
				}
				strResult = StringUtil.ReplaceAll(strResult, SEPERATOR, "-");
				strResult = StringUtil.ReplaceAll(strResult, LINE_SEPERATOR, "\"");
			}
			catch (error:Error)
			{
				strResult = "";
			}
			
			return strResult;
		}
		
		// methods
		public function WriteArrayCollection(p_ac:ArrayCollection, p_oThis:Object):void
		{
			try
			{
				WriteInformation("ArrayCollection.length=" + p_ac.length + " start", p_oThis);
				// rows
				var i:int;
				for (i=0; i<p_ac.length; i++)
				{
					// columns
					WriteArray(p_ac.getItemAt(i), p_oThis);
				}
				WriteInformation("ArrayCollection.length=" + p_ac.length + " done", p_oThis);
			}
			catch (error:Error)
			{
				WriteError(error, p_oThis);
			}
		}
		public function WriteArray(p_o:Object, p_oThis:Object):void
		{
			try
			{
				var strResult:String = "";
				
				for (var str:String in p_o) 
				{
					strResult = strResult + str + ":" + p_o[str] + ", ";
				} 
				
				WriteInformation(strResult, p_oThis);
			}
			catch (error:Error)
			{
				WriteError(error, p_oThis);
			}
		}
		
		public function WriteEvent(event:Event, p_oThis:Object):String
		{
			return WriteInformation(event.target.toString() + "::" + event.toString(), p_oThis);
		}
		public function WriteFaultEvent(event:FaultEvent, p_oThis:Object):String
		{
			return WriteCritical("WebService Fault. Failed to connect to DatePercent database. " + event.target + "::" + event.toString(), event.fault.message, p_oThis);
		}
		public function WriteIOErrorEvent(event:IOErrorEvent, p_oThis:Object):String
		{
			return WriteCritical("SWFLoader Fault. Failed to load swf. " + event.target + "::" + event.toString(), event.eventPhase.toString(), p_oThis);
		}
		
		public function WriteError(error:Error, p_oThis:Object):String
		{
			if (error.errorID == 1009)
			{
				return ResultCode.SUCCESS;
			}
			else
			{
				return WriteCritical(error.toString(), error.message, p_oThis);
			}
		}
		public function WriteSwitchOutOfBoundError(p_strID:String, p_oThis:Object):String
		{
			return WriteCritical("Switch out of bound error. ID=" + p_strID, "", p_oThis); 
		}
		
		public function WriteInformation(p_strMessage:String, p_oThis:Object):String
		{
			return m_bLogInformation?Write(LogTypeEnum.Information, p_strMessage, "", p_oThis):ResultCode.FAILED;
		}
		public function WriteProcess(p_strMessage:String, p_oThis:Object):String
		{
			return m_bLogProcess?Write(LogTypeEnum.Process, p_strMessage, "", p_oThis):ResultCode.FAILED;
		}
		public function WriteCritical(p_strMessage:String, p_strStackTrace:String, p_oThis:Object):String
		{
			return Write(LogTypeEnum.Critical, p_strMessage, p_strStackTrace, p_oThis);
		}
		
		private function Write(p_iLogType:int, p_strMessage:String, p_strExtMessage:String, p_oThis:Object):String
		{
			var strResult:String;
			
			try
			{
				var logRow:LogRow = new LogRow(p_iLogType, p_strMessage, p_strExtMessage, p_oThis.toString());
				m_aSpoll.push(logRow);
				
				strResult = ResultCode.SUCCESS;
			}
			catch (error:Error)
			{
				strResult = ResultCode.FAILED;
			}
			
			return strResult;
		}
	}
}