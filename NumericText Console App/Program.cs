using System;
using NumericText;

namespace NumericText_Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            string sInput = "This is a test to find the numbers:1, 101, 2222 or the negative numbers -2345, -44444.55 or -1,234.55 or ordinal numbers like 1st or 22nd or 66th or a number with thousands separators like 1,442,333 in this string. Fractions like 1/10, 3/8, 5/16 should also be located.  This sentence checks for a number at the end of a sentence like 3,244.";


            Console.WriteLine(sInput);
            Console.WriteLine("");
            Console.WriteLine(sInput.ToText());


            Console.ReadKey();


        }
    }
}
