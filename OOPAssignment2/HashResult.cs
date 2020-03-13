using System;
using System.Security.Cryptography;
using System.Linq;
using System.IO;

namespace OOPAssignment2
{
    class HashResult
    {
        public enum HashCodes { same, different, unsuccessful }
        private static readonly HashAlgorithm hashingAlgorithm = SHA512.Create();
        private static byte[] GetShaHash(string filename)
        {
            // This code returns a byte array created by computing the hash of a file.
            byte[] hash = default;
            // Catches if the specific file is not found.
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
        public static HashCodes Diff(string path1, string path2)
        {
            // Takes two hashes and returns the appropriate hashcode.
            var hash1 = GetShaHash(path1);
            var hash2 = GetShaHash(path2);
            if (hash1 != null && hash2 != null)
            {
                if (hash1.SequenceEqual(hash2))
                    return HashCodes.same;
                else
                    return HashCodes.different;
            }
            else
                return HashCodes.unsuccessful;
        }
    }
}
