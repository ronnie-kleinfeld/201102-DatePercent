package Data.Presents
{
	import Data.Base.ObjectBase;
	import Data.Member.PhotoData;
	
	public class PresentData extends ObjectBase
	{
		[Bindable] public var Photo:PhotoData;
		[Bindable] public var Name:String;
		[Bindable] public var Cost:int;
		
		public function PresentData(p_iID:int, p_photoData:PhotoData, p_strName:String, p_iCost:int)
		{
			super(p_iID);
			
			Photo = p_photoData;
			Name = p_strName;
			Cost = p_iCost;
		}
		public override function Dispose():void
		{
			super.Dispose();
			
			if (Photo != null)
			{
				Photo.Dispose();
				Photo = null;
			}
		}
	}
}