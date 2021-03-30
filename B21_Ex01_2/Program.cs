namespace B21_Ex01_2
{
    using System;
    using System.Text;

    public class Program
    {
        public static void    Main()
        {
            HourGlass();
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }

        public static void    HourGlass(int i_HourGlassHeight = 5)
        {
            hourGlassRecursive(i_HourGlassHeight, i_HourGlassHeight);
        }

        private static StringBuilder printCharRow(char i_CharToPrint, int i_TimesToPrint)
        {
            StringBuilder outputString = new StringBuilder(string.Empty, i_TimesToPrint);

            for (int j = 0; j < i_TimesToPrint; j++)
            {
                outputString.Append(i_CharToPrint);
            }
             
            return outputString;
        }

        private static void   hourGlassRecursive(int i_HourGlassHeight, int i_MaxRowWidth)
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

        private static void   printHourGlassSection(int i_SpacesPaddingNeeded, int i_HourGlassHeight)
        {
            StringBuilder outStringBuilder = new StringBuilder(string.Empty, i_HourGlassHeight);
            outStringBuilder.Append(printCharRow(' ', i_SpacesPaddingNeeded));
            outStringBuilder.Append(printCharRow('*', i_HourGlassHeight));
            outStringBuilder.Append(printCharRow(' ', i_SpacesPaddingNeeded));
            outStringBuilder.Append(System.Environment.NewLine);
            Console.Write(outStringBuilder);
        }
    }
}
