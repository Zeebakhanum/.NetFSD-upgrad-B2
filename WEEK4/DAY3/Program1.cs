using System;


namespace ConsoleApp2
{
    internal class Program1
    {
        static void Main(string[] args)
        {

            Console.Write("Enter Name: ");
            String name = Console.ReadLine();

            Console.Write("Enter Marks: ");
            int marks = Convert.ToInt32(Console.ReadLine());

            if (marks < 0 || marks > 100)
            {
                Console.WriteLine("Invalid Marks");
            }
            else if (marks >= 90)
            {
                Console.WriteLine("Student: " + name + " Grade: A");
            }
            else if (marks >= 75)
            {
                Console.WriteLine("Student: " + name + " Grade: B");
            }
            else if (marks >= 60)
            {
                Console.WriteLine("Student: " + name + " Grade: C");
            }
            else if (marks >= 40)
            {
                Console.WriteLine("Student: " + name + " Grade: D");
            }
            else
            {
                Console.WriteLine("Student: " + name + " Grade: Fail");
            }

        }
    }

}
