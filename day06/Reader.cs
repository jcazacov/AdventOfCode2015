using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace day06
{
    public class Reader
    {





        public List<Instruction> Read(string filename)
        {
            string pattern = @"(turn on|turn off|toggle) (\d*),(\d*) through (\d*),(\d*)";
            List<Instruction> instructions = new List<Instruction>();
             
            string[] allLines = File.ReadAllLines(filename);
            foreach (var line in allLines)
            {
                var match = Regex.Match(line, pattern);
                if (match.Success)
                {
                    Instruction item = new Instruction();
                    item.Order = match.Groups[1].Value;
                    item.X1 = Int32.Parse(match.Groups[2].Value);
                    item.Y1 = Int32.Parse(match.Groups[3].Value);
                    item.X2 = Int32.Parse(match.Groups[4].Value);
                    item.Y2 = Int32.Parse(match.Groups[5].Value);
                    instructions.Add(item);
                }
            }

            return instructions;
        }
    }
}