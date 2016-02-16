namespace Sunlight
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int size = 3 * n;
            int half = size / 2;
            int dotsCount = 1;

            for (int i = 0; i < size; i++)
            {
                if (i == 0 || i == size - 1)
                {
                    Console.Write("{0}{1}{0}", new string('.',half), '*');
                }
                else if (i < n)
                {
                    Console.Write(new string('.', dotsCount));
                    Console.Write('*');
                    Console.Write(new string('.', half - dotsCount - 1));
                    Console.Write('*');
                    Console.Write(new string('.', half - dotsCount - 1));
                    Console.Write('*');
                    Console.Write(new string('.', dotsCount));

                    dotsCount++;
                }
                else if (i != half && i < 2 * n)
                {
                    Console.Write(new string('.', n));
                    Console.Write(new string('*', n));
                    Console.Write(new string('.', n));
                }
                else if (i == half)
                {
                    Console.Write(new string('*', size));
                }
                else
                {
                    dotsCount--;

                    Console.Write(new string('.', dotsCount));
                    Console.Write('*');
                    Console.Write(new string('.', half - dotsCount - 1));
                    Console.Write('*');
                    Console.Write(new string('.', half - dotsCount - 1));
                    Console.Write('*');
                    Console.Write(new string('.', dotsCount));
                }

                Console.WriteLine();
            }
        }
    }
}
