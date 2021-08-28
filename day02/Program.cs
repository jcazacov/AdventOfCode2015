using System;
using System.Collections.Generic;
using System.IO;

namespace day02
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<List<int>> sizes = new List<List<int>>();
            string[] allLines = File.ReadAllLines("Input.txt");
            
            foreach (string line in allLines)
            {
                var lineList = new List<int>();
                var strs = line.Split(new char[] {'x'});
                foreach (string dim in strs)
                {
                    lineList.Add(Int32.Parse(dim));
                }                
                sizes.Add(lineList);
            }

            int paper = 0;
            int ribbon = 0;

            for (int num = 0; num < sizes.Count; num++)
            {
                List<int> order = sizes[num];
                int minside;

                int side1 = order[0] * order[1];
                minside = side1;
                
                int side2 = order[1] * order[2];
                if (side2 < minside)
                {
                    minside = side2;
                }
                    
                int side3 = order[0] * order[2];
                if (side3 < minside)
                {
                    minside = side3;
                }

                int minrib;
                
                int rib1 = order[0] * 2 + order[1] * 2;
                minrib = rib1;
                
                int rib2 = order[1] * 2 + order[2] * 2;
                if (rib2 < minrib)
                {
                    minrib = rib2;
                }
                    
                int rib3 = order[0] * 2 + order[2] * 2;
                if (rib3 < minrib)
                {
                    minrib = rib3;
                }

                int vol = order[0] * order[1] * order[2];

                
                
                
                int size = side1 * 2 + side2 * 2 + side3 * 2 + minside;
                int riball = minrib + vol;
                paper = paper + size;
                ribbon = ribbon + riball;
            }
            Console.WriteLine(paper);
            Console.WriteLine(ribbon);
        }
    }
}