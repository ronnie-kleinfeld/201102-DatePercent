package Data.Member
{
	import Data.Base.ObjectBase;
	
	public class LikeData extends ObjectBase
	{
		private var m_strObjectID:String;
		[Bindable] private var m_strName:String;
		[Bindable] public var Photo:PhotoData;
		public var IsLikesInCommon:Boolean;
		
		public function get ObjectID():String
		{
			return m_strObjectID;
		}
		public function get Name():String
		{
			return m_strName;
		}
		
		public function LikeData(p_iID:int, p_strObjectID:String, p_strName:String, p_photoData:PhotoData, p_bIsLikesInCommon:Boolean)
		{
			super(p_iID);
			
			m_strObjectID = p_strObjectID;
			m_strName = p_strName;
			Photo = p_photoData;
			IsLikesInCommon = p_bIsLikesInCommon;
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