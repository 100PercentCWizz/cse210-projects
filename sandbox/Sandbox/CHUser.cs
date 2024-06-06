using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Text.RegularExpressions;
using System.Reflection.Metadata;
using System.Formats.Asn1;

class CHUser {

    public string MultipleChoice(List<List<string>> kdr_list, string header = "EMPTY", string clearSeparator = "\x1b[2J\x1b[H", int startingIndex = 1) {
    // def multiple_choice(choices, header = 'EMPTY', prompt = 'Please select an action and press ENTER: ', clear_screen = True):
    //     # A string in the choices list can be substituted for a list in the format ['key', 'display', 'return']
    //     # In this case, the option will display like so:
    //     #   1. Option 1
    //     #   2. Option 2
    //     # key. display (returns return)
    //     #   3. Option 3

        // void cls() {
        //     string clearString = "\x1b[2J\x1b[H";
        //     Console.Write(clearString);
        // }

        string red(string inStr) {
            return $"\u001b[91m{inStr}\u001b[0m";
        }

        Boolean str_in_list(string search_str, List<string> in_list) {
            Boolean out_bool = false;
            foreach (string item in in_list) {
                if (item == search_str) {
                    out_bool = true;
                }
            }
            return out_bool;
        }

        List<List<string>> clean_up_kdr_list(List<List<string>> in_kdr) {
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

        List<string> get_valids(List<List<string>> in_kdr) {
            List<string> valids = [];
            foreach (List<string> item in in_kdr) {
                valids.Add(item[0]);
            }
            return valids;
        }

        int get_longest_key_len(List<List<string>> in_list) {
            int longest = 0;
            foreach (List<string> item in in_list) {
                if (item[0].Length > longest) {
                    longest = item[0].Length;
                }
            }
            return longest;
        }

        string print_and_prompt(List<List<string>> in_list, string error = "") {
            // if (clear_screen == true) {
            //     // Console.WriteLine("---  CLEAR  HERE  ---");
            //     cls();
            // }
            Console.Write(clearSeparator);
            Console.WriteLine($"\n{header}\n");
            int longest_key_len = get_longest_key_len(in_list);
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

        string user_input;

        List<List<string>> cleaned_kdr_list = clean_up_kdr_list(kdr_list);
        List<string> valid_answers = get_valids(cleaned_kdr_list);

        user_input = print_and_prompt(cleaned_kdr_list);
    
        while (!str_in_list(user_input, valid_answers)) {
            user_input = print_and_prompt(cleaned_kdr_list, error: $"\n{red($"\"{user_input}\" is an invalid response.")}");
        }
    
        foreach (List<string> item in cleaned_kdr_list) {
            if (user_input == item[0]) {
                user_input = item[2];
                break;
            }
        }
    
        return user_input;
    }

    public string TypedMultipleChoice(string prompt, List<List<string>> keyReturnList, string clearSeparator = "\x1b[2J\x1b[H") {
        
        string Red(string stringParam) {
            return $"\u001b[91m{stringParam}\u001b[0m";
        }

        Boolean AnswerIsInvalid(string search_str, List<string> in_list) {
            Boolean outBool = false;
            foreach (string item in in_list) {
                if (item == search_str) {
                    outBool = true;
                }
            }
            return !outBool;
        }
        
        List<string> GetValidInputs(List<List<string>> loloStringParam) {
            List<string> outList = new List<string>();
            foreach (List<string> keyReturnPair in loloStringParam) {
                outList.Add(keyReturnPair[0]);
            }
            return outList;
        }

        string PrintAndPrompt(string error = "") {
            Console.Write($"{clearSeparator}{prompt.Replace("/**/", error)}");
            return Console.ReadLine();
        }

        string user;
        List<string> validAnswers = GetValidInputs(keyReturnList);

        user = PrintAndPrompt();
    
        while (AnswerIsInvalid(user, validAnswers)) {
            user = PrintAndPrompt(error: $"\n{Red($"\"{user}\" is an invalid response.")}");
        }
    
        foreach (List<string> item in keyReturnList) {
            if (user == item[0]) {
                user = item[1];
                break;
            }
        }

        return user;
    }

