using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples
{
    class Program
    {        
        static void Main(string[] args)
        {
            ValidPrimes validPrimes = new ValidPrimes();
            List<int> validPrimesResult = validPrimes.FindValidPrimesBelowThousand();
            
            if (validPrimesResult.Count() > 0)
            {
                Console.WriteLine("PRIMES BELOW 1000 WHOSE PRODUCT's DIGITS ARE EITHER EQUAL or IN SEQUENTIAL ORDER");
                Console.WriteLine("---------------------------------------------------------------------------------");
                validPrimesResult.ForEach(prime => Console.Write(prime + " "));
            }
            else
            {
                Console.WriteLine("There are no primes below 1000 whose product's digits are either equal or in sequential order");
            }
                                    
            Console.Read();            
        }       
    }
   
}
