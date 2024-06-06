class Square {

    // MEMBER VARIABLES / ATTRIBUTES

    // public int _memVar1;
    // private int _memVar2;

    // MEMBER METHODS / FUNCTIONS / BEHAVIORS

    //     CONSTRUCTORS ( METHODS )

    // public Square(int memVar1Param, int memVar2Param) {
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
    
    private string RepeatString(string text, int repetitions) {
        string outStr = "";
        for (int i = 0; i < repetitions; i ++) {
            outStr = outStr + text;
        }
        return outStr;
    }

    // private string CenterPad(string text, int length) {
    //     double halfLen = (double)length / 2.0;
    //     int leftPad = Math.Floor(halfLen);
    //     int rightPad = Math.Ceiling(halfLen);
    //     return $"{}{text}{}";
    // }

    // public void DisplayWordBox() {

    // }

}
