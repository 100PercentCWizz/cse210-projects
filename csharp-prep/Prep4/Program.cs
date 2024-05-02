using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // List<string> people = [];
        // people.Add("Christian");

        // Console.WriteLine(people.Count);

        // foreach (string person in people) {
        //     Console.WriteLine(person);
        // }

        // for (int index = 0; index < people.Count; index++) {
        //     Console.WriteLine(people[index]);
        // }

        // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-5.0

        List<int> numbers = [];
        int num = 1;
        while (num != 0) {
            Console.WriteLine("Enter a list of numbers, type 0 when finished: ");
            num = Convert.ToInt32(Console.ReadLine());
            if (num != 0) {
                numbers.Add(num);
            }
        }
        
        int sum = 0;
        int largest = 0;
        int small_pos = numbers[0];
        foreach (int numy in numbers) {
            sum += numy;
            if (numy > largest) {
                largest = numy;
            } else if (numy < small_pos && numy > 0) {
                small_pos = numy;
            }
        }
        double average = (double)sum / numbers.Count;
        Console.WriteLine($"The sum of the numbers is {sum}.");
        Console.WriteLine($"The average of the numbers is {average}.");
        Console.WriteLine($"The largest number is {largest}.");
        Console.WriteLine($"The smallest positive number is {small_pos}.");
        Console.WriteLine($"The sorted list is:");
        numbers.Sort();
        foreach (int numy in numbers) {
            Console.WriteLine(numy);
        }

    }
}