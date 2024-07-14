using System.Dynamic;

abstract class Event {

    // MEMBER VARIABLES / ATTRIBUTES

    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public Event(string titleParam, string descriptionParam, string dateParam, string timeParam, Address addressParam) {
        _title = titleParam;
        _description = descriptionParam;
        _date = dateParam;
        _time = timeParam;
        _address = addressParam;
    }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    protected abstract string GetEventSpecificDetails();

    protected abstract string GetEventType();

    public string GetStandardDetails() {
        return $"--- STANDARD DETAILS ---\nEVENT: {_title}\nDESCRIPTION: {_description}\nWHEN: {_date} at {_time}\nWHERE:\n{_address.GetFormattedAddress()}";
    }

    public string GetFullDetails() {
        return $"--- FULL DETAILS ---\nEVENT: {_title}\nDESCRIPTION: {_description}\nWHEN: {_date} at {_time}\nWHERE:\n{_address.GetFormattedAddress()}\nEVENT TYPE: {GetEventType()}\n{GetEventSpecificDetails()}";
    }

    public string GetShortDetails() {
        return $"--- SHORT DETAILS ---\nEVENT: {_title}\nEVENT TYPE: {GetEventType()}\nWHEN: {_date}";
    }

}
