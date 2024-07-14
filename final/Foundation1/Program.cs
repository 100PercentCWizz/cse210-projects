using System;

class Program
{
    static void Main(string[] args)
    {

        // List<Video> vidList = new List<Video>();
        // vidList.Add(new Video());
        // vidList.Add(new Video());
        // vidList.Add(new Video());

        List<Video> vidList = new List<Video>();

        vidList.Add(new Video("Gangnam Style", "Psy", 100, [new Comment("Joe 1", "Cool moves!"), new Comment("Joe 2", "I like the suit!"), new Comment("Joe 3", "I hate this!")]));
        vidList.Add(new Video("Baby", "Justin Beiber", 200, [new Comment("Joe 1", "Cool song!"), new Comment("Joe 2", "I like the hair!"), new Comment("Joe 3", "I hate this!")]));
        vidList.Add(new Video("Cat Falls Into Dryer", "Mourning Cat Man", 300, [new Comment("Joe 1", "How sad!"), new Comment("Joe 2", "Oh no!"), new Comment("Joe 3", "Finally a video that speaks to me!")]));

        Console.Clear();
        Console.WriteLine("-------------------------");
        foreach (Video video in vidList) {
            video.PrintVideoData();
        }

    }
}
