namespace B21_Ex01_1
{
    using System;

    public class Program
    {
        public static void    Main()
        {
            RunBinarySeries();
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }

        public static void    RunBinarySeries()
        {
            Console.WriteLine("Please enter three 7-digit numbers separated by a carriage return");
            string binaryNum1 = get7DigitBinaryNum();
            string binaryNum2 = get7DigitBinaryNum();
            string binaryNum3 = get7DigitBinaryNum();
            printBinarySeriesStatistics(binaryNum1, binaryNum2, binaryNum3);
        }

        private static bool   checkIfNumIsBinary(string i_BinaryNum)
        {
            bool isNumBinary = true;

            foreach (char i in i_BinaryNum)
            {
                if (i != '0' && i != '1')
                {
                    isNumBinary = false;
                }
            }

            return isNumBinary;
        }

        private static bool   checkIfValid7DigitBinaryNum(string i_BinaryNum)
        {
            bool isNum = int.TryParse(i_BinaryNum, out _);
            bool is7DigitsLength = i_BinaryNum.Length == 7;
            bool isBinaryNum = checkIfNumIsBinary(i_BinaryNum);
            return isNum && is7DigitsLength && isBinaryNum;
        }

        private static string get7DigitBinaryNum()
        {
            bool validInput = false;
            string inputStringNum = string.Empty;

            while (!validInput)
            {
                inputStringNum = Console.ReadLine();
                validInput = checkIfValid7DigitBinaryNum(inputStringNum);
                if (!validInput)
                {
                    Console.WriteLine("Invalid input, please try again");
                }
            }

            return inputStringNum;
        }

        private static int    getZerosCount(string i_Str)
        {
            int zerosCount = 0;

            foreach (char i in i_Str)
            {
                if (i == '0')
                {
                    zerosCount++;
                }
            }

            return zerosCount;
        }

        private static bool   checkIfNumIsPowerOfTwo(int i_Num)
        {
            bool isPowerOfTwo;

            if (i_Num == 0)
            {
                isPowerOfTwo = false;
            }
            else
            {
                isPowerOfTwo = true;
            }

            while (i_Num >= 1)
            {
                if ((i_Num % 2 != 0) && (i_Num != 1))
                {
                    isPowerOfTwo = false;
                }

                i_Num /= 2;
            }

            return isPowerOfTwo;
        }

        private static int    countPowerOfTwo(int i_Num1, int i_Num2, int i_Num3)
        {
            int countPowerOfTwo = 0;

            if (checkIfNumIsPowerOfTwo(i_Num1))
            {
                countPowerOfTwo++;
            }

            if (checkIfNumIsPowerOfTwo(i_Num2))
            {
                countPowerOfTwo++;
            }

            if (checkIfNumIsPowerOfTwo(i_Num3))
            {
                countPowerOfTwo++;
            }

            return countPowerOfTwo;
        }

        private static bool   checkIfNumIsAscendingSeries(int i_Num)
        {
            bool isAscendingSeries = true;
            int previousDig = 10;

            while (i_Num > 0)
            {
                if (previousDig <= i_Num % 10)
                {
                    isAscendingSeries = false;
                }

                previousDig = i_Num % 10;
                i_Num /= 10;
            }

            return isAscendingSeries;
        }

        private static int    countAscendingSeries(int i_Num1, int i_Num2, int i_Num3)
        {
            int countAscendingSeries = 0;

            if (checkIfNumIsAscendingSeries(i_Num1))
            {
                countAscendingSeries++;
            }

            if (checkIfNumIsAscendingSeries(i_Num2))
            {
                countAscendingSeries++;
            }

            if (checkIfNumIsAscendingSeries(i_Num3))
            {
                countAscendingSeries++;
            }

            return countAscendingSeries;
        }

        private static void   printBinarySeriesStatistics(string i_BinaryNum1, string i_BinaryNum2, string i_BinaryNum3)
        {
            int decimalNum1 = convertBinaryToDecimal(int.Parse(i_BinaryNum1));
            int decimalNum2 = convertBinaryToDecimal(int.Parse(i_BinaryNum2));
            int decimalNum3 = convertBinaryToDecimal(int.Parse(i_BinaryNum3));
            int powerOfTwoCount = countPowerOfTwo(decimalNum1, decimalNum2, decimalNum3);
            int ascendingSeriesCount = countAscendingSeries(decimalNum1, decimalNum2, decimalNum3);
            int totalZerosCount = getZerosCount(i_BinaryNum1) + getZerosCount(i_BinaryNum2) + getZerosCount(i_BinaryNum3);
            int totalOnesCount = i_BinaryNum1.Length + i_BinaryNum2.Length + i_BinaryNum3.Length - totalZerosCount;
            int maxDecimalNum = Math.Max(Math.Max(decimalNum1, decimalNum2), decimalNum3);
            int minDecimalNum = Math.Min(Math.Min(decimalNum1, decimalNum2), decimalNum3);
            const int k_ParameterCount = 3;

            Console.WriteLine("The numbers are: {0}, {1}, {2},", decimalNum1, decimalNum2, decimalNum3);
            Console.WriteLine("{0} of these numbers are a power of 2", powerOfTwoCount);
            Console.WriteLine("{0} of these numbers are a ascending series ", ascendingSeriesCount);
            Console.WriteLine("The average number of 1's is {0}", totalOnesCount / k_ParameterCount);
            Console.WriteLine("The average number of 0's is {0}", totalZerosCount / k_ParameterCount);
            Console.WriteLine("The largest number is {0}, and the smallest number is {1} ", maxDecimalNum, minDecimalNum);
        }

        private static int    convertBinaryToDecimal(int i_Num)
        {
            int decimalNum = 0;
            int i = 0;

            while (i_Num > 0)
            {
                if (i_Num % 10 == 1)
                {
                    decimalNum += (int)Math.Pow(2, i);
                }

                i_Num /= 10;
                i++;
            }

            return decimalNum;
        }
    }
}