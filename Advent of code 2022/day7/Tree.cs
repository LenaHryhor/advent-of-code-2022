using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code_2022
{
    /*public enum NodeType
    {
        Directory,
        File
    }
    public class TreeNode
    {
        public NodeType type;
        public string name;
        public ulong size;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(NodeType type, string name, ulong size)
        {
            this.type = type;
            this.name = name;
            this.size = size;
            left = null;
            right = null;
        }
    }

    public class Tree
    {
        private TreeNode root;
        public Tree(TreeNode root)
        {
            this.root = root;
        }
        public void Insert(TreeNode currentNode, TreeNode newNode)
        {
            if(currentNode != null) {
                var node = newNode.type is NodeType.Directory ? currentNode.left : currentNode.right;
                Insert(node, newNode);
            }
            currentNode = newNode;
        }

    }*/
}
