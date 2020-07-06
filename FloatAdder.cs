using System;
using System.IO;
using System.Numerics;


namespace LargeNumbersCalculator
{
    class FloatAdder
    {
        private static Random random = new Random();
        private const int MinNumberOfDigits = 1000;
        private const int MaxNumberOfDigits = 10000;

        public static string SumValuesFromFiles(String path)
        {
            string[] lines = File.ReadAllLines(path);

            BigInteger firstNumber = BigInteger.Parse(lines[0]);
            BigInteger secondNumber = BigInteger.Parse(lines[1]);

            Console.WriteLine("\nPierwsza wylosowana liczba:\n");
            Console.WriteLine(firstNumber);
            Console.WriteLine("\nDruga wylosowana liczba:\n");
            Console.WriteLine(secondNumber);

            return (firstNumber + secondNumber).ToString();
        }

        public static string SumGeneratedValues()
        {
            string firstString = GenerateLongValue();
            string secondString = GenerateLongValue();

            int firstStringFloatingPoint = firstString.IndexOf(".");
            int secondStringFloatingPoint = secondString.IndexOf(".");

            string firstStringInteger = firstString.Substring(0, firstStringFloatingPoint);
            string firstStringFractional = firstString.Substring(firstStringFloatingPoint + 1, firstString.Length - firstStringInteger.Length - 1);

            BigInteger firstNumberInteger = BigInteger.Parse(firstStringInteger);
            BigInteger firstNumberFractional = BigInteger.Parse(firstStringFractional);

            string secondStringInteger = secondString.Substring(0, secondStringFloatingPoint);
            string secondStringFractional = secondString.Substring(secondStringFloatingPoint + 1, secondString.Length - secondStringInteger.Length - 1);

            BigInteger secondNumberInteger = BigInteger.Parse(secondStringInteger);
            BigInteger secondNumberFractional = BigInteger.Parse(secondStringFractional);

            BigInteger integerPartSum = firstNumberInteger + secondNumberInteger;

            int fractionalPartLength;
            if (firstStringFractional.Length > secondStringFractional.Length)
                fractionalPartLength = firstStringFractional.Length;
            else fractionalPartLength = secondStringFractional.Length;

            //TODO dodawanie części ułamkowej, dodawanie całości do części całkowitej, złączenie

            /*            int difference = fractionalPartSum.Length - fractionalPartLength;
                        BigInteger partToAdd;
                        BigInteger partToLeave;
                        string sum;
                        if (difference > 0)
                        {
                            partToAdd = BigInteger.Parse(fractionalPartSum.Substring(0, fractionalPartSum.Length - fractionalPartLength));
                            partToLeave = BigInteger.Parse(fractionalPartSum.Substring(fractionalPartSum.Length - fractionalPartLength, fractionalPartSum.Length));
                            integerPartSum += partToAdd;
                            sum = integerPartSum.ToString() + "." + partToLeave;
                        }
                        else sum = integerPartSum + "." + fractionalPartSum;
                        Console.WriteLine("\nSUMA:" + sum);
                        Console.WriteLine("\n");*/

            return "";
        }

        public static string GenerateLongValue()
        {
            int numberOfDigits = random.Next(MinNumberOfDigits, MaxNumberOfDigits);
            string generatedNumber = "";

            for (int i = 0; i < numberOfDigits; i++)
            {
                generatedNumber += GenerateDigit();
            }

            int pointerPosition = random.Next(0, generatedNumber.Length - 2) + 1;
            Console.WriteLine("POINER:" + pointerPosition);
            generatedNumber = generatedNumber.Substring(0, pointerPosition) + "." + generatedNumber.Substring(pointerPosition);
            Console.WriteLine(generatedNumber.IndexOf("."));
            return generatedNumber;
        }

        public static string GenerateDigit()
        {
            return random.Next(0, 10).ToString();
        }
    }
}
