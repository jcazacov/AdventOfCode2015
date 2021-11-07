using System;
using System.Collections.Generic;

namespace day11
{
    internal class Program
    {
        private static string letters = "abcdefghjkmnpqrstuvwxyz";
        public static void Main(string[] args)
        {
            

            List<int> numbers = new List<int>();
            var start = "hxbxxyzz";
            foreach (var ch in start)
            {
                numbers.Add(letters.IndexOf(ch));
            }
/*            
            
            numbers.Add(8);
            numbers.Add(21);
            numbers.Add(2);
            numbers.Add(21);
            numbers.Add(20);
            numbers.Add(21);
            numbers.Add(2);
            numbers.Add(1);
*/            

            bool found = false;
            int i = 7;

            while (!found)
            {
                if (numbers[i] < 22)
                {
                    numbers[i]++;
                    if (i != 7)
                    {
                        i++;
                    }
                    else
                    {
                        found = isSecure(numbers);
                        //printList(numbers);
                        
                    }
                }
                else
                {
                    numbers[i] = -1;
                    i--;
                }
            }
            
            printList(numbers);

            
        }

        static bool isSecure(List<int> password)
        {
            int len = password.Count;
            int pairs = 0;
            List<int> foundPairs = new List<int>();
            int trips = 0;
            for (int i = 1; i < len - 1; i++)
            {
                if (password[i - 1] == password[i] - 1 && password[i + 1] == password[i] + 1)
                {
                    trips++;
                }
            }
            

            for (int i = 1; i < len; i++)
            {
                if (password[i - 1] == password[i] && !(foundPairs.Contains(password[i])))
                {
                    pairs++;
                    foundPairs.Add(password[i]);
                }
            }

            if (pairs >= 2 && trips >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void printList(List<int> list)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(letters[list[j]]);
            }
            Console.WriteLine();
        }
    }
}