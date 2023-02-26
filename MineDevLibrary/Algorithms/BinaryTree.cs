using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineDevLibrary.Algorithms
{
    /// <summary>
    /// простое бинарное дерево
    /// 
    /// </summary>
    public class BinaryTree
    {
        //корень дерева
        private Node _Root { get; set; }    

        //узел
        private class Node 
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

        //создаем дерево 
        public BinaryTree()
        {
            _Root = new Node(1,
                        new Node(2, 
                            new Node(3), 
                            new Node(4)),
                        new Node(5, 
                            new Node(6)));
        }

        //превращаем дерево в лист рекурсивно
        public List<int> ToList()
        {
            var list = new List<int>();
            SearchRecursive(_Root, ref list);
            return list;
        }

        //возвращает перечислитель
        public IEnumerable<int> ToEnumerable()
        {
            return ToEnumerableNoRecurseve(_Root);
        }




        //рекурсивный обход
        private void SearchRecursive(Node node, ref List<int> listResult)
        {
            if (node == null) return;

            listResult.Add(node.Value);

            SearchRecursive(node.Left, ref listResult);
            SearchRecursive(node.Right, ref listResult);
        }



        //создаем перечислитель для дерева
        private IEnumerable<int> ToEnumerableImpl(Node node) 
        {
            if(node == null ) yield break;

            yield return node.Value;

            foreach(var n in ToEnumerableImpl(node.Left))
            {
                yield return n;
            }

            foreach (var n in ToEnumerableImpl(node.Right))
            {
                yield return n;
            }
        }


        //не рекурсивный проход по дереву и возврат перечислителя
        private IEnumerable<int> ToEnumerableNoRecurseve(Node node)
        {
            var state = new Stack<Node>();
            
            state.Push(node);

            while(state.Count>0)
            {
                var current = state.Pop();
                if (current == null) continue;

                yield return current.Value;

                state.Push(current.Left);
                state.Push(current.Right);
            }
        }

    }
}
