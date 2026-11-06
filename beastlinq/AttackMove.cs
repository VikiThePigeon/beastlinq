using System;
using System.Collections;
using System.Collections.Generic;
//наслідник мува
public class AttackMove : Move
{
    public AttackMove(string name, int power) : base(name, power)
    {
    }
    //CIFERKI
    private int GetDamage(int attack)
    {
        return Power + attack / 2;
    }
    public override void Use(Creature user, Creature target)
    {
        //тут ми отримуємо множник ефективності атаки рахуємо урон
        double mult = user.GetMultiplier(target.Element);
        int dmg = (int)(GetDamage(user.Attack) * mult);
        target.TakeDamage(dmg);
        Console.WriteLine(user.Name + " used " + Name + " on " + target.Name + " for " + dmg + " damage!");
        //тут ми перевіряємо множник ефективності атаки
        if (mult > 1)
        {
            Console.WriteLine("It's super effective!");
        }
        else if (mult < 1)
        {
            Console.WriteLine("It's not very effective...");
        }
    }
}