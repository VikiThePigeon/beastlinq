using System;
using System.Collections.Generic;

//обьява абстрактного класу крітера, який має онлі наслідування
public abstract class Creature : IDamageable, IHealable, IShowable
{
    //Інкапсуляція: ззовні всі властивості лише для читання, змінюються тільки через методи самого класу (TakeDamage, Heal, Restore)
    public string Name { get; private set; }
    public int HP { get; private set; }
    public int MaxHP { get; private set; }
    public int Attack { get; private set; }
    //список мувів крітера, який не можна змінювати ззовні
    private readonly List<Move> moves = new List<Move>();
    public IReadOnlyList<Move> Moves
    {
        get { return moves; }
    }

    public bool IsDead
    {
        get { return HP <= 0; }
    }
    //елемент крітера, який має бути реалізований у наслідниках (поліморфізм)
    public abstract string Element { get; }

    protected Creature(string name, int hp, int attack, params Move[] startMoves)
    {
        //валідація: некоректний об'єкт створити неможливо
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Ім'я істоти не може бути порожнім.");
        if (hp <= 0)
            throw new ArgumentException("HP має бути більше нуля.");
        if (attack < 0)
            throw new ArgumentException("Атака не може бути від'ємною.");
        Name = name;
        HP = hp;
        MaxHP = hp;
        Attack = attack;
        if (startMoves.Length == 0)
        {
            moves.Add(new AttackMove("Bite", 10));
            moves.Add(new AttackMove("Noise", 8));
        }
        else
        {
            moves.AddRange(startMoves);
        }
    }
    //поліморфізм: множник дамага проти стихії цілі (за замовчуванням 1.0)
    public virtual double GetMultiplier(string targetElement)
    {
        return 1.0;
    }
    //метод отримання дамага
    public void TakeDamage(int damage)
    {
        if (damage < 0)
            return;
        HP = Math.Max(0, HP - damage);// HP ніколи не стане менше 0
    }
    //метод часткового відновлення (HP не може перевищити MaxHP)
    public void Restore(int amount)
    {
        if (amount <= 0)
            return;
        HP = Math.Min(MaxHP, HP + amount);
    }
    //метод хілки
    public void Heal()
    {
        HP = MaxHP;
    }
    //метод показу
    public void Show()
    {
        Console.WriteLine(Name + " [" + Element + "] (HP: " + HP + "/" + MaxHP + ")");
    }
}
