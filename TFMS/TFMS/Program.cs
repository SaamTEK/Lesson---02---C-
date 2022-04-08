using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace TFMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StoreController.SaveData("1003 MSM 6th C");
            List<string> s = StoreController.ReadAllData();
            for(int i = 0; i < s.Count; i++)
            {
                Console.WriteLine(s[i]);
            }
            Console.WriteLine("Reading specific data");
            List<string> d = StoreController.ReadData("6th");
            // if(d.Count != 0) Console.WriteLine(d[0]);
            // StoreController.UpdateData("1009 DMS 10th C", 3);

            // StoreController.DeleteData(4);
        }
    }
}
