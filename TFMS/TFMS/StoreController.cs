using System;
using System.IO;
using System.Text;

namespace TFMS
{
    public static class StoreController
    {
        private static readonly string FilePath;

        static StoreController()
        {
            string appDirPath = Directory.GetCurrentDirectory(); // Get the current directory path of the application
            string dataDirPath = Path.Combine(appDirPath, "data"); // Append "data" folder to the current directory path

            // Create a new "data" subfolder within the app directory
            DirectoryInfo info = Directory.CreateDirectory(dataDirPath);
            // Console.WriteLine(info);

            // Create a file name for the new text file to store records in the data directory
            string dataFile = "data.txt";
            FilePath = Path.Combine(dataDirPath, dataFile);

            if (!File.Exists(FilePath))
            {
                Console.WriteLine("Creating new file...");
                try
                {
                    FileStream f = File.Create(FilePath);
                    f.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // Method to perform writing to the file
        public static void SaveData(string data)
        {
            if (FilePath != null) {
                try
                {
                    using (StreamWriter sw = File.AppendText(FilePath))
                    {
                        sw.WriteLine(data);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // Method to retrieve all records from the file
        public static string ReadAllData()
        {
            // Open the file to read from.
            string data = File.ReadAllText(FilePath);
            Console.WriteLine(data);
            return data;
        }

        // Method to retrieve only certain data based on the paramaters
        public static void ReadData(string id, string data)
        {
            if (File.Exists(FilePath)) {
                foreach (string line in File.ReadLines(FilePath))
                {
                    if (line.Contains(id) | line.Contains(data))
                    {
                        Console.WriteLine(line);
                    }
                }
            }                
        }

    }
}
