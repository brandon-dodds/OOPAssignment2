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
                Console.WriteLine($"The file {filename} was not found, sending default value.");
            }
            return hash;
        }

        public static void Diff(string path1, string path2)
        {
            var hash1 = GetShaHash(path1);
            var hash2 = GetShaHash(path2);
            if (hash1 != null && hash2 != null)
            {
                if (hash1.SequenceEqual(hash2))
                {
                    Console.Write(">: [Output] ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{path1} and {path2} are not different. \n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write(">: [Output] ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{path1} and {path2} are different. \n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.WriteLine("Hash could not be computed due to null values.");
            }
        }

        static void Main()
        {
            while (true)
            {
                Console.Write(">: [INPUT] ");
                var userCommandAndArgs = Console.ReadLine();
                var userSplit = userCommandAndArgs.Split(" ");
                switch (userSplit[0])
                {
                    case "diff":
                        Diff(userSplit[1], userSplit[2]);
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid command.");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
