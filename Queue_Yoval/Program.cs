using System;
using Unit4.CollectionsLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue_Yoval
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> q = new Queue<int>();

            q.Insert(5);
            q.Insert(6);

            Console.WriteLine(q);

            int[] arr = { 1, 4, 6, 2, -5, 7 };
            Queue<int> q1 = CreateQueue(arr);
            Console.WriteLine(q1);
            Console.WriteLine(isExists(q1,2));
            Console.WriteLine(q1);


        }

        public static Queue<int> CreateQueue(int[] arr)
        {
            Queue<int> q = new Queue<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                q.Insert(arr[i]);
            }
            return q;

        }

        public static bool isExists(Queue<int> q, int value)
        {
            bool exists = false;
            Queue<int> temp = q;
            while (!temp.IsEmpty())
            {
                int v = temp.Remove();
                if (v == value)
                {
                    exists = true;
                }
            }
            return exists;
        }

        public static bool TwoSum(Queue<int> q, int x)
        {
            while (!q.IsEmpty())
            {
                int first = q.Remove();
                int second = x - first;
                if (isExists(q, second))
                {
                    return true;
                }
            }
            return false;

        }
    }
}
