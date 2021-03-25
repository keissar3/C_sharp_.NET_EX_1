namespace B21_Ex01_3
{
    using System;

    public class Program
    {
        public static void Main()
        {
            HourGlassByUserInput();
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }

        public static void HourGlassByUserInput()
        {
            int userInput = (int)getValidHourGlassInput();
            B21_Ex01_2.Program.HourGlass(userInput);
        }

        private static uint getValidHourGlassInput()
        {
            bool validInput = false;
            uint validUserInput = 0;

            Console.WriteLine("Please enter the desired hour glass height");
            while (validInput == false)
            {
                string userStringInput = Console.ReadLine();
                validInput = uint.TryParse(userStringInput, out validUserInput);

                if (validInput == false)
                {
                    Console.WriteLine("Input must be a positive number");
                }
            }

            if (validUserInput % 2 == 0)
            {
                validUserInput++;
            }

            return validUserInput;
        }
    }
}