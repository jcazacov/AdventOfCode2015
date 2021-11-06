using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace day08
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int literalchar = 0;
            int memorychar = 0;
            int expandchar = 0;
            

            List<string> lines = new List<string>();
            string[] allLines = File.ReadAllLines("Input.txt");
            foreach (var line in allLines)
            {
                lines.Add(line);
            }
            foreach (var line in lines)
            {
                literalchar += line.Length;
            }

            foreach (string line in lines)
            {
                for (int i = 1; i < line.Length - 1; i++)
                {
                    char curchar = line[i];
                    char nextchar = line[i + 1];
                    if (line[i] == '\\')
                    {
                        if (line[i + 1] == '\\')
                        {
                            memorychar += 1;
                            i++;
                        }

                        else
                        {
                            if (line[i + 1] == '\"')
                            {
                                memorychar += 1;
                                i++;
                            }
                            else
                            {
                                if (line[i + 1] == 'x')
                                {
                                    memorychar += 1;
                                    i = i + 3;
                                }
                            }
                        }
                    }
                    else
                    {
                        memorychar++;
                    }
                }
            }

            foreach (string line in lines)
            {
                expandchar += 2;
                for (int i = 0; i < line.Length; i++)
                {
                    char curchar = line[i];
                    if (line[i] == '\\')
                    {
                        expandchar++;
                    }
                    if (line[i] == '\"')
                    {
                        expandchar++;
                    }

                    expandchar++;
                }
            }



            Console.WriteLine($"There are {literalchar} literal characters on the list");
            Console.WriteLine($"There are {memorychar} characters saved in memory");
            Console.WriteLine($"There are {expandchar} needed to encode the whole list");
            Console.WriteLine($"there are {literalchar - memorychar} less characters saved in memory than written on the list");
            Console.WriteLine($"there are {expandchar - literalchar} more characters needed to encode the list then are written on the list.");
        }
    }
}