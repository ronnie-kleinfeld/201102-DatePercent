package UI.Box.ModalBox
{
	import UI.Box.BoxBase;
	
	import mx.managers.PopUpManager;
	
	public class ModalBoxBase extends BoxBase
	{
		protected override function SetLocation():void
		{
			PopUpManager.centerPopUp(this);
		}
	}
}