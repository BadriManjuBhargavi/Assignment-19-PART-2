using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_19_PART_2
{
    
// Step 1: Create a generic delegate named Operation<T> that represents a method with two parameters of type T and a return type of T.
delegate T Operation<T>(T a, T b);

    public class Program
    {
        // Step 2: Implement four static methods: Add, Subtract, Multiply, and Divide.
        // Each method should take two parameters of type T as input and return the result of the corresponding operation.

        static T Add<T>(T a, T b)
        {
            dynamic num1 = a;
            dynamic num2 = b;
            return num1 + num2;
        }

        static T Subtract<T>(T a, T b)
        {
            dynamic num1 = a;
            dynamic num2 = b;
            return num1 - num2;
        }

        static T Multiply<T>(T a, T b)
        {
            dynamic num1 = a;
            dynamic num2 = b;
            return num1 * num2;
        }

        static T Divide<T>(T a, T b)
        {
            dynamic num1 = a;
            dynamic num2 = b;

            if (num2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            return num1 / num2;
        }

        public static void Main(string[] args)
        {
            // Step 3: Create instances of Operation<T> delegate for each of the four operations with appropriate type arguments.

            // For integer operations:
            Operation<int> addIntDelegate = Add;
            Operation<int> subtractIntDelegate = Subtract;
            Operation<int> multiplyIntDelegate = Multiply;
            Operation<int> divideIntDelegate = Divide;

            // For double operations:
            Operation<double> addDoubleDelegate = Add;
            Operation<double> subtractDoubleDelegate = Subtract;
            Operation<double> multiplyDoubleDelegate = Multiply;
            Operation<double> divideDoubleDelegate = Divide;

            // Step 4: Ask the user to input two values of type T (int or double).

            Console.Write("Enter the first value: ");
            string input1 = Console.ReadLine();

            Console.Write("Enter the second value: ");
            string input2 = Console.ReadLine();

            // Assuming the user will provide valid numeric input for simplicity.
            // In a real application, additional error handling and validation should be done.

            // Convert user input to appropriate types (int or double) based on the generic delegate used.
            dynamic value1, value2;
            bool isDouble = false;
            if (addIntDelegate != null)
            {
                value1 = int.Parse(input1);
                value2 = int.Parse(input2);
            }
            else
            {
                value1 = double.Parse(input1);
                value2 = double.Parse(input2);
                isDouble = true;
            }

            // Step 5: Prompt the user to choose an operation.

            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");

            Console.Write("Enter your choice (1/2/3/4): ");
            int choice = int.Parse(Console.ReadLine());

            dynamic result = null;

            // Step 6: Based on the user's choice, call the corresponding method through the generic delegate and display the result.
            switch (choice)
            {
                case 1:
                    result = isDouble ? addDoubleDelegate(value1, value2) : addIntDelegate(value1, value2);
                    break;
                case 2:
                    result = isDouble ? subtractDoubleDelegate(value1, value2) : subtractIntDelegate(value1, value2);
                    break;
                case 3:
                    result = isDouble ? multiplyDoubleDelegate(value1, value2) : multiplyIntDelegate(value1, value2);
                    break;
                case 4:
                    try
                    {
                        result = isDouble ? divideDoubleDelegate(value1, value2) : divideIntDelegate(value1, value2);
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            Console.WriteLine($"Result: {result}");
        }
    }

}
