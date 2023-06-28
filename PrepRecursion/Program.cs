using System;
using Unit4.CollectionsLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace PrepRecursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static void What(Queue<int> q)
        {
            if (q.Head() != 0)
            {
                int x = q.Remove();
                if (x > 0)
                    q.Insert(x);
                What(q);
                if (x < 0)
                    q.Insert(x);
            }
        }

        public static void sod(Queue<int> q)
        {
            q.Insert(0);
            What(q);
            q.Remove();
            while (!q.IsEmpty())
                Console.WriteLine(q.Remove() + "");
        }

        public static int wow (Queue<int> q, int num)
        {
            if (q.IsEmpty())
                return 0;
            int x = q.Remove();
            if (x % num == 0)
                return x + wow(q, num);
            return wow(q, num);
        }
    }
}
