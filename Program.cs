using System;
using System.IO;

namespace LargeNumbersCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("\nSUMA:\n" + Adder.SumGeneratedValues());
            Console.WriteLine("\nSUMA:\n" + Adder.SumValuesFromFiles(Path.Combine(Environment.CurrentDirectory, "Liczby.txt")));
        }
    }
}
