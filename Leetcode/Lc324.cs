using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class Lc324
    {
        public void SelfTest()
        {
            int[] arr = { 1, 5, 1, 1, 6, 4 };
            Calculate(arr);
        }

        public void Calculate(int[] nums)
        {
            var arr = nums.OrderBy(x => x).ToArray();
            var i = nums.Length / 2 - 1;
            if (nums.Length % 2 == 1)
                i++;
            var m = i;
            var j = arr.Length - 1;
            for (int n = 1; j > m; n += 2)
            {
                nums[n - 1] = arr[i];
                nums[n] = arr[j];
                i--;
                j--;
            }
            if (i == 0)
                nums[nums.Length - 1] = arr[i];
        }
    }
}
