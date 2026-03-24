using System;
using System.Collections.Generic;

// 🔹 1. Student Class (Only Data)
class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public double Marks { get; set; }
}

// 🔹 2. StudentRepository (Data Management)
class StudentRepository
{
    private List<Student> students = new List<Student>();

    public void AddStudent(Student student)
    {
        // Basic validation (Security Practice)
        if (string.IsNullOrWhiteSpace(student.StudentName))
        {
            throw new ArgumentException("Student name cannot be empty.");
        }

        if (student.Marks < 0 || student.Marks > 100)
        {
            throw new ArgumentException("Marks must be between 0 and 100.");
        }

        students.Add(student);
    }

    public List<Student> GetAllStudents()
    {
        return students;
    }
}

// 🔹 3. ReportGenerator (Report Only)
class ReportGenerator
{
    public void GenerateReport(List<Student> students)
    {
        Console.WriteLine("\n--- Student Report ---");

        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.StudentId}");
            Console.WriteLine($"Name: {student.StudentName}");
            Console.WriteLine($"Marks: {student.Marks}");
            Console.WriteLine($"Grade: {CalculateGrade(student.Marks)}");
            Console.WriteLine("----------------------");
        }
    }

    private string CalculateGrade(double marks)
    {
        if (marks >= 80) return "A";
        else if (marks >= 60) return "B";
        else if (marks >= 40) return "C";
        else return "Fail";
    }
}

// 🔹 Main Program
class Program1
{
    static void Main(string[] args)
    {
        StudentRepository repo = new StudentRepository();
        ReportGenerator report = new ReportGenerator();

        try
        {
            repo.AddStudent(new Student { StudentId = 1, StudentName = "Ali", Marks = 85 });
            repo.AddStudent(new Student { StudentId = 2, StudentName = "Sara", Marks = 72 });
            repo.AddStudent(new Student { StudentId = 3, StudentName = "John", Marks = 35 });

            // Generate Report
            report.GenerateReport(repo.GetAllStudents());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}