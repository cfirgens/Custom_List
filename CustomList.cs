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
            if (count == (capacity -1))
            {
                IncreaseCapacity();
            }
            items[count] = value;
            count++;
        }


        public void IncreaseCapacity()
        {
            capacity += capacity;
            T[] newItems = new T[capacity];            
            for(int i = 0; i < count; i++)
            {
                newItems[i] = items[i];
            }
            items = newItems;            
        }

        public void Remove(T value)
        {
            int findNumber;
            findNumber = FindNumber(value);
            if(findNumber > 0)
            {
                T[] newItems = new T[capacity];
                int j = 0;
                for (int i = 0 ; i < count; i++, j++) {
                    if (!value.Equals(items[i]))
                    {
                        newItems[j] = items[i];                        
                    }
                    else
                    {
                        j--;                       
                    }
                }
                count--;
                items = newItems;
            }
            
        }


        public int FindNumber(T value)
        {
            for(int i = 0; i < count; i++)
            {
                if (value.Equals(items[i]))
                {
                    return i;
                }
            }
            return -1;
            
        }


        public string Convert()
        {
            StringBuilder newString = new StringBuilder();
            
            for(int i = 0; i < Count; i++)
            {
                newString.Append(items[i] + ", "); 
            }
            string finalString = newString.ToString();

            return finalString;
        }

    }
}
