using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Collections;

public class SortedDictionaryApp
{
  public static void Main(string[] args)
  {
    var musicPlays = new Dictionary<string, HashSet<int>>();
    musicPlays.Add("Music 1", new HashSet<int> { 1, 2, 3, });
    musicPlays.Add("Music 2", new HashSet<int> { 4, 5, 6, 7 });
    musicPlays.Add("Music 3", new HashSet<int> { 1, 2, 3, 4, 5 });
    musicPlays.Add("Music 4", new HashSet<int> { 3, 4, 5 });
    musicPlays.Add("Music 5", new HashSet<int> { 3, 4, 5, 8, 1, 2, 3, 4, 9, 0 });
    musicPlays.Add("Music 6", new HashSet<int> { 11, 12, 13 });
    musicPlays.Add("Music 7", new HashSet<int> { 8, 9, 10 });
    musicPlays.Add("Music 8", new HashSet<int> { 0, 1, 2 });
    musicPlays.Add("Music 9", new HashSet<int> { 8, 1, 2 });

    var summary = new SortedDictionary<int, List<string>>();
    foreach (var musicId in musicPlays.Keys)
    {
      int playsCount = musicPlays[musicId].Count;
      if (!summary.ContainsKey(playsCount))
      {
        summary.Add(playsCount, new List<string>());
      }
      summary[playsCount].Add(musicId);
    }

    foreach (var playsCount in summary.Keys)
    {
      Console.Write($"{playsCount}: ");
      summary[playsCount].Sort();
      foreach (var music in summary[playsCount])
      {
        Console.Write($"{music}, ");
      }
      Console.WriteLine();
    }
  }
}