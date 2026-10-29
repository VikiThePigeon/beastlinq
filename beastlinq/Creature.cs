using System;
using System.Collections.Generic;

class Creature
{
    //стат крітера
    public string Name { get; set; }
    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int Attack { get; set; }
    public List<Move> Moves { get; set; }

    //конструктор
    public Creature(string name, int hp, int attack, params Move[] moves)
    {
        Name = name;
        HP = hp;
        MaxHP = hp;
        Attack = attack;
        Moves = new List<Move>();// створюємо список мувів
        if (moves.Length == 0)
        {
            Moves.Add(new Move("Tackle", 10));
            Moves.Add(new Move("Ember", 20));
        }
        else
        {
            Moves.AddRange(moves);
        }
    }
    //метод отримання дамага
    public void TakeDamage(int damage)
    {
        HP = HP - damage;
        if (HP < 0)
            HP = 0;
    }
    //метод перевірки чи померли
    public bool IsDead()
    {
        return HP <= 0;
    }
    //метод хілки
    public void Heal()
    {
        HP = MaxHP;
    }
    //метод показу
    public void Show()
    {
        Console.WriteLine(Name + "(HP: " + HP + "/" + MaxHP + ")");
    }
}
