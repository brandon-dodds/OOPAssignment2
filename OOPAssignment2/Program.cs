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
            byte[] hash = default;
            try
            {
                using FileStream stream = File.OpenRead(filename);
                hash = hashingAlgorithm.ComputeHash(stream);
            } 
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file was not found, sending default value.");
            }
            return hash;
        }

        static void Main()
        {
            var hash1 = GetShaHash("tex1.txt");
            var hash2 = GetShaHash("text2.txt");
            if(hash1 != null && hash2 != null)
                Console.WriteLine(hash1.SequenceEqual(hash2) ? "These are the same!" : "These aren't the same");
            else
                Console.WriteLine("Hash could not be computed.");
        }
    }
}
