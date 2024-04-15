using System;
using System.IO;

namespace Lab0
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get
            int low = GetPositiveInt("Enter a positive low number:");
            int high = GetIntGreaterThan("Enter a high number greater than the low number:", low);

            // Result
            int difference = high - low;
            Console.WriteLine($"The difference is: {difference}");

            // array
            int[] numbers = new int[high - low + 1];
            for (int i = 0; i <= high - low; i++)
            {
                numbers[i] = low + i;
            }

            WriteNumbersToFile(numbers, "numbers.txt");

            // Reading them from the filw
            int sum = CalculateSumFromFile("numbers.txt");
            Console.WriteLine($"The sum of the numbers is: {sum}");

            // Checking for prime numbers 
            for (int num = low; num <= high; num++)
            {
                if (IsPrime(num))
                {
                    Console.WriteLine($"{num} is prime.");
                }
            }
        }

        static int GetPositiveInt(string prompt)
        {
            int number;
            do
            {
                Console.WriteLine(prompt);
                number = int.Parse(Console.ReadLine());
            } while (number <= 0);
            return number;
        }

        static int GetIntGreaterThan(string prompt, int minValue)
        {
            int number;
            do
            {
                Console.WriteLine(prompt);
                number = int.Parse(Console.ReadLine());
            } while (number <= minValue);
            return number;
        }

        static void WriteNumbersToFile(int[] numbers, string filename)
        {
            using (StreamWriter file = new StreamWriter(filename))
            {
                for (int i = numbers.Length - 1; i >= 0; i--)
                {
                    file.WriteLine(numbers[i]);
                }
            }
        }

        static int CalculateSumFromFile(string filename)
        {
            int sum = 0;
            string[] fileNumbers = File.ReadAllLines(filename);
            foreach (string num in fileNumbers)
            {
                sum += int.Parse(num);
            }
            return sum;
        }

        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
