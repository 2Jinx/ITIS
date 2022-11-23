using OOP;

namespace OOP;

public class Program
{
    public static void Main()
    {
        try
        {
            //Fraction f1 = new Fraction(15, 4);
            //Fraction f2 = new Fraction(13,2);
            //Fraction f3 = new Fraction();
            //f3 = f1 + f2;
            //f3.Print();
            //Fraction f2 = new Fraction(2, 10);
            //f1.Reduction();
            //f1.Print();

            //f1.Mult(f2);
            //f1.Print();
            //Console.WriteLine(f1.GetProperFraction());

            //Complex c1 = new Complex(4, 2);
            //Complex c2 = new Complex(6, -3);
            //Complex c3 = new Complex();

            //c3 = c1 * c2;
            //c3.Print();
            //c3 = c3 / c2;
            //c3.Print();
            //Console.WriteLine(c3-c2);

            Time t1 = new Time(1, 1, 61);
            Time t2 = new Time(15, 61, 62);

            Console.WriteLine(t1.ToString());
            Console.WriteLine(t2.ToString());
            Console.WriteLine(t2 - t1);
            Console.WriteLine(t2 / 2);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
