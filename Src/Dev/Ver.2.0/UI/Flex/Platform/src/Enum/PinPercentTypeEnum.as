package Enum
{
	import Utils.AS3.Embeded;
	import Utils.AS3.Filters;
	
	import flash.display.DisplayObject;
	import flash.filters.GlowFilter;
	
	public class PinPercentTypeEnum
	{
		public static function Color(p_numDatePercentageValue:Number):Number
		{
			if (p_numDatePercentageValue > 85)
			{
				return 0xff9933;
			}
			else
			{
				return 0x3399ff;
			}
		}
		public static function Filter(p_numDatePercentageValue:Number):GlowFilter
		{
			if (p_numDatePercentageValue > 85)
			{
				return Utils.AS3.Filters.DatePercentageHighGlow;
			}
			else
			{
				return Utils.AS3.Filters.DatePercentageLowGlow;
			}
		}
	}
}