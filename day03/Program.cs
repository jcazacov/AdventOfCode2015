using System;
using System.Collections.Generic;
using System.IO;

namespace day03
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string[] allLines = File.ReadAllLines("Input.txt");
            var instr = allLines[0];

            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 0;
            int visit = 1;

            Dictionary<string, int> houses = new Dictionary<string, int>();
            houses.Add("0;0", 1);


            for (int i = 0; i < instr.Length; i++)
            {
                if (instr[i] == '^')
                {
                    if (i % 2 == 0)
                    {
                        y1++;
                    }
                    else
                    {
                        y2++;
                    }
                }

                if (instr[i] == 'v')
                {
                    if (i % 2 == 0)
                    {
                        y1--;
                    }
                    else
                    {
                        y2--;
                    }
                }

                if (instr[i] == '<')
                {
                    if (i % 2 == 0)
                    {
                        x1--;
                    }
                    else
                    {
                        x2--;
                    }
                }

                if (instr[i] == '>')
                {
                    if (i % 2 == 0)
                    {
                        x1++;
                    }
                    else
                    {
                        x2++;
                    }
                }
                if (i % 2 == 0)
                {
                    if (houses.ContainsKey($"{x1};{y1}"))
                    {
                        houses[$"{x1};{y1}"]++;
                    }
                    else
                    {
                        houses.Add($"{x1};{y1}", 1);
                        visit++;
                    }
                }
                else
                {
                    if (houses.ContainsKey($"{x2};{y2}"))
                    {
                        houses[$"{x2};{y2}"]++;
                    }
                    else
                    {
                        houses.Add($"{x2};{y2}", 1);
                        visit++;
                    }
                }
                
                
            }
            
            Console.WriteLine(visit);
        }
    }
}