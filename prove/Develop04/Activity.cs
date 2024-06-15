class Activity {

    // MEMBER VARIABLES / ATTRIBUTES

    // private string _description;
    // private int _memVar2;
    private int _durationInSeconds;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    // public Activity(int memVar1Param, int memVar2Param) {
    //     _memVar1 = memVar1Param;
    //     _memVar2 = memVar2Param;
    // }

        // GETTERS / ACCESSORS ( METHODS )

    // public int GetMemVar1() { return _memVar1; }
    // public int GetMemVar2() { return _memVar2; }

        // SETTERS / MUTATORS ( METHODS )

    // public void SetMemVar1(int memVar1Param) { _memVar1 = memVar1Param; }
    // public void SetMemVar2(int memVar2Param) { _memVar2 = memVar2Param; }

        // OTHER METHODS

    public void GetDurationFromUser(string header) {

        Boolean StringOnlyContains(string searchIn, string searchFor) {
            Boolean outBool = true;
            for (int index = 0; index < searchIn.Count(); index ++) {
                if (!searchFor.Contains(searchIn[index])) {
                    outBool = false;
                }
            }
            return outBool;
        }

        string user;
        Console.Write($"\x1b[2J\x1b[H\n{header}\n\nPlease enter the duration of this activity in seconds: ");
        user = Console.ReadLine();
        Console.Write("\n");
        while (!StringOnlyContains(user, "1234567890")) {
            Console.Write($"\x1b[2J\x1b[H\n{header}\n\n\u001b[91mSorry!  \"{user}\" is not a valid response.\u001b[0m\nPlease enter the duration of this activity in seconds: ");
            user = Console.ReadLine();
            Console.Write("\n");
        }
        _durationInSeconds = Int32.Parse(user);

    }

    public void DisplayAndAnimate(string text, int overallDuration = 6000) {

        int repetitions = 4;
        int milliseconds = (overallDuration / repetitions) / 7;

        Console.Write(text);

        for (int i = 0; i < repetitions; i ++) {
            Console.Write(" \\____\b\b\b\b\b\b");
            Thread.Sleep(milliseconds);
            Console.Write(" /\\___\b\b\b\b\b\b");
            Thread.Sleep(milliseconds);
            Console.Write(" _/\\__\b\b\b\b\b\b");
            Thread.Sleep(milliseconds);
            Console.Write(" __/\\_\b\b\b\b\b\b");
            Thread.Sleep(milliseconds);
            Console.Write(" ___/\\\b\b\b\b\b\b");
            Thread.Sleep(milliseconds);
            Console.Write(" ____/\b\b\b\b\b\b");
            Thread.Sleep(milliseconds);
            Console.Write(" _____\b\b\b\b\b\b");
            Thread.Sleep(milliseconds);
        }
        
    }

    public int GetDurationInSeconds() { return _durationInSeconds; }

    public static string BackOverText(string text) {
        string outText = text;
        for (int i = 0; i < text.Count(); i ++) {
            outText = outText + "\b";
        }
        return outText;
    }

}
