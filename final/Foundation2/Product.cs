class Product {

    // MEMBER VARIABLES / ATTRIBUTES

    private string _name;
    private string _productId;
    private int _pricePerUnit;
    private int _quantity;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public Product(string nameParam, string productIdParam, int pricePerUnitParam, int quantityParam) {
        _name = nameParam;
        _productId = productIdParam;
        _pricePerUnit = pricePerUnitParam;
        _quantity = quantityParam;
    }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    public int GetCost() { return _pricePerUnit * _quantity; }

    public string GetPackingInfo() { return $"PRODUCT: \"{_name}\" ID: {_productId}\n"; }

}
