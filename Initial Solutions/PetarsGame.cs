using System;
using System.Numerics;

public class PetarsGame
{
    public static void Main()
    {
        ulong startNumber = ulong.Parse(Console.ReadLine());
        ulong endNumber = ulong.Parse(Console.ReadLine());
        string replacement = Console.ReadLine();

        BigInteger sum = 0;

        for (ulong currentNumber = startNumber; currentNumber < endNumber; currentNumber++)
        {
            if (currentNumber % 5 == 0)
            {
                sum += currentNumber;
            }
            else
            {
                sum += currentNumber % 5;
            }
        }

        string result = string.Empty;
        result = sum.ToString();

        if (sum % 2 == 0)
        {
            result = result.Replace(result[0].ToString(), replacement);
        }
        else
        {
            result = result.Replace(result[result.Length - 1].ToString(), replacement);
        }

        Console.WriteLine(result);
    }
}