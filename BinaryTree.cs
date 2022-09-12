using System.Text;

namespace Leet
{
    internal class TreeNode
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
        public override string ToString()
        {
            string ls = left?.ToString() ?? "";
            string rs = right?.ToString() ?? "";
            return $"({val}{ls}{rs})";
        }
    }

    internal class BinaryTree
    {
        public void Tree2str()
        {
            Check.Value("1(2(4))(3)", Tree2str, new TreeNode { val = 1, left = new TreeNode { val = 2, left = new TreeNode { val = 4 } }, right = new TreeNode { val = 3 } });
            Check.Value("1(2()(4))(3)", Tree2str, new TreeNode { val = 1, left = new TreeNode { val = 2, right = new TreeNode { val = 4 } }, right = new TreeNode { val = 3 } });
        }

        string Tree2str(TreeNode root)
        {
            const string EMPTY_LEFT = "()";
            if (root == null) return EMPTY_LEFT;

            StringBuilder sb = new StringBuilder();

            void Node2Str(TreeNode node)
            {
                sb.Append("(");
                sb.Append(node.val.ToString());

                if (node.left != null || node.right != null)
                {
                    if (node.left != null)
                    {
                        Node2Str(node.left);
                    }
                    else
                    {
                        sb.Append(EMPTY_LEFT);
                    }

                    if (node.right != null)
                    {
                        Node2Str(node.right);
                    }
                }

                sb.Append(")");
            }

            Node2Str(root);

            return sb.ToString()[1..^1];
        }
    }
}
