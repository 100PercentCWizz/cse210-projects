abstract class Goal {

    // MEMBER VARIABLES / ATTRIBUTES

    protected string _description;
    protected int _points;
    protected int _timesCompleted;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public Goal(string description, int points, int timesCompleted) {
        _description = description;
        _points = points;
        _timesCompleted = timesCompleted;
    }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    public abstract void PrintGoal();

    public abstract int CalculateScore();

    public abstract Boolean HasNotBeenCompleted();

    public void IncrementCompletion() {
        _timesCompleted ++;
    }

    public string GetDescription() { return _description; }

    public int GetTimesCompleted() { return _timesCompleted; }

    public abstract List<string> VarsAsStrings();

}
