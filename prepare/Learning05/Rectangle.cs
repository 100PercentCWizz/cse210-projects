class Rectangle : Shape {

    // MEMBER VARIABLES / ATTRIBUTES

    private double _length;
    private double _width;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public Rectangle(string colorParam, double lengthParam, double widthParam) : base(colorParam) {
        SetColor(colorParam);
        _length = lengthParam;
        _width = widthParam;
    }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    public override double GetArea() { return _length * _width; }

}
