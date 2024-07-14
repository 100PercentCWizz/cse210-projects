class SwimmingActivity : Activity {

    // MEMBER VARIABLES / ATTRIBUTES

    private double _laps;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public SwimmingActivity(string dateParam, int lenInMinutesParam, double lapsParam) : base(dateParam, lenInMinutesParam) {
        _date = dateParam;
        _lenInMinutes = lenInMinutesParam;
        _laps = lapsParam;
    }

    // GETTERS / ACCESSORS ( METHODS )

    // SETTERS / MUTATORS ( METHODS )

    // OTHER METHODS

    public override double GetDistance() {
        return (_laps * 50) / 1000;
    }

    public override double GetSpeed() {
        return (GetDistance() / _lenInMinutes) * 60;
    }

    public override double GetPace() {
        return _lenInMinutes / GetDistance();
    }

    protected override string GetActivityType() { return "SWIMMING"; }

}
