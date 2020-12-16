using StardewModdingAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurrplingCore
{
    static class Utils
    {
        private static bool TryParseRelativeDate(string strDate, out SDate date)
        {
            switch (strDate)
            {
                case "today":
                    date = SDate.Now();
                    break;
                case "yesterday":
                    date = SDate.Now().AddDays(-1);
                    break;
                case "tomorrow":
                    date = SDate.Now().AddDays(1);
                    break;
                default:
                    date = null;
                    break;
            }

            return date != null;
        }

        public static SDate ParseDate(string strDate)
        {
            string[] s = strDate.Split(' ');

            if (TryParseRelativeDate(strDate, out SDate date))
                return date;

            if (s.Length == 2)
                return new SDate(Convert.ToInt32(s[0]), s[1]);

            if (s.Length != 3 || !s[2].StartsWith("Y"))
                throw new ParseDateException("Input date string has wrong format!");

            return new SDate(
                Convert.ToInt32(s[0]),
                s[1], 
                Convert.ToInt32(s[2].Substring(1))
            );
        }

        public static string CutText(string text, int maxChars)
        {
            if (text.Length < maxChars)
                return text;

            if (maxChars < 3)
                return "...";

            return text.Substring(0, maxChars - 3) + "...";
        }
    }
}
