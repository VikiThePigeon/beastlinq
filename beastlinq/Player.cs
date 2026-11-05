using System;
using System.Collections.Generic;

public class Player
{
    //стартові стати(лока імя) інкапсуляція шоб не можна було змінювати локацію ззовні і монстра теж
    public string Name { get; private set; }
    public Location Current { get; private set; }
    private readonly List<Creature> party = new List<Creature>();
    private readonly Stack<Location> history = new Stack<Location>();//history of locations
    public IReadOnlyList<Creature> Party
    {
        get { return party; }
    }
    public Player(string name, Location start)
    {
        Name = name;
        Current = start;
    }
    //метод додавання крітера в команду
    public void AddCreature(Creature c)
    {
        if (c != null)
            party.Add(c);
    }
    //перший крітер
    public Creature GetActive()
    {
        foreach (Creature c in party)
        {
            if (!c.IsDead)
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
        foreach (IHealable c in party)
        {
            c.Heal();
        }
    }
    //метод передвіженія
    public void MoveTo(Location next)
    {
        history.Push(Current);
        Current = next;
    }
    //метод повернення
    public bool GoBack()
    {
        if (history.Count > 0)
        {
            Current = history.Pop();
            return true;
        }
        return false;
    }
    //респавн після смерті
    public void Respawn(Location home)
    {
        Current = home;
        history.Clear();
        HealAll();
    }
}
