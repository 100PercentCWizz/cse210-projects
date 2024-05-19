class Entry {
    public string _entryDate;
    public string _givenPrompt;
    public string _entryText;

    public void DisplayEntry() {
        Console.WriteLine($"------------------------------\nEntry Date: {_entryDate}\nPrompt: {_givenPrompt}\nEntry: {_entryText}");
    }
    public void getNow() {
        DateTime theCurrentTime = DateTime.Now;
        _entryDate = theCurrentTime.ToShortDateString();
    }
}
