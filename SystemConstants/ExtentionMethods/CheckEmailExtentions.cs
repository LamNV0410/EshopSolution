using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ExtentionMethods
{
    public static class CheckEmailExtentions
    {
        public static bool IsEmail(this string name)
        {
            if (name.Contains("@"))
            {
                return true;
            }

            return false;
        }
    }
}
