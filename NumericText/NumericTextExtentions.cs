using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace NumericText
{
    public static class NumericTextExtentions
    {
        private class MatchResult
        {
            public string Value { get; set; }
            public bool IsFraction { get; set; }
            public bool IsOrdinal { get; set; }
        }

        public static string ToText(this string sSource)
        {
            string sOutput = sSource;
            string sExtractionPattern = "";
            List<MatchResult> MatchResults = new List<MatchResult>();

            sSource = "This is a test to find the numbers:1, 101, 2222 or the negative numbers -2345, -44444.55 or -1,234.55 or ordinal numbers like 1st or 22nd or 66th or a number with thousands separators like 1,442,333 in this string. Fractions like 1/10, 3/8, 5/16 should also be located.  This sentence checks for a number at the end of a sentence like 3,244.";

            // Search for any numeric values in the passed string.

            // Date, Time, Phone numbers
            // Currencies, percent, to the power of
            // Heights, Lengths etc.
            // 

            sExtractionPattern = @"(?<fraction>[\-\+]?[0-9]{1,}[\\\/][0-9]{1,})|(?:[\-\+]?[0-9]{4,})(?:(?:\.\d{1,})|(?<ordinal>st|nd|rd|th))?|(?:[\-\+]?[0-9]{1,3}(?:,[0-9]{3})*)(?:(?:\.\d{1,})|(?<ordinal>st|nd|rd|th))?";

            MatchCollection oMatches = Regex.Matches(sSource, sExtractionPattern);

            foreach (Match mMatch in oMatches)
            {
                MatchResults.Add(new MatchResult()
                {
                    Value = mMatch.Value,
                    IsFraction = (mMatch.Groups["fraction"].Value != string.Empty ? true : false),
                    IsOrdinal = (mMatch.Groups["ordinal"].Value != string.Empty ? true : false)
                });
            }

            // Order the numbers found by their length

            MatchResults = MatchResults.OrderByDescending(x => x.Value.Length).ToList();

            // Parse the numbers found and replace within the text

            foreach (MatchResult mMatch in MatchResults)
            {
                if (mMatch.IsFraction)
                {
                }

                if (mMatch.IsOrdinal)
                {
                }

                if (!mMatch.IsOrdinal && !mMatch.IsFraction)
                {
                    sSource = sSource.Replace(mMatch.Value, mMatch.Value.ToNumericText());
                }
            }

            // Return the parsed string.

            return sOutput;
        }

        public static string ToNumericText(this string sSource)
        {
            return ConvertToText(float.Parse(sSource), false);
        }
        public static string ToNumericText(this int iSource)
        {
            return ConvertToText((float)iSource, true);
        }
        public static string ToNumericText(this float fSource)
        {
            return ConvertToText(fSource, false);
        }

        private static string ConvertToText(float fInput, bool bIgnoreZeroDecimals)
        {
            string sOutput = "";
            JObject oFormat = JObject.Parse(File.ReadAllText(@"C:\Development\Open Source\NumericText\NumericText\Format Documents\ToText\EN.json"));

            // [minus ] trillion[, ]billion[, ]million[, ]thousand[, ]hundred[ and ]tens/singles[point][digits]

            IEnumerable<JToken> pricyProducts = oFormat["ordinals"].SelectTokens("$.[?(@..order == 1)]");






            return sOutput;
        }
    }
}
