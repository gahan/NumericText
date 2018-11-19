using System;
using System.Text.RegularExpressions;

namespace NumericText
{
    public static class NumericTextExtentions 
    {
        public static string ToText(this string sSource)
        {
            string sOutput = "";
            string sExtractionPattern = "";


            sSource = "This is a test to find the numbers:1, 101, 2222 or the negative numbers -2345, -44444.55 or -1,234.55 or ordinal numbers like 1st or 22nd or 66th or a number with thousands separators like 1,442,333 in this string. Fractions like 1/10, 3/8, 5/16 should also be located.  This sentence checks for a number at the end of a sentence like 3,244.";

            // Search for any numeric values in the passed string.

            // Date, Time, Phone numbers

            sExtractionPattern = @"(?<fraction>[\-\+]?[0-9]{1,}[\\\/][0-9]{1,})|(?:[\-\+]?[0-9]{4,})(?:(?:\.[0-9]*)|(?<ordinal>st|nd|rd|th))?|(?:[\-\+]?[0-9]{1,3}(?:,[0-9]{3})*)(?:(?:\.[0-9]*)|(?<ordinal>st|nd|rd|th))?";

            MatchCollection oMatches = Regex.Matches(sSource, sExtractionPattern);

            foreach(Match mMatch in oMatches)
            {
                Console.WriteLine(mMatch.Value);
            }

            // Remove all non-numeric characters and leave only digits and the first decimal point.


            // Check for any ordinal, fraction or currency markers and flag as appropiate. 


            // Parse the numbers


            // Return the parsed string.

            return sOutput;
        }
    }
}
