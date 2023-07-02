using Utils;

namespace GreedyAlgorithms
{
    [ShouldRepeat]
    public class ConnectRopesWithMinimalCost
    {
        public void SelfTest()
        {

        }

        public int Calculate(int[] lengths)
        {
            if (lengths.Length == 1)
                return lengths[0];

            var res = 0;
            var heap = new Heap(lengths);

            while (heap.Count > 1)
            {
                var a = heap.GetMin();
                var b = heap.GetMin();
                var sum = a + b;
                heap.Add(sum);
                res += sum;
            }
            return res;
        }
    }

    class Heap
    {
        private List<int> list = new();
        private int last = -1;

        public int Count => last + 1;

        public Heap(int[] arr)
        {
            this.list = arr.ToList();
            this.last = arr.Length - 1;
            for (int i = last / 2; i >= 0; i--)
            {
                SiftDown(i);
            }
        }

        public int GetMin()
        {
            var res = list[0];
            Swap(0, last);
            last--;
            SiftDown(0);
            return res;
        }

        public void Add(int value)
        {
            last++;
            if (last == list.Count)
                list.Add(value);
            else
                list[last] = value;
            SiftUp(last);
        }

        private void SiftUp(int i)
        {
            if (i == 0)
                return;

            var next = i / 2;
            if (list[next] > list[i])
            {
                Swap(next, i);
                SiftUp(next);
            }
        }

        private void SiftDown(int index)
        {
            int left = index * 2 + 1;
            int right = index * 2 + 2;

            if (left > last)
                return;
            if (right > last)
                right = left;

            var (i, min) = list[left] < list[right] ? (left, list[left]) : (right, list[right]);

            if (list[index] > min)
            {
                Swap(index, i);
                SiftDown(i);
            }
        }

        private void Swap(int a, int b)
        {
            var t = list[a];
            list[a] = list[b];
            list[b] = t;
        }
    }
}
