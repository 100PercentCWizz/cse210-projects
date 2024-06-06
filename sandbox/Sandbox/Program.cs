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

        // CHUser chuser = new CHUser();
        // Game game = new Game();
        // List<string> players = new List<string>();

        // string user = "HOME";

        // while (user != "END PROGRAM") {
        //     if (user == "HOME") {
        //         user = chuser.TypedMultipleChoice(prompt: "\nHOME\n\n  1. Play a Round of Elimination\n  2. Play a Round to 100\n  3. Set Players\n  4. End Program\n/**/\nPlease select an action and press ENTER:\n", keyReturnList: [["1", "ELIMINATION"], ["2", "PLAY TO 100"], ["3", "SET PLAYERS"], ["4", "END PRORGAM"]]);
        //     }
        //     else if (user == "SET PLAYERS") {
        //         players = [];
        //         user = "";
        //         while (user != "SUBMIT") {
        //             user = chuser.TypedMultipleChoice(prompt: "\nSET PLAYERS\n\n  1. Add a payer\n  2. Remove the last player\n  3. Submit Players\n\n/**/\nPlease select an action and press ENTER:\n", keyReturnList: [["1", "ADD"], ["2", "REMOVE"], ["3", "SUBMIT"]]);
        //             if (user == "ADD") {
        //                 Console.Write("\n  Please type the name of the new player: ");
        //                 players.Add(Console.ReadLine());
        //             }
        //             else if (user == "REMOVE") {
        //                 players.RemoveAt(players.Count - 1);
        //             }
        //         }
        //     }
        //     else if (user == "ELIMINATION") {
        //         // chuser.PlayElimination(players);
        //         user = "HOME";
        //     }
        //     else if (user == "PLAY TO 100") {
        //         // chuser.PlayTo100(players);
        //         user = "HOME";
        //     }

        // }

        // -------------------------------------

        // Thwomp thwomp = new Thwomp();
        // thwomp.PrintThwomp();

        // -------------------------------------

        double rise = 10;
        double frequency = 0.5;

        double pitch = rise / 2;
        int x = 0;

        int y = 0;

        Console.WriteLine("\x1b[2J\x1b[H");
        string lineToPrint = "";

        // while (true) {
        //     lineToPrint = "";
        //     y = (int)((-1 * pitch * Math.Cos(frequency * x) + pitch) / 1);
        //     for (int i = 0; i < y; i ++) {
        //         lineToPrint = lineToPrint + "\n";
        //     }
        //     lineToPrint = lineToPrint + "WEE!\b\b\b\b";
        //     for (int i = 0; i < y; i ++) {
        //         lineToPrint = lineToPrint + "\b";
        //     }
        //     Console.Write(lineToPrint);
        //     Thread.Sleep(100);
        //     x ++;
        // }

        int delay = 100;

        // while (true) {
        //     Console.Write("\\\b");
        //     Thread.Sleep(delay);
        //     Console.Write("|\b");
        //     Thread.Sleep(delay);
        //     Console.Write("/\b");
        //     Thread.Sleep(delay);
        //     Console.Write("-\b");
        //     Thread.Sleep(delay);
        // }

    }

}
