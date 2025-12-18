using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    public class RangeNode
    {
        public int from;
        public int to;

        public RangeNode(int from, int to)
        {
            this.from = from;
            this.to = to;
        }
        public override string ToString()
        {
            return $"({this.from},{this.to})";
        }
    }
}
