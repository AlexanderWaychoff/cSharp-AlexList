using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexList
{
    public class AList<T>
    {
        private int count;
        private T[] NList;
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
        public AList(int size)
        {
            NList = new T[size];
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
