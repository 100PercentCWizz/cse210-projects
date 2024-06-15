using System;

class Program {
    static void Main(string[] args) {

        CHUser chuser = new CHUser();
        BreathingActivity breath = new BreathingActivity();
        ListingActivity listA = new ListingActivity();
        ReflectionActivity reflect = new ReflectionActivity();
        string user = "HOME";

        while (user != "END PROGRAM") {
            if (user == "HOME") {
                user = chuser.MultipleChoice([["Breathing Activity"], ["Listing Activity"], ["Reflection Activity"], ["End Program", "END PROGRAM"]], "HOME");
            }
            else if (user == "Breathing Activity") {
                breath.DoBreathingActivity();
                user = "HOME";
            }
            else if (user == "Listing Activity") {
                listA.DoListingActivity();
                user = "HOME";
            }
            else if (user == "Reflection Activity") {
                reflect.DoReflectionActivity();
                user = "HOME";
            }
        }

    }
}
