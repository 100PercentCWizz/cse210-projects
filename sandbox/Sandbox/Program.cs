using System;
using System.Reflection.Metadata;

class Program
{
    static string multiple_choice (List<List<string>> kdr_list, string header, Boolean clear_screen) {
// def multiple_choice(choices, header = 'EMPTY', prompt = 'Please select an action and press ENTER: ', clear_screen = True):
//     # A string in the choices list can be substituted for a list in the format ['key', 'display', 'return']
//     # In this case, the option will display like so:
//     #   1. Option 1
//     #   2. Option 2
//     # key. display (returns return)
//     #   3. Option 3

//     def red(text):
//         text = '\033[91m' + text + '\033[0m'
//         return text

//     def cls():
//         print("\033c\033[3J", end='')

//     def create_key_choice_return_list(choices):
//         valid_ins = []
//         out_key_choice_return_list = []
//         unique_numeric = 1
//         for object in choices:
//             if isinstance(object, list):
//                 if object[0] == '':
//                     object[0] = unique_numeric
//                 out_key_choice_return_list.append([str(object[0]), str(object[1]), str(object[2])])
//                 unique_numeric += 1
//             else:
//                 out_key_choice_return_list.append([str(unique_numeric), str(object), str(object)])
//                 unique_numeric += 1
//             valid_ins.append(out_key_choice_return_list[len(out_key_choice_return_list) - 1][0])
//         return out_key_choice_return_list, valid_ins

//     def longest_length_in_list_of_lists(list_of_lists, index):
//         longest = len(list_of_lists[0][0])
//         for item in list_of_lists:
//             if len(item[index]) > longest:
//                 longest = len(item[index])
//         return longest

//     def print_and_prompt(internal_header, prompt2, cs = clear_screen, error = ''):
//         if cs == True:
//             cls()
//         print(f'\n{internal_header}\n')
//         longest_key_length = longest_length_in_list_of_lists(key_choice_return_list, 0)
//         for item in key_choice_return_list:
//             padding = ' '
//             repetitions = longest_key_length - len(item[0])
//             for number in range(0, repetitions):
//                 padding = padding + ' '
//             print(f'{padding}{item[0]}. {item[1]}')
//         print(error, end = '')
//         user_input = input(f'\n{prompt2}')
//         return user_input

//     key_choice_return_list, valid_answers = create_key_choice_return_list(choices)

        string user_input = "HELLO";
//     user_input = print_and_prompt(header, prompt, error = '')
    
//     while user_input not in valid_answers:
//         user_input = print_and_prompt(header, prompt, error = red(f'\n"{user_input}" is an invalid response.'))
    
//     for item in key_choice_return_list:
//         if user_input == item[0]:
//             user_input = item[2]
//             break
    
//     return user_input
        return user_input;
    }
    
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hello Sandbox World!");

        for (int x = 0; x < 10; x++) {
            Console.WriteLine($"x = {x}");
        }

    }
}
