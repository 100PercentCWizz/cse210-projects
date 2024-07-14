abstract class Activity {

    // MEMBER VARIABLES / ATTRIBUTES

    protected string _date;
    protected int _lenInMinutes;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public Activity(string dateParam, int lenInMinutesParam) {
        _date = dateParam;
        _lenInMinutes = lenInMinutesParam;
    }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    protected abstract string GetActivityType();

    public string GetSummary() {
        return $"{_date} {GetActivityType()} ({_lenInMinutes} min) - DISTANCE: {GetDistance()} km, SPEED: {GetSpeed()} km/h, PACE: {GetPace()} min/km";
    }

}
