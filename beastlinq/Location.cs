using System;
using System.Collections.Generic;

public class Location : IShowable
{
    //стати локацій
    public string Name { get; private set; }
    private readonly List<Location> neighbours = new List<Location>();
    private readonly Queue<Creature> Wild = new Queue<Creature>();
    public IReadOnlyList<Location> Neighbours
    {
        get { return neighbours; }
    }
    public Location(string name)
    {
        Name = name;
    }
    //метод підключення локацій
    public void Connect(Location other)
    {
        neighbours.Add(other);
        other.neighbours.Add(this);
    }
    //метод додавання дикого крітера queue
    public void AddWild(Creature c)
    {
        Wild.Enqueue(c);
    }
    //метод отримання дикого крітера null якщо немає
    public Creature GetWild()
    {
        if (Wild.Count == 0)
        {
            return null;
        }
        return Wild.Dequeue();
    }
    //метод що відбувається коли гравець заходить (у звичайній локації - нічого)
    public virtual void OnEnter(Player player)
    {
    }
    public void Show()
    {
        Console.WriteLine("\n You r here: " + Name);
        Console.WriteLine("Where to go?");
        for (int i = 0; i < Neighbours.Count; i++)
        {
            Console.WriteLine((i + 1) + " - " + Neighbours[i].Name);
        }
    }
}
