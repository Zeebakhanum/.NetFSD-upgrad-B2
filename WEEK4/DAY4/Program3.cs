using System;

class StudentResult
{
    // Method using out parameters
    public void CalculateResult(int m1, int m2, int m3, out int totalMarks, out double averageMarks)
    {
        totalMarks = m1 + m2 + m3;
        averageMarks = totalMarks / 3.0;
    }
}

class Program3
{
    static void Main()
    {
        StudentResult sr = new StudentResult();

        Console.Write("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine("\nStudent " + i);

            Console.Write("Enter mark1: ");
            int m1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter mark2: ");
            int m2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter mark3: ");
            int m3 = Convert.ToInt32(Console.ReadLine());

            // Input validation
            if (m1 < 0 || m1 > 100 || m2 < 0 || m2 > 100 || m3 < 0 || m3 > 100)
            {
                Console.WriteLine("Invalid marks! Marks must be between 0 and 100.");
                continue;
            }

            int total;
            double avg;

            // Calling method
            sr.CalculateResult(m1, m2, m3, out total, out avg);

            Console.WriteLine("Total Marks = " + total);
            Console.WriteLine("Average Marks = " + avg);

            if (avg >= 40)
                Console.WriteLine("Result = Pass");
            else
                Console.WriteLine("Result = Fail");
        }
    }
}