using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexList
{
    class Program
    {
        static void Main(string[] args)
        {
            string item = "Expected value";
            AList<string> listOfValues = new AList<string>();
            listOfValues.Add(item);
            //act
            listOfValues.Insert(0, "fill");
        }
    }
}
