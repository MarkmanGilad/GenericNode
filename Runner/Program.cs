using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericNode;

namespace Runner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<Runner> lst = Runner.ReadFromTextFile(@"C:\Users\gilad\Markman Dropbox\Gilad Markman\הוראה\יסודות\GenericNode\Runner\Runners.txt");
            
            PrintList(lst);
            Console.WriteLine(Average(lst));
            PrintList(TwoLevels(lst, 60));
            Node<Runner> lst2 = Runner.ReadFromTextFile(@"C:\Users\gilad\Markman Dropbox\Gilad Markman\הוראה\יסודות\GenericNode\Runner\Runners.txt");
            PrintList(TwoLevels2(lst2, 60));

            lst = Runner.ReadFromTextFile(@"C:\Users\gilad\Markman Dropbox\Gilad Markman\הוראה\יסודות\GenericNode\Runner\Runners.txt");
            lst2 = Slice(lst, 60);
            PrintList(lst);
            PrintList(lst2);

            lst = Runner.ReadFromTextFile(@"C:\Users\gilad\Markman Dropbox\Gilad Markman\הוראה\יסודות\GenericNode\Runner\Runners.txt");
            Node<Runner>[] arr = Slice2(lst, 60);
            PrintList(arr[0]);
            PrintList(arr[1]);

            lst = Runner.ReadFromTextFile(@"C:\Users\gilad\Markman Dropbox\Gilad Markman\הוראה\יסודות\GenericNode\Runner\Runners.txt");
            PrintList(findByCountry(lst, "Israel"));

            lst = Runner.ReadFromTextFile(@"C:\Users\gilad\Markman Dropbox\Gilad Markman\הוראה\יסודות\GenericNode\Runner\Runners.txt");
            Dell(lst, "Canada");
            PrintList(lst);

            lst = Runner.ReadFromTextFile(@"C:\Users\gilad\Markman Dropbox\Gilad Markman\הוראה\יסודות\GenericNode\Runner\Runners.txt");
            lst = Dell2(lst, "Canada");
            PrintList(lst);

        }
        public static void PrintList<T>(Node<T> head)
        {
            while (head != null)
            {
                Console.WriteLine(head);
                head = head.GetNext();
            }
            Console.WriteLine("*****************************************************");
        }

        public static double Average(Node<Runner> lst)
        {
            double sum = 0;
            int num = 0;
            while (lst != null)
            {
                sum += lst.GetValue().GetTime();
                num++;
                lst = lst.GetNext();
            }
            return sum / num;
        }

        public static Node<Runner> TwoLevels(Node<Runner> lst, int time)
        {
            lst = new Node<Runner>(new Runner("", "", 0), lst);
            Node<Runner> p = lst;
            Node<Runner> end_fast = p;
            while (p.HasNext())
            {
                Node<Runner> temp = p.GetNext();
                if (temp.GetValue().GetTime() < time)
                {
                    p.SetNext(temp.GetNext());
                    temp.SetNext(end_fast.GetNext());
                    end_fast.SetNext(temp);
                    end_fast = end_fast.GetNext();
                } else
                {
                    p = p.GetNext();
                }
                
            }
            return lst.GetNext();
        }

        public static Node<Runner> TwoLevels2(Node<Runner> lst, int time)
        {
            lst = new Node<Runner>(new Runner("", "", 0), lst);
            Node<Runner> p = lst;
            while (p.HasNext())
            {
                Node<Runner> temp = p.GetNext();
                if (temp.GetValue().GetTime() < time)
                {
                    p.SetNext(temp.GetNext());
                    temp.SetNext(lst.GetNext());
                    lst.SetNext(temp);
                } else
                {
                    p = p.GetNext();
                }
                
            }
            return lst.GetNext();
        }

        public static Node<Runner> Slice (Node<Runner> lst, int time)
        {
            lst = new Node<Runner>(new Runner("", "", 0), lst);
            Runner r = new Runner("", "", 0);
            Node<Runner> newLst = new Node<Runner>(r);
            Node<Runner> newTail = newLst;

            while (lst.HasNext())
            {
                if (lst.GetNext().GetValue().GetTime() < time)
                {
                    newTail.SetNext(lst.GetNext());
                    lst.SetNext(lst.GetNext().GetNext());
                    newTail = newTail.GetNext();
                } else
                {
                    lst = lst.GetNext();
                }
            }
            newTail.SetNext(null);
            return newLst.GetNext();
        }

        public static Node<Runner>[] Slice2(Node<Runner> lst, int time)
        {
            Node<Runner>[] arr = new Node<Runner>[2];
            Runner r1 = new Runner();
            Runner r2 = new Runner("", "", 0);
            arr[0] = new Node<Runner>(r1);
            Node<Runner> tail0 = arr[0];
            arr[1] = new Node<Runner>(r2);
            Node<Runner> tail1 = arr[1];
            while (lst != null)
            {
                if (lst.GetValue().GetTime() < time)
                {
                    tail0.SetNext(lst);
                    tail0 = tail0.GetNext();
                } else
                {
                    tail1.SetNext(lst);
                    tail1= tail1.GetNext();
                }
                lst = lst.GetNext();
            }
            tail0.SetNext(null);
            tail1.SetNext(null);
            arr[0] = arr[0].GetNext();
            arr[1] = arr[1].GetNext();
            return arr;
        }

        public static Node<Runner> findByCountry (Node<Runner> lst, string country) 
        {
            Runner r = new Runner();
            Node<Runner> head = new Node<Runner>(r);
            Node<Runner> tail = head;

            while (lst != null)
            {
                if (lst.GetValue().GetCountry() == country)
                {
                    r = new Runner(lst.GetValue().GetCountry(), lst.GetValue().GetName(), lst.GetValue().GetTime());
                    tail.SetNext(new Node<Runner>(r));
                    tail = tail.GetNext();
                }
                lst= lst.GetNext();
            }
            return head.GetNext();
        }

        public static void Dell(Node<Runner> lst, string country)
        {
            Runner r = new Runner();
            lst = new Node<Runner>(r, lst);

            while (lst.HasNext())
            {
                if (lst.GetNext().GetValue().GetCountry() == country)
                {
                    lst.SetNext(lst.GetNext().GetNext());
                } else
                {
                    lst = lst.GetNext();
                }
                
            }
        }

        public static Node<Runner> Dell2 (Node<Runner> lst, string country)
        {
            Runner r = new Runner();
            lst = new Node<Runner>(r, lst);
            Node<Runner> head = lst;

            while (lst.HasNext())
            {
                if (lst.GetNext().GetValue().GetCountry() == country)
                {
                    lst.SetNext(lst.GetNext().GetNext());
                }
                else
                {
                    lst = lst.GetNext();
                }
            }
            return head.GetNext();
        }
    }

}
