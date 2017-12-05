using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexList
{
    public class AList<T>
    {
        protected class IndexerClass
        {
            private T[] AList = new T[1];//adjust value with constructor later
            public T this[int i]
            {
                get
                {
                    return AList[i];
                }
                set
                {
                    AList[i] = value;
                }
            }
        }
        IndexerClass NList;// = new IndexerClass();//add constructor to create length here


        //array has a fixed length, contains a specific type of data, and contained data is 
        //constant (cannot be changed by a method)
        //Array<T>
        StoredValue<T> value;
        public int listLength = 0;
        private int count = 0;

        //public int Count
        //{
        //    get 
        //    {
        //        return count;
        //    }
        //}

        public AList()
        {
            this.NList = new IndexerClass();
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
    }
}
