using System;
using Unit4.CollectionsLib;
using Unit4.BinTreeCanvasLib;
using Unit4.BinTreeUtilsLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinNode<int> t1 = BinTreeUtils.BuildRandomTree(10, 1, 20);
            BinNode<int> t2 = BinTreeUtils.BuildRandomTree(10, 1, 20);
            TreeCanvas.AddTree(t1);
            TreeCanvas.TreeDrawPreOrder();
            TreeCanvas.AddTree(t2);
            TreeCanvas.TreeDrawPreOrder();
            Node<int> lst = Check(t1, t2);
            while (lst != null)
            {
                Console.WriteLine(lst.GetValue());
                lst = lst.GetNext();
            }
        }

        public static bool Exist (BinNode<int> t, int x)
        {
            if (t == null)
                return false;
            bool L = Exist(t.GetLeft(), x);
            bool R = Exist(t.GetRight(), x);
            return L || R || t.GetValue() == x;
        }

        public static Node<int> Check (BinNode<int> t1, BinNode<int> t2)
        {
            Node<int> first = new Node<int>(-1);
            first = Check(t1, t2, first);
            return first.GetNext();
        }

        public static Node<int> Check(BinNode<int> t1, BinNode<int> t2, Node<int> first)
        {
            if (t1 == null)
            {
                return first;
            }
            if (!Exist(t2, t1.GetValue()))
            {
                Node<int> n = new Node<int>(t1.GetValue(), first.GetNext());
                first.SetNext(n);
            }

            first = Check(t1.GetRight(), t2, first);
            first = Check(t1.GetLeft(), t2, first);
            return first;
        }

        public static int sumTree (BinNode<int> t)
        {
            if (t == null)
                return 0;
            
            int sum = 0;
            if (t.GetLeft() != null)
                sum += sumTree(t.GetLeft());
            if (t.GetRight() !=null)
                sum += sumTree(t.GetRight());
            int current = t.GetValue();
            t.SetValue(sum);
            return sum + current;
        }
    }
}
