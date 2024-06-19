class Square : Shape {

    // MEMBER VARIABLES / ATTRIBUTES

    private double _side;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public Square(string colorParam, double sideParam) : base(colorParam) {
        SetColor(colorParam);
        _side = sideParam;
    }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    public override double GetArea() { return _side * _side; }

}
