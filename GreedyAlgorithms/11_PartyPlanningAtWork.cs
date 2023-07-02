using Utils;

namespace GreedyAlgorithms
{
    [ShouldRepeat]
    public class PartyPlanningAtWork
    {
        public class TreeNode
        {
            public string Value { get; set; }
            public TreeNode[]? Children { get; set; }

            public TreeNode(string val, TreeNode[]? children = default)
            {
                Value = val;
                Children = children;
            }
        }

        public void SelfTest()
        {
            var a = new TreeNode("A");
            var b = new TreeNode("B");
            var c = new TreeNode("C");
            var d = new TreeNode("D", new[] { a, b, c });
            var e = new TreeNode("E");
            var f = new TreeNode("F");
            var g = new TreeNode("G");
            var h = new TreeNode("H", new[] { d, e });
            var i = new TreeNode("I", new[] { f });
            var j = new TreeNode("J", new[] { g });
            var k = new TreeNode("K", new[] { j, i, h });

            var res = Calculate(k); // A B C G F E K
        }

        public List<string> Calculate(TreeNode node)
        {
            List<string> list = new();

            Func<TreeNode, bool> func = null;
            func = node =>
            {
                bool shouldAdd;
                if (node.Children == null)
                    shouldAdd = true;
                else
                {
                    shouldAdd = true;
                    foreach (var child in node.Children)
                        shouldAdd &= func(child);
                }
                if (shouldAdd)
                {
                    list.Add(node.Value);
                    return false;
                }
                else
                    return true;
            };
            func(node);
            return list;
        }
    }
}
