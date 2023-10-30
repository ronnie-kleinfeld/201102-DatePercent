package UI.Box.PopBox
{
	import UI.Box.BoxBase;
	import UI.Box.BoxMDI;
	
	import Utils.Log.Logger;
	
	import flash.geom.Point;
	import flash.utils.getQualifiedClassName;
	
	public class PopBoxBase extends BoxBase
	{
		protected var m_enumNodgePosition:int;
		
		protected override function SetLocation():void
		{
			if (m_buttonOpener != null)
			{
				var pointButtonOpenerLocal:Point = new Point(m_buttonOpener.x, m_buttonOpener.y);
				var pointButtonOpenerGlobal:Point = m_buttonOpener.localToGlobal(pointButtonOpenerLocal);
				var pointButtonOpenerLocalOnBoxMDI:Point = BoxMDI.GetBoxMDI.globalToLocal(pointButtonOpenerGlobal);
				
				switch (m_enumNodgePosition)
				{
					case NodgePositionEnum.NONE:
						break;
					case NodgePositionEnum.LEFT_TOP:
						this.x = m_buttonOpener.x + m_buttonOpener.width;
						this.y = Number(m_buttonOpener.y) + Number(m_buttonOpener.height) / 2 - 20 - 7;
						break;
					case NodgePositionEnum.LEFT_MIDDLE:
						this.x = m_buttonOpener.x + m_buttonOpener.width;
						this.y = Number(m_buttonOpener.y) + Number(m_buttonOpener.height) / 2 - this.height / 2;
						break;
					case NodgePositionEnum.LEFT_BOTTOM:
						this.x = m_buttonOpener.x + m_buttonOpener.width;
						this.y = Number(m_buttonOpener.y) + Number(m_buttonOpener.height) / 2 - this.height + 20 + 8;
						break;
					case NodgePositionEnum.RIGHT_TOP:
						this.x = m_buttonOpener.x - this.width;
						this.y = Number(m_buttonOpener.y) + Number(m_buttonOpener.height) / 2 - 20 - 7;
						break;
					case NodgePositionEnum.RIGHT_MIDDLE:
						this.x = m_buttonOpener.x - this.width;
						this.y = Number(m_buttonOpener.y) + Number(m_buttonOpener.height) / 2 - this.height / 2;
						break;
					case NodgePositionEnum.RIGHT_BOTTOM:
						this.x = m_buttonOpener.x - this.width;
						this.y = Number(m_buttonOpener.y) + Number(m_buttonOpener.height) / 2 - this.height + 20 + 8;
						break;
					case NodgePositionEnum.TOP_LEFT:
						this.x = Number(m_buttonOpener.x) + Number(m_buttonOpener.width) / 2 - 20 - 7;
						this.y = m_buttonOpener.y + m_buttonOpener.height;
						break;
					case NodgePositionEnum.TOP_MIDDLE:
						this.x = Number(m_buttonOpener.x) + Number(m_buttonOpener.width) / 2 - this.width / 2;
						this.y = m_buttonOpener.y + m_buttonOpener.height;
						break;
					case NodgePositionEnum.TOP_RIGHT:
						this.x = Number(m_buttonOpener.x) + Number(m_buttonOpener.width) / 2 - this.width + 20 + 8;
						this.y = m_buttonOpener.y + m_buttonOpener.height;
						break;
					case NodgePositionEnum.BOTTOM_LEFT:
						this.x = Number(m_buttonOpener.x) + Number(m_buttonOpener.width) / 2 - 20 - 7;
						this.y = m_buttonOpener.y - this.height;
						break;
					case NodgePositionEnum.BOTTOM_MIDDLE:
						this.x = Number(m_buttonOpener.x) + Number(m_buttonOpener.width) / 2 - this.width / 2;
						this.y = m_buttonOpener.y - this.height;
						break;
					case NodgePositionEnum.BOTTOM_RIGHT:
						this.x = Number(m_buttonOpener.x) + Number(m_buttonOpener.width) / 2 - this.width + 20 + 8;
						this.y = m_buttonOpener.y - this.height;
						break;
					default:
						Logger.Instance.WriteSwitchOutOfBoundError(m_enumNodgePosition.toString(), flash.utils.getQualifiedClassName(this));
						break;
				}
				
				this.x = this.x;
				this.y = this.y;
			}
		}
	}
}