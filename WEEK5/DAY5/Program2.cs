using System;
using System.IO;

class Program2
{
    static void Main()
    {
        Console.WriteLine("=== File Properties Viewer ===");
        Console.Write("Enter folder path: ");
        string folderPath = Console.ReadLine();

        try
        {
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Error: The folder path is invalid or does not exist.");
                return;
            }

            // Get all files in the folder
            string[] files = Directory.GetFiles(folderPath);

            if (files.Length == 0)
            {
                Console.WriteLine("No files found in the folder.");
                return;
            }

            int count = 0;
            Console.WriteLine("\nFile Details:\n");
            Console.WriteLine("{0,-30} {1,10} {2,25}", "File Name", "Size (Bytes)", "Creation Date");

            foreach (string filePath in files)
            {
                FileInfo file = new FileInfo(filePath);
                Console.WriteLine("{0,-30} {1,10} {2,25}", file.Name, file.Length, file.CreationTime);
                count++;
            }

            Console.WriteLine($"\nTotal number of files: {count}");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: You do not have permission to access this folder.");
        }
        catch (IOException ex)
        {
            Console.WriteLine("Error: An I/O error occurred - " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}