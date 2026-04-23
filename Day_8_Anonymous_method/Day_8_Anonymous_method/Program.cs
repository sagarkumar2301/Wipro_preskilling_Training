// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

// Model
public class Student
{
    public string? Name { get; set; }
    public int Marks { get; set; }
    public int Attendance { get; set; }
    public int Participation { get; set; }
}


public delegate void StudentEvaluation(Student student);

class Program
{
    static void Main()
    {
        Console.Write("Enter number of students: ");
        int.TryParse(Console.ReadLine(), out int n);

        var students = new List<Student>();

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEnter details for Student {i + 1}:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Marks: ");
            int marks; 
            int.TryParse(Console.ReadLine(), out marks);

            Console.Write("Attendance: ");
            int attendance; 
            int.TryParse(Console.ReadLine(), out attendance);

            Console.Write("Participation: ");
            int participation; 
            int.TryParse(Console.ReadLine(), out participation);

            students.Add(new Student
            {
                Name = name,
                Marks = marks,
                Attendance = attendance,
                Participation = participation
            });
        }






        // --------- ANONYMOUS METHOD ---------
        StudentEvaluation evaluate = delegate (Student s)
        {
            int total = s.Marks + s.Attendance + s.Participation;

            Console.WriteLine($"\nStudent: {s.Name}");
            Console.WriteLine($"Total Score: {total}");

            if (total > 180)
                Console.WriteLine("Performance: Excellent");
            else if (total > 120)
                Console.WriteLine("Performance: Good");
            else
                Console.WriteLine("Performance: Average");
        };

        // Execute evaluation
        Console.WriteLine("\n--- Student Evaluation ---");
        students.ForEach(s => evaluate(s));

        // --------- LAMBDA: ELIGIBILITY ---------
        Func<Student, bool> isEligible = s => s.Marks > 50;

        Console.WriteLine("\n--- Eligible Students (Marks > 50) ---");
        students.Where(isEligible)
                .ToList()
                .ForEach(s => Console.WriteLine(s.Name));

        // --------- LAMBDA: FILTERING ---------
        var filtered = students.Where(s => s.Marks > 50);

        Console.WriteLine("\n--- Filtered Students ---");
        foreach (var s in filtered)
        {
            Console.WriteLine($"{s.Name} - {s.Marks}");
        }

    }
}