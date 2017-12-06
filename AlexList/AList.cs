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
            NList = new T[capacity];
        }
        //GetEnumerator
        public IEnumerator<T> GetEnumerable()
        {
            yield return default(T);
        }

        //methods
        public T[] ReplaceArray(T[] replacedList)
        {
            for (int i = 0; i < Capacity/2; i++)
            {
                replacedList[i] = NList[i];
            }
            return replacedList;
        }
        public void CheckCapacity()
        {
            if (Count >= Capacity/2)
            {
                Capacity = IncreaseCapacity();
                T[] replacedList = CreateNewArray();
                NList = ReplaceArray(replacedList);
            }
        }
        public T[] CreateNewArray()
        {
            T[] replacedList = new T[IncreaseCapacity()];
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
        }
        public bool Remove(T value)
        {
            return true;
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

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
