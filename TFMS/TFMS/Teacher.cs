using System;
using System.Collections.Generic;

namespace TFMS
{
    public static class Teacher
    {
        public static void AddNewTeacher()
        {
            string name = GetInput("\nEnter Teacher name");
            string id = GetInput("Enter ID");
            string cls = GetInput("Enter class (1-10)");
            string sec = GetInput("Enter Section (A/B/C)").ToUpper();

            string data = $"{id},{name},{cls}/{sec}";

            StoreController.SaveData(data);
            GetFormattedResponse("Teacher added successfully.");
        }

        public static void FilterTeachers() {
            string filter = GetInput("\nEnter filter parameter (ID, Name or Class/Section)");

            List<string> filteredList = StoreController.ReadData(filter);

            Console.WriteLine();
            Console.WriteLine("Result:");

            GetFormattedTableOutput(filteredList);
        }

        public static void GetAllTeachers()
        {
            List<string> teachers = StoreController.ReadAllData();

            GetFormattedTableOutput(teachers);
        }

        public static void UpdateTeacher()
        {
            Console.WriteLine();

            int index = Convert.ToInt32(GetInput("Enter index of Teacher to update"));

            string indexData = StoreController.GetDataAtIndex(index);

            Console.WriteLine("\nSelected Teacher: ");
            GetFormattedRow(indexData, true);
            Console.WriteLine();

            string[] splitData = indexData.Split(',');
            string newID = GetInput("Enter new ID", splitData[1]);
            string newName = GetInput("Enter new name", splitData[2]);
            string[] splitCS = splitData[3].Split('/');
            string newClass = GetInput("Enter new Class", splitCS[0]);
            string newSec = GetInput("Enter new Section", splitCS[1]).ToUpper();

            string newData = $"{newID},{newName},{newClass}/{newSec}";
            StoreController.UpdateData(newData, index);
            GetFormattedResponse($"Updated Teacher: {newData}" );
        }

        public static void DeleteTeacher()
        {
            Console.WriteLine();

            int index = Convert.ToInt32(GetInput("Enter index of Teacher to delete"));

            StoreController.DeleteData(index);
            GetFormattedResponse("Teacher deleted successfully.");
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

        private static void GetFormattedTableOutput(List<string> data)
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Index| ID   | Name                 |   C&S");
            Console.WriteLine("------------------------------------------");
            foreach (string item in data)
            {
                GetFormattedRow(item);
            }
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();
            Console.Write("Press any key to return to main menu... ");
            Console.ReadKey();
        }

        private static void GetFormattedRow(string data)
        {
            string[] splitData = data.Split(',');
            Console.WriteLine(String.Format("{0,-4} | {1,-4} | {2,-20} | {3,5}", splitData[0], splitData[1], splitData[2], splitData[3]));
        }

        private static void GetFormattedRow(string data, bool showBorder)
        {
            if (showBorder)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Index| ID   | Name                 |   C&S");
                Console.WriteLine("------------------------------------------");
                string[] splitData = data.Split(',');
                Console.WriteLine(String.Format("{0,-4} | {1,-4} | {2,-20} | {3,5}", splitData[0], splitData[1], splitData[2], splitData[3]));
                Console.WriteLine("------------------------------------------");
            }
        }

        private static void GetFormattedResponse(string response)
        {
            Console.WriteLine();
            Console.Write(response);
            GetAllTeachers();
        }
    }
}
