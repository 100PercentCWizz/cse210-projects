class Word {

    // member variables
    private string _text;
    private Boolean _isVisible;

    // constructor
    public Word(string textParam, Boolean isVisibleParam) {
        _text = textParam;
        _isVisible = isVisibleParam;
    }

    // member methods

        // accessors
    public string GetText() { return _text; }
    public Boolean GetIsVisible() { return _isVisible; }

        // mutators
    public void SetText(string textParam) { _text = textParam; }
    public void SetIsVisible(Boolean isVisibleParam) { _isVisible = isVisibleParam; }

}
