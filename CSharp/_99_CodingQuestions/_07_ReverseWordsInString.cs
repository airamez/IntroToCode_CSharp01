// https://leetcode.com/problems/reverse-words-in-a-string/?envType=study-plan-v2&envId=top-interview-150
using System;
using System.Collections.Generic;

namespace CodingQuestions;

public class ReverseWordsInString
{
  public static void Main(string[] args)
  {
    Console.WriteLine(ReverseWords("the sky is blue"));
    Console.WriteLine(ReverseWords("  hello world  "));
    Console.WriteLine(ReverseWords("a good   example"));
  }

  public static string ReverseWords(string s)
  {
    string[] words = s.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
    int left = 0;
    int right = words.Length - 1;
    while (left < right)
    {
      string aux = words[left];
      words[left] = words[right];
      words[right] = aux;
      left++;
      right--;
    }
    return String.Join(" ", words);
  }
}