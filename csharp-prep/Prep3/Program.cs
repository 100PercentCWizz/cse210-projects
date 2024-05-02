using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();

        Boolean playing = true;

        while (playing) {

            int magic_number = randomGenerator.Next(1, 101);

            // Console.Write("What is the magic number? ");
            // int magic_number = Convert.ToInt32(Console.ReadLine());

            int guess = 0;
            int num_of_guesses = 0;

            while (guess != magic_number) {
                Console.Write("Guess a number: ");
                guess = Convert.ToInt32(Console.ReadLine());

                if (guess != magic_number) {
                    if (guess > magic_number) {
                        Console.WriteLine("LOWER!");
                    } else {
                        Console.WriteLine("HIGHER!");
                    }
                }
                num_of_guesses ++;
            }

            Console.WriteLine($"CONGRATULATIONS!!!  You have guessed the magic number in {num_of_guesses} guesses!");

            Console.WriteLine("Would you like to play again?  (type yes to start another game) ");
            string response = Console.ReadLine();
            if (response != "yes") {
                playing = false;
            }

        }
    }
}