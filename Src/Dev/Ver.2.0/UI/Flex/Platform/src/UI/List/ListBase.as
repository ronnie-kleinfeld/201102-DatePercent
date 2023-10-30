package UI.List
{
	import Data.Base.CollectionEvent;
	import Data.Base.ObjectBase;
	
	import UI.Sep.SepBase;
	
	import flash.events.TimerEvent;
	import flash.utils.Timer;
	
	import mx.collections.ArrayCollection;
	import mx.events.EffectEvent;
	import mx.events.FlexEvent;
	
	import spark.components.Group;
	import spark.components.Scroller;
	import spark.effects.Move;
	import spark.effects.easing.Sine;
	
	[Event(name=ListEvent.DO_FILL_STEP_FILLED, type="UI.List.ListEvent")]
	public class ListBase extends Group
	{
		protected var m_scroller:Scroller;
		protected var m_hvGroup:Group;
		
		protected var m_ac:ArrayCollection;
		
		protected var m_timerFill:Timer;
		public var m_iPaintedListItemCount:int = 10;
		public var m_iPaintedListItemStpes:int = 5;
		public var m_iPaintedListItemMaxCount:int = -1;
		
		private var m_sine:Sine;
		protected var m_move:Move;
		protected var m_moveStartEnd:Move;
		
		[Bindable] public var m_classPrevPng:Class;
		[Bindable] public var m_classNextPng:Class;
		
		[Bindable] public var m_bAddSep:Boolean = false;
		[Bindable] protected var m_strToolTipPrev:String = "";
		[Bindable] protected var m_strToolTipNext:String = "";
		[Bindable] protected var m_bPrevVisible:Boolean = false;
		[Bindable] protected var m_bNextVisible:Boolean = false;
		
		// properties
		protected function get DoFillByTimer():Boolean
		{
			throw new Error("Override implementation missing");
		}
		protected function get FillInterval():int
		{
			return 1000;
		}
		protected function get AddItemByCollectionEvent():Boolean
		{
			throw new Error("Override implementation missing");
		}
		protected function get CollectionLength():int
		{
			if (m_ac == null)
			{
				return 0;
			}
			else
			{
				return m_ac.length;
			}
		}
		
		protected function get Sep():SepBase
		{
			throw new Error("Override implementation missing");
		}
		
		// class
		public function ListBase()
		{
			super();
			
			this.addEventListener(FlexEvent.UPDATE_COMPLETE, updateCompleteHandler);
			
			m_timerFill = new Timer(FillInterval);
			m_timerFill.addEventListener(TimerEvent.TIMER, m_timerFill_TIMER);
			
			m_sine = new Sine();
			m_sine.easeInFraction = 0.6;
			
			m_move = new Move();
			m_move.easer = m_sine;
			m_move.addEventListener(EffectEvent.EFFECT_UPDATE, m_move_EFFECT_UPDATE);
			m_move.duration = 1500;
			
			m_moveStartEnd = new Move();
			m_moveStartEnd.easer = m_sine;
			m_moveStartEnd.addEventListener(EffectEvent.EFFECT_UPDATE, m_moveStartEnd_EFFECT_UPDATE);
			m_moveStartEnd.duration = 500;
		}
		public function Init(p_ac:ArrayCollection):void
		{
			m_ac = p_ac;
			if (m_iPaintedListItemCount > CollectionLength)
			{
				m_iPaintedListItemCount = CollectionLength;
			}
			
			m_ac.addEventListener(CollectionEvent.OBJECT_ADDED, collectionBase_OBJECT_ADDED);
			m_ac.addEventListener(CollectionEvent.OBJECT_ALLREADY_EXISTS, collectionBase_OBJECT_ALLREADY_EXISTS);
			m_ac.addEventListener(CollectionEvent.OBJECT_REMOVED, collectionBase_OBJECT_REMOVED);
		}
		public function Dispose():void
		{
			m_classNextPng = null;
			m_classPrevPng = null;
			
			if (m_moveStartEnd != null)
			{
				m_moveStartEnd.removeEventListener(EffectEvent.EFFECT_UPDATE, m_moveStartEnd_EFFECT_UPDATE);
				m_moveStartEnd.easer = null;
				m_moveStartEnd = null;
			}
			if (m_move != null)
			{
				m_move.removeEventListener(EffectEvent.EFFECT_UPDATE, m_move_EFFECT_UPDATE);
				m_move.easer = null;
				m_move = null;
			}
			m_sine = null;
			
			if (m_timerFill == null)
			{
				m_timerFill.stop();
				m_timerFill.removeEventListener(TimerEvent.TIMER, m_timerFill_TIMER);
				m_timerFill = null;
			}
			
			if (m_ac != null)
			{
				m_ac.removeEventListener(CollectionEvent.OBJECT_REMOVED, collectionBase_OBJECT_REMOVED);
				m_ac.removeEventListener(CollectionEvent.OBJECT_ALLREADY_EXISTS, collectionBase_OBJECT_ALLREADY_EXISTS);
				m_ac.removeEventListener(CollectionEvent.OBJECT_ADDED, collectionBase_OBJECT_ADDED);
				m_ac = null;
			}
			
			if (m_hvGroup != null)
			{
				while (m_hvGroup.numElements > 0)
				{
					var listItem:ListItemBase = ListItemBase(m_hvGroup.getElementAt(0));
					listItem.Dispose();
					m_hvGroup.removeElementAt(0);
				}
			}
			m_scroller = null;
			
			this.removeEventListener(FlexEvent.UPDATE_COMPLETE, updateCompleteHandler);
		}
		
		protected function updateCompleteHandler(event:FlexEvent):void
		{
			InvalidatePrevNext();
		}
		
		// fill
		public function DoFill():void
		{
			if (DoFillByTimer)
			{
				m_timerFill.start();
			}
			else
			{
				DoFillStep();
			}
		}
		
		private function m_timerFill_TIMER(event:TimerEvent):void
		{
			try
			{
				m_timerFill.stop();
				DoFillTimer();
			}
			finally
			{
				m_timerFill.start();
			}
		}
		public function StartFillTimer():void
		{
			m_timerFill.start();
		}
		public function StopFillTimer():void
		{
			m_timerFill.stop();
		}
		protected function DoFillTimer():void
		{
			throw new Error("Override implementation missing");
		}
		protected function DoFillStep():void
		{
		}
		
		// add
		protected function collectionBase_OBJECT_ADDED(event:CollectionEvent):void
		{
			throw new Error("Override implementation missing");
		}
		protected function AddListItem(p_listItem:ListItemBase, p_bAddAtIndexZero:Boolean):void
		{
			p_listItem.m_list = this;
			p_listItem.alpha = 0;
			p_listItem.width = 0;
			p_listItem.height = 0;
			p_listItem.m_bAddSep = m_bAddSep;
			p_listItem.addEventListener(FlexEvent.CREATION_COMPLETE, listItem_CREATION_COMPLETE, false, 0, true);
			p_listItem.addEventListener(ListItemEvent.LIST_ITEM_ADDED, listItem_LIST_ITEM_ADDED, false, 0, true);
			p_listItem.addEventListener(ListItemEvent.LIST_ITEM_MOVE_TO_END, listItem_LIST_ITEM_MOVE_TO_END, false, 0, true);
			p_listItem.addEventListener(ListItemEvent.LIST_ITEM_REMOVED, listItem_LIST_ITEM_REMOVED, false, 0, true);
			p_listItem.addEventListener(ListItemEvent.LIST_ITEM_CLICKED, listItem_LIST_ITEM_CLICKED, false, 0, true);
			p_listItem.addEventListener(ListItemEvent.LIST_ITEM_ROLL_OVER, listItem_LIST_ITEM_ROLL_OVER, false, 0, true);
			p_listItem.addEventListener(ListItemEvent.LIST_ITEM_ROLL_OUT, listItem_LIST_ITEM_ROLL_OUT, false, 0, true);
			
			if (p_bAddAtIndexZero)
			{
				m_hvGroup.addElementAt(p_listItem, 0);
			}
			else
			{
				m_hvGroup.addElement(p_listItem);
			}
			
			p_listItem.DoAdd();
			
			if (m_iPaintedListItemMaxCount > -1 && m_hvGroup.numElements > m_iPaintedListItemMaxCount)
			{
				var listItemBase:ListItemBase = ListItemBase(m_hvGroup.getElementAt(m_hvGroup.numElements - 1));
				DoRemoveListItemByObjectBase(listItemBase.m_objectBase);
			}
		}
		protected function listItem_LIST_ITEM_ADDED(event:ListItemEvent):void
		{
			InvalidatePrevNext();
		}
		protected function listItem_LIST_ITEM_MOVE_TO_END(event:ListItemEvent):void
		{
			DoMoveEnd();
		}
		protected function listItem_CREATION_COMPLETE(event:FlexEvent):void
		{
			InvalidatePrevNext();
		}
		
		// allready exists
		protected function collectionBase_OBJECT_ALLREADY_EXISTS(event:CollectionEvent):void
		{
			// overriden in ActiveBarList
		}
		
		// remove
		protected function collectionBase_OBJECT_REMOVED(event:CollectionEvent):void
		{
			DoRemoveListItemByObjectBase(event.ObjectData);
		}
		protected function DoRemoveListItemByObjectBase(p_objectBase:ObjectBase):void
		{
			var listItemBase:ListItemBase = FindListItemByID(p_objectBase.ID);
			if (listItemBase != null)
			{
				listItemBase.DoRemove();
			}
		}
		protected function listItem_LIST_ITEM_REMOVED(event:ListItemEvent):void
		{
			m_hvGroup.removeElement(event.ListItem);
			DisposeListItem(event.ListItem);
			InvalidatePrevNext();
		}
		protected function DisposeListItem(p_listItem:ListItemBase):void
		{
			if (p_listItem != null)
			{
				p_listItem.Dispose();
				p_listItem.removeEventListener(ListItemEvent.LIST_ITEM_ROLL_OUT, listItem_LIST_ITEM_ROLL_OUT);
				p_listItem.removeEventListener(ListItemEvent.LIST_ITEM_ROLL_OVER, listItem_LIST_ITEM_ROLL_OVER);
				p_listItem.removeEventListener(ListItemEvent.LIST_ITEM_CLICKED, listItem_LIST_ITEM_CLICKED);
				p_listItem.removeEventListener(ListItemEvent.LIST_ITEM_REMOVED, listItem_LIST_ITEM_REMOVED);
				p_listItem.removeEventListener(ListItemEvent.LIST_ITEM_MOVE_TO_END, listItem_LIST_ITEM_MOVE_TO_END);
				p_listItem.removeEventListener(ListItemEvent.LIST_ITEM_ADDED, listItem_LIST_ITEM_ADDED);
				p_listItem.removeEventListener(FlexEvent.CREATION_COMPLETE, listItem_CREATION_COMPLETE);
				p_listItem = null;
			}
		}
		
		// interaction
		protected function listItem_LIST_ITEM_CLICKED(event:ListItemEvent):void
		{
		}
		protected function listItem_LIST_ITEM_ROLL_OVER(event:ListItemEvent):void
		{
			if (DoFillByTimer)
			{
				m_timerFill.stop();
			}
		}
		protected function listItem_LIST_ITEM_ROLL_OUT(event:ListItemEvent):void
		{
			if (DoFillByTimer)
			{
				m_timerFill.start();
			}
		}
		
		// move
		protected function InvalidatePrevNext():void
		{
			throw new Error("Override implementation missing");
		}
		
		private function IncrementPaintedListItemCount():void
		{
			m_iPaintedListItemCount = m_iPaintedListItemCount + m_iPaintedListItemStpes;
			if (m_iPaintedListItemCount > CollectionLength)
			{
				m_iPaintedListItemCount = CollectionLength;
			}
		}
		
		protected function DoMovePrev():void
		{
			m_move.target = m_hvGroup;
			m_move.end();
			m_move.play();
		}
		protected function DoMoveNext():void
		{
			m_move.target = m_hvGroup;
			m_move.end();
			m_move.play();
			IncrementPaintedListItemCount();
			DoFill();
		}
		private function m_move_EFFECT_UPDATE(event:EffectEvent):void
		{
			InvalidatePrevNext();
		}
		
		public function DoMoveStart():void
		{
			try
			{
				m_moveStartEnd.target = m_hvGroup;
				m_moveStartEnd.end();
				m_moveStartEnd.play();
			}
			catch (error:Error)
			{
			}
		}
		public function DoMoveEnd():void
		{
			try
			{
				m_moveStartEnd.target = m_hvGroup;
				m_moveStartEnd.end();
				m_moveStartEnd.play();
			}
			catch (error:Error)
			{
			}
		}
		protected function m_moveStartEnd_EFFECT_UPDATE(event:EffectEvent):void
		{
		}
		
		// utils
		protected function FindListItemByID(p_iID:int):ListItemBase
		{
			for (var i:int = 0; i < m_hvGroup.numElements; i++)
			{
				var listItemBase:ListItemBase = ListItemBase(m_hvGroup.getElementAt(i));
				
				if (listItemBase.m_objectBase.ID == p_iID)
				{
					return listItemBase;
				}
			}
			
			return null;
		}
	}
}