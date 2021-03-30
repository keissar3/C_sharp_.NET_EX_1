namespace B21_Ex01_6
{
    using System;

    public class Program
    {
        public static void    Main()
        {
            RunNumbersStatistics();

            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }

        public static void    RunNumbersStatistics()
        {
            Console.WriteLine("Please enter 6 digit number");
            int inputNumber = getInputNumberFromUser();
            printBiggestAndLowestDigitInNumber(inputNumber);
            printDigitDividedBy3Count(inputNumber);
            printHowManyDigitAreBiggerThanTheUnitsDigit(inputNumber);
        }

        private static void     printHowManyDigitAreBiggerThanTheUnitsDigit(int i_InputNumber)
        {
            int counterDigitBiggerThanUnitsDigit = 0, unitsDigit = i_InputNumber % 10;

            while (i_InputNumber > 0)
            {
                int currentDigit = i_InputNumber % 10;

                if (currentDigit > unitsDigit)
                {
                    counterDigitBiggerThanUnitsDigit++;
                }

                i_InputNumber /= 10;
            }

            string outputString = string.Format("There are {0} digits in the number that are bigger than the units digit ", counterDigitBiggerThanUnitsDigit);
            Console.WriteLine(outputString);
        }

        private static void   printDigitDividedBy3Count(int i_InputNumber)
        {
            int counterDigitDividedBy3 = 0, currentDigit, counterOfDigit = 0;

            while (i_InputNumber > 0)
            {
                counterOfDigit++;
                currentDigit = i_InputNumber % 10;
                if (currentDigit % 3 == 0)
                {
                    counterDigitDividedBy3++;
                }

                i_InputNumber /= 10;
            }

            string outputString = string.Format("There is {0} digits in the number that can be divided by 3", counterDigitDividedBy3 + 6 - counterOfDigit);
            Console.WriteLine(outputString);
        } 

        private static void   printBiggestAndLowestDigitInNumber(int i_InputNumber)
        {
            int minDigitInNumber = i_InputNumber % 10, maxDigitInNumber = i_InputNumber % 10, currentDigit, counterOfDigit = 0;

            while (i_InputNumber > 0)
            {
                counterOfDigit++;
                currentDigit = i_InputNumber % 10;
                if (currentDigit < minDigitInNumber)
                {
                    minDigitInNumber = currentDigit;
                }

                if (currentDigit > maxDigitInNumber)
                {
                    maxDigitInNumber = currentDigit;
                }

                i_InputNumber /= 10;
            }

            if (counterOfDigit < 6)
            {
                Console.WriteLine("The lowest digit in the number is 0");
            }
            else
            {
                Console.WriteLine("The lowest digit in the number is {0}", minDigitInNumber);
            }

            Console.WriteLine("The biggest digit in the number is {0}", maxDigitInNumber);
        }

        private static bool   checkValidOf6DigitNumber(string i_InputStringNumber)
        {
            bool isLengthOk = i_InputStringNumber.Length == 6;
            bool isTheInputContainOnlyDigits = B21_Ex01_4.Program.IsOnlyDigits(i_InputStringNumber);

            return isLengthOk && isTheInputContainOnlyDigits;
        }

        private static int    getInputNumberFromUser()
        {
            bool isValidInput = false;
            string inputString = string.Empty;

            while (!isValidInput)
            {
                inputString = Console.ReadLine();
                isValidInput = checkValidOf6DigitNumber(inputString);
                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input, please try again");
                }
            }

            int decimalNumber = int.Parse(inputString);

            return decimalNumber;
        }
    }
}