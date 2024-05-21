using System;
using Unit4.CollectionsLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahav
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<int> n = new Node<int>(0);
            Node<int> n1 = new Node<int>(1, n);

            Console.WriteLine(n.GetValue());
            Console.WriteLine(n1.GetNext().GetValue());
        }
        public static void print (Node<int> lst) 
        {
            while (lst != null)
            {
                Console.WriteLine(lst.GetValue());
                lst = lst.GetNext();
            }
        }
        public static Node<int> CreateList (int[] arr)
        {
            Node<int> lst = new Node<int>(0);
            Node<int> tail = lst;
            for (int i = 0; i < arr.Length; i++)
            {
                Node<int> node = new Node<int>(arr[i]);
                tail.SetNext(node);
                tail = tail.GetNext();
            }
            return lst.GetNext();
        }
    
        public static int Length (Node<int> lst) 
        {
            int count = 0;
            Node<int> lst1 = lst;
            while (lst1 != null)
            {
                count++;
                lst1 = lst1.GetNext();
            }
            return count;
        }

        public static bool isTriple (Node<int> lst)
        {
            int length = Length(lst);
            if (length == 0 || length % 3 != 0) { return false;}

            Node<int> lst1 = lst;
            Node<int> lst2 = lst;
            Node<int> lst3 = lst;

            for (int i = 0;i < length/3;i++)
            {
                lst2 = lst2.GetNext();
            }
            for (int i = 0; i < length / 3 * 2; i++)
            {
                lst3 = lst3.GetNext();
            }
            for (int i = 0; i < length / 3; i++)
            {
                if (lst1.GetValue() != lst2.GetValue() || lst1.GetValue() != lst3.GetValue()) 
                { 
                    return false;
                }
                lst1 = lst1.GetNext();
                lst2 = lst2.GetNext();
                lst3 = lst3.GetNext();
            }
            return true;

        }
    
        public static Node<RangeNode> CreateRangeList (Node<int> L) // אני מניח שיש לפחות שתי חוליות בשרשרת
        {
            Node<int> l1 = L;
            Node<int> l2 = l1;
            Node<RangeNode> RL = new Node<RangeNode>(new RangeNode(0,0));
            Node<RangeNode> tail = RL;
            while (l2.HasNext())
            {
                while (l2.HasNext() && l2.GetNext().GetValue() - 1 == l2.GetValue()) // bug end of list
                {
                    l2 = l2.GetNext();
                }
                l1 = l2.GetNext();
                RangeNode rn = new RangeNode(l1.GetValue(), l2.GetValue());
                Node<RangeNode> n = new Node<RangeNode>(rn);
                tail.SetNext(n);
                //tail.SetNext(new Node<RangeNode>(new RangeNode(l1.GetValue(), l2.GetValue())));
                tail = tail.GetNext();
                l2 = l1;
            }
            return RL.GetNext();
            
            
        }
    }

    class RangeNode
    {
        private int from;
        private int to;

        public RangeNode(int from, int to)
        {
            this.from = from;
            this.to = to;
        }
    }
}
