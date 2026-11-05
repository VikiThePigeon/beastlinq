public class LightCreature : Creature
{
    public override string Element
    {
        get { return "Light"; }
    }
    public LightCreature(string name, int hp, int attack, params Move[] moves) : base(name, hp, attack, moves)
    {
    }
    public override double GetMultiplier(string targetElement)
    {
        if (targetElement == "Dark")
            return 1.5;
        return 1.0;
    }
}