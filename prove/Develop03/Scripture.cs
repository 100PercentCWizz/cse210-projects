using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

class Scripture {

    // member variables
    private List<Word> _words = new List<Word>();
    private Reference _ref = new Reference();
    
    // constructor
    // public Scripture(string textParam, Boolean isVisibleParam) {
    //     _text = textParam;
    //     _isVisible = isVisibleParam;
    // }

    // member methods

        // accessors
    // public string GetText() { return _text; }
    // public Boolean GetIsVisible() { return _isVisible; }

        // mutators
    // public void SetText(string textParam) { _text = textParam; }
    // public void SetIsVisible(Boolean isVisibleParam) { _isVisible = isVisibleParam; }

    // others
    public void RenderAndDisplayScripture() {
        Console.Write($"{_ref.GetBook()} {_ref.GetChapter()}:{_ref.GetVerse()} - ");
        foreach (Word word in _words) {
            if (word.GetIsVisible()) {
                Console.Write($"{word.GetText()} ");
            }
            else {
                int repetitions = word.GetText().Length;
                string blank = "";
                for (int i = 0; i < repetitions; i ++) {
                    blank = blank + "_";
                }
                Console.Write($"{blank} ");
            }
        }
    }

    public void ResetVisibles() {
        foreach (Word word in _words) {
            word.SetIsVisible(true);
        }
    }

    private Boolean ThereIsStillVisibleWords() {
        foreach (Word word in _words) {
            if (word.GetIsVisible()) {
                return true;
            }
        }
        return false;
    }

    public void AddInvisibles(int invisiblesToAdd) {

        Random r = new Random();

        for (int i = 0; i < invisiblesToAdd && ThereIsStillVisibleWords(); i ++) {
            int randNum = r.Next(0, _words.Count);
            Boolean wordAtIndexIsNotVisible = !_words[randNum].GetIsVisible();
            while (wordAtIndexIsNotVisible) {
                randNum = r.Next(0, _words.Count);
            }
            _words[randNum].SetIsVisible(false);
        }
    }

    public void AddWord(Word wordToAdd) { _words.Add(wordToAdd); }

    public void SetReference(Reference refParam) { _ref = refParam;  }

}
