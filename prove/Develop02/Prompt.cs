class Prompt {
    List<string> _promptList = [
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is the biggest lesson I learned today?",
        "What was the hardest decision I had to make today?",
        "What was the strangest or weirdest thing I witnessed today?",
        "Who did God bless me through the most today?",
        "What is something I did well at today?"
    ];

    public string GetPrompt() {
        // get the current day of the month
        DateTime dt = DateTime.Now;
        int promptIndex = dt.Day % 10;
        return _promptList[promptIndex];
    }
}
