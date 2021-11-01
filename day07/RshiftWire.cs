using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace day07
{
    [DebuggerDisplay("Rshift {leftInput}  {rightInput} {HasValue} {Value}")]
    public class RshiftWire:Wire
    {
        private string leftInput;
        private string rightInput;
        
        public RshiftWire(string name, string left, string right)
        {
            this.Name = name;
            rightInput = right;
            leftInput = left;
        }
        
        public override void TryCalculate(Dictionary<string, Wire> wires)
        {
            UInt16 leftvalue;
            UInt16 rightvalue;
            if (!TryGetValue(leftInput, wires, out leftvalue))
            {
                return;
            }
            if (!TryGetValue(rightInput, wires, out rightvalue))
            {
                return;
            }

            Value = (UInt16) (leftvalue >> rightvalue);
            HasValue = true;
        }

        
        
    }
}