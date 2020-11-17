using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace InClassAssignmentWeek7
{
    public static class Utility
    {
        //A string that uses the string called title to set information to it and to check that the user has input something
        public static string GetUserInput(string Title)
        {
            string userInput;
            WriteLine(Title);
            userInput = ReadLine();
            userInput = userInput.Trim();

            while (String.IsNullOrEmpty(userInput))
            {
                WriteLine("Please enter a value.");
                userInput = ReadLine();
                userInput = userInput.Trim();
            }
            return userInput;
        }

        //A true false statement that uses the string called title to set information to it and to check that the user has input the letter y or n
        public static bool Affirm(string Title)
        {
            WriteLine(Title);
            while (true)
            {
                ConsoleKey UserInput = ReadKey().Key;
                switch (UserInput)
                {
                    case ConsoleKey.N:
                        return false;
                    case ConsoleKey.Y:
                        return true;
                    default:
                        WriteLine("Please press Y/N to affirm or deny.");
                        break;
                }
            }
        }

        //A method that uses a for loop to set the proper window width
        public static void Line()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Write("-");
            }
            Write("\n");
        }

        //A method that uses the string called input to set information to it by applying the proper window width
        public static void Center(string input)
        {
            int half = WindowWidth / 2;
            half = half - (input.Length / 2);
            if (half > 0)
            {
                for (int i = 0; i < half; i++)
                {
                    Write(" ");
                }
                Write(input);
            }
            else
            {
                Write(input);
            }
            Write("\n");
        }
    }
}