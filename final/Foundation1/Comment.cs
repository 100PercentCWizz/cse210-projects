class Comment {

    // MEMBER VARIABLES / ATTRIBUTES

    private string _commentAuthor;
    private string _text;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public Comment(string commentAuthorParam, string textParam) {
        _commentAuthor = commentAuthorParam;
        _text = textParam;
        // Console.Write("Who is the author of this comment? ");
        // _commentAuthor = Console.ReadLine();
        // Console.Write($"What was {_commentAuthor}'s comment? ");
        // _text = Console.ReadLine();
    }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    public void PrintCommentData() {
        Console.WriteLine($"{_commentAuthor} - \"{_text}\"");
    }

}
