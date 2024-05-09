class Course
{
    public string _courseCode;
    public string _className;
    public int _numberOfCredits;
    public string _color;

    // methods
    public void Display() {
        Console.WriteLine($"Course Code: {_courseCode}\nClass Name: {_className}\nNum of Credits: {_numberOfCredits}\nColor: {_color}");
    }

}
