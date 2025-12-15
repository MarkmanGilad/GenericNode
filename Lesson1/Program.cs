using System;
using System.IO;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace GenericList
{
    public class Program
    {
        static Random rnd = new Random(10);
        static void Main(string[] args)
        {

            int[] arr = { 10, 9, 8 };
            Node<int> head = CreateRandomList(10);
            PrintList(head);
            Node<double> headDouble = CreateRandomListDouble(10);
            PrintList(headDouble);
            Node<string> headStr = CreateListStr(10);
            PrintList(headStr);

            Console.WriteLine("Length: " + Length(headStr));
            Console.WriteLine("Get: " + GetNode(headStr, 5));

            Node<int> node = new Node<int>(100);
            PrintList(Add(head, node, 7));
            node = new Node<int>(200);
            AddLast(head, node);
            PrintList(head);
            Del(head, 7);
            head = Pop(head);
            PrintList(head);
            Console.WriteLine(Sum(head));
            Console.Write("copylist: ");
            PrintList(CopyList2(headStr));
            headDouble = Reverse(headDouble);
            PrintList(headDouble);
            PrintList(ReverseNew(headDouble));
            Console.WriteLine(Index(head, 200));
            Add(headStr, new Node<string>("text"), 4);
            Node<string> n = Find(headStr, "text");
            Console.WriteLine(n);
            PrintList(headStr);
            PrintList(Slice(headStr, 3, 8));

            Node<string> headStr2 = CopyList(headStr);
            PrintList(headStr);
            PrintList(headStr2);
            Console.WriteLine(Equal(headStr, headStr2));


            headStr2 = Slice(headStr2, 2, 4);
            PrintList(headStr2);
            Console.WriteLine(Equal(headStr, headStr2));

            Node<string> union = Union(headStr, headStr2);
            PrintList(union);
            Node<int> l1 = CreateRandomList(10);
            Node<int> l2 = CreateRandomList(10);
            PrintList(l1);
            PrintList(l2);
            PrintList(Intersect(l1, l2));
            PrintList(Intersect_Unique(l1, l2));
            l1 = CreateRandomList(20);
            PrintList(l1);
            Unique(l1);
            PrintList(l1);
            Console.WriteLine(Max(l1));
            l1 = new Node<int>(0);
            for (int i = 2; i < 20; i += 2)
            {
                l1 = Add(l1, new Node<int>(i));
            }
            l2 = new Node<int>(0);
            for (int i = 3; i < 20; i += 3)
            {
                l2 = Add(l2, new Node<int>(i));
            }
            PrintList(l1);
            PrintList(l2);
            PrintList(UnionSort(l1, l2));

            Node<int> intList = CreateRandomList(50);
            PrintList(intList);
            Console.WriteLine(commonValue(intList));
            l1 = new Node<int>(0);
            for (int i = 2; i < 20; i += 2)
            {
                AddLast(l1, new Node<int>(i));
            }
            PrintList(l1);
            Add(l1, new Node<int>(6), 4);
            PrintList(l1);
            Console.WriteLine(Consistent(l1));
            PrintList(SumOfsubList(l1));

            // Bagrot 2010 RangeNode
            Node<int> h = ReadFromTextFile("List.txt");
            PrintList(h);
            PrintList(CreateRangeList(h));
            PrintList(CreateRangeList2(h));

            // Bagrot 2020 BuildDigit
            h = ReadFromTextFile(@"List1.txt");
            PrintList(h);
            PrintList(BuildDigit(h));
            PrintList(BuildDigit2(h));

            // maxSortedSubList
            h = ReadFromTextFile("List2.txt");
            PrintList(h);
            Console.WriteLine(maxSortedSubList(h));
            
            head = CreateRandomList(50);
            PrintList(head);

            Console.Write("RecursionPrint: ");
            RecursionPrint(head);
            Console.WriteLine();

            Console.WriteLine("RecursionLength: " + RecursionLength(head));
            Console.WriteLine("RecursionLength2: " + RecursionLength2(head, 0));

            Console.WriteLine("RecursionCount: " + RecursionCount(head, 74));
            Console.WriteLine("RecursionMax: " + RecursionMax(head));

            Console.Write("RecursionList: ");
            PrintList(RecursionCopy(head));
            Console.Write("RecursionListReverse: ");
            PrintList(RecursionReverse(head, null));

            Console.ReadLine();


        }
        public static Node<int> CreateRandomList(int n)
        {
            //Random rnd = new Random(10);
            Node<int> head = new Node<int>(rnd.Next(100));
            Node<int> tail = head;
            for (int i = 1; i < n; i++)
            {
                tail.SetNext(new Node<int>(rnd.Next(100)));
                tail = tail.GetNext();
            }
            return head;
        }
        public static Node<int> CreateList(int[] arr)
        {
            Node<int> head = new Node<int>(0);
            Node<int> tail = head;
            for (int i = 0;i < arr.Length;i++)
            {
                Node<int> node = new Node<int>(arr[i]);
                tail.SetNext(node);
                tail = tail.GetNext();
            }
            return head.GetNext();
        }
        public static Node<string> CreateListStr(int n)
        {
            Random rnd = new Random(100);
            Node<string> head = new Node<string>("" + (char)rnd.Next(65, 90));
            Node<string> tail = head;
            for (int i = 1; i < n; i++)
            {
                tail.SetNext(new Node<string>("" + (char)rnd.Next(65, 90)));
                tail = tail.GetNext();
            }
            return head;
        }
        public static Node<double> CreateRandomListDouble(int n)
        {
            Random rnd = new Random();
            Node<double> head = new Node<double>(rnd.Next() / 1000.0);
            Node<double> tail = head;
            for (int i = 1; i < n; i++)
            {
                tail.SetNext(new Node<double>(rnd.Next() / 1000.0));
                tail = tail.GetNext();
            }
            return head;
        }
        public static void PrintList<T>(Node<T> head)
        {
            while (head != null)
            {
                Console.Write(head + " ");
                head = head.GetNext();
            }
            Console.WriteLine();
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
        public static int Length<T>(Node<T> head)
        {
            int length = 0;
            while (head != null)
            {
                length++;
                head = head.GetNext();
            }
            return length;
        }
        public static Node<int> GetNode(Node<int> head, int n)
        {
            for (int i = 0; i < n; i++)
            {
                head = head.GetNext();
            }

            return head;
        }
        public static Node<T> GetNode<T>(Node<T> head, int n)
        {
            for (int i = 0; i < n; i++)
            {
                head = head.GetNext();
            }

            return head;
        }
        public static Node<int> Add(Node<int> head, Node<int> node)
        {
            node.SetNext(head);
            return node;

        }
        public static Node<T> Add<T>(Node<T> head, Node<T> node)
        {
            node.SetNext(head);
            return node;

        }
        public static Node<int> Add(Node<int> head, Node<int> node, int n)
        {
            Node<int> p = head;
            if (n == 0)
            {
                return Add(head, node);
            }
            for (int i = 0; i < n - 1; i++)
            {
                p = p.GetNext();
            }
            node.SetNext(p.GetNext());
            p.SetNext(node);
            return head;

        }
        public static Node<T> Add<T>(Node<T> head, Node<T> node, int n)
        {
            Node<T> p = head;
            if (n == 0)
            {
                return Add(head, node);
            }
            for (int i = 0; i < n - 1; i++)
            {
                p = p.GetNext();
            }
            node.SetNext(p.GetNext());
            p.SetNext(node);
            return head;

        }
        public static void AddLast(Node<int> head, Node<int> node)
        {
            while (head.HasNext())
            {
                head = head.GetNext();
            }
            head.SetNext(node);
        }
        public static void AddLast<T>(Node<T> head, Node<T> node)
        {
            while (head.HasNext())
            {
                head = head.GetNext();
            }
            head.SetNext(node);
        }
        public static Node<int> Pop(Node<int> head)
        {
            Node<int> newHead = head.GetNext();
            head.SetNext(null);
            return newHead;
        }
        public static Node<T> Pop<T>(Node<T> head)
        {
            Node<T> newHead = head.GetNext();
            head.SetNext(null);
            return newHead;
        }
        public static Node<int> Del(Node<int> head, int n)
        {
            head = new Node<int>(0, head);
            for (int i = 0; i < n; i++)
            {
                head = head.GetNext();
            }
            head.SetNext(head.GetNext().GetNext());
            return head.GetNext();
        }
        public static Node<T> Del<T>(Node<T> head, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                head = head.GetNext();
            }
            head.SetNext(head.GetNext().GetNext());
            return head;
        }
        public static int Sum(Node<int> head)
        {
            int sum = 0;
            while (head != null)
            {
                sum += head.GetValue();
                head = head.GetNext();
            }
            return sum;
        }
        public static Node<string> CopyList(Node<string> head)
        {
            Node<string> newHead = new Node<string>(head.GetValue());
            Node<string> tail = newHead;
            head = head.GetNext();
            while (head != null)
            {
                tail.SetNext(new Node<string>(head.GetValue()));
                head = head.GetNext();
                tail = tail.GetNext();
            }
            return newHead;
        }
        public static Node<string> CopyList2(Node<string> head)
        {
            Node<string> newHead = new Node<string>("");
            Node<string> tail = newHead;
            
            while (head != null)
            {
                tail.SetNext(new Node<string>(head.GetValue()));
                head = head.GetNext();
                tail = tail.GetNext();
            }
            return newHead.GetNext();
        }
        public static Node<T> CopyList<T>(Node<T> head)
        {
            Node<T> newHead = new Node<T>(head.GetValue());
            Node<T> tail = newHead;
            head = head.GetNext();
            while (head != null)
            {
                tail.SetNext(new Node<T>(head.GetValue()));
                head = head.GetNext();
                tail = tail.GetNext();
            }
            return newHead;
        }
        public static Node<double> Reverse(Node<double> head)
        {
            if (!head.HasNext())
                return head;
            Node<double> p1 = head.GetNext();
            Node<double> p2 = p1.GetNext();
            p1.SetNext(head);
            head.SetNext(null);

            while (p2 != null)
            {
                head = p1;
                p1 = p2;
                p2 = p1.GetNext();
                p1.SetNext(head);
            }
            return p1;
        }
        public static Node<T> Reverse<T>(Node<T> head)
        {
            if (!head.HasNext())
                return head;
            Node<T> p1 = head.GetNext();
            Node<T> p2 = p1.GetNext();
            p1.SetNext(head);
            head.SetNext(null);

            while (p2 != null)
            {
                head = p1;
                p1 = p2;
                p2 = p1.GetNext();
                p1.SetNext(head);
            }
            return p1;
        }
        public static Node<double> ReverseNew(Node<double> head)
        {
            Node<double> newHead = new Node<double>(head.GetValue());
            head = head.GetNext();
            while (head != null)
            {
                // Node<double> p = new Node<double>(head.GetValue(), newHead);
                // p.SetNext(newHead);
                // newHead = p;
                newHead = new Node<double>(head.GetValue(), newHead);
                head = head.GetNext();
            }
            return newHead;
        }
        public static Node<T> ReverseNew<T>(Node<T> head)
        {
            Node<T> newHead = new Node<T>(head.GetValue());
            head = head.GetNext();
            while (head != null)
            {
                // Node<double> p = new Node<double>(head.GetValue(), newHead);
                // p.SetNext(newHead);
                // newHead = p;
                newHead = new Node<T>(head.GetValue(), newHead);
                head = head.GetNext();
            }
            return newHead;
        }
        public static int Index(Node<int> head, int value)
        {
            int index = 0;
            while (head != null)
            {
                if (head.GetValue() == value)
                    return index;
                index++;
                head = head.GetNext();
            }
            return -1;
        }
        public static int Index<T>(Node<T> head, T value)
        {
            int index = 0;
            while (head != null)
            {
                if (head.GetValue().Equals(value))
                    return index;
                index++;
                head = head.GetNext();
            }
            return -1;
        }
        public static Node<string> Find(Node<string> head, string value)
        {
            while (head != null)
            {
                if (head.GetValue() == value)
                    return head;
                head = head.GetNext();
            }
            return null;
        }
        public static Node<T> Find<T>(Node<T> head, T value)
        {
            while (head != null)
            {
                if (head.GetValue().Equals(value))
                    return head;
                head = head.GetNext();
            }
            return null;
        }
        public static Node<char> Slice(Node<char> head, int start, int end)
        {                           // this methos changes the original list
            for (int i = 0; i < start; i++)
            {
                head = head.GetNext();
            }
            Node<char> p = head;
            for (int i = start; i < end; i++)
            {
                p = p.GetNext();
            }
            p.SetNext(null);
            return head;
        }
        public static Node<T> Slice<T>(Node<T> head, int start, int end)
        {                           // this methos changes the original list
            for (int i = 0; i < start; i++)
            {
                head = head.GetNext();
            }
            Node<T> p = head;
            for (int i = start; i < end; i++)
            {
                p = p.GetNext();
            }
            p.SetNext(null);
            return head;
        }
        public static bool Equal<T>(Node<T> l1, Node<T> l2)
        {
            while (l1 != null && l2 != null && l1.GetValue().Equals(l2.GetValue()))
            {
                l1 = l1.GetNext();
                l2 = l2.GetNext();
            }
            if (l1 == null && l2 == null)
            {
                return true;
            }
            return false;
        }
        public static Node<T> Union<T>(Node<T> l1, Node<T> l2)
        {
            Node<T> p = l1;
            while (p.HasNext())
            {
                p = p.GetNext();
            }
            p.SetNext(l2);
            return l1;
        }
        public static Node<T> Intersect<T>(Node<T> l1, Node<T> l2)
        {
            Node<T> newList = null;
            Node<T> l2_copy = l2;
            while (l1 != null)
            {
                while (l2 != null)
                {
                    if (l1.GetValue().Equals(l2.GetValue()))
                    {
                        newList = new Node<T>(l1.GetValue(), newList);
                        break;
                    }
                    l2 = l2.GetNext();
                }
                l1 = l1.GetNext();
                l2 = l2_copy;
            }
            return newList;
        }
        public static Node<T> Intersect_Unique<T>(Node<T> l1, Node<T> l2)
        {
            Node<T> newList = null;
            Node<T> l1_copy = l1;
            Node<T> l2_copy = l2;
            while (l1 != null)
            {
                while (l2 != null)
                {
                    if (l1.GetValue().Equals(l2.GetValue()))
                    {
                        newList = new Node<T>(l1.GetValue(), newList);
                        int index = Index(l1_copy, l1.GetValue());
                        l1_copy = Del(l1_copy, index);
                        index = Index(l2_copy, l2.GetValue());
                        l2_copy = Del(l2_copy, index);
                        break;
                    }
                    l2 = l2.GetNext();
                }
                l1 = l1.GetNext();
                l2 = l2_copy;
            }
            return newList;
        }
        public static void Unique<T>(Node<T> head)
        {
            Node<T> p;
            Node<T> pre = head;
            while (head.HasNext())
            {
                p = head.GetNext();
                while (p != null)
                {
                    if (p.GetValue().Equals(head.GetValue()))
                    {
                        pre.SetNext(p.GetNext());    // delete p from list
                        p = p.GetNext();
                    }
                    else
                    {
                        pre = pre.GetNext();
                        p = p.GetNext();
                    }
                }
                head = head.GetNext();
                pre = head;
            }
        }
        public static void Unique(Node<int> head)
        {
            Node<int> p;
            Node<int> pre = head;
            while (head.HasNext())
            {
                p = head.GetNext();
                while (p != null)
                {
                    if (p.GetValue() == head.GetValue())
                    {
                        pre.SetNext(p.GetNext());    // delete p from list
                        p = p.GetNext();
                    }
                    else
                    {
                        pre = pre.GetNext();
                        p = p.GetNext();
                    }
                }
                head = head.GetNext();
                pre = head;
            }
        }
        public static Node<T> Max<T>(Node<T> head) where T : IComparable<T>
        {
            Node<T> max = head;
            Node<T> p;
            while (head.HasNext())
            {
                p = head.GetNext();
                if (max.GetValue().CompareTo(p.GetValue()) < 0)
                {
                    max = p;
                }
                head = head.GetNext();
            }
            return max;
        }
        public static Node<int> Max(Node<int> head)
        {
            Node<int> max = head;
            Node<int> p;
            while (head.HasNext())
            {
                p = head.GetNext();
                if (max.GetValue() < p.GetValue())
                {
                    max = p;
                }
                head = head.GetNext();
            }
            return max;
        }
        public static Node<T> UnionSort<T>(Node<T> l1, Node<T> l2) where T : IComparable<T>
        {
            Node<T> newHead;
            if (l1.GetValue().CompareTo(l2.GetValue()) > 0)
            {
                newHead = l1;
                l1 = l1.GetNext();
            }
            else
            {
                newHead = l2;
                l2 = l2.GetNext();
            }
            Node<T> tail = newHead;
            while (l1 != null && l2 != null)
            {
                if (l1.GetValue().CompareTo(l2.GetValue()) > 0)
                {
                    tail.SetNext(l1);
                    l1 = l1.GetNext();
                    tail = tail.GetNext();
                }
                else
                {
                    tail.SetNext(l2);
                    l2 = l2.GetNext();
                    tail = tail.GetNext();
                }

            }
            if (l1 != null && l2 == null)
            {
                tail.SetNext(l1);
            }
            else if (l2 != null)
            {
                tail.SetNext(l2);
            }
            return newHead;
        }
        public static Node<double> UnionSort(Node<double> l1, Node<double> l2)
        {
            Node<double> newHead;
            if (l1.GetValue() > l2.GetValue())
            {
                newHead = l1;
                l1 = l1.GetNext();
            }
            else
            {
                newHead = l2;
                l2 = l2.GetNext();
            }
            Node<double> tail = newHead;
            while (l1 != null && l2 != null)
            {
                if (l1.GetValue() > l2.GetValue())
                {
                    tail.SetNext(l1);
                    l1 = l1.GetNext();
                    tail = tail.GetNext();
                }
                else
                {
                    tail.SetNext(l2);
                    l2 = l2.GetNext();
                    tail = tail.GetNext();
                }

            }
            if (l1 != null && l2 == null)
            {
                tail.SetNext(l1);
            }
            else if (l2 != null)
            {
                tail.SetNext(l2);
            }
            return newHead;
        }
        public static int commonValue(Node<int> head)
        {
            int[] arr = new int[101];
            while (head != null)
            {
                arr[head.GetValue()]++;
                head = head.GetNext();
            }
            int max = arr[0];
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                    index = i;
                }
            }
            return index;
        }
        public static bool Consistent<T>(Node<T> head) where T : IComparable<T>
        {
            Node<T> p1 = head;
            Node<T> p2 = head.GetNext();
            int compare1 = p1.GetValue().CompareTo(p2.GetValue());
            if (compare1 == 0)
                return false;
            while (p2.HasNext())
            {
                p2 = p2.GetNext();
                p1 = p1.GetNext();
                int compare2 = p1.GetValue().CompareTo(p2.GetValue());
                if (compare1 * compare2 <= 0)
                    return false;
            }
            return true;
        }
        public static bool Consistent(Node<int> head)
        {
            Node<int> p1 = head;
            Node<int> p2 = head.GetNext();
            int compare1 = p1.GetValue().CompareTo(p2.GetValue());
            if (compare1 == 0)
                return false;
            while (p2.HasNext())
            {
                p2 = p2.GetNext();
                p1 = p1.GetNext();
                int compare2 = p1.GetValue().CompareTo(p2.GetValue());
                if (compare1 * compare2 <= 0)
                    return false;
            }
            return true;
        }
        public static Node<T> Zipper<T>(Node<T> l1, Node<T> l2)
        {
            Node<T> head = l1;
            Node<T> tail = l1;
            l1 = l1.GetNext();
            while (l1 != null && l2 != null)
            {
                tail.SetNext(l2);
                tail = l2;
                tail.SetNext(l1);
                tail = l1;
                l2 = l2.GetNext();
                l1 = l1.GetNext();
            }
            if (l1 != null)
                tail.SetNext(l1);
            else if (l2 != null)
                tail.SetNext(l2);
            return head;
        }
        public static Node<int> SumOfsubList(Node<int> L)
        {
            Node<int> head = new Node<int>(L.GetValue());
            Node<int> tail = head;
            int pre = L.GetValue() - 1;
            L = L.GetNext();
            while (L != null)
            {
                if (L.GetValue() > pre)
                {
                    tail.SetValue(tail.GetValue() + L.GetValue());
                }
                else
                {
                    tail.SetNext(new Node<int>(L.GetValue()));
                    tail = tail.GetNext();
                }
                pre = L.GetValue();
                L = L.GetNext();
            }

            return head;
        }
        public static bool isTripleList(Node<int> L)
        {
            // A
            if (L == null) // A
                return false;
            // B
            int count = 0;
            Node<int> p1 = L;
            while (p1 != null)
            {
                count++;
                p1 = p1.GetNext();
            }
            if (count % 3 != 0)
                return false;
            // C
            p1 = L;
            Node<int> p2 = L;
            for (int i = 0; i < count / 3; i++)
            {
                p1 = p1.GetNext();
                p2 = p2.GetNext(); // p2 = p2.GetNext().GetNext();
                p2 = p2.GetNext(); 
            }
            for (int i = 0; i < count / 3; i++)
            {
                if (L.GetValue() == p1.GetValue() && L.GetValue() == p2.GetValue())
                {
                    L = L.GetNext();
                    p1 = p1.GetNext();
                    p2 = p2.GetNext();
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public static void addSort(Node<int> L, int n)
        {
            Node<int> node = new Node<int>(n);
            if (L.GetValue() > n)  // add node after L and swap values
            {
                node.SetNext(L.GetNext());
                L.SetNext(node);
                node.SetValue(L.GetValue());
                L.SetValue(n);
                return;
            }
            Node<int> pre = L;
            L = L.GetNext();
            while (L != null)
            {
                if (n > L.GetValue())
                {
                    pre = L;
                    L = L.GetNext();
                }
                else
                {
                    pre.SetNext(node);
                    node.SetNext(L);
                    return;
                }
            }
            pre.SetNext(node); // add node at last
        }
        public static Node<int> sortList(Node<int> L)
        {
            Node<int> head = new Node<int>(L.GetValue());
            L = L.GetNext();
            while (L != null)
            {
                addSort(L, L.GetValue());
            }
            return head;
        }
        public static Node<RangeNode> CreateRangeList(Node<int> sourceList)
        {
            Node<int> p1 = sourceList;
            Node<int> p2 = sourceList;
            Node<RangeNode> rHead;
            Node<RangeNode> rTail;

            // make first Node
            while (p2.HasNext() && p2.GetValue() + 1 == p2.GetNext().GetValue())
            {
                p2 = p2.GetNext();
            }
            RangeNode rn = new RangeNode(p1.GetValue(), p2.GetValue());
            rHead = new Node<RangeNode>(rn);
            rTail = rHead;

            p1 = p2.GetNext();
            p2 = p2.GetNext();

            while (p1 != null)
            {
                while (p2.HasNext() && p2.GetValue() + 1 == p2.GetNext().GetValue())
                {
                    p2 = p2.GetNext();
                }
                rn = new RangeNode(p1.GetValue(), p2.GetValue());
                rTail.SetNext(new Node<RangeNode>(rn));
                rTail = rTail.GetNext();
                p1 = p2.GetNext();
                p2 = p2.GetNext();
            }
            return rHead;
        }
        public static Node<RangeNode> CreateRangeList2(Node<int> sourceList)
        {
            Node<int> p1 = sourceList;
            Node<int> p2 = sourceList;
            RangeNode rn = new RangeNode(0, 0);
            Node<RangeNode> rHead = new Node<RangeNode>(rn);
            Node<RangeNode> rTail = rHead;

            while (p1 != null)
            {
                while (p2.HasNext() && p2.GetValue() + 1 == p2.GetNext().GetValue())
                {
                    p2 = p2.GetNext();
                }
                rn = new RangeNode(p1.GetValue(), p2.GetValue());
                rTail.SetNext(new Node<RangeNode>(rn));
                rTail = rTail.GetNext();
                p1 = p2.GetNext();
                p2 = p2.GetNext();
            }
            return rHead.GetNext();
        }
        public static Node<int> ReadFromTextFile(string fileName)
        {
            var directory = Directory.GetCurrentDirectory();
            string Pdirectory = Directory.GetParent(Directory.GetParent(directory).ToString()).ToString();
            var path = Path.Combine(Pdirectory, fileName);
            TextReader reader = File.OpenText(path);
            string line = reader.ReadLine();
            Node<int> head = new Node<int>(int.Parse(line));
            Node<int> tail = head;
            do
            {
                line = reader.ReadLine();
                if (!String.IsNullOrEmpty(line))
                {
                    tail.SetNext(new Node<int>(int.Parse(line)));
                    tail = tail.GetNext();
                }
            } while (line != null);
            return head;
        }
        public static Node<int> BuildDigit(Node<int> lst)
        {
            // make first number

            int num = lst.GetValue();
            Node<int> head = new Node<int>(lst.GetValue() % 10);
            Node<int> tail = head;
            num = num / 10;
            while (num > 0)
            {
                tail.SetNext(new Node<int>(num % 10));
                num = num / 10;
                tail = tail.GetNext();

            }
            tail.SetNext(new Node<int>(-9));
            tail = tail.GetNext();
            lst = lst.GetNext();
            while (lst != null)
            {
                num = lst.GetValue();
                while (num > 0)
                {
                    tail.SetNext(new Node<int>(num % 10));
                    num = num / 10;
                    tail = tail.GetNext();

                }
                lst = lst.GetNext();
                tail.SetNext(new Node<int>(-9));
                tail = tail.GetNext();
            }
            return head;
        }
        public static Node<int> BuildDigit2(Node<int> lst)
        {
            Node<int> head = new Node<int>(-1); // will be deleted at end
            Node<int> tail = head;
            while (lst != null)
            {
                int num = lst.GetValue();
                while (num > 0)
                {
                    tail.SetNext(new Node<int>(num % 10));
                    num = num / 10;
                    tail = tail.GetNext();
                }
                lst = lst.GetNext();
                Node<int> temp = new Node<int>(-9);
                tail.SetNext(new Node<int>(-9));
                tail = tail.GetNext();
            }
            return head.GetNext(); // return without first node
        }
        public static int maxSortedSubList (Node<int> lst)
        {
            int max = 1;
            int count = 1;
            int num = lst.GetValue();
            while (lst.HasNext())
            {
                lst = lst.GetNext();
                if (lst.GetValue() > num)
                {
                    count++;
                    if (count > max)
                        max = count;
                } else
                {
                    if (count > max)
                        max = count;
                    count = 1;
                }
                num = lst.GetValue();
            }
            return max;
        }
        public static Node<double> Positive (Node<double> lst)
        {
            Node<double> lst2 = lst;
            Node<double> head = new Node<double>(0);
            Node<double> tail = head;

            while (lst2 != null)
            {
                if (lst2.GetValue() > 0)
                {
                    Node<double> temp = new Node<double>(lst2.GetValue());
                    tail.SetNext(temp);
                    tail = tail.GetNext();  // tail = temp
                }
                lst2 = lst2.GetNext();
            }
            head = head.GetNext(); // if (head.hasNext())
            PrintList(head);
            PrintList(lst);
            return head;
        }
        public static void RecursionPrint <T>(Node<T> lst)
        {
            if (lst == null)
                return;
            RecursionPrint(lst.GetNext());
            Console.Write(lst + " ");
        }
        public static int RecursionLength (Node<int> lst)
        {
            if (lst == null)
                return 0;
            return RecursionLength(lst.GetNext()) + 1;

        }
        public static int RecursionLength2(Node<int> lst, int length)
        {
            if (lst == null)
                return length;
            return RecursionLength2(lst.GetNext(), length + 1);

        }
        public static int RecursionCount (Node<int> lst, int value)
        {
            if (lst == null)
                return 0;
            if (lst.GetValue() == value)
                return RecursionCount(lst.GetNext(), value) + 1;
            else
                return RecursionCount(lst.GetNext(), value) + 0;
        }
        public static int RecursionMax (Node<int> lst)
        {
            if (lst == null)
                return -1;
            return Math.Max(lst.GetValue(), RecursionMax(lst.GetNext()));
        }
        public static Node<int> RecursionCopy(Node<int> lst)
        {
            if (!lst.HasNext())
                return new Node<int>(lst.GetValue());

            Node<int> temp = RecursionCopy(lst.GetNext());
            return new Node<int>(lst.GetValue(), temp);
        }
        public static Node<int> RecursionReverse(Node<int> lst, Node<int> newLst)
        {
            if (lst == null)
                return newLst;

            return RecursionReverse(lst.GetNext(), new Node<int> (lst.GetValue(), newLst));
        }
    }

    public class poo
    {
        public string ToString ()
        {
            return "";
        }
    }

}
