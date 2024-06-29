using System.ComponentModel;
using System.Reflection.Metadata;

class GoalCollection {

    // MEMBER VARIABLES / ATTRIBUTES

    private List<Goal> _goals = new List<Goal>();

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    public int GetScore() {
        int score = 0;
        foreach (Goal goal in _goals) {
            score += goal.CalculateScore();
        }
        return score;
    }

    private string TextRepeated(string text, int repetitions) {
        string outString = "";
        for (int i = 0; i < repetitions; i ++) {
            outString = outString + text;
        }
        return outString;
    }

    public void DisplayGoals() {
        Console.Clear();
        Console.WriteLine("\nHOME > DISPLAY GOALS\n");
        Console.WriteLine(TextRepeated("-", 50));
        foreach (Goal goal in _goals) {
            goal.PrintGoal();
            Console.WriteLine(TextRepeated("-", 50));
        }
        Console.WriteLine("\nAll goals have been printed.\n\nPress ENTER to return to HOME.");
        Console.ReadLine();
    }

    public void CreateGoal() {
        CHUser chuser = new CHUser();
        string user = "";
        user = chuser.MultipleChoice([["Create Simple Goal"], ["Create Eternal Goal"], ["Create Checklist Goal"], ["Cancel"]], "HOME > ADD NEW GOAL");
        
        Console.Write("\nPlease give this goal a title/description: ");
        string description = Console.ReadLine();
        int points = chuser.GetIntAbove("\nHow many points will be awarded when this goal is completed? ", 1);

        if (user == "Create Simple Goal") {
            _goals.Add(new SimpleGoal(description, points, 0));
        }
        else if (user == "Create Eternal Goal") {
            _goals.Add(new EternalGoal(description, points, 0));
        }
        else if (user == "Create Checklist Goal") {
            int maxCompletion = chuser.GetIntAbove("\nHow many times must this goal be completed to complete the overall goal? ", 1);
            int bonusPoints = chuser.GetIntAbove("\nHow many BONUS POINTS will be awarded upon the overall completion of this goal? ", 1);
            _goals.Add(new ChecklistGoal(description, points, 0, maxCompletion, bonusPoints));
        }
        Console.WriteLine("\nThe new goal has been added.\n\nPress ENTER to return to HOME.");
        Console.ReadLine();
    }

    public void LoadGoals() {
        _goals = [];
        Console.Clear();
        Console.Write("\nHOME > LOAD GOALS\n\nPlease provide the path to extract the goals from: ");
        string filename = Console.ReadLine();
        filename.Replace("\\", "/");
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines) {
            List<string> parts = new List<string>(line.Split("|"));
            if (parts[0].Trim() == "simple") {
                _goals.Add(new SimpleGoal(parts[1].Trim(), int.Parse(parts[2].Trim()), int.Parse(parts[3].Trim())));
            }
            else if (parts[0].Trim() == "eternal") {
                _goals.Add(new EternalGoal(parts[1].Trim(), int.Parse(parts[2].Trim()), int.Parse(parts[3].Trim())));
            }
            else if (parts[0].Trim() == "checklist") {
                _goals.Add(new ChecklistGoal(parts[1].Trim(), int.Parse(parts[2].Trim()), int.Parse(parts[3].Trim()), int.Parse(parts[4].Trim()), int.Parse(parts[5].Trim())));
            }
        }
        Console.WriteLine("\nThe goals have been loaded.\n\nPress ENTER to return to HOME.");
        Console.ReadLine();
    }

    private void SaveListToTxt(string filename, List<List<string>> dataToSave, string separator) {
        
        List<int> GetLongests(List<List<string>> data) {
            List<int> outList = new List<int>();
            for (int i = 0; i < data[0].Count; i ++) {
                outList.Add(0);
            }
            foreach (List<string> entry in data) {
                for (int i = 0; i < entry.Count; i ++) {
                    if (entry[i].Count() > outList[i]) {
                        outList[i] = entry[i].Count();
                    }
                }
            }
            return outList;
        }

        string AlignLeft(string text, int totalChars) {
            string outString = text;
            while (outString.Count() < totalChars) {
                outString = outString + " ";
            }
            return outString;
        }

        List<int> longestLens = GetLongests(dataToSave);

        List<string> linesToWrite = new List<string>();
        foreach (List<string> entry in dataToSave) {
            string line = AlignLeft(entry[0], longestLens[0]);
            for (int i = 1; i < entry.Count; i ++) {
                line = $"{line}{separator}{AlignLeft(entry[i], longestLens[i])}";
            }
            linesToWrite.Add(line);
        }

        using (StreamWriter outputFile = new StreamWriter(filename)) {
            foreach (string line in linesToWrite) {
                outputFile.WriteLine(line);
            }
        }

    }

    public void SaveGoals() {
        Console.Clear();
        Console.Write("\nHOME > SAVE GOALS\n\nPlease provide the path where the goals will be saved: ");
        string filename = Console.ReadLine();
        filename = filename.Replace("\\", "/");
        
        List<List<string>> dataToSave = new List<List<string>>();
        dataToSave.Add(["GOAL TYPE", "DESCRIPTION", "POINTS", "TIMES COMPLETED", "MAX COMPLETION", "BONUS POINTS"]);
        foreach (Goal goal in _goals) {
            dataToSave.Add(goal.VarsAsStrings());
        }
        SaveListToTxt(filename, dataToSave, " | ");

        Console.WriteLine("\nThe goals have been saved.\n\nPress ENTER to return to HOME.");
        Console.ReadLine();
    }

    public void RecordGoalProgress() {
        CHUser chuser = new CHUser();
        List<List<string>> options = new List<List<string>>();
        foreach (Goal goal in _goals) {
            if (goal.HasNotBeenCompleted()) {
                options.Add([$"Mark \"{goal.GetDescription()}\" goal.", goal.GetDescription()]);
            }
        }
        options.Add(["Cancel"]);
        string selectedGoal = chuser.MultipleChoice(options, "HOME > RECORD GOAL PROGRESS");
        if (selectedGoal != "Cancel") {
            foreach (Goal goal in _goals) {
                if (goal.GetDescription() == selectedGoal) {
                    goal.IncrementCompletion();
                }
            }
            Console.WriteLine("\nYour goal progress has been updated and your points have been awarded.\n\nPress ENTER to return to HOME.");
        }
        else {
            Console.WriteLine("\nCanceled.  No values have been changed.\n\nPress ENTER to return to HOME.");
        }
        Console.ReadLine();
    }

}
