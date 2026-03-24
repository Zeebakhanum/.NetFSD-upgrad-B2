using System;
using System.Threading.Tasks;

class Program4
{
    // Step 1: Verify Payment
    public static async Task<bool> VerifyPaymentAsync()
    {
        Console.WriteLine("Verifying payment...");
        await Task.Delay(2000); // Simulate delay
        Console.WriteLine("Payment verified ✅");
        return true;
    }

    // Step 2: Check Inventory
    public static async Task<bool> CheckInventoryAsync()
    {
        Console.WriteLine("Checking inventory...");
        await Task.Delay(2000); // Simulate delay
        Console.WriteLine("Inventory available ✅");
        return true;
    }

    // Step 3: Confirm Order
    public static async Task ConfirmOrderAsync()
    {
        Console.WriteLine("Confirming order...");
        await Task.Delay(1500); // Simulate delay
        Console.WriteLine("Order confirmed 🎉");
    }

    static async Task Main(string[] args)
    {
        Console.WriteLine("Order Processing Started...\n");

        // Step-by-step async execution (maintaining order)
        bool paymentStatus = await VerifyPaymentAsync();

        if (paymentStatus)
        {
            bool inventoryStatus = await CheckInventoryAsync();

            if (inventoryStatus)
            {
                await ConfirmOrderAsync();
            }
            else
            {
                Console.WriteLine("Order failed ❌: Out of stock");
            }
        }
        else
        {
            Console.WriteLine("Order failed ❌: Payment issue");
        }

        Console.WriteLine("\nOrder Processing Completed.");
    }
}