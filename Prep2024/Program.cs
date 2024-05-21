using System;
using Unit4.CollectionsLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prep2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
        public static Queue<int> Mashlim (Queue<int> SQ)
        {
            Queue<int> SL = new Queue<int>();
            Queue<int> copySQ = CopyQ(SQ);

            int first = copySQ.Remove();
            while (!copySQ.IsEmpty()) 
            {
                int second = copySQ.Remove();
                for (int i = first + 1; i < second; i++)
                {
                    SL.Insert(i);
                }
                first = second;
            }
            return SL;
        }
        
        public static Queue<int> CopyQ (Queue<int> Q)
        {
            Queue<int> copyQ = new Queue<int>();
            Queue<int> tempQ = new Queue<int>();
            while (!Q.IsEmpty()) 
            {
                int t = Q.Remove();
                copyQ.Insert(t);
                tempQ.Insert(t);
            }
            while (!tempQ.IsEmpty())
            {
                Q.Insert(tempQ.Remove());
            }
            return copyQ;
        }
    
        public static Node<Queue<int>> MashlimList (Node<Queue<int>> lst)
        {
            
            Node<Queue<int>> res = new Node<Queue<int>>(null);
            Node<Queue<int>> tail = res;
            while (lst !=null)
            {
                Queue<int> m = Mashlim(lst.GetValue());
                Node<Queue<int>> p = new Node<Queue<int>>(m);
                tail.SetNext(p);
                tail= tail.GetNext();
                lst = lst.GetNext();
            }
                        
            return res.GetNext();
        }
    
        public static int minQ (Queue<int> q)
        {
            Queue<int> temp = CopyQ (q);
            int min = temp.Remove();
            while (!temp.IsEmpty())
            {
                //min = Math.Min(min, temp.Remove());
                int v = temp.Remove();
                if (min > v)
                {
                    min = v;
                }
                
            }
            return min;
        }

        public static int popMin (Queue<int> q)
        {
            int count = 0;
            int min = minQ(q);
            Queue<int> temp = new Queue<int>();

            while (!q.IsEmpty())
            {
                int v = q.Remove();
                if (v != min || count > 0)
                {
                    temp.Insert(v);
                }
                else
                {
                    count++;
                }
            }
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
            return min;
        }
    
        public static int popMin1 (Queue<int> q)
        {
            int min = minQ(q);
            while (!q.IsEmpty())
            {
                int v = q.Remove();
                if (v != min)
                {
                    q.Insert(v);
                }
                else
                {
                    return min;
                }
            }
            return min;
        }

        public static void Sort (Queue<int> q)
        {
            Queue<int> temp = new Queue<int>();
            
            while (!q.IsEmpty())
            {
                int min = popMin(q);
                temp.Insert(min);
            }
            while (temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
        }
    
        public static int sequal (Queue<int> q)
        {
            int count = 1;
            int value = q.Remove();
            while (q.Head() == value)
            {
                count++;
                q.Remove();
            }
            return count;
        }

        public static bool CrazyQ (Queue<int> q)
        {
            int l1 = sequal(q);
            while (!q.IsEmpty())
            {
                int l2 = sequal(q);
                if (l1 >= l2)
                {
                    return false;
                }
                l1 = l2;
            }
            return true;
        }

        public static bool CrazyArr(Queue<int>[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (!CrazyQ(arr[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public static void three (Queue<int> q)
        {
            Queue<int> temp = new Queue<int>(); 
            while (!q.IsEmpty())
            {
                int n1 = q.Remove();
                int n2 = q.Remove();
                int n3 = q.Remove();
                //int min = Math.Min(n1, n2);
                //min = Math.Min(min, n3);
                int min = Math.Min(n1, Math.Min(n2, n3));
                temp.Insert(min);
            }
            while (!temp.IsEmpty())
            {
                q.Insert(temp.Remove());
            }
        }
        //Node<Queue<int>> node;
        //Queue<Node<int>> queue;
        //Queue<int>[] arr;
        //Queue<int[]> Qarr;
        //Node<int[]> lstArr;
        //Node<int>[] arr1;

        public static void func (Node<int> L)
        {
            Node<int> temp = L;
            int count = 1;
            while (temp !=null && temp.HasNext())
            {
                while(temp.GetValue() == temp.GetNext().GetValue())
                {
                    count++;
                    temp = temp.GetNext();
                }
                if (count > 1)
                {
                    Node<int> n = new Node<int>(count);
                    n.SetNext(temp.GetNext());
                    temp.SetNext(n);
                    temp = temp.GetNext();
                }
                temp = temp.GetNext();
                count = 1;

            }
        }

         

    }

    public class Employee
    {
        protected string name;
        protected int vetek;
        public int id;

        public Employee (string name, int vetek, int id)
        {
            this.name = name;
            this.vetek = vetek;
            this.id = id;
        }

        public virtual int getScore ()
        {
            return this.vetek + 4;
        }
    }
    class UnionMemeber : Employee
    {
        protected int UnionVetek;

        public UnionMemeber (int unionVetek, string name, int vetek, int id) : base (name, vetek, id)
        {
            this.UnionVetek = unionVetek;
        }

        public override int getScore()
        {
            return 2 * this.UnionVetek + 2 * base.getScore();
        }

    }
    class Supervisor : Employee
    {
        //Employee[] workers = new Employee[15];
        Employee[] workers;
        private int numberOfWorkers;

        public Supervisor (int unionVetek, string name, int vetek, int id, int maxOfWorkers) : base(name, vetek, id)
        {
            workers = new Employee[maxOfWorkers];
        }
        public void addWorker (Employee worker)
        {
            if (numberOfWorkers < workers.Length)
            {
                workers[numberOfWorkers] = worker;
                numberOfWorkers++;
            }
            
        }

        
    }


}
