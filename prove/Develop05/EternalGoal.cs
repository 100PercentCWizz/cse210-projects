class EternalGoal : Goal {

    // MEMBER VARIABLES / ATTRIBUTES

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public EternalGoal(string description, int points, int timesCompleted) : base(description, points, timesCompleted) {
        _description = description;
        _points = points;
        _timesCompleted = timesCompleted;
    }

    // GETTERS / ACCESSORS ( METHODS )

    // SETTERS / MUTATORS ( METHODS )

    // OTHER METHODS

    public override int CalculateScore() {
        return _points * _timesCompleted;
    }

    public override void PrintGoal() {
        Console.WriteLine($"Goal Type: Eternal");
        Console.WriteLine($"Goal Description: {_description}");
        Console.WriteLine($"Points For Each Completion: {_points}");
        Console.WriteLine($"Times Completed: {_timesCompleted}");
        Console.WriteLine($"Points Obtained: {CalculateScore()}");
    }

    public override Boolean HasNotBeenCompleted() {
        return true;
    }

    public override List<string> VarsAsStrings() {
        return [
            "eternal",
            _description,
            $"{_points}",
            $"{_timesCompleted}",
            "",
            ""
        ];
    }

}
