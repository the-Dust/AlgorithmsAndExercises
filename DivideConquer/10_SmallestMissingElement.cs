using Utils;

namespace DivideConquer
{
    [ShouldRepeat]
    public class SmallestMissingElement
    {
        public void SelfTest()
        {
            int[] arr1 = { 1, 2, 3, 4, 5 };
            int[] arr2 = { 2, 3, 4, 5 };
            int[] arr3 = { 0, 2, 3, 4, 5 };
            int[] arr4 = { 0, 1, 2, 3, 4, 5, 7 };
            int[] arr5 = { 0, 1, 2, 3, 5, 8, 9 };
            int[] arr6 = { 0, 1, 2, 3, 7, 8, 9 };

            var ans1 = Calculate(arr1); // -1
            var ans2 = Calculate(arr2); // -1
            var ans3 = Calculate(arr3); // 1
            var ans4 = Calculate(arr4); // 6
            var ans5 = Calculate(arr5); // 4
            var ans6 = Calculate(arr6); // 4
        }

        public int Calculate(int[] arr)
        {
            int l = 0;
            int r = arr.Length;
            int m;
            while(r - l > 1)
            {
                m = l + (r-l) / 2;
                if (arr[m] - m > arr[l] - l)
                    r = m;
                else
                    l = m;
            }
            return l == arr.Length-1 ? -1 : arr[l] + 1;
        }
    }
}
