using System;

namespace Polynomial
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial p1 = new Polynomial(new double[] { 2, 3, 4 });
            Polynomial p2 = new Polynomial(new double[] { 1, 6, 7, 10 });
            Console.WriteLine($"p1= {p1.ToString()}");
            Console.WriteLine($"p2= {p2.ToString()}");

            Console.WriteLine($"p1-p2 = {(p1 - p2).ToString()}");
            Console.WriteLine($"p1+p2 = {(p1 + p2).ToString()}");
            Console.WriteLine($"p1*p2 = {(p1 * p2).ToString()}");

            Console.WriteLine($"Get koef of x^2 in p1 (p1[2] = {p1[2]})");
            Console.WriteLine("Set koef of x^2 in p1 to 5 (p1[2]=5)");
            p1[2] = 5;
            Console.WriteLine($"Get koef of x^2 in p1 (p1[2] = {p1[2]})");
            Console.WriteLine($"Power of p1={p1.Power}");
        }
    }
}
