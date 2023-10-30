package UI.Box
{
	import UI.Button.ButtonBase;
	import UI.Photo.PhotoBase;
	
	import flash.events.Event;
	
	import mx.effects.Fade;
	import mx.events.EffectEvent;
	
	import spark.components.Group;
	
	public class BoxBase extends Group
	{
		protected static const CLOSE:String = "CLOSE";
		protected static const HIDDEN:String = "HIDDEN";
		
		protected var m_buttonOpener:ButtonBase;
		protected var m_photoOpener:PhotoBase;
		
		private var m_fadeBox:Fade;
		private var m_fadeContent:Fade;
		
		public function BoxBase()
		{
			super();
			
			visible = false;
			
			m_fadeBox = new Fade();
			m_fadeBox.duration = 400;
			m_fadeBox.addEventListener(EffectEvent.EFFECT_END, m_fadeBox_EFFECT_END);
			
			m_fadeContent = new Fade();
			m_fadeContent.alphaFrom = 0;
			m_fadeContent.alphaTo = 1;
			m_fadeContent.duration = 400;
			m_fadeContent.addEventListener(EffectEvent.EFFECT_END, m_fadeContent_EFFECT_END);
		}
		public function Init(p_buttonOpener:ButtonBase, p_photoOpener:PhotoBase):void
		{
			m_buttonOpener = p_buttonOpener;
			m_photoOpener = p_photoOpener;
		}
		public function Dispose():void
		{
			try
			{
				if (m_fadeBox != null)
				{
					m_fadeBox.removeEventListener(EffectEvent.EFFECT_END, m_fadeBox_EFFECT_END);
					m_fadeBox = null;
				}
				
				if (m_fadeContent != null)
				{
					m_fadeContent.removeEventListener(EffectEvent.EFFECT_END, m_fadeContent_EFFECT_END);
					m_fadeContent = null;
				}
				
				if (m_buttonOpener != null)
				{
					m_buttonOpener.Selected = false;
					m_buttonOpener = null;
				}
				if (m_photoOpener != null)
				{
					m_photoOpener.Selected = false;
					m_photoOpener = null;
				}
			}
			catch (error:Error)
			{
			}
		}
		
		public function DoShowBox(p_boxCanvas:BoxCanvas):void
		{
			visible = true;
			SetLocation();
			
			m_fadeBox.target = p_boxCanvas;
			m_fadeBox.alphaFrom = 0;
			m_fadeBox.alphaTo = 1;
			m_fadeBox.play();
		}
		public function DoHideBox():void
		{
			try
			{		
				m_fadeBox.alphaFrom = 1;
				m_fadeBox.alphaTo = 0;
				m_fadeBox.play();
				
				if (m_buttonOpener != null)
				{
					m_buttonOpener.Selected = false;
				}
				if (m_photoOpener != null)
				{
					m_photoOpener.Selected = false;
				}
			}
			catch (error:Error)
			{
			}
		}
		protected function m_fadeBox_EFFECT_END(event:EffectEvent):void
		{
			if (m_fadeBox != null && m_fadeBox.alphaTo == 0)
			{
				dispatchEvent(new Event(HIDDEN));
			}
		}
		
		protected function SetLocation():void
		{
		}
		
		public function DoShowContent(p_boxContent:BoxContent):void
		{
			m_fadeContent.target = p_boxContent;
			m_fadeContent.play();
		}
		protected function m_fadeContent_EFFECT_END(event:EffectEvent):void
		{
		}
	}
}