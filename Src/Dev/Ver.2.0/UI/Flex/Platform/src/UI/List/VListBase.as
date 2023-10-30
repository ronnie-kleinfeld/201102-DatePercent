package UI.List
{
	import Handler.LocHandler;
	
	import UI.Sep.HSep;
	import UI.Sep.SepBase;
	
	import Utils.AS3.Embeded;
	import Handler.LocGeneratedCode;
	
	public class VListBase extends ListBase
	{
		protected override function get Sep():SepBase
		{
			return new HSep();
		}
		
		// class
		public function VListBase()
		{
			super();
			
			m_classPrevPng = Embeded.s_imgListSmallUp;
			m_classNextPng = Embeded.s_imgListSmallDown;
			m_strToolTipPrev = LocHandler.GS(LocGeneratedCode.Up);
			m_strToolTipNext = LocHandler.GS(LocGeneratedCode.Down);
		}
		
		// methods
		protected override function InvalidatePrevNext():void
		{
			try
			{
				m_bPrevVisible = m_hvGroup.y < 0;
				m_bNextVisible = m_hvGroup.y + m_hvGroup.height > m_scroller.height;
			}
			catch (error:Error)
			{
			}
		}
		
		protected override function DoMovePrev():void
		{
			m_move.yTo = m_hvGroup.y + m_scroller.height * 4 / 5;
			if (m_move.yTo > 0)
			{
				m_move.yTo = 0;
			}
			
			super.DoMovePrev();
		}
		protected override function DoMoveNext():void
		{
			m_move.yTo = m_hvGroup.y - m_scroller.height * 4 / 5;
			if (-m_move.yTo > m_hvGroup.height)
			{
				m_move.yTo = -m_hvGroup.height;
			}
			
			super.DoMoveNext();
		}
		
		public override function DoMoveStart():void
		{
			m_moveStartEnd.yTo = 0;
			
			super.DoMoveStart();
		}
		public override function DoMoveEnd():void
		{
			if (m_hvGroup.height > m_scroller.height)
			{
				m_moveStartEnd.yTo = -m_hvGroup.height + m_scroller.height;
				if (-m_move.yTo > m_hvGroup.height)
				{
					m_move.yTo = -m_hvGroup.height;
				}
			}
			
			super.DoMoveEnd();
		}
	}
}