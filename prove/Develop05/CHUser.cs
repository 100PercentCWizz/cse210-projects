using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Text.RegularExpressions;
using System.Reflection.Metadata;
using System.Formats.Asn1;

class CHUser {

    private string Red(string inStr) {
        return $"\u001b[91m{inStr}\u001b[0m";
    }

    // PUBLIC METHODS

    public string MultipleChoice(List<List<string>> kdrList, string header, string clearSeparator = "\x1b[2J\x1b[H", int startingIndex = 1) {
        // def multipleChoice(choices, header = 'EMPTY', prompt = 'Please select an action and press ENTER: ', clearScreen = True):
        //     # A string in the choices list can be substituted for a list in the format ['key', 'display', 'return']
        //     # In this case, the option will display like so:
        //     #   1. Option 1
        //     #   2. Option 2
        //     # key. display (returns return)
        //     #   3. Option 3

        Boolean StringInList(string searchStr, List<string> inList) {
            Boolean outBool = false;
            foreach (string item in inList) {
                if (item == searchStr) {
                    outBool = true;
                }
            }
            return outBool;
        }

        List<List<string>> CleanKDRList(List<List<string>> inKdr) {
            List<List<string>> outKdr = new List<List<string>>(inKdr);
            int numeric = startingIndex;
            for (int index = 0; index < inKdr.Count; index ++) {
                // if the list element is in the format ["HOME"], convert it to the format [numeric, "HOME", "HOME"]
                if (outKdr[index].Count == 1) {
                    outKdr[index] = [$"{numeric}", outKdr[index][0], outKdr[index][0]];
                    numeric ++;
                }
                // if the list element is in the format ["Home", "HOME"], convert it to the format [numeric, "Home", "HOME"]
                if (outKdr[index].Count == 2) {
                    outKdr[index] = [$"{numeric}", outKdr[index][0], outKdr[index][1]];
                    numeric ++;
                }
                // if the list element is in the format ["h", "Home", "HOME"]
                if (outKdr[index].Count == 3) {
                    // if the return is left empty, the return will default to the display
                    if (outKdr[index][2] == "") {
                        outKdr[index][2] = outKdr[index][1];
                    }
                    // if the key is left empty, the key will be assigned a unique number
                    if (outKdr[index][0] == "") {
                        outKdr[index][0] = $"{numeric}";
                        numeric ++;
                    }
                }
            }
            return outKdr;
        }

        List<string> GetValids(List<List<string>> inKdr) {
            List<string> valids = [];
            foreach (List<string> item in inKdr) {
                valids.Add(item[0]);
            }
            return valids;
        }

        int GetLongestKeyLength(List<List<string>> inList) {
            int longest = 0;
            foreach (List<string> item in inList) {
                if (item[0].Length > longest) {
                    longest = item[0].Length;
                }
            }
            return longest;
        }

        string PrintAndPrompt(List<List<string>> inList, string error = "") {
            Console.Write(clearSeparator);
            Console.WriteLine($"\n{header}\n");
            int longestKeyLen = GetLongestKeyLength(inList);
            foreach (List<string> item in inList) {
                int paddingAmount = longestKeyLen - item[0].Length;
                string padding = " ";
                for (int i = 0; i < paddingAmount; i ++) {
                    padding = padding + " ";
                }
                Console.WriteLine($" {padding}{item[0]}. {item[1]}");
            }
            Console.Write(error);
            Console.Write("\nPlease key in an option and press ENTER: ");
            string user = Console.ReadLine();
            return user;
        }

        string userInput;

        List<List<string>> cleanedKDRList = CleanKDRList(kdrList);
        List<string> validAnswers = GetValids(cleanedKDRList);

        userInput = PrintAndPrompt(cleanedKDRList);
    
        while (!StringInList(userInput, validAnswers)) {
            userInput = PrintAndPrompt(cleanedKDRList, error: $"\n{Red($"\"{userInput}\" is an invalid response.")}");
        }
    
        foreach (List<string> item in cleanedKDRList) {
            if (userInput == item[0]) {
                userInput = item[2];
                break;
            }
        }
    
