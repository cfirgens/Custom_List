using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_List
{
    class Custom_List<T>
    {
        int count;
        int capacity;
        public int Count { get; }
        public int Capacity { get; }

        private T[] items;

        CustomList()
        {
            items = new T[4];
            count = 0;
        }
    }
}
