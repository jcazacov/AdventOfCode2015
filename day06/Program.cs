using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace day06
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            var lights = new bool[1000,1000];
            var lightsInt = new int[1000,1000];


            Reader reader = new Reader();
            List<Instruction> list = reader.Read("Input.txt");

            foreach (Instruction instr in list)
            {
                for (int i = instr.Y1; i < instr.Y2 + 1; i++)
                {
                    for (int j = instr.X1; j < instr.X2 + 1; j++)
                    {
                        instr.Apply(ref lights, i, j);
                        instr.ApplyInt(ref lightsInt, i , j);
                    }
                }
            }

            int lit = 0;
            int power = 0;
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (lights[i , j])
                    {
                        lit++;
                    }

                    power += lightsInt[i, j];
                } 
            }

            Console.WriteLine($"there are {lit} lights lit");
            Console.WriteLine($"The light has a power of {power}");

        }
    }
}