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
            // Creates a default byte array hash.
            byte[] hash = default;
            try
            {
                // If the file is not found, catch the exception.
                using FileStream stream = File.OpenRead(filename);
                hash = hashingAlgorithm.ComputeHash(stream);
            } 
            catch (FileNotFoundException ex)
            {
                // Sends the default error.
                Console.WriteLine(ex.Message);
            }
            return hash;
        }
        public static void Diff(string path1, string path2)
        {
            // Creates two variables with the hashes of the files.
            var hash1 = GetShaHash(path1);
            var hash2 = GetShaHash(path2);
            // If hash1 or hash 2 are not null.
            if (hash1 != null && hash2 != null)
            {
                // if the hashes are equal.
                if (hash1.SequenceEqual(hash2))
                {
                    Console.Write(">: [OUTPUT] ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{path1} and {path2} are not different. \n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                // if they aren't equal.
                else
                {
                    Console.Write(">: [OUTPUT] ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{path1} and {path2} are different. \n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            // Print an error.
            else
            {
                Console.WriteLine("Hash could not be computed due to null values.");
            }
        }
        static void Main()
        {
            while (true)
            {
                // Takes the user input and splits it into different words.
                Console.Write(">: [INPUT] ");
                var userCommandAndArgs = Console.ReadLine();
                var userSplit = userCommandAndArgs.Split(" ");
                // Switches on user split.
                if (userSplit.Length <= 2)
                {
                    Console.WriteLine("Not enough arguments."); 
                }
                else
                {
                    switch (userSplit[0])
                    {
                        // case diff (diff command).
                        case "diff":
                            //takes in the words as the arguments.
                            Diff(userSplit[1], userSplit[2]);
                            Console.WriteLine();
                            break;
                        default:
                            //if it doesnt work, it loops.
                            Console.WriteLine("Please enter a valid command.");
                            Console.WriteLine();
                            break;
                    }
                }
            }
        }
    }
}