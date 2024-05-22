using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture();
        Reference refer = new Reference("3 Nephi", "5", "13");
        scripture.SetReference(refer);

        string verseText = "Behold, I am a disciple of Jesus Christ, the Son of God. I have been called of him to declare his word among his people, that they might have everlasting life.";
        string[] wordList = verseText.Split(" ");
        foreach (string word in wordList) {
            Word newWord = new Word(textParam: word, isVisibleParam: true);
            scripture.AddWord(newWord);
        }
        
        scripture.ResetVisibles();
        string user = "";
        
        while (user != "quit") {
            Console.WriteLine($"\x1b[2J\x1b[H\n");
            scripture.RenderAndDisplayScripture();
            Console.Write("\nPress ENTER to remove words, type \"re\" to show all words, and type \"quit\" to quit.");
            user = Console.ReadLine();
            user = user.ToLower();
            
            if (user == "re") {
                scripture.ResetVisibles();
            }
            else {
                scripture.AddInvisibles(3);
            }
        }
        Console.WriteLine("PROGRAM ENDED.");
    }
}
