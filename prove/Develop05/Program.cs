using System;

class Program
{
    static void Main(string[] args)
    {

        GoalCollection goalCollection = new GoalCollection();

        CHUser chuser = new CHUser();
        string user = "Home";

        while (user != "End Program") {
            if (user == "Home") {
                user = chuser.MultipleChoice([["Create New Goal"], ["Display Goals"], ["Load Goals"], ["Save Goals"], ["Record Goal Progress"], ["End Program"]], $"HOME\n\nYou have {goalCollection.GetScore()} points.");
            }
            else if (user == "Create New Goal") {
                goalCollection.CreateGoal();
                user = "Home";
            }
            else if (user == "Display Goals") {
                goalCollection.DisplayGoals();
                user = "Home";
            }
            else if (user == "Load Goals") {
                goalCollection.LoadGoals();
                user = "Home";
            }
            else if (user == "Save Goals") {
                goalCollection.SaveGoals();
                user = "Home";
            }
            else if (user == "Record Goal Progress") {
                goalCollection.RecordGoalProgress();
                user = "Home";
            }
        }

    }
}
