namespace B21_Ex01_4
{
	using System;

	public class Program
	{
		public static void    Main()
		{
			RunStringAnalysis();
			Console.WriteLine("Press Enter to exit");
			Console.ReadLine();
		}

		public static void    RunStringAnalysis()
		{
			Console.WriteLine("Please enter 10 random English letters or 10 random digits ");
			string inputString = getStringFromUser();
			printWhetheStringIsPalindrom(inputString);
			printInfoAboutTheStringAccordingToIsContent(inputString);
		}
		
		private static void   printWhetherTheNumberIsDividedBy4(string i_InputString)
		{
			long decimalNumber = long.Parse(i_InputString);
			if (decimalNumber % 4 == 0)
			{
				Console.WriteLine("The number is divided by 4");	
			}
			else
			{
				Console.WriteLine("The number is not divided by 4");
			}
		}

		private static void   printHowMuchUppercaseInString(string i_InputString)
        {
			int counterOfUppercase = 0;

			foreach(char i in i_InputString)
            {
				if (i >= 'A' && i <= 'Z')
					counterOfUppercase++;
            }

			Console.WriteLine("There is a {0} uppercase in the string", counterOfUppercase);


        }
		private static void   printInfoAboutTheStringAccordingToIsContent(string i_InputString)
        {
			if(isOnlyDigits(i_InputString))
            {
				printWhetherTheNumberIsDividedBy4(i_InputString);
            }
			else
            {
				printHowMuchUppercaseInString(i_InputString);
            }
        }

		private static bool   isStringPalindrom(string i_InputString, int i_IndexLeft ,int i_IndexRight)
        {
			int sizeOfStringInRec = i_IndexRight - i_IndexLeft+1;

			if (sizeOfStringInRec == 0)
			{
				return true;
			}
			if (i_InputString[i_IndexRight] == i_InputString[i_IndexLeft])
			{
				return isStringPalindrom(i_InputString, i_IndexLeft + 1, i_IndexRight - 1);
			}
			else
			{
				return false;
			}
        }

        private static void   printWhetheStringIsPalindrom(string i_InputString)
        {
			bool isPalindrom = isStringPalindrom(i_InputString, 0, i_InputString.Length-1);
			if(isPalindrom)
            {
				Console.WriteLine("The string is a palindrom");
            }
			else
            {
				Console.WriteLine("The string is not a palindrom");
            }
        }
		private static string getStringFromUser()
		{
			bool isValidInput = false;
			string inputString = string.Empty;

			while (!isValidInput)
			{
				inputString = Console.ReadLine();
				isValidInput = checkIfValid10DigitOrLetters(inputString);
				if (!isValidInput)
				{
					Console.WriteLine("Invalid input, please try again");
				}
			}

			return inputString;

		}

		private static bool   isOnlyLetters(string i_InputString)
		{
			bool isValid = true;

			foreach (char i in i_InputString)
			{
				if (!((i >= 'A' && i <= 'Z') || (i >= 'a' && i <= 'z')))
				{
					isValid = false;
				}
			}

			return isValid;
		}

		public static bool   isOnlyDigits(string i_InputString)
		{
			bool isValid = true;

			foreach (char i in i_InputString)
			{

				if (!((i >= '0' && i <= '9')))
				{ 
					isValid = false;
				}
			}

			return isValid;

		}

		private static bool  checkIfValid10DigitOrLetters(string i_InputString)
		{
			bool isTheInputContainOnlyLetters = isOnlyLetters(i_InputString);
			bool isTheInputContainOnlyDigits = isOnlyDigits(i_InputString);
			bool isLenghtIsOk = i_InputString.Length == 10;


			return (isTheInputContainOnlyDigits || isTheInputContainOnlyLetters) && isLenghtIsOk;
		}

	}

}


