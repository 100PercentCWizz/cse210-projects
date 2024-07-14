class Video {

    // MEMBER VARIABLES / ATTRIBUTES

    private string _title;
    private string _author;
    private int _lenInSec;
    private List<Comment> _comments;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public Video(string titleParam, string authorParam, int lenInSecParam, List<Comment> commentsParam) {
        _title = titleParam;
        _author = authorParam;
        _lenInSec = lenInSecParam;
        _comments = commentsParam;
        // Console.Write("What is the title of this video? ");
        // _title = Console.ReadLine();
        // Console.Write($"Who is the author of this video? ");
        // _author = Console.ReadLine();

        // Console.Write($"What is the length of this video in seconds? ");
        // string response = Console.ReadLine();
        // while (!int.TryParse(response, out _lenInSec)) {
        //     Console.Write($"\"{response}\" could not be converted to an integer.\nWhat is the length of this video in seconds? ");
        //     response = Console.ReadLine();
        // }

        // _comments = new List<Comment>();
        // _comments.Add(new Comment());
        // _comments.Add(new Comment());
        // _comments.Add(new Comment());

    }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    private int GetCommentCount() { return _comments.Count; }

    public void PrintVideoData() {
        Console.WriteLine($"TITLE: \"{_title}\"");
        Console.WriteLine($"AUTHOR: {_author}");
        Console.WriteLine($"LENGTH IN SECONDS: {_lenInSec}");
        Console.WriteLine($"NUMBER OF COMMENTS: {GetCommentCount()}");
        Console.WriteLine($"-- COMMENTS --");
        foreach (Comment comment in _comments) {
            comment.PrintCommentData();
        }
        Console.WriteLine("-------------------------");
    }

}
