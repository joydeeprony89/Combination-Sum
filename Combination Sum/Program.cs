using System;
using System.Collections.Generic;

namespace Combination_Sum
{
  //
  class Program
  {
    static void Main(string[] args)
    {
      var nums = new int[] { 2, 3, 5 };
      int target = 8;
      Program p = new Program();
      var result = p.CombinationSum(nums, target);
      foreach (var res in result)
        Console.WriteLine(string.Join(",", res));
    }

    public IList<IList<int>> CombinationSum(int[] nums, int target)
    {
      var result = new List<IList<int>>();
      //Array.Sort(nums);
      Backtracking(result, nums, target, new List<int>(), 0, 0);
      return result;
    }

    private void Backtracking(List<IList<int>> result, int[] nums, int target, IList<int> temp, int start, int currentSum)
    {
      if (currentSum > target) return;
      if (currentSum == target)
      {
        result.Add(new List<int>(temp));
        return;
      }
      for (int i = start; i < nums.Length; i++)
      {
        temp.Add(nums[i]);
        currentSum += nums[i];
        Backtracking(result, nums, target, temp, i, currentSum);
        temp.RemoveAt(temp.Count - 1);
        currentSum -= nums[i];
      }
    }
  }
}
