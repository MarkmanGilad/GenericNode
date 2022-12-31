using System;
using System.IO;
using Unit4.CollectionsLib;
using Unit4.BinTreeCanvasLib;

namespace BinTree
{
    public class BinTree<T> 
    {
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
    }
}
