package Enum
{
	import Handler.LocHandler;
	import Handler.SesHandler;
	
	import Handler.LocGeneratedCode;
	import Utils.Log.Logger;
	
	public class RadiusTypeEnum
	{
		public static const SMALL:int = 1;
		public static const MEDIUM:int = 5;
		public static const LARGE:int = 10;
		
		public static function RadiusLabel(p_iRadiusCode:int):String
		{
			var numRadius:Number;
			
			switch (p_iRadiusCode)
			{
				case RadiusTypeEnum.SMALL:
					numRadius = 1;
					break;
				case RadiusTypeEnum.MEDIUM:
					numRadius = 5;
					break;
				case RadiusTypeEnum.LARGE:
					numRadius = 10;
					break;
				default:
					Logger.Instance.WriteSwitchOutOfBoundError(p_iRadiusCode.toString(), "RadiusTypeEnum");
					numRadius = 10;
			}
			
			switch (SesHandler.Instance.Session.Me.DistanceUnitsCode)
			{
				case 2:
					numRadius = numRadius / 1.609344;
					break;
				default:
					numRadius = numRadius;
					break;
			}
			
			switch (SesHandler.Instance.Session.Me.DistanceUnitsCode)
			{
				case 2:
					if (numRadius < 1000)
					{
						return numRadius.toFixed(2) + " " + LocHandler.GS(LocGeneratedCode.of_a_Mile);
					}
					else
					{
						return numRadius.toFixed(2) + " " + LocHandler.GS(LocGeneratedCode.Miles);
					}
					break;
				default:
					if (numRadius < 1)
					{
						return (numRadius * 1000).toFixed() + " " + LocHandler.GS(LocGeneratedCode.Meter);
					}
					else
					{
						return numRadius.toFixed(2) + " " + LocHandler.GS(LocGeneratedCode.Km);
					}
					break;
			}
		}
	}
}