using System.Drawing;
using Unit4.BinTreeCanvasLib;
using Unit4.BinTreeUtilsLib;
using Unit4.CollectionsLib;

BinNode<int> tree = BinTreeUtils.BuildRandomTree(20, 1, 100);
TreeCanvas.AddTree(tree);
TreeCanvas.TreeDrawPreOrder();