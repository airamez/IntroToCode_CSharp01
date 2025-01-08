// https://leetcode.com/problems/jump-game/?envType=study-plan-v2&envId=top-interview-150
using System;
using System.Collections.Generic;

namespace CodingQuestions;

public class JumpGame
{

  public static void Main(string[] args)
  {
    Console.WriteLine(CanJump([2, 3, 1, 1, 4]));
    Console.WriteLine(CanJump([3, 2, 1, 0, 4]));
    Console.WriteLine(CanJump([0]));
    Console.WriteLine(CanJump([1]));
  }

  public static bool CanJump(int[] nums)
  {
    var dp = new bool[nums.Length];
    dp[nums.Length - 1] = true;
    for (var i = nums.Length - 2; i >= 0; i--)
    {
      for (int j = 1; j <= nums[i]; j++)
      {
        if (dp[i + j])
        {
          dp[i] = true;
          break;
        }
      }
    }
    return dp[0];
  }
}