        return userInput;
    }

    // GET INT FUNCTIONS

    public int GetInt(string prompt) {

        int outInt = 0;

        int left = Console.CursorLeft;
        int top = Console.CursorTop;
        string user = "";
        Boolean repeated = false;
        Boolean stringCannotConvertToInt = true;

        while (stringCannotConvertToInt) {
            Console.CursorLeft = left;
            Console.CursorTop = top;
            for (int i = 0; i < 50; i ++) {
                Console.Write("          ");
            }
            Console.CursorLeft = left;
            Console.CursorTop = top;
            if (repeated && stringCannotConvertToInt) {
                Console.WriteLine(Red($"Sorry!  \"{user}\" cannot be converted to an integer."));
            }
            Console.Write(prompt);
            user = Console.ReadLine();
            repeated = true;
            stringCannotConvertToInt = !int.TryParse(user, out outInt);
        }

        return outInt;

    }

    public int GetIntAbove(string prompt, int minInclusive) {

        int outInt = minInclusive;

        int left = Console.CursorLeft;
        int top = Console.CursorTop;
        string user = "";
        Boolean repeated = false;
        Boolean stringCannotConvertToInt = true;

        while (stringCannotConvertToInt || outInt < minInclusive) {
            Console.CursorLeft = left;
            Console.CursorTop = top;
            for (int i = 0; i < 50; i ++) {
                Console.Write("          ");
            }
            Console.CursorLeft = left;
            Console.CursorTop = top;
            if (repeated && stringCannotConvertToInt) {
                Console.WriteLine(Red($"Sorry!  \"{user}\" cannot be converted to an integer."));
            }
            else if (outInt < minInclusive) {
                Console.WriteLine(Red($"Sorry!  \"{user}\" is not {minInclusive} or higher."));
            }
            Console.Write(prompt);
            user = Console.ReadLine();
            repeated = true;
            stringCannotConvertToInt = !int.TryParse(user, out outInt);
        }

        return outInt;

    }

    public int GetIntBelow(string prompt, int maxInclusive) {

        int outInt = maxInclusive;

        int left = Console.CursorLeft;
        int top = Console.CursorTop;
        string user = "";
        Boolean repeated = false;
        Boolean stringCannotConvertToInt = true;

        while (stringCannotConvertToInt || outInt > maxInclusive) {
            Console.CursorLeft = left;
            Console.CursorTop = top;
            for (int i = 0; i < 50; i ++) {
                Console.Write("          ");
            }
            Console.CursorLeft = left;
            Console.CursorTop = top;
            if (repeated && stringCannotConvertToInt) {
                Console.WriteLine(Red($"Sorry!  \"{user}\" cannot be converted to an integer."));
            }
            else if (outInt > maxInclusive) {
                Console.WriteLine(Red($"Sorry!  \"{user}\" is not {maxInclusive} or lower."));
            }
            Console.Write(prompt);
            user = Console.ReadLine();
            repeated = true;
            stringCannotConvertToInt = !int.TryParse(user, out outInt);
        }

        return outInt;

    }

    public int GetIntBetween(string prompt, int minInclusive, int maxInclusive) {

        int outInt = minInclusive;

        int left = Console.CursorLeft;
        int top = Console.CursorTop;
        string user = "";
        Boolean repeated = false;
        Boolean stringCannotConvertToInt = true;

        while (stringCannotConvertToInt || outInt < minInclusive || outInt > maxInclusive) {
            Console.CursorLeft = left;
            Console.CursorTop = top;
            for (int i = 0; i < 50; i ++) {
                Console.Write("          ");
            }
            Console.CursorLeft = left;
            Console.CursorTop = top;
            if (repeated && stringCannotConvertToInt) {
                Console.WriteLine(Red($"Sorry!  \"{user}\" cannot be converted to an integer."));
            }
            else if (outInt < minInclusive || outInt > maxInclusive) {
                Console.WriteLine(Red($"Sorry!  \"{user}\" is not between {minInclusive} and {maxInclusive}."));
            }
            Console.Write(prompt);
            user = Console.ReadLine();
            repeated = true;
            stringCannotConvertToInt = !int.TryParse(user, out outInt);
        }

        return outInt;

    }

    // GET FILE/DIRECTORY FUNCTIONS

    private List<string> GetFileListFromLocation(string path, List<string> fileTypes) {

        List<string> outFiles = new List<string>();
        string internalPath = path.Replace("\\", "/");

        string[] files = Directory.GetFiles(internalPath);
        Boolean isOfTheValidFileTypes;

        for (int index = 0; index < files.Count(); index ++) {

            isOfTheValidFileTypes = false;

            foreach (string fileType in fileTypes) {
                if (files[index].Contains(fileType)) {
                    isOfTheValidFileTypes = true;
                }
            }

            if (isOfTheValidFileTypes) {
                outFiles.Add(files[index].Replace("\\", "/"));
            }

        }

        return outFiles;

    }

    private List<string> GetDirectoryListFromLocation(string path) {
        List<string> outFolders = new List<string>();
        string internalPath = path.Replace("\\", "/");

        string[] folders = Directory.GetDirectories(internalPath);
        for (int index = 0; index < folders.Count(); index ++) {
            outFolders.Add($"{folders[index].Replace("\\", "/")}/");
        }
        return outFolders;
    }

    private string CondenseDirectory(string path) {

        string SubStr(string stringParam, int startInclusive, int endExclusive) {
            return stringParam.Substring(startInclusive, endExclusive - startInclusive);
        } 

        string innerPath = path.Replace("\\", "/");
        int i = innerPath.Length - 2;
        Console.WriteLine(innerPath);
        while (innerPath[i] != '/' && i > 0) { Console.WriteLine($"innerPath at {i} = {innerPath[i]}"); i --; }
        return SubStr(innerPath, i + 1, innerPath.Length);
    }

    public string GetDirectoryExplore(string baseDirectory, string valueIfCanceled, string getDirectoryHeader, string getDirectoryClearSeparator = "\x1b[2J\x1b[H") {

        string internalbaseDirectory = baseDirectory.Replace("\\", "/");
        List<List<string>> options = new List<List<string>>();
        List<string> selectedDirectories = new List<string>();
        selectedDirectories.Add(internalbaseDirectory);
        // List<string> availableFiles = new List<string>();
        List<string> availableDirectories = new List<string>();

        string user = "";

        while (user != "CANCEL" && user != "USE") {

            availableDirectories = GetDirectoryListFromLocation(selectedDirectories[selectedDirectories.Count - 1]);

            if (selectedDirectories.Count > 1 ) {
                options = [["1", "Use This Folder", "USE"], ["2", "Go Back a Folder", "BACK"]];
            }
            else {
                options = [["1", "Use This Folder\n", "USE"]];
            }
            if (availableDirectories.Count >= 1) {
                options.Add(["3", "Cancel\nENTER A FOLDER:", "CANCEL"]);
            }
            else {
                options.Add(["3", "Cancel\nENTER A FOLDER:\n  \u001b[91mNONE AVAILABLE\u001b[0m", "CANCEL"]);
            }

            foreach (string dir in availableDirectories) {
                options.Add([CondenseDirectory(dir), dir]);
            }

            user = MultipleChoice(kdrList: options, header: $"{getDirectoryHeader}\nCURRENT PATH: {selectedDirectories[selectedDirectories.Count - 1]}\n\nOPTIONS", clearSeparator: getDirectoryClearSeparator, startingIndex: 4);

            if (user == "BACK") {
                selectedDirectories.RemoveAt(selectedDirectories.Count - 1);
            }
            else if (user != "CANCEL" && user != "USE") {
                selectedDirectories.Add(user);
            }

        }

        string outDirectory;

        if (user == "USE") {
            outDirectory = selectedDirectories[selectedDirectories.Count - 1];
        }
        else {
            outDirectory = valueIfCanceled;
        }

        return outDirectory;

    }

}
