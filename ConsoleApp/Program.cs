using System;
using DataStructure;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.AddToEnd(11);
            list.AddToEnd(4);
            list.AddToEnd(-3);
            list.AddToEnd(4);
            list.AddTo(1, 8);
            list.AddToBiginning(0);
            list.AddToBiginning(1);
            list.AddTo(0, -2);
            list.AddToEnd(4);
            list.AddToEnd(4);
            list.AddToEnd(4);
            list.AddToEnd(4);
            list.AddToEnd(4);
            list.PrintList();            
            Console.WriteLine();

            list.DeleteElementsWithValue(4);
            list.PrintList();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
