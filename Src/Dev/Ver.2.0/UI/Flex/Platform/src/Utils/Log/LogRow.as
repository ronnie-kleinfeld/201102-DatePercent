package Utils.Log 
{
	internal class LogRow
	{
		private var m_iLogType:int;
		private var m_strMessage:String;
		private var m_strExtMessage:String;
		private var m_strQualifiedClassName:String;
		
		public function get LogType():int
		{
			return m_iLogType;
		}
		public function get Message():String
		{
			return m_strMessage;
		}
		public function get ExtMessage():String
		{
			return m_strExtMessage;
		}
		public function get QualifiedClassName():String
		{
			return m_strQualifiedClassName;
		}
		
		public function LogRow(p_iLogType:int, p_strMessage:String, p_strExtMessage:String, p_strQualifiedClassName:String)
		{
			m_iLogType = p_iLogType;
			m_strMessage = p_strMessage;
			m_strExtMessage = p_strExtMessage;
			m_strQualifiedClassName = p_strQualifiedClassName;
		}
	}
}