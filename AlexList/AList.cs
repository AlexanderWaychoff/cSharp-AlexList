using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexList
{
    public class AList<T>
    {
        //array has a fixed length, contains a specific type of data, and contained data is 
        //constant (cannot be changed by a method)
        //Array<T>
        StoredValue<T> value = new StoredValue<T>();
    }
}
