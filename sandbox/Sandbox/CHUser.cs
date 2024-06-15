using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Text.RegularExpressions;
using System.Reflection.Metadata;
using System.Formats.Asn1;

class CHUser {

    private string Red(string inStr) {
        return $"\u001b[91m{inStr}\u001b[0m";
    }

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

    // PUBLIC METHODS

    // public int GetIntInRange(string prompt, int intInclusive, int intExclusive) {
        
    // }

    public string MultipleChoice(List<List<string>> kdrList, string header, string clearSeparator = "\x1b[2J\x1b[H", int startingIndex = 1) {
        // def multiple_choice(choices, header = 'EMPTY', prompt = 'Please select an action and press ENTER: ', clear_screen = True):
        //     # A string in the choices list can be substituted for a list in the format ['key', 'display', 'return']
        //     # In this case, the option will display like so:
        //     #   1. Option 1
        //     #   2. Option 2
        //     # key. display (returns return)
        //     #   3. Option 3

        Boolean StringInList(string search_str, List<string> in_list) {
            Boolean out_bool = false;
            foreach (string item in in_list) {
                if (item == search_str) {
                    out_bool = true;
                }
            }
            return out_bool;
        }

        List<List<string>> CleanKDRList(List<List<string>> in_kdr) {
            List<List<string>> out_kdr = new List<List<string>>(in_kdr);
            int numeric = startingIndex;
            for (int index = 0; index < in_kdr.Count; index ++) {
                // if the list element is in the format ["HOME"], convert it to the format [numeric, "HOME", "HOME"]
                if (out_kdr[index].Count == 1) {
                    out_kdr[index] = [$"{numeric}", out_kdr[index][0], out_kdr[index][0]];
                    numeric ++;
                }
                // if the list element is in the format ["Home", "HOME"], convert it to the format [numeric, "Home", "HOME"]
                if (out_kdr[index].Count == 2) {
                    out_kdr[index] = [$"{numeric}", out_kdr[index][0], out_kdr[index][1]];
                    numeric ++;
                }
                // if the list element is in the format ["h", "Home", "HOME"]
                if (out_kdr[index].Count == 3) {
                    // if the return is left empty, the return will default to the display
                    if (out_kdr[index][2] == "") {
                        out_kdr[index][2] = out_kdr[index][1];
                    }
                    // if the key is left empty, the key will be assigned a unique number
                    if (out_kdr[index][0] == "") {
                        out_kdr[index][0] = $"{numeric}";
                        numeric ++;
                    }
                }
            }
            return out_kdr;
        }

        List<string> GetValids(List<List<string>> in_kdr) {
            List<string> valids = [];
            foreach (List<string> item in in_kdr) {
                valids.Add(item[0]);
            }
            return valids;
        }

        int GetLongestKeyLength(List<List<string>> in_list) {
            int longest = 0;
            foreach (List<string> item in in_list) {
                if (item[0].Length > longest) {
                    longest = item[0].Length;
                }
            }
            return longest;
        }

        string PrintAndPrompt(List<List<string>> in_list, string error = "") {
            Console.Write(clearSeparator);
            Console.WriteLine($"\n{header}\n");
            int longest_key_len = GetLongestKeyLength(in_list);
            foreach (List<string> item in in_list) {
                int padding_amount = longest_key_len - item[0].Length;
                string padding = " ";
                for (int i = 0; i < padding_amount; i ++) {
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

    // public string GetFileExplore(string baseDirectory, string valueIfCanceled, string header, List<string> fileTypes = ["."], string clearSeparator = "\x1b[2J\x1b[H") {

    //     string internalbaseDirectory = baseDirectory.Replace("\\", "/");
    //     List<List<string>> options = new List<List<string>>();
    //     List<string> selectedDirectories = new List<string>();
    //     selectedDirectories.Add(internalbaseDirectory);
    //     List<string> availableFiles = new List<string>();
    //     List<string> availableDirectories = new List<string>();

    //     //
    //     List<List<string>> optionPairs = new List<List<string>>();
    //     string otherOptions;
    //     string fileOptions;
    //     string folderOptions;

    //     optionPairs = [];

    //     otherOptions = "";
    //     if (selectedDirectories.Count > 1) {
    //         otherOptions = "    1. Go Back a Folder";
    //         optionPairs.Add(["1", "BACK"]);
    //     }
    //     else {
    //         otherOptions = "";
    //     }
    //     if (selectedDirectories.Contains(".")) {
    //         otherOptions = otherOptions + "\n    2. Use This File";
    //         optionPairs.Add(["2", "USE"]);
    //     }
    //     else {
    //         otherOptions = otherOptions + "\n";
    //     }
    //     otherOptions = $"{otherOptions}\n    3. Cancel";
    //     optionPairs.Add(["3", "CANCEL"]);

    //     int numeric = 4;
    //     if (selectedDirectories[selectedDirectories.Count - 1].Contains(".")) {
    //         fileOptions = "";
    //         folderOptions = "";
    //     }
    //     else {
    //         if (availableFiles.Count >= 1) {
    //             fileOptions = "\nSELECT A FILE:\n";
    //             foreach (string file in availableFiles) {
    //                 fileOptions = $"{fileOptions}{numeric}. {CondenseDirectory(file)}\n";
    //                 optionPairs.Add([$"{numeric}", file]);
    //                 numeric ++;
    //             }
    //         }
    //         else {
    //             fileOptions = $"\nSELECT A FILE: {Red("NONE AVAILABLE")}\n";
    //         }
    //     }

    //     //         $"\n{header}\n\nCURRENT PATH: {currentPath}\n\n{otherOptions}{fileOptions}{folderOptions}/**/\nPlease key in an action and press ENTER: ";
    //     //

    //     string user = "";

    //     while (user != "CANCEL" && user != "USE") {

    //         // if the last selected item is a file, then clear out the available files and directories
    //         if (selectedDirectories[selectedDirectories.Count - 1].Contains(".")) {
    //             availableFiles = [];
    //             availableDirectories = [];
    //         }
    //         // if the last selected item is a directory, then open that directory and get all the child files and child directories
    //         else {
    //             availableFiles = GetFileListFromLocation(selectedDirectories[selectedDirectories.Count - 1]);
    //             availableDirectories = GetDirectoryListFromLocation(selectedDirectories[selectedDirectories.Count - 1]);
    //         }

    //         // populate our option list depending on what files and folders are available
    //         options = [];

    //         if (selectedDirectories.Count > 1) {
    //             options.Add(["1", "Go Back a Folder", "BACK"]);
    //         }

    //         options.Add(["3", "Cancel\nSELECT A FILE:", "CANCEL"]);

    //         if (availableFiles.Count >= 1) {
    //             for (int i = 0; i < availableFiles.Count - 1; i ++) {
    //                 options.Add([CondenseDirectory(availableFiles[i]), availableFiles[i]]);
    //             }
    //             options.Add([$"{CondenseDirectory(availableFiles[availableFiles.Count - 1])}\nSELECT A FOLDER:", availableFiles[availableFiles.Count - 1]]);
    //         }
    //         else {
    //             options[options.Count - 1] = ["3", "Cancel\nSELECT A FILE:\n  \u001b[91mNONE AVAILABLE\u001b[0m\n", "CANCEL"];
    //         }
    //         if (availableDirectories.Count >= 1) {
    //             for (int i = 0; i < availableDirectories.Count; i ++) {
    //                 options.Add([CondenseDirectory(availableDirectories[i]), availableDirectories[i]]);
    //             }
    //         }
    //         else {
    //             if (availableFiles.Count >= 1) {
    //                 options[options.Count - 1][1] = $"{options[options.Count - 1][1]}\n  \u001b[91mNONE AVAILABLE\u001b[0m";
    //             }
    //             else {
    //                 options[options.Count - 1][1] = $"{options[options.Count - 1][1]}\nSELECT A FOLDER:\n  \u001b[91mNONE AVAILABLE\u001b[0m";
    //             }
    //         }

    //         user = MultipleChoice(options, header, clearSeparator, startingIndex: 4);

    //         // process user response
    //         if (user == "BACK") {
    //             selectedDirectories.RemoveAt(selectedDirectories.Count - 1);
    //         }
    //         else if (user != "USE" && user != "CANCEL") {
    //             selectedDirectories.Add(user);
    //         }
        
    //     }

    //     if (user == "CANCEL") {
    //         user = valueIfCanceled;
    //     }
    //     else if (user == "USE") {
    //         user = selectedDirectories[selectedDirectories.Count - 1];
    //     }

    //     return user;
    // }

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
