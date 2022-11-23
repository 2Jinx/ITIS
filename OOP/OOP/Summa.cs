using System;
namespace OOP
{
	public class Summa
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
            Console.WriteLine($"{a}+{b}");
        }

		public Summa(double n, double m)
		{
			a = n;
			b = m;
        }

		public void Sum()
		{
			double res = a + b;
			Console.WriteLine(res);
		}
    }
}

