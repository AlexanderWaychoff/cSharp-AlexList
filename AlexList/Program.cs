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
            AList<string> arrangeList = new AList<string>() { "dog", "hamster", "cat", "fish" };
            //act
            arrangeList = arrangeList.Arrange();//AlphabeticallyA
        }
    }
}
