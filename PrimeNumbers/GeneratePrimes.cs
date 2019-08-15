using System;
using System.Linq;

namespace PrimeNumbers
{
    /**
           * This class Generates prime numbers up to a user specified
           * maximum. The algorithm used is the Sieve of Eratosthenes.
           *  https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes   
*/
    public static class GeneratePrimes
    {
        
        public static int[] PrimesSmallerOrEqual(this int maxValue)
        {
            if (maxValue < 2)
                return new int[0];

            return maxValue.InitializeArray()
                .Sieve()
                .MovePrimes();
        }

        private static int[] MovePrimes(this bool[] isPrimeArray) =>
            isPrimeArray
                .Select((p, i) => new { Index = i, IsPrime = p })
                .Where(v => v.IsPrime)
                .Select(v => v.Index)
                .ToArray();

        private static bool[] Sieve(this bool[] isPrimeArray)
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
            return isPrimeArray;
        }

        private static bool[] InitializeArray(this int sizeOfArray)
        {
            return Enumerable
                .Range(0, sizeOfArray+1)
                .Select(n => true)
                .ToArray();
        }
    }
}