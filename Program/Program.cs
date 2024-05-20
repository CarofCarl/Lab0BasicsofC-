using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter a positive low number and validate the input
            int lowNumber = ValidatedLowNumber("Enter the positive and low number: ");

            // Prompt the user to enter a high number that is greater than the low number and validate the input
            int highNumber = ValidatedHighNumber("Enter the high number: ", lowNumber);

            // Calculate the difference between the high number and the low number
            int difference = highNumber - lowNumber;
            Console.WriteLine($"The difference between {highNumber} and {lowNumber} is {difference}");

            // Create an array of numbers between lowNumber and highNumber
            int[] numbers = Array(lowNumber, highNumber);

            // Write the numbers to a file in reverse order
            Filednumber(numbers, "numbers.txt");

            // Wait for the user to press Enter before closing the console window
            Console.ReadLine();
        }

        // Method to validate that the input is a positive number
        static int ValidatedLowNumber(string prompt)
        {
            int number;
            while (true)
            {
                // Prompt the user to enter a number
                Console.Write(prompt);

                // Try to parse the input to an integer and check if it is positive
                if (int.TryParse(Console.ReadLine(), out number) && IsPositive(number))
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
        static int ValidatedHighNumber(string prompt, int lowNumber)
        {
            int number;
            while (true)
            {
                // Prompt the user to enter a number
                Console.Write(prompt);

                // Try to parse the input to an integer and check if it is greater than the low number
                if (int.TryParse(Console.ReadLine(), out number) && IsGreaterThanLow(number, lowNumber))
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
        static bool IsPositive(int number)
        {
            return number > 0;
        }

        // Method to check if a number is greater than the low number
        static bool IsGreaterThanLow(int number, int lowNumber)
        {
            return number > lowNumber;
        }

        // Method to create an array of numbers between lowNumber and highNumber
        static int[] Array(int lowNumber, int highNumber)
        {
            int size = highNumber - lowNumber + 1;
            int[] numbers = new int[size];
            for (int i = 0; i < size; i++)
            {
                // Fill the array with numbers from lowNumber to highNumber
                numbers[i] = lowNumber + i;
            }
            return numbers;
        }

        // Method to write the numbers to a file in reverse order
        static void Filednumber(int[] numbers, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = numbers.Length - 1; i >= 0; i--)
                {
                    // Write each number to the file
                    writer.WriteLine(numbers[i]);
                }
            }
        }
    }
}
