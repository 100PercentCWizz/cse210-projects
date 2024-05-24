using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Text.RegularExpressions;

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

    public string GetFileExplore(string baseDir, string header2 = "EMPTY", string clearSeparator2 = "\x1b[2J\x1b[H") {

        List<string> GetFileList(string path) {
            List<string> outFiles = new List<string>();
            string internalPath = path.Replace("\\", "/");

            string[] files = Directory.GetFiles(internalPath);
            for (int index = 0; index < files.Count(); index ++) {
                files[index] = Regex.Replace(files[index], ".*\\\\", "");
                outFiles.Add(files[index]);
            }
            return outFiles;
        }

        List<string> GetDirList(string path) {
            List<string> outFolders = new List<string>();
            string internalPath = path.Replace("\\", "/");

            string[] folders = Directory.GetDirectories(internalPath);
            for (int index = 0; index < folders.Count(); index ++) {
                folders[index] = Regex.Replace(folders[index], ".*(/|\\\\)", "");
                outFolders.Add($"{folders[index]}/");
            }
            return outFolders;
        }

        string ConcatList(List<string> strings) {
            string outStr = "";
            foreach (string str in strings) {
                outStr = $"{outStr}{str}";
            }
            return outStr;
        }

        Boolean IsFile(string path) {
            FileAttributes attr = File.GetAttributes(path);
            if (attr.HasFlag(FileAttributes.Directory)) {
                return false;
            }
            else {
                return true;
            }
        }

        string internalBaseDir = baseDir.Replace("\\", "/");
        List<List<string>> options = new List<List<string>>();
        List<string> selectedDirs = new List<string>();
        selectedDirs.Add(internalBaseDir);
        List<string> availableFiles = new List<string>();
        List<string> availableDirs = new List<string>();
        string user = "HOME";
        string dirStr = "";

        while (user != "USE" && user != "CANCEL") {
            
            dirStr = ConcatList(selectedDirs);

            availableDirs = GetDirList(dirStr);
            availableFiles = GetFileList(dirStr);

            // If the path is a file, the only options will be BACK, USE, and CANCEL
            if (IsFile(dirStr)) {
                options = [["1", "Go Back a Folder", "BACK"], ["2", "Use This File", "USE"], ["3", "Cancel", "CANCEL"]];
            }
            // If the path is a folder and there are FILES but no FOLDERS
            else if (availableFiles.Count() > 0 && availableDirs.Count() < 1) {
                options = [["1", "Go Back a Folder\n", "BACK"], ["3", "Cancel\nSELECT A FILE:"]];
                for (int index = 0; index < availableFiles.Count - 1; index ++) {
                    options.Add([availableFiles[index]]);
                }
                options.Add([$"{availableFiles[availableFiles.Count - 1]}\nENTER A FOLDER: \u001b[91mNONE AVAILABLE\u001b[0m", availableFiles[availableFiles.Count - 1]]);
            }
            else if (availableFiles.Count() < 1 && availableDirs.Count() > 0) {
                options = [["1", "Go Back a Folder\n", "BACK"], ["3", "Cancel\nSELECT A FILE: \u001b[91mNONE AVAILABLE\u001b[0m\nENTER A FOLDER:", "CANCEL"]];
                for (int index = 0; index < availableDirs.Count; index ++) {
                    options.Add([availableDirs[index]]);
                }
            }
            else if (availableFiles.Count() > 0 && availableDirs.Count() > 0) {
                options = [["1", "Go Back a Folder\n", "BACK"], ["3", "Cancel\nSELECT A FILE:"]];
                for (int index = 0; index < availableFiles.Count - 1; index ++) {
                    options.Add([availableFiles[index]]);
                }
                options.Add([$"{availableFiles[availableFiles.Count - 1]}\nENTER A FOLDER:", availableFiles[availableFiles.Count - 1]]);
                for (int index = 0; index < availableDirs.Count; index ++) {
                    options.Add([availableDirs[index]]);
                }
            }
            else if (availableFiles.Count() < 1 && availableDirs.Count() < 1) {
                options = [["1", "Go Back a Folder\n", "BACK"], ["3", "Cancel\nSELECT A FILE: \u001b[91mNONE AVAILABLE\u001b[0m\nENTER A FOLDER: \u001b[91mNONE AVAILABLE\u001b[0m", "CANCEL"]];
            }
            // END

            user = MultipleChoice(kdr_list: options, header: $"{header2}\n\nCURRENT PATH: {ConcatList(selectedDirs)}\n\nOTHER ACTIONS:", clearSeparator: clearSeparator2, startingIndex: 4);
            if (user == "CANCEL") {
                return user;
            }
            else if (user == "USE") {
                return ConcatList(selectedDirs);
            }
            else if (user == "BACK") {
                selectedDirs.RemoveAt(selectedDirs.Count - 1);
            }
            else {
                selectedDirs.Add(user);
            }
        }

        return user;
        
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
    }

    // public string GetDirExplore(string baseDir2, string header3 = "EMPTY", string clearSeparator3 = "\x1b[2J\x1b[H") {
    //     string path = @"C:\Users\JohnDoe\Documents";
    //     string[] files = Directory.GetFiles(path);
   
    //     foreach (string file in files) {
    //         Console.WriteLine(file);
    //     }

    //     return "FILLER";
    // }

}
