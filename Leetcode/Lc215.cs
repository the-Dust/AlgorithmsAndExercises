namespace Leetcode
{
    public class Lc215
    {
        private Random rnd = new();

        public void SelfTest()
        {
            var arr1 = new[] { 3, 2, 1, 5, 6, 4 };
            var arr2 = new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            var arr3 = new[] { -1, 2, 0 };

            var ans1 = FindKthLargest(arr1, 2); // 5
            var ans2 = FindKthLargest(arr2, 4); // 4
            var ans3 = FindKthLargest(arr3, 2); // 0
        }

        public int FindKthLargest(int[] nums, int k)
        {
            return Sort(nums, 0, nums.Length, k);
        }

        private int Sort(int[] arr, int l, int r, int count)
        {
            int q = rnd.Next(l, r);
            var m = Partition(arr, l, q, r);
            if (r - m == count)
                return arr[m];
            else if (r - m > count)
                return Sort(arr, m + 1, r, count);
            else
                return Sort(arr, l, m, count - (r - m));
        }

        private int Partition(int[] arr, int l, int q, int r)
        {
            int pivot = arr[q];
            int j = l;
            Swap(ref arr[q], ref arr[r - 1]);
            for (int i = l; i < r - 1; i++)
            {
                if (arr[i] < pivot)
                {
                    Swap(ref arr[i], ref arr[j]);
                    j++;
                }
            }
            Swap(ref arr[j], ref arr[r - 1]);
            return j;
        }

        private void Swap(ref int a, ref int b) => (a, b) = (b, a);
    }
}