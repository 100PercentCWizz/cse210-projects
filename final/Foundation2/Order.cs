class Order {

    // MEMBER VARIABLES / ATTRIBUTES

    private List<Product> _products;
    private Customer _customer;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public Order(List<Product> productsParam, Customer customerParam) {
        _products = productsParam;
        _customer = customerParam;
    }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    private int GetShippingCost() {
        if (_customer.IsFromTheUSA()) {
            return 500;
        }
        else {
            return 3500;
        }
    }

    public int CalculateTotalCost() {
        int outVal = 0;
        foreach (Product product in _products) {
            outVal += product.GetCost();
        }
        outVal += GetShippingCost();
        return outVal;
    }

    public string GetPackingLabel() {
        string packingLabel = "";
        foreach (Product product in _products) {
            packingLabel = packingLabel + product.GetPackingInfo();
        }
        return packingLabel;
    }

    public string GetShippingLabel() {
        return _customer.GetMailingAddress();
    }

    public void DisplayAll() {
        Console.WriteLine("-----  ORDER  -----");
        Console.WriteLine("\nPACKING LABEL:");
        Console.WriteLine(GetPackingLabel());
        Console.WriteLine("SHIPPING LABEL");
        Console.WriteLine(GetShippingLabel());
        Console.WriteLine("\nTOTAL PRICE:");
        Console.WriteLine($"${CalculateTotalCost() / 100}.{CalculateTotalCost() % 100}");
        Console.WriteLine();
    }

}
