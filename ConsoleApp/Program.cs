using System;
using DataStructure;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList {};
            list.AddToEnd(1);
            list.AddToEnd(3);
            list.AddToEnd(4);
            list.AddTo(1, 2);
            list.AddToBiginning(0);
            list.AddToBiginning(-1);
            list.AddTo(0, -2);
            Console.WriteLine(list.Lenght);
            list.PrintList();
        }
    }
}
