class Player {

    private string _playerName;
    private int _playerPoints;

    public Player(string nameParam) {
        _playerName = nameParam;
    }

    public int GetPoints() { return _playerPoints; }
    public string GetName() { return _playerName; }

    public void SetPoints(int pointParam) { _playerPoints = pointParam; }
    public void AddPointsToPlayer(int pointsToAdd) { _playerPoints += pointsToAdd; }

}
