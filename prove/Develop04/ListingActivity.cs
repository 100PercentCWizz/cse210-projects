class ListingActivity : Activity {

    // MEMBER VARIABLES / ATTRIBUTES

    private string _listingPrompt = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    private List<string> _typingpPrompts = [
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    ];

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    // public ListingActivity(int memVar1Param, int memVar2Param) {
    //     _memVar1 = memVar1Param;
    //     _memVar2 = memVar2Param;
    // }

        // GETTERS / ACCESSORS ( METHODS )



        // SETTERS / MUTATORS ( METHODS )



        // OTHER METHODS

    private string GetRandomListingPrompt() {
        Random rand = new Random();
        int index = rand.Next(0, _typingpPrompts.Count - 1);
        return _typingpPrompts[index];
    }

    public void DoListingActivity() {
        GetDurationFromUser("HOME > LISTING ACTIVITY");
        DisplayAndAnimate(_listingPrompt);
        Console.Write("\n\n");

        DisplayAndAnimate($"After the countdown, list as many things as you can for the prompt below:\n{GetRandomListingPrompt()}\n");

        Console.Write(" begin in 3\b\b\b\b\b\b\b\b\b\b\b");
        Thread.Sleep(1000);
        Console.Write(" begin in 2\b\b\b\b\b\b\b\b\b\b\b");
        Thread.Sleep(1000);
        Console.Write(" begin in 1\b\b\b\b\b\b\b\b\b\b\b");
        Thread.Sleep(1000);
        Console.WriteLine(" begin now.\n");

        List<string> userItems = [];

        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(GetDurationInSeconds());

        DateTime currentTime = DateTime.Now;
        while (currentTime < futureTime) {
            Console.Write(" > ");
            userItems.Add(Console.ReadLine());
            currentTime = DateTime.Now;
        }

        DisplayAndAnimate($"\nExcellent job!  You've listed {userItems.Count} things.");

        DisplayAndAnimate("\n\nThank you for participating!  Redirecting you to the HOME menu.");
    }

}
