using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace day07
{
    [DebuggerDisplay("Copy {input}  {HasValue} {Value}")]
    public class CopyWire:Wire
    {
        private string input;
        
        
        public CopyWire(string name, string input)
        {
            this.Name = name;
            this.input = input;
            
        }
        
        public override void TryCalculate(Dictionary<string, Wire> wires)
        {
            if (!TryGetValue(input, wires, out var value))
            {
                return;
            }
            
            Value = (value);
            HasValue = true;
        }
    }
}