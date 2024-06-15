using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Schema;

class Program
{

    static void Main(string[] args) {

        // CHUser chuser = new CHUser();
        // string user = "HOME";
        // string currentPath = "NONE";

        // while (user != "CANCEL") {

        //     if (user == "HOME") {
        //         user = chuser.MultipleChoice([[$"Select a Folder: {currentPath}", ""], ["CANCEL"]], "HOME");
        //     }
        //     else {
        //         currentPath = chuser.GetDirectoryExplore("C:/Users/User/Documents/1-Christian/3-Programming/3-C#", valueIfCanceled: currentPath, getDirectoryHeader: "HOME > SELECT A FOLDER");
        //         user = "HOME";
        //     }

        // }

        Thwomp thwomp = new Thwomp();
        // thwomp.PrintThwomp();

        // -------------------------------------

        double rise = 10;
        double frequency = 0.5;

        double pitch = rise / 2;
        int x = 0;

        int y = 0;

        Console.WriteLine("\x1b[2J\x1b[H");

        while (true) {
            y = (int)((-1 * pitch * Math.Cos(frequency * x) + pitch) / 1);
            Console.WriteLine(thwomp.GetThwompString(y, (int)pitch));
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            x ++;
            Thread.Sleep(200);
        }

    }

}
