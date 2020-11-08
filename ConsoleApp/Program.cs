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
            list.AddToEnd(-3);
            list.AddToEnd(4);
            list.AddTo(1, 8);
            list.AddToBiginning(0);
            list.AddToBiginning(1);
            list.AddTo(0, -2);
            list.PrintList();
            Console.WriteLine();


            ArrayList newList = list.QuickSort();
            ArrayList newList2 = list.QuickSortDecrease();
            newList.PrintList();
            Console.WriteLine();
            Console.WriteLine();


            newList2.PrintList();

            Console.WriteLine();
            list.PrintList();
            Console.WriteLine();
        }
    }
}
