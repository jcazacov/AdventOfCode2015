using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace day07
{
    public class Reader
    {





        public Dictionary<string, Wire> Read(string filename)
        {
            string Andpattern = @"^(\w+) AND (\w+) -> (\w+)";
            string Orpattern = @"^(\w+) OR (\w+) -> (\w+)";
            string Notpattern = @"^NOT (\w+) -> (\w+)";
            string Lshiftpattern = @"^(\w+) LSHIFT (\w+) -> (\w+)";
            string Rshiftpattern = @"^(\w+) RSHIFT (\w+) -> (\w+)";
            string Copypattern = @"^(\w+) -> (\w+)";
            
            Dictionary<string, Wire> results = new Dictionary<string, Wire>();
             
            string[] allLines = File.ReadAllLines(filename);
            foreach (var line in allLines)
            {
                Wire wire = null;
                
                var match = Regex.Match(line, Andpattern);
                if (match.Success)
                {
                    wire = new AndWire(match.Groups[3].Value, match.Groups[1].Value, match.Groups[2].Value);
                }
                
                match = Regex.Match(line, Orpattern);
                if (match.Success)
                {
                    wire = new OrWire(match.Groups[3].Value, match.Groups[1].Value, match.Groups[2].Value);
                }
                
                match = Regex.Match(line, Lshiftpattern);
                if (match.Success)
                {
                    wire = new LshiftWire(match.Groups[3].Value, match.Groups[1].Value, match.Groups[2].Value);
                }
                
                match = Regex.Match(line, Rshiftpattern);
                if (match.Success)
                {
                    wire = new RshiftWire(match.Groups[3].Value, match.Groups[1].Value, match.Groups[2].Value);
                }
                
                match = Regex.Match(line, Notpattern);
                if (match.Success)
                {
                    wire = new NotWire(match.Groups[2].Value, match.Groups[1].Value);
                }
                
                match = Regex.Match(line, Copypattern);
                if (match.Success)
                {
                    wire = new CopyWire(match.Groups[2].Value, match.Groups[1].Value);
                }

                results[wire.Name] = wire;
            }

            return results;
        }
    }
}