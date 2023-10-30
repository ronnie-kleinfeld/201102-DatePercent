package UI.Box
{
	import Data.Member.PhotoData;
	
	import Platform.PlatformApp;
	
	import UI.Box.MessageBox.MessageBox;
	import UI.Box.MessageBox.MessageBoxEvent;
	import UI.Box.ModalBox.ModalBoxBase;
	import UI.Box.PopBox.PopBoxBase;
	
	import Utils.Log.Logger;
	
	import flash.events.Event;
	import flash.utils.getQualifiedClassName;
	
	import mx.managers.PopUpManager;
	
	import spark.components.Group;
	
	public class BoxMDI extends Group
	{
		protected static const CLOSE:String = "CLOSE";
		protected static const HIDDEN:String = "HIDDEN";
		
		// singleton
		private static var s_boxMDI:BoxMDI;
		public static function get GetBoxMDI():BoxMDI
		{
			return s_boxMDI;
		}
		public function set GetBoxMDI(value:BoxMDI):void
		{
			s_boxMDI = value;
		}
		
		// members
		public var m_platformApp:PlatformApp;
		
		private var m_messageBox:MessageBox;
		private var m_modalBoxBase:ModalBoxBase;
		private var m_popBoxBaseNonModal:PopBoxBase;
		private var m_popBoxBaseMember:PopBoxBase;
		private var m_popBoxBaseBalloon:PopBoxBase;
		
		// class
		public function BoxMDI()
		{
			super();
			
			this.minWidth = 0;
			this.minHeight = 0;
		}
		
		public function DoCloseAllBox():void
		{
			DoDisposeMessageBox();
			DoDisposeModalBox();
			DoCloseNonModalBox();
			DoCloseMemberBox();
			DoCloseBalloonBox();
		}
		
		// messageBox
		public function AddMessageBox(p_strTitle:String, p_strMessage:String, p_strDontAsk:String, p_photoData:PhotoData, p_strState:String = "Yes", p_funcPostModalBox:Function = null):void
		{
			Logger.Instance.WriteInformation("AddMessageBox:" + p_strMessage, flash.utils.getQualifiedClassName(this));
			if (m_messageBox == null)
			{
				m_messageBox = new MessageBox();
				m_messageBox.Init(null, null);
				m_messageBox.m_strLabel = p_strDontAsk;
				m_messageBox.addEventListener(MessageBox.YES, m_messageBox_YESNO, false, 0, true);
				m_messageBox.addEventListener(MessageBox.NO, m_messageBox_YESNO, false, 0, true);
				m_messageBox.addEventListener(HIDDEN, m_messageBox_HIDDEN, false, 0, true);
				PopUpManager.addPopUp(m_messageBox, this, true);
				PopUpManager.centerPopUp(m_messageBox);
				m_messageBox.GetData(p_strTitle, p_strMessage, p_photoData, p_strState, p_funcPostModalBox);
			}
			else
			{
				Logger.Instance.WriteCritical("MessageBox exists", "", flash.utils.getQualifiedClassName(this));
			}
		}
		private function m_messageBox_YESNO(event:MessageBoxEvent):void
		{
			Logger.Instance.WriteEvent(event, flash.utils.getQualifiedClassName(this));
			if (event.PostMessageBox != null)
			{
				event.PostMessageBox(event);
			}
			m_messageBox.DoHideBox();
		}
		private function m_messageBox_HIDDEN(event:Event):void
		{
			Logger.Instance.WriteEvent(event, flash.utils.getQualifiedClassName(this));
			DoDisposeMessageBox();
		}
		private function DoDisposeMessageBox():void
		{
			if (m_messageBox != null)
			{
				Logger.Instance.WriteInformation(m_messageBox.toString(), flash.utils.getQualifiedClassName(this));
				PopUpManager.removePopUp(m_messageBox);
				m_messageBox.addEventListener(HIDDEN, m_messageBox_HIDDEN, false, 0, true);
				m_messageBox.addEventListener(MessageBox.NO, m_messageBox_YESNO, false, 0, true);
				m_messageBox.addEventListener(MessageBox.YES, m_messageBox_YESNO, false, 0, true);
				m_messageBox.Dispose();
				m_messageBox = null;
			}
		}
		
		// modalBox
		public function AddModalBox(p_modalBoxBase:ModalBoxBase):void
		{
			Logger.Instance.WriteInformation(p_modalBoxBase.toString(), flash.utils.getQualifiedClassName(this));
			if (m_modalBoxBase == null)
			{
				m_modalBoxBase = p_modalBoxBase;
				m_modalBoxBase.addEventListener(CLOSE, m_modalBoxBase_CLOSE, false, 0, true);
				m_modalBoxBase.addEventListener(HIDDEN, m_modalBoxBase_HIDDEN, false, 0, true);
				PopUpManager.addPopUp(m_modalBoxBase, this, true);
			}
			else
			{
				Logger.Instance.WriteCritical("ModalBox exists", "", flash.utils.getQualifiedClassName(this));
			}
		}
		public function CenterModalBox(p_modalBoxBase:ModalBoxBase):void
		{
			Logger.Instance.WriteInformation("CenterModalBox", flash.utils.getQualifiedClassName(this));
			PopUpManager.centerPopUp(p_modalBoxBase);
		}
		private function m_modalBoxBase_CLOSE(event:Event):void
		{
			Logger.Instance.WriteEvent(event, flash.utils.getQualifiedClassName(this));
			m_modalBoxBase.DoHideBox();
		}
		private function m_modalBoxBase_HIDDEN(event:Event):void
		{
			Logger.Instance.WriteEvent(event, flash.utils.getQualifiedClassName(this));
			DoDisposeModalBox();
		}
		private function DoDisposeModalBox():void
		{
			if (m_modalBoxBase != null)
			{
				Logger.Instance.WriteInformation(m_modalBoxBase.toString(), flash.utils.getQualifiedClassName(this));
				PopUpManager.removePopUp(m_modalBoxBase);
				m_modalBoxBase.addEventListener(HIDDEN, m_modalBoxBase_HIDDEN, false, 0, true);
				m_modalBoxBase.addEventListener(CLOSE, m_modalBoxBase_CLOSE, false, 0, true);
				m_modalBoxBase.Dispose();
				m_modalBoxBase = null;
			}
		}
		
		// nonModal
		public function AddNonModalPopUp(p_popBoxBaseNonModal:PopBoxBase):void
		{
			Logger.Instance.WriteInformation(p_popBoxBaseNonModal.toString(), flash.utils.getQualifiedClassName(this));
			if (m_popBoxBaseNonModal != null)
			{
				DoDisposeNonModalBox();
			}
			
			m_popBoxBaseNonModal = p_popBoxBaseNonModal;
			m_popBoxBaseNonModal.addEventListener(CLOSE, m_popBoxBaseNonModal_CLOSE, false, 0, true);
			m_popBoxBaseNonModal.addEventListener(HIDDEN, m_popBoxBaseNonModal_HIDDEN, false, 0, true);
			this.addElement(m_popBoxBaseNonModal);
		}
		private function m_popBoxBaseNonModal_CLOSE(event:Event):void
		{
			Logger.Instance.WriteEvent(event, flash.utils.getQualifiedClassName(this));
			DoCloseNonModalBox();
		}
		public function DoCloseNonModalBox():void
		{
			if (m_popBoxBaseNonModal != null)
			{
				Logger.Instance.WriteInformation(m_popBoxBaseNonModal.toString(), flash.utils.getQualifiedClassName(this));
				m_popBoxBaseNonModal.DoHideBox();
			}
		}
		private function m_popBoxBaseNonModal_HIDDEN(event:Event):void
		{
			Logger.Instance.WriteEvent(event, flash.utils.getQualifiedClassName(this));
			DoDisposeNonModalBox();
		}
		private function DoDisposeNonModalBox():void
		{
			if (m_popBoxBaseNonModal !== null)
			{
				Logger.Instance.WriteInformation(m_popBoxBaseNonModal.toString(), flash.utils.getQualifiedClassName(this));
				this.removeElement(m_popBoxBaseNonModal);
				m_popBoxBaseNonModal.removeEventListener(HIDDEN, m_popBoxBaseNonModal_HIDDEN);
				m_popBoxBaseNonModal.removeEventListener(CLOSE, m_popBoxBaseNonModal_CLOSE);
				m_popBoxBaseNonModal.Dispose();
				m_popBoxBaseNonModal = null;
			}
		}
		
		// member
		public function AddMemberPopUp(p_popBoxBaseMember:PopBoxBase):void
		{
			Logger.Instance.WriteInformation(p_popBoxBaseMember.toString(), flash.utils.getQualifiedClassName(this));
			if (p_popBoxBaseMember != null)
			{
				DoDisposeMemberBox();
			}
			
			m_popBoxBaseMember = p_popBoxBaseMember;
			m_popBoxBaseMember.addEventListener(CLOSE, m_popBoxBaseMember_CLOSE, false, 0, true);
			m_popBoxBaseMember.addEventListener(HIDDEN, m_popBoxBaseMember_HIDDEN, false, 0, true);
			this.addElement(m_popBoxBaseMember);
		}
		private function m_popBoxBaseMember_CLOSE(event:Event):void
		{
			Logger.Instance.WriteEvent(event, flash.utils.getQualifiedClassName(this));
			DoCloseMemberBox();
		}
		public function DoCloseMemberBox():void
		{
			if (m_popBoxBaseMember != null)
			{
				Logger.Instance.WriteInformation(m_popBoxBaseMember.toString(), flash.utils.getQualifiedClassName(this));
				m_popBoxBaseMember.DoHideBox();
			}
		}
		private function m_popBoxBaseMember_HIDDEN(event:Event):void
		{
			Logger.Instance.WriteEvent(event, flash.utils.getQualifiedClassName(this));
			DoDisposeMemberBox();
		}
		private function DoDisposeMemberBox():void
		{
			if (m_popBoxBaseMember !== null)
			{
				Logger.Instance.WriteInformation(m_popBoxBaseMember.toString(), flash.utils.getQualifiedClassName(this));
				this.removeElement(m_popBoxBaseMember);
				m_popBoxBaseMember.removeEventListener(HIDDEN, m_popBoxBaseMember_HIDDEN);
				m_popBoxBaseMember.removeEventListener(CLOSE, m_popBoxBaseMember_CLOSE);
				m_popBoxBaseMember.Dispose();
				m_popBoxBaseMember = null;
			}
		}
		
		// balloon
		public function AddBalloonPopUp(p_popBoxBaseBalloon:PopBoxBase):void
		{
			Logger.Instance.WriteInformation(p_popBoxBaseBalloon.toString(), flash.utils.getQualifiedClassName(this));
			if (m_popBoxBaseBalloon != null)
			{
				DoDisposeBalloonBox();
			}
			
			m_popBoxBaseBalloon = p_popBoxBaseBalloon;
			m_popBoxBaseBalloon.addEventListener(CLOSE, m_popBoxBaseBalloon_CLOSE, false, 0, true);
			m_popBoxBaseBalloon.addEventListener(HIDDEN, m_popBoxBaseBalloon_HIDDEN, false, 0, true);
			this.addElement(m_popBoxBaseBalloon);
		}
		private function m_popBoxBaseBalloon_CLOSE(event:Event):void
		{
			Logger.Instance.WriteEvent(event, flash.utils.getQualifiedClassName(this));
			DoCloseBalloonBox();
		}
		public function DoCloseBalloonBox():void
		{
			if (m_popBoxBaseBalloon != null)
			{
				Logger.Instance.WriteInformation(m_popBoxBaseBalloon.toString(), flash.utils.getQualifiedClassName(this));
				m_popBoxBaseBalloon.DoHideBox();
			}
		}
		private function m_popBoxBaseBalloon_HIDDEN(event:Event):void
		{
			Logger.Instance.WriteEvent(event, flash.utils.getQualifiedClassName(this));
			DoDisposeBalloonBox();
		}
		private function DoDisposeBalloonBox():void
		{
			if (m_popBoxBaseBalloon !== null)
			{
				Logger.Instance.WriteInformation(m_popBoxBaseBalloon.toString(), flash.utils.getQualifiedClassName(this));
				this.removeElement(m_popBoxBaseBalloon);
				m_popBoxBaseBalloon.removeEventListener(HIDDEN, m_popBoxBaseBalloon_HIDDEN);
				m_popBoxBaseBalloon.removeEventListener(CLOSE, m_popBoxBaseBalloon_CLOSE);
				m_popBoxBaseBalloon.Dispose();
				m_popBoxBaseBalloon = null;
			}
		}
	}
}