using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericNode;

namespace Stack
{
    public class Program
    {
        static void Main(string[] args)
        {

            //Stack<int> s1 = CreateStack<int>(new int[] { 34, 7, 40, 6, 20, 3, 15, 30 });
            //Console.WriteLine(s1);

            //Stack<int> s2 = Copy(s1);
            //Console.WriteLine(s2);

            //RecursivePrint2(s1);
            //Console.WriteLine(s1);
            //Console.WriteLine("*************");
            ////Console.WriteLine(RecursiveSum1(s2));
            ////Console.WriteLine(s2);
            //Console.WriteLine(RecursiveSum2(s1));
            //Console.WriteLine(s1);
            //Console.WriteLine(LessThen1(s1, 40));
            //Console.WriteLine(s1);
            //Console.WriteLine(LessThen2(s2, 5));
            //Console.WriteLine(s2);
            //Console.WriteLine(Sort(s2));

            Stack<int> s3 = CreateStack<int>(new int[] { 3, 15, 34, 30, 7, 40, 6, 20, 8 });
            Stack<int> s4 = CreateStack<int>(new int[] { 34, 7, 40, 3, 15, 30, 8, 20 , 6});
            //s3 = Sort(s3);
            //Console.WriteLine(s3);
            //Console.WriteLine(s4);
            //Console.WriteLine("isSimilar " + isSimilar(s3, s4));
            Console.WriteLine(s3);
            Console.WriteLine(s4);
            Console.WriteLine("isSimilar2 " + isSimilar2(s3, s4));
            Console.WriteLine(s3);
            Console.WriteLine(s4);
            //Console.WriteLine(isSort(s3));

            //Console.WriteLine(isLegalBrackets("[25+(33 / {4 + 5} ) * (35 + 5)]"));
            //Console.WriteLine(isLegalBrackets("[({})()]"));
            //int[] arr = { 5, 3, 4, 5, 1, 5, 6 };
            //Array.Reverse(arr);
            //Stack<int> s5 = CreateStack<int>(arr);
            //Console.WriteLine(LongestSequence(s5));
            //Console.WriteLine(s1);
            //Console.WriteLine(PopMax(s1));
            //Console.WriteLine(s1);
            //Console.WriteLine(Sort2(s1));
        }