    private List<string> GetFileList(string path) {
        List<string> outFiles = new List<string>();
        string internalPath = path.Replace("\\", "/");

        string[] files = Directory.GetFiles(internalPath);
        for (int index = 0; index < files.Count(); index ++) {
            outFiles.Add(files[index].Replace("\\", "/"));
        }
        return outFiles;
    }

    private List<string> GetDirList(string path) {
        List<string> outFolders = new List<string>();
        string internalPath = path.Replace("\\", "/");

        string[] folders = Directory.GetDirectories(internalPath);
        for (int index = 0; index < folders.Count(); index ++) {
            outFolders.Add($"{folders[index].Replace("\\", "/")}/");
        }
        return outFolders;
    }

    private string CondensePath(string path) {

        string SubStr(string stringParam, int startInclusive, int endExclusive) {
            return stringParam.Substring(startInclusive, endExclusive - startInclusive);
        } 

        string innerPath = path.Replace("\\", "/");
        int i = innerPath.Length - 2;
        Console.WriteLine(innerPath);
        while (innerPath[i] != '/' && i > 0) { Console.WriteLine($"innerPath at {i} = {innerPath[i]}"); i --; }
        return SubStr(innerPath, i + 1, innerPath.Length);
    }

    public string GetFileExplore(string baseDir, string valueIfCanceled = "CANCELED", string header = "EMPTY", string clearSeparator = "\x1b[2J\x1b[H") {
        
        string Red(string inStr) {
            return $"\u001b[91m{inStr}\u001b[0m";
        }

        string internalBaseDir = baseDir.Replace("\\", "/");
        List<List<string>> options = new List<List<string>>();
        List<string> selectedDirs = new List<string>();
        selectedDirs.Add(internalBaseDir);
        List<string> availableFiles = new List<string>();
        List<string> availableDirs = new List<string>();

//
        List<List<string>> optionPairs = new List<List<string>>();
        string otherOptions;
        string fileOptions;
        string folderOptions;

        optionPairs = [];

        otherOptions = "";
        if (selectedDirs.Count > 1) {
            otherOptions = "    1. Go Back a Folder";
            optionPairs.Add(["1", "BACK"]);
        }
        else {
            otherOptions = "";
        }
        if (selectedDirs.Contains(".")) {
            otherOptions = otherOptions + "\n    2. Use This File";
            optionPairs.Add(["2", "USE"]);
        }
        else {
            otherOptions = otherOptions + "\n";
        }
        otherOptions = $"{otherOptions}\n    3. Cancel";
        optionPairs.Add(["3", "CANCEL"]);

        int numeric = 4;
        if (selectedDirs[selectedDirs.Count - 1].Contains(".")) {
            fileOptions = "";
            folderOptions = "";
        }
        else {
            if (availableFiles.Count >= 1) {
                fileOptions = "\nSELECT A FILE:\n";
                foreach (string file in availableFiles) {
                    fileOptions = $"{fileOptions}{numeric}. {CondensePath(file)}\n";
                    optionPairs.Add([$"{numeric}", file]);
                    numeric ++;
                }
            }
            else {
                fileOptions = $"\nSELECT A FILE: {Red("NONE AVAILABLE")}\n";
            }
        }


//         $"\n{header}\n\nCURRENT PATH: {currentPath}\n\n{otherOptions}{fileOptions}{folderOptions}/**/\nPlease key in an action and press ENTER: ";
//

        string user = "";

        while (user != "CANCEL" && user != "USE") {

            // if the last selected item is a file, then clear out the available files and directories
            if (selectedDirs[selectedDirs.Count - 1].Contains(".")) {
                availableFiles = [];
                availableDirs = [];
            }
            // if the last selected item is a directory, then open that directory and get all the child files and child directories
            else {
                availableFiles = GetFileList(selectedDirs[selectedDirs.Count - 1]);
                availableDirs = GetDirList(selectedDirs[selectedDirs.Count - 1]);
            }

            // populate our option list depending on what files and folders are available
            options = [];

            if (selectedDirs.Count > 1) {
                options.Add(["1", "Go Back a Folder", "BACK"]);
            }

            options.Add(["3", "Cancel\nSELECT A FILE:", "CANCEL"]);

            if (availableFiles.Count >= 1) {
                for (int i = 0; i < availableFiles.Count - 1; i ++) {
                    options.Add([CondensePath(availableFiles[i]), availableFiles[i]]);
                }
                options.Add([$"{CondensePath(availableFiles[availableFiles.Count - 1])}\nSELECT A FOLDER:", availableFiles[availableFiles.Count - 1]]);
            }
            else {
                options[options.Count - 1] = ["3", "Cancel\nSELECT A FILE:\n  \u001b[91mNONE AVAILABLE\u001b[0m\n", "CANCEL"];
            }
            if (availableDirs.Count >= 1) {
                for (int i = 0; i < availableDirs.Count; i ++) {
                    options.Add([CondensePath(availableDirs[i]), availableDirs[i]]);
                }
            }
            else {
                if (availableFiles.Count >= 1) {
                    options[options.Count - 1][1] = $"{options[options.Count - 1][1]}\n  \u001b[91mNONE AVAILABLE\u001b[0m";
                }
                else {
                    options[options.Count - 1][1] = $"{options[options.Count - 1][1]}\nSELECT A FOLDER:\n  \u001b[91mNONE AVAILABLE\u001b[0m";
                }
            }

            user = MultipleChoice(options, header, clearSeparator, startingIndex: 4);

            // process user response
            if (user == "BACK") {
                selectedDirs.RemoveAt(selectedDirs.Count - 1);
            }
            else if (user != "USE" && user != "CANCEL") {
                selectedDirs.Add(user);
            }
        
        }

        if (user == "CANCEL") {
            user = valueIfCanceled;
        }
        else if (user == "USE") {
            user = selectedDirs[selectedDirs.Count - 1];
        }

        return user;
    }

