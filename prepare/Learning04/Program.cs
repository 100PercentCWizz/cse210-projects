using System;

class Program
{
    static void Main(string[] args)
    {
        
        Assignment assignment = new Assignment("Christian1", "Biology");
        Console.WriteLine(assignment.GetSummary());

        MathAssignment mathAssignment = new MathAssignment("Christian2", "Trig", "1.3", "1 - 5");
        Console.WriteLine(mathAssignment.GetHomeworkList());

        WritingAssignment writingAssignment = new WritingAssignment("Christian3", "Norris-ology", "Why Chuck Norris could take Godzilla in a fight.");
        Console.WriteLine(writingAssignment.GetWritingInformation());

    }
}
