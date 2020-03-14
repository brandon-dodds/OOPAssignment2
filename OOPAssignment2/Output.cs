using System;
using static OOPAssignment2.HashResult;
namespace OOPAssignment2
{
    class Output
    {
        // Following SRP, creating a class to handle console output.
        public static void HashOutput(HashCodes FileHashResult)
        {
            // Function that outputs based on the enum output in hashResult.Diff();
            switch (FileHashResult)
            {
                case HashCodes.same:
                    Console.Write(">: [OUTPUT] ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"These files are the same!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case HashCodes.different:
                    Console.Write(">: [OUTPUT] ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"These files are different!");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case HashCodes.unsuccessful:
                    Console.WriteLine("Hash could not be computed due to null values.\n");
                    break;
            }
        }
        public static void HelpOutput()
        {
            Console.WriteLine("The diff command is the only command implemented. " +
                "You can use it by typing diff text1.txt text2.txt\n");
        }
    }
}
