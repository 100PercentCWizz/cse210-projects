class Fraction {

    // MEMBER VARIABLES / ATTRIBUTES

    private int _numerator;
    private int _denominator;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

    //     CONSTRUCTORS ( METHODS )

    public Fraction() {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int numerParam) {
        _numerator = numerParam;
        _denominator = 1;
    }

    public Fraction(int numerParam, int denomParam) {
        _numerator = numerParam;
        _denominator = denomParam;
    }

    //     GETTERS / ACCESSORS ( METHODS )

    public int GetNumerator() { return _numerator; }
    public int GetDenominator() { return _denominator; }

    //     SETTERS / MUTATORS ( METHODS )

    public void SetNumerator(int numerParam) { _numerator = numerParam; }
    public void SetDenominator(int denomParam) { _denominator = denomParam; }

    //     OTHER METHODS

    public string GetFractionalString() { return $"{_numerator}/{_denominator}"; }

    public double GetDecimalValue() { return (double)_numerator / (double)_denominator; }

}