        public static Stack<T> CreateStack<T>(T[] arr)
        {
            Stack<T> stack = new Stack<T>();
            for (int i = 0; i < arr.Length; i++)
            {
                stack.Push(arr[i]);
            }
            return stack;
        }
        public static Stack<T> Copy<T>(Stack<T> st)
        {
            Stack<T> Newstack = new Stack<T>();
            Stack<T> temp = new Stack<T>();
            while (!st.isEmpty())
            {
                temp.Push(st.Pop());
            }
            while (!temp.isEmpty())
            {
                T value = temp.Pop();
                Newstack.Push(value);
                st.Push(value);
            }
            return Newstack;
        }
        public static void SpilledOn<T>(Stack<T> st1, Stack<T> st2)
        {
            while (!st2.isEmpty())
            {
                st1.Push(st2.Pop());
            }
        }
        public static int Min(Stack<int> st)
        {
            int min = st.Top();
            Stack<int> temp = new Stack<int>();
            while (!st.isEmpty())
            {
                int value = st.Pop();
                min = Math.Min(min, value);
                temp.Push(value);
            }
            SpilledOn<int>(st, temp);
            return min;
        }
        public static int Count(Stack<int> st, int value)
        {
            int count = 0;
            Stack<int> temp = new Stack<int>();
            while (!st.isEmpty())
            {
                if (st.Top() == value)
                {
                    count++;

                }
                temp.Push(st.Pop());
            }
            SpilledOn<int>(st, temp);
            return count;

        }
        public static void Circle<T>(Stack<T> st)
        {
            Stack<T> temp = new Stack<T>();
            T topValue = st.Pop();
            while (!st.isEmpty())
            {
                temp.Push(st.Pop());
            }
            st.Push(topValue);
            SpilledOn(st, temp);
        }
        public static bool isSortUp (Stack<int> st)
        {
            Stack<int> temp = new Stack<int>();
            temp.Push(st.Pop());
            while (!st.isEmpty())
            {
                if (temp.Top() >= st.Top())
                    return false;
                temp.Push(st.Pop());
            }
            SpilledOn (st, temp);
            return true;
        }
        public static bool isSortDown(Stack<int> st)
        {
            Stack<int> temp = new Stack<int>();
            temp.Push(st.Pop());
            while (!st.isEmpty())
            {
                if (temp.Top() >= st.Top())
                    return false;
                temp.Push(st.Pop());
            }
            SpilledOn(st, temp);
            return true;
        }
        public static bool isSort(Stack<int> st)
        {
            return isSortUp (st) || isSortDown (st);
        }
        public static bool isEqual(Stack<int> st1, Stack<int> st2)
        {
            Stack<int> st1_copy = new Stack<int>();
            Stack<int> st2_copy = new Stack<int>();
            while (!st1.isEmpty() || !st2.isEmpty())
            {
                st1_copy.Push(st1.Pop());
                st2_copy.Push(st2.Pop());
                if (st1_copy.Top() != st2.Top())
                {
                    SpilledOn(st1, st1_copy);
                    SpilledOn(st2, st2_copy);
                    return false;
                }
            }
            bool res = false;
            if (st1.isEmpty() && st2.isEmpty())
                res = true;
            SpilledOn(st1, st1_copy);
            SpilledOn(st2, st2_copy);
            return res;
        }
        public static Stack<int> Sort(Stack<int> st)
        {
            Stack<int> sorted = new Stack<int>();
            int max = st.Pop();
            while (!st.isEmpty())
            {
                Stack<int> temp = new Stack<int>();
                while (!st.isEmpty())
                {
                    int val = st.Pop();
                    if (val > max)
                    {
                        temp.Push(max);
                        max = val;
                    }
                    else
                    {
                        temp.Push(val);
                    }
                }
                sorted.Push(max);
                st = temp;
                max = st.Pop();
            }
            sorted.Push(max);
            return sorted;
        }
        public static int PopMax(Stack<int> st)
        {
            Stack<int> temp = new Stack<int>();
            int save = -1;
            while (!st.isEmpty())
            {
                int value = st.Pop();
                temp.Push(value);
                save = Math.Max(save, value);
            }
            while (!temp.isEmpty())
            {
                int value = temp.Pop();
                if (save != value)
                {
                    st.Push(value);
                }
            }
            return save;
        }
        public static Stack<int> Sort2(Stack<int> st)
        {
            Stack<int> temp = new Stack<int>();
            Stack<int> SortedStack = new Stack<int>();
            while (!st.isEmpty())
            {
                temp.Push(st.Pop());
            }
            while (!temp.isEmpty())
            {
                int max = PopMax(temp);
                SortedStack.Push(max);
            }
            return SortedStack;
        }

        public static bool isSimilar(Stack<int> st1, Stack<int> st2)
        {
            return isContains(st1, st2) && isContains(st2,st1);
        }
        public static bool isContains(Stack<int> st1, Stack<int> st2)
        {
            Stack<int> st1_copy = new Stack<int>();
            Stack<int> st2_copy = new Stack<int>();
            bool similar = true;
            
            while (!st1.isEmpty()) // && similar
            {
                similar = false;
                st1_copy.Push(st1.Pop());

                while (!st2.isEmpty()) // && !similar
                {
                    st2_copy.Push(st2.Pop());
                    if (st1_copy.Top() == st2_copy.Top())
                    {
                        similar = true;
                        break;
                    }
                }
                SpilledOn(st2, st2_copy);
                if (similar == false)
                    break;
            }

            // החזר את המחסניות למצב התחלתי
            SpilledOn(st1, st1_copy);
            return similar;
        }

        public static bool isInclude2 (Stack<int> st, int n) // פעולת עזר
        {
            Stack<int> temp = new Stack<int>();
            bool include = false;
            while (!st.isEmpty()) // !include
            {
                temp.Push(st.Pop());
                if (temp.Top() == n)
                {
                    include = true;
                    break;
                }
            }
            SpilledOn(st, temp);
            return include;
        }

        public static bool isContains2(Stack<int> st1, Stack<int> st2) // פעולת עזר
        {
            Stack<int> temp = new Stack<int>();
            bool contains = true;
            while (!st1.isEmpty() && contains) // contains
            {
                temp.Push(st1.Pop());
                if (!isInclude2(st2, temp.Top()))
                {
                    contains = false;
                    
                }
            }
            SpilledOn(st1, temp);
            return contains;
        }

        public static bool isSimilar2 (Stack<int> st1, Stack<int> st2)
        {
            return isContains2(st1, st2) && isContains2(st2, st1);
        }

