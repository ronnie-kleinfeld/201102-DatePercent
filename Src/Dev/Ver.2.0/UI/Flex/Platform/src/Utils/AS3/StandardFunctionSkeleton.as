package Utils.AS3
{

	public class StandardFunctionSkeleton
	{
		public function SampleFunction(p_o:Object, p_str:String, p_b:Boolean, result1:Object):String
		{
			var strResult:String;
			
			try
			{
				// do something
				//  doing
				//Logger.Instance.WriteProcess("done doing", System.Reflection.MethodBase.GetCurrentMethod());
				// check what's done
				//  something wrong
				if (p_b)
				{
					//Logger.Instance.WriteCritical("Failed to insert row into the database", System.Reflection.MethodBase.GetCurrentMethod());
					strResult = ResultCode.FAILED; //FAILED_TO_INSERT_ROW_INTO_THE_DATABASE
					return strResult;
				}
				
				//set byref parameters
				strResult = ResultCode.SUCCESS;
			}
			catch (error:Error)
			{
				//Logger.Instance.Write(error, System.Reflection.MethodBase.GetCurrentMethod());
				strResult = ResultCode.FAILED;
			}
			finally
			{
			}
			
			return strResult;
		}
	}
}