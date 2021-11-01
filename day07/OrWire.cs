using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace day07
{
    [DebuggerDisplay("OR {leftInput}  {rightInput} {HasValue} {Value}")]
    public class OrWire:Wire
    {
        private string leftInput;
        private string rightInput;
        
        public OrWire(string name, string left, string right)
        {
            this.Name = name;
            rightInput = right;
            leftInput = left;
        }
        
        public override void TryCalculate(Dictionary<string, Wire> wires)
        {
            if (!TryGetValue(leftInput, wires, out var leftvalue))
            {
                return;
            }
            if (!TryGetValue(rightInput, wires, out var rightvalue))
            {
                return;
            }

            Value = (UInt16) (leftvalue | rightvalue);
            HasValue = true;
        }

        
        
    }
}