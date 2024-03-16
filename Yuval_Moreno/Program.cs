using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace Yuval_Moreno
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 6, -3, 10, 19, 6, 7, 4 };
            Node<int> lst = CreateList(arr);
            
            //PrintList(lst);
            //Console.WriteLine(GetNode(lst, 5));
            //Node<int> lst2 = new Node<int>(3);
            //PrintList(add(lst, lst2));
            //PrintList(add(lst, lst2, 4));
            //PrintList(del(lst, 0));
            //Console.WriteLine(sum(lst));
            //Node<int> lst2 = lst;
            //Node<int> newList = copylist(lst);
            //lst.SetValue(-1);
            //PrintList(lst2);
            //PrintList(newList);
            //Console.WriteLine(max(lst));
            //Console.WriteLine(Consistent(lst));
            //PrintList(SumOfSubList(lst));
            Console.WriteLine(isTriplelist(lst));
        }

        public static Node<int> GetNode(Node<int> head, int n)
        {
            for (int i = 0; i < n; i++)
            {
                head = head.GetNext();
            }
            return head;
        }

        public static Node<int> CreateList(int[] arr)
        {
            Node<int> head = new Node<int>(0);
            Node<int> tail = head;
            for (int i = 0; i < arr.Length; i++)
            {
                Node<int> node = new Node<int>(arr[i]);
                tail.SetNext(node);
                tail = tail.GetNext();
            }
            return head.GetNext();
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
        public static Node<int> add (Node<int> head, Node<int> node)
        {
            
            node.SetNext(head);
            return node;
        }
        public static Node<int> add (Node<int> head, Node<int> node, int n)
        {
            head = new Node<int>(0, head);
            Node<int> temp = head;
            for (int i = 0; i < n; i++)
            {
                head = head.GetNext();

            }
            node.SetNext(head.GetNext());
            head.SetNext(node);
            return temp.GetNext();
        }
        public static Node<int> del(Node<int> head, int n)
        {
            head = new Node<int> (0, head);
            Node<int> temp = head;
            for (int i = 0; i < n; i++)
            {
                head = head.GetNext();
            }
            head.SetNext(head.GetNext().GetNext());
            return temp.GetNext();
        }

        public static int sum (Node<int> head)
        {
            int sum = 0;
            while (head != null)
            {
                sum += head.GetValue();
                head = head.GetNext();
            }
            return sum;

        }
        
        public static Node<int> copylist(Node<int> head)
        {
            Node<int> copy = new Node<int>(0);
            Node<int> tail = copy;
            while(head != null)
            {
                tail.SetNext(new Node<int>(head.GetValue()));
                head = head.GetNext();
                tail = tail.GetNext();
            }
            return copy.GetNext();    
        }
        public static int index(Node<int> head, int value)
        {
            int count = 0;
            while (head != null)
            {
                if (head.GetValue() == value)
                {
                    return count;
                }
                count++;
                head = head.GetNext();
            }
            return -1;
        }
        public static bool contain( Node<int> l1, Node<int> l2)
        {
            while (l1 != null)
            {
                if (!isContain(l2, l1.GetValue()))
                {
                    return false;
                }
                l1 = l1.GetNext(); 
            }
            return true;
        }

        public static bool isContain (Node<int> lst, int value)
        {
            while(lst != null)
            {
                if (lst.GetValue() == value)
                {
                    return true;
                }
                lst = lst.GetNext();    

            }
            return false;
        }
    
        public static bool equal(Node<int> l1, Node<int> l2)
        {
            return contain(l1, l2) && contain(l2, l1);
        }
    
        public static Node<int> max (Node<int> head)
        {
            Node<int> max = new Node<int>(head.GetValue());
            
            while (head!= null)
            {
                if (max.GetValue() < head.GetValue())
                {
                    max.SetValue(head.GetValue()); 
                }
                head = head.GetNext();
            
            }
            return max;
        }
        public static Node<int> max1(Node<int> head)
        {
            Node<int> max = head;

            while (head != null)
            {
                if (max.GetValue() < head.GetValue())
                {
                    max = head;
                }
                head = head.GetNext();

            }
            return max;
        }
        
        
        public static bool Consistent(Node<int> head)
        {
            Node<int> temp = head;
            bool up = true;
            bool down = true;
            // check up
            while(head.HasNext())
            {
                if (head.GetValue() > head.GetNext().GetValue())
                {
                    up= false;
                }
                head = head.GetNext();
            }
            // check down
            while (temp.HasNext())
            {
                if (temp.GetValue() < temp.GetNext().GetValue())
                {
                    down = false;
                }
                temp = temp.GetNext();
            }
            return up || down;
        }

        public static int Length ( Node<int> head)
        {
            int count = 0;
            while(head != null)
            {
                count++;
                head = head.GetNext();
            }
            return count;
        }

        public static Node<int> SumOfSubList ( Node<int> L)
        {
            Node<int> tail = L;
            Node<int> NewList = new Node<int>(0);
            Node<int> newTail = NewList;
            int sum = tail.GetValue();
            while(tail.HasNext()) 
            {
                if(tail.GetNext().GetValue() > tail.GetValue())
                {
                    sum += tail.GetNext().GetValue();
                    tail = tail.GetNext();
                }
                else
                {
                    newTail.SetNext(new Node<int>(sum));
                    newTail = newTail.GetNext();
                    tail = tail.GetNext();
                    sum = tail.GetValue();
                }
            }
            newTail.SetNext(new Node<int>(sum));
            
            return NewList.GetNext();
        }
        public static Node<int> GetPos(Node<int> l, int place)
        {
            for (int i = 0; i < place; i++)
            {
                l = l.GetNext();
            }
            return l; 
        }
        public static bool isTriplelist(Node<int> l)
        {
            Node<int> head = l;
            int length = Length(l);
            if (length == 0 || length % 3 !=0)
            {
                return false;
            }

            int pos = length / 3;
            
            Node<int> head2 = GetPos(l, pos); 
            Node<int> head3 = GetPos(l, pos*2);
            while (head3 != null)
            {
                if (head.GetValue() != head2.GetValue() 
                    || head2.GetValue() != head3.GetValue())
                {
                   return false;  
                }
                head = head.GetNext();
                head2 = head2.GetNext();   
                head3 = head3.GetNext();
            }
            return true;    
        }
    }
}
