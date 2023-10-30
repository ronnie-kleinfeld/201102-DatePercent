package Data.Member
{
	import Data.Base.ObjectBase;
	import Data.MemberData;
	
	import Handler.SesHandler;
	
	import Platform.Map.MemberMarker.MemberMarker;
	
	public class MapMarkerData extends ObjectBase
	{
		public var m_mapMarker:MemberMarker;
		
		public function get Member():MemberData
		{
			return SesHandler.Instance.Session.Members.FindItemMemberDataByID(this.ID);
		}
		public function get GetMapMarker():MemberMarker
		{
			return m_mapMarker;
		}
		public function set SetMapMarker(value:MemberMarker):void
		{
			m_mapMarker = value;
		}
		
		public function MapMarkerData(p_iID:int)
		{
			super(p_iID);
		}
		public override function Dispose():void
		{
			super.Dispose();
			
			if (m_mapMarker != null)
			{
				m_mapMarker.Dispose();
				m_mapMarker = null;
			}
		}
	}
}