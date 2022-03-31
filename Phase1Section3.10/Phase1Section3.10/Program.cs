using System;
using System.Text;
namespace Phase1Section3._10
{
    class Program
    {
        static void Main(string[] args)
        {
            doApp();
            Console.Write("Enter any key to exit...");
            Console.ReadKey();
            return;
        }
        public static void doApp()
        {
            string mary = "Mary had a little lamb.";
            Console.WriteLine("Original string= " + mary);
            Console.WriteLine("Clone of a string = " + mary.Clone());
            Console.WriteLine("Compare two strings = " + mary.CompareTo(" Mary had a big lamb"));
            Console.WriteLine("Characters in a string = " + mary.Contains(" r "));
            Console.WriteLine("String ending with = " + mary.EndsWith(" lamb. "));
            Console.WriteLine("All lowercase = " + mary.ToLower());
            Console.WriteLine("All uppercase = " + mary.ToUpper());
            Console.WriteLine("Insert string within a string = " + mary.Insert(4, " and Jack "));
            Console.WriteLine("Splitting string into words: ");

            string[] parts = mary.Split(' ');
            foreach (string p in parts)
            {
                Console.WriteLine(p);
            }
            StringBuilder sb = new StringBuilder("");
            for (int i = 0; i < 10; i++)
            {
                sb.Append(i.ToString() + " ");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}