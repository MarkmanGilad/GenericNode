using System;
using Unit4.CollectionsLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiryat_Shmona
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Node<int> n1 = new Node<int>(1);

            //Console.WriteLine(n1);
            int[] arr = { 1, 10, 2, -3, 7 };
            Node<int> lst = CreateList(arr);
            PrintList(lst);
            Console.WriteLine(SumList(lst));

            Console.ReadLine();
        }
        public static Node<int> CreateList (int [] arr) 
        {
            Node<int> lst = new Node<int>(0);
            Node<int> tail = lst;
            for (int i = 0; i < arr.Length; i++)
            {
                Node<int> n = new Node<int>(arr[i]);
                tail.SetNext(n);
                tail = tail.GetNext();
            }
            return lst.GetNext();
        }
        
        public static void PrintList(Node<int> head)
        {
            while (head != null)
            {
                Console.Write(head + " ");
                head = head.GetNext();
            }
            Console.WriteLine();
        }

        public static int SumList (Node<int> lst)
        {
            int sum = 0;

            
            return 0;
        }
        
        public static void AddLast (Node<int> lst, int value) 
        { 

        }

        public static Node<int> Add (Node<int> lst, int value, int n)
        {
            Node<int> node = new Node<int>(value);
            Node<int> temp = lst;
            
            return null;
        }

        public static Queue<int> CreateQ (int[] arr)
        {
            Queue<int> q = new Queue<int>();
            for (int i=0; i < arr.Length; i++)
            {
                q.Insert(arr[i]);
            }
            return q;
        }
        public static Queue<int> CopyQ (Queue<int> q)
        {
            Queue<int> newQ = new Queue<int>();
            Queue<int> tempQ = new Queue<int>();
            while (!q.IsEmpty()) 
            {
                int value = q.Remove();
                newQ.Insert(value);
                tempQ.Insert(value);
            }
            while (!tempQ.IsEmpty())
            {
                q.Insert(tempQ.Remove());
            }
            return newQ;

        }

        public static bool isExist (Queue<int> q, int value)
        {
            Queue<int> tempQ = CopyQ (q);
            while (!tempQ.IsEmpty())
            {
                int v = tempQ.Remove();
                if (value == v)
                {
                    return true;
                }
            }
            return false;
        }
    
        public static int minQ (Queue<int> q)
        {
            Queue<int> copyQ = CopyQ(q);
            int min = copyQ.Head();
            while (!copyQ.IsEmpty())
            {
                if (copyQ.Head() < min)
                {
                    min = copyQ.Head();
                }
                copyQ.Remove();
            }
            return min;
        }

        public static int popMin (Queue<int> q) 
        { 
            Queue<int> temp = new Queue<int>();
            int min = minQ(q);
            bool flag = false;
            while(!q.IsEmpty())
            {
                if(q.Head() != min || flag)
                {
                    temp.Insert(q.Remove());
                }
                else 
                {
                    q.Remove();
                    flag = true;
                } 
            }
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
            return min;
        }

        public static Queue<int> Sort (Queue<int> q)
        {
            Queue<int> copy = CopyQ(q);
            Queue<int> temp = new Queue<int>();

            while (!copy.IsEmpty())
            {
                temp.Insert(popMin(copy));
            }
            return temp;
        }
    
        public static void exp ()
        {
            Queue<Queue<int>> qq = new Queue<Queue<int>>();
            Queue<Node<int>> qn = new Queue<Node<int>>();
            Node<Queue<int>> nq = new Node<Queue<int>>(null);
            Queue<int>[] arrq = new Queue<int>[10];
            Queue<int[]> qarr = new Queue<int[]>();
            int[] arr = new int[10];
            qarr.Insert(arr);


        }
    
    }
}
