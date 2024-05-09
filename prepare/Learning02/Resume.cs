// Keeps track of the person's name and a list of their jobs.
public class Resume {
    public string _name;
    public List<Job> _jobs = new();

    public void Display() {
        Console.WriteLine($"Name: {_name}\nJobs:");
        foreach (Job jobElem in _jobs) {
            jobElem.Display();
        }
    }
}