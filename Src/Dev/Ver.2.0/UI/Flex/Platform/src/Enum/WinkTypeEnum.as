package Enum
{
	import Utils.AS3.Embeded;
	import Utils.Log.Logger;
	
	import flash.utils.getQualifiedClassName;
	
	public class WinkTypeEnum
	{
		public static function Image(value:int):Class
		{
			var oClass:Class;
			
			switch (value)
			{
				case 1:
					oClass = Embeded.s_imgTwink01;
					break;
				case 2:
					oClass = Embeded.s_imgTwink02;
					break;
				case 3:
					oClass = Embeded.s_imgTwink03;
					break;
				case 4:
					oClass = Embeded.s_imgTwink04;
					break;
				case 5:
					oClass = Embeded.s_imgTwink05;
					break;
				case 6:
					oClass = Embeded.s_imgTwink06;
					break;
				case 7:
					oClass = Embeded.s_imgTwink07;
					break;
				case 8:
					oClass = Embeded.s_imgTwink08;
					break;
				case 9:
					oClass = Embeded.s_imgTwink09;
					break;
				case 10:
					oClass = Embeded.s_imgTwink10;
					break;
				case 11:
					oClass = Embeded.s_imgTwink11;
					break;
				case 12:
					oClass = Embeded.s_imgTwink12;
					break;
				case 13:
					oClass = Embeded.s_imgTwink13;
					break;
				case 14:
					oClass = Embeded.s_imgTwink14;
					break;
				case 15:
					oClass = Embeded.s_imgTwink15;
					break;
				case 16:
					oClass = Embeded.s_imgTwink16;
					break;
				case 17:
					oClass = Embeded.s_imgTwink17;
					break;
				case 18:
					oClass = Embeded.s_imgTwink18;
					break;
				case 19:
					oClass = Embeded.s_imgTwink19;
					break;
				case 20:
					oClass = Embeded.s_imgTwink20;
					break;
				case 21:
					oClass = Embeded.s_imgTwink21;
					break;
				case 22:
					oClass = Embeded.s_imgTwink22;
					break;
				case 23:
					oClass = Embeded.s_imgTwink23;
					break;
				case 24:
					oClass = Embeded.s_imgTwink24;
					break;
				case 25:
					oClass = Embeded.s_imgTwink25;
					break;
				case 26:
					oClass = Embeded.s_imgTwink26;
					break;
				case 27:
					oClass = Embeded.s_imgTwink27;
					break;
				case 28:
					oClass = Embeded.s_imgTwink28;
					break;
				case 29:
					oClass = Embeded.s_imgTwink29;
					break;
				case 30:
					oClass = Embeded.s_imgTwink30;
					break;
				case 31:
					oClass = Embeded.s_imgTwink31;
					break;
				case 32:
					oClass = Embeded.s_imgTwink32;
					break;
				case 33:
					oClass = Embeded.s_imgTwink33;
					break;
				case 34:
					oClass = Embeded.s_imgTwink34;
					break;
				case 35:
					oClass = Embeded.s_imgTwink35;
					break;
				case 37:
					oClass = Embeded.s_imgTwink37;
					break;
				case 38:
					oClass = Embeded.s_imgTwink38;
					break;
				case 39:
					oClass = Embeded.s_imgTwink39;
					break;
				case 40:
					oClass = Embeded.s_imgTwink40;
					break;
				case 41:
					oClass = Embeded.s_imgTwink41;
					break;
				case 43:
					oClass = Embeded.s_imgTwink43;
					break;
				case 44:
					oClass = Embeded.s_imgTwink44;
					break;
				case 45:
					oClass = Embeded.s_imgTwink45;
					break;
				case 46:
					oClass = Embeded.s_imgTwink46;
					break;
				default:
					Logger.Instance.WriteSwitchOutOfBoundError(value.toString(), "WinkTypeEnum");
					break;
			}
			
			return oClass;
		}
	}
}