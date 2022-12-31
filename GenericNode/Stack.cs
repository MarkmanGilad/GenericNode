using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericNode
{
    public class Stack <T>
    {
        private Node<T> Head;
        public Stack() 
        { 
            this.Head = null; 
        }
        public void Push (T value)
        {
            Node<T> node = new Node<T>(value, Head);
            Head = node;
        }
        public T Pop ()
        {
            T value = Head.GetValue();
            Head = Head.GetNext();
            return value;
        }
        public T Top ()
        {
            return Head.GetValue();
        }
        public bool isEmpty () 
        { 
            return Head == null; 
        }
        public override string ToString()
        {
            Node<T> temp = Head;
            string str = "[ ";
            while (temp != null)
            {
                str += temp + ",";
                temp = temp.GetNext();
            }
            str = str.Substring(0, str.Length - 1) + " ]";
            return str;
        }
    }
}
