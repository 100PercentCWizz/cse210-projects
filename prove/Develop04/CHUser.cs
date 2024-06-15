using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Text.RegularExpressions;
using System.Reflection.Metadata;
using System.Formats.Asn1;

class CHUser {

    private string Red(string inStr) {
        return $"\u001b[91m{inStr}\u001b[0m";
    }

    public string MultipleChoice(List<List<string>> kdrList, string header, string clearSeparator = "\x1b[2J\x1b[H", int startingIndex = 1) {
        // def multiple_choice(choices, header = 'EMPTY', prompt = 'Please select an action and press ENTER: ', clear_screen = True):
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

}