    // public string GetFileExplore(string baseDir, string header2 = "EMPTY", string clearSeparator2 = "\x1b[2J\x1b[H") {

    //     string ConcatList(List<string> strings) {
    //         string outStr = "";
    //         foreach (string str in strings) {
    //             outStr = $"{outStr}{str}";
    //         }
    //         return outStr;
    //     }

    //     Boolean IsFile(string path) {
    //         FileAttributes attr = File.GetAttributes(path);
    //         if (attr.HasFlag(FileAttributes.Directory)) {
    //             return false;
    //         }
    //         else {
    //             return true;
    //         }
    //     }

    //     string internalBaseDir = baseDir.Replace("\\", "/");
    //     List<List<string>> options = new List<List<string>>();
    //     List<string> selectedDirs = new List<string>();
    //     selectedDirs.Add(internalBaseDir);
    //     List<string> availableFiles = new List<string>();
    //     List<string> availableDirs = new List<string>();
    //     string user = "HOME";
    //     string dirStr = "";

    //     while (user != "USE" && user != "CANCEL") {
            
    //         dirStr = ConcatList(selectedDirs);

    //         availableDirs = GetDirList(dirStr);
    //         availableFiles = GetFileList(dirStr);

    //         // If the path is a file, the only options will be BACK, USE, and CANCEL
    //         if (IsFile(dirStr)) {
    //             options = [["1", "Go Back a Folder", "BACK"], ["2", "Use This File", "USE"], ["3", "Cancel", "CANCEL"]];
    //         }
    //         // If the path is a folder and there are FILES but no FOLDERS
    //         else if (availableFiles.Count() > 0 && availableDirs.Count() < 1) {
    //             options = [["1", "Go Back a Folder\n", "BACK"], ["3", "Cancel\nSELECT A FILE:"]];
    //             for (int index = 0; index < availableFiles.Count - 1; index ++) {
    //                 options.Add([availableFiles[index]]);
    //             }
    //             options.Add([$"{availableFiles[availableFiles.Count - 1]}\nENTER A FOLDER: \u001b[91mNONE AVAILABLE\u001b[0m", availableFiles[availableFiles.Count - 1]]);
    //         }
    //         else if (availableFiles.Count() < 1 && availableDirs.Count() > 0) {
    //             options = [["1", "Go Back a Folder\n", "BACK"], ["3", "Cancel\nSELECT A FILE: \u001b[91mNONE AVAILABLE\u001b[0m\nENTER A FOLDER:", "CANCEL"]];
    //             for (int index = 0; index < availableDirs.Count; index ++) {
    //                 options.Add([availableDirs[index]]);
    //             }
    //         }
    //         else if (availableFiles.Count() > 0 && availableDirs.Count() > 0) {
    //             options = [["1", "Go Back a Folder\n", "BACK"], ["3", "Cancel\nSELECT A FILE:"]];
    //             for (int index = 0; index < availableFiles.Count - 1; index ++) {
    //                 options.Add([availableFiles[index]]);
    //             }
    //             options.Add([$"{availableFiles[availableFiles.Count - 1]}\nENTER A FOLDER:", availableFiles[availableFiles.Count - 1]]);
    //             for (int index = 0; index < availableDirs.Count; index ++) {
    //                 options.Add([availableDirs[index]]);
    //             }
    //         }
    //         else if (availableFiles.Count() < 1 && availableDirs.Count() < 1) {
    //             options = [["1", "Go Back a Folder\n", "BACK"], ["3", "Cancel\nSELECT A FILE: \u001b[91mNONE AVAILABLE\u001b[0m\nENTER A FOLDER: \u001b[91mNONE AVAILABLE\u001b[0m", "CANCEL"]];
    //         }
    //         // END

