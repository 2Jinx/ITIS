using System;
namespace OOP
{
	public class Multiplication
	{
        private double a;
        private double b;

        public void SetFirstNum(int n)
        {
            a = n;
        }

        public double GetFirstNum()
        {
            return a;
        }

        public void SetSecondNum(int m)
        {
            b = m;
        }

        public double GetSecondNum()
        {
            return b;
        }

        public void Print()
        {
            if (a < 0 && b > 0)
                Console.WriteLine($"({a})*{b}");
            if (a > 0 && b < 0)
                Console.WriteLine($"{a}*({b})");
            if (a < 0 && b < 0)
                Console.WriteLine($"({a})*({b})");
            if (a > 0 && b > 0)
                Console.WriteLine($"{a}*{b}");
        }

        public Multiplication(double n, double m)
        {
            a = n;
            b = m;
        }
        public void Mult()
        {
            double res = a * b;
            Console.WriteLine(res);
        }
    }
}

