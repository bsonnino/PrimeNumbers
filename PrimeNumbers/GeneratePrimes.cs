using System;
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
        
        public static int[] GetPrimes(int maxValue)
        {
            if (maxValue < 2)
                return new int[0];

            bool[] isPrimeArray = InitializeArray(maxValue);
            Sieve(isPrimeArray);
            return MovePrimes(isPrimeArray);
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
                .Range(0, sizeOfArray+1)
                .Select(n => true)
                .ToArray();
        }
    }
}