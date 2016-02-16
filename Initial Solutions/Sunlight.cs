using System;

public class Sunlight
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int size = n * 3;
        int half = size / 2;

        int sideDotsCounter = 1;

        for (int i = 0; i < size; i++)
        {
            if (i == 0 || i == size - 1)
            {
                Console.Write(new string('.', half));
                Console.Write("*");
                Console.Write(new string('.', half));
            }
            else if (i < n)
            {
                Console.Write(new string('.', sideDotsCounter));
                Console.Write("*");
                Console.Write(new string('.', half - sideDotsCounter - 1));
                Console.Write("*");
                Console.Write(new string('.', half - sideDotsCounter - 1));
                Console.Write("*");
                Console.Write(new string('.', sideDotsCounter));

                sideDotsCounter++;
            }
            else if (i < 2 * n && i != half)
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
                sideDotsCounter--;

                Console.Write(new string('.', sideDotsCounter));
                Console.Write("*");
                Console.Write(new string('.', half - sideDotsCounter - 1));
                Console.Write("*");
                Console.Write(new string('.', half - sideDotsCounter - 1));
                Console.Write("*");
                Console.Write(new string('.', sideDotsCounter));
            }

            Console.WriteLine();
        }
    }
}