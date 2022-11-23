using System;                     // класс дробных чисел с методами
namespace OOP
{
	internal class Fraction
	{
        private int numerator;
        private int denominator;

        public Fraction(int n, int d)
        {
            if (d == 0)
                throw new ArgumentException("Нельзя делить на ноль!");

            numerator = n;
            denominator = d;
            Reduction();
        }

        public Fraction(int n) : this(n, 1)
        {
            //numerator = n;
            //denominator = 1;
        }

        public Fraction() : this(0, 1)
        {
            //numerator = 0;
            //denominator = 1;
        }

        public Fraction (Fraction f) : this(f.Numerator, f.Denominator)
        {
            //
        }

        public double GetValue()
        {
            double n = numerator;
            double d = denominator;
            double res = n / d;
            return res;
        }

        public void SetNum(int n)
        {
            numerator = n;
        }

        public int GetNum()
        {
            return numerator;
        }

        public void SetDenom(int d)
        {
            if (d == 0)
                throw new ArgumentException("Нельзя делить на ноль!");
            denominator = d;
        }

        public int GetDen()
        {
            return denominator;
        }

        public void Print()
        {
            Console.WriteLine($"{Numerator}/{Denominator}");
        }

        public override string ToString()
        {
            if (Denominator == 1)
                return $"{Numerator}";
            return $"{Numerator/Denominator}";
        }

        private static void Swap(ref int leftItem, ref int rightItem)
        {
            int t = leftItem;
            leftItem = rightItem;
            rightItem = t;
        }

        private static int Nod(int n, int d)
        {
            int t;
            n = Math.Abs(n);
            d = Math.Abs(d);
            while (d != 0 && n != 0)
            {
                if (n % d > 0)
                {
                    t = n;
                    n = d;
                    d = t % d;
                }
                else
                    break;
            }
            if (d != 0 && n != 0)
                return d;
            return 0;
        }

        public void Reduction()
        {
            int nod = Nod(numerator, denominator);
            if (nod != 0)
            {
                numerator /= nod;
                denominator /= nod;
            }
        }

        public void Add(Fraction f)
        {
            this.numerator = this.numerator * f.denominator +
                this.denominator * f.numerator;
            this.denominator = this.denominator * f.denominator;
            Reduction();
        }

        public void Add(Fraction f1, Fraction f2)
        {
            this.numerator = f1.numerator * f2.denominator +
                f1.denominator * f2.numerator;
            this.denominator = f1.denominator * f2.denominator;
            Reduction();
        }

        public void Sub(Fraction f)
        {
            this.numerator = this.numerator * f.denominator -
                this.denominator * f.numerator;
            this.denominator = this.denominator * f.denominator;
            Reduction();
        }

        public void Sub(Fraction f1, Fraction f2)
        {
            this.numerator = f1.numerator * f2.denominator -
                f1.denominator * f2.numerator;
            this.denominator = f1.denominator * f2.denominator;
            Reduction();
        }

        public void Mult(Fraction f)
        {
            this.numerator = this.numerator * f.numerator;
            this.denominator = this.denominator * f.denominator;
            Reduction();
        }

        public void Mult(Fraction f1, Fraction f2)
        {
            this.numerator = f1.numerator * f2.numerator;
            this.denominator = f1.denominator * f2.denominator;
            Reduction();
        }

        public void Div(Fraction f)
        {
            Swap(ref f.numerator, ref f.denominator);
            this.numerator = this.numerator * f.numerator;
            this.denominator = this.denominator * f.denominator;
            Reduction();
        }

        public void Div(Fraction f1, Fraction f2)
        {
            Swap(ref f2.numerator, ref f2.denominator);
            this.numerator = f1.numerator * f2.numerator;
            this.denominator = f1.denominator * f2.denominator;
            Reduction();
        }
        public int Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
            }
        }

        public int Denominator
        {
            get
            {
                return denominator;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("знаменатель должен быть положительным !");
                }
            }
        }

        public int GetIntegerPart()
        {
            return Numerator / Denominator;
        }

        public string GetProperFraction()
        {
            string result;
            int integerP = GetIntegerPart();
            int n = numerator - (denominator * integerP);
            result = $"{integerP} {n}/{denominator}";
            return result;
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            var n = f1.Numerator * f2.Denominator +
                f1.Denominator * f2.Numerator;
            var d = f1.Denominator * f2.Denominator;
            return new Fraction(n, d);
        }

        public static Fraction operator +(Fraction f1, int a)
        {
            var n = f1.Numerator + a * f1.Denominator;
            var d = f1.Denominator;
            return new Fraction(n, d);
        }
        public static Fraction operator +(int a, Fraction f1)
        {
            return f1 + a;
        }

        public static Fraction operator ++(Fraction f)
        {
            var n = f.Numerator + f.Denominator;
            var d = f.Denominator;
            return new Fraction(n, d);
        }

        public static bool operator >(Fraction f1, Fraction f2)
        {
            return f1.Numerator * f2.Denominator >
                             f1.Denominator * f2.Numerator;
        }

        public static bool operator <(Fraction f1, Fraction f2)
        {
            return f1.Numerator * f2.Denominator <
                             f1.Denominator * f2.Numerator;
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            var n = f1.numerator * f2.denominator - f2.numerator * f1.denominator;
            var d = f1.denominator * f2.denominator;
            return new Fraction(n, d);
        }

        public static Fraction operator -(int a, Fraction f)
        {
            var n = a * f.denominator - f.numerator;
            var d = f.denominator;
            return new Fraction(n, d);
        }



    }
}

