package UI.List
{
	import Handler.LocHandler;
	
	import UI.Sep.SepBase;
	import UI.Sep.VSep;
	
	import Utils.AS3.Embeded;
	import Handler.LocGeneratedCode;
	
	public class HListBase extends ListBase
	{
		// properties
		protected override function get Sep():SepBase
		{
			return new VSep();
		}
		
		// class
		public function HListBase()
		{
			super();
			
			m_classPrevPng = Embeded.s_imgListSmallLeft;
			m_classNextPng = Embeded.s_imgListSmallRight;
			m_strToolTipPrev = LocHandler.GS(LocGeneratedCode.Left);
			m_strToolTipNext = LocHandler.GS(LocGeneratedCode.Right);
		}
		
		// move
		protected override function InvalidatePrevNext():void
		{
			m_bPrevVisible = m_hvGroup.x < 0;
			m_bNextVisible = m_hvGroup.x + m_hvGroup.width > m_scroller.width || CollectionLength > m_hvGroup.numElements;;
		}
		
		protected override function DoMovePrev():void
		{
			m_move.xTo = m_hvGroup.x + m_scroller.width * 4 / 5;
			if (m_move.xTo > 0)
			{
				m_move.xTo = 0;
			}
			
			super.DoMovePrev();
		}
		protected override function DoMoveNext():void
		{
			m_move.xTo = m_hvGroup.x - m_scroller.width * 4 / 5;
			if (-m_move.xTo > m_hvGroup.width)
			{
				m_move.xTo = -m_hvGroup.width;
			}
			
			super.DoMoveNext();
		}
		
		public override function DoMoveStart():void
		{
			m_moveStartEnd.xTo = 0;
			
			super.DoMoveStart();
		}
		public override function DoMoveEnd():void
		{
			if (m_hvGroup.width > m_scroller.width)
			{
				m_moveStartEnd.xTo = -m_hvGroup.width + m_scroller.width;
				if (-m_move.xTo > m_hvGroup.width)
				{
					m_move.xTo = -m_hvGroup.width;
				}
			}
			
			super.DoMoveEnd();
		}
	}
}