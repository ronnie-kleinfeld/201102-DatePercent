/**
 * This is a generated sub-class of _FlexWS.as and is intended for behavior
 * customization.  This class is only generated when there is no file already present
 * at its target location.  Thus custom behavior that you add here will survive regeneration
 * of the super-class. 
 **/

package services.flexws
{
	import mx.rpc.soap.Operation;
	
	public class FlexWS extends _Super_FlexWS
	{
		public function FlexWS()
		{
			for each (var operation:Operation in _serviceControl.operations)
			{
				switch (operation.resultType.toString())
				{
					case "[class Boolean]":
					case "[class String]":
					case "[class FS]":
					case "[class int]":
						break;
					default:
						operation.resultType = Object;
				}
			}
		}
	}
}