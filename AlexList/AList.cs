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
        //ctor
        public AList(AList<T> content = null)
        {
            int capacity = DetermineCapacity(content);
            NList = new T[capacity];
            if(!(content == null))
            {
                ReplaceArray(capacity, content);
            }
        }
        //GetEnumerator
        public IEnumerator<T> GetEnumerable()
        {
            yield return default(T);
        }

        //methods
        public void ReplaceArray(int capacity, AList<T> replacedList)
        {
            for (int i = 0; i < capacity; i++)
            {
                NList[i] = replacedList[i];
            }
        }
        public void CreateNewArray()
        {

        }
        public int DetermineCapacity(AList<T> previousArray = null)
        {
            int capacity = 0;
            if (previousArray == null)
            {
                capacity = startingCapacity;
            }
            else
            {
                foreach (var item in previousArray)
                {
                    capacity += 1;
                }
                capacity *= 2;
            }
            return capacity;
        }
        public void Add(T value)
        {
            NList[0] = value;
        }
        public bool Remove(T value)
        {
            return true;
        }
        public void RemoveAt(int value)
        {

        }
        public int Count()
        {
            return 0;
        }
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
