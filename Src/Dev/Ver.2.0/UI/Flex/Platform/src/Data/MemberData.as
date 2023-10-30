package Data
{
	import Data.Base.CollectionEvent;
	import Data.Base.ObjectBase;
	import Data.Base.ObjectEvent;
	import Data.Member.CommDataCollection;
	import Data.Member.FriendDataCollection;
	import Data.Member.LikeDataCollection;
	import Data.Member.PhotoData;
	import Data.Member.PhotoDataCollection;
	
	import Enum.RadiusTypeEnum;
	
	import Handler.AppHandler;
	import Handler.LocHandler;
	import Handler.ParHandler;
	import Handler.SesHandler;
	
	import Utils.AS3.Const;
	import Utils.AS3.Embeded;
	import Handler.LocGeneratedCode;
	import Utils.Log.Logger;
	
	import com.mapquest.DistanceUnits;
	import com.mapquest.LatLng;
	
	import flash.utils.getQualifiedClassName;
	
	[Event(name=CollectionEvent.ZOOM_LEVEL_CHANGED, type=ObjectEvent)]
	[Event(name=MemberData.GPS_CHANGED, type=ObjectEvent)]
	public class MemberData extends ObjectBase
	{
		public static const GPS_CHANGED:String = "GPS_CHANGED";
		
		private var m_strUID:String;
		private var m_photoData:PhotoData = new PhotoData(-1, "", "http://" + ParHandler.Instance.IISServer + Const.NO_IMAGE_RELATIVE_PATH, "http://" + ParHandler.Instance.IISServer + Const.NO_IMAGE_RELATIVE_PATH);
		private var m_strNickName:String = LocHandler.GS(LocGeneratedCode.Nick_Name);
		private var m_dtBirthdate:Date = new Date(1990);
		private var m_iAge:int = -1;
		private var m_iSexCode:int = 1;
		private var m_gps:LatLng = new LatLng(48.85819, 2.294585);
		public var DistanceUnitsCode:int = 1;
		private var m_numDistanceKm:Number;
		[Bindable] public var m_bIsOnline:Boolean = false;
		private var m_numDatePercentage:Number = -1;
		private var m_numDatePercentageFactored:Number = -1;
		private var m_iRadius:int = 10;
		private var m_strPinUrl:String = "/Res/Platform/Pins/Green.png";
		[Bindable] public var IsLinked:Boolean = false;
		[Bindable] public var CreditsBalance:int;
		public var DontAskRemoveFromFavorites:Boolean = false;
		public var DontAskAddToFavorites:Boolean = false;
		public var DontAskBlockMember:Boolean = false;
		public var DontAskRemoveFromBlackList:Boolean = false;
		public var DontAskRemoveFromMyPhotos:Boolean = false;
		public var DontAskInvitationSend:Boolean = false;
		public var DontAskFeedbackSent:Boolean = false;
		public var DontAskReportSent:Boolean = false;
		public var DontAskProfileUpdated:Boolean = false;
		public var DontAskTwinkSent:Boolean = false;
		
		[Bindable] public var CommCount:int = 0;
		
		[Bindable] public var Photos:PhotoDataCollection;
		public var Friends:FriendDataCollection;
		public var Likes:LikeDataCollection;
		public var Comms:CommDataCollection;
		
		private var m_bIsMe:Boolean = false;
		
		public function get UID():String
		{
			return m_strUID;
		}
		[Bindable]
		public function get Photo():PhotoData
		{
			return m_photoData;
		}
		private function set Photo(value:PhotoData):void
		{
			m_photoData = value;
		}
		[Bindable]
		public function get NickName():String
		{
			return m_strNickName;
		}
		public function set NickName(value:String):void
		{
			m_strNickName = value;
		}
		public function get Birthdate():Date
		{
			return m_dtBirthdate;
		}
		[Bindable]
		public function get BirthdateLabel():String
		{
			var strResult:String;
			
			switch (Locale)
			{
				case "en":
					// mm/dd/yyyy
					strResult = (m_dtBirthdate.month + 1).toString() + "/" + m_dtBirthdate.date.toString() + "/" + m_dtBirthdate.fullYear.toString();
					break;
				case "el":
				case "eu":
				case "fr":
				case "zh":
				case "de":
				case "zh":
				case "hu":
				case "ar":
				case "ja":
				case "en":
				case "ko":
				case "lv":
				case "lt":
				case "ne":
				case "sl":
				case "af":
				case "sv":
				case "zh":
					// yyyy/mm/dd
					strResult = m_dtBirthdate.fullYear.toString() + "/" + (m_dtBirthdate.month + 1).toString() + "/" + m_dtBirthdate.date.toString();
					break;
				default:
					// dd/mm/yyyy
					Logger.Instance.WriteSwitchOutOfBoundError(Locale, flash.utils.getQualifiedClassName(this));
					strResult = m_dtBirthdate.date.toString() + "/" + (m_dtBirthdate.month + 1).toString() + "/" + m_dtBirthdate.fullYear.toString();
					break;
			}
			
			return strResult;
		}
		private function set BirthdateLabel(value:String):void
		{
			throw new Error("Override implementation missing");
		}
		public function get HoroscopeCode():int
		{
			var iHoroscopeCode:int;
			var iMonth:int = Birthdate.getMonth() + 1;
			var iDate:int = Birthdate.getDate();
			
			if (iMonth == 3 && iDate >= 21 || iMonth == 4 && iDate <=  19)
			{
				iHoroscopeCode = 1;
			}
			else if (iMonth == 4 && iDate >= 20 || iMonth == 5 && iDate <=  20)
			{
				iHoroscopeCode = 2;
			}
			else if (iMonth == 5 && iDate >= 21 || iMonth == 6 && iDate <=  20)
			{
				iHoroscopeCode = 3;
			}
			else if (iMonth == 6 && iDate >= 21 || iMonth == 7 && iDate <=  22)
			{
				iHoroscopeCode = 4;
			}
			else if (iMonth == 7 && iDate >= 23 || iMonth == 8 && iDate <=  22)
			{
				iHoroscopeCode = 5;
			}
			else if (iMonth == 8 && iDate >= 23 || iMonth == 9 && iDate <=  22)
			{
				iHoroscopeCode = 6;
			}
			else if (iMonth == 9 && iDate >= 23 || iMonth == 10 && iDate <=  22)
			{
				iHoroscopeCode = 7;
			}
			else if (iMonth == 10 && iDate >= 23 || iMonth == 11 && iDate <=  21)
			{
				iHoroscopeCode = 8;
			}
			else if (iMonth == 11 && iDate >= 22 || iMonth == 12 && iDate <=  21)
			{
				iHoroscopeCode = 9;
			}
			else if (iMonth == 12 && iDate >= 22 || iMonth == 1 && iDate <=  19)
			{
				iHoroscopeCode = 10;
			}
			else if (iMonth == 1 && iDate >= 20 || iMonth == 2 && iDate <=  18)
			{
				iHoroscopeCode = 11;
			}
			else if (iMonth == 2 && iDate >= 19 || iMonth == 3 && iDate <=  20)
			{
				iHoroscopeCode = 12;
			}
			else
			{
				Logger.Instance.WriteSwitchOutOfBoundError(Birthdate.toString(), flash.utils.getQualifiedClassName(this));
				iHoroscopeCode = 1;
			}
			
			return iHoroscopeCode;
		}
		[Bindable]
		public function get HoroscopePng():Class
		{
			var classHoroscopePng:Class;
			
			switch (HoroscopeCode)
			{
				case 1:
					classHoroscopePng = Embeded.s_imgHoroscope01aries;
					break;
				case 2:
					classHoroscopePng = Embeded.s_imgHoroscope02tarus;
					break;
				case 3:
					classHoroscopePng = Embeded.s_imgHoroscope03gemini;
					break;
				case 4:
					classHoroscopePng = Embeded.s_imgHoroscope04cancer;
					break;
				case 5:
					classHoroscopePng = Embeded.s_imgHoroscope05leo;
					break;
				case 6:
					classHoroscopePng = Embeded.s_imgHoroscope06virgo;
					break;
				case 7:
					classHoroscopePng = Embeded.s_imgHoroscope07libra;
					break;
				case 8:
					classHoroscopePng = Embeded.s_imgHoroscope08scorpio;
					break;
				case 9:
					classHoroscopePng = Embeded.s_imgHoroscope09sagitarios;
					break;
				case 10:
					classHoroscopePng = Embeded.s_imgHoroscope10capricorn;
					break;
				case 11:
					classHoroscopePng = Embeded.s_imgHoroscope11aqu;
					break;
				case 12:
					classHoroscopePng = Embeded.s_imgHoroscope12pisces;
					break;
				default:
					classHoroscopePng = Embeded.s_imgHoroscope01aries;
					Logger.Instance.WriteSwitchOutOfBoundError(HoroscopeCode.toString(), flash.utils.getQualifiedClassName(this));
					break;
			}
			
			return classHoroscopePng;
		}
		private function set HoroscopePng(value:Class):void
		{
			throw new Error("Override implementation missing");
		}
		[Bindable]
		public function get HoroscopeLabel():String
		{
			var strHoroscopeLabel:String;
			
			switch (HoroscopeCode)
			{
				case 1:
					strHoroscopeLabel = LocHandler.GS(LocGeneratedCode.Aries);
					break;
				case 2:
					strHoroscopeLabel = LocHandler.GS(LocGeneratedCode.Taurus);
					break;
				case 3:
					strHoroscopeLabel = LocHandler.GS(LocGeneratedCode.Gemini);
					break;
				case 4:
					strHoroscopeLabel = LocHandler.GS(LocGeneratedCode.Cancer);
					break;
				case 5:
					strHoroscopeLabel = LocHandler.GS(LocGeneratedCode.Leo);
					break;
				case 6:
					strHoroscopeLabel = LocHandler.GS(LocGeneratedCode.Virgo);
					break;
				case 7:
					strHoroscopeLabel = LocHandler.GS(LocGeneratedCode.Libra);
					break;
				case 8:
					strHoroscopeLabel = LocHandler.GS(LocGeneratedCode.Scorpio);
					break;
				case 9:
					strHoroscopeLabel = LocHandler.GS(LocGeneratedCode.Sagittarius);
					break;
				case 10:
					strHoroscopeLabel = LocHandler.GS(LocGeneratedCode.Capricorn);
					break;
				case 11:
					strHoroscopeLabel = LocHandler.GS(LocGeneratedCode.Aquarius);
					break;
				case 12:
					strHoroscopeLabel = LocHandler.GS(LocGeneratedCode.Pisces);
					break;
				default:
					strHoroscopeLabel = LocHandler.GS(LocGeneratedCode.Aries);
					Logger.Instance.WriteSwitchOutOfBoundError(HoroscopeCode.toString(), flash.utils.getQualifiedClassName(this));
					break;
			}
			
			return strHoroscopeLabel;
		}
		public function set HoroscopeLabel(value:String):void
		{
			throw new Error("Override implementation missing");
		}
		[Bindable]
		public function get Age():int
		{
			if (m_iAge == -1)
			{
				m_iAge = new Date().getFullYear() - Birthdate.getFullYear();
			}
			return m_iAge;
		}
		public function set Age(value:int):void
		{
			throw new Error("Override implementation missing");
		}
		public function get SexCode():int
		{
			return m_iSexCode;
		}
		public function get SexLabel():String
		{
			var strResult:String;
			
			switch (m_iSexCode)
			{
				case 1:
					strResult = LocHandler.GS(LocGeneratedCode.Male);
					break;
				case 2:
					strResult = LocHandler.GS(LocGeneratedCode.Female);
					break;
			}
			
			return strResult;
		}
		public function get GPS():LatLng
		{
			return m_gps;
		}
		public function set GPS(value:LatLng):void
		{
			m_gps = value;
			dispatchEvent(new ObjectEvent(GPS_CHANGED, this));
		}
		public function get DistanceUnitsLabel():String
		{
			switch (DistanceUnitsCode)
			{
				case 2:
					return LocHandler.GS(LocGeneratedCode.Miles);
					break;
				default:
					return LocHandler.GS(LocGeneratedCode.Km);
					break;
			}
		}
		public function get DistanceValue():Number
		{
			switch (DistanceUnitsCode)
			{
				case 2:
					return m_numDistanceKm / 1.609344;
					break;
				default:
					return m_numDistanceKm;
					break;
			}
		}
		[Bindable]
		public function get DistanceLabel():String
		{
			switch (DistanceUnitsCode)
			{
				case 2:
					if (DistanceValue < 1000)
					{
						return DistanceValue.toFixed(2) + " " + LocHandler.GS(LocGeneratedCode.of_a_Mile);
					}
					else
					{
						return DistanceValue.toFixed(2) + " " + LocHandler.GS(LocGeneratedCode.Miles);
					}
					break;
				default:
					if (DistanceValue < 1)
					{
						return (DistanceValue * 1000).toFixed() + " " + LocHandler.GS(LocGeneratedCode.Meter);
					}
					else
					{
						return DistanceValue.toFixed(2) + " " + LocHandler.GS(LocGeneratedCode.Km);
					}
					break;
			}
		}
		public function set DistanceLabel(value:String):void
		{
			throw new Error("Override implementation missing");
		}
		
		[Bindable]
		public function get IsOnline():Boolean
		{
			return m_bIsOnline;
		}
		private function set IsOnline(value:Boolean):void
		{
			m_bIsOnline = value;
		}
		public function IsOnlineToggler():void
		{
			m_bIsOnline = !m_bIsOnline;
		}
		
		public function get DatePercentageValue():Number
		{
			if (m_numDatePercentageFactored == -1)
			{
				CalculateDatePercentage();
			}
			return m_numDatePercentageFactored;
		}
		[Bindable]
		public function get DatePercentageLabel():String
		{
			return DatePercentageValue.toFixed(0) + "%";
		}
		private function set DatePercentageLabel(value:String):void
		{
			throw new Error("Override implementation missing");
		}
		public function get LocaleCode():String
		{
			return AppHandler.Instance.GetLocale.LCL_CODE;
		}
		public function get Locale():String
		{
			return ParHandler.Instance.Locale;
		}
		public function get LocaleNative():String
		{
			return AppHandler.Instance.GetLocale.LCL_NATIVE_NAME;
		}
		public function get Radius():int
		{
			return m_iRadius;
		}
		public function set Radius(value:int):void
		{
			m_iRadius = value;
			dispatchEvent(new ObjectEvent(ObjectEvent.ZOOM_LEVEL_CHANGED, this));
		}
		public function get ZoomLevel():int
		{
			switch (Radius)
			{
				case RadiusTypeEnum.SMALL:
					return 17;
					break;
				case RadiusTypeEnum.MEDIUM:
					return 14;
					break;
				case RadiusTypeEnum.LARGE:
					return 11;
					break;
				default:
					Logger.Instance.WriteSwitchOutOfBoundError(Radius.toString(), flash.utils.getQualifiedClassName(this));
					return 17;
					break;
			}
		}
		public function get PinUrl():String
		{
			return m_strPinUrl;
		}
		
		[Bindable]
		public function get IsMe():Boolean
		{
			return m_bIsMe;
		}
		private function set IsMe(value:Boolean):void
		{
			m_bIsMe = value;
		}
		
		public function MemberData(p_iID:int, p_bIsMe:Boolean)
		{
			super(p_iID);
			
			m_bIsMe = p_bIsMe;
			Photos = new PhotoDataCollection();
			Friends = new FriendDataCollection();
			Likes = new LikeDataCollection();
			Comms = new CommDataCollection();
		}
		public function InitMe(p_oUser:Object):void
		{
			this.ID = p_oUser.USR_ID;
			m_strUID = p_oUser.USR_UID;
			m_iSexCode = p_oUser.USR_SEX_CODE;
			m_photoData = new PhotoData(-1, "", p_oUser.USR_FB_PIC_URL, p_oUser.USR_FB_PICX_URL);
			NickName = p_oUser.USR_NICK_NAME;
			m_dtBirthdate = p_oUser.USR_BIRTHDAY;
			GPS = new LatLng(p_oUser.USR_LAT, p_oUser.USR_LNG);
			DistanceUnitsCode = p_oUser.USR_DISTANCE_UNITS_CODE;
			Radius = p_oUser.USR_RADIUS_KM;
			m_strPinUrl = p_oUser.USR_PIN_URL;
			CreditsBalance = p_oUser.USR_CREDITS_BALANCE;
			
			DontAskRemoveFromFavorites = p_oUser.USR_DONT_ASK_REMOVE_FROM_FAVORITES;
			DontAskAddToFavorites = p_oUser.USR_DONT_ASK_ADD_TO_FAVORITES;
			DontAskBlockMember = p_oUser.USR_DONT_ASK_BLOCK_MEMBER;
			DontAskRemoveFromBlackList = p_oUser.USR_DONT_ASK_REMOVE_FROM_BLACK_LIST;
			DontAskRemoveFromMyPhotos = p_oUser.USR_DONT_ASK_REMOVE_FROM_MY_PHOTOS;
			DontAskInvitationSend = p_oUser.USR_DONT_ASK_INVITATION_SENT;
			DontAskFeedbackSent = p_oUser.USR_DONT_ASK_FEEDBACK_SENT;
			DontAskReportSent = p_oUser.USR_DONT_ASK_REPORT_SENT;
			DontAskProfileUpdated = p_oUser.USR_DONT_ASK_PROFILE_UPDATED;
			DontAskTwinkSent = p_oUser.USR_DONT_ASK_TWINK_SENT;
		}
		public function FillMe(p_oUser:Object):void
		{
			this.ID = p_oUser.USR_ID;
			m_strUID = p_oUser.USR_UID;
			m_iSexCode = p_oUser.USR_SEX_CODE;
			m_photoData = new PhotoData(-1, "", p_oUser.USR_FB_PIC_URL, p_oUser.USR_FB_PICX_URL);
			NickName = p_oUser.USR_NICK_NAME;
			m_dtBirthdate = p_oUser.USR_BIRTHDAY;
			GPS = new LatLng(p_oUser.USR_LAT, p_oUser.USR_LNG);
			DistanceUnitsCode = p_oUser.USR_DISTANCE_UNITS_CODE;
			Radius = p_oUser.USR_RADIUS_KM;
			m_strPinUrl = p_oUser.USR_PIN_URL;
			
			m_bIsOnline = true;
			m_numDatePercentage = 0;
			m_numDatePercentageFactored = 0;
			CommCount = 0;
		}
		public function FillMember(p_oUser:Object):void
		{
			this.ID = p_oUser.USR_ID;
			m_strUID = p_oUser.USR_UID;
			m_iSexCode = p_oUser.USR_SEX_CODE;
			m_photoData = new PhotoData(-1, "", p_oUser.USR_FB_PIC_URL, p_oUser.USR_FB_PICX_URL);
			NickName = p_oUser.USR_NICK_NAME;
			m_dtBirthdate = p_oUser.USR_BIRTHDAY;
			GPS = new LatLng(p_oUser.USR_LAT, p_oUser.USR_LNG);
			DistanceUnitsCode = p_oUser.USR_DISTANCE_UNITS_CODE;
			m_numDistanceKm = Math.abs(GPS.arcDistance(SesHandler.Instance.Session.Me.GPS, DistanceUnits.KILOMETERS));
			Radius = p_oUser.USR_RADIUS_KM;
			m_strPinUrl = p_oUser.USR_PIN_URL;
			IsLinked = p_oUser.USL_LINK_TYPE_CODE != null;
			
			if (p_oUser.USL_IS_ONLINE == null)
			{
				m_bIsOnline = false;
			}
			else
			{
				m_bIsOnline = p_oUser.USL_IS_ONLINE;
			}
			m_numDatePercentage = 0;
			m_numDatePercentageFactored = 0;
			CommCount = 0;
		}
		public override function Dispose():void
		{
			super.Dispose();
			
			if (Comms != null)
			{
				Comms.Dispose();
				Comms = null;
			}
			if (Likes != null)
			{
				Likes.Dispose();
				Likes = null;
			}
			if (Friends != null)
			{
				Friends.Dispose();
				Friends = null;
			}
			if (Photos != null)
			{
				Photos.Dispose();
				Photos = null;
			}
			if (m_photoData != null)
			{
				m_photoData.Dispose();
				m_photoData = null;
			}
			
			GPS = null;
		}
		
		public function CalculateDatePercentage():Number
		{
			var numDatePercentage:Number = 0;
			
			try
			{
				// Distance - 30%
				if (m_numDistanceKm < 1000)
				{
					numDatePercentage += 30;
				}
				else if (m_numDistanceKm < 5000)
				{
					numDatePercentage += 20;
				}
				else if (m_numDistanceKm < 10000)
				{
					numDatePercentage += 10;
				}
				
				// Age Diff - 30%
				var iAgeDiff:int = SesHandler.Instance.Session.Me.Age - Age;
				if (SesHandler.Instance.Session.Me.SexCode == 1 && SexCode == 1)
				{
					if (Math.abs(iAgeDiff) < 5)
					{
						numDatePercentage += 30;
					}
					else if (Math.abs(iAgeDiff) < 10)
					{
						numDatePercentage += 20;
					}
					else if (Math.abs(iAgeDiff) < 15)
					{
						numDatePercentage += 10;
					}
				}
				else if (SesHandler.Instance.Session.Me.SexCode == 1 && SexCode == 2)
				{
					if (iAgeDiff >= 0 && iAgeDiff < 5)
					{
						numDatePercentage += 30;
					}
					else if (iAgeDiff >= 5 && iAgeDiff < 10)
					{
						numDatePercentage += 20;
					}
					else if (iAgeDiff >= 10 && iAgeDiff < 15)
					{
						numDatePercentage += 10;
					}
				}
				else if (SesHandler.Instance.Session.Me.SexCode == 2 && SexCode == 1)
				{
					if (iAgeDiff > -5 && iAgeDiff < 0)
					{
						numDatePercentage += 30;
					}
					else if (iAgeDiff > -10 && iAgeDiff <= -5)
					{
						numDatePercentage += 20;
					}
					else if (iAgeDiff > -15 && iAgeDiff <= -15)
					{
						numDatePercentage += 10;
					}
				}
				else if (SesHandler.Instance.Session.Me.SexCode == 2 && SexCode == 2)
				{
					if (Math.abs(iAgeDiff) < 5)
					{
						numDatePercentage += 30;
					}
					else if (Math.abs(iAgeDiff) < 10)
					{
						numDatePercentage += 20;
					}
					else if (Math.abs(iAgeDiff) < 15)
					{
						numDatePercentage += 10;
					}
				}
				else
				{
					Logger.Instance.WriteCritical("Unknown SexCode", "Me.SexCode:" + SesHandler.Instance.Session.Me.SexCode + "Member.SexCode" + SexCode, flash.utils.getQualifiedClassName(this));
				}
				
				// Things you both like - 30%
				if (Likes.CommonLength > 10)
				{
					numDatePercentage += 30;
				}
				else if (Likes.CommonLength > 5)
				{
					numDatePercentage += 20;
				}
				else if (Likes.CommonLength > 1)
				{
					numDatePercentage += 10;
				}
				
				// Mutual Friends - 10%
				if (Friends.CommonLength > 10)
				{
					numDatePercentage += 10;
				}
				else if (Friends.CommonLength > 5)
				{
					numDatePercentage += 7;
				}
				else if (Friends.CommonLength > 1)
				{
					numDatePercentage += 3;
				}
			}
			catch (error:Error)
			{
				Logger.Instance.WriteError(error, flash.utils.getQualifiedClassName(this));
				numDatePercentage = 80;
			}
			
			m_numDatePercentage = numDatePercentage;
			m_numDatePercentageFactored = m_numDatePercentage;
			
			return m_numDatePercentage;
		}
		public function CalculateDatePercentageFactor(p_numRatio:Number):void
		{
			m_numDatePercentageFactored = m_numDatePercentage * p_numRatio;
		}
		
		[Bindable]
		public function get IsFavorite():Boolean
		{
			return SesHandler.Instance.Session.Favorites.FindItemFavoriteDataByID(ID) != null;
		}
		private function set IsFavorite(value:Boolean):void
		{
		}
		
		public function CalculateCommCounts():void
		{
			var iCommCount:int = 0;
			
			for (var i:int = 0; i < Comms.Length; i++)
			{
				if (!Comms.FindItemCommDataByIndex(i).IsRead)
				{
					iCommCount++;
				}
			}
			
			CommCount = iCommCount;
		}
	}
}