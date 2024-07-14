using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        Order order1 = new Order([new Product("Apples", "159753", 50, 6), new Product("Burritos", "357951", 125, 3), new Product("Cheese", "147963", 600, 1)], new Customer("Chuck Norris", new Address("42 Wallaby Way", "Sidney", "Victoria", "Australia")));
        order1.DisplayAll();

        Order order2 = new Order([new Product("Bananas", "369741", 25, 8), new Product("Chocolate Bar", "789321", 150, 1), new Product("Oreos", "123987", 350, 2)], new Customer("Michael Jackson", new Address("123 Sesame Street", "New York City", "NY", "USA")));
        order2.DisplayAll();
    }
}
