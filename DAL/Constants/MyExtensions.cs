using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Constants
{
    public static class MyExtensions
    {
        public static string NoMatterLowerOrUpper(this string str)
        {
            string newStr = str.ToUpper();
            return newStr;
        }
    }
}
