abstract class Enemy {

    // MEMBER VARIABLES / ATTRIBUTES

    protected string _name;
    protected int _hp;
    protected int _maxHp;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

        // CONSTRUCTORS ( METHODS )

        // GETTERS / ACCESSORS ( METHODS )

        // SETTERS / MUTATORS ( METHODS )

        // OTHER METHODS

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

    public virtual string GetName() {
        return _name;
    }

    public abstract int Attack();

    public void ReceivesDamage(int damage) { _hp -= damage; }

}
