public class GrassCreature : Creature
{
    public override string Element
    {
        get { return "Grass"; }
    }
    public GrassCreature(string name, int hp, int attack, params Move[] moves) : base(name, hp, attack, moves)
    {
    }
    public override double GetMultiplier(string targetElement)
    {
        if (targetElement == "Water")
            return 1.5;
        if (targetElement == "Fire")
            return 0.5;
        return 1.0;
    }
}