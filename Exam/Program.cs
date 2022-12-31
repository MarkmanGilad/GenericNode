using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericNode;

namespace Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<Cage> lst = ReadFromTextFile(@"C:\Users\Gilad\Markman Dropbox\Gilad Markman\הוראה\יסודות\GenericNode\Exam\TextFile1.txt");
            PrintList(lst);
            NewOrder(lst);
            PrintList(lst);
            Different(lst);
            PrintList(lst);
            /********************************************************************/

            Node<StudentGrades> lst2 = ReadFromTextFile2(@"C:\Users\Gilad\Markman Dropbox\Gilad Markman\הוראה\יסודות\GenericNode\Exam\TextFile2.txt");
            PrintList(lst2);
            Node<StudentGrades> lst3 = Excellent(lst2);
            PrintList(lst3);
            Node<SubjectGrade> lst4 = Average (lst2);
            PrintList(lst4);
        }

        public static  int Sum (Node<Cage> lst, string name)
        {
            int count = 0;  // מספר הכלובים
            int sum = 0;    // מספר החיות
            while (lst != null)
            {
                if (lst.GetValue().GetName() == name) // אם שם החיה תואם
                {
                    count++;
                    sum += lst.GetValue().GetNum();
                }
                lst = lst.GetNext();
            }
            Console.WriteLine($"number of {name} Cages: " + count);
            return sum;
        }

        public static void NewOrder (Node<Cage> lst)
        {
            Node<Cage> p = lst; // מצביע לסוף כל תת רשימה
            Node<Cage> p1 = lst; // מצביע הסורק את הרשימה. תמיד נמצא לפני החוליה הנבדקת

            while (p != null)
            {
                while (p1.GetNext() != null )
                {
                    if (p.GetValue().GetName() == p1.GetNext().GetValue().GetName())
                    {
                        if (p1 == p)     // אם חוליות צמודות מאותו סוג - מקדמים שני המצביעים
                        {
                            p = p.GetNext();                      
                            p1 = p1.GetNext();
                        } 
                        else
                        {
                            Node<Cage> temp = p1.GetNext();                 // שמירת החוליה להעברה
                            p1.SetNext(p1.GetNext().GetNext());             // ביטול החוליה

                            temp.SetNext(p.GetNext());                      // שירשור החוליה למקום החדש
                            p.SetNext(temp);
                            p = p.GetNext();                                // קידום המצביע לסוף תת הרשימה
                        }
                    }
                    else
                    {
                        p1 = p1.GetNext();
                    }
                }
                p = p.GetNext();    // קידום לתת רשימה חדש
                p1 = p;             //   
            }
        }

        public static void Different (Node<Cage> lst)
        {
            NewOrder (lst);     // מיון הרשימה לפי סוגי חיות
            int count = 1;      // מונה לסוגי הכלובים. אנו מניחים שיש לפחות כלוב אחד. אחרת נוסיף בדיקה אם הרשימה ריקה
            while (lst.HasNext())
            {
                if (lst.GetValue().GetName() != lst.GetNext().GetValue().GetName()) // בדיקה אם עברנו לתת רשימה חדש
                {
                    count++; 
                }
                lst = lst.GetNext();
            }
            lst.SetNext(new Node<Cage>(new Cage("Different", count)));  // יצירת חוליה חדשה ושירשור לסוף הרשימה
           
        }

        public static Node<Cage> ReadFromTextFile(string fileName)
        {
            TextReader reader = File.OpenText(fileName);
            Node<Cage> head = new Node<Cage>(new Cage("", -1));
            Node<Cage> tail = head;
            string line;
            do
            {
                line = reader.ReadLine();
                if (!String.IsNullOrEmpty(line))
                {
                    string[] attr = line.Split(',');
                    Cage cage = new Cage (attr[0], int.Parse(attr[1]));
                    tail.SetNext(new Node<Cage>(cage));
                    tail = tail.GetNext();
                }
            } while (line != null);
            return head.GetNext();
        }


        /********************************************************************/

        public static Node<StudentGrades> Excellent (Node<StudentGrades> lst)
        {
            Node<StudentGrades> head = new Node<StudentGrades>(new StudentGrades("", "", -1));  // יצירת שרשרת חדשה עם חוליה פיקטיבית
            Node<StudentGrades> tail = head;                                                    // יצירת מצביע לשרשור לסוף הרשימה החדשה

            StudentGrades maxStudent = lst.GetValue();    // משתנה לשמירת התלמיד המצטיין בכל קבוצה. מקבל תלמיד ראשון
            lst = lst.GetNext();                         // נתחיל מהתלמיד השני
            
            while (lst != null)
            {
                if (lst.GetValue().GetSubject() == maxStudent.GetSubject()) // אם אנחנו באותו מקצוע
                {
                    if (lst.GetValue().GetGrade() > maxStudent.GetGrade())  // נבדוק ונעדכן תלמיד מצטיין
                    {
                        maxStudent = lst.GetValue();
                    } 
                } 
                else        // עברנו למקצוע אחר
                {
                    tail.SetNext(new Node<StudentGrades>(maxStudent)); // נוסיף את התלמיד המצטיין לרשימה החדשה
                    tail = tail.GetNext();                             // נעביר מצביע לסוף הרשימה החדשה
                    maxStudent = lst.GetValue();                       // נאתחל מצטיין עם תלמיד מהרשימה החדשה.

                } 
                lst = lst.GetNext();                                    
            }
            tail.SetNext(new Node<StudentGrades>(maxStudent));  // נשרשר את החוליה האחרונה שלא שירשרנו בתוך הלולאה.
            return head.GetNext();                              // החזרת השרשרת ללא החוליה הפקיקטיבית
        }

        public static Node<SubjectGrade> Average (Node<StudentGrades> lst)
        {
            Node<SubjectGrade> head = new Node<SubjectGrade>(new SubjectGrade("", -1)); // ניצור רשימה חדשה עם חוליה פיקטיבית
            Node<SubjectGrade> tail = head;                                             // מצביע לסוף הרשימה החדשה לשירשור
            double sum = 0; // משתנה לסכום הציונים של כל מקצוע
            int count = 0;  // משתנה הסופר את מספר הציונים בכל מקצוע
            string subject = lst.GetValue().GetSubject(); // המקצוע הנוכחי
            
            while (lst!= null)
            {
                if (lst.GetValue().GetSubject() == subject) // אם אנחנו עדיין באותו מקצוע
                {
                    sum += lst.GetValue().GetGrade();       // נוסיף ציון נוכחי
                    count++;                                // נוסיף מספר תלמידים
                    lst = lst.GetNext();
                }
                else                                        // אם עברנו למקצוע אחר
                {
                    SubjectGrade Grade = new SubjectGrade(subject, sum / count);    // ניצור חוליה חדשה
                    tail.SetNext(new Node<SubjectGrade>(Grade));                    // נשרשר בסוף השרשרת החדשה
                    tail = tail.GetNext();
                    sum = 0;                        // נאפס צוברים
                    count = 0;
                    subject = lst.GetValue().GetSubject();  // שם המקצוע בתת השרשרת החדשה
                }
            }
            tail.SetNext(new Node<SubjectGrade>(new SubjectGrade(subject, sum / count)));   // נוסיף חוליה אחרונה שלא עודכנה כיוון שהגענו לסוף
            return head.GetNext();  // נחזיר ללא חוליה פקטיבית
        }

        public static Node<StudentGrades> ReadFromTextFile2(string fileName)
        {
            TextReader reader = File.OpenText(fileName);
            Node<StudentGrades> head = new Node<StudentGrades>(new StudentGrades("","", -1));
            Node<StudentGrades> tail = head;
            string line;
            do
            {
                line = reader.ReadLine();
                if (!String.IsNullOrEmpty(line))
                {
                    string[] attr = line.Split(',');
                    StudentGrades SG = new StudentGrades (attr[0], attr[1], int.Parse(attr[2]));
                    tail.SetNext(new Node<StudentGrades>(SG));
                    tail = tail.GetNext();
                }
            } while (line != null);
            return head.GetNext();
        }




        /********************************************************************/

        public static void PrintList<T>(Node<T> head)
        {
            while (head != null)
            {
                Console.WriteLine(head);
                head = head.GetNext();
            }
            Console.WriteLine("*****************************************************");
        }

    }
    public class Cage
    {
        private string Name;
        private int Num;

        public Cage (string name, int num)
        {
            Name = name;
            Num = num;
        }
        public string GetName () { return Name; }
        public int GetNum () { return Num; }
        public void SetNum (int num) { Num = num; } 
        public void SetName (string name) { Name = name; }

        public override string ToString()
        {
            return $"{Name} {Num}";
        }
    }

    public class StudentGrades
    {
        private string Name;
        private string Subject;
        int Grade;

        public StudentGrades (string name, string subject, int grade)
        {
            Name = name;
            Subject = subject;
            Grade = grade;
        }

        public string GetName() { return Name; }
        public string GetSubject() { return Subject; }
        public int GetGrade () { return Grade; }

        public override string ToString()
        {
            return $"{Name}, {Subject}, {Grade}";
        }
    }

    public class SubjectGrade
    {
        private string Subject;
        double Average;
        public SubjectGrade(string subject, double average)
        {
            Subject = subject;
            Average = average;
        }
        public override string ToString()
        {
            return $"{Subject}, {Average}";
        }
    }
}
