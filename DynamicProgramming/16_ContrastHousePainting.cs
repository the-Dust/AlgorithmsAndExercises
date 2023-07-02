using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Utils;

namespace DynamicProgramming
{
    [ShouldRepeat]
    public class ContrastHousePainting
    {
        private string[] letters = new[] { "a", "b", "c" };

        public void SelfTest()
        {
            /*var graph = new Dictionary<string, Dictionary<string, int>> {
                ["start"] = new Dictionary<string, int> { ["a"] = 6, ["b"] = 2 },
                ["a"] = new Dictionary<string, int> { ["end"] = 1 },
                ["b"] = new Dictionary<string, int> { ["a"] = 3, ["end"] = 5 },
                ["end"] = new Dictionary<string, int> { },
            };

            var path = ShortestPathDag(graph, "start", "end");*/

            var table = new[]
            {
                new [] {3,2,3},
                new [] {8,3,1},
                new [] {5,4,2},
                new [] {9,2,8},
            };

            var res = Calculate(table); // 11
        }

        public int Calculate(int[][] table)
        {
            var map = new Dictionary<string, Dictionary<string, int>>();
            map["startA"] = new Dictionary<string, int>() { ["b0"] = table[0][1], ["c0"] = table[0][2] };
            map["startB"] = new Dictionary<string, int>() { ["a0"] = table[0][0], ["c0"] = table[0][2] };
            map["startC"] = new Dictionary<string, int>() { ["b0"] = table[0][1], ["a0"] = table[0][0] };
            for (int i = 0; i < table.Length - 1; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    var node = NodeName(j, i);
                    map[node] = new Dictionary<string, int>();
                    for(int k = 0; k < 3; k++)
                    {
                        if (k == j)
                            continue;
                        var neighbour = NodeName(k, i + 1);
                        map[node][neighbour] = table[i + 1][k];
                    }
                }
            }
            var lastLevel = table.Length - 1;
            map[$"a{lastLevel}"] = new Dictionary<string, int>() { ["endB"] = 0, ["endC"] = 0 };
            map[$"b{lastLevel}"] = new Dictionary<string, int>() { ["endA"] = 0, ["endC"] = 0 };
            map[$"c{lastLevel}"] = new Dictionary<string, int>() { ["endA"] = 0, ["endB"] = 0 };

            var pathA = ShortestPathDag(map, "startA", "endA");
            var pathB = ShortestPathDag(map, "startB", "endB");
            var pathC = ShortestPathDag(map, "startC", "endC");

            return Math.Min(pathA, Math.Min(pathB, pathC));
        }

        private string NodeName(int letter, int num) => $"{(char)('a' + letter)}{num}";

        private int ShortestPathDag(Dictionary<string, Dictionary<string, int>> graph, string start, string end)
        {
            var processed = new HashSet<string>();
            var parents = new Dictionary<string, string>();
            var costs = new Dictionary<string, int>();

            graph[start].ToList().ForEach(x =>
            {
                costs[x.Key] = x.Value;
                parents[x.Key] = start;
            });

            Func<string> minimalCost = () => costs
                .Where(x => !processed.Contains(x.Key) && graph.ContainsKey(x.Key))
                .Aggregate(new KeyValuePair<string, int>("", int.MaxValue), (acc, x) => acc.Value < x.Value ? acc : x).Key;

            var node = minimalCost();
            while(node != "" && graph.TryGetValue(node, out var neighbours)) 
            {
                foreach(var (neigh, cost) in neighbours)
                {
                    var newCost = costs[node] + cost;
                    if(!costs.TryGetValue(neigh, out var oldCost) || oldCost > newCost)
                    {
                        costs[neigh] = newCost;
                        parents[neigh] = node;
                    }
                }
                processed.Add(node);
                node = minimalCost();
            }
            return costs[end];
        }
    }

}
