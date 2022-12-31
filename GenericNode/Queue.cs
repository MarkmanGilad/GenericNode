using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericNode
{
    public class Queue <T>
    {
        private Node<T> first;
        private Node<T> last;
        public Queue()
        {
            first = null;
            last = null;
        }
        public bool isEmpty ()
        {
            return this.first == null;
        }
        public T Head()
        {
            return this.first.GetValue();
        }
        public void Insert (T value) // מוסיף איבר לסוף התור
        {
            if (this.last != null)
            {
                this.last.SetNext(new Node<T>(value)) ;
                this.last = this.last.GetNext();
            }
            else
            {
                this.last = new Node<T>(value);
                this.first = this.last;
            }
        }
        public T Remove () // מוציא ומחזיר את האיבר הראשון בתור
        {
            T value = this.first.GetValue();
            this.first = this.first.GetNext();

            if (this.first == null)
            {
                this.last = null;
            }
            return value;
        }
        public override string ToString()
        {
            Node<T> temp = this.first;
            string str = "[ ";
            while (temp != null)
            {
                str += temp;
                temp = temp.GetNext();
                if (temp != null)
                    str += ", ";
            }
            str += " ]";
            return str;
        }
    }
}
