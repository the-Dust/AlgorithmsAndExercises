using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityGame
{
    internal class CityGame
    {
        public string[] Solve(string[] cities, string[] reference)
        {
            var map = cities.GroupBy(x => x[0]).ToDictionary(x => x.Key, x => x.ToHashSet());
            var bestRes = new ChainResult();
            var paths = new Dictionary<string, string[]>();
            foreach (var city in cities)
            {
                var localMap = Copy(map, city);
                var res = TryFind(localMap, city, paths);
                if (res.Full)
                    return res.Chain.ToArray();
                else if (res.Chain.Count > bestRes.Chain.Count)
                    bestRes = res;
                TryAdd(paths, city, res.Chain.ToArray());
            }

            return bestRes.Chain.ToArray();
        }

        private ChainResult TryFind(Dictionary<char, HashSet<string>> map, string start, Dictionary<string, string[]> paths)
        {
            var res = new ChainResult();
            res.Chain.Add(start);

            if (paths.TryGetValue(start, out var cities))
            {
                var countMap = CountMap(map);
                res.Chain = cities.ToList();
                res.Full = countMap == cities.Length - 1;
                return res;
            }
            
            var cur = start;
            while (map.Count > 0)
            {
                if (!map.TryGetValue(End(cur), out var hashSet))
                {
                    res.Full = false;
                    return res;
                }
                var set = hashSet.ToArray();
                if (set.Length == 1)
                {
                    var city = set[0];
                    res.Chain.Add(city);
                    cur = city;
                    DeleteCity(map, city);
                }
                else
                {
                    var bestRes = new ChainResult();
                    for (int i = 0; i < set.Length; i++)
                    {
                        var localStart = set[i];
                        var localMap = Copy(map, localStart);
                        var localRes = TryFind(localMap, localStart, paths);
                        if (localRes.Full)
                        {
                            res.Full = true;
                            res.Chain.AddRange(localRes.Chain);
                            return res;
                        }
                        else if (localRes.Chain.Count > bestRes.Chain.Count)
                            bestRes = localRes;
                        TryAdd(paths, localStart, localRes.Chain.ToArray());
                    }
                    res.Full = false;
                    res.Chain.AddRange(bestRes.Chain);
                    return res;
                }
            }
            res.Full = true;
            return res;
        }

        private Dictionary<char, HashSet<string>> Copy(Dictionary<char, HashSet<string>> source, string? except = null)
        {
            var map = source.ToDictionary(x => x.Key, x => x.Value.ToHashSet());
            if (except != null)
            {
                DeleteCity(map, except);
            }
            return map;
        }

        private void DeleteCity(Dictionary<char, HashSet<string>> map, string city)
        {
            map[city[0]].Remove(city);
            if (map[city[0]].Count() == 0)
            {
                map.Remove(city[0]);
            }
        }

        private char End(string city)
        {
            var last = city.Length - 1;
            if (city.EndsWith('ь') || city.EndsWith('ъ'))
                last--;
            return city[last];
        }

        private int CountMap(Dictionary<char, HashSet<string>> map) => map.Select(x => x.Value.Count).Sum();

        private void TryAdd(Dictionary<string, string[]> paths, string key, string[] newVal)
        {
            if (paths.TryGetValue(key, out var oldVal))
            {
                if(oldVal.Length < newVal.Length)
                    paths[key] = newVal;
            }
            else
            {
                paths.Add(key, newVal);
            }
        }
    }

    class ChainResult
    {
        public bool Full { get; set; }

        public List<string> Chain { get; set; } = new();
    }
}
