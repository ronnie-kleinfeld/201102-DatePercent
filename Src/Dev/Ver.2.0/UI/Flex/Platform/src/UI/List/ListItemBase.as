package UI.List
{
	import Data.Base.ObjectBase;
	
	import Utils.Log.Logger;
	
	import flash.events.MouseEvent;
	import flash.utils.getQualifiedClassName;
	
	import mx.effects.Fade;
	import mx.effects.Resize;
	import mx.effects.Sequence;
	import mx.events.EffectEvent;
	
	import spark.components.Group;
	
	[Event(name=ListItemEvent.LIST_ITEM_ADDED, type=UI.List.ListItemEvent)]
	[Event(name=ListItemEvent.LIST_ITEM_MOVE_TO_END, type=UI.List.ListItemEvent)]
	[Event(name=ListItemEvent.LIST_ITEM_REMOVED, type=UI.List.ListItemEvent)]
	[Event(name=ListItemEvent.LIST_ITEM_ROLL_OVER, type=ListItemEvent)]
	[Event(name=ListItemEvent.LIST_ITEM_ROLL_OUT, type=UI.List.ListItemEvent)]
	[Event(name=ListItemEvent.LIST_ITEM_CLICKED, type=UI.List.ListItemEvent)]
	public class ListItemBase extends Group
	{
		public var m_list:ListBase;
		
		[Bindable] public var m_objectBase:ObjectBase;
		[Bindable] public var m_bAddSep:Boolean = false;
		
		private var m_sequenceAdd:Sequence;
		private var m_fadeAdd:Fade;
		private var m_resizeAdd:Resize;
		
		private var m_sequenceRemove:Sequence;
		private var m_fadeRemove:Fade;
		private var m_resizeRemove:Resize;
		
		protected function get WidthTo():Number
		{
			throw new Error("Override implementation missing");
		}
		protected function get HeightTo():Number
		{
			throw new Error("Override implementation missing");
		}
		
		public function ListItemBase()
		{
			this.buttonMode = true;
			
			this.addEventListener(MouseEvent.ROLL_OVER, rollOverHandler, false, 0, true);
			this.addEventListener(MouseEvent.ROLL_OUT, rollOutHandler, false, 0, true);
			this.addEventListener(MouseEvent.MOUSE_DOWN, mouseDownHandler, false, 0, true);
			this.addEventListener(MouseEvent.MOUSE_UP, mouseUpHandler, false, 0, true);
			this.addEventListener(MouseEvent.CLICK, clickHandler, false, 0, true);
		}
		public function Init(p_objectBase:ObjectBase):void
		{
			m_objectBase = p_objectBase;
		}
		public function Dispose():void
		{
			try
			{
				this.removeEventListener(MouseEvent.CLICK, clickHandler);
				this.removeEventListener(MouseEvent.MOUSE_UP, mouseUpHandler);
				this.removeEventListener(MouseEvent.MOUSE_DOWN, mouseDownHandler);
				this.removeEventListener(MouseEvent.ROLL_OUT, rollOutHandler);
				this.removeEventListener(MouseEvent.ROLL_OVER, rollOverHandler);
				
				if (m_resizeRemove != null)
				{
					m_resizeRemove = null;
				}
				if (m_fadeRemove != null)
				{
					m_fadeRemove = null;
				}
				if (m_sequenceRemove != null)
				{
					m_sequenceRemove.removeEventListener(EffectEvent.EFFECT_END, m_sequenceRemove_EFFECT_END);
					while (m_sequenceRemove.children.length > 0)
					{
						m_sequenceRemove.children.pop();
					}
					m_sequenceRemove = null;
				}
				
				if (m_resizeAdd != null)
				{
					m_resizeAdd = null;
				}
				if (m_fadeAdd != null)
				{
					m_fadeAdd = null;
				}
				if (m_sequenceAdd != null)
				{
					m_sequenceAdd.removeEventListener(EffectEvent.EFFECT_END, m_sequenceAdd_EFFECT_END);
					while (m_sequenceAdd.children.length > 0)
					{
						m_sequenceAdd.children.pop();
					}
					m_sequenceAdd = null;
				}
				
				m_objectBase = null;
				
				m_list = null;
			}
			catch (error:Error)
			{
			}
		}
		
		public function DoAdd():void
		{
			if (m_sequenceAdd == null)
			{
				m_sequenceAdd = new Sequence();
				m_sequenceAdd.target = this;
				m_sequenceAdd.startDelay = 100;
				m_sequenceAdd.addEventListener(EffectEvent.EFFECT_END, m_sequenceAdd_EFFECT_END);
				
				m_resizeAdd = new Resize();
				m_resizeAdd.widthTo = WidthTo;
				m_resizeAdd.heightTo = HeightTo;
				m_resizeAdd.duration = 400;
				m_sequenceAdd.addChild(m_resizeAdd);
				
				m_fadeAdd = new Fade();
				m_fadeAdd.alphaFrom = 0;
				m_fadeAdd.alphaTo = 1;
				m_fadeAdd.duration = 400;
				m_sequenceAdd.addChild(m_fadeAdd);
			}
			
			m_sequenceAdd.play();
		}
		protected function m_sequenceAdd_EFFECT_END(event:EffectEvent):void
		{
			Logger.Instance.WriteEvent(event, flash.utils.getQualifiedClassName(this));
			dispatchEvent(new ListItemEvent(ListItemEvent.LIST_ITEM_ADDED, this));
		}
		
		public function DoRemove():void
		{
			if (m_sequenceRemove == null)
			{
				m_sequenceRemove = new Sequence();
				m_sequenceRemove.target = this;
				m_sequenceRemove.startDelay = 500;
				m_sequenceRemove.addEventListener(EffectEvent.EFFECT_END, m_sequenceRemove_EFFECT_END);
				
				m_fadeRemove = new Fade();
				m_fadeRemove.alphaFrom = 1;
				m_fadeRemove.alphaTo = 0;
				m_fadeRemove.duration = 400;
				m_sequenceRemove.addChild(m_fadeRemove);
				
				m_resizeRemove = new Resize();
				m_resizeRemove.widthTo = 0;
				m_resizeRemove.heightTo = 0;
				m_resizeRemove.duration = 400;
				m_sequenceRemove.addChild(m_resizeRemove);
			}
			
			m_sequenceRemove.play();
		}
		private function m_sequenceRemove_EFFECT_END(event:EffectEvent):void
		{
			dispatchEvent(new ListItemEvent(ListItemEvent.LIST_ITEM_REMOVED, this));
			Dispose();
		}
		
		protected function rollOverHandler(event:MouseEvent):void
		{
			dispatchEvent(new ListItemEvent(ListItemEvent.LIST_ITEM_ROLL_OVER, this));
		}
		protected function rollOutHandler(event:MouseEvent):void
		{
			dispatchEvent(new ListItemEvent(ListItemEvent.LIST_ITEM_ROLL_OUT, this));
		}
		protected function mouseDownHandler(event:MouseEvent):void
		{
		}
		protected function mouseUpHandler(event:MouseEvent):void
		{
		}
		protected function clickHandler(event:MouseEvent):void
		{
			dispatchEvent(new ListItemEvent(ListItemEvent.LIST_ITEM_CLICKED, this));
		}
	}
}