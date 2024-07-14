using System.Net;
using System.Reflection.Metadata.Ecma335;

class Player {

    // MEMBER VARIABLES / ATTRIBUTES

    private string _name;
    private int _hp;
    private int _maxHp;
    private int _attackStat;
    // private List<Item> _items;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

    public Player(string nameP) {
        _name = nameP;
        _hp = 1000;
        _maxHp = 1000;
        _attackStat = 10;
    }

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS
    
    public string GetName() { return _name; }

    public int GetHealthFactor() {
        if (_hp > 0) {
            return _hp / (_maxHp / 50);
        }
        else {
            return 0;
        }
    }

    public Boolean IsAlive() {
        if (_hp >= 1) {
            return true;
        }
        else {
            return false;
        }
    }

    public void ReceivesDamage(int damage) {
        _hp -= damage;
    }

    public int DealsDamage() { return _attackStat; }

    // public Boolean BagIsFull() {
    //     if (_items.Count >= 6) {
    //         return true;
    //     }
    //     else {
    //         return false;
    //     }
    // }

}
