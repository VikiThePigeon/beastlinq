using System;
using System.Collections.Generic;

public class Move
{
    //стати мувів
   public string Name { get; set; }
   public int Power { get; set; }
   public Move(string name, int power )
   {
        Name = name;
        Power = power;
   }
    //метод отримання дамага формула
    public int GetDamage(int damageAmount)
    {
        return Power + damageAmount/2;
    }
    //метод показу
    public void ShowMove()
    {
        Console.WriteLine(Name + "(Strenght: " + Power + ")");
    }

}
