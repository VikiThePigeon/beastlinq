public class WaterCreature : Creature
{
    public override string Element
    {
        get { return "Water"; }
    }
    public WaterCreature(string name, int hp, int attack, params Move[] moves)
        : base(name, hp, attack, moves)
    {
    }
    public override double GetMultiplier(string targetElement)
    {
        if (targetElement == "Fire" || targetElement == "Earth" || targetElement == "Poison")
            return 1.5;
        if (targetElement == "Grass" || targetElement == "Electric")
            return 0.5;
        return 1.0;
    }
}