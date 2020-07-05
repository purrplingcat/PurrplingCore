using StardewModdingAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurrplingCore
{
    class Utils
    {
        public static SDate ParseDate(string strDate)
        {
            string[] s = strDate.Split(' ');

            if (s.Length != 3 || !s[2].StartsWith("Y"))
                throw new ParseDateException("Input date string has wrong format!");

            return new SDate(
                Convert.ToInt32(s[0]),
                s[1], 
                Convert.ToInt32(s[2].Substring(1))
            );
        }
    }
}
