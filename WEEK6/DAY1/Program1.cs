using System;
using System.Threading.Tasks;

class Program1
{
    // Asynchronous method to simulate writing logs
    public static async Task WriteLogAsync(string message)
    {
        Console.WriteLine($"Start writing log: {message}");

        // Simulate file writing delay (like saving to file)
        await Task.Delay(2000);

        Console.WriteLine($"Finished writing log: {message}");
    }

    static async Task Main(string[] args)
    {
        Console.WriteLine("Logging started...\n");

        // Calling async method multiple times
        Task log1 = WriteLogAsync("User logged in");
        Task log2 = WriteLogAsync("File uploaded");
        Task log3 = WriteLogAsync("Error occurred");

        // Main thread continues without waiting immediately
        Console.WriteLine("Main thread is free to do other work...\n");

        // Wait for all logs to complete
        await Task.WhenAll(log1, log2, log3);

        Console.WriteLine("\nAll logs written successfully!");
    }
}