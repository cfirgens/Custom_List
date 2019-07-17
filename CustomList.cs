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
        
        public int Count
        {
            get
            {
                return count;
            }
        }
        public int Capacity
        {
            get
            {
                return capacity;
            }
        }

        private T[] items;

        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < count)
                {
                    return items[index];
                }

                throw new IndexOutOfRangeException();
            }

            set
            {
                if (index >= 0 && index < count)
                {
                    items[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public CustomList()
        {
            
            count = 0;
            capacity = 4;
            items = new T[capacity];

        }


        public void Add(T value)
        {
            int index;
            if (count == capacity)
            {
                IncreaseCapacity();
            }
            if (count == 0)
            {
                index = 0;
            }
            else
            {
                index = Count - 1;
            }

            items[index] = value;
            count++;
        }


        public void IncreaseCapacity()
        {
            T[] newItems = new T[capacity];
            capacity += capacity;
            for(int i = 0; i < count; i++)
            {
                newItems[i] = items[i];
            }

            items = newItems;

            
        }
    }
}
