using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AlexList
{
    public class AList<T> : IEnumerable<T>
    {
        private T[] NList;
        private int startingCapacity = 6;
        private int count = 0;
        private int index = 0;
        private int capacity = 6;
        private int removedIndex = 0;
        public T this[int i]
        {
            get
            {
                return NList[i];
            }
            set
            {
                NList[i] = value;
            }
        }
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }
        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                capacity = value;
            }
        }
        //ctor
        public AList()//T[]    //AList<T>
        {
            this.capacity = startingCapacity;
            this.Count = 0;
            NList = new T[capacity];
        }

        //methods
        public T[] ReplaceArray(T[] replacedList, int? removedIndex = null)
        {
            bool hasRemoveMatch = false;
            for (int i = 0; i < Count; i++)
            {
                if (i == removedIndex)
                {
                    hasRemoveMatch = true;
                }
                else if(hasRemoveMatch)
                {
                    replacedList[i - 1] = NList[i];
                }
                else
                {
                    replacedList[i] = NList[i];
                }
            }
            return replacedList;
        }
        public int CheckCapacity(int? removedIndex = null)
        {
            if (Count >= Capacity/2)
            {
                Capacity = IncreaseCapacity();
                T[] replacedList = CreateNewArray();
                NList = ReplaceArray(replacedList);
            }
            else if(!(removedIndex == null))
            {
                T[] replacedList = CreateNewArray();
                NList = ReplaceArray(replacedList, removedIndex);
            }
            return Capacity;
        }
        public T[] CreateNewArray()
        {
            T[] replacedList = new T[Capacity];
            return replacedList; 
        }
        public int IncreaseCapacity()
        {
            int capacity = Capacity;
            capacity *= 2;
            return capacity;
        }
        public void Add(T value)
        {
            Count += 1;
            Index = Count - 1;
            NList[Index] = value;
            CheckCapacity();
        }
        public bool Remove(T value)
        {
            for (int i = 0; i < Count; i++)
            {
                if(NList[i].Equals(value))
                {
                    removedIndex = i;
                    CheckCapacity(removedIndex);
                    Count -= 1;
                    return true;
                }
            }
            return false;
        }
        public void RemoveAt(int value)
        {

        }
        //public int Count()
        //{
        //    return 0;
        //}
        public void Clear()
        {

        }
        public void Insert(int i, T value)
        {

        }
        public T IndexOf(int i)
        {
            return NList[i];
        }
        public override string ToString()
        {
            String arrayItems = String.Empty;
            foreach (var item in this)
            {
                if (String.IsNullOrEmpty(arrayItems))
                {
                    arrayItems += item.ToString();
                }
                else
                {
                    arrayItems += String.Format(", {0}", item);
                }
            }
            return arrayItems;
        }
        //to overload, not override, string; specifically need override
        //public string ToString(string seperator = ", ")
        //{
        //    String arrayItems = String.Empty;
        //    foreach (var item in this)
        //    {
        //        if (String.IsNullOrEmpty(arrayItems))
        //        {
        //            arrayItems += item.ToString();
        //        }
        //        else
        //        {
        //            arrayItems += String.Format("{0}{1}", seperator, item);
        //        }
        //    }
        //    return arrayItems;
        //}

        public IEnumerator<T> GetEnumerator()
        {          
            for(int i = 0; i < Count; i ++)
            {
                yield return NList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return NList[i];
            }
        }
    }
}
