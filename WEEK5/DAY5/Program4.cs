using System;
using System.IO;

class Program4
{
    static void Main()
    {
        Console.WriteLine("=== Disk Storage Monitor ===\n");

        try
        {
            // Get all system drives
            DriveInfo[] drives = DriveInfo.GetDrives();

            if (drives.Length == 0)
            {
                Console.WriteLine("No drives found on this system.");
                return;
            }

            Console.WriteLine("{0,-10} {1,-12} {2,15} {3,15} {4}", "Drive", "Type", "Total Size (GB)", "Free Space (GB)", "Status");

            foreach (DriveInfo drive in drives)
            {
                if (!drive.IsReady)
                {
                    Console.WriteLine("{0,-10} {1,-12} {2,15} {3,15} {4}", drive.Name, drive.DriveType, "N/A", "N/A", "Not Ready");
                    continue;
                }

                double totalSizeGB = Math.Round(drive.TotalSize / (1024.0 * 1024 * 1024), 2);
                double freeSpaceGB = Math.Round(drive.TotalFreeSpace / (1024.0 * 1024 * 1024), 2);
                double freePercent = (drive.TotalFreeSpace / (double)drive.TotalSize) * 100;

                string status = freePercent < 15 ? "⚠ Low Space!" : "Healthy";

                Console.WriteLine("{0,-10} {1,-12} {2,15} {3,15} {4}", drive.Name, drive.DriveType, totalSizeGB, freeSpaceGB, status);
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: You do not have permission to access some drives.");
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