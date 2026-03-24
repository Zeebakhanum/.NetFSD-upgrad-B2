using System;

// 🔹 1. Interface
interface INotification
{
    void Send(string message);
}

// 🔹 2. Concrete Classes

class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine("Email Notification: " + message);
    }
}

class SMSNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine("SMS Notification: " + message);
    }
}

class PushNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine("Push Notification: " + message);
    }
}

// 🔹 3. Factory Class
class NotificationFactory
{
    public INotification CreateNotification(string type)
    {
        if (type.ToLower() == "email")
            return new EmailNotification();
        else if (type.ToLower() == "sms")
            return new SMSNotification();
        else if (type.ToLower() == "push")
            return new PushNotification();
        else
            throw new ArgumentException("Invalid notification type");
    }
}

// 🔹 Main Program
class Program6
{
    static void Main(string[] args)
    {
        NotificationFactory factory = new NotificationFactory();

        // Create Email Notification
        INotification notification1 = factory.CreateNotification("email");
        notification1.Send("Welcome to our service!");

        // Create SMS Notification
        INotification notification2 = factory.CreateNotification("sms");
        notification2.Send("Your OTP is 1234");

        // Create Push Notification
        INotification notification3 = factory.CreateNotification("push");
        notification3.Send("You have a new alert!");
    }
}