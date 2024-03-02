using System;
using System.Collections.Generic;

namespace Combination_Sum
{
    //https://www.youtube.com/watch?v=GBKI9VSKdGg
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 2, 3, 6, 7 };
            int target = 7;
            Solution p = new Solution();
            var result = p.CombinationSum(nums, target);
            foreach (var res in result)
                Console.WriteLine(string.Join(",", res));
        }
        public class Solution
        {
            public IList<IList<int>> CombinationSum(int[] candidates, int target)
            {
                var res = new List<IList<int>>();
                var temp = new List<int>();
                void Dfs(int i, int total)
                {
                    // base case
                    if (total == target)
                    {
                        res.Add(new List<int>(temp));
                        return;
                    }
                    // if index out of ound
                    if (i >= candidates.Length || total > target)
                    {
                        return;
                    }

                    temp.Add(candidates[i]);
                    total += candidates[i];
                    // add the same no multiple times
                    Dfs(i, total);
                    var val = temp[temp.Count - 1];
                    temp.RemoveAt(temp.Count - 1);
                    // add next no
                    Dfs(i + 1, total - val);
                }
                Dfs(0, 0);
                return res;
            }
        }
    }
}
