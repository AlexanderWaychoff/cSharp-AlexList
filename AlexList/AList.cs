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
        protected int Capacity
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
        private T[] ReplaceArray(T[] replacedList, int? removedIndex = null)
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
        protected int CheckCapacity(int? removedIndex = null)
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
        private T[] CreateNewArray()
        {
            T[] replacedList = new T[Capacity];
            return replacedList; 
        }
        private int IncreaseCapacity()
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
        private AList<T> CycleAddToList (AList<T> keepArray, AList<T> cyclingArray)
        {
            for(int i = 0; i < cyclingArray.Count; i++)
            {
                keepArray.Add(cyclingArray[i]);
            }
            return keepArray;
        }
        private AList<T> AddTwoLists(AList<T> list1, AList<T> list2)
        {
            AList<T> addedLists = new AList<T>();
            addedLists = CycleAddToList(addedLists, list1);
            addedLists = CycleAddToList(addedLists, list2);
            return addedLists;
        }
        private AList<T> CycleRemoveFromList(AList<T> keepArray, AList<T> cyclingArray)
        {
            for (int i = 0; i < cyclingArray.Count; i++)
            {
                keepArray.Remove(cyclingArray[i]);
            }
            return keepArray;
        }
        public AList<T> Zip (AList<T> list1, AList<T> list2)
        {
            AList<T> zippedList = new AList<T>();
            int lengthOfZipper = GetZipCount(list1, list2);
            for (int i = 0; i < lengthOfZipper; i++)
            {
                zippedList.Add(list1[i]);
                zippedList.Add(list2[i]);
            }
            return zippedList;
        }
        protected int GetZipCount(AList<T> list1, AList<T> list2)
        {
            int grabMinimumCount = 0;
            if (list1.Count <= list2.Count)
            {
                grabMinimumCount = list1.Count;
            }
            else
            {
                grabMinimumCount = list2.Count;
            }
            return grabMinimumCount;
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
        public static AList<T> operator +(AList<T> list1, AList<T> list2)
        {
            AList<T> combinedLists = new AList<T>();
            combinedLists = combinedLists.AddTwoLists(list1, list2);
            return combinedLists;
        }
        public static AList<T> operator -(AList<T> list1, AList<T> list2)
        {
            AList<T> combinedLists = new AList<T>();
            combinedLists = combinedLists.CycleRemoveFromList(list1, list2);
            return combinedLists;
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
