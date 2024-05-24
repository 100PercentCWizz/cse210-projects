using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

class Scripture {

    // member variables
    private List<Word> _words = new List<Word>();
    private Reference _ref = new Reference();
    
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

    public void ResetWordsToVisible() {
        foreach (Word word in _words) {
            word.SetIsVisible(true);
        }
    }

    private Boolean ThereIsStillVisibleWords() {
        Boolean outBool = false;
        foreach (Word word in _words) {
            if (word.GetIsVisible() == true) {
                outBool = true;
            }
        }
        return outBool;
    }

    public void RemoveWords(int invisiblesToAdd) {

        Random r = new Random();

        for (int i = 0; i < invisiblesToAdd && ThereIsStillVisibleWords(); i ++) {
            int randNum = r.Next(0, _words.Count);
            while (_words[randNum].GetIsVisible() == false) {
                randNum = r.Next(0, _words.Count);
            }
            _words[randNum].SetIsVisible(false);
        }
    }

    public void AddWord(Word wordToAdd) { _words.Add(wordToAdd); }

    public void SetReference(Reference refParam) { _ref = refParam;  }

}
