using System;

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
                Console.WriteLine("Type: diff text1.txt text2.txt");
                Console.Write(">: [INPUT] ");
                var userCommandAndArgs = Console.ReadLine();
                var userSplit = userCommandAndArgs.Split(" ");
                // Split based on the user input.
                switch (userSplit[0])
                {
                    // Diff is the command.
                    case "diff":
                        var fileHashResult = HashResult.Diff(userSplit[1], userSplit[2]);
                        Output.HashOutput(fileHashResult);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid command.\n");
                        break;
                }
            }
        }
    }
}
