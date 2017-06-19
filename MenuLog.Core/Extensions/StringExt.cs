using System;
using System.Collections.Generic;
using System.Text;

namespace MenuLog.Core.Extensions
{
    public static class StringExt
    {
        public static bool IsEmpty(this string src)
        {
            return string.IsNullOrWhiteSpace(src);
        }
    }
}
