class Reference {

        // member variables
    private string _book;
    private string _chapter;
    private string _verse;

    // constructor
    public Reference(string bookParam = "", string chapterParam = "", string verseParam = "") {
        _book = bookParam;
        _chapter = chapterParam;
        _verse = verseParam;
    }

    // member methods

        // accessors
    public string GetBook() { return _book; }
    public string GetChapter() { return _chapter; }
    public string GetVerse() { return _verse; }

}
