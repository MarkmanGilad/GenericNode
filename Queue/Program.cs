using System;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using GenericNode;

namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> q = CreateQueue(new int[] { 3, 7, 2, 12, 34, 1 });
            Console.WriteLine(q);
            Console.WriteLine("isExist1: " + isExist1(q, 34));
            Console.WriteLine("isExist2: " + isExist2(q, 12));
            Console.WriteLine("isExist3: " + isExist3(q, 12));
            Console.WriteLine("Copy: " + Copy(q));
            Console.WriteLine(q);
            Reverse(q);
            Console.WriteLine(q);
            //Console.WriteLine(PopMin(q));
            //Console.WriteLine(PopMin(q));
            Console.WriteLine(Sort(q));

            Queue<int> q2 = CreateQueue(new int[] { 4, 3, 2, 4, 3, 1, 2, 3, 4, 4 });
            Console.WriteLine(Sequence(q2, 4));

            Queue<int> q3 = CreateQueue(new int[] { 3, 7, 2, 12, 34, 1 });
            Console.WriteLine(MinMax(q3, 1));
            Console.WriteLine(q3);
            Console.WriteLine(sortedStack(q3));
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

        public static void Concatenate<T>(Queue<T> q1, Queue<T> q2) // שירשור
        {
            while (!q2.isEmpty())
            {
                q1.Insert(q2.Remove());
            }
        }

        public static bool isExist1<T>(Queue<T> q, T value)
        {
            Queue<T> temp = new Queue<T>();
            bool exist = false;
            while (!q.isEmpty())
            {
                T val = q.Remove();
                temp.Insert(val);
                if (val.Equals(value))
                {
                    exist = true;
                }
            }
            Concatenate(q, temp);
            return exist;
        }

        public static bool isExist2<T>(Queue<T> q, T value)
        {
            bool exist = false;
            T flag = q.Head();
            if (flag.Equals(value))
                return true;
            q.Insert(q.Remove());
            while (!q.Head().Equals(flag))
            {
                if (q.Head().Equals(value))
                    exist = true;
                q.Insert(q.Remove());
            }
            return exist;
        }

        public static bool isExist3(Queue<int> q, int value)
        {
            bool exist = false;
            int flag = -1;
            q.Insert(-1);
            while (!q.Head().Equals(flag))
            {
                if (q.Head().Equals(value))
                    exist = true;
                q.Insert(q.Remove());
            }
            q.Remove();
            return exist;
        }
        
        public static Queue<T> Copy<T>(Queue<T> q)
        {
            Queue<T> q1 = new Queue<T>();
            Queue<T> temp = new Queue<T>();
            while (!q.isEmpty())
            {
                T item = q.Remove();
                temp.Insert(item);
                q1.Insert(item);
            }
            while (!temp.isEmpty())
            {
                q.Insert(temp.Remove());
            }
            return q1;
        }

        public static void Reverse<T>(Queue<T> q)
        {
            Stack<T> st = new Stack<T>();
            while (!q.isEmpty())
            {
                st.Push(q.Remove());
            }
            while (!st.isEmpty())
            {
                q.Insert(st.Pop());
            }
        }

        public static int PopMin(Queue<int> q)
        {
            Queue<int> temp = new Queue<int>();
            int min = q.Remove();
            while (!q.isEmpty())
            {
                int value = q.Remove();
                if (value > min)
                {
                    temp.Insert(value);
                }
                else
                {
                    temp.Insert(min);
                    min = value;
                }
            }
            Concatenate(q, temp);
            return min;
        }

        public static Queue<int> Sort(Queue<int> q)
        {
            Queue<int> q1 = Copy(q);
            Queue<int> oredered = new Queue<int>();

            while (!q1.isEmpty())
            {
                oredered.Insert(PopMin(q1));
            }
            return oredered;
        }

        public static bool Sequence(Queue<int> q, int n)
        {
            int[] arr = new int[n + 1];
            q.Insert(-1);
            bool result = true;
            while (q.Head() != -1)
            {
                if (q.Head() > n || q.Head() < 1)
                    result = false;
                arr[q.Head()] += 1;
                q.Insert(q.Remove());
            }
            q.Remove(); // remove flag -1
            for (int i = 1; i <= n; i++)
            {
                if (arr[i] != i)
                    result = false;
            }
            return result;
        }

        public static Stack<int> sortedStack(Queue<int> q)
        {
            int min = 0;
            Stack<int> s = new Stack<int>();
            while (min >= 0) // כל עוד יש בתור מספרים גדולים יותר
            {
                min = MinMax(q, min);
                if (min > 0)
                    s.Push(min);
            }
            return s;
        }

        public static int MinMax(Queue<int> q, int n) // מחזיר את האיבר הקטן ביותר שגדול למספר שהתקבל. אם אין יחזיר מינוס 1
        {
            int flag = -1;
            q.Insert(flag);
            int minMax = int.MaxValue;
            while (q.Head() != -1)
            {
                if (q.Head() > n)
                {
                    minMax = Math.Min(minMax, q.Head());
                }
                q.Insert(q.Remove());
            }
            q.Remove(); // remove flag
            if (minMax == int.MaxValue)
                return -1;
            else
                return minMax;
        }

        public static void Merge (Queue<int> q1, Queue<int> q2) 
        {
            Queue<int> merge = new Queue<int>();

            while (!q1.isEmpty() && !q2.isEmpty()) 
            {
                if (q1.Head() < q2.Head())
                {
                    merge.Insert(q1.Remove());
                } else
                {
                    merge.Insert(q2.Remove());
                }
            }
            if (!q1.isEmpty())
            {
                Concatenate(merge, q1);
            }
            else if (!q2.isEmpty())
            {
                Concatenate(merge, q2);
            }
            
            Concatenate(q1, merge); // q1 is empty

        }

        // תגבור
        public static void PopMin1 (Queue<int> q)
        {
            int min = q.Head();
            Queue<int> temp = new Queue<int> ();
            while (!q.isEmpty())
            {
                
                temp.Insert(q.Remove());
                if (temp.Head() < min)
                {
                    min = temp.Head();
                }
            }

            while (!temp.isEmpty())
            {
                if (temp.Head() != min)
                {
                    q.Insert(temp.Remove());
                }
                else
                {
                    temp.Remove();
                }
            }

            
        }
    }
}
