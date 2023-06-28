using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;
using Unit4.BinTreeCanvasLib;
using Unit4.BinTreeUtilsLib;
using System.ComponentModel.Design;
using System.IO;

namespace BinTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //createIntTree();
            string tree = @"C:\Users\Gilad\Markman Dropbox\Gilad Markman\הוראה\יסודות\GenericNode\BinTree\tree.txt";
            string fullTree = @"C:\Users\Gilad\Markman Dropbox\Gilad Markman\הוראה\יסודות\GenericNode\BinTree\fullTree.txt";
            string smallTree = @"C:\Users\Gilad\Markman Dropbox\Gilad Markman\הוראה\יסודות\GenericNode\BinTree\smallTree.txt";
            string charTree = @"C:\Users\Gilad\Markman Dropbox\Gilad Markman\הוראה\יסודות\GenericNode\BinTree\TreeChar.txt";
            BinNode<int> intTree =CreateIntTree(smallTree);
            BinNode<string> cTree = CreateStringTree(charTree);

            //BinNode<int> intTree = BinTreeUtils.BuildRandomTree(20, 1, 100);
            //TreeCanvas.AddTree(intTree);
            //TreeCanvas.TreeDrawPreOrder();
            //DFS(intTree);
            //Console.WriteLine();
            //Queue<int> preOrder = new Queue<int>();
            //Queue<int> inOrder = new Queue<int>();
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
            //Queue<int> queue = new Queue<int>();
            //Console.WriteLine(DFS(intTree, queue));
            //Console.WriteLine(DFS_Count(intTree));
            //Console.WriteLine(DFS_FindMax(intTree));
            //Console.WriteLine(DFS_FindMaxLeaf(intTree));
            //Console.WriteLine(DFS_Depth(intTree));
            //Console.WriteLine(DFS_sum_of_nodes(intTree));
            //Console.WriteLine(DFS_sum_of_leaves(intTree));
            //Console.WriteLine(DFS_IsAllEven(intTree));
            //DFS_SortSons(intTree);
            //TreeCanvas.AddTree(intTree);
            //TreeCanvas.TreeDrawPreOrder();

            //TreeCanvas.AddTree(cTree);
            //TreeCanvas.TreeDrawPreOrder();
            //Console.WriteLine(WordFromRoot(cTree, "helpu"));
            TreeCanvas.AddTree(intTree);
            TreeCanvas.TreeDrawPreOrder();
            //PrintAll(intTree, 0);
            Console.WriteLine(TreeEqual(intTree)); 

        }
        public static BinNode<int> CreateIntTree(string fileName)
        {
            Queue<int?[]> treeQ = new Queue<int?[]>();
            TextReader reader = File.OpenText(fileName);
            string line;
            do
            {
                line = reader.ReadLine();
                if (!String.IsNullOrEmpty(line))
                {
                    string[] LineArr = line.Split(',');
                    int?[] ints = new int?[LineArr.Length];
                    for (int i = 0; i < LineArr.Length; i++)
                    {
                        int n;
                        ints[i] = int.TryParse(LineArr[i], out n) ? n : (int?)null;
                    }
                    treeQ.Insert(ints);
                }
            } while (line != null);

            int?[] parents = treeQ.Remove();
            BinNode<int>[] parentsNodes = new BinNode<int>[parents.Length];
            if (parents[0] == null)
                return null;
            parentsNodes[0] = new BinNode<int>((int)parents[0]);
            BinNode<int> root = parentsNodes[0];

            while (!treeQ.IsEmpty())
            {
                int?[] children = treeQ.Remove();
                BinNode<int>[] childrenNodes = new BinNode<int>[children.Length];

                for (int i = 0; i < children.Length; i++)
                {
                    if (children[i] != null)
                    {
                        childrenNodes[i] = new BinNode<int>((int)children[i]);
                        int parent = i / 2;
                        int son = i % 2;
                        if (son == 0)
                        {
                            parentsNodes[parent].SetLeft(childrenNodes[i]);
                        }
                        else
                        {
                            parentsNodes[parent].SetRight(childrenNodes[i]);
                        }
                    }
                }
                parentsNodes = childrenNodes;
            }
            return root;
        }
        public static BinNode<string> CreateStringTree(string fileName)
        {
            Queue<string[]> treeQ = new Queue<string[]>();
            TextReader reader = File.OpenText(fileName);
            string line;
            do
            {
                line = reader.ReadLine();
                if (!String.IsNullOrEmpty(line))
                {
                    string[] LineArr = line.Split(',');
                    treeQ.Insert(LineArr);
                }
            } while (line != null);

            string[] parents = treeQ.Remove();
            BinNode<string>[] parentsNodes = new BinNode<string>[parents.Length];
            parentsNodes[0] = new BinNode<string>(parents[0]);
            BinNode<string> root = parentsNodes[0];

            while (!treeQ.IsEmpty())
            {
                string[] children = treeQ.Remove();
                BinNode<string>[] childrenNodes = new BinNode<string>[children.Length];

                for (int i = 0; i < children.Length; i++)
                {
                    if (children[i] != "")
                    {
                        childrenNodes[i] = new BinNode<string>(children[i]);
                        int parent = i / 2;
                        int son = i % 2;
                        if (son == 0)
                        {
                            parentsNodes[parent].SetLeft(childrenNodes[i]);
                        }
                        else
                        {
                            parentsNodes[parent].SetRight(childrenNodes[i]);
                        }
                    }
                }
                parentsNodes = childrenNodes;
            }
            return root;
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

        /************** Homework *********************/

        public static Queue<int> DFS (BinNode<int> node, Queue<int> q)
        {
            if (node == null)
                return q;
            q.Insert(node.GetValue());
            DFS(node.GetLeft(), q);
            DFS(node.GetRight(),q);
            return q;
        }

        public static int DFS_Count(BinNode<int> node)
        {
            if (node == null)
                return 0;
            return DFS_Count(node.GetLeft()) + DFS_Count(node.GetRight()) + 1;
        }

        public static int DFS_FindMax(BinNode<int> node)
        {
            if (node == null)
                return int.MinValue;
            int max = Math.Max(DFS_FindMax(node.GetLeft()), DFS_FindMax(node.GetRight()));
            return Math.Max(max, node.GetValue());
        }

        public static int DFS_FindMaxLeaf(BinNode<int> node)
        {
            if (node == null)
                return int.MinValue;
            if (!node.HasLeft() && !node.HasRight())
                return node.GetValue();
            return Math.Max(DFS_FindMaxLeaf(node.GetLeft()), DFS_FindMaxLeaf(node.GetRight()));
        }

        public static int DFS_Depth (BinNode<int> node)
        {
            int depthL=0, depthR=0;
            if (!node.HasLeft() && !node.HasRight())
                return 0;
            if (node.HasLeft()) 
                depthL = DFS_Depth(node.GetLeft());
            if (node.HasRight())
                depthR = DFS_Depth(node.GetRight());
            return Math.Max(depthL, depthR) + 1;
        }
        public static int DFS_sum_of_nodes (BinNode<int> node)
        {
            if (node == null)
                return 0;
            return DFS_sum_of_nodes(node.GetLeft()) + DFS_sum_of_nodes(node.GetRight()) + node.GetValue();
            
        }

        public static int DFS_sum_of_leaves (BinNode<int> node)
        {
            if (node == null)
                return 0;
            if (!node.HasLeft() && !node.HasRight())
                return node.GetValue();
            return DFS_sum_of_leaves(node.GetLeft()) + DFS_sum_of_leaves(node.GetRight());
        }

        public static bool DFS_IsAllEven (BinNode<int> node)
        {
            if (node==null)
                return true;
            return DFS_IsAllEven(node.GetLeft()) && DFS_IsAllEven(node.GetRight()) && node.GetValue() % 2 == 0;
        }

        public static void DFS_SortSons (BinNode<int> node)
        {
            if (node == null)
                return;
            if (node.HasLeft() && node.HasRight() && node.GetLeft().GetValue() < node.GetRight().GetValue())
            {
                BinNode<int> temp = node.GetLeft();
                node.SetLeft(node.GetRight());
                node.SetRight(temp);
            }
            DFS_SortSons(node.GetLeft());
            DFS_SortSons(node.GetRight());
        }

        /** Bagrut 2022 **/

        public static bool WordFromRoot(BinNode<string> tree, string str)
        {
            if (str == "")
                return true;
            if (tree == null) 
                return false;
            if (str[0].ToString() != tree.GetValue())
                return false;
            return WordFromRoot(tree.GetLeft(), EraseFirst(str)) || WordFromRoot(tree.GetRight(), EraseFirst(str));

        }
        public static string EraseFirst (string str)
        {
            return str.Remove(0, 1);
        }

        /** Bagrut 2020 **/

        public static void PrintAll(BinNode<int> node, int num)
        {
            if (node == null)
                return;
            if (!node.HasLeft() && !node.HasRight())
            {
                Console.WriteLine(num * 10 + node.GetValue());
                return;
            }
            PrintAll(node.GetLeft(), num * 10 + node.GetValue());
            PrintAll(node.GetRight(), num * 10 + node.GetValue());
        }

        /** Bagrut 2020 special **/

        public static bool TreeEqual (BinNode<int> tree)
        {
            return countRemainder(tree, 3, 0) == countRemainder(tree, 3, 1) &&
                countRemainder(tree, 3, 0) == countRemainder(tree, 3, 2);
        }

        public static int countRemainder (BinNode<int> node, int divide, int remainder)
        {
            if (node == null)
                return 0;
            if (node.GetValue() % divide == remainder)
            {
                return countRemainder(node.GetLeft(), divide, remainder) + countRemainder(node.GetRight(), divide, remainder) + 1;
            }
            return countRemainder(node.GetLeft(), divide, remainder) + countRemainder(node.GetRight(), divide, remainder);


        }

        /**** Bagrut 2019 *****/

        public static bool Order (BinNode<Range> node)
        {
            if (node == null)
                return true;

            if (node.HasLeft() && !node.HasRight())
            {
                bool order = node.GetValue().GetLow() == node.GetLeft().GetValue().GetLow();
                order = order && node.GetValue().GetHigh() >= node.GetLeft().GetValue().GetHigh();
                if (!order)
                    return false;
            }
            if (!node.HasLeft() && node.HasRight())
            {
                bool order = node.GetValue().GetHigh() == node.GetRight().GetValue().GetHigh();
                order = order && node.GetValue().GetLow() <= node.GetRight().GetValue().GetLow();
                if (!order)
                    return false;
            }
            if (node.HasLeft() && node.HasRight())
            {
                bool order = node.GetLeft().GetValue().GetHigh() < node.GetRight().GetValue().GetLow(); 
                if (!order)
                    return false;
            }
            return Order(node.GetLeft()) && Order(node.GetRight());
            
        }

        public static bool hasOrderedSeries (BinNode<int> tr)
        {
            if (tr == null) return true;

            bool left = hasOrderedSeries(tr.GetLeft());
            bool right = hasOrderedSeries(tr.GetRight());

            bool current = tr.HasLeft() && left && tr.GetValue() < tr.GetLeft().GetValue() ||
                           tr.HasRight() && right && tr.GetValue() < tr.GetRight().GetValue();
            return current;

        }

    }

    class Range
    {
        private int Low;
        private int High;

        public Range (int low, int high) { 
        Low = low;
        High = high;
        }

        public int GetLow () { return Low; }
        public int GetHigh () { return High; }
    }
}
