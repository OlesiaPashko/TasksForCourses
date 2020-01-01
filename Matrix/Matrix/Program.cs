using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m1 = new Matrix(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            Matrix m2 = new Matrix(new int[,] { { 1, 8, 6 }, { 5, 5, 2 }, { 9, 3, 5 } });
            Console.WriteLine("First matrix:");
            Console.WriteLine(m1);
            Console.WriteLine("Second matrix:");
            Console.WriteLine(m2);
            Console.WriteLine("result of m1+m2:");
            Console.WriteLine(m1 + m2);
            Console.WriteLine("result of m1-m2:");
            Console.WriteLine(m1 - m2);
            Console.WriteLine("result of m1*m2:");
            Console.WriteLine(m1 * m2);
            m1.WriteToFile("d:\\matrix.txt");
            Console.WriteLine("reading from file matrix:");
            m1.ReadFromFile("d:\\matrix.txt");
            Console.Read();
        }
    }
}
