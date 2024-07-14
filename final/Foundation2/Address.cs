class Address {

    // MEMBER VARIABLES / ATTRIBUTES

    private string _streetAddress;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public Address(string streetAddressParam, string cityParam, string stateOrProvinceParam, string countryParam) {
        _streetAddress = streetAddressParam;
        _city = cityParam;
        _stateOrProvince = stateOrProvinceParam;
        _country = countryParam;
    }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    public string GetFormattedAddress() {
        return $"{_streetAddress}\n{_city}, {_stateOrProvince}\n{_country}";
    }

}
