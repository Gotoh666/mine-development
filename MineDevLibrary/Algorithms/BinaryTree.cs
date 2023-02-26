using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineDevLibrary.Algorithms
{
    public class BinaryTree
    {
        private Node _Tree { get; set; }    

        public class Node 
        {
            public int Value { get; set; }
            public Node? Left { get; set; }
            public Node? Right { get; set; }

            public Node (int val, Node? left=null, Node? right=null)
            {
                Value = val;
                Left = left;
                Right = right;
            }
        }

        public BinaryTree()
        {
            _Tree = new Node(1,new Node(2, new Node(3), new Node(4)), new Node(5, new Node(6)));
        }

        //превращаем дерево в лист рекурсивно
        public List<int> ToList()
        {
            var list = new List<int>();
            SearchRecursive(_Tree, ref list);
            return list;
        }

        //рекурсивный обход
        private void SearchRecursive(Node node, ref List<int> listResult)
        {
            if (node == null) return;

            listResult.Add(node.Value);

            SearchRecursive(node.Left, ref listResult);
            SearchRecursive(node.Right, ref listResult);
        }


        


    }
}
