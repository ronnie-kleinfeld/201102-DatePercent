using System;
using System.Collections.Generic;
using System.Text;

namespace MADA.Log.BL.Samples
{
    class CSharp
    {
        /// <summary>
        /// standard function skeleton
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        /// <param name="?">any data will be returned by ref</param>
        /// <returns>SUCCESS | FAILED | any other status</returns>
        public string SampleFunction(object p_o, string p_str, bool p_b, ref object result1)
        {
            try
            {
                // do something
                //  doing
                Logger.Instance.WriteProcess("done doing", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                // check what's done
                //  something wrong
                if (p_b)
                {
                    Logger.Instance.WriteCritical("Failed to insert row into the database", System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                    return BE.ResultCode.FAILED; //FAILED_TO_INSERT_ROW_INTO_THE_DATABASE
                }

                //set byref parameters
                return BE.ResultCode.SUCCESS;
            }
            catch (System.Exception ex)
            {
                Logger.Instance.Write(ex, System.Reflection.MethodBase.GetCurrentMethod(), Environment.MachineName);
                return BE.ResultCode.FAILED;
            }
            finally
            {
            }
        }
    }
}