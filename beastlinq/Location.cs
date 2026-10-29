using System;
using System.Collections.Generic;

class Location
{
    //стати локацій
    public string Name { get; set; }
    public List<Location> Neighbours = new List<Location>();
    public Queue<Creature> Wild = new Queue<Creature>();
    public Location(string name)
    {
        Name = name;
        Neighbours = new List<Location>();
        Wild = new Queue<Creature>();
    }
    //метод підключення локацій
    public void Connect(Location other)
    {
        Neighbours.Add(other);
        other.Neighbours.Add(this);
    }
    //метод додавання дикого крітера queue
    public void AddWild(Creature c)
    {
        Wild.Enqueue(c);
    }
    //метод отримання дикого крітера null якщо немає
    public Creature GetWild()
    {
        if (Wild.Count > 0)
        {
            return Wild.Dequeue();
        }
        return null;
    }
}
