public class FireCreature : Creature
{
    public override string Element
    {
        get { return "Fire"; }
    }
    public FireCreature(string name, int hp, int attack, params Move[] moves) : base(name, hp, attack, moves)
    {
    }
    public override double GetMultiplier(string targetElement)
    {
        if (targetElement == "Grass" || targetElement == "Metal" || targetElement == "Ice" || targetElement == "Poison")
            return 1.5;
        if (targetElement == "Water" || targetElement == "Earth")
            return 0.5;
        return 1.0;
    }
}