using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericNode;

namespace Runner
{
    public class Runner
    {
        private string Country;
        private string Name;
        private int Time;

        public Runner(string country, string name, int time)
        {
            Country = country;
            Name = name;
            Time = time;
        }
        public Runner (){}
        
        public string GetCountry () { return Country; }
        public string GetName () { return Name; }
        public int GetTime () { return Time; }
       
        public override string ToString()
        {
            return $"Country: {this.Country} Name: {this.Name} Time: {this.Time} ";
        }

        public static Node<Runner> ReadFromTextFile(string fileName)
        {
            TextReader reader = File.OpenText(fileName);
            Node<Runner> head = new Node<Runner>(new Runner());
            Node<Runner> tail = head;
            string line;
            do
            {
                line = reader.ReadLine();
                if (!String.IsNullOrEmpty(line))
                {
                    string[] attr = line.Split(',');
                    Runner runner = new Runner(attr[0], attr[1], int.Parse(attr[2]));
                    tail.SetNext(new Node<Runner>(runner));
                    tail = tail.GetNext();
                }
            } while (line != null);
            return head.GetNext();
        }

    }
}
