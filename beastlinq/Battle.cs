using System;
using System.Collections.Generic;

class Battle
{
    //характеристики битви
    public Player Player { get; set; }
    public Creature Enemy { get; set; }
    Random rnd = new Random();
    public Battle(Player player, Creature enemy)
    {
        Player = player;
        Enemy = enemy;
    }
    //метод старту і цикл битви
    public void Start()
    {
        Console.WriteLine("Battle started!");
        while (!Enemy.IsDead() && !Player.AllDead())
        {
            while (!Enemy.IsDead() && !Player.AllDead())
            {
                Creature me = Player.GetActive();
                me.Show();
                Enemy.Show();
                Console.WriteLine("1 - Attack, 2 - Catch, 3 - Flee");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (!PlayerAttack(me))
                        continue;   // неправильний вибір ходу - хід не витрачається
                }
                else if (choice == "2")
                {
                    if (TryCatch())
                        return;
                }
                else if (choice == "3")
                {
                    Console.WriteLine("You fled!");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }
                if (Enemy.IsDead())
                {
                    Console.WriteLine("You won!");
                    return;
                }
                EnemyAttack(me);
            }
        }
    }
    //метод атаки якщо хиба то не правильний хід і не витрачається
    public bool PlayerAttack(Creature me)
    {
        for (int i = 0; i < me.Moves.Count; i++)
        {
            Console.Write((i + 1) + ". ");
            me.Moves[i].ShowMove();
        }
        int n;
        if (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > me.Moves.Count)
        {
            Console.WriteLine("Invalid choice.");
            return false;
        }
        int dmg = me.Moves[n - 1].GetDamage(me.Attack);
        Enemy.TakeDamage(dmg);
        Console.WriteLine("You dealt " + dmg + " damage!");
        return true;
    }
    //метод атаки ворога
    public void EnemyAttack(Creature me)
    {
        Move m = Enemy.Moves[rnd.Next(Enemy.Moves.Count)];
        int d = m.GetDamage(Enemy.Attack);
        me.TakeDamage(d);
        Console.WriteLine(Enemy.Name + " used " + m.Name + " and dealt " + d + " damage!");
    }
    //метод спроби піймати
    public bool TryCatch()
    {
        int chance = 30 + (Enemy.MaxHP - Enemy.HP);
        if (rnd.Next(100) < chance)
        {
            Enemy.Heal();
            Player.Party.Add(Enemy);
            Console.WriteLine("You caught tha THING!");
            return true;
        }
        Console.WriteLine("You failed to catch tha THING!");
        return false;
    }
}