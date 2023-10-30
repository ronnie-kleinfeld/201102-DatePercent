package Data.Member
{
	import Data.Base.CollectionBase;
	
	import mx.collections.ArrayCollection;
	
	public class CreditDataCollection extends CollectionBase
	{
		public function AddItemCreditData(p_creditData:CreditData):void
		{
			this.AddItem(p_creditData);
		}
		public function AddItemCreditDataAt(p_creditData:CreditData, p_iIndex:int):void
		{
			this.AddItemAt(p_creditData, p_iIndex);
		}
		
		public function RemoveItemCreditData(p_creditData:CreditData):CreditData
		{
			return CreditData(this.RemoveItemAt(this.FindItemIndexByID(p_creditData.ID)));
		}
		public function RemoveItemCreditDataByID(p_iID:int):CreditData
		{
			return CreditData(this.RemoveItemAt(this.FindItemIndexByID(p_iID)));
		}
		
		public function FindItemCreditDataByID(p_iID:int):CreditData
		{
			var creditData:CreditData;
			for (var i:int = 0; i < this.Length; i++)
			{
				creditData = CreditData(this.getItemAt(i));
				if (creditData.ID == p_iID)
				{
					return creditData;
				}
			}
			
			return null;
		}
		public function FindItemCreditDataByIndex(p_iIndex:int):CreditData
		{
			return CreditData(this.getItemAt(p_iIndex));
		}
		
		public function Fill(p_ac:ArrayCollection):void
		{
			for (var i:int = 0; i < p_ac.length; i++)
			{
				var oObject:Object = p_ac.getItemAt(i);
				if (FindItemCreditDataByID(oObject.USD_ID) == null)
				{
					AddItemCreditData(new CreditData(
						oObject.USD_ID,
						oObject.USD_CREDIT_TYPE_CODE,
						oObject.USD_CREATION_DATETIME,
						oObject.USD_CREDITS,
						oObject.USD_PAYED_FOR_USER_ID,
						oObject.USD_PRESENT_CODE));
				}
			}
		}
	}
}