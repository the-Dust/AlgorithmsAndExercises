using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class Lc39
    {
        public void SelfTest()
        {
            var res1 = CombinationSum(new int[] { 2, 3, 6, 7 }, 7); // [[2,2,3],[7]]
            var res2 = CombinationSum(new int[] { 2, 3, 5 }, 8); // [[2,2,2,2],[2,3,3],[3,5]]
            var res3 = CombinationSum(new int[] { 2 }, 1); // []
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            Array.Sort(candidates);
            return CombinationSum(candidates, target, 0); ;
        }

        private IList<IList<int>> CombinationSum(int[] candidates, int target, int start)
        {
            IList<IList<int>> result = new List<IList<int>>();

            for(int i = start; i < candidates.Length; i++)
            {
                var candidate = candidates[i];
                var delta = target - candidate;
                if (delta < 0)
                    continue;
                else if(delta == 0)
                {
                    result.Add(new List<int>() { candidate });
                }
                else
                {
                    var res = CombinationSum(candidates, target - candidate, i);
                    foreach (var list in res)
                    {
                        list.Add(candidate);
                        result.Add(list);
                    }
                }
            }
            return result;
        }
    }
}
