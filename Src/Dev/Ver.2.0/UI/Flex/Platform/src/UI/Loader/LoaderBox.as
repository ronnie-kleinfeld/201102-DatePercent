package UI.Loader
{
	import Utils.AS3.Embeded;
	import Utils.Log.Logger;
	
	import flash.utils.getQualifiedClassName;
	
	import mx.events.FlexEvent;
	
	import spark.components.VGroup;
	
	public class LoaderBox extends VGroup
	{
		public static const SMALL:String = "SMALL";
		public static const MEDIUM:String = "MEDIUM";
		public static const LARGE:String = "LARGE";
		
		[Bindable] public var m_strSize:String = SMALL;
		private var m_numLoaderItemSize:Number = 7;
		private var m_pngClass:Class = Embeded.s_imgLoader;
		private var m_numRadius:Number;
		
		public function LoaderBox()
		{
			super();
			
			this.setStyle("horizontalAlign", "center");
			this.setStyle("verticalAlign", "middle");
			
			this.addEventListener(FlexEvent.CREATION_COMPLETE, creationCompleteHandler);
		}
		public function Dispose():void
		{
			while (this.numElements > 0)
			{
				var loaderItem:LoaderItem = LoaderItem(removeElementAt(0));
				loaderItem.Dispose();
				loaderItem = null;
			}
			
			this.removeEventListener(FlexEvent.CREATION_COMPLETE, creationCompleteHandler);
			
			m_pngClass = null;
		}
		
		private function creationCompleteHandler(event:FlexEvent):void
		{
			switch (m_strSize)
			{
				case SMALL:
					this.width = 24;
					this.height = 24;
					m_numLoaderItemSize = 9;
					m_pngClass = Embeded.s_imgLoader;
					break;
				case MEDIUM:
					this.width = 36;
					this.height = 36;
					m_numLoaderItemSize = 9;
					m_pngClass = Embeded.s_imgLoader;
					break;
				case LARGE:
					this.width = 50;
					this.height = 50;
					m_numLoaderItemSize = 9;
					m_pngClass = Embeded.s_imgLoader;
					break;
				default:
					Logger.Instance.WriteSwitchOutOfBoundError(m_strSize, flash.utils.getQualifiedClassName(this));
			}
			m_numRadius = this.width / 2 - 2;
			
			var loaderItem:LoaderItem;
			for (var i:int=0; i<360; i=i+30)
			{
				loaderItem = new LoaderItem();
				loaderItem.m_pngClass = m_pngClass;
				loaderItem.m_numLoaderItemSize = m_numLoaderItemSize;
				loaderItem.m_iTick = 12 - i / 30;
				loaderItem.width = m_numLoaderItemSize;
				loaderItem.height = m_numLoaderItemSize;
				loaderItem.x = 4 + m_numRadius / 2 + m_numRadius * Math.sin(i * Math.PI / 180);
				loaderItem.y = 4 + m_numRadius / 2 + m_numRadius * Math.cos(i * Math.PI / 180);
				this.addElement(loaderItem);
			}
		}
	}
}