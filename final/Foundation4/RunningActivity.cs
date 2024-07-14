class RunningActivity : Activity {

    // MEMBER VARIABLES / ATTRIBUTES

    private double _distance;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public RunningActivity(string dateParam, int lenInMinutesParam, double distanceParam) : base(dateParam, lenInMinutesParam) {
        _date = dateParam;
        _lenInMinutes = lenInMinutesParam;
        _distance = distanceParam;
    }

    // GETTERS / ACCESSORS ( METHODS )

    // SETTERS / MUTATORS ( METHODS )

    // OTHER METHODS

    public override double GetDistance() {
        return _distance;
    }

    public override double GetSpeed() {
        return (_distance / _lenInMinutes) * 60;
    }

    public override double GetPace() {
        return _lenInMinutes / _distance;
    }

    protected override string GetActivityType() { return "RUNNING"; }

}
