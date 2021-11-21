using System;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

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


            var token = JToken.Parse(allLines);
            int result = Jadder(token);
            Console.WriteLine(result);
        }

        private static int Jadder(JToken token)
        {
            if (token.Type == JTokenType.Integer)
            {
                return token.Value<int>();
            }

            if (token is JProperty property)
            {
                return Jadder(property.Value);
            }

            if (token is JObject obj)
            {
                foreach (var item in obj.Children())
                {
                    if (item is JProperty prop)
                    {
                        if (prop.Value.Type == JTokenType.String)
                        {
                            if (prop.Value.Value<string>() == "red")
                            {
                                return 0;
                            }
                        }
                    }
                }
            }

            if (!(token is JContainer))
            {
                return 0;
            }

            // only if token is array or object
            int sum = 0;
            foreach (var item in token.Children())
            {
                sum = sum + Jadder(item);
            }

            return sum;
        }
    }
}