using System;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.Schema;

class Program
{
    static string multiple_choice (List<List<string>> kdr_list, string header = "EMPTY", Boolean clear_screen = true) {
// // def multiple_choice(choices, header = 'EMPTY', prompt = 'Please select an action and press ENTER: ', clear_screen = True):
// //     # A string in the choices list can be substituted for a list in the format ['key', 'display', 'return']
// //     # In this case, the option will display like so:
// //     #   1. Option 1
// //     #   2. Option 2
// //     # key. display (returns return)
// //     #   3. Option 3

// //     def red(text):
// //         text = '\033[91m' + text + '\033[0m'
// //         return text

// //     def cls():
// //         print("\033c\033[3J", end='')

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
            if (clear_screen == true) {
                Console.WriteLine("---  CLEAR  HERE  ---");
            }
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
            user_input = print_and_prompt(cleaned_kdr_list, error: $"\n\"{user_input}\" is an invalid response.");
        }
    
        foreach (List<string> item in cleaned_kdr_list) {
            if (user_input == item[0]) {
                user_input = item[2];
                break;
            }
        }
    
        return user_input;
    }
    
    static void Main(string[] args)
    {

        Course course1 = new Course();
        course1._className = "Programming with Classes";
        course1._color = "Green";
        course1._courseCode = "CSE 210";
        course1._numberOfCredits = 2;
        course1.Display();

        // string user = "HOME";

        // while (user != "END PROGRAM") {
        //     if (user == "HOME") {
        //         List<List<string>> kdr = [["", "a", ""], ["", "b", ""], ["", "c", ""]];
        //         user = multiple_choice(kdr_list: kdr, header: "HOME");
        //     }
        // }
        // Console.WriteLine(user);
        
    }
}
