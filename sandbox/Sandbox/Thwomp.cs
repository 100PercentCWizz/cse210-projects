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
    public void PrintThwomp() {
        foreach (string line in _thwompText) {
            Console.WriteLine(Color(line, "##"));
        }
    }

}
