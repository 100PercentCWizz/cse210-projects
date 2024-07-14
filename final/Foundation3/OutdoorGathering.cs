using System.Dynamic;

class OutdoorGathering : Event {

    // MEMBER VARIABLES / ATTRIBUTES

    private string _weatherForcast;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public OutdoorGathering(string titleParam, string descriptionParam, string dateParam, string timeParam, Address addressParam, string weatherForcastParam) : base(titleParam, descriptionParam, dateParam, timeParam, addressParam) {
        _weatherForcast = weatherForcastParam;
    }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    protected override string GetEventSpecificDetails() {
        return $"WEATHER FORCAST: {_weatherForcast}";
    }

    protected override string GetEventType() { return "outdoor gathering"; }

}
