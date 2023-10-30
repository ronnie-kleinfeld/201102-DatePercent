package UI.Loader
{
	import flash.filters.GlowFilter;
	
	import mx.controls.Image;
	import mx.effects.AnimateProperty;
	import mx.events.EffectEvent;
	import mx.events.FlexEvent;
	
	import spark.components.Group;
	
	public class LoaderItem extends Group
	{
		private var m_image:Image;
		public var m_numLoaderItemSize:Number;
		public var m_pngClass:Class;
		public var m_iTick:int;
		
		private var m_animatePropertyAlpha:AnimateProperty;
		
		private var m_animatePropertyFilter:AnimateProperty;
		private var m_glowFilter:GlowFilter;
		
		public function LoaderItem()
		{
			m_image = new Image();
			m_image.alpha = 0;
			this.addElement(m_image);
			
			m_animatePropertyAlpha = new AnimateProperty();
			m_animatePropertyAlpha.property = "alpha";
			m_animatePropertyAlpha.fromValue = 1;
			m_animatePropertyAlpha.toValue = 0;
			m_animatePropertyAlpha.duration = 1200;
			m_animatePropertyAlpha.target = m_image;
			m_animatePropertyAlpha.addEventListener(EffectEvent.EFFECT_END, m_animatePropertyAlpha_EFFECT_END);
			
			m_glowFilter = new GlowFilter();
			m_glowFilter.blurX = 3;
			m_glowFilter.blurY = 3;
			m_glowFilter.alpha = 1;
			m_glowFilter.color = 0xffffff;
			m_glowFilter.knockout = false;
			m_glowFilter.quality = 10;
			m_glowFilter.strength = 2;
			m_glowFilter.inner = false;
			this.filters = [m_glowFilter];
			
			m_animatePropertyFilter = new AnimateProperty();
			m_animatePropertyFilter.property = "quality";
			m_animatePropertyFilter.fromValue = 10;
			m_animatePropertyFilter.toValue = 0;
			m_animatePropertyFilter.startDelay = 300;
			m_animatePropertyFilter.duration = 1200;
			m_animatePropertyFilter.target = m_glowFilter;
			m_animatePropertyFilter.addEventListener(EffectEvent.EFFECT_END, m_animatePropertyFilter_EFFECT_END);
			
			this.addEventListener(FlexEvent.CREATION_COMPLETE, creationCompleteHandler);
		}
		public function Dispose():void
		{
			this.removeEventListener(FlexEvent.CREATION_COMPLETE, creationCompleteHandler);
			
			if (m_animatePropertyFilter != null)
			{
				m_animatePropertyFilter.removeEventListener(EffectEvent.EFFECT_END, m_animatePropertyFilter_EFFECT_END);
				m_animatePropertyFilter.target = null;
				m_animatePropertyFilter = null;
			}
			
			this.filters = null;
			m_glowFilter = null;
			
			if (m_animatePropertyAlpha != null)
			{
				m_animatePropertyAlpha.removeEventListener(EffectEvent.EFFECT_END, m_animatePropertyAlpha_EFFECT_END);
				m_animatePropertyAlpha.target = null;
				m_animatePropertyAlpha = null;
			}
			
			if (m_image != null)
			{
				m_image.source = null;
				m_image.unloadAndStop();
				this.removeElement(m_image);
				m_image = null;
			}
			
			m_pngClass = null;
		}
		
		private function creationCompleteHandler(event:FlexEvent):void
		{
			this.width = m_numLoaderItemSize;
			this.height = m_numLoaderItemSize;
			
			m_image.source = m_pngClass;
			m_image.percentWidth = 100;
			m_image.percentHeight = 100;
			
			m_animatePropertyFilter.startDelay = 300 + 100 * m_iTick;
			m_animatePropertyAlpha.startDelay = 100 * m_iTick;
			
			m_animatePropertyFilter.play();
			m_animatePropertyAlpha.play();
		}
		
		private function m_animatePropertyFilter_EFFECT_END(event:EffectEvent):void
		{
			m_animatePropertyFilter.startDelay = 0;
			m_animatePropertyFilter.play();
		}
		private function m_animatePropertyAlpha_EFFECT_END(event:EffectEvent):void
		{
			m_animatePropertyAlpha.startDelay = 0;
			m_animatePropertyAlpha.play();
		}
	}
}