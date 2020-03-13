using System;

namespace OOPAssignment2
{
    class Output
    {
        // Following SRP, creating a class to handle console output.
        public static void HashOutput(HashResult.HashCodes FileHashResult)
        {
            // Function that outputs based on the enum output in hashResult.Diff();
            switch (FileHashResult)
            {
                case HashResult.HashCodes.same:
                    Console.Write(">: [OUTPUT] ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"These files are the same!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case HashResult.HashCodes.different:
                    Console.Write(">: [OUTPUT] ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"These files are different!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case HashResult.HashCodes.unsuccessful:
                    Console.WriteLine("Hash could not be computed due to null values.\n");
                    break;
            }
        }
    }
}
