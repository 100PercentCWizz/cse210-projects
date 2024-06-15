class Thwomp {

    private List<string> _thwompText = [
        "DGDGDG  DGDG  DGDG  DGDG  DGDG  DGDGDG",
        "DGLGLGDGLGLGDGLGLGDGLGLGDGLGLGDGLGLGDG",
        "DGLGDGDGDGDGDGDGDGDGDGDGDGDGDGDGDGLGDG",
        "  DGDGLGLGLGLGLGLGLGLGLGLGLGLGLGDGDG  ",
        "DGLGDGLGLGLGLGLGLGLGLGLGLGLGLGLGDGLGDG",
        "DGLGDGLGLGDGDGLGLGLGLGLGDGDGLGLGDGLGDG",
        "  DGDGLGLGLGLGDGLGLGLGDGLGLGLGLGDGDG  ",
        "DGLGDGLGLGLGRRRRDGDGDGRRRRLGLGLGDGLGDG",
        "DGLGDGLGLGLGRRDGLGLGLGDGRRLGLGLGDGLGDG",
        "  DGDGLGLGLGLGLGLGLGLGLGLGLGLGLGDGDG  ",
        "DGLGDGLGLGDGDGLGLGLGLGLGDGDGLGLGDGLGDG",
        "DGLGDGLGDGWWWWDGDGDGDGDGWWWWDGLGDGLGDG",
        "  DGDGLGDGDGWWWWWWWWWWWWWWDGDGLGDGDG  ",
        "DGLGDGLGDGWWWWWWWWWWWWWWWWWWDGLGDGLGDG",
        "DGLGDGLGLGDGDGDGDGDGDGDGDGDGLGLGDGLGDG",
        "  DGDGLGLGLGLGLGLGLGLGLGLGLGLGLGDGDG  ",
        "DGLGDGDGDGDGDGDGDGDGDGDGDGDGDGDGDGLGDG",
        "DGLGLGDGLGLGDGLGLGDGLGLGDGLGLGDGLGLGDG",
        "DGDGDG  DGDG  DGDG  DGDG  DGDG  DGDGDG"
    ];

    private string Color(string stringParam, string fillerString = "[]") {
        stringParam = stringParam.Replace("RR", $"\u001b[91m{fillerString}\u001b[0m");
        stringParam = stringParam.Replace("LG", $"\u001b[37m{fillerString}\u001b[0m");
        stringParam = stringParam.Replace("WW", $"\u001b[97m{fillerString}\u001b[0m");
        stringParam = stringParam.Replace("DG", $"\u001b[90m{fillerString}\u001b[0m");
        stringParam = stringParam.Replace("BB", $"\u001b[30m{fillerString}\u001b[0m");
        return stringParam;
    }

// Thread.Sleep(1000);
// Console.WriteLine("c\b");
    public string GetThwompString(int padding, int pitchParam) {
        string outString = "";
        for (int i = 0; i < padding; i ++) {
            outString = outString + "                                      \n";
        }
        foreach (string line in _thwompText) {
            outString = outString + Color(line, "##") + "\n";
        }
        for (int i = padding; i < pitchParam; i ++) {
            outString = outString + "                                      \n";
        }
        return outString;
    }

// PASTE THIS INTO THE PROGRAM FILE
        // Thwomp thwomp = new Thwomp();
        // // thwomp.PrintThwomp();

        // // -------------------------------------

        // double rise = 10;
        // double frequency = 0.5;

        // double pitch = rise / 2;
        // int x = 0;

        // int y = 0;

        // Console.WriteLine("\x1b[2J\x1b[H");

        // while (true) {
        //     y = (int)((-1 * pitch * Math.Cos(frequency * x) + pitch) / 1);
        //     Console.WriteLine(thwomp.GetThwompString(y, (int)pitch));
        //     Console.CursorLeft = 0;
        //     Console.CursorTop = 0;
        //     x ++;
        //     Thread.Sleep(200);
        // }

}
