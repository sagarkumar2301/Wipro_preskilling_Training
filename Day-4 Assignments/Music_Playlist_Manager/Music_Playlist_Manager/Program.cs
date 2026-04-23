// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

class PlaylistManager
{
    static void Main()
    {
        LinkedList<string> playlist = new LinkedList<string>();
        SortedList<int, string> ratings = new SortedList<int, string>();
        SortedDictionary<string, string> artistMap = new SortedDictionary<string, string>();

        // Add songs
        playlist.AddLast("Song1");
        playlist.AddLast("Song2");

        // Remove song
        playlist.Remove("Song1");

        // Sorted by rating
        ratings.Add(5, "Song2");
        ratings.Add(3, "Song3");

        foreach (var item in ratings)
            Console.WriteLine(item.Value);

        // Artist mapping
        artistMap["Arijit"] = "Song2";
        artistMap["Atif"] = "Song3";

        foreach (var artist in artistMap)
            Console.WriteLine($"{artist.Key} -> {artist.Value}");
    }
}
