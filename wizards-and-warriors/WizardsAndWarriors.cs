abstract class Character
{

    private string _characterType;
    protected Character(string characterType)
    {
        this._characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return "Character is a " + _characterType;
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6;
    }
}

class Wizard : Character
{

    private Boolean _isSpellPrepared;
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        return _isSpellPrepared ? 12 : 3;
    }

override public bool Vulnerable()
    {
        return !_isSpellPrepared;
    }

    public void PrepareSpell()
    {
        this._isSpellPrepared = true;
    }
}
