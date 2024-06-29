class SimpleGoal : Goal {

    // MEMBER VARIABLES / ATTRIBUTES

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public SimpleGoal(string description, int points, int timesCompleted) : base(description, points, timesCompleted) {
        _description = description;
        _points = points;
        _timesCompleted = timesCompleted;
    }

    // GETTERS / ACCESSORS ( METHODS )

    // SETTERS / MUTATORS ( METHODS )

    // OTHER METHODS

    public override int CalculateScore() {
        if (_timesCompleted > 0) {
            return _points;
        }
        else {
            return 0;
        }
    }

    public override void PrintGoal() {
        string completionStatus;
        if (_timesCompleted > 0) {
            completionStatus = "COMPLETED";
        }
        else {
            completionStatus = "NOT COMPLETED";
        }
        Console.WriteLine($"Goal Type: Simple");
        Console.WriteLine($"Goal Description: {_description}");
        Console.WriteLine($"Points Upon Completion: {_points}");
        Console.WriteLine($"Completion Status: {completionStatus}");
        Console.WriteLine($"Points Obtained: {CalculateScore()}");
    }

    public override Boolean HasNotBeenCompleted() {
        if (_timesCompleted < 1) {
            return true;
        }
        else {
            return false;
        }
    }

    public override List<string> VarsAsStrings() {
        return [
            "simple",
            _description,
            $"{_points}",
            $"{_timesCompleted}",
            "",
            ""
        ];
    }

}
