using System.Collections.Generic;
using System.Linq;
using Utils;

namespace DivideConquer
{
    [ShouldRepeat]
    public class MajorityElement
    {
        public void SelfTest()
        {
            var arr1 = new long[] { 2, 3, 9, 2, 2 };
            var arr2 = new long[] { 512766168, 717383758, 5, 126144732, 5, 573799007, 5, 5, 5, 405079772 };

            var res1 = Calculate(arr1); // true
            var res2 = Calculate(arr2); // false
        }

        public bool Calculate(long[] arr)
        {
            var candidates = Candidates(arr.ToList());
            foreach (var candidate in candidates)
            {
                var count = 0;
                foreach (var num in arr)
                {
                    if (candidate == num)
                    {
                        count++;
                        if (count > arr.Length / 2)
                            return true;
                    }
                }
            }
            return false;
        }

        private List<long> Candidates(List<long> list)
        {
            if (list.Count <= 2)
            {
                return list;
            }
            List<long> candidates = new List<long>();
            var count = list.Count;
            if (count % 2 == 1)
            {
                candidates.Add(list[count - 1]);
            }
            for (int i = 0; i <= count - 2; i += 2)
            {
                if (list[i] == list[i + 1])
                {
                    candidates.Add(list[i]);
                }
            }
            return Candidates(candidates);
        }
    }
}
