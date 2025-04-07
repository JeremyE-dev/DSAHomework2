
namespace DSAHomework2
{
    public class Program
    {
        static void Main(string[] args)
        {


            // Homework2.printCoefficients(polynomial);



            //write a program to test the method parts a - c. Your test program should demonstrate
            //creating, displaying, and evaluating the following polynomials with the given values for x:

            // Test case 1:  x + 1.0 with x = 1.0

            // ** Set up terms **
            //  x + 1.0
            double[] coefficients_1 = { 1.0, 1.0};
            
            // x^2 - 1.0
            double[] coefficients_2 = { 1.0, 0.0, -1.0};
            
            // -3.0x^3 + 0.5x^2 - 2.0x
            double[] coefficients_3 = { -3.0, 0.5, -2.0};
            
            // -0.3125x^4 - 9.915x^2 - 7.75x - 40.0
            double[] coefficients_4 = { -.3125, 0.0, -9.915, -7.75, -40.0};

            // ** Create Lists of coefficients**
            SinglyLinkedList<double> polynomial_1 = Homework2.Create(coefficients_1);
            SinglyLinkedList<double> polynomial_2 = Homework2.Create(coefficients_2);
            SinglyLinkedList<double> polynomial_3 = Homework2.Create(coefficients_3);
            SinglyLinkedList<double> polynomial_4 = Homework2.Create(coefficients_4);

            // ** Display **
            Console.WriteLine("polynomial_1: should display x + 1.0 ");
            Homework2.Display(polynomial_1);
            Console.WriteLine();

            Console.WriteLine("polynomial_2: should display x^2 - 1.0 ");
            Homework2.Display(polynomial_2);
            Console.WriteLine();

            Console.WriteLine("polynomial_3: should display -3.0x^3 + 0.5x^2 - 2.0x ");
            Homework2.Display(polynomial_3);
            Console.WriteLine();

            Console.WriteLine("polynomial_4: should display -0.3125x^4 - 9.915x^2 - 7.75x - 40.0 ");
            Homework2.Display(polynomial_4);



            // ** Evaluate **

            // Test case 2: x^2 - 1.0 with x = 2.03

            // ** Create **
            // ** Display **
            // ** Evaluate **

            //Test case 3:  -3.0x^3 + 0.5x^2 - 2.0x

            // ** Create **
            // ** Display **
            // ** Evaluate **

            // Test case 4: -0.3125x^4 - 9.915x^2 - 7.75x - 40.0 with x = 123.45

            // ** Create **
            // ** Display **
            // ** Evaluate **

        }
    }
}
