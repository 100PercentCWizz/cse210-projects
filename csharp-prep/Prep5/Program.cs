using System;

class Program
{
    static void DisplayWelcome() {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName() {
        Console.WriteLine("Please enter your name: ");
        string str = Console.ReadLine();
        return str;
    }

    static int PromptUserNumber() {
        Console.WriteLine("Please enter your favorite number: ");
        int num = Convert.ToInt32(Console.ReadLine());
        return num;
    }

    static int SquareNumber(int integer) {
        return integer * integer;
    }

    static void DisplayResult(string name, int integer) {
        Console.WriteLine($"{name}, the square of your number is {integer}.");
    }

    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int num = PromptUserNumber();
        int SqrNum = SquareNumber(num);
        DisplayResult(name, SqrNum);
    }
}
