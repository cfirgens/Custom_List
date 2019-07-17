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

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < count)
                {
                    return items[index];
                }

                throw new ArgumentOutOfRangeException();
            }

            set
            {
                if (index >= 0 && index < count)
                {
                    items[index] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }



        public CustomList()
        {
            items = new T[capacity];
            count = 0;
            capacity = 4;
            
        }
    }
}
