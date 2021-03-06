﻿using System;
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
        protected static class KeyboardValues
        {
            public static AList<string> alphaChar = new AList<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            public static AList<string> alphaValue = new AList<string>() { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26" };
        }
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
        /// <summary>
        /// Sorts your list in numerical order, starting with the lowest number.
        /// </summary>
        //public AList<T> ArrangeNumerically()
        //{
        //    if (typeof(T) == typeof(string))
        //    {
        //        throw new NotFiniteNumberException();
        //    }
        //    else
        //    {
        //        AList<T> arrangedList = new AList<T>();

        //        for (int j = 0; j < this.Count; j++)
        //        {
        //            T numberValue = this[j];
        //            for (int i = 0; i < Count; i++)
        //            {
        //                if (this[j].CompareTo(this[i]) < 0)
        //                {
        //                    numberValue = this[i];
        //                }
        //            }
        //            //CompareTo
        //            arrangedList.Add(NList[wordValueList.IndexOf(decimalValue)]);
        //            //this.Remove(NList[wordValueList.IndexOf(decimalValue)]);
        //            wordValueList[wordValueList.IndexOf(decimalValue)] = Convert.ToDecimal(checkedValue);
        //        }

        //        return arrangedList;
        //    }
        //}
        /// <summary>
        /// Sorts your list in alphabetical order, starting with the letter 'A'.
        /// </summary>
        public AList<T> ArrangeAlphabetically()
        {
            if (typeof(T) != typeof(string))
            {
                throw new NotSupportedException();
            }
            else
            {
                AList<T> arrangedList = new AList<T>();
                AList<decimal> wordValueList = new AList<decimal>();
                T item;
                for (int i = 0; i < Count; i++)
                {
                    string wordValue = "";
                    int cap = 0;
                    item = NList[i];
                    foreach (char C in item.ToString().ToLower())
                    {
                        cap += 1;
                        if (cap < 14)//28 digits is max storage of decimal, each letter needs 2 digits
                        {
                            wordValue += KeyboardValues.alphaValue[KeyboardValues.alphaChar.IndexOf(C.ToString())];
                        }
                    }
                    wordValueList.Add(Convert.ToDecimal("0." + wordValue));
                }
                return Alphabetically(wordValueList);
            }
        }
        private AList<T> Alphabetically (AList<decimal> wordValueList)
        {
            AList<T> arrangedList = new AList<T>();
            for (int j = 0; j < this.Count; j++)
            {
                string checkedValue = "0.301";
                decimal decimalValue = Convert.ToDecimal(checkedValue);
                for (int i = 0; i < wordValueList.Count; i++)
                {
                    if (decimalValue > wordValueList[i])
                    {
                        decimalValue = wordValueList[i];
                    }
                }
                arrangedList.Add(NList[wordValueList.IndexOf(decimalValue)]);
                //this.Remove(NList[wordValueList.IndexOf(decimalValue)]);
                wordValueList[wordValueList.IndexOf(decimalValue)] = Convert.ToDecimal(checkedValue);
            }
            return arrangedList;
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
        public void Insert(int index, T value)
        {
            if(index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            for (int i = 0; i < Count; i++)
            {
                if (i == index)
                {
                    for (int j = Count + 1; j > index + 1; j--)
                    {
                        this[j - 1] = this[j - 2];
                    }
                    Count += 1;
                    CheckCapacity();
                    i += Count;
                    this[index] = value;
                }
                else
                {
                    this.Add(value);
                }
            }
        }
        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if(this[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }
        public T IndexAt(int placement)
        {
            return NList[placement];
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
