using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace QueueStackPrep
{
    internal class Program
    {
        public static Stack<Student> BestStudents (Queue<Student> students)
        {
            Stack<Student> st = new Stack<Student>();
            int max = students.Head().GetGrade();

            while (!students.IsEmpty())
            {
                Student student = students.Remove();
                if (max == student.GetGrade())
                {
                    st.Push(student);
                } else if (max < student.GetGrade())
                {
                    st = new Stack<Student>();
                    st.Push(student);
                    max = student.GetGrade();
                }
            }
            return st;

        }
        /***************************** שאלה 13 *************************/
        
        /*סיבוכיות זמן  
        * מספר התורים - n
        * ההפרש הגדול ביותר בין המספרים בכל תור - k
        * O(n*k)
        */
        public static Stack<Queue<int>> StackOfQueue (Stack<Queue<int>> SQ)
        {
            Stack<Queue<int>> SL = new Stack<Queue<int>>();
            while (!SQ.IsEmpty())
            {
                Queue<int> Q = SQ.Pop();
                Queue<int> newQ = new Queue<int>();
                int num = Q.Remove();
                while (!Q.IsEmpty())
                {
                    if (num == Q.Head())
                    {
                        Q.Remove();
                    } 
                    else if (num + 1 == Q.Head())
                    {
                        num++;
                        Q.Remove();
                    }
                    else if (num + 1 < Q.Head())  // else
                    {
                        num++;
                        newQ.Insert(num);
                    }
                    
                }
                SL.Push(newQ);
            }
            return SL;

        }

        public static Queue<Node<int>> QueueOfQueue(Queue<Queue<int>> QQ)
        {
            Queue<Node<int>> QL = new Queue<Node<int>>();
            while (!QQ.IsEmpty())
            {
                Queue<int> Q = QQ.Remove();
                Node<int> head = new Node<int>(0); // פיקטיבי
                Node<int> tail = head;
                int num = Q.Remove();
                while (!Q.IsEmpty())
                {
                    for (int i= num+1; i < Q.Head(); i++ )
                    {
                        tail.SetNext(new Node<int>(i));
                        tail = tail.GetNext();
                    }
                    num = Q.Remove();
                }
                QL.Insert(head.GetNext());
            }
            return QL;

        }

        /**************** בגרות 2021 ***********************/

        public static int Size (Queue<int>q)
        {
            Queue<int> temp = new Queue<int> ();
            int size = 0;
            while (!q.IsEmpty())
            {
                size++;
                temp.Insert(q.Remove());
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
            return size;
        }

        public static int Size1(Queue<int> q)
        {
            Queue<int> temp = Copy(q);
            int size = 0;
            while (!temp.IsEmpty())
            {
                size++;
            }
            return size;
        }

        public static bool IsIdentical (Queue<int> q1, Queue<int> q2)
        {
            bool identical = true;
            int size = Size(q1);
            if (size != Size(q2))
                return false;

            for (int i = 0; i < size; i++)
            {
                if (q1.Head() != q2.Head())
                    identical = false;
                q1.Insert(q1.Remove());
                q2.Insert(q2.Remove());

            }
            return identical;
        }

        public static bool IsIdentical1(Queue<int> q1, Queue<int> q2)
        {
            Queue<int> temp1 = Copy(q1);
            Queue<int> temp2 = Copy(q2);

            int size1 = Size(temp1);
            int size2 = Size(temp2);
            if (size1 != size2)
                return false;
            while (!temp1.IsEmpty())
            {
                if (temp1.Head() != temp2.Head())
                    return false;
                temp1.Remove();
                temp2.Remove();
            }
            return true;
        }

        public static bool IsSimilar (Queue<int> q1, Queue<int> q2)
        {
            //bool similar = false;
            int size = Size (q1);
            if (size != Size(q2))
                return false;
            
            for (int i=0; i < size; i++)
            {
                if (IsIdentical(q1, q2)) 
                    return true;
                q1.Insert (q1.Remove());
            }
            return false;
        } 

        /********************** בגרות 2019 ********************/
        public static int ToNumber (Queue<int> q)
        {
            int num = 0, mul = 1;
            
            while (!q.IsEmpty())
            {
                num = mul * q.Remove();
                mul = mul * 10;
            } 
            return num;
        }

        public static int BigNumber (Node<Queue<int>> lst)
        {
            int max = 0;
            while (lst != null)
            {
                int num = ToNumber(lst.GetValue());
                if (max < ToNumber(lst.GetValue())) {
                    max = num;
                }
                lst.GetNext();
            }
            
            return max;
        }

        /********************** בגרות 2006 ********************/
        /* סיבוכיות
         * המקרה הגרוע ביותר שכל המספרים שונים.
         * לכל מספר נעבור שוב על התור ונספור את מספר המופעים שלו.
         * O(N^2)
         */
        public static Queue<int> CommonQueue (Queue<int> q)
        {
            Queue<int> temp = Copy(q);
            Queue<int> CQ = new Queue<int>();
            while (!temp.IsEmpty())
            {
                CQ.Insert(temp.Head());
                CQ.Insert(CountRemove(temp, temp.Head()));
            }
            return CQ;
        }

        public static int CountRemove (Queue<int> q, int num)
        // סופרת את מספר הפעמים שמופיע בתור 
        // ומוחק את כל המופעים
        {
            int count = 0;
            Queue<int> temp = new Queue<int>();
            while (!q.IsEmpty())
            {
                if (num == q.Head())
                {
                    count++;
                    q.Remove();
                }
                else
                {
                    temp.Insert(q.Remove());
                }
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
            
            return count;
        }

        public static Queue<T> Copy <T> (Queue<T> q)
        {
            return q; // לא ממומש - פעולה פיקטיבית
        }

        /********************** בגרות 2008 ********************/
        public static void flipDirection (Stack<int> st)
        {
            string dir;
            Stack<int> temp = new Stack<int>();
            int n1 = st.Pop();
            temp.Push(n1);
            int n2 = st.Pop();
            temp.Push(n1);
            if (n1 > n2)
                dir = "down";
            else
                dir = "up";
            while (!st.IsEmpty())
            {
                int n = st.Pop();
                if (n > temp.Top() && dir=="up") {
                    temp.Push(n);
                } 
                else if (n > temp.Top() && dir == "down")
                {
                    temp.Push(temp.Top());
                    temp.Push(n);
                    dir = "up";
                } 
                else if (n < temp.Top() && dir == "up" )
                {
                    temp.Push(temp.Top());
                    temp.Push(n);
                    dir = "down";
                }
                else // n < temp.Top() && dir == "Down"
                {
                    temp.Push(n);
                }
            }

            while (!temp.IsEmpty())
                st.Push(temp.Pop());
        }


        /********************** בגרות 2020ב ********************/
        public static Stack<int> Block (Stack<int> stk)
        {
            Stack<int> newStk = new Stack<int>();
            int count = 1;
            int num = stk.Pop();
            while (!stk.IsEmpty())
            {
                if(num != stk.Top() && count == 1)
                {
                    newStk.Push(num);
                    num = stk.Pop();
                }
                else if (num != stk.Top() && count > 1)
                {
                    num = stk.Pop();
                    count = 1;
                }
                else // if (num == stk.Top())
                {
                    count++;
                    stk.Pop();
                }
            }

            return newStk;
        }
        public static Queue<int> Block1(Queue<int> q)
        {
            Queue<int> newQ = new Queue<int>();
            int count = 1;
            int num = q.Remove(); 
            while (!q.IsEmpty())
            {
                if (num == q.Head())
                {
                    count++;
                }    
                else
                {
                    if (count == 1)
                    {
                        newQ.Insert(num);
                    }
                    count = 1;
                }
                num = q.Remove();
            }
            if (count == 1)
            {
                newQ.Insert(num);
            }
            return newQ;
        }


        /********************** בגרות 2020א ********************/
        public static bool isExists (int num, Stack<int> st)
        {
            Stack<int> temp = new Stack<int>();
            bool exists = false;
            while (!st.IsEmpty())
            {
                temp.Push(st.Pop());
                if (temp.Top() % 10 == num)
                {
                    exists = true;
                }
            }
            while (!temp.IsEmpty())
                st.Push(temp.Pop());
            return exists;
        }

        public static bool AllExists (Stack<int> stk)
        {
            Stack<int> temp = Clone(stk);
            bool exists = true;
            while (!temp.IsEmpty())
            {
                int num = temp.Pop();
                exists = exists && isExists(num, stk);
            }
            return exists;
        }

        public static int LeftDigit (int num)
        {
            string str = num.ToString ();
            string digit = "" + str[0];
            return int.Parse(digit);
        }

        public static Stack<T> Clone <T> (Stack<T> st)
        {
            return st; // פיקטיבי - לא מומש
        }
        
        public static bool Sequance (Queue<int> q, int n)
        {
            Queue<int> temp = Copy(q);
            int[] arr = new int[n+1];
            while(!temp.IsEmpty())
            {
                int num = temp.Remove();
                if (num <=n)
                {
                    arr[num]++;
                }
            }
            for (int i=0; i < n+1; i++)
            {
                if (arr[i] != i)
                {
                    return false;
                }
            }
            return true;

        }

        /********************** main ********************/

        

        static void Main(string[] args)
        {
            Queue<Queue<int>> qq = new Queue<Queue<int>>();
            Queue<Node<int>> qn = new Queue<Node<int>>();
            Queue<int[]> qa= new Queue<int[]>();
            Queue<int>[] aq = new Queue<int>[5];

            aq[3].Insert(5);
            Console.WriteLine(aq[3].Head());

        }

    }

    public class Student
    {
        private int Grade;
        private string Name;

        public Student(int grade, string name)
        {
            this.Grade = grade;
            this.Name = name;
        }
        public Student()
        {
            this.Grade = 0;
            this.Name = "";
        }
        public int GetGrade()
        {
            return Grade;
        }
        public void SetGrade(int grade)
        {
            Grade = grade;
        }
        public string GetName()
        {
            return Name;
        }
        public void SetName (string name)
        {
            Name = name;
        }
    }
}
