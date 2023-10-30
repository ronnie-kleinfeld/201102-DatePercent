package Handler
{
	import Data.SessionData;
	
	import Utils.AS3.Serializer;
	import Utils.Log.Logger;
	
	import flash.events.Event;
	import flash.events.EventDispatcher;
	
	import mx.collections.ArrayCollection;
	import mx.rpc.events.FaultEvent;
	import mx.rpc.events.ResultEvent;
	
	import services.flexws.FlexWS;
	
	public final class SesHandler extends EventDispatcher
	{
		// singleton
		private static var s_dsInstance:SesHandler;
		
		public static function get Instance():SesHandler
		{
			if (s_dsInstance == null)
			{
				s_dsInstance = new SesHandler();
			}
			
			return s_dsInstance;
		}
		
		// members
		public static const INITIALIZED:String = "INITIALIZED";
		public static const FILLED:String = "FILLED";
		public static const MEMBERS_FILLED:String = "MEMBERS_FILLED";
		public static const INBOX_FILLED:String = "INBOX_FILLED";
		public static const FAULT:String = "FAULT";
		
		protected var m_wsSessionInit:FlexWS;
		protected var m_bInitialized:Boolean = false;
		protected var m_wsSessionFill:FlexWS;
		protected var m_wsSessionFillOnlineMembers:FlexWS;
		protected var m_wsSessionFillLocalMembers:FlexWS;
		protected var m_wsSessionFillInbox:FlexWS;
		protected var m_wsSessionFillCreditsBalance:FlexWS;
		
		[Bindable] public var Session:SessionData;
		
		// properties
		public function get Initialized():Boolean
		{
			return m_bInitialized;
		}
		
		// class
		public function SesHandler()
		{
			super();
			
			Logger.Instance.WriteInformation("Init", "SessionHandler");
			
			Session = new SessionData(ParHandler.Instance.SID);
		}
		
		// init me
		public function SessionInit():void
		{
			m_wsSessionInit = new FlexWS();
			m_wsSessionInit.addEventListener(ResultEvent.RESULT, m_wsSessionInit_RESULT);
			m_wsSessionInit.addEventListener(FaultEvent.FAULT, m_wsSessionInit_FAULT);
			m_wsSessionInit.SessionInit(ParHandler.Instance.SID, ParHandler.Instance.Token);
		}
		protected function m_wsSessionInit_RESULT(event:ResultEvent):void
		{
			Logger.Instance.WriteEvent(event, "SessionHandler");
			
			try
			{
				Session.Me.InitMe(Serializer.DeSerializeObject(event, "T_USER"));
				Logger.Instance.WriteProcess("USR_ID:" + Session.Me.ID, "SessionHandler");
				Session.Favorites.Fill(Serializer.DeSerializeArrayCollection(event, "T_USER_FAVORITE"));
				Session.BlackListed.Fill(Serializer.DeSerializeArrayCollection(event, "Table1"));
				Session.Members.Fill(Serializer.DeSerializeArrayCollection(event, "Table2"));
				Session.Members.FillMultipleMembersPhotos(Serializer.DeSerializeArrayCollection(event, "Table3"));
				Session.Members.FillMultipleMembersLikes(Serializer.DeSerializeArrayCollection(event, "Table4"));
				Session.Members.FillMultipleMembersFriends(Serializer.DeSerializeArrayCollection(event, "Table5"));
				Session.Members.FillMultipleMembersComms(Serializer.DeSerializeArrayCollection(event, "Table6"));
				Session.Members.CalculateDatePercentage();
				
				m_bInitialized = true;
				dispatchEvent(new Event(INITIALIZED));
			}
			catch (error:Error)
			{
				Logger.Instance.WriteError(error, "SessionHandler");
				dispatchEvent(new Event(FAULT));
			}
		}
		protected function m_wsSessionInit_FAULT(event:FaultEvent):void
		{
			Logger.Instance.WriteFaultEvent(event, "SessionHandler");
			dispatchEvent(new Event(FAULT));
		}
		
		// fill me
		public function SessionFill():void
		{
			m_wsSessionFill = new FlexWS();
			m_wsSessionFill.addEventListener(ResultEvent.RESULT, m_wsSessionFill_RESULT);
			m_wsSessionFill.addEventListener(FaultEvent.FAULT, m_wsSessionFill_FAULT);
			m_wsSessionFill.SessionFill(ParHandler.Instance.SID);
		}
		protected function m_wsSessionFill_RESULT(event:ResultEvent):void
		{
			Logger.Instance.WriteEvent(event, "SessionHandler");
			
			try
			{
				Session.Me.FillMe(Serializer.DeSerializeObject(event, "T_USER"));
				Logger.Instance.WriteProcess("USR_ID:" + Session.Me.ID, "SessionHandler");
				Session.Me.Photos.Fill(Serializer.DeSerializeArrayCollection(event, "T_USER_PHOTO"));
				Session.Me.Friends.Fill(Serializer.DeSerializeArrayCollection(event, "Table1"));
				Session.Me.Likes.Fill(Serializer.DeSerializeArrayCollection(event, "Table2"));
				
				dispatchEvent(new Event(FILLED));
			}
			catch (error:Error)
			{
				Logger.Instance.WriteError(error, "SessionHandler");
			}
		}
		protected function m_wsSessionFill_FAULT(event:FaultEvent):void
		{
			Logger.Instance.WriteFaultEvent(event, "SessionHandler");
		}
		
		// fill online members
		public function SessionFillOnlineMembers():void
		{
			m_wsSessionFillOnlineMembers = new FlexWS();
			m_wsSessionFillOnlineMembers.addEventListener(ResultEvent.RESULT, m_wsSessionFillOnlineMembers_RESULT);
			m_wsSessionFillOnlineMembers.addEventListener(FaultEvent.FAULT, m_wsSessionFillOnlineMembers_FAULT);
			m_wsSessionFillOnlineMembers.SessionFillOnlineMembers(ParHandler.Instance.SID);
		}
		protected function m_wsSessionFillOnlineMembers_RESULT(event:ResultEvent):void
		{
			Logger.Instance.WriteEvent(event, "SessionHandler");
			
			try
			{
				var ac:ArrayCollection = Serializer.DeSerializeArrayCollection(event, "T_USER");
				Session.Members.Fill(ac);
				Session.Members.FillMultipleMembersPhotos(Serializer.DeSerializeArrayCollection(event, "Table1"));
				Session.Members.FillMultipleMembersLikes(Serializer.DeSerializeArrayCollection(event, "Table2"));
				Session.Members.FillMultipleMembersFriends(Serializer.DeSerializeArrayCollection(event, "Table3"));
				Session.Members.FillMultipleMembersComms(Serializer.DeSerializeArrayCollection(event, "Table4"));
				Session.Members.CalculateDatePercentage();
				
				Session.BreakingNews.Fill(ac);
				
				dispatchEvent(new Event(MEMBERS_FILLED));
			}
			catch (error:Error)
			{
				Logger.Instance.WriteError(error, "SessionHandler");
			}
		}
		protected function m_wsSessionFillOnlineMembers_FAULT(event:FaultEvent):void
		{
			Logger.Instance.WriteFaultEvent(event, "SessionHandler");
		}
		
		// fill local members
		public function SessionFillLocalMembers():void
		{
			m_wsSessionFillLocalMembers = new FlexWS();
			m_wsSessionFillLocalMembers.addEventListener(ResultEvent.RESULT, m_wsSessionFillLocalMembers_RESULT);
			m_wsSessionFillLocalMembers.addEventListener(FaultEvent.FAULT, m_wsSessionFillLocalMembers_FAULT);
			m_wsSessionFillLocalMembers.SessionFillLocalMembers(ParHandler.Instance.SID);
		}
		protected function m_wsSessionFillLocalMembers_RESULT(event:ResultEvent):void
		{
			Logger.Instance.WriteEvent(event, "SessionHandler");
			
			try
			{
				var ac:ArrayCollection = Serializer.DeSerializeArrayCollection(event, "T_USER");
				Session.Members.Fill(ac);
				Session.Members.FillMultipleMembersPhotos(Serializer.DeSerializeArrayCollection(event, "Table1"));
				Session.Members.FillMultipleMembersLikes(Serializer.DeSerializeArrayCollection(event, "Table2"));
				Session.Members.FillMultipleMembersFriends(Serializer.DeSerializeArrayCollection(event, "Table3"));
				Session.Members.FillMultipleMembersComms(Serializer.DeSerializeArrayCollection(event, "Table4"));
				Session.Members.CalculateDatePercentage();
				
				Session.BreakingNews.Fill(ac);
			}
			catch (error:Error)
			{
				Logger.Instance.WriteError(error, "SessionHandler");
			}
		}
		protected function m_wsSessionFillLocalMembers_FAULT(event:FaultEvent):void
		{
			Logger.Instance.WriteFaultEvent(event, "SessionHandler");
		}
		
		// fill inbox
		public function SessionFillInbox():void
		{
			m_wsSessionFillInbox = new FlexWS();
			m_wsSessionFillInbox.addEventListener(ResultEvent.RESULT, m_wsSessionFillInbox_RESULT);
			m_wsSessionFillInbox.addEventListener(FaultEvent.FAULT, m_wsSessionFillInbox_FAULT);
			m_wsSessionFillInbox.SessionFillInbox(ParHandler.Instance.SID);
		}
		protected function m_wsSessionFillInbox_RESULT(event:ResultEvent):void
		{
			Logger.Instance.WriteEvent(event, "SessionHandler");
			
			try
			{
				Session.Inboxes.Fill(Serializer.DeSerializeArrayCollection(event, "T_USER_INBOX"));
				Session.Members.Fill(Serializer.DeSerializeArrayCollection(event, "Table1"));
				Session.Members.FillMultipleMembersPhotos(Serializer.DeSerializeArrayCollection(event, "Table2"));
				Session.Members.FillMultipleMembersLikes(Serializer.DeSerializeArrayCollection(event, "Table3"));
				Session.Members.FillMultipleMembersFriends(Serializer.DeSerializeArrayCollection(event, "Table4"));
				Session.Members.FillMultipleMembersComms(Serializer.DeSerializeArrayCollection(event, "Table5"));
				Session.Members.CalculateDatePercentage();
				
				dispatchEvent(new Event(INBOX_FILLED));
			}
			catch (error:Error)
			{
				Logger.Instance.WriteError(error, "SessionHandler");
			}
		}
		protected function m_wsSessionFillInbox_FAULT(event:FaultEvent):void
		{
			Logger.Instance.WriteFaultEvent(event, "SessionHandler");
		}
		
		// fill inbox
		public function SessionFillCreditsBalance():void
		{
			m_wsSessionFillCreditsBalance = new FlexWS();
			m_wsSessionFillCreditsBalance.addEventListener(ResultEvent.RESULT, m_wsSessionFillCreditsBalance_RESULT);
			m_wsSessionFillCreditsBalance.addEventListener(FaultEvent.FAULT, m_wsSessionFillCreditsBalance_FAULT);
			m_wsSessionFillCreditsBalance.SessionFillCreditsBalance(ParHandler.Instance.SID);
		}
		protected function m_wsSessionFillCreditsBalance_RESULT(event:ResultEvent):void
		{
			Logger.Instance.WriteEvent(event, "SessionHandler");
			
			try
			{
				var oUser:Object = Serializer.DeSerializeObject(event, "T_USER");
				SesHandler.Instance.Session.Me.CreditsBalance = oUser.USR_CREDITS_BALANCE;
			}
			catch (error:Error)
			{
				Logger.Instance.WriteError(error, "SessionHandler");
			}
		}
		protected function m_wsSessionFillCreditsBalance_FAULT(event:FaultEvent):void
		{
			Logger.Instance.WriteFaultEvent(event, "SessionHandler");
		}
	}
}