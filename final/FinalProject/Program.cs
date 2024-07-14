using System;

class Program
{
    static void Main(string[] args)
    {
        // IMPORTS
        CHString chstring = new CHString();

        Console.Clear();

        chstring.SlowPrint("\nWhat is the name of your hero? ");
        string heroName = Console.ReadLine().ToUpper();
        Player player = new Player(heroName);

        Combat combat = new Combat(player);

        chstring.SlowPrint($"\nWelcome, {heroName}.  Your journey is just beginning!");
        Thread.Sleep(2000);

        int finalScore = 0;

        while (player.IsAlive()) {

            Console.Clear();
            combat.GetEnemy(finalScore);
            chstring.SlowPrint($"\n{player.GetName()} encounters a {combat.GetEnemyName()}.");
            Thread.Sleep(1000);

            combat.EngageInBattle();
        }

        Console.Clear();
        chstring.SlowPrint($"\nYou were SLAIN...\n\nYour final score is {finalScore} enemies defeated.\n\n");
        
    }
}
