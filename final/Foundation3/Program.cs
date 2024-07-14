using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        List<Event> eventList = new List<Event>();
        eventList.Add(new OutdoorGathering("Pool Party", "It's a party at the pool", "6/30", "3:00 PM", new Address("123 Sesame Street", "Rexburg", "ID", "USA"), "Sunny"));
        eventList.Add(new Lecture("Delivering the Final Blow", "Learn how to demolish someone from a skilled professional", "7/2", "6:00 PM", new Address("111 College Ave.", "Pocatello", "ID", "USA"), "Chuck Norris", 500));
        eventList.Add(new Reception("C + N Reception", "Celebrate Christian and Nikara's marriage", "7/10", "2:00 PM", new Address("130 Reception Street", "Afton", "WY", "USA"), "208-867-5309"));
        
        foreach (Event eventItem in eventList) {
            Console.WriteLine(eventItem.GetStandardDetails());
            Console.WriteLine(eventItem.GetFullDetails());
            Console.WriteLine(eventItem.GetShortDetails());
        }
    }
}
