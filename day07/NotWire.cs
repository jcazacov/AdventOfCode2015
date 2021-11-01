using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace day07
{
    [DebuggerDisplay("NOT {input} {HasValue} {Value}")]
    public class NotWire:Wire
    {
        private string input;
        
        
        public NotWire(string name, string input)
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
            
            Value = (UInt16) (~value);
            HasValue = true;
        }
    }
}