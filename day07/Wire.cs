using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace day07
{
    
    public abstract class Wire
    {
        public string Name;
        public System.UInt16 Value;
        public bool HasValue = false;
        public abstract void TryCalculate(Dictionary<string, Wire> wires);
        
        protected bool TryGetValue(string wireName, Dictionary<string, Wire> wires,  out UInt16 value)
        {
            var result = UInt16.TryParse(wireName, out value);
            if (result)
            {
                return true;
            }
            else
            {
                if (!wires.ContainsKey(wireName))
                {
                    return false;
                }
                else
                {
                    var anotherWire = wires[wireName];
                    if (anotherWire.HasValue)
                    {
                        value = anotherWire.Value;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            
        }
    }
}