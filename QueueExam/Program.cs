using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace QueueExam
{
    internal class Program
    {
        public static Queue<char> ToSet (Queue<char> q)
        {
            Queue<char> temp = new Queue<char>();
            Queue<char> set = new Queue<char>();

            while (!q.IsEmpty())
            {
                char c = q.Remove();
                temp.Insert(c);
                if (!isExist(set, c))
                    set.Insert(c);
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
            return set;
        }

        public static bool isExist (Queue<char> q, char ch)
        {
            bool exist = false;
            Queue<char> temp = new Queue<char>();
            while (!q.IsEmpty())
            {
                char c = q.Remove();
                temp.Insert(c);
                if (ch == c)
                    exist= true;
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
            return exist;
        }
        
        public static Queue<char> Intersect (Queue<char> q1, Queue<char> q2)
        {
            Queue<char> res = new Queue<char>();
            Queue<char> temp = new Queue<char>();

            while (!q1.IsEmpty())
            {
                char ch = q1.Remove();
                temp.Insert(ch);
                if (isExist(q2,ch))
                {
                    res.Insert(ch);
                }
            }
            while(!temp.IsEmpty())
                q1.Insert(temp.Remove());
            
            return ToSet(res);
        }

        public static Queue<T> Copy<T>(Queue<T> q)
        {
            Queue<T> q1 = new Queue<T>();
            Queue<T> temp = new Queue<T>();
            while (!q.IsEmpty())
            {
                T item = q.Remove();
                temp.Insert(item);
                q1.Insert(item);
            }
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
            return q1;
        }

        public static Queue<char> QueueIntersect(Queue<Queue<char>> qq)
        {
            Queue<Queue<char>> temp = new Queue<Queue<char>>();
            Queue<char> res = Copy(qq.Head());

            while (!qq.IsEmpty())
            {
                temp.Insert(Copy(qq.Head()));
                Queue<char> q = qq.Remove();
                res = Intersect(res, q);

            }
            while (!temp.IsEmpty())
                qq.Insert(temp.Remove());
            return res;
        }

        public static Queue<T> CreateQueue<T>(T[] arr)
        {
            Queue<T> q = new Queue<T>();
            for (int i = 0; i < arr.Length; i++)
            {
                q.Insert(arr[i]);
            }
            return q;
        }

        static void Main(string[] args)
        {
            /*
            Queue<char> q1 = CreateQueue(new char[] { 'a', 'c', 'a', 'd', 'b', 'b'});
            Queue<char> q2 = CreateQueue(new char[] { 'b', 'b', 'c', 'a', 'a', 'e'});
            Queue<char> q3 = CreateQueue(new char[] { 'a', 'c', 'a', 'a', 'f' });
            Queue<char> q4 = CreateQueue(new char[] { 'd', 'd', 'c', 'a', 'a' });
            Queue<Queue<char>> qq = CreateQueue(new Queue<char>[] { q1, q2, q3, q4 });

            //Console.WriteLine(q1);
            //Console.WriteLine(q2);
            //Console.WriteLine(isExist(q2, 'g'));
            //Console.WriteLine(ToSet(q1));
            //Console.WriteLine(Intersect(q1, q2));
            //Console.WriteLine(q1);
            //Console.WriteLine(q2);
            Console.WriteLine(qq);
            Console.WriteLine(QueueIntersect(qq));
            Console.WriteLine(qq);
            */
            Queue<char> q1 = CreateQueue(new char[] { 'a', 'c', 'a', 'd', 'b', 'b' });
            Queue<char> q2 = CreateQueue(new char[] { 'b', 'b', 'c', 'a', 'a', 'e' });
            Console.WriteLine(Intersect1(q1, q2));
            Console.WriteLine(q1);
            Console.WriteLine(q2);
        }
    
        /********************** Exam Check **************************/

        public static Queue<char> ToSet1 (Queue<char> tor)
        {
            Queue<char> final = new Queue<char> ();
            Queue<char> temp1 = new Queue<char>();
            Queue<char> temp2 = new Queue<char>();
            bool check = true; 
            char hold1, hold2;

            while (!tor.IsEmpty())
            {
                hold1 = tor.Remove();
                check = true;
                temp1.Insert(hold1);
                while (!final.IsEmpty())
                {
                    hold2 = final.Remove();
                    temp2.Insert(hold2);
                    check = check && hold1 != hold2;
                }
                while (!temp2.IsEmpty())
                {
                    final.Insert(temp2.Remove());
                }
                if (check)
                {
                    final.Insert(hold1);
                }
            }
            while (!temp1.IsEmpty())
            {
                tor.Insert(temp1.Remove());
            }
            return final;

        }
    
        public static Queue<char> Intersect1(Queue<char> tor1, Queue<char> tor2)
        {
            Queue<char> temp1 = new Queue<char>();
            Queue<char> temp2 = new Queue<char>();
            Queue<char> final = new Queue<char>();

            bool check = true;
            char hold1, hold2;

            while (!tor1.IsEmpty())
            {
                hold1 = tor1.Remove();
                check = true;
                temp1.Insert(hold1);
                while (!tor2.IsEmpty())
                {
                    hold2 = tor2.Remove();
                    temp2.Insert(hold2);
                    check = check && hold1 != hold2;
                }
                while (!temp2.IsEmpty())
                {
                    tor2.Insert(temp2.Remove());
                }
                if (!check)
                {
                    final.Insert(hold1);
                }
            }
            while (!temp1.IsEmpty())
            {
                tor1.Insert(temp1.Remove());
            }
            return ToSet1(final);
        }
    }
}
