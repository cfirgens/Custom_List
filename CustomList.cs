using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T> : IEnumerable<T>
    {
        //member variables
        int count;
        int capacity;
        T[] listItems;

        //properties
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

        //index
        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < count)
                {
                    return listItems[index];
                }

                throw new IndexOutOfRangeException();
            }

            set
            {
                if (index >= 0 && index < count)
                {
                    listItems[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        // constructor
        public CustomList()
        {            
            count = 0;
            capacity = 4;
            listItems = new T[capacity];
        }

        // methods

        public void Add(T value)
        {
            if (count == (capacity -1))
            {
                IncreaseCapacity();
            }
            listItems[count] = value;
            count++;
        }

        public void Remove(T value)
        {
            int findNumber;
            findNumber = Find(value);
            if (findNumber > 0)
            {
                T[] newItems = new T[capacity];
                int j = 0;
                for (int i = 0; i < count; i++, j++)
                {
                    if (!value.Equals(listItems[i]))
                    {
                        newItems[j] = listItems[i];
                    }
                    else
                    {
                        j--;
                    }
                }
                count--;
                listItems = newItems;
            }
        }
        public void RemoveAt(int indexRemove)
        {
            for (int i = indexRemove + 1; i < Count; i++)
            {
                listItems[i - 1] = listItems[i];
            }
            count--;
        }

        public void IncreaseCapacity()
        {
            capacity += capacity;
            T[] newItems = new T[capacity];            
            for(int i = 0; i < count; i++)
            {
                newItems[i] = listItems[i];
            }
            listItems = newItems;            
        }
        public int Find(T value)
        {
            for(int i = 0; i < count; i++)
            {
                if (value.Equals(listItems[i]))
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
                newString.Append(listItems[i] + " "); 
            }
            string finalString = newString.ToString();

            return finalString;
        }
        public static CustomList<T> operator +(CustomList<T> listOne, CustomList<T> listTwo)
        {
            CustomList<T> combinedList = new CustomList<T>();

            for (int i = 0; i < listOne.Count; i++)
            {
                combinedList.Add(listOne[i]);
            }
            for (int j = 0; j < listTwo.Count; j++)
            {
                combinedList.Add(listTwo[j]);
            }
            return combinedList;
        }
        public static CustomList<T> operator -(CustomList<T> listOne, CustomList<T> listTwo)
        {
            for (int i = 0; i < listOne.Count; i++)
            {
                for (int j = 0; j < listTwo.Count; j++)
                {
                    if (listOne[i].Equals(listTwo[j]))
                    {
                        listOne.Remove(listTwo[j]);
                    }
                }
            }
            return listOne;
        }

        public static CustomList<T> Zip(CustomList<T> listOne, CustomList<T> listTwo)
        {
            var zippedList = new CustomList<T>();
            if (listOne.Count == listTwo.Count)
            {
                for (int i = 0; i < listOne.Count; i++)
                {
                    zippedList.Add(listOne[i]);
                    zippedList.Add(listTwo[i]);
                }
                return zippedList;
            }
            else if (listOne.Count > listTwo.Count)
            {
                for (int i = 0; i < listOne.Count; i++)
                {
                    for(int j = 0; i< listTwo.Count; j++, i++)
                    {
                        zippedList.Add(listOne[j]);
                        zippedList.Add(listTwo[j]);
                    }

                    zippedList.Add(listOne[i]);

                }
                return zippedList;
            }
            else
            {
                for (int i = 0; i < listTwo.Count; i++)
                {
                    for (int j = 0; i < listOne.Count; j++, i++)
                    {
                        zippedList.Add(listOne[j]);
                        zippedList.Add(listTwo[j]);
                    }

                    zippedList.Add(listTwo[i]);

                }
                return zippedList;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return listItems[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
