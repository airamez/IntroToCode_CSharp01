/*
   Create a C# program that processes inputs of song names along with the 
   users who played them. At the end, generate a summary of the most played songs,
   ranked by the number of unique users who played each song.
   Display the results in ascending order of play count, and for songs with the 
   same play count, sort them alphabetically.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Collections;

public class SortedDictionaryDemoApp
{
  public static void Main(string[] args)
  {
    MusicPlayer player = new MusicPlayer();
    player.PlaySong("Bohemian Rhapsody", 1);
    player.PlaySong("Bohemian Rhapsody", 1);
    player.PlaySong("Bohemian Rhapsody", 2);
    player.PlaySong("Bohemian Rhapsody", 2);
    player.PlaySong("Bohemian Rhapsody", 3);
    player.PlaySong("Bohemian Rhapsody", 4);
    player.PrintMusicPlayingSummary();

    player.PlaySong("Imagine", 1);
    player.PlaySong("Imagine", 2);
    player.PlaySong("Imagine", 3);
    player.PlaySong("Imagine", 1);
    player.PlaySong("Imagine", 2);
    player.PlaySong("Imagine", 3);
    player.PrintMusicPlayingSummary();

    player.PlaySong("Despacito", 1);
    player.PlaySong("Despacito", 1);
    player.PlaySong("Despacito", 1);
    player.PrintMusicPlayingSummary();

    player.PlaySong("Three Little Birds", 1);
    player.PlaySong("Three Little Birds", 2);
    player.PlaySong("Three Little Birds", 3);
    player.PrintMusicPlayingSummary();

    player.PlaySong("Hotel California", 1);
    player.PlaySong("Hotel California", 2);
    player.PlaySong("Hotel California", 2);
    player.PlaySong("Hotel California", 3);
    player.PrintMusicPlayingSummary();

    player.PlaySong("Wonderwall", 1);
    player.PlaySong("Wonderwall", 1);
    player.PlaySong("Wonderwall", 2);
    player.PrintMusicPlayingSummary();

    player.PlaySong("Hey Jude", 1);
    player.PlaySong("Hey Jude", 1);
    player.PlaySong("Hey Jude", 2);
    player.PlaySong("Hey Jude", 3);
    player.PrintMusicPlayingSummary();

    player.PlaySong("Smells Like Teen Spirit", 1);
    player.PlaySong("Smells Like Teen Spirit", 2);
    player.PlaySong("Smells Like Teen Spirit", 3);
    player.PrintMusicPlayingSummary();

    player.PlaySong("Rolling in the Deep", 1);
    player.PlaySong("Rolling in the Deep", 2);
    player.PrintMusicPlayingSummary();

    player.PlaySong("Stairway to Heaven", 1);
    player.PlaySong("Stairway to Heaven", 2);
    player.PlaySong("Stairway to Heaven", 3);
    player.PlaySong("Stairway to Heaven", 4);
    player.PrintMusicPlayingSummary();
  }
}

public class MusicPlayer
{
  private Dictionary<string, HashSet<int>> musicPlays;

  public MusicPlayer()
  {
    musicPlays = new Dictionary<string, HashSet<int>>();
  }
  public void PlaySong(string musicId, int playerId)
  {
    if (!musicPlays.ContainsKey(musicId))
    {
      musicPlays[musicId] = new HashSet<int>();
    }
    musicPlays[musicId].Add(playerId);
  }

  public void PrintMusicPlayingSummary()
  {
    Console.WriteLine("Music plays summary");
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

    foreach (var playsCount in summary.Keys.Reverse())
    {
      Console.Write($"{playsCount}: ");
      summary[playsCount].Sort();
      foreach (var music in summary[playsCount])
      {
        Console.Write($"[{music}], ");
      }
      Console.WriteLine();
    }
  }
}