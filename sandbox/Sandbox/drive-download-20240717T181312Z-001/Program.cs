// // Program.cs

// using System;

// class Program {
//     static void Main(string[] args) {
//         Player player = new Player(100, 20, 10);
//         FireEnemy enemy = new FireEnemy("Blazing Inferno", 50, 15, 5, 0.3);
//         HealthPotion healthPotion = new HealthPotion("Health Potion", "Restores 50 HP.", 10, 50);
//         Sword sword = new Sword("Sword of Power", "Increases attack power.", 50, 10);
//         Shield shield = new Shield("Shield of Resistance", "Decreases damage taken.", 30, 5);

//         Console.WriteLine("Player stats:");
//         Console.WriteLine($"Health: {player.Health}, Attack: {player.AttackPower}, Defense: {player.Defense}\n");

//         // Using non-consumable items
//         sword.Use();
//         shield.Use();

//         Console.WriteLine();

//         Console.WriteLine($"Encountered {enemy.Name}!");
//         Console.WriteLine($"Enemy stats:");
//         Console.WriteLine($"Health: {enemy.Health}, Attack: {enemy.AttackPower}, Defense: {enemy.Defense}\n");

//         // Simulating combat
//         player.Attack(enemy);
//         enemy.Attack(player);

//         Console.WriteLine();

//         // Using a consumable item
//         Console.WriteLine($"Player uses {healthPotion.Name}.");
//         player.UseItem(healthPotion);
//     }
// }
