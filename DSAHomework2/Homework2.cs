using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

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
                // Append each coefficient to the polynomial
                AppendTerm(polynomial, coefficient);
            }

            return polynomial;
        }

        public static void printCoefficients(SinglyLinkedList<double> polynomial)
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

        //a) Implement a method called AppendTerm
        // This method should append (insert at the end) the value "coefficient" to "polynomial"
        // For example, appending 3.1 to polynomial already containing 6.0 > 0.0 > -5.3
        // should result in the value 3.1 being added at the end: 6.0 > 0.0 > -5.3 > 3.1

        // the entity assembling the polynomial, needs to know how to represent the missing terms
        // and that we are using standard form for the polynomial
        // so the terms are being implemented manually in the list
        public static void AppendTerm(SinglyLinkedList<double> polynomial, double coefficient)
        {
            // examples:
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


            // the position will determine the power, which will come into play when evaluating and diplaying
            // a "Term" is a coefficient, a variable, and an exponent


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

        public static void Display(SinglyLinkedList<double> polynomial)
        {
            // Test case 1:  x + 1.0 with x = 1.0
            // Test case 2: x^2 - 1.0 with x = 2.03
            // Test case 3:  -3.0x^3 + 0.5x^2 - 2.0x
            // Test case 4: -0.3125x^4 - 9.915x^2 - 7.75x - 40.0 with x = 123.45

            // if the number is whole then print

            // print the coefficients
            SinglyLinkedList<double>.Element current = polynomial.Head;
            int exponent = polynomial.Size - 1;
            while (current != null && exponent >= 0)
            {
                // all test cases have at least  2 terms, so there will always be one "x"
                // position relative to size
                // is the term zero?

                // if the term is zero it is a placeholder, skip it, but decrement the exponent
                if (current.Data == 0.0)
                {
                    current = current.Next;
                    exponent--;
                    continue;
                }

                // 1 means no coefficient, but there is a variable, just print the "x" and the exponent if there is one
                // this is a special or placeholder case where the coefficient is 1.0 used to indicate that ther is 
                // no calcuable coefficient
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
                            //IsWhole(current.Data) ? Console.Write($"{current.Data:0.0}" + "x" + "^" + exponent) : Console.Write(current.Data + "x" + "^" + exponent);

                        } else
                        {
                            Console.Write(
                               IsWhole(current.Data)
                                   ? $"{Math.Abs(current.Data):0.0}x^{exponent}"
                                   : $"{Math.Abs(current.Data)}x^{exponent}"
                               );

                            // Console.Write(Math.Abs(current.Data) + "x" + "^" + exponent);
                        }
                    }
                    else if (exponent == 1)
                    {
                        if (current == polynomial.Head && current.Data < 0)
                        {
                            // Console.Write(current.Data + "x");

                            Console.Write(
                              IsWhole(current.Data)
                                  ? $"{current.Data:0.0}x"
                                  : $"{current.Data}x^"
                              );


                        } else
                        {
                            // Console.Write(Math.Abs(current.Data) + "x");
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

                            Console.Write($"{current.Data:0.0}"); // Interpolated string with format
                        }
                        else
                        {
                            Console.Write($"{Math.Abs(current.Data):0.0}"); // Interpolated string with format
                        }

                        ////Console.Write($"{current.Data:0.0}"); // Interpolated string with format
                        //Console.Write($"{Math.Abs(current.Data):0.0}"); // Interpolated string with format
                    }
                }

                // if the term is not the last one
                //this deals with the sign after the current term given term
                if (current.Next != null)
                {
                    // check the sign of the next term
                    if (current.Next.Data > 0)
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

        public static double Evaluate(SinglyLinkedList<double> polynomial, double x)
        {
            return 0.0;
        }

        //Helper methods
        private static bool IsWhole(double number)
        {
            return number % 1 == 0;

        }
    }
}
