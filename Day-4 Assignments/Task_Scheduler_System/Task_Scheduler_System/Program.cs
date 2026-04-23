// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

class TaskSchedulerSystem
{
    static void Main()
    {
        Queue<string> taskQueue = new Queue<string>();
        Stack<string> undoStack = new Stack<string>();
        List<string> allTasks = new List<string>();
        SortedDictionary<int, string> priorityTasks = new SortedDictionary<int, string>();
        HashSet<string> uniqueTasks = new HashSet<string>();

        // Add task
        if (uniqueTasks.Add("Task1"))
        {
            taskQueue.Enqueue("Task1");
            allTasks.Add("Task1");
        }

        priorityTasks[1] = "High Priority Task";
        priorityTasks[2] = "Low Priority Task";

        // Execute task
        string task = taskQueue.Dequeue();
        Console.WriteLine("Executing: " + task);
        undoStack.Push(task);

        // Undo task
        Console.WriteLine("Undo: " + undoStack.Pop());

        // Priority tasks
        foreach (var t in priorityTasks)
            Console.WriteLine($"{t.Key}: {t.Value}");
    }
}
