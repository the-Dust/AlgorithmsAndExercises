using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace DynamicProgramming
{
    [ShouldRepeat]
    public class FunPartyPlanningAtWork
    {
        public void SelfTest()
        {
            var tree = new Node { 
                Weight= 3,
                Children = new[] { 
                    new Node { Weight = 5, 
                        Children = new[] { new Node { Weight = 2 } } },
                    new Node { Weight = 1,
                        Children = new[] { new Node { Weight = 3 } } },
                    new Node { Weight = 6,
                        Children = new[] { 
                            new Node { Weight = 2 },
                            new Node { Weight = 7, Children = new[] {
                                new Node { Weight = 1 },
                                new Node { Weight = 2 },
                                new Node { Weight = 1 },
                            } },
                        } 
                    }
                }
            };

            var res = Calculate(tree); // 18
        }

        public int Calculate(Node head)
        {
            var weights = new Dictionary<Node, int>();

            Func<Node, int> indsSet = null;

            indsSet = node =>
            {
                if (node.Children == null)
                {
                    weights[node] = node.Weight;
                    return weights[node];
                }
                if (weights.TryGetValue(node, out var w))
                    return w;

                var first = node.Weight + node.Children.Select(x => x.Children?.Select(n => indsSet(n)).Sum() ?? 0).Sum();
                var second = node.Children.Select(x => indsSet(x)).Sum();
                weights[node] = Math.Max(second, first);
                return weights[node];
            };
            var result = indsSet(head);
            return result;
        }
    }

    public class Node
    {
        public int Weight { get; set; }

        public Node[] Children { get; set; }
    }
}
