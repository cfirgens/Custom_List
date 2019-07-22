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
        T[] listItems;
        
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
            listItems = new T[capacity];
        }


        public void Add(T value)
        {
            if (count == (capacity -1))
            {
                IncreaseCapacity();
            }
            listItems[count] = value;
            count++;
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

        public void Remove(T value)
        {
            int findNumber;
            findNumber = FindNumber(value);
            if(findNumber > 0)
            {
                T[] newItems = new T[capacity];
                int j = 0;
                for (int i = 0 ; i < count; i++, j++) {
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


        public int FindNumber(T value)
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

        public static CustomList<T>  operator - (CustomList<T> listOne, CustomList<T> listTwo)
        {
            CustomList<T> minusList = new CustomList<T>();
            int matchFound = listOne.FindNumber(listTwo);

            if(matchFound != -1)
            {
                int lastMatchCount = matchFound + listTwo.Count - 1;
                for (int i = 0; i < listOne.Count; i++)
                {
                    if ( i < matchFound || i > lastMatchCount)
                    {
                        minusList.Add(listOne[i]);
                    }
                }
            }
            else
            {
                for(int i = 0; i < listOne.Count; i++)
                {
                    minusList.Add(listOne[i]);
                }
            }
            return minusList;

        }




    }
}
