using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Schema;

class Program
{
    // static void displayLOL(List<List<string>> inLOL) {
    //     Console.WriteLine("[");
    //     foreach(List<string> row in inLOL) {
    //         Console.Write("    [");
    //         foreach(string rowItem in row) {
    //             Console.Write($"\"{rowItem}\", ");
    //         }
    //         Console.Write("],");
    //         Console.WriteLine();
    //     }
    //     Console.WriteLine("]");
    // }

    static void Main(string[] args) {

        // List<List<string>> loadedJournal = readTxtFile("C:/Users/User/Documents/[1] Christian/[3] Programming/[3] C#/cse210-projects/sandbox/Sandbox/Journal01.txt", separator: " | ");
        // Console.WriteLine(loadedJournal);
        // displayLOL(loadedJournal);

        // Course course1 = new Course();
        // course1._className = "Programming with Classes";
        // course1._color = "Green";
        // course1._courseCode = "CSE 210";
        // course1._numberOfCredits = 2;
        // course1.Display();

        // --------------------------------------
        string pathy = @"C:\Users\User\Documents\[1] Christian\[3] Programming\[3] C#\cse210-projects\sandbox\Sandbox";
        CHUser chuser = new CHUser();
        string user = chuser.GetFileExplore(baseDir: pathy, header2: "HOME > GET FILE");
        Console.WriteLine(user);
        // --------------------------------------

        // string thisDir = @"C:\Users\User\Documents\[1] Christian\[3] Programming\[3] C#\[1] My Programs";
        // thisDir.Replace("\\", "/");

    // string currentFile = chuser.GetDir(baseDir: thisDir);

    }
}
