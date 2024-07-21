// using System;

// class IceEnemy : Enemy {
//     private static readonly Random rand = new Random();
//     private double frostbiteChance; // Probability of inflicting frostbite (e.g., 0.2 for 20%)

//     public IceEnemy(int health, int attackPower, int defense, string name, double frostbiteChance) 
//         : base(health, attackPower, defense, name, "Ice") {
//         this.frostbiteChance = frostbiteChance;
//     }

//     public override void Attack() {
//         Console.WriteLine($"{name} uses an ice attack!");
//         TryInflictFrostbite();
//     }

//     private void TryInflictFrostbite() {
//         if (rand.NextDouble() < frostbiteChance) {
//             InflictFrostbite();
//         }
//     }

//     private void InflictFrostbite() {
//         // Logic to inflict frostbite status effect
//         Console.WriteLine($"{name} inflicted frostbite!");
//         // Assuming there's a method in the status effect class to apply frostbite
//         // StatusEffect.ApplyFrostbite(this); // Example method call
//     }
// }
