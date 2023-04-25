using System;

namespace SamirTask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var address1 = "Xətai r. Qacaq Nəbi ev 7 m 102";
            var results = AddressPatternParser.GetAddressPatterns(address1);

            if (results.Count == 0)
            {
                Console.WriteLine("Address contains no matching patterns");
            }

            Console.WriteLine("Matching patterns : ");
            foreach (var result in results)
            {
                Console.Write($"{result.PatternName} ");
            }

            Console.WriteLine('\n');

            Console.WriteLine("Pattern values : ");
            for (int i = 0; i < results.Count; i++)
            {
                if(i+1 != results.Count)
                {
                    Console.Write($"{results[i].PatternValue}, ");
                }
                else
                {
                    Console.WriteLine($"{results[i].PatternValue}");
                }
            }
        }
    }
}
