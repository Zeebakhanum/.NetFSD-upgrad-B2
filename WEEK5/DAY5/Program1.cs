using System;
using System.IO;
using System.Text;

class Program1
{
    static void Main()
    {
        string filePath = "log.txt"; // File to store messages
        Console.WriteLine("=== Simple Log Application ===");

        while (true)
        {
            Console.Write("Enter a message (or type 'exit' to quit): ");
            string message = Console.ReadLine();

            if (message.ToLower() == "exit")
            {
                Console.WriteLine("Exiting the application.");
                break;
            }

            try
            {
                // Convert message to bytes
                byte[] data = Encoding.UTF8.GetBytes(message + Environment.NewLine);

                // Open FileStream in append mode
                using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                {
                    fs.Write(data, 0, data.Length);
                }

                Console.WriteLine("Message saved successfully!\n");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Error: You do not have permission to write to the file.");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error: An I/O error occurred while writing to the file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}