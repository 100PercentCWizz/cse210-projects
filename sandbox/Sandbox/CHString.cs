using System.ComponentModel.Design;

class CHString {

    // MEMBER VARIABLES / ATTRIBUTES

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    public string TextRepeated(string text, int repetitions) {
        string outStr = "";
        for (int i = 0; i < repetitions; i ++) {
            outStr = outStr + text;
        }
        return outStr;
    }

    public string LeftAlign(string text, int totalLength) {
        int rPad = totalLength - text.Count();
        return $"{text}{TextRepeated(" ", rPad)}";
    }

    public string CenterAlign(string text, int totalLength) {
        int lPad = (totalLength - text.Count()) / 2;
        int rPad = (totalLength - text.Count()) - lPad;
        return $"{TextRepeated(" ", lPad)}{text}{TextRepeated(" ", rPad)}";
    }

    public string RightAlign(string text, int totalLength) {
        int rPad = totalLength - text.Count();
        return $"{TextRepeated(" ", rPad)}{text}";
    }

    public void SlowPrint(string text, int printSpeed = 25) {
        for (int i = 0; i < text.Count(); i ++) {
            Console.Write(text[i]);
            Thread.Sleep(printSpeed);
        }
    }

    public string ResetColor() { return "\u001b[0m"; }
    public string Red() { return "\u001b[91m"; }
    public string Red(string text) {
        return $"\u001b[91m{text}\u001b[0m";
    }
    public string Green() { return "\u001B[32m"; }
    public string Yellow() { return "\u001B[93m"; }

    public void DisplayDB(List<List<string>> database) {

        List<int> GetColumnWidths() {

            List<int> colWidths = new List<int>();

            // create list of zeros [0, 0, 0, 0, 0]
            for (int colIndex = 0; colIndex < database[0].Count; colIndex ++) {
                colWidths.Add(0);
            }

            // if the string is longer than the greatest width (contained in colWidths), then replace it with the length of the new longest string
            for (int rowIndex = 0; rowIndex < database.Count; rowIndex ++) {
                for (int colIndex = 0; colIndex < database[0].Count; colIndex ++) {
                    if (database[rowIndex][colIndex].Count() > colWidths[colIndex]) {
                        colWidths[colIndex] = database[rowIndex][colIndex].Count();
                    }
                }
            }
        
            return colWidths;

        }

        void DisplayLine(List<string> databaseEntry, List<int> columnWidths) {
            for (int i = 0; i < databaseEntry.Count; i ++) {
                if (i == 0) {
                    Console.Write($"| {LeftAlign(databaseEntry[i], columnWidths[i])}");
                }
                else {
                    Console.Write($" | {LeftAlign(databaseEntry[i], columnWidths[i])}");
                }
            }
            Console.Write("|\n");
        }

        List<int> colWidths = GetColumnWidths();

        foreach (List<string> entry in database) {
            DisplayLine(entry, colWidths);
        }

    }

}
