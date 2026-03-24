using System;
using System.IO;

class Program3
{
    static void Main()
    {
        Console.WriteLine("=== Project Directory Analyzer ===");
        Console.Write("Enter the root directory path: ");
        string rootPath = Console.ReadLine();

        try
        {
            DirectoryInfo rootDir = new DirectoryInfo(rootPath);

            if (!rootDir.Exists)
            {
                Console.WriteLine("Error: The directory path is invalid or does not exist.");
                return;
            }

            // Get all subdirectories
            DirectoryInfo[] subDirs = rootDir.GetDirectories();

            if (subDirs.Length == 0)
            {
                Console.WriteLine("No subdirectories found in the root directory.");
                return;
            }

            Console.WriteLine("\nSubdirectory Details:\n");
            Console.WriteLine("{0,-40} {1,15}", "Folder Name", "Number of Files");

            foreach (DirectoryInfo dir in subDirs)
            {
                int fileCount = dir.GetFiles().Length;
                Console.WriteLine("{0,-40} {1,15}", dir.Name, fileCount);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: You do not have permission to access this directory.");
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