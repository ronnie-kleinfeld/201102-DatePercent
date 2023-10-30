package Data
{
	import Data.Member.ActiveDataCollection;
	import Data.Member.BlackListedDataCollection;
	import Data.Member.BreakingNewsDataCollection;
	import Data.Member.CreditDataCollection;
	import Data.Member.FavoriteDataCollection;
	import Data.Member.InboxDataCollection;
	import Data.Member.MapMarkerDataCollection;
	
	public class SessionData
	{
		public var SID:String;
		public var RegionRadiusKm:Number = 10;
		
		[Bindable] public var Me:MemberData;
		public var Members:MemberDataCollection;
		[Bindable] public var Inboxes:InboxDataCollection;
		[Bindable] public var BreakingNews:BreakingNewsDataCollection;
		public var MapMarkers:MapMarkerDataCollection;
		public var Actives:ActiveDataCollection;
		[Bindable] public var Favorites:FavoriteDataCollection;
		[Bindable] public var BlackListed:BlackListedDataCollection;
		[Bindable] public var Credits:CreditDataCollection;
		
		public function SessionData(p_strSID:String)
		{
			super();
			
			Me = new MemberData(-1, true);
			SID = p_strSID;
			Members = new MemberDataCollection();
			Inboxes = new InboxDataCollection();
			BreakingNews = new BreakingNewsDataCollection();
			MapMarkers = new MapMarkerDataCollection();
			Actives = new ActiveDataCollection();
			Favorites = new FavoriteDataCollection();
			BlackListed = new BlackListedDataCollection();
			Credits = new CreditDataCollection();
		}
		public function Dispose():void
		{
			super.Dispose();
			
			if (Credits != null)
			{
				Credits.Dispose();
				Credits = null;
			}
			if (BlackListed != null)
			{
				BlackListed.Dispose();
				BlackListed = null;
			}
			if (Favorites != null)
			{
				Favorites.Dispose();
				Favorites = null;
			}
			if (Actives != null)
			{
				Actives.Dispose();
				Actives = null;
			}
			if (MapMarkers != null)
			{
				MapMarkers.Dispose();
				MapMarkers = null;
			}
			if (BreakingNews != null)
			{
				BreakingNews.Dispose();
				BreakingNews = null;
			}
			if (Inboxes != null)
			{
				Inboxes.Dispose();
				Inboxes = null;
			}
			if (Members != null)
			{
				Members.Dispose();
				Members = null;
			}
			if (Me != null)
			{
				Me.Dispose();
				Me = null;
			}
		}
	}
}