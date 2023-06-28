using System;
using Unit4.CollectionsLib;
using Unit4.BinTreeCanvasLib;
using Unit4.BinTreeUtilsLib;
using System.IO;


namespace TreeExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string intTreeFile = @"C:\Users\Gilad\Markman Dropbox\Gilad Markman\הוראה\מדעי המחשב יא\GenericNode\TreeExam\intTree.txt";
            string strTreeFile = @"C:\Users\Gilad\Markman Dropbox\Gilad Markman\הוראה\מדעי המחשב יא\GenericNode\TreeExam\strTree.txt";
            string triangleTreeFile = @"C:\Users\Gilad\Markman Dropbox\Gilad Markman\הוראה\מדעי המחשב יא\GenericNode\TreeExam\triangleTree.txt";
            string charTreeFile = @"C:\Users\Gilad\Markman Dropbox\Gilad Markman\הוראה\מדעי המחשב יא\GenericNode\TreeExam\charTree.txt";
            BinNode<int> intTree = CreateIntTree(intTreeFile);
            BinNode<string> strTree = CreateStringTree(strTreeFile);
            BinNode<int> triangleTree = CreateIntTree(triangleTreeFile);
            BinNode<string> charTree = CreateStringTree(charTreeFile);

            TreeCanvas.AddTree(triangleTree);
            TreeCanvas.TreeDrawPreOrder();

            //Console.WriteLine(DoesContain(strTree, "aggdc")); 
            //Console.WriteLine(equalTriangle(triangleTree));
            //Console.WriteLine(maxPerimeter(triangleTree));
            Console.WriteLine(ToStr(charTree));
            //Console.WriteLine(peri(triangleTree, triangleTree.GetValue()));
            Console.WriteLine(ToStr(charTree, ""));
            string str = new ;
        }

        public static int DoesContain (BinNode<string> node, string str)
        {                           // מניחים שאין מחרוזת ריקה בעץ
            if (node == null)  
                return 0; 
            if (node.GetValue()[0] == str[0] && node.GetValue()[node.GetValue().Length-1] == str[str.Length - 1])
                return DoesContain(node.GetLeft(), str) + DoesContain(node.GetRight(), str) + 1;
            else
                return DoesContain(node.GetLeft(), str) + DoesContain(node.GetRight(), str);
        }

        public static int equalTriangle (BinNode<int> node)
        {
            if (node == null)
                return 0;
            if (node.HasLeft() && node.HasRight() && node.GetLeft().GetValue() == node.GetValue() && 
                node.GetRight().GetValue() == node.GetValue())
                return equalTriangle(node.GetLeft()) + equalTriangle(node.GetRight()) + 1;

            return equalTriangle(node.GetLeft()) + equalTriangle(node.GetRight());
            
        }
        public static int maxPerimeter(BinNode<int> node)
        {                       // O(n) n- number of nodes in tree
            if (node == null)  // כיוון שנאמר שיש רק 0 או 2 בדיקה זו מיותרת
                return 0;
            if (!node.HasLeft() || !node.HasRight())
                return 0;
            else {
                int current = node.GetValue() + node.GetLeft().GetValue() + node.GetRight().GetValue();
                int maxSon = Math.Max(maxPerimeter(node.GetLeft()), maxPerimeter(node.GetRight()));
                return Math.Max(maxSon, current);
            } 
        }

        public static string ToStr (BinNode<string> node) // להרצה יש לשנות את סוג החוליה לחוליה של מחרוזת
        {
            if (node == null)
                return "";
            if (!node.HasLeft() && !node.HasRight())   // עלה
                return node.GetValue().ToString();
            
            return ToStr(node.GetLeft()) + ToStr(node.GetRight());
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
        
        /**************************************************************************/

        public static int peri(BinNode<int> t, int maxPeri)
        {
            if (t== null) 
                return maxPeri;
            if (t.HasLeft())
            {
                maxPeri = Math.Max(maxPeri, t.GetValue() + t.GetLeft().GetValue() + t.GetRight().GetValue());
            }
            maxPeri = peri (t.GetLeft(), maxPeri);
            maxPeri = peri(t.GetRight(), maxPeri);
            return maxPeri;
        }

        public static string ToStr (BinNode<string> t, String leafstr)
        {
            if (t == null)
                return leafstr;
            if (!t.HasLeft() && !t.HasRight())
                leafstr += t.GetValue().ToString();
            ToStr(t.GetLeft(), leafstr);
            ToStr(t.GetRight(), leafstr);
            return leafstr;
        }

    }
}
