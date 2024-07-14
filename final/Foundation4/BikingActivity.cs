class BikingActivity : Activity {

    // MEMBER VARIABLES / ATTRIBUTES

    private double _speed;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public BikingActivity(string dateParam, int lenInMinutesParam, double speedParam) : base(dateParam, lenInMinutesParam) {
        _date = dateParam;
        _lenInMinutes = lenInMinutesParam;
        _speed = speedParam;
    }

    // GETTERS / ACCESSORS ( METHODS )

    // SETTERS / MUTATORS ( METHODS )

    // OTHER METHODS

    public override double GetDistance() {
        double dubLenInMinutes = (double)_lenInMinutes;
        return (dubLenInMinutes / 60.0) * _speed;
    }

    public override double GetSpeed() { return _speed; }

    public override double GetPace() {
        return 60 / _speed;
    }

    protected override string GetActivityType() { return "BIKING"; }

}
