using System;
using System.Diagnostics;
using System.IO;

class Program5
{
    static void Main(string[] args)
    {
        // Configure Trace Listener (log file)
        Trace.Listeners.Clear();
        Trace.Listeners.Add(new TextWriterTraceListener("order_log.txt"));
        Trace.AutoFlush = true;

        Console.WriteLine("Order Processing Started...\n");
        Trace.TraceInformation("Order Processing Started");

        try
        {
            ValidateOrder();
            ProcessPayment();
            UpdateInventory();
            GenerateInvoice();

            Trace.TraceInformation("Order processed successfully!");
            Console.WriteLine("\nOrder processed successfully!");
        }
        catch (Exception ex)
        {
            Trace.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine("\nOrder processing failed!");
        }

        Trace.Close();
    }

    static void ValidateOrder()
    {
        Trace.WriteLine("Step 1: Validating Order...");
        Console.WriteLine("Validating Order...");
        // Simulate success
    }

    static void ProcessPayment()
    {
        Trace.WriteLine("Step 2: Processing Payment...");
        Console.WriteLine("Processing Payment...");
        // Simulate success
    }

    static void UpdateInventory()
    {
        Trace.WriteLine("Step 3: Updating Inventory...");
        Console.WriteLine("Updating Inventory...");

        // 🔴 Simulate failure (for debugging demo)
        throw new Exception("Inventory update failed!");
    }

    static void GenerateInvoice()
    {
        Trace.WriteLine("Step 4: Generating Invoice...");
        Console.WriteLine("Generating Invoice...");
    }
}