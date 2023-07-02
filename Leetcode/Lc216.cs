using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class Lc216
    {
        public void SelfTest()
        {
            var res1 = CombinationSum3(3, 7); // [[1,2,4]]
            var res2 = CombinationSum3(3, 9); // [[1,2,6],[1,3,5],[2,3,4]]
            var res3 = CombinationSum3(4, 1); // []
        }

        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            return CombinationSum3(k, n, 1);
        }

        private IList<IList<int>> CombinationSum3(int k, int n, int min)
        {
            IList<IList<int>> result = new List<IList<int>>();

            if (k == 1)
            {
                if (n <= 9 && min <= n)
                {
                    result.Add(new List<int>() { n });
                    return result;
                }
                else return null;
            }
            var max = Math.Min(9, n);
            for(int i = min; i < max; i++)
            {
                var res = CombinationSum3(k - 1, n - i, i + 1);
                if (res != null)
                {
                    foreach(var l in res)
                    {
                        l.Add(i);
                        result.Add(l);
                    }
                    
                }
            }
            return result;
        }
    }
}
