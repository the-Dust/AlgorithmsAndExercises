using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;

namespace YandexCup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var task = Console.ReadLine().Split();
            int datacenters = int.Parse(task[0]);
            int servers = int.Parse(task[1]);
            int events = int.Parse(task[2]);
            var dc = new DataCenter[datacenters];
            var pq = new PriorityQueue();
            for (int i = 0; i < datacenters; i++)
            {
                var center = new DataCenter(servers);
                dc[i] = center;
                pq.Add(i, center);
            }
            List<int> answers = new List<int>();

            for (int i = 0; i < events; i++)
            {
                var evnt = Console.ReadLine();
                if (evnt.StartsWith("DISABLE"))
                {
                    var data = evnt.Substring(8).Split();
                    var centerInd = int.Parse(data[0]) - 1;
                    var serverInd = int.Parse(data[1]) - 1;
                    var center = dc[centerInd];
                    var oldState = center.State;
                    center.Disable(serverInd);
                    pq.Replace(centerInd, center, oldState);
                }
                else if (evnt.StartsWith("RESET"))
                {
                    var data = int.Parse(evnt.Substring(6)) - 1;
                    var center = dc[data];
                    var oldState = center.State;
                    center.Reset();
                    pq.Replace(data, center, oldState);
                }
                else if (evnt == "GETMAX")
                {
                    answers.Add(pq.Max() + 1);
                }
                else if (evnt == "GETMIN")
                {
                    answers.Add(pq.Min() + 1);
                }
            }
            answers.ForEach(x => Console.WriteLine(x));
        }
    }

    class PriorityQueue
    {
        private SortedDictionary<long, SortedDictionary<int, DataCenter>> map = new();

        public int Min()
        {
            var min = map[map.Keys.First()].First().Key;
            return min;
        }

        public int Max()
        {
            var max = map[map.Keys.Last()].First().Key;
            return max;
        }

        public void Add(int index, DataCenter dc)
        {
            var state = dc.State;
            if (map.TryGetValue(state, out var innerMap))
            {
                innerMap[index] = dc;
            }
            else
            {
                map[state] = new SortedDictionary<int, DataCenter>(){{index, dc}};
            }
        }

        public void Replace(int index, DataCenter dc, long oldState)
        {
            var innerMap = map[oldState];
            innerMap.Remove(index);
            if (!innerMap.Any())
            {
                map.Remove(oldState);
            }
            Add(index, dc);
        }
    }

    class DataCenter
    {
        private bool[] servers;
        private int resets = 0;
        private int working = 0;
        private int state = -1;

        public long State
        {
            get
            {
                if (state == -1)
                {
                    state = resets * working;
                }

                return state;
            }
        }

        public void Reset()
        {
            for (int i = 0; i < servers.Length; i++)
            {
                servers[i] = false;
            }

            resets++;
            working = servers.Length;
            state = -1;
        }

        public void Disable(int server)
        {
            if (!servers[server])
            {
                servers[server] = true;
                working--;
                state = -1;
            }
        }

        public DataCenter(int count)
        {
            servers = new bool[count]; // inverse logic
            working = count;
        }
    }
}
