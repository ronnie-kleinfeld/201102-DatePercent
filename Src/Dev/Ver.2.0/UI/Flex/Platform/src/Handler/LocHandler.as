package Handler
{
	import Utils.Log.Logger;
	
	public class LocHandler
	{
		// singleton
		private static var s_dsInstance:LocHandler;
		
		public static function get Instance():LocHandler
		{
			if (s_dsInstance == null)
			{
				s_dsInstance = new LocHandler();
			}
			
			return s_dsInstance;
		}
		public static function GS(p_strCode:String):String
		{
			var strResult:String;
			
			try
			{
				strResult = LocHandler.Instance.m_aLocale[p_strCode];
				if (strResult == null || strResult == "")
				{
					strResult = LocHandler.Instance.m_aLocaleEn[p_strCode];
				}
			}
			catch (error:Error)
			{
				Logger.Instance.WriteCritical("Missing string for code:" + p_strCode, "", "LocHandler");
				strResult = p_strCode;
			}
			
			return strResult;
		}
		
		// members
		private var m_aLocale:Array;
		private var m_aLocaleEn:Array;
		
		// class
		public function LocHandler()
		{
			super();
			
			m_aLocaleEn = LocGeneratedCode.FillEn;
		}
		public function Init(p_strLocal:String):void
		{
			switch (p_strLocal.substring(0, 2).toUpperCase())
			{
				case "EN":
					m_aLocale = LocGeneratedCode.FillEn;
					break;
				case "AF":
					m_aLocale = LocGeneratedCode.FillAF;
					break;
				case "DE":
					m_aLocale = LocGeneratedCode.FillDE;
					break;
				case "SQ":
					m_aLocale = LocGeneratedCode.FillSQ;
					break;
				case "AR":
					m_aLocale = LocGeneratedCode.FillAR;
					break;
				case "HY":
					m_aLocale = LocGeneratedCode.FillHY;
					break;
				case "AZ":
					m_aLocale = LocGeneratedCode.FillAZ;
					break;
				case "EU":
					m_aLocale = LocGeneratedCode.FillEU;
					break;
				case "BE":
					m_aLocale = LocGeneratedCode.FillBE;
					break;
				case "BN":
					m_aLocale = LocGeneratedCode.FillBN;
					break;
				case "BG":
					m_aLocale = LocGeneratedCode.FillBG;
					break;
				case "CA":
					m_aLocale = LocGeneratedCode.FillCA;
					break;
				case "ZH":
					switch (p_strLocal.toUpperCase())
					{
						case "ZH_SM":
							m_aLocale = LocGeneratedCode.FillZH_SM;
							break;
						case "ZH_TR":
							m_aLocale = LocGeneratedCode.FillZH_TR;
							break;
						default:
							Logger.Instance.WriteCritical("Unsupported Locale:" + p_strLocal, "", "LocHandler");
							m_aLocale = LocGeneratedCode.FillEn;
							break;
					}
					break;
				case "HR":
					m_aLocale = LocGeneratedCode.FillHR;
					break;
				case "CS":
					m_aLocale = LocGeneratedCode.FillCS;
					break;
				case "DA":
					m_aLocale = LocGeneratedCode.FillDA;
					break;
				case "NL":
					m_aLocale = LocGeneratedCode.FillNL;
					break;
				case "EO":
					m_aLocale = LocGeneratedCode.FillEO;
					break;
				case "ET":
					m_aLocale = LocGeneratedCode.FillET;
					break;
				case "TL":
					m_aLocale = LocGeneratedCode.FillTL;
					break;
				case "FI":
					m_aLocale = LocGeneratedCode.FillFI;
					break;
				case "FR":
					m_aLocale = LocGeneratedCode.FillFR;
					break;
				case "GL":
					m_aLocale = LocGeneratedCode.FillGL;
					break;
				case "KA":
					m_aLocale = LocGeneratedCode.FillKA;
					break;
				case "EL":
					m_aLocale = LocGeneratedCode.FillEL;
					break;
				case "HE":
					m_aLocale = LocGeneratedCode.FillHE;
					break;
				case "HI":
					m_aLocale = LocGeneratedCode.FillHI;
					break;
				case "HU":
					m_aLocale = LocGeneratedCode.FillHU;
					break;
				case "IS":
					m_aLocale = LocGeneratedCode.FillIS;
					break;
				case "ID":
					m_aLocale = LocGeneratedCode.FillID;
					break;
				case "GA":
					m_aLocale = LocGeneratedCode.FillGA;
					break;
				case "IT":
					m_aLocale = LocGeneratedCode.FillIT;
					break;
				case "JA":
					m_aLocale = LocGeneratedCode.FillJA;
					break;
				case "KO":
					m_aLocale = LocGeneratedCode.FillKO;
					break;
				case "LA":
					m_aLocale = LocGeneratedCode.FillLA;
					break;
				case "LV":
					m_aLocale = LocGeneratedCode.FillLV;
					break;
				case "LT":
					m_aLocale = LocGeneratedCode.FillLT;
					break;
				case "MK":
					m_aLocale = LocGeneratedCode.FillMK;
					break;
				case "MS":
					m_aLocale = LocGeneratedCode.FillMS;
					break;
				case "NBNN":
					m_aLocale = LocGeneratedCode.FillNBNN;
					break;
				case "FA":
					m_aLocale = LocGeneratedCode.FillFA;
					break;
				case "PL":
					m_aLocale = LocGeneratedCode.FillPL;
					break;
				case "PT":
					m_aLocale = LocGeneratedCode.FillPT;
					break;
				case "RO":
					m_aLocale = LocGeneratedCode.FillRO;
					break;
				case "RU":
					m_aLocale = LocGeneratedCode.FillRU;
					break;
				case "SR":
					m_aLocale = LocGeneratedCode.FillSR;
					break;
				case "SK":
					m_aLocale = LocGeneratedCode.FillSK;
					break;
				case "SL":
					m_aLocale = LocGeneratedCode.FillSL;
					break;
				case "ES":
					m_aLocale = LocGeneratedCode.FillES;
					break;
				case "SW":
					m_aLocale = LocGeneratedCode.FillSW;
					break;
				case "SV":
					m_aLocale = LocGeneratedCode.FillSV;
					break;
				case "TA":
					m_aLocale = LocGeneratedCode.FillTA;
					break;
				case "TE":
					m_aLocale = LocGeneratedCode.FillTE;
					break;
				case "TH":
					m_aLocale = LocGeneratedCode.FillTH;
					break;
				case "TR":
					m_aLocale = LocGeneratedCode.FillTR;
					break;
				case "UK":
					m_aLocale = LocGeneratedCode.FillUK;
					break;
				case "VI":
					m_aLocale = LocGeneratedCode.FillVI;
					break;
				case "CY":
					m_aLocale = LocGeneratedCode.FillCY;
					break;
				default:
					Logger.Instance.WriteCritical("Unsupported Locale:" + p_strLocal, "", "LocHandler");
					m_aLocale = LocGeneratedCode.FillEn;
					break;
			}
		}
	}
}