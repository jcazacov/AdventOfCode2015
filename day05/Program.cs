using System;
using System.Collections.Generic;
using System.IO;

namespace day05
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<string> lines = new List<string>();
            string[] allLines = File.ReadAllLines("Input.txt");
            
            foreach (string line in allLines)
            {
                lines.Add(line);
            }

            int nicelines = 0;


            foreach (var line in lines)
            {
                char prev = ' ';
                char curr = ' ';
                bool nice = true;
                bool lone = true;
                int vocal = 0;
                int i = 0;
                while (nice && i<line.Length)
                {
                    curr = line[i];
                    if ((prev == 'a' && curr == 'b') || (prev == 'c' && curr == 'd') || (prev == 'p' && curr == 'q') ||
                        (prev == 'x' && curr == 'y'))
                    {
                        nice = false;
                        break;
                    }

                    if (prev == curr)
                    {
                        lone = false;
                    }

                    if (curr == 'a' || curr == 'e' || curr == 'i' || curr == 'o' || curr == 'u')
                    {
                        vocal++;
                    }
                    
                    i++;
                    prev = curr;
                }

                if (lone)
                {
                    nice = false;
                }

                if (vocal < 3)
                {
                    nice = false;
                }

                if (nice)
                {
                    nicelines++;
                }
            }

            
            Console.WriteLine(nicelines);
        }
    }
}