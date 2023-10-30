package UI.List
{
	import flash.events.Event;
	
	public class ListItemEvent extends Event
	{
		public static const LIST_ITEM_ADD:String = "LIST_ITEM_ADD";
		public static const LIST_ITEM_ADDED:String = "LIST_ITEM_ADDED";
		public static const LIST_ITEM_MOVE_TO_END:String = "LIST_ITEM_MOVE_TO_END";
		public static const LIST_ITEM_REMOVED:String = "LIST_ITEM_REMOVED";
		public static const LIST_ITEM_ROLL_OVER:String = "LIST_ITEM_ROLL_OVER";
		public static const LIST_ITEM_ROLL_OUT:String = "LIST_ITEM_ROLL_OUT";
		public static const LIST_ITEM_CLICKED:String = "LIST_ITEM_CLICKED";
		
		private var m_listItem:ListItemBase;
		private var m_funcPostMessageBox:Function;
		
		public function get ListItem():ListItemBase
		{
			return m_listItem;
		}
		public function get PostMessageBox():Function
		{
			return m_funcPostMessageBox;
		}
		
		public function ListItemEvent(type:String, p_listItem:ListItemBase, p_funcPostMessageBox:Function=null, bubbles:Boolean=false, cancelable:Boolean=false)
		{
			super(type, bubbles, cancelable);
			m_listItem = p_listItem;
			m_funcPostMessageBox = p_funcPostMessageBox;
		}
		public function Dispose():void
		{
			m_funcPostMessageBox = null;
			m_listItem = null;
		}
	}
}