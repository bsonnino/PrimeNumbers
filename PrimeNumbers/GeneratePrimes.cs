using System;

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

            // initialize array to true.
            for (i = 0; i < sizeOfArray; i++)
                isPrimeArray[i] = true;
            // get rid of known non-primes
            isPrimeArray[0] = isPrimeArray[1] = false;
            // sieve
            int j;
            for (i = 2; i < Math.Sqrt(sizeOfArray) + 1; i++)
            {
                if (isPrimeArray[i]) // if i is uncrossed, cross its multiples.
                {
                    for (j = 2 * i; j < sizeOfArray; j += i)
                        isPrimeArray[j] = false; // multiple is not prime
                }
            }
            // how many primes are there?
            int count = 0;
            for (i = 0; i < sizeOfArray; i++)
            {
                if (isPrimeArray[i])
                    count++; // bump count.
            }
            int[] primes = new int[count];
            // move the primes into the result
            for (i = 0, j = 0; i < sizeOfArray; i++)
            {
                if (isPrimeArray[i]) // if prime
                    primes[j++] = i;
            }
            return primes; // return the primes
        }
    }
}