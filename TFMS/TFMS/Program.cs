using System;
using System.IO;
using System.Text;

namespace TFMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StoreController.SaveData("01 1000 Saathvik 6th C");
            StoreController.ReadAllData();
        }
    }
}
