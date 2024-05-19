using System;

class Program
{
    static string multiple_choice (List<List<string>> kdr_list, string header = "EMPTY", string clear_separator = "\x1b[2J\x1b[H") {
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
            int numeric = 1;
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
            Console.Write(clear_separator);
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
    static void Main(string[] args) {

        Journal activeJournal = new Journal();

        string user = "HOME";

        List<List<string>> kdr = [];

        Prompt p = new Prompt();
        string prompty = p.GetPrompt();
        string todaysPrompt = "TODAY'S PROMPT: " + prompty;

        while (user != "END PROGRAM") {
            if (user == "HOME") {
                kdr = [["Respond to today's prompt.", "WRITE"], ["Display journal", "DISPLAY"], ["Load a journal", "LOAD"], ["Save journal", "SAVE"], ["End Program", "END PROGRAM"]];
                user = multiple_choice(kdr_list: kdr, header: $"{todaysPrompt}\nHOME");
            }
            else if (user == "WRITE") {
                Entry newEntry = new Entry();
                Console.WriteLine($"\x1b[2J\x1b[H\n{todaysPrompt}\nType your entry below and press ENTER when finished:\n");
                newEntry._entryText = Console.ReadLine();
                newEntry.getNow();
                newEntry._givenPrompt = p.GetPrompt();
                activeJournal.AddEntry(newEntry);
                Console.WriteLine("\nThe entry has been added to the journal.\nPress ENTER to return to home.");
                Console.ReadLine();
                user = "HOME";
            }
            else if (user == "DISPLAY") {
                activeJournal.DisplayJournal();
                Console.WriteLine("\nThe journal has been printed.\nPress ENTER to return to home.");
                Console.ReadLine();
                user = "HOME";
            }
            else if (user == "LOAD") {
                Console.WriteLine("Please provide the filename:\n");
                string usedFile = Console.ReadLine();
                activeJournal.LoadJournal(filename: usedFile, separator: " | ");
                Console.WriteLine("\nThe journal has been loaded.\nPress ENTER to return to home.");
                Console.ReadLine();
                user = "HOME";
            }
            else if (user == "SAVE") {
                Console.WriteLine("Please provide the filename to save to:\n");
                string savingFile = Console.ReadLine();
                activeJournal.SaveJournal(filename: savingFile, separator: " | ");
                Console.WriteLine("\nThe journal has been saved.\nPress ENTER to return to home.");
                Console.ReadLine();
                user = "HOME";
            }
        }
        Console.Write("\x1b[2J\x1b[H" + "\nPROGRAM ENDED");
    }
}
