using System.Dynamic;

class Lecture : Event {

    // MEMBER VARIABLES / ATTRIBUTES

    private string _speaker;
    private int _capacity;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public Lecture(string titleParam, string descriptionParam, string dateParam, string timeParam, Address addressParam, string speakerParam, int capacityParam) : base(titleParam, descriptionParam, dateParam, timeParam, addressParam) {
        _speaker = speakerParam;
        _capacity = capacityParam;
    }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    protected override string GetEventSpecificDetails() {
        return $"SPEAKER NAME: {_speaker}\nCAPACITY: {_capacity}";
    }

    protected override string GetEventType() { return "lecture"; }

}
