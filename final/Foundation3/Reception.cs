using System.Dynamic;

class Reception : Event {

    // MEMBER VARIABLES / ATTRIBUTES

    private string _rsvp;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public Reception(string titleParam, string descriptionParam, string dateParam, string timeParam, Address addressParam, string rsvpParam) : base(titleParam, descriptionParam, dateParam, timeParam, addressParam) {
        _rsvp = rsvpParam;
    }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    protected override string GetEventSpecificDetails() {
        return $"RSVP TO: {_rsvp}";
    }

    protected override string GetEventType() { return "reception"; }

}
