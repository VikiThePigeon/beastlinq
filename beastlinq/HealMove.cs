using System;
using System.Collections.Generic;

//наслідник мува
public class HealMove : Move
{
    public HealMove(string name, int power) : base(name, power)
    {
    }
    public override void Use(Creature user, Creature target)
    {
        // HP напряму не чіпаємо (воно закрите) - просимо істоту відновити себе
        user.Restore(Power);
        Console.WriteLine(user.Name + " used " + Name + " and restored " + Power + " HP!");
    }

    public override void Show()
    {
        Console.WriteLine(Name + " (Heal: " + Power + ")");
    }
}