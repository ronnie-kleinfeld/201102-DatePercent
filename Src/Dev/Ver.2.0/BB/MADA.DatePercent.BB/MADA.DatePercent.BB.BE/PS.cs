using System;
using System.Collections.Generic;
using System.Text;

namespace MADA.DatePercent.BB.BE
{
    public class PS
    {
        /// <summary>
        ///  1 - Has Messages
        ///  2 - Has Online Favorites
        ///  4 - Has Breaking News
        ///  8 - Me FB Updated
        /// 16 - Is Online
        /// 32 - Link Updated
        /// 64 - Credits Balance Updated
        /// </summary>
        public int _BW;
        /// <summary>
        /// Online Count
        /// </summary>
        public int _C;
    }
}