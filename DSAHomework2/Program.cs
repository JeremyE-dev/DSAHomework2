
namespace DSAHomework2
{
    public class Program
    {
        static void Main(string[] args)
        {

            // ** Set up terms **
            
            //  x + 1.0
            double[] coefficients_1 = { 1.0, 1.0};
            
            // x^2 - 1.0
            double[] coefficients_2 = { 1.0, 0.0, -1.0};
            
            // -3.0x^3 + 0.5x^2 - 2.0x
            double[] coefficients_3 = { -3.0, 0.5, -2.0, 0.0};
            
            // -0.3125x^4 - 9.915x^2 - 7.75x - 40.0
            double[] coefficients_4 = { -.3125, 0.0, -9.915, -7.75, -40.0};

            // ** Create lists of coefficients **
            
            SinglyLinkedList<double> polynomial_1 = Homework2.Create(coefficients_1);
            SinglyLinkedList<double> polynomial_2 = Homework2.Create(coefficients_2);
            SinglyLinkedList<double> polynomial_3 = Homework2.Create(coefficients_3);
            SinglyLinkedList<double> polynomial_4 = Homework2.Create(coefficients_4);

            // ** Evaluate results **
            
            double result_1 = Homework2.Evaluate(polynomial_1, 1.0);
            double result_2 = Homework2.Evaluate(polynomial_2, 2.03);
            double result_3 = Homework2.Evaluate(polynomial_3, 5.0);
            double result_4 = Homework2.Evaluate(polynomial_4, 123.45);

            // ** Display polynomials **
            
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
            Console.WriteLine();

            // **  Print evaluated results **

            // Test case 1:  x + 1.0 with x = 1.0
            Console.WriteLine($"Expected Result of polynomial_1: 2.0");
            Console.WriteLine($"Actual Result of polynomial_1: {result_1}");
            Console.WriteLine();

            // Test case 2: x^2 - 1.0 with x = 2.03
            Console.WriteLine($"Expected Result of polynomial_2:  3.1209");
            Console.WriteLine($"Actual Result of polynomial_2: {result_2}");
            Console.WriteLine();

            //Test case 3:  -3.0x^3 + 0.5x^2 - 2.0x with x = 5.0
            Console.WriteLine($"Expected Result of polynomial_3: -372.5");
            Console.WriteLine($"Actual Result of polynomial_3: {result_3}");
            Console.WriteLine();

            // Test case 4: -0.3125x^4 - 9.915x^2 - 7.75x - 40.0 with x = 123.45
            Console.WriteLine($"Expect result of polynomial_4: -72,731,671.68625821");
            Console.WriteLine($"Actual Result of polynomial_4: {result_4} ");
            Console.WriteLine();

        }
    }
}
