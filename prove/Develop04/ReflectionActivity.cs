class ReflectionActivity : Activity {

    // MEMBER VARIABLES / ATTRIBUTES

    private string _reflectingPrompt = "This activity will help you reflect on moments from your life.  This will help you recognize the power you have and how you can use it in other aspects of your life.";

    private List<string> _firstPrompts = [
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    ];

    private List<string> _secondPrompts = [
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    ];

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    // public ReflectionActivity(int memVar1Param, int memVar2Param) {
    //     _memVar1 = memVar1Param;
    //     _memVar2 = memVar2Param;
    // }

        // GETTERS / ACCESSORS ( METHODS )



        // SETTERS / MUTATORS ( METHODS )



        // OTHER METHODS

    private string GetRandomSecondPrompt() {
        Random rand = new Random();
        int index = rand.Next(0, _secondPrompts.Count - 1);
        return _secondPrompts[index];
    }

    public void DoReflectionActivity() {
        GetDurationFromUser("HOME > REFLECTION ACTIVITY");
        DisplayAndAnimate(_reflectingPrompt);
        Console.Write("\n");

        Random randy = new Random();
        int firstPromptIndex = randy.Next(0, _firstPrompts.Count);

        for (int i = 0; i < GetDurationInSeconds(); i += 5) {
            if ((i % 10) == 0) {
                Console.WriteLine();
                DisplayAndAnimate(_firstPrompts[firstPromptIndex % (_firstPrompts.Count - 1)], 5000);
                Console.WriteLine();
                firstPromptIndex ++;
            }
            else if ((i % 10) == 5) {
                Console.WriteLine();
                DisplayAndAnimate(GetRandomSecondPrompt(), 5000);
                Console.WriteLine();
            }
        }
        DisplayAndAnimate("\n", (GetDurationInSeconds() % 5) * 1000);
        Console.WriteLine("\n");

        DisplayAndAnimate("\nThank you for participating!  Redirecting you to the HOME menu.");
    }

}
