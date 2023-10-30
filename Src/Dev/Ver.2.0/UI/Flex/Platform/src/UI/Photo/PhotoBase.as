package UI.Photo
{
	import Data.Member.PhotoData;
	
	import Utils.AS3.Filters;
	import Utils.Log.Logger;
	
	import flash.events.MouseEvent;
	import flash.utils.getQualifiedClassName;
	
	import spark.components.BorderContainer;
	
	public class PhotoBase extends BorderContainer
	{
		[Bindable] public var m_iSize:int = 49;
		private var m_bSelected:Boolean = false;
		
		[Bindable] public var Photo:PhotoData;
		[Bindable] public var m_strTooltip:String = "";
		
		// properties
		public function get Selected():Boolean
		{
			return m_bSelected;
		}
		[Bindable]
		public function set Selected(value:Boolean):void
		{
			m_bSelected = value;
			if (m_bSelected)
			{
				filters = [Utils.AS3.Filters.Selected];
			}
			else
			{
				filters = null;
			}
		}
		
		// class
		public function PhotoBase()
		{
			super();
			
			this.buttonMode = true;
			
			this.filters = null;
			this.setStyle("borderColor", 0x3399ff);
			this.setStyle("borderColor", 0x3399ff);
			this.setStyle("borderWeight", 2);
			this.setStyle("cornerRadius", 6);
			
			this.addEventListener(MouseEvent.ROLL_OVER, rollOverHandler, false, 0, true);
			this.addEventListener(MouseEvent.ROLL_OUT, rollOutHandler, false, 0, true);
			this.addEventListener(MouseEvent.MOUSE_DOWN, mouseDownHandler, false, 0, true);
			this.addEventListener(MouseEvent.MOUSE_UP, mouseUpHandler, false, 0, true);
			this.addEventListener(MouseEvent.CLICK, clickHandler, false, 0, true);
			
			this.toolTip = m_strTooltip;
		}
		public function Dispose():void
		{
			this.removeEventListener(MouseEvent.CLICK, clickHandler);
			this.removeEventListener(MouseEvent.MOUSE_UP, mouseUpHandler);
			this.removeEventListener(MouseEvent.MOUSE_DOWN, mouseDownHandler);
			this.removeEventListener(MouseEvent.ROLL_OUT, rollOutHandler);
			this.removeEventListener(MouseEvent.ROLL_OVER, rollOverHandler);
			
			this.filters = null;
			
			if (Photo != null)
			{
				Photo.Dispose();
				Photo = null;
			}
		}
		
		//events
		protected function rollOverHandler(event:MouseEvent):void
		{
			Logger.Instance.WriteEvent(event, flash.utils.getQualifiedClassName(this));
			event.stopPropagation();
		}
		protected function rollOutHandler(event:MouseEvent):void
		{
			Logger.Instance.WriteEvent(event, flash.utils.getQualifiedClassName(this));
			event.stopPropagation();
		}
		protected function mouseDownHandler(event:MouseEvent):void
		{
			Logger.Instance.WriteEvent(event, flash.utils.getQualifiedClassName(this));
			event.stopPropagation();
		}
		protected function mouseUpHandler(event:MouseEvent):void
		{
			Logger.Instance.WriteEvent(event, flash.utils.getQualifiedClassName(this));
			event.stopPropagation();
		}
		protected function clickHandler(event:MouseEvent):void
		{
			Logger.Instance.WriteEvent(event, flash.utils.getQualifiedClassName(this));
		}
	}
}