    //         user = MultipleChoice(kdr_list: options, header: $"{header2}\n\nCURRENT PATH: {ConcatList(selectedDirs)}\n\nOTHER ACTIONS:", clearSeparator: clearSeparator2, startingIndex: 4);
    //         if (user == "CANCEL") {
    //             return user;
    //         }
    //         else if (user == "USE") {
    //             return ConcatList(selectedDirs);
    //         }
    //         else if (user == "BACK") {
    //             selectedDirs.RemoveAt(selectedDirs.Count - 1);
    //         }
    //         else {
    //             selectedDirs.Add(user);
    //         }
    //     }

    //     return user;

    // }

// ------------------------------------------------
        
// \nCURRENT PATH: C:/sjk/fgh/sdf/fgh/
//
// OTHER ACTIONS:
// 1. Go Back a Folder
// 2. Use This File
// 3. Cancel
// SELECT A FILE:
// 4. File1.txt
// 5. File2.txt
// 6. File3.txt
// ENTER A FOLDER:
// 7. Folder1
// 8. Folder2
// 9. Folder3


// CURRENT PATH: C:/sjk/fgh/sdf/fgh/File1.txt
//
// OTHER ACTIONS:
// 1. Go Back a Folder
// 2. Use This File
// 3. Cancel


    // public string GetDirExplore(string baseDir2, string header3 = "EMPTY", string clearSeparator3 = "\x1b[2J\x1b[H") {
    //     string path = @"C:\Users\JohnDoe\Documents";
    //     string[] files = Directory.GetFiles(path);
   
    //     foreach (string file in files) {
    //         Console.WriteLine(file);
    //     }

    //     return "FILLER";
    // }

}
