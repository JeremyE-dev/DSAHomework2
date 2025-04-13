using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Transactions;

namespace DSAHomework2
{
    public class Homework2
    {
        public static SinglyLinkedList<double> Create(double[] coefficients)
        {
            // Create a polynomial using a singly linked list
            SinglyLinkedList<double> polynomial = new SinglyLinkedList<double>();
            foreach (double coefficient in coefficients)
            {
                AppendTerm(polynomial, coefficient);
            }

            return polynomial;
        }
    

        //a) Implement a method called AppendTerm
        // This method should append (insert at the end) the value "coefficient" to "polynomial"
        // For example, appending 3.1 to polynomial already containing 6.0 > 0.0 > -5.3
        // should result in the value 3.1 being added at the end: 6.0 > 0.0 > -5.3 > 3.1

        //** Assembling the polynomoial **
        // the entity assembling the polynomial, needs to know how to represent the missing terms
        // and that we are using standard form for the polynomial
        // so the terms are being implemented manually in the list

        // a "Term" is a coefficient, a variable, and an exponent

        // the position will determine the power, which will come into play when evaluating and displaying

        //** Examples and Test Cases

        // Test case 1:  x + 1.0 with x = 1.0
        // -- in this case if there is no coefficient but the term exists then, use 1 as a placeholder
        // -- because x^1 = 1.0x^1
        // -- list would be represented as 1.0 > 1.0

        // Test case 2: x^2 - 1.0 with x = 2.03
        // -- in this case if there is no coefficient but the term exists then, use 1 as a placeholder
        // -- list would be represented as 1.0 > 0.0 > -1.0
        // -- the 0.0 represents the x^1 term, which is not present in this case

        // Test case 3:  -3.0x^3 + 0.5x^2 - 2.0x
        // -- list would be represented as -3.0 > 0.5 > -2.0 > 0.0
        // -- the 0.0 represents the constant term

        // Test case 4: -0.3125x^4 - 9.915x^2 - 7.75x - 40.0 with x = 123.45
        // -- list would be represented as -0.3125 > 0.0 > -9.915 > -7.75 > -40.0
        // -- 0.0 is the placeholder for the x^3 term, which is not present in this case


        public static void AppendTerm(SinglyLinkedList<double> polynomial, double coefficient)
        {
            // Check if the polynomial is empty
            if (polynomial.Empty)
            {
                // If empty, set the head and tail to the new coefficient
                polynomial.InsertAfter(null, coefficient);
            }
            else
            {
                // If not empty, insert the new coefficient after the tail
                polynomial.InsertAfter(polynomial.Tail, coefficient);
            }
        }

        //b) Implement a method called Display
        // This method should print the polynomial in proper format.
        // for example, displaying polynomial 6.0 > 0.0 > -5.3 > 3.1 should
        // return 6.0x^3 - 5.3x + 3.1 being printed.

        // Test cases:
        // Test case 1:  x + 1.0 with 
        // Test case 2: x^2 - 1.0 with x = 2.03
        // Test case 3:  -3.0x^3 + 0.5x^2 - 2.0x
        // Test case 4: -0.3125x^4 - 9.915x^2 - 7.75x - 40.0 with x = 123.45

