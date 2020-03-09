using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace OOPAssignment2
{
    class Program
    {
        private static readonly HashAlgorithm hashingAlgorithm = SHA512.Create();
        private static byte[] GetShaHash(string filename)
        {
            using FileStream stream = File.OpenRead(filename);
            return hashingAlgorithm.ComputeHash(stream);
        }

        static void Main()
        {
            var hash1 = GetShaHash("text1.txt");
            var hash2 = GetShaHash("text2.txt");
            Console.WriteLine(hash1.SequenceEqual(hash2) ? "These are the same!" : "These aren't the same");
        }
    }
}
