using System;
using System.IO;

namespace day01
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            string[] allLines = File.ReadAllLines("Input.txt");

            int floor = 0;
            int enter = 1;
            bool first = true;

            var instr = allLines[0]; 

            for (int i = 0; i < instr.Length; i++)
            {
                if (instr[i] == '(')
                {
                    floor = floor + 1;
                }
                if (instr[i] == ')')
                {
                    floor = floor - 1;
                }

                if (floor <= -1 && first)
                {
                    enter = i + 1;
                    first = false;
                }
            }
            Console.WriteLine(floor);
            Console.WriteLine(enter);
        }
    }
}