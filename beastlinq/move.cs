using System;
using System.Collections.Generic;
using System.Linq;

class Move
{
   public string Name { get; set; }
   public int  Power { get; set; }
   public Move(string name, int power )
   {
        Name = name;
        Power = power;
   }
    public int GetDamage()
    {
        return Power + attacker.Attack/2;
    }
    public void ShowMove()
    {
        Console.WriteLine(Name + "(Сила: " + Power + ")");
    }

}
