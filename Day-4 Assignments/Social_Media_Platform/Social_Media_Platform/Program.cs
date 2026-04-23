// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

class SocialMedia
{
    static void Main()
    {
        List<string> posts = new List<string>();
        Dictionary<string, int> likes = new Dictionary<string, int>();
        HashSet<int> users = new HashSet<int>();
        Stack<string> actions = new Stack<string>();
        Queue<string> notifications = new Queue<string>();

        // Add users
        users.Add(1);
        users.Add(2);

        // Add post
        posts.Add("Hello World");
        likes["Hello World"] = 0;

        // Like post
        likes["Hello World"]++;
        Console.WriteLine("Likes: " + likes["Hello World"]);

        // Track action
        actions.Push("Post Created");
        actions.Push("Post Liked");

        // Undo action
        Console.WriteLine("Undo: " + actions.Pop());

        // Notifications
        notifications.Enqueue("New Like");
        notifications.Enqueue("New Comment");

        Console.WriteLine("Notification: " + notifications.Dequeue());
    }
}
