// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // ===== SYNCHRONOUS EXECUTION =====
        Console.WriteLine("===== SYNCHRONOUS EXECUTION =====");

        Stopwatch syncWatch = Stopwatch.StartNew();

        LoadStudentDetails();
        LoadMarks();
        LoadAttendance();

        syncWatch.Stop();
        Console.WriteLine($"Total Time (Sync): {syncWatch.ElapsedMilliseconds} ms\n");

        // ===== ASYNCHRONOUS EXECUTION =====
        Console.WriteLine("===== ASYNCHRONOUS EXECUTION =====");

        Stopwatch asyncWatch = Stopwatch.StartNew();

        Task t1 = LoadStudentDetailsAsync();
        Task t2 = LoadMarksAsync();
        Task t3 = LoadAttendanceAsync();

        await Task.WhenAll(t1, t2, t3);

        asyncWatch.Stop();
        Console.WriteLine($"Total Time (Async): {asyncWatch.ElapsedMilliseconds} ms");
    }

    // ---------- SYNCHRONOUS METHODS ----------
    static void LoadStudentDetails()
    {
        Task.Delay(2000).Wait(); // Simulate delay
        Console.WriteLine("Student Details Loaded");
    }

    static void LoadMarks()
    {
        Task.Delay(2000).Wait();
        Console.WriteLine("Marks Loaded");
    }

    static void LoadAttendance()
    {
        Task.Delay(2000).Wait();
        Console.WriteLine("Attendance Loaded");
    }

    // ---------- ASYNCHRONOUS METHODS ----------
    static async Task LoadStudentDetailsAsync()
    {
        await Task.Delay(2000);
        Console.WriteLine("Student Details Loaded");
    }

    static async Task LoadMarksAsync()
    {
        await Task.Delay(2000);
        Console.WriteLine("Marks Loaded");
    }

    static async Task LoadAttendanceAsync()
    {
        await Task.Delay(2000);
        Console.WriteLine("Attendance Loaded");
    }
}