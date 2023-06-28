using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace QueueExam
{
    internal class Program
    {
        public static int Length (Queue<int> q)
        {
            int length = 0;
            Queue<int> temp = q;
            while (!q.IsEmpty())
            {
                length++;
                temp.Insert(q.Remove());
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
            return length;
        }

        public static bool IsBalanced(Queue<int>[] a)
        {
            int first, second;
            first = Length(a[0]);
            for (int i = 1; i < a.Length; i++)
            {
                second = Length(a[i]);
                if (Math.Abs(first - second) > 1)
                    return false;
                first = second;
            }
            return true;
        }
        public static Queue<char> ToSet (Queue<char> q)
        {
            Queue<char> temp = Copy (q);
            Queue<char> set = new Queue<char>();

            while (!temp.IsEmpty())
            {
                char c = temp.Remove();
                if (!isExist(set, c))
                    set.Insert(c);
            }
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

        public static Queue<char> Intersect_2(Queue<char> q1, Queue<char> q2)
        {
            Queue<char> res = new Queue<char>();
            Queue<char> temp_q1 = Copy(q1);

            while (!temp_q1.IsEmpty())
            {
                char ch = temp_q1.Remove();
                if (isExist(q2, ch))
                {
                    res.Insert(ch);
                }
            }
            return ToSet(res);
        }

        public static Queue<Queue<char>> deepCopy (Queue<Queue<char>> qq)
        {
            Queue<Queue<char>> temp = new Queue<Queue<char>>();
            Queue<Queue<char>> copy = new Queue<Queue<char>>();
            while (!qq.IsEmpty())
            {
                copy.Insert(Copy(qq.Head()));
                temp.Insert(qq.Remove());

            }
            while (!temp.IsEmpty())
                qq.Insert(temp.Remove());
            return copy;

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
            
            Queue<char> q1 = CreateQueue(new char[] { 'a', 'c', 'a', 'd', 'b', 'b' });
            Queue<char> q2 = CreateQueue(new char[] { 'b', 'b', 'c', 'a', 'a', 'e' });
            Console.WriteLine(Intersect1(q1, q2));
            Console.WriteLine(q1);
            Console.WriteLine(q2);
            */
            //Node<int> lst = CreateList(new int[] { 3, 5, 1, -2, 3, 8, 5, 2, 9 });
            //PrintList(lst);
            //Console.WriteLine(Secret(lst));
            Queue<int> q = CreateQueue(new int[] { 3, 5, 1, -2, 3, 8, 5, 2, 9 });
            Console.WriteLine(q);
            Console.WriteLine(CheckOposite(q, -2));
            q = CreateQueue(new int[] { 3, 5, 1, -2, 3, 8, 5, 2, 9 });
            Console.WriteLine(CountOposite(q, -2));

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

        /********************** Moed B **************************/

        public static void PrintList<T>(Node<T> head)
        {
            while (head != null)
            {
                Console.Write(head + " ");
                head = head.GetNext();
            }
            Console.WriteLine();
        }

        public static Node<int> CreateList (int[] arr)
        {
            Node<int> lst = new Node<int>(arr[0]);
            Node<int> p = lst;
            for (int i = 1; i < arr.Length; i++) {
                p.SetNext(new Node<int>(arr[i]));
                p = p.GetNext();
            }
            return lst;
        }

        public static int Secret (Node<int> p)
        {
            int x;
            if (p.GetNext() == null)
            {
                x = 0;
            }
            else
            {
                x = Secret(p.GetNext());
                if (p.GetNext().GetValue() < p.GetValue())
                {
                    x++;
                }
            }
            return x;
        }
    
    
        public static bool CheckOposite (Queue<int> q, int num) 
        {
            bool found = false;
            while (!q.IsEmpty())
            {
                int value = q.Remove();
                if (num == value)
                {
                    if (!found)
                    {
                        found = true;
                        num *= -1;
                    } 
                    else 
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static int  CountOposite(Queue<int> q, int num)
        {
            bool found = false;
            int count = 0;
            while (!q.IsEmpty())
            {
                int value = q.Remove();
                if (found)
                {
                    if (num == value)
                    {
                        return count;
                    }
                    count++;
                } 
                else if (num == value)
                    {
                        found = true;
                        num *= -1;
                    }
            }
            return -1;
        }

        public static Node<Item> CountQueue (Queue<int> q)
        {
            Item item = new Item(0); // פיקטיבי
            Node<Item> itemList = new Node<Item>(item);
            Node<Item> tail = itemList;
            while (!q.IsEmpty())
            {
                int num = q.Head();
                item = new Item(num);
                item.setAmountQueue(CountRemove(q, num));
                tail.SetNext(new Node<Item>(item));
                tail = tail.GetNext();
            }
            return itemList.GetNext();
        }

        public static int CountRemove (Queue<int> q, int num) 
        {
            Queue<int> temp = new Queue<int>();
            int count = 0;

            while (!q.IsEmpty())
            {
                if (q.Head() == num)
                {
                    count++;
                    q.Remove();
                } else
                {
                    temp.Insert(q.Remove());
                }
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
            return count;
        }

        
        
    }

    
}
