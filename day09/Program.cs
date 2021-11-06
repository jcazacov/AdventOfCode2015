using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day09
{
    internal class Program
    {
        static Dictionary<string, int> distances = new Dictionary<string, int>();
        
        public static void Main(string[] args)
        {

            HashSet<string> allCities = new HashSet<string>();
            string pattern = @"(\w+) to (\w+) = (\d+)";

            string[] allLines = File.ReadAllLines("Input.txt");
            foreach (var line in allLines)
            {
                var match = Regex.Match(line, pattern);
                if (match.Success)
                {
                    string city1 = match.Groups[1].Value;
                    string city2 = match.Groups[2].Value;
                    int distance = Int32.Parse(match.Groups[3].Value);

                    allCities.Add(city1);
                    allCities.Add(city2);
                    
                    distances.Add(city1 + city2, distance);
                    distances.Add(city2 + city1, distance);

                }
            }

            List<string> cityList = allCities.ToList();

            int result = minDistance(null, cityList);
            Console.WriteLine(result);



        }

        static int distance(string city1, string city2)
        {
            if (city1 == null)
            {
                return 0;
            }

            string myKey = city1 + city2;
            return distances[myKey];
        }

        static int minDistance(string start, List<string> citiesLeft)
        {
            if (citiesLeft.Count == 0)
            {
                return 0; 
            }
            int mindin = Int32.MaxValue;

            foreach (string city in citiesLeft)
            {
                int newDistance = distance(start, city) + minDistance(city,
                    citiesLeft.Where(c => c != city).ToList());
                if (newDistance < mindin)
                {
                    mindin = newDistance;
                }
            }
            return mindin;
        }
    }
}