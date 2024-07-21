using System;
using System.Collections.Generic;

class EnemyFactory {
    private static readonly Random rand = new Random();

    private static readonly List<string> fireEnemyNames = new List<string> {
        "Blazing Inferno", "Flame Warden", "Ember Spirit", "Inferno Beast"
    };

    private static readonly List<string> iceEnemyNames = new List<string> {
        "Frozen Specter", "Ice Wraith", "Frost Giant", "Glacial Phantom"
    };

    private static readonly List<string> danceEnemyNames = new List<string> {
        "Dancing Specter", "Twilight Dancer", "Waltz Phantom", "Rhythm Reaper"
    };

    // public static FireEnemy CreateFireEnemy(double burnChance) {
    //     int health = rand.Next(50, 101); // Random health between 50 and 100
    //     int attackPower = rand.Next(10, 21); // Random attack power between 10 and 20
    //     int defense = rand.Next(5, 16); // Random defense between 5 and 15
    //     string name = fireEnemyNames[rand.Next(fireEnemyNames.Count)];
    //     return new FireEnemy(health, attackPower, defense, name, burnChance);
    // }

    // public static IceEnemy CreateIceEnemy(double frostbiteChance) {
    //     int health = rand.Next(50, 101); // Random health between 50 and 100
    //     int attackPower = rand.Next(10, 21); // Random attack power between 10 and 20
    //     int defense = rand.Next(5, 16); // Random defense between 5 and 15
    //     string name = iceEnemyNames[rand.Next(iceEnemyNames.Count)];
    //     return new IceEnemy(health, attackPower, defense, name, frostbiteChance);
    // }

    // public static DanceEnemy CreateDanceEnemy(double doubleDamageChance) {
    //     int health = rand.Next(50, 101); // Random health between 50 and 100
    //     int attackPower = rand.Next(10, 21); // Random attack power between 10 and 20
    //     int defense = rand.Next(5, 16); // Random defense between 5 and 15
    //     string name = danceEnemyNames[rand.Next(danceEnemyNames.Count)];
    //     return new DanceEnemy(health, attackPower, defense, name, doubleDamageChance);
    // }
}
