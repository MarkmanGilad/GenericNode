using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;
using Unit4.BinTreeCanvasLib;
using Unit4.BinTreeUtilsLib;
using System.ComponentModel.Design;

namespace BinTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //createIntTree();
            string path = @"C:\Users\Gilad\Markman Dropbox\Gilad Markman\הוראה\יסודות\GenericNode\BinTree\tree.txt";
            string fullTree = @"C:\Users\Gilad\Markman Dropbox\Gilad Markman\הוראה\יסודות\GenericNode\BinTree\fullTree.txt";
            string smallTree = @"C:\Users\Gilad\Markman Dropbox\Gilad Markman\הוראה\יסודות\GenericNode\BinTree\smallTree.txt";
            BinNode<int> intTree = BinTree<int>.CreateIntTree(fullTree);

            //BinNode<int> intTree = BinTreeUtils.BuildRandomTree(20, 1, 100);
            TreeCanvas.AddTree(intTree);
            TreeCanvas.TreeDrawPreOrder();
            DFS(intTree);
            Console.WriteLine();
            //Queue<int> preOrder = new Queue<int>();
            Queue<int> inOrder = new Queue<int>();
            //Queue<int> postOrder = new Queue<int>();

            //GetNodes(intTree, preOrder, inOrder,postOrder);
            //Console.WriteLine(preOrder);
            //Console.WriteLine(inOrder);
            //Console.WriteLine(postOrder);

            //DFS_Stack(intTree);
            //BFS(intTree);
            //int level = BFS_level(intTree);
            //Console.WriteLine($"height: {level}");
            //int level = BFS_level2(intTree);
            //Console.WriteLine($"height: {level}");
        }

        public static void graphicTree ()
        {
            BinNode<int> t = BinTreeUtils.BuildRandomTree(50, 1, 3);
            TreeCanvas.AddTree(t);
            TreeCanvas.TreeDrawPostOrder();
        }

        public static void createIntTree()
        {
            string path = @"C:\Users\Gilad\Markman Dropbox\Gilad Markman\הוראה\יסודות\GenericNode\BinTree\tree.txt";
            BinNode<int> intTree = BinTree<int>.CreateIntTree(path);
            TreeCanvas.AddTree(intTree);
            TreeCanvas.TreeDrawPreOrder();
        }
        
        public static void createStringTree()
        {
            string path = @"C:\Users\Gilad\Markman Dropbox\Gilad Markman\הוראה\יסודות\GenericNode\BinTree\tree.txt";
            BinNode<string> stringTree = BinTree<string>.CreateStringTree(path);
            TreeCanvas.AddTree(stringTree);
            TreeCanvas.TreeDrawPreOrder();
        }
    
        public static void DFS <T> (BinNode<T> node)
        {
            if (node == null)
                return;
            // preOrder - תחילית
            Console.Write(node + ", ");
            DFS(node.GetLeft());
            // inOrder -  תוכית
            DFS(node.GetRight());
            // postOrder - סופית
        }

        public static void GetNodes<T>(BinNode<T> node, Queue<T> preOrder, 
            Queue<T> inOrder, Queue<T> postOrder)
        {
            if (node == null)
                return;
            preOrder.Insert(node.GetValue());
            GetNodes(node.GetLeft(), preOrder, inOrder,postOrder);
            inOrder.Insert(node.GetValue());
            GetNodes(node.GetRight(), preOrder, inOrder, postOrder);
            postOrder.Insert(node.GetValue());
        }

        public static void DFS_Stack <T> (BinNode<T> node)
        {
            Stack<BinNode<T>> stack = new Stack<BinNode<T>>();
            stack.Push(node);
            while (!stack.IsEmpty())
            {
                node = stack.Pop();
                Console.Write(node + ", ");
                if (node.HasRight()) { stack.Push(node.GetRight()); }
                if (node.HasLeft()) { stack.Push(node.GetLeft()); }
            }
            Console.WriteLine();
        }

        public static void BFS<T>(BinNode<T> node)
        {
            Queue<BinNode<T>> queue = new Queue<BinNode<T>>();
            queue.Insert(node);
            while (!queue.IsEmpty())
            {
                node = queue.Remove();
                Console.Write(node + ", ");
                if (node.HasLeft()) { queue.Insert(node.GetLeft()); }
                if (node.HasRight()) { queue.Insert(node.GetRight()); }
            }
            Console.WriteLine();
        }

        public static int BFS_level<T>(BinNode<T> node)
        {
            Queue<BinNode<T>> queue = new Queue<BinNode<T>>();
            int level = -1;
            queue.Insert(node);
            int qSize = 1;
            while (!queue.IsEmpty())
            {
                level++;
                int level_size = qSize;
                Console.WriteLine($"level: {level} size: {level_size}");
                while (level_size > 0)
                {
                    node = queue.Remove(); qSize--;
                    if (node.HasLeft()) { queue.Insert(node.GetLeft()); qSize++; }
                    if (node.HasRight()) { queue.Insert(node.GetRight()); qSize++; }
                    level_size--;
                }
            }
            return level;
        }

        public static int BFS_level2<T>(BinNode<T> node)
        {
            Queue<BinNode<T>> queue = new Queue<BinNode<T>>();
            int level = -1;
            queue.Insert(node);
            int qSize = 1;
            while (!queue.IsEmpty())
            {
                level++;
                int level_size = qSize;
                Console.WriteLine($"level: {level} size: {level_size}");
                for (int i = 0; i < level_size; i++)
                {
                    node = queue.Remove(); qSize--;
                    if (node.HasLeft()) { queue.Insert(node.GetLeft()); qSize++; }
                    if (node.HasRight()) { queue.Insert(node.GetRight()); qSize++; }
                }
            }
            return level;
        }

    }
}
