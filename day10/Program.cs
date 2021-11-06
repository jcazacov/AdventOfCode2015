using System;

namespace day10
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string value = "1113222113";
            for (int i = 0; i < 29; i++)
            {
                value = lookSay(value);
                Console.WriteLine(value);
            }
            Console.WriteLine(value.Length);
        }



        static string lookSay(string seq)
        {
            if (seq.Length == 1)
            {
                return "1" + seq;
            }
            
            string newSeq = "";
            string curDig = seq[0].ToString();
            int counter = 1;
            for (int i = 1; i < seq.Length; i++)
            {
                if (seq[i].ToString() == curDig)
                {
                    counter++;
                }
                else
                {
                    newSeq = newSeq.ToString() + counter.ToString() + curDig.ToString();
                    curDig = seq[i].ToString();
                    counter = 1;
                }
            }
            newSeq = newSeq + counter.ToString() + curDig.ToString();
            return newSeq;
        }
        
        
    }
}