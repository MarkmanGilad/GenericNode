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

    }
}
