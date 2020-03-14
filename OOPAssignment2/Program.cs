using System;
using static OOPAssignment2.HashResult;

namespace OOPAssignment2
{
    class Program
    {
        static void Main()
        {
            // While the application is running.
            while (true)
            {
                // Ask the user for input.
                Console.Write(">: [INPUT] ");
                string userCommandAndArgs = Console.ReadLine();
                string[] userSplit = userCommandAndArgs.Split(" ");
                // Split based on the user input.
                switch (userSplit[0])
                {
                    // Diff is the only command implemented thus far.
                    case "diff":
                        HashCodes fileHashResult = Diff(userSplit[1], userSplit[2]);
                        Output.HashOutput(fileHashResult);
                        break;
                    case "help":
                        Output.HelpOutput();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid command. Or type \"help\" to learn more.\n");
                        break;
                }
            }
        }
    }
}
