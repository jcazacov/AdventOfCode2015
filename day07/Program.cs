using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

namespace day07
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Reader reader = new Reader();
            Dictionary<string, Wire> Wires = reader.Read("Input.txt");

            //Task 1
            CalculateWires(Wires);  
            var resulta = Wires["a"].Value;
            Console.WriteLine(resulta);
            
            //Task 2
            foreach (var wire in Wires.Values)
            {
                wire.HasValue = false;
            }
            Wires["b"] = new CopyWire("b", resulta.ToString());
            CalculateWires(Wires);
            Console.WriteLine(Wires["a"].Value);
        }

        private static void CalculateWires(Dictionary<string, Wire> Wires)
        {
            while (Wires["a"].HasValue == false)
            {
                foreach (var wire in Wires.Values)
                {
                    if (wire.HasValue == false)
                    {
                        wire.TryCalculate(Wires);
                    }
                }
            }
        }
    }
}