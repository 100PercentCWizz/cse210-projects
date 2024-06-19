abstract class Shape {

    // MEMBER VARIABLES / ATTRIBUTES

    private string _color;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public Shape(string colorParam) { _color = colorParam; }

        // GETTERS / ACCESSORS ( METHODS )

    public string GetColor() { return _color; }

        // SETTERS / MUTATORS ( METHODS )

    public void SetColor(string colorParam) { _color = colorParam; }

        // OTHER METHODS

    public abstract double GetArea();

}
