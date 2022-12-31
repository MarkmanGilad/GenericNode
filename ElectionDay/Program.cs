using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericNode;
namespace ElectionDay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = @"C:\Users\Gilad\Downloads\Products.txt";
            Node<Product> head = Product.ReadFromTextFile(file);
            PrintList(head);
            
            Console.ReadLine();
        }

        public static void PrintList<T>(Node<T> head)
        {
            while (head != null)
            {
                Console.WriteLine(head + " ");
                head = head.GetNext();
                //Console.WriteLine();
            }
            
        }
        public static void Add (Node<Product> head, Product product)
        {
            Node<Product> node = new Node<Product>(product);
            while (head.HasNext())
            {
                head = head.GetNext();
            }
            head.SetNext(node);
        }
        public static Product FindByIndex (Node<Product> head, int index)
        {
            for(int i= 0; i < index; i++)
            {
                head = head.GetNext();
            }
            return head.GetValue();
            
        }
        public static Product FindById(Node<Product> head, int id)
        {
            while (head != null)
            {
                if (head.GetValue().GetProductId() == id)
                {
                    return head.GetValue();
                }
                head = head.GetNext();
            }
            return null;
        }
        public static int Index (Node<Product> head, string name)
        {
            int count = 0;
            
            while (head != null)
            {
                if (head.GetValue().GetName() == name)
                {
                    return count;
                }
                count++;
                head = head.GetNext();
            }
            return -1;
        }
        public static Product Max (Node<Product> head)
        {
            Product max = head.GetValue();

            while (head != null)
            {
                if (head.GetValue().GetPrice() > max.GetPrice())
                {
                    max = head.GetValue();
                }
                head = head.GetNext();
            }
            return max;
        }
        public static Product MaxProfit(Node<Product> head)
        {
            Product max = head.GetValue();

            while (head != null)
            {
                if (head.GetValue().GetPrice() - head.GetValue().GetCost() > max.GetPrice() - max.GetCost())
                {
                    max = head.GetValue();
                }
                head = head.GetNext();
            }
            return max;
        }
        public static void Dell (Node<Product> head, string name)
        {
            if (head.GetValue().GetName() == name)
            {
                head.SetValue(head.GetNext().GetValue());
                head.SetNext(head.GetNext().GetNext());
                return;
            }
            Node<Product> tmp = head;
            head = head.GetNext();
            while (head != null)
            {
                if (head.GetValue().GetName() == name)
                {
                    tmp.SetNext(head.GetNext());
                    return;
                }
                tmp = head;
                head = head.GetNext();
            }
        }
        public static void UpdatePrice (Node<Product> head, double change)
        {
            change = 1 + change;
            while (head != null)
            {
                head.GetValue().SetPrice(head.GetValue().GetPrice() * change);
                head = head.GetNext();
            }
        }
        public static Node<Product> RunningOut (Node<Product> head)
        {
            Node<Product> newList = new Node<Product>(new Product());
            Node<Product> tail = newList;

            while (head != null)
            {
                if (head.GetValue().GetQuantity() < 10)
                {
                    tail.SetNext(new Node<Product>(head.GetValue()));
                    tail = tail.GetNext();
                }
                head = head.GetNext();
            }
            return newList.GetNext();
        }
        public static void EmptyProducts (Node<Product> head)
        {
            Node<Product> oldHead = head;
            Node<Product> newHead = new Node<Product>(new Product(), head);
            Node<Product> pre = newHead;

            while (head != null)
            {
                if (head.GetValue().GetQuantity() == 0)
                {
                    pre.SetNext(head.GetNext());
                    
                }
                pre = head;
                head = head.GetNext();
            }
            newHead = newHead.GetNext();
            if (newHead != null)
            {
                oldHead.SetValue(newHead.GetValue());
                oldHead.SetNext(newHead.GetNext());
            } else
            {
                oldHead.SetValue(null);
                oldHead.SetNext(null);
            }
            
            
        }

    }
}
