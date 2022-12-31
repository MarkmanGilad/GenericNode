using System;
using Unit4.BinTreeCanvasLib;
using Unit4.BinTreeUtilsLib;
using Unit4.CollectionsLib;



namespace Unit4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinNode<int> tree = BinTreeUtils.BuildRandomTree(20, 1, 100);
            TreeCanvas.AddTree(tree);
            TreeCanvas.TreeDrawPreOrder();
        }
    }
}
