using System;

public class CityLocation : Location
{
    public CityLocation(string name) : base(name)
    {
    }
    public override void OnEnter(Player player)
    {
        player.HealAll();
        Console.WriteLine("Creatures healed.");
    }
}