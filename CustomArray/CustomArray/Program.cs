using System;

namespace CustomArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new CustomArray<int>(-7, 10);
            for(int i = -7; i < 10; i++)
            {
                arr[i] = i;
            }
            foreach(int elem in arr)
            {
                Console.WriteLine(elem);
            }
        }

    }
}
