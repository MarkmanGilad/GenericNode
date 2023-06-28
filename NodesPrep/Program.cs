using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;
using Unit4.BinTreeCanvasLib;
using System.Data.SqlTypes;
using static System.Net.Mime.MediaTypeNames;
using System.Configuration;


namespace NodesPrep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
        
        public static double maxGrade( Node<Student> lst)
        {
            double max= 0;
            while (lst != null)
            {
                if (lst.GetValue().getAvgGrade() > max)
                {
                    max = lst.GetValue().getAvgGrade();
                }
                lst = lst.GetNext();
            }
            return max;
        }

        public Node<Student> [] sortByClass (Node<Student> lst)
        {
            Node<Student>[] classes = new Node<Student>[13];

            while (lst != null)
            {
                Node<Student> next =  lst.GetNext();
                int classNum = lst.GetValue().getStudentClass();
                lst.SetNext(classes[classNum]);
                classes[classNum] = lst;
                lst = next;
            }
            return classes;
        }

        public Queue<Student> Excellents (Node<Student> lst)
        {
            Queue<Student> excel = new Queue<Student>();
            while (lst != null && lst.HasNext())
            {
                if (lst.GetNext().GetValue().getAvgGrade() >= 95) 
                {
                    Student s = lst.GetNext().GetValue();
                    excel.Insert(s);
                    lst.SetNext(lst.GetNext().GetNext());    // מחק את החוליה
                }
                else
                {
                    lst = lst.GetNext();
                }
                
            }
            return excel;
        }

        public static Queue<Student> SortByClass (Node<Student> lst)
        {
            Queue<Student> sorted = new Queue<Student>();
            
            lst = new Node<Student>(new Student(), lst);  // הוספת חוליה פקטיבית
            
            for (int i = 1; i <=12; i++) // עבור כל כיתה
            {
                while (lst != null && lst.HasNext())
                {
                    Node<Student> next = lst.GetNext();
                    if (next.GetValue().getStudentClass() == i)
                    {
                        Student s = next.GetValue();
                        lst.SetNext(lst.GetNext().GetNext());   // מחק את החוליה
                        sorted.Insert(s);
                    }
                    lst = lst.GetNext();
                }
            }
            return sorted;
        } 

        public static bool VerticalSet (BinNode<int> tree)
        {

            if (tree == null)           // מיותר
                return true;

            bool LSet = true, RSet = true;
            if (tree.HasLeft())
            {
                LSet = VerticalSet(tree.GetLeft());
                LSet = LSet && tree.GetValue() < tree.GetLeft().GetValue();
            }
            if (tree.HasRight())
            {
                RSet = VerticalSet(tree.GetRight());
                RSet = RSet && tree.GetValue() < tree.GetRight().GetValue();
            }
            return LSet || RSet;
        }

        public static int HorizontalSet (BinNode<int> t)
        {
            Queue<BinNode<int>> queue = new Queue<BinNode<int>>();
            int level = -1;
            queue.Insert(t);
            int qSize = 1;
            int countSets = 0;
            while (!queue.IsEmpty())
            {
                level++;
                int level_size = qSize;
                bool isSet = true;
                int leftVal = t.GetValue()-1;
                for (int i = 0; i < level_size; i++)
                {
                    isSet = isSet && leftVal < t.GetValue();
                    t = queue.Remove(); qSize--;
                    if (t.HasLeft()) { queue.Insert(t.GetLeft()); qSize++; }
                    if (t.HasRight()) { queue.Insert(t.GetRight()); qSize++; }
                    leftVal = t.GetValue();
                }
                if (isSet) { countSets++; }
            }
            return countSets;
        }

        public static Node<int> Reverse(Node<int> head)
        {
            if (!head.HasNext())
                return head;
            Node<int> p1 = head.GetNext();
            Node<int> p2 = p1.GetNext();
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

        public static Node<int> Sum (Node<int> lst1, Node<int>lst2)
        {
            Node<int> sum = null;

            lst1 = Reverse(lst1);
            lst2 = Reverse(lst2);
            int remain = 0;
            while (lst1!=null && lst2 != null)
            {                
                int digit = lst1.GetValue() + lst2.GetValue() + remain;
                remain = digit /10 ;
                digit = digit % 10;
                sum = new Node<int>(digit, sum);
                lst1 = lst1.GetNext();
                lst2 = lst2.GetNext();

            }
            if (lst1 != null)
            {
                while (lst1 != null)
                {
                    int digit = lst1.GetValue() + remain;
                    int new_remain = digit / 10;
                    digit = digit % 10;
                    sum = new Node<int>(digit, sum);
                    remain = new_remain;
                    lst1 = lst1.GetNext();

                }
            } else
            {
                while (lst2 != null)
                {
                    int digit = lst2.GetValue() + remain;
                    int new_remain = digit / 10;
                    digit = digit % 10;
                    sum = new Node<int>(digit, sum);
                    remain = new_remain;
                    lst2 = lst2.GetNext();

                }
            }
            if (remain != 0)
            {
                sum = new Node<int>(remain, sum);
            }
            return sum;
        }
    }
}
