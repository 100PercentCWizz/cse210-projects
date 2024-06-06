using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Security.Cryptography;

class Game {

    // MEMBER VARIABLES / ATTRIBUTES

    // public int _memVar1;
    // private int _memVar2;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

    //     CONSTRUCTORS ( METHODS )

    // public Game(int memVar1Param, int memVar2Param) {
    //     _memVar1 = memVar1Param;
    //     _memVar2 = memVar2Param;
    // }

    //     GETTERS / ACCESSORS ( METHODS )

    // public int GetMemVar1() { return _memVar1; }
    // public int GetMemVar2() { return _memVar2; }

    //     SETTERS / MUTATORS ( METHODS )

    // public void SetMemVar1(int memVar1Param) { _memVar1 = memVar1Param; }
    // public void SetMemVar2(int memVar2Param) { _memVar2 = memVar2Param; }

    //     OTHER METHODS

    public string CenterInSpaces(string text, int length) {
        
        string SpacesRepeated(int timesRepeated) {
            string str = "";
            for (int i = 0; i < timesRepeated; i ++) {
                str = str + " ";
            }
            return str;
        }
        
        string lPad = "";
        string rPad = "";
        if ((length - text.Length) % 2 == 1) {
            lPad = SpacesRepeated((length - text.Length) / 2);
            rPad = SpacesRepeated(((length - text.Length) / 2) + 1);
        }
        else {
            lPad = SpacesRepeated((length - text.Length) / 2);
            rPad = SpacesRepeated((length - text.Length) / 2);
        }

        return $"{lPad}{text}{rPad}";

    }

    public List<string> ConvertNumberToStrList(int number) {
        List<string> outLoS = new List<string>();
        List<string> blockText = new List<string>();
        outLoS = ["", "", "", "", ""]; 
        string numAsString = $"{number}";

        for (int i = 0; i < numAsString.Length; i ++) {

            if (numAsString[i] == '1') {
                blockText = [
                    "  []  ",
                    "[][]  ",
                    "  []  ",
                    "  []  ",
                    "[][][]"
                ];
            }
            else if (numAsString[i] == '2') {
                blockText = [
                    "[][][]",
                    "    []",
                    "[][][]",
                    "[]    ",
                    "[][][]"
                ];
            }
            else if (numAsString[i] == '3') {
                blockText = [
                    "[][][]",
                    "    []",
                    "  [][]",
                    "    []",
                    "[][][]"
                ];
            }
            else if (numAsString[i] == '4') {
                blockText = [
                    "[]  []",
                    "[]  []",
                    "[][][]",
                    "    []",
                    "    []"
                ];
            }
            else if (numAsString[i] == '5') {
                blockText = [
                    "[][][]",
                    "[]    ",
                    "[][][]",
                    "    []",
                    "[][][]"
                ];
            }
            else if (numAsString[i] == '6') {
                blockText = [
                    "[][][]",
                    "[]    ",
                    "[][][]",
                    "[]  []",
                    "[][][]"
                ];
            }
            else if (numAsString[i] == '7') {
                blockText = [
                    "[][][]",
                    "    []",
                    "    []",
                    "    []",
                    "    []"
                ];
            }
            else if (numAsString[i] == '8') {
                blockText = [
                    "[][][]",
                    "[]  []",
                    "[][][]",
                    "[]  []",
                    "[][][]"
                ];
            }
            else if (numAsString[i] == '9') {
                blockText = [
                    "[][][]",
                    "[]  []",
                    "[][][]",
                    "    []",
                    "[][][]"
                ];
            }
            else if (numAsString[i] == '0') {
                blockText = [
                    "[][][]",
                    "[]  []",
                    "[]  []",
                    "[]  []",
                    "[][][]"
                ];
            }
        
            for (int layerIndex = 0; layerIndex < 5; layerIndex ++) {
                
                if (i > 0) {
                    outLoS[layerIndex] = outLoS[layerIndex] + "  " + blockText[layerIndex];
                }
                else {
                    outLoS[layerIndex] = blockText[layerIndex];
                }

            }

        }

        if (number == 101) {
            // outLoS = [
            //     "\u001b[91m  [][][][][]  \u001b[0m",
            //     "\u001b[91m[]  [][][]  []\u001b[0m",
            //     "\u001b[91m[]  []  []  []\u001b[0m",
            //     "\u001b[91m[][][][][][][]\u001b[0m",
            //     "\u001b[91m  []  []  []  \u001b[0m"
            // ];
            outLoS = [
                "  [][][][][]  ",
                "[]  [][][]  []",
                "[]  []  []  []",
                "[][][][][][][]",
                "  []  []  []  "
            ];
        }

        for (int i = 0; i < 5; i ++) {
            outLoS[i] = CenterInSpaces(outLoS[i], 22);
        }

        return outLoS;

    }

