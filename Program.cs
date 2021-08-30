using System;

namespace TSPGreedy2
{
    class Program
    {
        static int Main()
        {
            takeInput();

            Console.Write("\n\nThe Path is:\n");
            mincost(0); //passing 0 because starting vertex

            Console.Write("\n\nMinimum cost is ");
            Console.Write(cost);

            return 0;
        }

        public static int[,] ary = new int[20, 20];
        public static int[] completed = new int[20];
        public static int n;
        public static int cost = 0;
        public static void takeInput()
        {
            int i;
            int j;

            Console.Write("Enter the number of villages: ");
            n = int.Parse(ConsoleInput.ReadToWhiteSpace(true));

            Console.Write("\nEnter the Cost Matrix\n");

            for (int b = 0; b < n; b++)
            {
                Console.Write("\nEnter Elements of Row: ");
                Console.Write(b + 1);
                Console.Write("\n");

                for (j = 0; j < n; j++)
                {
                    {
                        ary[b, j] = int.Parse(ConsoleInput.ReadToWhiteSpace(true));
                    }

                    completed[b] = 0;
                }

                Console.Write("\n\nThe cost list is:");

                for (i = 0; i < n; i++)
                {
                    Console.Write("\n");

                    for (j = 0; j < n; j++)
                    {
                        Console.Write("\t");
                        Console.Write(ary[i, j]);
                    }
                }
            }
        }
        public static int least(int c)
        {
            int i;
            int nc = 999;
            int min = 999;
            int kmin = 0;

            for (i = 0; i < n; i++)
            {
                if ((ary[c, i] != 0) && (completed[i] == 0))
                {
                    if (ary[c, i] + ary[i, c] < min)
                    {
                        min = ary[i, 0] + ary[c, i];
                        kmin = ary[c, i];
                        nc = i;
                    }
                }
            }

            if (min != 999)
            {
                cost += kmin;
            }

            return nc;
        }
        public static void mincost(int city)
        {
            int i;
            int ncity;

            completed[city] = 1;

            Console.Write(city + 1);
            Console.Write("--->");
            ncity = least(city);

            if (ncity == 999)
            {
                ncity = 0;
                Console.Write(ncity + 1);
                cost += ary[city, ncity];

                return;
            }

            mincost(ncity);
        }

    }
}
internal static class ConsoleInput
{
    private static bool goodLastRead = false;
    internal static bool LastReadWasGood
    {
        get
        {
            return goodLastRead;
        }
    }

    internal static string ReadToWhiteSpace(bool skipLeadingWhiteSpace)
    {
        string input = "";

        char nextChar;
        while (char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
        {
            //accumulate leading white space if skipLeadingWhiteSpace is false:
            if (!skipLeadingWhiteSpace)
                input += nextChar;
        }
        //the first non white space character:
        input += nextChar;

        //accumulate characters until white space is reached:
        while (!char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
        {
            input += nextChar;
        }

        goodLastRead = input.Length > 0;
        return input;
    }

    internal static string ScanfRead(string unwantedSequence = null, int maxFieldLength = -1)
    {
        string input = "";

        char nextChar;
        if (unwantedSequence != null)
        {
            nextChar = '\0';
            for (int charIndex = 0; charIndex < unwantedSequence.Length; charIndex++)
            {
                if (char.IsWhiteSpace(unwantedSequence[charIndex]))
                {
                    //ignore all subsequent white space:
                    while (char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
                    {
                    }
                }
                else
                {
                    //ensure each character matches the expected character in the sequence:
                    nextChar = (char)System.Console.Read();
                    if (nextChar != unwantedSequence[charIndex])
                        return null;
                }
            }

            input = nextChar.ToString();
            if (maxFieldLength == 1)
                return input;
        }

        while (!char.IsWhiteSpace(nextChar = (char)System.Console.Read()))
        {
            input += nextChar;
            if (maxFieldLength == input.Length)
                return input;
        }

        return input;
    }
} 