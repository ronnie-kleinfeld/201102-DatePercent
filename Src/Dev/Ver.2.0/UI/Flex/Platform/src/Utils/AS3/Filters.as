package Utils.AS3
{
	import flash.filters.GlowFilter;
	
	import spark.filters.DropShadowFilter;
	
	public class Filters
	{
		private static var s_glowFilterMO:GlowFilter;
		private static var s_glowFilterSelected:GlowFilter;
		private static var s_dropShadowFilterSunken:DropShadowFilter;
		private static var s_dropShadowFilterShadow:DropShadowFilter;
		private static var s_glowFilter:GlowFilter;
		private static var s_datePercentageLowGlowFilter:GlowFilter;
		private static var s_datePercentageHighGlowFilter:GlowFilter;
		
		public static function get MO():GlowFilter
		{
			if (s_glowFilterMO == null)
			{
				s_glowFilterMO = new GlowFilter();
				s_glowFilterMO.blurX = 5;
				s_glowFilterMO.blurY = 5;
				s_glowFilterMO.alpha = 1;
				s_glowFilterMO.color = 0xcc0000;
				s_glowFilterMO.knockout = false;
				s_glowFilterMO.quality = 15;
				s_glowFilterMO.strength = 2;
				s_glowFilterMO.inner = false;
			}
			return s_glowFilterMO;
		}
		public static function get Selected():GlowFilter
		{
			if (s_glowFilterSelected == null)
			{
				s_glowFilterSelected = new GlowFilter();
				s_glowFilterSelected.blurX = 5;
				s_glowFilterSelected.blurY = 5;
				s_glowFilterSelected.alpha = 1;
				s_glowFilterSelected.color = 0x5fe632;
				s_glowFilterSelected.knockout = false;
				s_glowFilterSelected.quality = 15;
				s_glowFilterSelected.strength = 2;
				s_glowFilterSelected.inner = false;
			}
			return s_glowFilterSelected;
		}
		public static function get Sunken():DropShadowFilter
		{
			if (s_dropShadowFilterSunken == null)
			{
				s_dropShadowFilterSunken = new DropShadowFilter();
				s_dropShadowFilterSunken.angle = 45;
				s_dropShadowFilterSunken.blurX = 4;
				s_dropShadowFilterSunken.blurY = 4;
				s_dropShadowFilterSunken.distance = 4;
				s_dropShadowFilterSunken.alpha = 0.63;
				s_dropShadowFilterSunken.color = 0x000000;
				s_dropShadowFilterSunken.knockout = false;
				s_dropShadowFilterSunken.quality = 2;
				s_dropShadowFilterSunken.strength = 4;
				s_dropShadowFilterSunken.inner = true;
				s_dropShadowFilterSunken.hideObject = false;
			}
			return s_dropShadowFilterSunken;
		}
		public static function get Shadow():DropShadowFilter
		{
			if (s_dropShadowFilterShadow == null)
			{
				s_dropShadowFilterShadow = new DropShadowFilter();
				s_dropShadowFilterShadow.angle = 45;
				s_dropShadowFilterShadow.blurX = 4;
				s_dropShadowFilterShadow.blurY = 4;
				s_dropShadowFilterShadow.distance = 4;
				s_dropShadowFilterShadow.alpha = 0.63;
				s_dropShadowFilterShadow.color = 0x000000;
				s_dropShadowFilterShadow.knockout = false;
				s_dropShadowFilterShadow.quality = 2;
				s_dropShadowFilterShadow.strength = 4;
				s_dropShadowFilterShadow.inner = true;
				s_dropShadowFilterShadow.hideObject = false;
			}
			return s_dropShadowFilterSunken;
		}
		public static function get Glow():GlowFilter
		{
			if (s_glowFilter == null)
			{
				s_glowFilter = new GlowFilter();
				s_glowFilter.blurX = 3;
				s_glowFilter.blurY = 3;
				s_glowFilter.alpha = 1;
				s_glowFilter.color = 0xffffff;
				s_glowFilter.knockout = false;
				s_glowFilter.quality = 15;
				s_glowFilter.strength = 2;
				s_glowFilter.inner = false;
			}
			return s_glowFilter;
		}
		public static function get DatePercentageLowGlow():GlowFilter
		{
			if (s_datePercentageLowGlowFilter == null)
			{
				s_datePercentageLowGlowFilter = new GlowFilter();
				s_datePercentageLowGlowFilter.blurX = 3;
				s_datePercentageLowGlowFilter.blurY = 3;
				s_datePercentageLowGlowFilter.alpha = 1;
				s_datePercentageLowGlowFilter.color = 0x3399ff;
				s_datePercentageLowGlowFilter.knockout = false;
				s_datePercentageLowGlowFilter.quality = 15;
				s_datePercentageLowGlowFilter.strength = 2;
				s_datePercentageLowGlowFilter.inner = false;
			}
			return s_datePercentageLowGlowFilter;
		}
		public static function get DatePercentageHighGlow():GlowFilter
		{
			if (s_datePercentageHighGlowFilter == null)
			{
				s_datePercentageHighGlowFilter = new GlowFilter();
				s_datePercentageHighGlowFilter.blurX = 3;
				s_datePercentageHighGlowFilter.blurY = 3;
				s_datePercentageHighGlowFilter.alpha = 1;
				s_datePercentageHighGlowFilter.color = 0xff9933;
				s_datePercentageHighGlowFilter.knockout = false;
				s_datePercentageHighGlowFilter.quality = 15;
				s_datePercentageHighGlowFilter.strength = 2;
				s_datePercentageHighGlowFilter.inner = false;
			}
			return s_datePercentageHighGlowFilter;
		}
	}
}