using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class ExtraProgram
    {
        public static void MyExtraProgram()
        {
            // Prompt the user to enter a positive low number and validate the input
            double lowNumber = ValidatedLowNumber("Enter the positive and low number: ");

            // Prompt the user to enter a high number that is greater than the low number and validate the input
            double highNumber = ValidatedHighNumber("Enter the high number: ", lowNumber);

            // Calculate the difference between the high number and the low number
            double difference = highNumber - lowNumber;
            Console.WriteLine($"The difference between {highNumber} and {lowNumber} is {difference}");

            // Create a list of numbers between lowNumber and highNumber
            List<double> numbers = AskedList(lowNumber, highNumber);

            // Write the numbers to a file in reverse order
            FiledMyNumber(numbers, "numbers.txt");

            // Read the numbers back from the file and calculate the sum
            List<double> numbersFromFile = ReadNumbersFromFile("numbers.txt");
            double sum = numbersFromFile.Sum();
            Console.WriteLine($"The sum of the numbers is {sum}");

            // Print the prime numbers between lowNumber and highNumber
            Console.WriteLine("Prime numbers between {0} and {1}:", lowNumber, highNumber);
            foreach (double number in numbers)
            {
                if (IsPrime(number))
                {
                    Console.WriteLine(number);
                }
            }

            // Wait for the user to press Enter before closing the console window
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }

        // Method to validate that the input is a positive number
        static double ValidatedLowNumber(string prompt)
        {
            double number;
            while (true)
            {
                // Prompt the user to enter a number
                Console.Write(prompt);

                // Try to parse the input to a double and check if it is positive
                if (double.TryParse(Console.ReadLine(), out number) && IsPositive(number))
                {
                    // If valid, break the loop
                    break;
                }

                // If invalid, display an error message and repeat the loop
                Console.WriteLine("Invalid input. Please enter a positive number.");
            }
            return number;
        }

        // Method to validate that the input is greater than the low number
        static double ValidatedHighNumber(string prompt, double lowNumber)
        {
            double number;
            while (true)
            {
                // Prompt the user to enter a number
                Console.Write(prompt);

                // Try to parse the input to a double and check if it is greater than the low number
                if (double.TryParse(Console.ReadLine(), out number) && IsGreaterThanLow(number, lowNumber))
                {
                    // If valid, break the loop
                    break;
                }

                // If invalid, display an error message and repeat the loop
                Console.WriteLine($"Invalid input. Please enter a number greater than {lowNumber}.");
            }
            return number;
        }

        // Method to check if a number is positive
        static bool IsPositive(double number)
        {
            return number > 0;
        }

        // Method to check if a number is greater than the low number
        static bool IsGreaterThanLow(double number, double lowNumber)
        {
            return number > lowNumber;
        }

        // Method to create a list of numbers between lowNumber and highNumber
        static List<double> AskedList(double lowNumber, double highNumber)
        {
            List<double> numbers = new List<double>();
            for (double i = lowNumber; i <= highNumber; i++)
            {
                // Add the number to the list
                numbers.Add(i);
            }
            return numbers;
        }

        // Method to write the numbers to a file in reverse order
        static void FiledMyNumber(List<double> numbers, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    // Write each number to the file
                    writer.WriteLine(numbers[i]);
                }
            }
        }

        // Method to read numbers from a file
        static List<double> ReadNumbersFromFile(string filePath)
        {
            List<double> numbers = new List<double>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Parse each line to a double and add to the list
                    numbers.Add(double.Parse(line));
                }
            }
            return numbers;
        }

        // Method to check if a number is prime
        static bool IsPrime(double number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 1 != 0) return false; // Ensure the number is an integer
            int intNumber = (int)number;
            if (intNumber % 2 == 0) return false;
            for (int i = 3; i <= Math.Sqrt(intNumber); i += 2)
            {
                if (intNumber % i == 0) return false;
            }
            return true;
        }
    }
}
