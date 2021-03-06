﻿namespace CompoundInterest
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            decimal tvPrice = decimal.Parse(Console.ReadLine());
            int loanYears = int.Parse(Console.ReadLine());
            decimal bankInterest = decimal.Parse(Console.ReadLine());
            decimal friendInterest = decimal.Parse(Console.ReadLine());

            decimal bankLoan = tvPrice * (decimal)(Math.Pow(1 + (double)bankInterest, loanYears));
            decimal friendLoan = tvPrice * (1 + friendInterest);

            if (bankLoan < friendLoan)
            {
                Console.WriteLine("{0:F2} Bank", bankLoan);
            }
            else
            {
                Console.WriteLine("{0:F2} Friend", friendLoan);
            }
        }
    }
}
