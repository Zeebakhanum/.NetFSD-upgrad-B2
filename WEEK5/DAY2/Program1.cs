using System;

namespace StudentRecordSystem
{
    // 1. Define Record (Struct)
    struct Student
    {
        public int RollNumber;
        public string Name;
        public string Course;
        public int Marks;
    }

    class Program1
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[100];
            int count = 0;
            int choice;

            do
            {
                Console.WriteLine("\n--- Student Record Management System ---");
                Console.WriteLine("1. Add Students");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Search Student by Roll Number");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter number of students: ");
                        int n = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine($"\nEnter details for Student {i + 1}:");

                            // Input validation for Roll Number
                            Console.Write("Enter Roll Number: ");
                            students[count].RollNumber = ReadValidInt();

                            Console.Write("Enter Name: ");
                            students[count].Name = Console.ReadLine();

                            Console.Write("Enter Course: ");
                            students[count].Course = Console.ReadLine();

                            // Input validation for Marks
                            Console.Write("Enter Marks: ");
                            students[count].Marks = ReadValidMarks();

                            count++;
                        }
                        break;

                    case 2:
                        Console.WriteLine("\nStudent Records:");
                        if (count == 0)
                        {
                            Console.WriteLine("No records found.");
                        }
                        else
                        {
                            for (int i = 0; i < count; i++)
                            {
                                Console.WriteLine($"Roll No: {students[i].RollNumber} | Name: {students[i].Name} | Course: {students[i].Course} | Marks: {students[i].Marks}");
                            }
                        }
                        break;

                    case 3:
                        Console.Write("\nEnter Roll Number to search: ");
                        int searchRoll = ReadValidInt();
                        bool found = false;

                        for (int i = 0; i < count; i++)
                        {
                            if (students[i].RollNumber == searchRoll)
                            {
                                Console.WriteLine("\nStudent Found:");
                                Console.WriteLine($"Roll No: {students[i].RollNumber} | Name: {students[i].Name} | Course: {students[i].Course} | Marks: {students[i].Marks}");
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Console.WriteLine("Student record not found.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

            } while (choice != 4);
        }

        // Method for integer validation
        static int ReadValidInt()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid input. Enter a valid number: ");
            }
            return value;
        }

        // Method for marks validation (0–100)
        static int ReadValidMarks()
        {
            int marks;
            while (!int.TryParse(Console.ReadLine(), out marks) || marks < 0 || marks > 100)
            {
                Console.Write("Invalid marks. Enter value between 0 and 100: ");
            }
            return marks;
        }
    }
}