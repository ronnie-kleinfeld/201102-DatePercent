package Platform.Map.MemberMarker
{
	import Data.MemberData;
	
	import Enum.PinPercentTypeEnum;
	
	import Handler.LocHandler;
	
	import Platform.BreakingNewsBar.BreakingNewsBar;
	
	import Utils.AS3.Filters;
	import Handler.LocGeneratedCode;
	import Utils.Log.Logger;
	
	import com.mapquest.tilemap.pois.ImageMapIcon;
	import com.mapquest.tilemap.pois.Poi;
	
	import flash.display.Bitmap;
	import flash.display.Loader;
	import flash.events.Event;
	import flash.events.EventDispatcher;
	import flash.events.IOErrorEvent;
	import flash.events.MouseEvent;
	import flash.net.URLRequest;
	import flash.system.ApplicationDomain;
	import flash.system.LoaderContext;
	import flash.system.Security;
	import flash.system.SecurityDomain;
	import flash.utils.getQualifiedClassName;
	
	import mx.events.EffectEvent;
	
	import spark.components.Group;
	import spark.effects.Move;
	import spark.effects.easing.Bounce;
	
	[Event(name=ITEM_ROLL_OVER, type="Platform.Map.MapMarker.MapMarkerEvent")]
	[Event(name=CLICK, type="Platform.Map.MapMarker.MapMarkerEvent")]
	public class MemberMarker extends EventDispatcher
	{
		public var m_poi:Poi;
		public var m_imageMapIcon:ImageMapIcon;
		
		private var m_urlRequestPin:URLRequest;
		private var m_loader:Loader;
		private var m_iReloadCount:int;
		
		private var m_memberData:MemberData;
		
		private var m_move:Move;
		private var m_bounce:Bounce;
		private var m_groupDummy:Group;
		
		public function get Member():MemberData
		{
			return m_memberData;
		}
		
		public function MemberMarker(p_memberData:MemberData)
		{
			m_memberData = p_memberData;
			
			Security.allowDomain("*");
			Security.loadPolicyFile("http://profile.ak.fbcdn.net/crossdomain.xml");
			
			m_poi = new Poi(m_memberData.GPS);
			m_poi.addEventListener(MouseEvent.ROLL_OVER, m_poi_ROLL_OVER);
			m_poi.addEventListener(MouseEvent.ROLL_OUT, m_poi_ROLL_OUT);
			m_poi.addEventListener(MouseEvent.CLICK, m_poi_CLICK);
			
			if (m_memberData.IsMe)
			{
				m_poi.label = LocHandler.GS(LocGeneratedCode.Me);
			}
			else
			{
				m_poi.label = m_memberData.DatePercentageLabel;
			}
			
			DoLoadImage();
			
			m_groupDummy = new Group();
			m_bounce = new Bounce();
			m_move = new Move();
			m_move.yFrom = -15;
			m_move.yTo = 0;
			m_move.duration = 1200;
			m_move.target = m_groupDummy;
			m_move.easer = m_bounce;
			m_move.addEventListener(EffectEvent.EFFECT_UPDATE, m_move_EFFECT_UPDATE);
		}
		public function DoLoadImage():void
		{
			Security.allowDomain("*");
			Security.loadPolicyFile("http://profile.ak.fbcdn.net/crossdomain.xml");
			m_urlRequestPin = new URLRequest(m_memberData.Photo.UrlX);
			if (m_loader == null)
			{
				m_loader = new Loader();
				m_loader.contentLoaderInfo.addEventListener(Event.COMPLETE, m_loader_COMPLETE, false, 0, true);
				m_loader.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR, m_loader_IO_ERROR, false, 0, true);
			}
			else
			{
				m_loader.unloadAndStop();
			}
			m_loader.load(m_urlRequestPin, new LoaderContext(true, ApplicationDomain.currentDomain, SecurityDomain.currentDomain));
		}
		private function m_loader_COMPLETE(event:Event):void
		{
			try
			{
				var bitmap:Bitmap = event.currentTarget.content;
				bitmap.width = 39;
				bitmap.height = 39;
				
				m_imageMapIcon = new ImageMapIcon();
				m_imageMapIcon.setImage(bitmap);
				m_poi.icon = m_imageMapIcon;
				m_poi.icon.filters = [Enum.PinPercentTypeEnum.Filter(m_memberData.DatePercentageValue)];
			}
			catch (error:Error)
			{
				Logger.Instance.WriteError(error, flash.utils.getQualifiedClassName(this));
			}
		}
		private function m_loader_IO_ERROR(event:IOErrorEvent):void
		{
			if (m_iReloadCount < 5)
			{
				m_iReloadCount++;
				m_loader.load(m_urlRequestPin, new LoaderContext(true, ApplicationDomain.currentDomain, SecurityDomain.currentDomain));
			}
			else
			{
				Logger.Instance.WriteCritical(event.text, "", flash.utils.getQualifiedClassName(this));
			}
		}
		
		public function Dispose():void
		{
			m_groupDummy = null;
			m_bounce = null;
			if (m_move != null)
			{
				m_move.removeEventListener(EffectEvent.EFFECT_UPDATE, m_move_EFFECT_UPDATE);
				m_move.easer = null;
				m_move.target = null;
				m_move = null;
			}
			
			m_memberData = null;
			
			if (m_poi != null)
			{
				m_imageMapIcon = null;
				m_poi.removeEventListener(MouseEvent.CLICK, m_poi_CLICK);
				m_poi.removeEventListener(MouseEvent.ROLL_OUT, m_poi_ROLL_OUT);
				m_poi.removeEventListener(MouseEvent.ROLL_OVER, m_poi_ROLL_OVER);
				m_poi = null;
			}
		}
		
		private function m_poi_ROLL_OVER(event:MouseEvent):void
		{
			event.stopPropagation();
			m_poi.y = m_poi.y - 2;
			BreakingNewsBar.GetBreakingNewsBar.breakingNewsList.StopFillTimer();
			m_poi.icon.filters = [Utils.AS3.Filters.Glow];
		};
		private function m_poi_ROLL_OUT(event:MouseEvent):void
		{
			event.stopPropagation();
			m_poi.y = m_poi.y + 2;
			BreakingNewsBar.GetBreakingNewsBar.breakingNewsList.StartFillTimer();
			m_poi.icon.filters = [Enum.PinPercentTypeEnum.Filter(m_memberData.DatePercentageValue)];
		};
		private function m_poi_CLICK(event:MouseEvent):void
		{
			event.stopPropagation();
			if (!m_move.isPlaying)
			{
				Poke();
				dispatchEvent(new MemberMarkerEvent(MemberMarkerEvent.CLICK, this, event));
			}
		};
		
		public function Poke():void
		{
			if (!m_move.isPlaying)
			{
				m_move.yFrom = m_poi.y - 15;
				m_move.yTo = m_poi.y;
				m_move.play();
			}
		}
		private function m_move_EFFECT_UPDATE(event:EffectEvent):void
		{
			m_poi.y = m_groupDummy.y;
		}
	}
}