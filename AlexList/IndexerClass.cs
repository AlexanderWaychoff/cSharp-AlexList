using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexList
{
    public class IndexerClass<T>
    {
        //int AListLength = 0;
        public T[] AList = new T[0];
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
}
