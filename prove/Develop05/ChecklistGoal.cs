class ChecklistGoal : Goal {

    // MEMBER VARIABLES / ATTRIBUTES

    private int _maxCompletion;
    private int _bonusPoints;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public ChecklistGoal(string description, int points, int timesCompleted, int maxCompletion, int bonusPoints) : base(description, points, timesCompleted) {
        _description = description;
        _points = points;
        _timesCompleted = timesCompleted;
        _maxCompletion = maxCompletion;
        _bonusPoints = bonusPoints;
    }

    // GETTERS / ACCESSORS ( METHODS )

    // SETTERS / MUTATORS ( METHODS )

    // OTHER METHODS

    public override int CalculateScore() {
        int pointsObtained = 0;
        pointsObtained += _timesCompleted * _points;
        if (_timesCompleted >= _maxCompletion) {
            pointsObtained += _bonusPoints;
        }
        return pointsObtained;
    }

    public override void PrintGoal() {
        Console.WriteLine($"Goal Type: Checklist");
        Console.WriteLine($"Goal Description: {_description}");
        Console.WriteLine($"Progress: {_timesCompleted}/{_maxCompletion}");
        Console.WriteLine($"Points For Each Completion: {_points}");
        Console.WriteLine($"Bonus Points For Final Completion: {_bonusPoints}");
        Console.WriteLine($"Points Obtained: {CalculateScore()}");
    }

    public override Boolean HasNotBeenCompleted() {
        if (_timesCompleted < _maxCompletion) {
            return true;
        }
        else {
            return false;
        }
    }

    public override List<string> VarsAsStrings() {
        return [
            "checklist",
            _description,
            $"{_points}",
            $"{_timesCompleted}",
            $"{_maxCompletion}",
            $"{_bonusPoints}"
        ];
    }

}
