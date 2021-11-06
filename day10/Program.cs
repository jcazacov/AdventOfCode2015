using System;
using System.Collections.Generic;

namespace day10
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<byte> value = new List<byte>
            {
                1, 1, 1, 3, 2, 2, 2, 1, 1, 3
            };
            for (int i = 0; i < 50; i++)
            {
                value = lookSay(value);
                Console.WriteLine(i);
            }
            Console.WriteLine(value.Count);
        }



        static List<byte> lookSay(List<byte> seq)
        {
            if (seq.Count == 1)
            {
                return new List<byte> { 1, seq[0]};
            }

            List<byte> newSeq = new List<byte>();
            var curDig = seq[0];
            byte counter = 1;
            for (int i = 1; i < seq.Count; i++)
            {
                if (seq[i] == curDig)
                {
                    counter++;
                }
                else
                {
                    newSeq.Add(counter);
                    newSeq.Add(curDig);
                    curDig = seq[i];
                    counter = 1;
                }
            }
            newSeq.Add(counter);
            newSeq.Add(curDig);
            return newSeq;
        }
        
        
    }
}