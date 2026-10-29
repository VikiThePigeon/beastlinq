using System;
using System.Collections.Generic;

class Player
{
    //стартові стати(лока імя)
    public string Name { get; set; }
    public List<Creature> Party = new List<Creature>();
    public Location Current { get; set; }
    public Stack<Location> History { get; set; }//повернення назад

    public Player(string name, Location start)
    {
        Name = name;
        Current = start;
        Party = new List<Creature>();
        History = new Stack<Location>();
    }
    //перший крітер
    public Creature GetActive()
    {
        foreach (Creature c in Party)
        {
            if (!c.IsDead())
                return c;
        }
        return null;
    }
    //метод перевірки чи померли всі чувачки
    public bool AllDead()
    {
        return GetActive() == null;
    }
    //хілка
    public void HealAll()
    {
        foreach (Creature c in Party)
        {
            c.Heal();
        }
    }
    public void MoveTo(Location next)
    {
        History.Push(Current);
        Current = next;
    }
    public bool GoBack()
    {
        if (History.Count > 0)
        {
            Current = History.Pop();
            return true;
        }
        return false;
    }
}
