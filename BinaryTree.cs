using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

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
            void Check(TreeNode root, string expected)
            {
                var result = Tree2str(root);
                Console.WriteLine($"{result == expected} => {root} = {result}, expected {expected}");
            }

            Check(new TreeNode { val = 1, left = new TreeNode { val = 2, left = new TreeNode { val = 4 } }, right = new TreeNode { val = 3 } }, "1(2(4))(3)");
            Check(new TreeNode { val = 1, left = new TreeNode { val = 2, right = new TreeNode { val = 4 } }, right = new TreeNode { val = 3 } }, "1(2()(4))(3)");
        }

        string Tree2str(TreeNode root)
        {
            const string EMPTY_LEFT = "()";
            if (root == null) return EMPTY_LEFT;

            StringBuilder sb = new StringBuilder();

            void node2str(TreeNode node)
            {
                sb.Append("(");
                sb.Append(node.val.ToString());

                if (node.left != null || node.right != null)
                {
                    if (node.left != null)
                    {
                        node2str(node.left);
                    }
                    else
                    {
                        sb.Append(EMPTY_LEFT);
                    }

                    if (node.right != null)
                    {
                        node2str(node.right);
                    }
                }

                sb.Append(")");
            }

            node2str(root);

            return sb.ToString()[1..^1];
        }
    }
}
