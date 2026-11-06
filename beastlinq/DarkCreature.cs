public class DarkCreature : Creature
{
    public override string Element
    {
        get { return "Dark"; }
    }
    public DarkCreature(string name, int hp, int attack, params Move[] moves)
        : base(name, hp, attack, moves)
    {
    }
    public override double GetMultiplier(string targetElement)
    {
        if (targetElement == "Light")
            return 1.5;
        return 1.0;
    }
}