using System;
using System.IO;
using System.Text.RegularExpressions;

namespace day12
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string pattern = @"(-*)(\d+)";
            int sum = 0;

            string allLines = File.ReadAllText("Input.txt");
            var regex = new Regex(pattern);
            
            
            var match = regex.Match(allLines);
            while (match.Success)
            {
                int zahl = Int32.Parse(match.Groups[2].Value);
                if (match.Groups[1].Value == "-")
                {
                    sum = sum - zahl;
                }
                else
                {
                    sum = sum + zahl;
                }
                
                match = match.NextMatch();
            }
            Console.WriteLine(sum);
        }
    }
}