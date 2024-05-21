using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Yuval_Moreno
{
    class Student
    {
        protected string name;
        public string address;
        private string city;
        protected static int numOfStudents=0;
        protected int EnglishGrade;
        
        public Student() {
            Console.WriteLine("Empty");
            numOfStudents++;
        }

        public Student(string name, string address, string city) 
        {
            this.name = name;
            this.address = address;
            this.city = city;
            Console.WriteLine("Full");
            numOfStudents++;

        }
        public Student(string name)
        {
            this.name = name;
            Console.WriteLine("Name");


        }

        public string GetCity() {return this.city;}

        public void SetCity(string city) {this.city = city;}
        public string GetNumOfStudents()
        {
            return numOfStudents + "";
        }
        public void add ()
        {
            numOfStudents++;
        }
        public void setName (string Name)
        {
            this.name = Name;
        }
        public void addBonus (int Bonus)
        {
            this.EnglishGrade += Bonus;
        }
        public string GetName ()
        {
            return this.name;
        }
    }

    class LawStudent : Student
    {
        private string degree="first";

        public LawStudent(string name,string degree) : base(name) 
        {
            Console.WriteLine("start");
            this.degree = degree;
            this.name=name + "bbbbbbb";
            Console.WriteLine("Law student");
        }

        public string getDegree() { return degree;}

        public void del ()
        {
            this.degree = "";
            this.name = "";
            this.address = "";
            this.SetCity("");

        }
    }
    
    class University
    {
        Student[] arr = new Student[100];
        Student HeadOfVaad = new Student();
    }
}