    public string StrListToStr(List<string> LoSParam) {
        string outString = "";
        foreach (string item in LoSParam) {
            outString = outString + item + "\n";
        }
        return outString;
    }

    public List<string> GetButton(int number, string playerName, string message = "") {
        string playerNParameter = CenterInSpaces(playerName, 18);
        List<string> buttonPrintText = new List<string>();
        List<string> blockText = new List<string>();
        blockText = ConvertNumberToStrList(number);
        string blockTextParameter00 = blockText[0];
        string blockTextParameter01 = blockText[1];
        string blockTextParameter02 = blockText[2];
        string blockTextParameter03 = blockText[3];
        string blockTextParameter04 = blockText[4];
        buttonPrintText = [
            CenterInSpaces($"                                                                   ", 100),
            CenterInSpaces($"                        {playerNParameter}                         ", 100),
            CenterInSpaces($"                                                                   ", 100),
            CenterInSpaces($"                        [][][][][][][][][]                         ", 100),
            CenterInSpaces($"                    [][]                  [][]                     ", 100),
            CenterInSpaces($"                  []                          []                   ", 100),
            CenterInSpaces($"                []                              []                 ", 100),
            CenterInSpaces($"              []                                  []               ", 100),
            CenterInSpaces($"            []                                      []             ", 100),
            CenterInSpaces($"            []        {blockTextParameter00}        []             ", 100),
            CenterInSpaces($"            []        {blockTextParameter01}        []             ", 100),
            CenterInSpaces($"            []        {blockTextParameter02}        []             ", 100),
            CenterInSpaces($"            []        {blockTextParameter03}        []             ", 100),
            CenterInSpaces($"            []        {blockTextParameter04}        []             ", 100),
            CenterInSpaces($"            []                                      []             ", 100),
            CenterInSpaces($"              []                                  []               ", 100),
            CenterInSpaces($"                []                              []                 ", 100),
            CenterInSpaces($"                  []                          []                   ", 100),
            CenterInSpaces($"                    [][]                  [][]                     ", 100),
            CenterInSpaces($"                        [][][][][][][][][]                         ", 100),
            CenterInSpaces($"                                                                   ", 100),
            CenterInSpaces(message, 100)
        ];
        return buttonPrintText;
    }

    public void PlayElimination() {
        Boolean playing = true;
        int nummy = 0;
        string user = "";
        while (playing) {
            Console.Write("\x1b[2J\x1b[H");
            Console.WriteLine(StrListToStr(GetButton(nummy, "Christian", $"Type \"k\" to KEEP your {nummy} points or press ENTER to press the BUTTON")));
            user = Console.ReadLine();
            while (user != "" && user != "k") {
                Console.Write("\x1b[2J\x1b[H");
                Console.WriteLine(StrListToStr(GetButton(nummy, "Christian", $"Type \"k\" to KEEP your {nummy} points or press ENTER to press the BUTTON")));
                user = Console.ReadLine();
            }
            Random rand = new Random();
            int playersNum = rand.Next(1, 101);
            int compsNum = 0;
            for (int i = 0; i < nummy; i ++) {
                compsNum = rand.Next(1, 101);
                if (compsNum == playersNum) {
                    playing = false;
                }
            }
            nummy ++;
        }
        Console.Write("\x1b[2J\x1b[H");
        Console.WriteLine(StrListToStr(GetButton(101, "Christian", message: "OUCH!  Pass the device to {Hannah}.  When they are ready, press ENTER:")));
    }

    public void PlayToAmount(int amount) {

    }

}
