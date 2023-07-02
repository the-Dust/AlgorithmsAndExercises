namespace Leetcode.Utilites
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public static TreeNode CreateTree(int?[] arr, TreeNode root = null, int left = -1, int right = -1)
        {
            if (arr == null || arr.Length == 0 || !arr[0].HasValue)
                return null;

            if (root == null)
                root = new TreeNode(arr[0].Value);

            if (left == -1)
            {
                left = 2 * 0 + 1;
                right = 2 * 0 + 2;
            }

            if (left < arr.Length && arr[left].HasValue)
            {
                root.left = new TreeNode(arr[left].Value);
                CreateTree(arr, root.left, 2 * left + 1, 2 * left + 2);
            }

            if (right < arr.Length && arr[right].HasValue)
            {
                root.right = new TreeNode(arr[right].Value);
                CreateTree(arr, root.right, 2 * right + 1, 2 * right + 2);
            }

            return root;
        }
    }
}
