namespace PetarGame
{
    using System;
    using System.Numerics;

    class Program
    {
        static void Main(string[] args)
        {
            checked
            {
                ulong start = ulong.Parse(Console.ReadLine());
                ulong end = ulong.Parse(Console.ReadLine());

                string symbol = Console.ReadLine();
                BigInteger sum = new BigInteger();

                for (ulong i = start; i < end; i++)
                {
                    if (i % 5 == 0)
                    {
                        sum += i;
                    }
                    else
                    {
                        sum += i % 5;
                    }
                }

                string result = sum.ToString();

                if (sum % 2 == 0)
                {
                    string mask = result[0].ToString();

                    result = result.Replace(mask, symbol);
                }
                else
                {
                    string mask = result[result.Length - 1].ToString();

                    result = result.Replace(mask, symbol);
                }

                Console.WriteLine(result);

            }

        }
    }
}
