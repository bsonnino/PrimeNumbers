﻿using System;
using System.Linq;

namespace PrimeNumbers
{
    /**
           * This class Generates prime numbers up to a user specified
           * maximum. The algorithm used is the Sieve of Eratosthenes.
           *  https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes   
*/
    public class GeneratePrimes
    {
        /**
        * @param maxValue is the generation limit.
*/
        public static int[] generatePrimes(int maxValue)
        {
            if (maxValue < 2)
                return new int[0];

            // declarations
            int sizeOfArray = maxValue + 1; // size of array
            bool[] isPrimeArray = new bool[sizeOfArray];
            int i;

            isPrimeArray = InitializeArray(sizeOfArray);
            int j;
            Sieve(isPrimeArray);
            int[] primes = MovePrimes(isPrimeArray);
            return primes; // return the primes
        }

        private static int[] MovePrimes(bool[] isPrimeArray) =>
            isPrimeArray
                .Select((p, i) => new { Index = i, IsPrime = p })
                .Where(v => v.IsPrime)
                .Select(v => v.Index)
                .ToArray();

        private static void Sieve(bool[] isPrimeArray)
        {
            var sizeOfArray = isPrimeArray.Length;

            isPrimeArray[0] = isPrimeArray[1] = false;

            for (int i = 2; i < Math.Sqrt(sizeOfArray) + 1; i++)
            {
                if (isPrimeArray[i]) // if i is uncrossed, cross its multiples.
                {
                    for (int j = 2 * i; j < sizeOfArray; j += i)
                        isPrimeArray[j] = false;
                }
            }
        }

        private static bool[] InitializeArray(int sizeOfArray)
        {
            return Enumerable
                .Range(0, sizeOfArray)
                .Select(n => true)
                .ToArray();
        }
    }
}