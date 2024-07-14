class Combat {

    // MEMBER VARIABLES / ATTRIBUTES

    Player _player;
    Enemy _enemy;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public Combat(Player _playerP) {
        _player = _playerP;
    }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

    public void GetEnemy(int scoreP) {
        
        Random rand = new Random();

        int typeSelection = rand.Next(0, 3);

        if (((scoreP + 1) % 5) == 0) {
            if (typeSelection == 0) {
                _enemy = new HeavyBoss(scoreP);
            }
            else if (typeSelection == 1) {
                _enemy = new HeavyBoss(scoreP);
            }
            else {
                _enemy = new HeavyBoss(scoreP);
            }
        }
        else {
            if (typeSelection == 0) {
                _enemy = new HeavyBoss(scoreP);
            }
            else if (typeSelection == 1) {
                _enemy = new HeavyBoss(scoreP);
            }
            else {
                _enemy = new HeavyBoss(scoreP);
            }
        }
    }

    // vvv
    private string GetPlayerHealthString() {
        CHString chstring = new CHString();
        int numOfChars = _player.GetHealthFactor();
        string textColor = "";
        if (numOfChars < 15) {
            textColor = chstring.Red();
        }
        else if (numOfChars < 35) {
            textColor = chstring.Yellow();
        }
        else {
            textColor = chstring.Green();
        }
        // return chstring.TextRepeated("X", numOfChars) + chstring.TextRepeated(" ", 50 - numOfChars);
        return $"{textColor}{chstring.TextRepeated("X", numOfChars) + chstring.TextRepeated(" ", 50 - numOfChars)}\u001b[0m";
    }

    private string GetEnemyHealthString() {
        CHString chstring = new CHString();
        int numOfChars = _enemy.GetHealthFactor();
        string textColor = "";
        if (numOfChars < 15) {
            textColor = chstring.Red();
        }
        else if (numOfChars < 35) {
            textColor = chstring.Yellow();
        }
        else {
            textColor = chstring.Green();
        }
        // return chstring.TextRepeated("X", numOfChars) + chstring.TextRepeated(" ", 50 - numOfChars);
        return $"{textColor}{chstring.TextRepeated("X", numOfChars) + chstring.TextRepeated(" ", 50 - numOfChars)}\u001b[0m";
    }

    public string GetEnemyName() { return _enemy.GetName(); }

    public void DisplayBattleScreen() {
        CHString chstring = new CHString();
        Console.Clear();
        Console.WriteLine("[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]");
        Console.WriteLine("[]                                                          []");
        Console.WriteLine("[]  [][][][][][][][][][][][][][][][][][][][][][][][][][][]  []");
        Console.WriteLine("[]  []                                                  []  []");
        Console.WriteLine("[]  [][][][][][][][][][][][][][][][][][][][][][][][][][][]  []");
        Console.WriteLine("[]                                                          []");
        Console.WriteLine("[]                      RRRR      RRRR                      []".Replace("RR", chstring.Red("[]")));
        Console.WriteLine("[]                      RR  RRRRRR  RR                      []".Replace("RR", chstring.Red("[]")));
        Console.WriteLine("[]                      RR    RR    RR                      []".Replace("RR", chstring.Red("[]")));
        Console.WriteLine("[]                      RRRRRRRRRRRRRR                      []".Replace("RR", chstring.Red("[]")));
        Console.WriteLine("[]                        RR      RR                        []".Replace("RR", chstring.Red("[]")));
        Console.WriteLine("[]                          RRRRRR                          []".Replace("RR", chstring.Red("[]")));
        Console.WriteLine("[]                                                          []");
        Console.WriteLine("[]                                                          []");
        Console.WriteLine("[]                                                          []");
        Console.WriteLine("[]  [][][][][][][][][][][][][][][][][][][][][][][][][][][]  []");
        Console.WriteLine("[]  []                                                  []  []");
        Console.WriteLine("[]  [][][][][][][][][][][][][][][][][][][][][][][][][][][]  []");
        Console.WriteLine("[]  []                        []                        []  []");
        Console.WriteLine("[]  []                        []                        []  []");
        Console.WriteLine("[]  []                        []                        []  []");
        Console.WriteLine("[]  [][][][][][][][][][][][][][][][][][][][][][][][][][][]  []");
        Console.WriteLine("[]                                                          []");
        Console.WriteLine("[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]");
        Console.WriteLine();
        Console.Write("");
    }
    // ^^^

    // vvv
    private Boolean BattleIsActive() {
        if (_player.IsAlive() && _enemy.IsAlive()) {
            return true;
        }
        else {
            return false;
        }
    }

    public void EngageInBattle() {
        DisplayBattleScreen();
        UpdateHealthBars();
        while (BattleIsActive()) {
            PlayerDoesTurn();
            EnemyDoesTurn();
        }
    }
    // ^^^

    private void UpdateHealthBars() {

        CHString chstring = new CHString();

        Console.CursorTop = 3;
        Console.CursorLeft = 0;
        Console.Write("[]  []                                                  []  []");
        Console.CursorLeft = 6;
        chstring.SlowPrint(GetEnemyHealthString());

        Console.CursorTop = 16;
        Console.CursorLeft = 0;
        Console.Write("[]  []                                                  []  []");
        Console.CursorLeft = 6;
        chstring.SlowPrint(GetPlayerHealthString());
    }

    private void UpdateBattleMessage(string messageP) {
        CHString chstring = new CHString();
        Console.CursorTop = 13;
        Console.CursorLeft = 0;
        Console.Write("[]                                                          []");
        Console.CursorLeft = 7;
        chstring.SlowPrint(messageP);
    }

    private void EnemyDoesTurn() {
        UpdateBattleMessage($"The {_enemy.GetName()} attacks!");
        _player.ReceivesDamage(_enemy.Attack());
        UpdateHealthBars();
    }

    private void PlayerDoesTurn() {
        UpdateBattleMessage($"What will {_player.GetName()} do? ");
        Console.ReadLine();

        UpdateBattleMessage($"{_player.GetName()} attacks!");

        _enemy.ReceivesDamage(_player.DealsDamage());
        UpdateHealthBars();
    }

}
