package UI.Button
{
	import Utils.AS3.Filters;
	import Utils.Log.Logger;
	
	import flash.events.MouseEvent;
	import flash.utils.getQualifiedClassName;
	
	import spark.components.Group;
	
	public class ButtonBase extends Group
	{
		[Bindable] public var m_strTooltip:String = "";
		private var m_bSelected:Boolean = false;
		
		[Bindable] public var m_png:Class = null;
		[Bindable] public var m_iPngPaddingLeft:int = 0;
		[Bindable] public var m_iPngPaddingRight:int = 0;
		
		[Bindable] public var m_strText:String = "";
		[Bindable] public var m_iLabelPaddingLeft:int = 0;
		[Bindable] public var m_iLabelPaddingRight:int = 0;
		[Bindable] public var m_iLabelPaddingTop:int = 0;
		[Bindable] public var m_strLabelHorizontalAlign:String = "center";
		[Bindable] public var m_iFontSize:int = 10;
		[Bindable] public var m_iFontColor:int = 0xffffff;
		
		public var m_strTag:String;
		
		// properties
		[Bindable]
		public function get Selected():Boolean
		{
			return m_bSelected;
		}
		public function set Selected(value:Boolean):void
		{
			m_bSelected = value;
			if (m_bSelected)
			{
				filters = [Filters.Selected];
			}
			else
			{
				filters = null;
			}
		}
		
		// class
		public function ButtonBase()
		{
			super();
			
			this.buttonMode = true;
			
			this.filters = null;
			
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
			
			m_png = null;
			
			this.filters = null;
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
			event.stopPropagation();
		}
	}
}