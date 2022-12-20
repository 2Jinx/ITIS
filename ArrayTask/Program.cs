using System;
using ArrayTask;

namespace ArrayTask;

public class Program
{
    public static void Main()
    {
        try
        {
            Array a = new Array(2, 2);
            Array b = new Array(2, 2);
            Array c = new Array(2, 2);
            Array d = new Array(2, 2);
            Array at = new Array(2, 2);
            int[,] matr = a.GenerateRandomMatrix();
            b.GenerateRandomMatrix();
            c = a * b;
            d = a - b;
            
            Console.WriteLine();
            a.PrintMatrix();
            Console.WriteLine();
            b.PrintMatrix();
            Console.WriteLine();
            c.PrintMatrix();
            Console.WriteLine();
            Console.WriteLine(a.IsSymmetric());
            //Console.WriteLine();
            //d.PrintMatrix();
            //c.PrintMatrix();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
