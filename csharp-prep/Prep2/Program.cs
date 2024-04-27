using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your grade percentage as a number: ");
        string strGrade = Console.ReadLine();
        int intGrade = int.Parse(strGrade);
        string letterGrade;

        if (intGrade >= 90) {
            letterGrade = "A";
        } else if (intGrade >= 80) {
            letterGrade = "B";
        } else if (intGrade >= 70) {
            letterGrade = "C";
        } else if (intGrade >= 60) {
            letterGrade = "D";
        } else {
            letterGrade = "F";
        }

        if (intGrade % 10 >= 7 && (letterGrade != "A" && letterGrade != "F")) {
            letterGrade = letterGrade + "+";
        } else if (intGrade % 10 < 3 && letterGrade != "F") {
            letterGrade = letterGrade + "-";
        }

        Console.WriteLine($"Your grade: {letterGrade}");

        if (intGrade >= 70) {
            Console.Write("Congrats!  You passed the class!");
        } else {
            Console.Write("You did not pass the class but you can certainly try again!");
        }
    }
}
