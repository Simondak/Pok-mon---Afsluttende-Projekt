using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pokémon
{
    class Program
    {
        private static readonly Dictionary<string, string> Choice = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"CatchWildPokemon", "1"},
            {"BattleInLeagues", "2"},
            {"Exit", "3"}
        };
        
        private static readonly string CatchWildPokemon = Choice["CatchWildPokemon"];
        private static readonly string BattleInLeagues = Choice["BattleInLeagues"];
        private static readonly string Exit = Choice["Exit"];

        private static int pokemonsInStorage = 6;
        private static string rival = "Misty";
        //private static string[] movePoolBulbasaur = new string[] {"Vine Whip", "Tackle", "Poison Powder", "Razor Leaf"};
        //private static string[] movePoolCharmander = new string[] {"Ember", "Scratch", "Fire Spin", "Fire Fang"};
        //private static string[] movePoolSquirtle = new string[] {"Water Gun", "Bubble", "Tackle", "Aqua Tail"};
        private static int bulbasaurHP = 45;
        private static int charmanderHP = 39;
        private static int squirtleHP = 44;
        private static string[] spawnRandomPokemon = {
        "Bulbasaur", "Ivysaur", "Venusaur", "Charmander", "Charmeleon",
        "Charizard", "Squirtle", "Wartortle", "Blastoise", "Caterpie",
        "Metapod", "Butterfree", "Weedle", "Kakuna", "Beedrill",
        "Pidgey", "Pidgeotto", "Pidgeot", "Rattata", "Raticate",
        "Spearow", "Fearow", "Ekans", "Arbok", "Pikachu",
        "Raichu", "Sandshrew", "Sandslash", "Nidoran", "Nidorina",
        "Nidoqueen", "Nidoran", "Nidorino", "Nidoking", "Clefairy",
        "Clefable", "Vulpix", "Ninetales", "Jigglypuff", "Wigglytuff",
        "Zubat", "Golbat", "Oddish", "Gloom", "Vileplume",
        "Paras", "Parasect", "Venonat", "Venomoth", "Diglett",
        "Dugtrio", "Meowth", "Persian", "Psyduck", "Golduck",
        "Mankey", "Primeape", "Growlithe", "Arcanine", "Poliwag",
        "Poliwhirl", "Poliwrath", "Abra", "Kadabra", "Alakazam",
        "Machop", "Machoke", "Machamp", "Bellsprout", "Weepinbell",
        "Victreebel", "Tentacool", "Tentacruel", "Geodude", "Graveler",
        "Golem", "Ponyta", "Rapidash", "Slowpoke", "Slowbro",
        "Magnemite", "Magneton", "Farfetch'd", "Doduo", "Dodrio",
        "Seel", "Dewgong", "Grimer", "Muk", "Shellder",
        "Cloyster", "Gastly", "Haunter", "Gengar", "Onix",
        "Drowzee", "Hypno", "Krabby", "Kingler", "Voltorb",
        "Electrode", "Exeggcute", "Exeggutor", "Cubone", "Marowak",
        "Hitmonlee", "Hitmonchan", "Lickitung", "Koffing", "Weezing",
        "Rhyhorn", "Rhydon", "Chansey", "Tangela", "Kangaskhan",
        "Horsea", "Seadra", "Goldeen", "Seaking", "Staryu",
        "Starmie", "Mr. Mime", "Scyther", "Jynx", "Electabuzz",
        "Magmar", "Pinsir", "Tauros", "Magikarp", "Gyarados",
        "Lapras", "Ditto", "Eevee", "Vaporeon", "Jolteon", "Flareon",
        "Porygon", "Omanyte", "Omastar", "Kabuto", "Kabutops", "Aerodactyl",
        "Snorlax", "Articuno", "Zapdos", "Moltres", "Dratini", "Dragonair", "Dragonite", "Mewtwo", "Mew" };

        
        static void Main(string[] args)
        {
            string path = @"C:\Users\Ejer\Documents\ProfessorOak.txt";
            List<string> ProfessorOaksSpeech = new List<string>(File.ReadAllLines(path, Encoding.UTF8));

            int i = 0;
            while (i < ProfessorOaksSpeech.Count)
            {
                Console.WriteLine(ProfessorOaksSpeech[i]);
                i += 1;
            }

            Console.WriteLine("\nChoose Your Starter Pokémon!\n");
            Console.WriteLine("Bulbasaur | Charmander | Squirtle\n");
            string chooseStarter = Console.ReadLine();

            if(chooseStarter == "Bulbasaur".ToLower())
            {
                Console.WriteLine("\nCongratulations You Chose Bulbasaur!");
            }
            else if (chooseStarter == "Charmander".ToLower())
            {
                Console.WriteLine("\nCongratulations You Chose Charmander!");
            }
            else if (chooseStarter == "Squirtle".ToLower())
            {
                Console.WriteLine("\nCongratulations You Chose Squirtle!");
            }
            Console.WriteLine("\nProf. Oak: OH look there's " + rival + " you need to battle her to start your adventure!");
            Console.WriteLine("\nDo You Want To Battle? Y/N");
            string userInput = Console.ReadLine();
            if(userInput == "Y".ToLower())
            {
                if (chooseStarter == "Bulbasaur".ToLower())
                {
                    Console.WriteLine(rival + " Threw out Charmander");
                    Console.WriteLine("\nFIGHT!!!\n");

                    Random rnd = new Random();
                    // YOUR POKÉMON
                    int yourPokemonHPStat = rnd.Next(20, 20);
                    int yourPokemonAtkStat = rnd.Next(20, 20);
                    int yourPokemonDefStat = rnd.Next(20, 20);
                    int yourPokemonLvl = rnd.Next(5, 5);
                    // MISTY'S POKÉMON
                    int opponentsPokemonHPStat = rnd.Next(1, 100);
                    int opponentsPokemonAtkStat = rnd.Next(1, 60);
                    int opponentsPokemonDefStat = rnd.Next(1, 40);
                    int opponentsPokemonLvl = rnd.Next(1, 100);

                    // The Battle
                    if(yourPokemonAtkStat >= opponentsPokemonDefStat)
                    {
                        Console.WriteLine("You defeated " + rival + "'s Pokémon, GOOD JOB!\n");
                        isRunning = true;
                        Menu();
                    }
                    else
                    {
                        Console.WriteLine("YOU LOST!");
                    }

                    /*
                    Console.WriteLine("Bulbasaur has these 4 moves, what do you want to use?\n" + string.Join(", ", movePoolBulbasaur));
                    string userInputMoves = Console.ReadLine();
                    if (userInputMoves == movePoolBulbasaur[0].ToLower())
                    {
                        Console.WriteLine("Bulbasaur used " + movePoolBulbasaur[0] + ", opponent took 10 damage\n");
                    }
                    else if (userInputMoves == movePoolBulbasaur[1].ToLower())
                    {
                        Console.WriteLine("Bulbasaur used " + movePoolBulbasaur[1] + ", opponent took 2 damage\n");
                    }
                    else if(userInputMoves == movePoolBulbasaur[2].ToLower())
                    {
                        Console.WriteLine("Bulbasaur used " + movePoolBulbasaur[2] + ", opponent took 6 damage\n");
                    }
                    else if(userInputMoves == movePoolBulbasaur[3].ToLower())
                    {
                        Console.WriteLine("Bulbasaur used " + movePoolBulbasaur[3] + ", opponent took 12 damage\n");
                    }*/
                }

            }
            else
            {
                Console.WriteLine("GAME OVER!");
            }
            

            
            //isRunning = true;
            //Menu();
        }

        public static void Menu()
        {
            while (isRunning)
            {
                DisplayMenu();

                var choice = Console.ReadLine();
                while(Choice.All(n => n.Value != choice))
                {
                    Console.WriteLine($"\nPlease type '{CatchWildPokemon}', '{BattleInLeagues}' or exit the game typing '{Exit}'.");
                    choice = Console.ReadLine();
                }
                if(choice == Exit)
                {
                    isRunning = false;
                }
            }
        }

        private static bool isRunning;
        private static bool battleInLeagues;
        private static void DisplayMenu()
        {
            Console.WriteLine("\nWhat do you want to do?\n");
            Console.WriteLine($"{CatchWildPokemon}. Catch wild Pokémon");
            Console.WriteLine($"{BattleInLeagues}. Battle in Leagues");
            Console.WriteLine($"{Exit}. Exit");
        }
        private static void RequirementsToBattleInLeagues()
        {
            if(pokemonsInStorage < 6)
            {
                Console.WriteLine($"You need to catch {0} more Pokémons to battle");
            }
        }
        public static class CatchPokemon
        {
            private static void CatchWildPokemonIntro()
            {
                Console.WriteLine("\nIt's time to catch some wild Pokémon!");
                Console.WriteLine("Let's walk around and explore this area.");
            }
            private static void ChoiceCatchWildPokemon()
            {
                CatchWildPokemonIntro();
                Console.ReadKey();

                Random rnd = new Random();
                Enumerable.Repeat<Action>(() =>
                {
                    int foundWildPokemon = rnd.Next(1, 3);
                    if (foundWildPokemon == 1)
                    {
                        Console.WriteLine(GetRandomElementFromArray());
                    }
                }, 30).ToList().ForEach(x => x());
            }
        }
        private static bool IsCatchSuccessful()
        {
            return new Random().Next(100) >= 50;
        }

        private static string GetRandomElementFromArray()
        {
            // Create a Random Object
            Random rnd = new Random();
            // Generate a random index less than the size of the array
            int indexInArray = rnd.Next(spawnRandomPokemon.Length);

            // Display result
            return $"You Encoutered A Wild {spawnRandomPokemon[indexInArray]}";
        }
    }
}
