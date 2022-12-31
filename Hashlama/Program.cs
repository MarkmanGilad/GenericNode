using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericNode;
using GenericList;

namespace Hashlama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<int> head = GenericList.Program.CreateRandomList(20);
            Print(head);
            Console.WriteLine(Index(head, 27));
            Console.WriteLine(LastIndex(head, 27));
            Console.WriteLine(Find(head, 11));
            Print(Copy_bigger(head, 50));
            Print(Copy_bigger1(head, 50));


            Console.ReadKey();
        }
        public static void Print (Node<int> lst)
        {
            while (lst != null)
            {
                Console.Write(lst + " ");
                lst = lst.GetNext();
            }
            Console.WriteLine();

        }
       
        public static int Index (Node<int> lst, int num)
        {
            int count = 0;
            while (lst != null)
            {
                if (lst.GetValue() == num)
                {
                    return count;
                }
                count++;
                lst = lst.GetNext();
            }
            return -1;
        }

        public static int LastIndex(Node<int> lst, int num)
        {
            int index = -1;
            int count = 0;
            while (lst != null)
            {
                if (lst.GetValue() == num)
                {
                    index = count;
                }
                count++;
                lst = lst.GetNext();
            }
            return index;
        }
        public static Node<int> Find (Node<int> lst, int n)
        {
            for (int i=0; i < n; i++)
            {
                lst = lst.GetNext();
            }
            return lst;
        }
    
        public static Node<int> Copy_bigger (Node<int> lst, int num)
        {
            Node<int> head = new Node<int>(-1);
            Node<int> tail = head;

            while (lst != null)
            {
                if (lst.GetValue() > num)
                {
                    Node<int> temp = new Node<int>(lst.GetValue());
                    tail.SetNext(temp);
                    tail = temp; // tail = tail.GetNext();

                }
                lst = lst.GetNext();
            }
            return head.GetNext();
        }

        public static Node<int> Copy_bigger1(Node<int> lst, int num)
        {
            Node<int> head = null;
            while (lst != null)
            {
                if (lst.GetValue() > num)
                {
                    Node<int> t = new Node<int>(lst.GetValue(), head);
                    head = t;
                }
                lst = lst.GetNext();
            }
            return head;
        }


    }
}
