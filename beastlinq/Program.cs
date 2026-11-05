using System;
using System.Collections.Generic;

class Program
{
    private static readonly Dictionary<string, Location> World = new Dictionary<string, Location>();
    //метод створення світу приватний - ззовні недоступний
    static void CreateWorld()//граф бтв
    {
        //places
        World["City"] = new CityLocation("City");
        World["Field"] = new Location("Field");
        World["Forest"] = new Location("Forest");
        World["Lake"] = new Location("Lake");

        World["City"].Connect(World["Field"]);
        World["Field"].Connect(World["Forest"]);
        World["Forest"].Connect(World["Lake"]);
        World["Lake"].Connect(World["City"]);
        //wild creatures
        World["Field"].AddWild(new DarkCreature("Shorat", 25, 7, new AttackMove("Bite", 12), new AttackMove("Scratch", 8)));//shadow rat
        World["Forest"].AddWild(new LightCreature("Mappy", 40, 10, new AttackMove("Slam", 15), new AttackMove("Light Beam", 10), new AttackMove("Bark", 5)));//light type dawg
        World["Forest"].AddWild(new GrassCreature("Skalie", 35, 11, new AttackMove("Vine Whip", 10), new AttackMove("Seed Bomb", 12)));//grass lizord
        World["Lake"].AddWild(new WaterCreature("Lumi", 38, 9, new AttackMove("Splash", 14), new HealMove("Healing slime", 10)));//fih
    }
    //метод створення гравця
    static void Main()
    {

        CreateWorld();
        Player player = new Player("Evo", World["City"]);
        player.AddCreature(new FireCreature("Flaminny", 45, 12, new AttackMove ("Tackle", 10), new AttackMove ("Ember", 20)));//fire snail

        Console.WriteLine("Catch a creature!");

        while (player.Party.Count < 3)
        {
            //гравець вибирає куди йти
            player.Current.Show();
            Console.WriteLine("b - back");
            Console.WriteLine("0 - exit");
            //гравець вводить вибір
            string input = Console.ReadLine();
            if (input == "0")
            {
                return;
            }
            if (input == "b")
            {
                if (!player.GoBack())
                {
                    Console.WriteLine("No way back.");
                    continue;
                }
            }
            //інвалід ввід
            else
            {
                int n;
                if (!int.TryParse(input, out n) || n < 1 || n > player.Current.Neighbours.Count)
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }
                player.MoveTo(player.Current.Neighbours[n - 1]);
            }
            //поліморфізм: у місті лікує, в інших локаціях нічого не робить
            player.Current.OnEnter(player);
            //гравець зустрічає дикого крітера
            Creature wild = player.Current.GetWild();
            if (wild != null)
            {
                Battle battle = new Battle(player, wild);
                battle.Start();

                //додати дикого крітера до парті гравця, якщо він не в парті
                if (!battle.Caught)
                {
                    wild.Heal();
                    player.Current.AddWild(wild);
                }
                if (player.AllDead())
                {
                    Console.WriteLine("All your creatures have fainted. You are back in the city.");
                    player.Respawn(World["City"]);
                }
            }
        }
        Console.WriteLine("You won! You have 3 creatures.");
    }
}