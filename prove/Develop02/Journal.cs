using System.ComponentModel.DataAnnotations;

class Journal {
    List<Entry> _entries = new List<Entry>();

    public void DisplayJournal() {
        foreach (Entry entry in _entries) {
            entry.DisplayEntry();
        }
    }

    public void SaveJournal(string filename, string separator = ",") {
        string cleanedFile = filename.Replace("\\", "/");
        using (StreamWriter outputFile = new StreamWriter(filename)) {
            foreach (Entry entry in _entries) {
                outputFile.WriteLine($"{entry._entryDate}{separator}{entry._givenPrompt}{separator}{entry._entryText}");
            }
        }
    }

    public void LoadJournal(string filename, string separator = ",") {
        _entries = [];
        string[] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines) {
            // string[] parts = line.Split(separator);
            List<string> parts = new List<string>(line.Split(separator));
            Entry entryToAppend = new Entry();
            entryToAppend._entryDate = parts[0];
            entryToAppend._givenPrompt = parts[1];
            entryToAppend._entryText = parts[2];
            _entries.Add(entryToAppend);
        }
    }

    public void AddEntry(Entry entryToAdd) {
        _entries.Add(entryToAdd);
    }
}
