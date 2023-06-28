using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace QueueExam
{
    internal class MoedB
    {
        public static bool CheckOposite(Queue<int> q, int num)
        {
            bool found = false;
            while (!q.IsEmpty())
            {
                int value = q.Remove();
                if (num == value)
                {
                    if (!found)
                    {
                        found = true;
                        num *= -1;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static int CountOposite(Queue<int> q, int num)
        {
            bool found = false;
            int count = 0;
            while (!q.IsEmpty())
            {
                int value = q.Remove();
                if (found)
                {
                    if (num == value)
                    {
                        return count;
                    }
                    count++;
                }
                else if (num == value)
                {
                    found = true;
                    num *= -1;
                }
            }
            return -1;
        }

        public static Node<Item> CountQueue(Queue<int> q)
        {
            Item item = new Item(0); // פיקטיבי
            Node<Item> itemList = new Node<Item>(item);
            Node<Item> tail = itemList;
            while (!q.IsEmpty())
            {
                int num = q.Head();
                item = new Item(num);
                item.setAmountQueue(CountRemove(q, num));
                tail.SetNext(new Node<Item>(item));
                tail = tail.GetNext();
            }
            return itemList.GetNext();
        }

        public static int CountRemove(Queue<int> q, int num)
        {
            Queue<int> temp = new Queue<int>();
            int count = 0;

            while (!q.IsEmpty())
            {
                if (q.Head() == num)
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


    }
    public class Item
    {
        private int MyNumber;
        private int AmountInQueue;

        public Item(int num)
        {
            MyNumber = num;
        }
        public void setAmountQueue(int count_Queuenum)
        {
            AmountInQueue = count_Queuenum;
        }

    }
}
