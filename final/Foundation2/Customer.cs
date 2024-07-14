using System.Dynamic;

class Customer {

    // MEMBER VARIABLES / ATTRIBUTES

    private string _name;
    private Address _address;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public Customer(string nameParam, Address addressParam) {
        _name = nameParam;
        _address = addressParam;
    }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    public string GetMailingAddress() {
        return $"{_name}\n{_address.GetFormattedAddress()}";
    }

    public Boolean IsFromTheUSA() {
        if (_address.GetFormattedAddress().Contains("USA")) {
            return true;
        }
        else {
            return false;
        }
    }

}
