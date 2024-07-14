class Student {

    // MEMBER VARIABLES / ATTRIBUTES

    private string _first;
    private string _last;
    private string _gender;
    private string _classTime;

    private List<ClassDate> _datesAttended;
    private List<ClassDate> _datesAbsent;
    private List<ClassDate> _datesUnanswered;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public Student() {

    }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    public string GetFullName() {
        return $"{_first} {_last}";
    }

    public Boolean MatchesClassTimeAndGender(string classTimeP, string genderP) {
        if (_classTime == classTimeP && _gender == genderP) {
            return true;
        }
        else {
            return false;
        }
    }

}

class ClassDate {

    // MEMBER VARIABLES / ATTRIBUTES

    private int _day;
    private int _month;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public ClassDate(int dayP, int monthP) {
        _day = dayP;
        _month = monthP;
    }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    public string GetMonthAbbreviation() {
        List<string> months = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"];
        return months[_month - 1];
    }

    public string GetDD_MMM() {
        if (_day < 10) {
            return $"0{_day} {GetMonthAbbreviation()}";
        }
        else {
            return $"{_day} {GetMonthAbbreviation()}";
        }
    }

}
