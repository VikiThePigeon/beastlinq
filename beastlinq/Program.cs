using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static Dictionary<string, Location> World = new Dictionary<string, Location>();
    //метод створення світу
    static void CreateWorld()
    {
        //places
        World["City"] = new Location("City");
        World["Field"] = new Location("Field");
        World["Forest"] = new Location("Forest");
        World["Lake"] = new Location("Lake");

        World["City"].Connect(World["Field"]);
        World["Field"].Connect(World["Forest"]);
        World["Forest"].Connect(World["Lake"]);
        World["Lake"].Connect(World["City"]);
        //wild creatures

        World["Field"].AddWild(new Creature("Meepy", 30, 8));//sheep
        World["Field"].AddWild(new Creature("Shorat", 25, 7, new Move("Bite", 12), new Move("Scratch", 8)));//shadow rat
        World["Forest"].AddWild(new Creature("Mappy", 40, 10, new Move("Slam", 15), new Move("Light Beam", 10), new Move("Bark", 5)));//light type dawg
        World["Forest"].AddWild(new Creature("Igurass", 35, 11));//grass lizord
        World["Lake"].AddWild(new Creature("Koipoi", 38, 9, new Move("Splash", 14), new Move("Tackle", 10)));
    }
    //метод створення гравця
    static void Main(string[] args)
    {

        CreateWorld();
        Player player = new Player("Evo", World["City"]);
        player.Party.Add(new Creature("Flaminny", 45, 12));//fire snail

        Console.WriteLine("Catch a creature!");

        while (player.Party.Count < 3)
        {
            //гравець вибирає куди йти
            Console.WriteLine("\nYou r here: " + player.Current.Name);
            Console.WriteLine("Where you want to go?");
            for (int i = 0; i < player.Current.Neighbours.Count; i++)
            {
                Console.WriteLine((i + 1) + " - " + player.Current.Neighbours[i].Name);
            }
            Console.WriteLine("b - back");
            Console.WriteLine("0 - exit");

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

            if (player.Current.Name == "City")
            {
                player.HealAll();
                Console.WriteLine("Creatures healed.");
            }

            Creature wild = player.Current.GetWild();
            if (wild != null)
            {
                Battle battle = new Battle(player, wild);
                battle.Start();

                //
                if (!player.Party.Contains(wild))
                {
                    wild.Heal();
                    player.Current.AddWild(wild);
                }
                if (player.AllDead())
                {
                    Console.WriteLine("All your creatures have fainted. You are back in the city.");
                    player.Current = World["City"];
                    player.History.Clear();
                    player.HealAll();
                }
            }
        }
        Console.WriteLine("You won! You have 3 creatures.");
    }
}