        public static bool isLegalBrackets (string eq)
        {
            string brackets = "{}[]()";
            string openBrackets = "{[(";
            Stack <char> stack = new Stack<char>();
            for (int i = 0; i< eq.Length; i++)
            {
                if (brackets.Contains(eq[i]))
                {
                    if (openBrackets.Contains(eq[i]))
                        stack.Push(eq[i]);
                    else
                    {
                        if (stack.isEmpty())
                            return false;
                        if (eq[i] != ClosingBrackets(stack.Pop()))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public static char ClosingBrackets(char c)
        {
            switch (c) {
                case '{':
                    return '}';
                case '[':
                    return ']';
                case '(':
                    return ')';
                default:
                    return ' ';
            }
            
        }
        public static int LongestSequence (Stack<int> st)
        {
            Stack<int> temp = new Stack<int>();
            int max = 1;    // מניחים שהמחסנית אינה ריקה. אחרת נצטרך להוסיף בדיקה ולהחזיר 0
            int count = 0; // אורך רצף נוכחי

            temp.Push(st.Pop()); 
            while (!st.isEmpty())
            {
                if (temp.Top() + 1 == st.Top())
                {
                    count++;
                } 
                else
                {
                    count = 1;
                }
                max = Math.Max(max, count);
                temp.Push(st.Pop());
            }
            return max;
        }
        public static bool isPolyndrome (Stack<int> st)
        {
            Stack<int> temp = Copy(st);
            Stack<int> reverse = new Stack<int>();
            SpilledOn(reverse, temp);
            return isEqual(reverse, st);
        }

        public static bool isMatchDigit (Stack<int> st)
        {
            bool[] ones = new bool[10];
            bool[] tens = new bool[10];
            Stack<int> temp = new Stack<int>();
            while (!st.isEmpty())
            {
                int num = st.Pop();
                temp.Push(num);
                int one = num % 10;
                int ten = num / 10;
                ones[one] = true;
                tens[ten] = true;
            }
            SpilledOn(st, temp);
            for (int i=0; i < 10; i++)
            {
                if (ones[i] != tens[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static int SubSetLength(Stack<int> st, int num)
        {
            int count = 0;
            int length = 0;
            bool start = false;
            Stack<int> temp = new Stack<int> ();
            while (!st.isEmpty())
            {
                temp.Push(st.Pop());
                if (temp.Top() == num && !start)  // התחל ספירה
                {
                    start = true;
                    count++;
                } 
                else if (temp.Top() == -num && start) // סיום סדרה
                {
                    count++;
                    length = count; ;
                    
                } else if (start) // ספור
                {
                    count++;
                }

            }
            
            SpilledOn(st, temp);
            return length;
        }

        public static int LongestSubSet (Stack<int> st)
        {
            Stack<int> st2 = Copy(st);
            int max = 0;
            while (!st2.isEmpty())
            {
                int num = st2.Pop();
                max = Math.Max(max, SubSetLength(st, num));
            }
            return max;
        }

       


        /***************** Recursive Methods ***************************/
        public static void RecursivePrint1 <T> (Stack<T> st)
        {
            if (st.isEmpty())
                return;
            T value = st.Pop();
            RecursivePrint1(st);
            Console.WriteLine(value);
        }
        public static void RecursivePrint2<T>(Stack<T> st)
        {
            if (st.isEmpty())
                return;
            T value = st.Pop();
            RecursivePrint2(st);
            st.Push(value);
            Console.WriteLine(value);
        }
        public static int RecursiveSum1 (Stack<int> st)
        {
            if (st.isEmpty())
                return 0;
            return st.Pop() + RecursiveSum1(st);
        }
        public static int RecursiveSum2(Stack<int> st)
        {
            if (st.isEmpty())
                return 0;
            int value = st.Pop();
            int sum = RecursiveSum2(st);
            st.Push(value);
            return value + sum; 
        }
        public static bool LessThen1 (Stack<int> st, int value)
        {
            if (st.isEmpty())
                return true;
            return st.Pop() < value && LessThen1 (st, value);
        }
        public static bool LessThen2(Stack<int> st, int value)
        {
            if (st.isEmpty())
                return true;
            int v = st.Pop();
            bool result = LessThen2(st, value);
            st.Push(v);
            return v < value && result;
        }
    }

    public class TwoStack
    {
        Stack<int> numbers = new Stack<int>();
        Stack<int> sums = new Stack<int>();

        public Stack<int> GetNums (int x)
        {
            while (!numbers.isEmpty())
            {
                if (numbers.Top() == x)
                {
                    return Program.Copy(sums);
                }
                numbers.Pop();
                sums.Pop();
            }
            return numbers;
        }

        public void EraseNum (int x)
        {

        }
    }
}
