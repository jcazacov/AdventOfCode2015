using System;
using System.Security.Cryptography;

namespace day04
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string prae = "yzbqklnj";
            int num = -1;
            int result;
            
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            
            while (true)
            {
                num++;
                string input = prae + num.ToString();
                
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                if (hashBytes[0] == 0 && hashBytes[1] == 0 && hashBytes[2] == 0)
                {
                    result = num;
                    Console.WriteLine(result);
                    break;
                }
            }
        }
    }
}