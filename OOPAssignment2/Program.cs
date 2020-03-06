using System;
using System.IO;
using System.Linq;
namespace OOPAssignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            var string1 = File.ReadAllLines("text1.txt");
            var string2 = File.ReadAllLines("text2.txt");
            Console.WriteLine(string1.SequenceEqual(string2) ? "These are the same!" : "These aren't the same");
        }
    }
}
