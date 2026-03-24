using System;

class ConfigurationManager
{
    // 🔹 Static instance (only one)
    private static ConfigurationManager instance;

    // 🔹 Lock object (for thread safety)
    private static readonly object lockObj = new object();

    // 🔹 Properties
    public string ApplicationName { get; private set; }
    public string Version { get; private set; }
    public string DatabaseConnectionString { get; private set; }

    // 🔹 Private Constructor (prevents new)
    private ConfigurationManager()
    {
        ApplicationName = "Inventory System";
        Version = "1.0.0";
        DatabaseConnectionString = "Server=localhost;Database=InventoryDB;";
    }

    // 🔹 GetInstance Method (Thread-Safe)
    public static ConfigurationManager GetInstance()
    {
        if (instance == null)
        {
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = new ConfigurationManager();
                }
            }
        }
        return instance;
    }
}

// 🔹 Main Program
class Program5
{
    static void Main(string[] args)
    {
        // First call
        ConfigurationManager config1 = ConfigurationManager.GetInstance();

        // Second call
        ConfigurationManager config2 = ConfigurationManager.GetInstance();

        // Print values
        Console.WriteLine("Config 1:");
        PrintConfig(config1);

        Console.WriteLine("\nConfig 2:");
        PrintConfig(config2);

        // Check same instance
        Console.WriteLine("\nAre both instances same? " + (config1 == config2));
    }

    static void PrintConfig(ConfigurationManager config)
    {
        Console.WriteLine($"App Name: {config.ApplicationName}");
        Console.WriteLine($"Version: {config.Version}");
        Console.WriteLine($"DB Connection: {config.DatabaseConnectionString}");
    }
}