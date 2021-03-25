namespace B21_Ex01_2
{
    using System;

    public class Program
    {
        public static void Main()
        {
            HourGlass();
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }

        public static void HourGlass(int i_HourGlassHeight = 5)
        {
            hourGlassRecursive(i_HourGlassHeight, i_HourGlassHeight);
        }

        private static void printCharRow(char i_CharToPrint, int i_TimesToPrint)
        {
            for (int j = 0; j < i_TimesToPrint; j++)
            {
                Console.Write(i_CharToPrint);
            }
        }

        private static void hourGlassRecursive(int i_HourGlassHeight, int i_MaxRowWidth)
        {
            int spacesPaddingNeeded = (i_MaxRowWidth - i_HourGlassHeight) / 2;
            if (i_HourGlassHeight == 1)
            {
                printHourGlassSection(spacesPaddingNeeded, i_HourGlassHeight);
            }
            else
            {
                printHourGlassSection(spacesPaddingNeeded, i_HourGlassHeight);
                hourGlassRecursive(i_HourGlassHeight - 2, i_MaxRowWidth);
                printHourGlassSection(spacesPaddingNeeded, i_HourGlassHeight);
            }
        }

        private static void printHourGlassSection(int i_SpacesPaddingNeeded, int i_HourGlassHeight)
        {
            printCharRow(' ', i_SpacesPaddingNeeded);
            printCharRow('*', i_HourGlassHeight);
            printCharRow(' ', i_SpacesPaddingNeeded);
            Console.Write(Environment.NewLine);
        }
    }
}
