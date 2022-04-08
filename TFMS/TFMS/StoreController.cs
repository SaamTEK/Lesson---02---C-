using System;
using System.IO;
using System.Collections.Generic;
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
                    Console.WriteLine($"Exception Occured: {ex.Message}");
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
                    Console.WriteLine($"Exception Occured: {ex.Message}");
                }
            }
        }

        // Method to retrieve all records from the file
        public static List<string> ReadAllData()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    int counter = 0;
                    string line;

                    // Read the file, add index to each line and assign it to a returning List item
                    StreamReader file = new StreamReader(FilePath);
                    List<string> data = new List<string>();
                    while ((line = file.ReadLine()) != null)
                    {
                        data.Add(counter.ToString() + ": " + line);
                        counter++;
                    }

                    file.Close();
                    return data;
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Exception Occured: {ex.Message}");
                    return null;
                }

            } else
            {
                return null;
            }
        }

        // Method to retrieve filtered data based on the paramaters
        public static List<string> ReadData(string fiter)
        {
            if (File.Exists(FilePath))
            {
                List<string> data = new List<string>();
                try
                {
                    int counter = 0;
                    foreach (string line in File.ReadLines(FilePath))
                    {
                        if (line.Contains(fiter))
                        {
                            // Console.WriteLine(counter.ToString() + ": " + line);
                            data.Add(counter.ToString() + ": " + line);
                            counter++;
                        } else
                        {
                            counter++;
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception Occured: {ex.Message}");
                    return null;
                }

                return data;
            } else
            {
                return null;
            }     
        }

        // Method to retrieve data at a specific index 
        public static string GetDataAtIndex(int index)
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    string[] fileData = File.ReadAllLines(FilePath);
                    return fileData[index];
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception Occured: {ex.Message}");
                    return null;
                }
            } else { return null; }
        }

        // Method to update data at a specific index 
        public static void UpdateData(string data, int index)
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    string[] fileData = File.ReadAllLines(FilePath);
                    fileData[index] = data;
                    File.WriteAllLines(FilePath, fileData);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception Occured: {ex.Message}");
                }
            }
        }

        // Method to delete data at a specific index
        public static void DeleteData(int index)
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    string[] fileData = File.ReadAllLines(FilePath);
                    List<string> fileDataList = new List<string>(fileData);
                    fileDataList.RemoveAt(index);
                    File.WriteAllLines(FilePath, fileDataList);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception Occured: {ex.Message}");
                }
            }
        }

    }
}
