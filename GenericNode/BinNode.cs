using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericNode
{
    public class BinNode <T>
    {
        private BinNode<T> left;
        private T value;
        private BinNode<T> right;

        public BinNode (T value)
        {
            this.left = null;
            this.value = value;
            this.right = null;
        }
        public BinNode (BinNode<T> left, T value, BinNode<T> right)
        {
            this.left = left;
            this.value = value;
            this.right = right;
        }

        public T GetValue () { return this.value; }
        public BinNode<T> GetLeft () { return this.left; }  
        public BinNode<T> GetRight () { return this.right; }
        public bool HasLeft () { return this.left != null; }
        public bool hasRight () { return this.right != null; }
        public void SetValue (T value) { this.value = value; }
        public void SetLeft (BinNode<T> left) { this.left = left; }
        public void SetRight (BinNode<T> right) { this.right= right; }
        public override string ToString() {return this.value.ToString();}
    }
}
