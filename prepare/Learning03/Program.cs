using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction frac1 = new Fraction();
        Fraction frac2 = new Fraction(6);
        Fraction frac3 = new Fraction(6, 7);

        Console.WriteLine($"DEMONSTRATING USE OF GETTER ON FRACTION 1: {frac1.GetNumerator()}/{frac1.GetDenominator()}");
        frac1.SetNumerator(2);
        frac1.SetDenominator(4);
        Console.WriteLine($"DEMONSTRATING USE OF SETTER ON FRACTION 1 BY SETTING IT TO 2/4: {frac1.GetNumerator()}/{frac1.GetDenominator()}");
        Console.WriteLine("FRACTIONS IN FORMAT #/#");
        Console.WriteLine($"Fraction 1: {frac1.GetFractionalString()}\nFraction 2: {frac2.GetFractionalString()}\nFraction 3: {frac3.GetFractionalString()}");
        Console.WriteLine("FRACTIONS IN FORMAT #.#");
        Console.WriteLine($"Fraction 1: {frac1.GetDecimalValue()}\nFraction 2: {frac2.GetDecimalValue()}\nFraction 3: {frac3.GetDecimalValue()}");

    }
}
