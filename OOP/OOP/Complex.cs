using System;
namespace OOP
{
	internal class Complex
	{
        private double re;
        private double im;

        public Complex(double r, double i)
        {
            re = r;
            im = i;
        }

        public Complex(double re) : this(re, 1)
        {
            //re = n;
            //im = 1;
        }
        public Complex() : this(0, 1)
        {
            //re = 0;
            //im = 1;
        }
        public void SetRealPart(double r)
        {
            re = r;
        }

        public double GetRealPart()
        {
            return re;
        }

        public void SetImaginePart(double i)
        {
            if (im == 0)
                throw new ArgumentException("аргумент мнимой части должен быть ненулевым!");
            im = i;
        }

        public double GetImaginePart()
        {
            return im;
        }

        public void Print()
        {
            if(Im > 0)
                Console.WriteLine($"{Re}+{Im}i");
            if(Im < 0)
                Console.WriteLine($"{Re}-{Math.Abs(Im)}i");
            if (Im == 0)
                Console.WriteLine($"{Re}");
        }

        public override string ToString()
        {
            if (Im > 0)
                return $"{Re}+{Im}i";
            return $"{Re}-{Math.Abs(Im)}i";
        }

        public double Re
        {
            get
            {
                return re;
            }
            set
            {
                re = value;
            }
        }

        public double Im
        {
            get
            {
                return im;
            }
            set
            {
                if (value == 0)
                    throw new ArgumentException("аргумент мнимой части должен быть ненулевым!");
            }
        }

        public void Add(Complex c)
        {
            this.re = this.re + c.re;
            this.im = this.im + c.im;
        }

        public void Add(Complex c1, Complex c2)
        {
            this.re = c1.re + c2.re;
            this.im = c1.im + c2.im;
        }

        public void Sub(Complex c)
        {
            this.re = this.re - c.re;
            this.im = this.im - c.im;
        }

        public void Sub(Complex c1, Complex c2)
        {
            this.re = c1.re - c2.re;
            this.im = c1.im - c2.im;
        }

        public void Mult(Complex c)
        {
            double thisRe = this.re;
            this.re = this.re * c.re - this.im * c.im;
            this.im = thisRe * c.im + c.re * this.im;
        }

        public void Mult(Complex c1, Complex c2)
        {
            this.re = c1.re * c2.re - c1.im * c2.im;
            this.im = c1.re * c2.im + c2.re * c1.im;
        }

        public void Div(Complex c)
        {
            double thisRe = this.re;
            this.re = (this.re * c.re + this.im * c.im) / (c.re * c.re + c.im * c.im);
            this.im = (thisRe * (-1) * c.im - c.re * this.im) / (c.re * c.re + c.im * c.im);
        }

        public void Div(Complex c1, Complex c2)
        {
            this.re = (c1.re * c2.re + c1.im * c2.im) / (c2.re * c2.re + c2.im * c2.im);
            this.im = (c1.re * (-1) * c2.im - c2.re * c1.im) / (c2.re * c2.re + c2.im * c2.im);
        }

        public double Abs()
        {
            return Math.Sqrt(re * re + im * im);
        }

        public void GetMod()
        {
            Console.WriteLine(Math.Sqrt(re * re + im * im));
        }

        public double Arg()
        {
            if (re > 0 && im > 0)
                return (Math.Atan(re / im));
            if (re > 0 && im < 0)
                return (-Math.Atan(re / im));
            if (re < 0 && im > 0)
                return (Math.PI - Math.Atan(re / im));
            if (re < 0 && im < 0)
                return (-Math.PI + Math.Atan(re / im));
            if (re == 0 && im > 0)
                return (Math.PI / 2);
            if (re == 0 && im < 0)
                return (-Math.PI / 2);
            if (re > 0 && im == 0)
                return (0);
            if (re < 0 && im == 0)
                return (Math.PI);
            return 0;
        }

        public static Complex operator + (Complex c1, Complex c2)
        {
            return new Complex(c1.re + c2.re, c2.im + c2.im);
        }

        public static Complex operator +(double n, Complex c)
        {
            return new Complex(n + c.re, c.im);
        }

        public static Complex operator +(Complex c, double n)
        {
            return new Complex(c.re, c.im + n);
        }

        public static Complex operator - (Complex c1, Complex c2)
        {
            return new Complex(c1.re - c2.re, c2.im - c2.im);
        }

        public static Complex operator -(double n, Complex c)
        {
            return new Complex(c.re - n, c.im);
        }

        public static Complex operator - (Complex c, double n)
        {
            return new Complex(c.re, c.im - n);
        }

        public static Complex operator / (Complex c1, Complex c2)
        {
            var r = (c1.re * c2.re + c1.im * c2.im) / (c2.re * c2.re + c2.im * c2.im);
            var i = (c1.re * (-1) * c2.im - c2.re * c1.im) / (c2.re * c2.re + c2.im * c2.im);
            return new Complex(r, i);
        }

        public static Complex operator / (Complex c, double n)
        {
            if (n == 0)
                throw new ArgumentException("на ноль делить нельзя!");
            return new Complex(c.re / n, c.im / n);
        }

        public static Complex operator * (Complex c1, Complex c2)
        {
            var r = c1.re * c2.re - c1.im * c2.im;
            var i = c1.re * c2.im + c2.re * c1.im;
            return new Complex(r, i);
        }

        public static Complex operator * (Complex c, double n)
        {
            return new Complex(c.re * n, c.im * n);
        }
    }
}

