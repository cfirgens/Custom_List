using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> newList = new List<int>();

            Console.WriteLine(newList);
            newList.Remove(5);

            Console.ReadLine();

            newList.RemoveAt(1);
        }
    }
}
