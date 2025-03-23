using System;
using System.Data.SqlClient;

//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit4.CollectionsLib;

namespace ListTemplates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 9, 8 };
            LoopList(null);
            CreateList(arr);
            ChangeList(null, 5);
        }

        static int LoopList (Node<int> head)
        {
            int res = 0;
            while (head != null)
            {
                // Do something
                head = head.GetNext();
            }
            return res;
        }

        static Node<int> CreateList(int[] arr)
        {
            Node<int> head = new Node<int>(0);  // חוליה פיקטיבית
            Node<int> tail = head;
            for (int i = 0; i < arr.Length; i++)
            {
                Node<int> node = new Node<int>(arr[i]);
                tail.SetNext(node);
                tail = tail.GetNext();
            }
            return head.GetNext();
        }

        static Node<int> ChangeList(Node<int> lst, int value) // del
        {
            #region option
            //if (lst == null)
            //    return null;

            //if (!lst.HasNext()) 
            //{
            //    if (lst.GetValue() == value)
            //        return null;
            //    else
            //        return lst;
            //}
            #endregion

            lst = new Node<int>(0, lst); // הוספת חוליה פיקטיבית להתחלה

            while (lst.HasNext()) // lst.GetNext() == null
            {
                if (lst.GetNext().GetValue() == value)
                {
                    lst.SetNext(lst.GetNext().GetNext());
                    return lst.GetNext();
                }
            }
            return lst.GetNext();
        }
    }
}
