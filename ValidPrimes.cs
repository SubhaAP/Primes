using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public class ValidPrimes
    {
        private List<int> validPrimeNumbers;   

        public ValidPrimes()
        {
            validPrimeNumbers = new List<int>();
        }

        public List<int> FindValidPrimesBelowThousand()
        {
            validPrimeNumbers = FindValidPrimeNumbers();
            return validPrimeNumbers;
        }

        private List<int> FindValidPrimeNumbers()
        {
            List<int> fourValidPrimes = new List<int>();
            List<int> primeNumbers = FindAllPrimesBelowThousand();
            //Console.WriteLine(primeNumbers.Count());
            Int64 productOfPrimes;           
            Boolean isValid = false;
            List<int> digits = null;                    
            
            for (int a = primeNumbers.Count() - 1; a > 0; a--)
            {
                for (int b = primeNumbers.Count() - 2; b > 0; b--)
                {
                    for (int c = primeNumbers.Count() - 3; c > 0; c--)
                    {
                        for (int d = primeNumbers.Count() - 4; d > 0; d--)
                        {
                            productOfPrimes = 1;
                            productOfPrimes = productOfPrimes * primeNumbers[a] * primeNumbers[b] * primeNumbers[c] * primeNumbers[d];
                            digits = GetDigits(productOfPrimes);
                            digits.Reverse();
                            if (digits.Count() == 12)
                            {
                                isValid = IsValidProduct(digits);
                                if (isValid)
                                {
                                    fourValidPrimes.Add(primeNumbers[a]);
                                    fourValidPrimes.Add(primeNumbers[b]);
                                    fourValidPrimes.Add(primeNumbers[c]);
                                    fourValidPrimes.Add(primeNumbers[d]);
                                    return fourValidPrimes;
                                }

                            }
                        }                        
                    }                    
                }                
            }
            return fourValidPrimes;
        }

        private List<int> FindAllPrimesBelowThousand()
        {
            List<int> primeNumbers = new List<int>();
            for (int i = 1; i < 999; i++)
            {
                if (IsPrime(i))
                {
                    primeNumbers.Add(i);
                }
            }
            return primeNumbers;
        }

        private Boolean IsPrime(int number)
        {
            Boolean isPrime = true;
            for (int i = 1; i <= number; i++)
            {
                if (number%i == 0 && i != 1 && i != number)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }

        private List<int> GetDigits(Int64 product)
        {
            List<int> digits = new List<int>();
            Int64 digit;            
            Int64 numberToDivide = product;
            do
            {
                digit = numberToDivide % 10;
                numberToDivide = numberToDivide / 10;
                digits.Add((int)digit);
            } while (numberToDivide != 0);
            return digits;
        }

        private Boolean IsValidProduct(List<int> digits)
        {
            Boolean isValid = true;           
            for (int n=0; n < digits.Count()-1; n++)
            {
                if(digits[n] != digits[n+1] && digits[n]+1 != digits[n + 1])
                {
                    isValid = false;
                    break;
                }                
            }            
            return isValid;
        }
    }
}
