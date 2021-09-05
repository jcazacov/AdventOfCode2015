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

            Coordinates Santa = new Coordinates();
            Coordinates Robot = new Coordinates();

            HashSet<string> visits = new HashSet<string>();
            visits.Add("0;0");


            for (int i = 0; i < instr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Santa.Move(instr[i]);
                    visits.Add(Santa.Key);
                }
                else
                {
                    Robot.Move(instr[i]);
                    visits.Add(Robot.Key);
                }
            }
            Console.WriteLine(visits.Count);
        }
    }
}