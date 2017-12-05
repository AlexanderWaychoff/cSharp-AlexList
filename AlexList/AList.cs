using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexList
{
    public class AList<T>
    {
        internal class IndexerClass
        {
            private T[] values = new T[0];//adjust value with constructor later
            ///public T this[int i]
            //{
                //get set
            //}
        }
        IndexerClass test = new IndexerClass();//add constructor to create length here


        //array has a fixed length, contains a specific type of data, and contained data is 
        //constant (cannot be changed by a method)
        //Array<T>
        StoredValue<T> value;
        public int listLength = 0;
        private int count = 0;

        public int Count
        {
            get 
            {
                return count;
            }
        }

        public AList()
        {

        }
        public void Add(T value)
        {

        }
        public void Remove(T value)
        {

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
    }
}
