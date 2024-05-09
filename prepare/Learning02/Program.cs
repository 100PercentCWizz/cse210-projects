using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Adobe";
        job1._startYear = 2000;
        job1._endYear = 2020;
        // Console.WriteLine(job1._company);
        // job1.Display();

        Job job2 = new Job();
        job2._jobTitle = "Engineer of Software";
        job2._company = "Adober";
        job2._startYear = 2001;
        job2._endYear = 2021;
        // Console.WriteLine(job2._company);
        // job2.Display();

        Resume resume1 = new Resume();
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
        resume1._name = "Christian Haroldsen";
        resume1.Display();
    }
}