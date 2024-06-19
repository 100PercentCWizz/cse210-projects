class Circle : Shape {

    // MEMBER VARIABLES / ATTRIBUTES

    private double _radius;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public Circle(string colorParam, double radiusParam) : base(colorParam) {
        SetColor(colorParam);
        _radius = radiusParam;
    }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    public override double GetArea() { return Math.PI * _radius * _radius; }

}
