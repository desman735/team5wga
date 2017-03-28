﻿
abstract public class UnitAIBehaviour {
    private Unit subject;

    public UnitAIBehaviour(Unit subject) {
        Subject = subject;
    }

    protected Unit Subject {
        get {return subject;}

        set {subject = value;}
    }

    abstract public void UpdateState();

    protected IFightable getClosestUnit() {
        throw new System.NotImplementedException();
    }
}
