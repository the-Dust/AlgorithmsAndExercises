using Leetcode.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class Lc113
    {
        public void SelfTest() 
        {
            int?[] arr = new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, 5, 1 };
            var tree = TreeNode.CreateTree(arr);

            var res = PathSum(tree, 22); // [[5,4,11,2],[5,8,4,5]]
        }

        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            var result = PathSumInternal(root, targetSum);
            result.ForEach(x => Reverse(x));
            return result;
        }

        private List<IList<int>> PathSumInternal(TreeNode root, int targetSum)
        {
            if (root == null)
                return new List<IList<int>>();
            if (root.val == targetSum && root.right == null && root.left == null)
                return new List<IList<int>>() { new List<int> { root.val } };

            var left = PathSumInternal(root.left, targetSum - root.val);
            var right = PathSumInternal(root.right, targetSum - root.val);
            left.AddRange(right);

            var filtered = left.Where(x => x.Count > 0).ToList();
            filtered.ForEach(x => x.Add(root.val));
            return filtered;
        }

        private void Reverse(IList<int> list)
        {
            var l = 0;
            var r = list.Count - 1;
            while (l < r)
            {
                (list[l], list[r]) = (list[r], list[l]);
                l++;
                r--;
            }
        }
    }
}
