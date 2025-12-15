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
            //BinNode<int> intTree =CreateIntTree(smallTree);
            //BinNode<string> cTree = CreateStringTree(charTree);

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
            //TreeCanvas.AddTree(intTree);
            //TreeCanvas.TreeDrawPreOrder();
            //PrintAll(intTree, 0);
            //Console.WriteLine(TreeEqual(intTree)); 

            BinTreeMethods();

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


        /*********************** Tree Print****************************/
        public static void BinTreeMethods()
        {
            string path = GetTreeFilePath("tree_new.txt");
            BinNode<int> tree = BuildBinaryTree<int>(path);
            PrintBinaryTree(tree);
            PrintBinaryTreeColored(tree);
        }

        /// <summary>
        /// Builds a binary tree from a text file
        /// The file format uses indentation (tabs) to represent tree structure:
        /// - Each line represents a node
        /// - Indentation level indicates depth
        /// - "Left:" prefix indicates left child
        /// - "Right:" prefix indicates right child
        /// - Empty lines are treated as null nodes
        /// </summary>
        /// <typeparam name="T">Type of elements in the tree (must support conversion from string)</typeparam>
        /// <param name="filePath">Path to the text file containing tree structure</param>
        /// <returns>Root node of the binary tree, or null if file is empty</returns>
        public static BinNode<T> BuildBinaryTree<T>(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
                throw new System.IO.FileNotFoundException($"Tree file not found: {filePath}");

            string[] lines = System.IO.File.ReadAllLines(filePath);
            if (lines.Length == 0)
                return null;

            int currentLine = 0;
            return BuildTreeRecursive<T>(lines, ref currentLine, 0);
        }

        /// <summary>
        /// Recursively builds the binary tree from file lines
        /// </summary>
        private static BinNode<T> BuildTreeRecursive<T>(string[] lines, ref int currentLine, int expectedDepth)
        {
            // Skip any empty lines before processing
            while (currentLine < lines.Length && string.IsNullOrWhiteSpace(lines[currentLine]))
            {
                currentLine++;
            }

            if (currentLine >= lines.Length)
                return null;

            string line = lines[currentLine];

            // Calculate depth based on leading tabs
            int depth = 0;
            while (depth < line.Length && line[depth] == '\t')
            {
                depth++;
            }

            // If depth doesn't match expected, this node belongs to a different level
            if (depth != expectedDepth)
                return null;

            // Extract the value (remove tabs and prefixes)
            string trimmedLine = line.TrimStart('\t');
            string valueStr = trimmedLine;

            // Remove "Left:" or "Right:" prefix if present
            if (trimmedLine.StartsWith("Left:"))
                valueStr = trimmedLine.Substring(5);
            else if (trimmedLine.StartsWith("Right:"))
                valueStr = trimmedLine.Substring(6);

            // Convert string to type T
            T value = ConvertToType<T>(valueStr);

            // Create the node
            BinNode<T> node = new BinNode<T>(value);
            currentLine++;

            // Process children in a loop to handle both left and right
            while (currentLine < lines.Length)
            {
                // Skip empty lines
                while (currentLine < lines.Length && string.IsNullOrWhiteSpace(lines[currentLine]))
                {
                    currentLine++;
                }

                if (currentLine >= lines.Length)
                    break;

                string nextLine = lines[currentLine];

                // Check depth of next line
                int nextDepth = 0;
                while (nextDepth < nextLine.Length && nextLine[nextDepth] == '\t')
                {
                    nextDepth++;
                }

                // If next line is not a direct child, stop processing
                if (nextDepth != depth + 1)
                    break;

                string trimmedNextLine = nextLine.TrimStart('\t');

                // Process left child
                if (trimmedNextLine.StartsWith("Left:"))
                {
                    node.SetLeft(BuildTreeRecursive<T>(lines, ref currentLine, depth + 1));
                }
                // Process right child
                else if (trimmedNextLine.StartsWith("Right:"))
                {
                    node.SetRight(BuildTreeRecursive<T>(lines, ref currentLine, depth + 1));
                }
                else
                {
                    // Unknown format, stop processing
                    break;
                }
            }

            return node;
        }

        /// <summary>
        /// Converts a string value to the specified type T
        /// </summary>
        private static T ConvertToType<T>(string value)
        {
            try
            {
                // Handle common types
                Type targetType = typeof(T);

                if (targetType == typeof(string))
                    return (T)(object)value;

                if (targetType == typeof(int))
                    return (T)(object)int.Parse(value);

                if (targetType == typeof(double))
                    return (T)(object)double.Parse(value);

                if (targetType == typeof(float))
                    return (T)(object)float.Parse(value);

                if (targetType == typeof(bool))
                    return (T)(object)bool.Parse(value);

                if (targetType == typeof(char) && value.Length == 1)
                    return (T)(object)value[0];

                // Use Convert.ChangeType for other types
                return (T)Convert.ChangeType(value, targetType);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Cannot convert '{value}' to type {typeof(T).Name}", ex);
            }
        }


        /// <summary>
        /// Gets the tree file path, compatible with both local and VPL
        /// </summary>
        public static string GetTreeFilePath(string filePath)
        {
            string[] possiblePaths = new[]
            {
                filePath,
                Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, filePath),
                Path.Combine("..", filePath),
                Path.Combine("..", "..", filePath)
            };

            foreach (var path in possiblePaths)
            {
                try
                {
                    if (File.Exists(path))
                        return Path.GetFullPath(path);
                }
                catch
                {
                    continue;
                }
            }

            return filePath;
        }


        /// <summary>
        /// Prints a binary tree to the console with visual edges
        /// Uses box-drawing characters for a cleaner appearance
        /// </summary>
        /// <typeparam name="T">Type of elements in the tree</typeparam>
        /// <param name="root">Root node of the tree</param>
        public static void PrintBinaryTree<T>(BinNode<T> root)
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty (null)");
                return;
            }

            Console.WriteLine("Binary Tree Structure:");
            Console.WriteLine("======================");
            PrintBinaryTreeRecursive(root, "", "", true);
            Console.WriteLine("======================");
        }

        /// <summary>
        /// Recursively prints the tree structure to console with visual edges
        /// </summary>
        /// <typeparam name="T">Type of elements in the tree</typeparam>
        /// <param name="node">Current node being printed</param>
        /// <param name="indent">Current indentation string</param>
        /// <param name="pointer">Pointer character (├── or └──)</param>
        /// <param name="isRoot">Whether this is the root node</param>
        private static void PrintBinaryTreeRecursive<T>(BinNode<T> node, string indent, string pointer, bool isRoot)
        {
            if (node == null)
                return;

            // Print current node
            Console.Write(indent);
            if (!isRoot)
                Console.Write(pointer);
            Console.WriteLine(node.GetValue());

            // Prepare indentation for children
            string childIndent = indent;
            if (!isRoot)
            {
                childIndent += (pointer == "└── " ? "    " : "│   ");
            }

            // Print left and right children
            if (node.HasLeft() || node.HasRight())
            {
                // Print left child
                if (node.HasLeft())
                {
                    PrintBinaryTreeRecursive(node.GetLeft(), childIndent, "├── ", false);
                }
                else if (node.HasRight())
                {
                    // Show null left child only if right child exists
                    Console.WriteLine(childIndent + "├── (null)");
                }

                // Print right child
                if (node.HasRight())
                {
                    PrintBinaryTreeRecursive(node.GetRight(), childIndent, "└── ", false);
                }
                else if (node.HasLeft())
                {
                    // Show null right child only if left child exists
                    Console.WriteLine(childIndent + "└── (null)");
                }
            }
        }

        /// <summary>
        /// Prints a binary tree to the console with colored output (optional)
        /// Highlights different levels with colors for better visualization
        /// </summary>
        /// <typeparam name="T">Type of elements in the tree</typeparam>
        /// <param name="root">Root node of the tree</param>
        /// <param name="useColors">Whether to use colored output</param>
        public static void PrintBinaryTreeColored<T>(BinNode<T> root, bool useColors = true)
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty (null)");
                return;
            }

            Console.WriteLine("Binary Tree Structure:");
            Console.WriteLine("======================");
            PrintBinaryTreeColoredRecursive(root, "", "", true, 0, useColors);
            Console.WriteLine("======================");
        }

        /// <summary>
        /// Recursively prints the tree with optional color coding by depth
        /// </summary>
        private static void PrintBinaryTreeColoredRecursive<T>(BinNode<T> node, string indent, string pointer, bool isRoot, int depth, bool useColors)
        {
            if (node == null)
                return;

            // Color palette for different depths
            ConsoleColor[] colors = new ConsoleColor[]
            {
                ConsoleColor.Cyan,
                ConsoleColor.Yellow,
                ConsoleColor.Green,
                ConsoleColor.Magenta,
                ConsoleColor.Blue,
                ConsoleColor.Red
            };

            // Print current node
            Console.Write(indent);
            if (!isRoot)
                Console.Write(pointer);

            if (useColors)
            {
                var originalColor = Console.ForegroundColor;
                Console.ForegroundColor = colors[depth % colors.Length];
                Console.WriteLine(node.GetValue());
                Console.ForegroundColor = originalColor;
            }
            else
            {
                Console.WriteLine(node.GetValue());
            }

            // Prepare indentation for children
            string childIndent = indent;
            if (!isRoot)
            {
                childIndent += (pointer == "└── " ? "    " : "│   ");
            }

            // Print left and right children
            if (node.HasLeft() || node.HasRight())
            {
                // Print left child
                if (node.HasLeft())
                {
                    PrintBinaryTreeColoredRecursive(node.GetLeft(), childIndent, "├── ", false, depth + 1, useColors);
                }
                else if (node.HasRight())
                {
                    Console.WriteLine(childIndent + "├── (null)");
                }

                // Print right child
                if (node.HasRight())
                {
                    PrintBinaryTreeColoredRecursive(node.GetRight(), childIndent, "└── ", false, depth + 1, useColors);
                }
                else if (node.HasLeft())
                {
                    Console.WriteLine(childIndent + "└── (null)");
                }
            }
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