        public static void Display(SinglyLinkedList<double> polynomial)
        {
            // Test case 1:  x + 1.0 with x = 1.0
            // Test case 2: x^2 - 1.0 with x = 2.03
            // Test case 3:  -3.0x^3 + 0.5x^2 - 2.0x
            // Test case 4: -0.3125x^4 - 9.915x^2 - 7.75x - 40.0 with x = 123.45

            // all test cases have at least  2 terms, so there will always be one "x"

            SinglyLinkedList<double>.Element current = polynomial.Head;
            int exponent = polynomial.Size - 1;
            while (current != null && exponent >= 0)
            {
                // if the term is zero it is a placeholder, skip it, but decrement the exponent
                if (current.Data == 0.0)
                {
                    current = current.Next;
                    exponent--;
                    continue;
                }

                // 1 means either there no coefficient, but there is a variable and just print the "x" and the exponent (if there is one)
                // if the 1.0 is a constant then we print that
                else if (current.Data == 1.0)
                {
                    if (exponent > 1) // an exponent exists i.e. (x^3, x^2...)
                    {
                        Console.Write("x" + "^" + exponent);
                       
                    } else if (exponent == 1) // this is a case of the x^1 position
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write($"{current.Data:0.0}");
                    }

                } else
                {
                    // print the coefficient
                    if (exponent > 1)
                    {
                        // if its the first one and its negative then do not convert to math.abs
                        if (current == polynomial.Head && current.Data < 0)
                        {
                            Console.Write(
                                IsWhole(current.Data)
                                    ? $"{current.Data:0.0}x^{exponent}"
                                    : $"{current.Data}x^{exponent}"
                            );

                        } else
                        {
                            Console.Write(
                               IsWhole(current.Data)
                                   ? $"{Math.Abs(current.Data):0.0}x^{exponent}"
                                   : $"{Math.Abs(current.Data)}x^{exponent}"
                            );
                        }
                    }
                    else if (exponent == 1)
                    {
                        if (current == polynomial.Head && current.Data < 0)
                        {

                            Console.Write(
                              IsWhole(current.Data)
                                  ? $"{current.Data:0.0}x"
                                  : $"{current.Data}x^"
                            );

                        } else
                        {
                            Console.Write(
                             IsWhole(current.Data)
                                 ? $"{Math.Abs(current.Data):0.0}x"
                                 : $"{Math.Abs(current.Data)}x^"
                             );
                        }
                    }
                    else
                    {
                        if (current == polynomial.Head && current.Data < 0)
                        {

                            Console.Write($"{current.Data:0.0}"); 
                        }
                        else
                        {
                            Console.Write($"{Math.Abs(current.Data):0.0}"); 
                        }
                    }
                }
                
                // Handle the  the sign (+/-) after the current term
                // if (current.Next != null && current.Next.Data != 0 && exponent != 1)
                if (current.Next != null)
                {
                    // edge case if the last term is a 0.0 placeholder
                    // do not want a +/- sign in that case
                    if (current.Next == polynomial.Tail && current.Next.Data == 0 && exponent == 1)
                    {

                    }
                    // check the sign of the next term
                    else if (current.Next.Data > 0)
                    {
                        Console.Write(" + ");
                    }
                    else
                    {
                        Console.Write(" - ");
                        current.Next.Data = Math.Abs(current.Next.Data);
                    }
                }

                exponent--;
                current = current.Next;
            }
            Console.WriteLine();
        }

        //c) Implement a method called Evaluate
        // This method should evaluate the polynomial at a given value of x and return the result
        // For example, given polynomial 6.0 > 0.0 > -5.3 > 3.1 at x = 2
        // and x having value 7.0 the function should return 2024.0
        // (The result of evaluating 6.0*7.0^3 - 5.3*7.0 + 3.1 )

        // Test case 1:  x + 1.0 with x = 1.0
        // Test case 2: x^2 - 1.0 with x = 2.03 
        // Test case 3:  -3.0x^3 + 0.5x^2 - 2.0x with x = 05.0
        // Test case 4: -0.3125x^4 - 9.915x^2 - 7.75x - 40.0 with x = 123.45

        // Each element of the list represents the coefficient for x^(length of the list - position in list - 1). So the first element of the list above is the coefficient for x^(4 - 0 - 1 = 3).

        public static double Evaluate(SinglyLinkedList<double> polynomial, double variable)
        {
            double result = 0.0;

            // set the current term to head of polynomial
            // This allows us to track the where we are in the linked list
            SinglyLinkedList<double>.Element current = polynomial.Head;

            //this is the location of the current term in the polynomial
            // acts like an index, so we can calculate the exponent
            int position = 0;
            double currentTerm = 0.0;

            while (current != null)
            {

                if (current.Data == 0)
                {
                    current = current.Next;
                    position++;
                    continue;
                }

                currentTerm = Homework2.CalculateCurrentTerm(current.Data, position, polynomial.Size, variable);
                result += currentTerm;
                current = current.Next;
                position++;
            }
            return result;
        }

        //Helper methods
        private static bool IsWhole(double number)
        {
            return number % 1 == 0;

        }

        private static double CalculateCurrentTerm(double coefficient,int position, int lengthOfList, double variable)
        {
            //calculate the exponent
            // exponent will either be 4, 3, 2, 1, or 0
            double result = 0.0; ;
            int exponent = lengthOfList - position - 1;

            double variableToExponent = Math.Pow(variable, exponent);
            return result = coefficient * variableToExponent;

        }

        // Helper method for texting coefficients are listed correctly
        private static void printCoefficients(SinglyLinkedList<double> polynomial)
        {
            // Print the coefficients of the polynomial
            SinglyLinkedList<double>.Element current = polynomial.Head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }

    }
}
