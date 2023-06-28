using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodesPrep
{
    public class Student
    {
        private string name;        // שם התלמיד
        private int studentClass;   // כיתה. 10 = יוד
        private double avgGrade;    // ממוצע ציונים

        public Student() {}
        public Student(string name, int studentClass, double avgGrade)
        {
            this.name = name;
            this.studentClass = studentClass;
            this.avgGrade = avgGrade;
        }

        public string GetName () { return name; }
        public int getStudentClass () {  return studentClass; }
        public double getAvgGrade () {  return avgGrade; }

        public void setName (string name) { this.name = name;}
        public void setStudentClass (int studentClass) {  this.studentClass = studentClass;}
        public void setAvgGrade (double avgGrade) { this.avgGrade = avgGrade; }
    }

}
