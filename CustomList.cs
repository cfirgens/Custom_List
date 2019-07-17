using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T>
    {
        int count;
        int capacity;
        public int Count { get; }
        public int Capacity { get; }

        private T[] items;

        public CustomList()
        {
            items = new T[4];
            count = 0;
        }
    }
}
