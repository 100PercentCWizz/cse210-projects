class BreathingActivity : Activity {

    // MEMBER VARIABLES / ATTRIBUTES

    private string _breathingPrompt = "This activity will help you relax by guiding you through slow breathing.  Clear your mind and focus on your breathing.";

    private List<string> _animationFrames = [
        BackOverText(" breath in 3 "),
        BackOverText(" breath in 2 "),
        BackOverText(" breath in 1 "),
        BackOverText("     AND     "),
        BackOverText(" breath out 3"),
        BackOverText(" breath out 2"),
        BackOverText(" breath out 1"),
        BackOverText("     AND     ")
    ];

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    // public BreathingActivity(int memVar1Param, int memVar2Param) {
    //     _memVar1 = memVar1Param;
    //     _memVar2 = memVar2Param;
    // }

        // GETTERS / ACCESSORS ( METHODS )

    public string GetAnimationFrameAt(int index) {
        int safeIndex = index % _animationFrames.Count;
        return _animationFrames[safeIndex];
    }

        // SETTERS / MUTATORS ( METHODS )



        // OTHER METHODS

    public void DoBreathingActivity() {
        GetDurationFromUser("HOME > BREATHING ACTIVITY");
        DisplayAndAnimate(_breathingPrompt);
        Console.Write("\n\n");
        for (int i = 0; i < GetDurationInSeconds(); i ++) {
            Console.Write(GetAnimationFrameAt(i));
            Thread.Sleep(1000);
        }
        Console.WriteLine();
        DisplayAndAnimate("\nThank you for participating!  Redirecting you to the HOME menu.");
    }

}
