using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFMS
{
    public static class Teacher
    {
        public static void AddNewTeacher()
        {
            string name = GetInput("Enter Teacher name");
            string id = GetInput("Enter ID: ");
            string cs = GetInput("Enter Class & Section: ");

            string data = $"{id},{name},{cs}";

            StoreController.SaveData(data);
        }

        public static void FilterTeachers() {
            string filter = GetInput("Enter filter parameter (ID, Name or Class & Section");

            List<string> filteredList = StoreController.ReadData(filter);

            foreach (string item in filteredList) { 
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        public static void GetAllTeachers()
        {
            List<string> teachers = StoreController.ReadAllData();

            foreach (string item in teachers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        public static void UpdateTeacher()
        {
            Console.Write("Enter index of Teacher to update: ");
            int index = Convert.ToInt32(Console.ReadLine());

            string indexData = StoreController.GetDataAtIndex(index);
            string[] splitData = indexData.Split(',');
            Console.WriteLine($"{splitData[0]} {splitData[1]} {splitData[2]}");

            string newID = GetInput("Enter new ID", splitData[0]);
            string newName = GetInput("Enter new name", splitData[1]);
            string newCS = GetInput("Enter new Class & Section", splitData[2]);

            string newData = $"{newID},{newName},{newCS}";
            Console.WriteLine(newData);
            StoreController.UpdateData(newData, index);
        }

        public static void DeleteTeacher()
        {
            Console.Write("Enter index of Teacher to delete: ");
            int index = Convert.ToInt32(Console.ReadLine());
            StoreController.DeleteData(index);
        }

        private static string GetInput(string Prompt)
        {
            string Result;
            do
            {
                Console.Write(Prompt + ": ");
                Result = Console.ReadLine();
                if (string.IsNullOrEmpty(Result))
                {
                    Console.WriteLine("Empty input, please try again");
                }
            } while (string.IsNullOrEmpty(Result));
            return Result;
        }

        private static string GetInput(string Prompt, string PrevValue)
        {
            string Result;
            Console.Write(Prompt + ": ");
            Result = Console.ReadLine();
            if (string.IsNullOrEmpty(Result))
            {
                Console.WriteLine("Empty input, retaining previous value.");
                return PrevValue;
            }
            return Result;
        }
    }
}
