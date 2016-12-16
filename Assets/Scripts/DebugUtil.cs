using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class DebugUtil
    {
        [Conditional("DEBUG")]
        public static void Assert(bool condition)
        {
            if (!condition) throw new Exception();
        }
    }
}
