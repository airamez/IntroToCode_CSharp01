// https://leetcode.com/problems/letter-combinations-of-a-phone-number/

using System;
using System.Collections.Generic;

namespace CodingQuestions;

public class LetterCombinationOfPhoneNumber
{
  public static void Main(string[] args)
  {
    var input = "2";
    foreach (var item in LetterCombinations(input))
    {
      Console.Write($"{item}, ");
    }
  }

  public static IList<string> LetterCombinations(string digits)
  {
    if (digits == null || digits.Length == 0)
    {
      return new List<string>();
    }
    var dic = new Dictionary<char, List<char>>();
    dic['2'] = new List<char> { 'a', 'b', 'c' };
    dic['3'] = new List<char> { 'd', 'e', 'f' };
    dic['4'] = new List<char> { 'g', 'h', 'i' };
    dic['5'] = new List<char> { 'j', 'k', 'l' };
    dic['6'] = new List<char> { 'm', 'n', 'o' };
    dic['7'] = new List<char> { 'p', 'q', 'r', 's' };
    dic['8'] = new List<char> { 't', 'u', 'v' };
    dic['9'] = new List<char> { 'w', 'x', 'y', 'z' };

    var dpDic = new Dictionary<int, List<string>>();

    for (int i = 0; i < digits.Length; i++)
    {
      var letters = dic[digits[i]];
      AddToDpDic(dpDic, i, letters);
    }
    return dpDic[digits.Length - 1];
  }

  private static void AddToDpDic(Dictionary<int, List<string>> dpDic, int i, List<char> letters)
  {
    dpDic[i] = new List<string>();
    if (i == 0)
    {
      foreach (var letter in letters)
      {
        dpDic[0].Add(letter.ToString());
      }
    }
    else
    {
      foreach (var previousConbination in dpDic[i - 1])
      {
        foreach (var letter in letters)
        {
          dpDic[i].Add(previousConbination.ToString() + letter);
        }
      }
    }
  }
}