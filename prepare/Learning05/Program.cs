using System;

class Program
{
    static void Main(string[] args)
    {

        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("RED", 5.0));
        shapes.Add(new Rectangle("GREEN", 5.0, 10.0));
        shapes.Add(new Circle("Blue", 2.0));

        foreach (Shape shape in shapes) {
            Console.WriteLine($"This shape is {shape.GetColor()} and its area is {shape.GetArea()}.");
        }

    }
}
