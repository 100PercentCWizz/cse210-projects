using System.Net;

class Map {

    // MEMBER VARIABLES / ATTRIBUTES

    private List<string> _map = [
        "#############",
        "#...........#",
        "#...#...#...#",
        "#...#...#...#",
        "#.####.####.#",
        "#...#...#...#",
        "#...........#",
        "#...#...#...#",
        "#.####.####.#",
        "#...#...#...#",
        "#...#...#...#",
        "#...........#",
        "#############"
    ];

    private int _playerX = 2;
    private int _playerY = 2;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    // public Map() {

    // }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    private string ReplaceStringAt(string stringP, string replaceWith, int indexToReplace) {
        string outString = "";
        for (int i = 0; i < stringP.Count() - 1; i ++) {
            if (i == indexToReplace) {
                outString = outString + replaceWith;
            }
            else {
                outString = outString + stringP[i];
            }
        }
        return outString;
    }

    public void DisplayMap() {
        Console.Clear();
        List<string> internalMap = _map;
        internalMap[_playerY] = ReplaceStringAt(internalMap[_playerY], "P", _playerX);
        foreach (string line in _map) {
            string editedLine = line.Replace("#", "[]").Replace(".", "  ").Replace("P", ":)");
            Console.WriteLine(editedLine);
        }
    }

    public void MovePlayerUp() {
        if (_map[_playerY - 1][_playerX] != '#') {
            _playerY -= 1;
        }
    }

    public void MovePlayerDown() {
        if (_map[_playerY + 1][_playerX] != '#') {
            _playerY += 1;
        }
    }

    public void MovePlayerLeft() {
        if (_map[_playerY][_playerX - 1] != '#') {
            _playerX -= 1;
        }
    }

    public void MovePlayerRight() {
        if (_map[_playerY][_playerX + 1] != '#') {
            _playerX += 1;
        }
    }

    public void TestPlayerMovement() {
        while (true) {
            DisplayMap();
            string userIn = Console.ReadLine();
            if (userIn == "w") {
                MovePlayerUp();
            }
            else if (userIn == "s") {
                MovePlayerDown();
            }
            else if (userIn == "a") {
                MovePlayerLeft();
            }
            else if (userIn == "d") {
                MovePlayerRight();
            }
        }
    }

}
