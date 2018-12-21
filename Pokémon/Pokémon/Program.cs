using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

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

        private static int[] pokemonsInStorage = {1, 2, 3};
        private static string rival = "Misty";
        //private static string[] movePoolBulbasaur = new string[] {"Vine Whip", "Tackle", "Poison Powder", "Razor Leaf"};
        //private static string[] movePoolCharmander = new string[] {"Ember", "Scratch", "Fire Spin", "Fire Fang"};
        //private static string[] movePoolSquirtle = new string[] {"Water Gun", "Bubble", "Tackle", "Aqua Tail"};
        private static string[] MistysPokemon = {"Bulbasaur", "Charmander", "Squirtle"};
        private static string[] caughtORNot = {"Got it!", "Oh no, the Pokémon escaped!"};
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

        CatchPokemon cp = new CatchPokemon();

        static void Main(string[] args)
        {

            /// *** PROFESSOR OAKS INTRO SPEECH *** ///
             string path = @"C:\Users\Ejer\Documents\ProfessorOak.txt";
             List<string> ProfessorOaksSpeech = new List<string>(File.ReadAllLines(path, Encoding.UTF8));

             int i = 0;
             while (i < ProfessorOaksSpeech.Count)
             {
                 Console.WriteLine(ProfessorOaksSpeech[i]);
                 i += 1;
             }

            /// *** ATTEMPT ON DATABASE CONNECTION FOR PROFESSOR OAKS INTRO SPEECH, BUT I CAN'T GET IT WORKING :( *** ///
            /*string server = "localhost";
            string database = "pokemon_profoak_intro";
            string username = "root";
            string password = "";
            string query = "SELECT * FROM textintro";
            MySqlConnection connection;
            string connectionString = String.Format("server={0}; uid={2}; password={3}; database={1}; ", server, database, username, password);
            
            MySqlConnection msc = new MySqlConnection(connectionString);
            connection = new MySqlConnection(connectionString);


            List<string>[] list = new List<string>[1];
            list[0] = new List<string>();
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                list[0].Add(dataReader["oaksIntro"] + "");
            }
            dataReader.Close();
            connection.Close();
            Console.WriteLine(list);*/
            /// *** END OF DATABASE CONNECTION ATTEMPT *** ///

            /// *** CHOOSE YOUR STARTING POKÉMON *** ///
            Console.WriteLine("\nChoose Your Starter Pokémon!\n");
            Console.WriteLine("Bulbasaur | Charmander | Squirtle\n");
            string chooseStarter = Console.ReadLine();
            if (chooseStarter == "Bulbasaur".ToLower())
            {
                Console.WriteLine("\nCongratulations You Chose Bulbasaur!");
                MistysPokemon = new string[] {"Charmander"};
            }
            else if (chooseStarter == "Charmander".ToLower())
            {
                Console.WriteLine("\nCongratulations You Chose Charmander!");
                MistysPokemon = new string[] {"Squirtle"};
            }
            else if (chooseStarter == "Squirtle".ToLower())
            {
                Console.WriteLine("\nCongratulations You Chose Squirtle!");
                MistysPokemon = new string[] {"Bulbasaur"};
            }

            /// *** INTRO FOR BATTLE *** ///
            Console.WriteLine("\nProf. Oak: OH look there's " + rival + " you need to battle her to start your adventure!");
            Console.WriteLine("\nDo You Want To Battle? Y/N");
            if (chooseStarter == "Bulbasaur".ToLower())
            {
                ChoosenStarter();
            }
            else if (chooseStarter == "Charmander".ToLower())
            {
                ChoosenStarter();
            }
            else if (chooseStarter == "Squirtle".ToLower())
            {
                ChoosenStarter();
            }
            else
            {
                Console.WriteLine("GAME OVER!");
            }
        }

        /// *** DISPLAY CHOICE MENU AND ACTIONS *** ///
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
                if (choice == CatchWildPokemon)
                {
                    CatchPokemon cp = new CatchPokemon();
                    cp.ChoiceCatchWildPokemon();
                    
                }
                else if (choice == BattleInLeagues)
                {
                    RequirementsToBattleInLeagues();
                }
                else if(choice == Exit)
                {
                    isRunning = false;
                }
            }
        }

        private static bool isRunning;
        private static bool battleInLeagues;

        /// *** THE MENU *** ///
        private static void DisplayMenu()
        {
            Console.WriteLine("\nWhat do you want to do?\n");
            Console.WriteLine($"{CatchWildPokemon}. Catch wild Pokémon");
            Console.WriteLine($"{BattleInLeagues}. Battle in Leagues");
            Console.WriteLine($"{Exit}. Exit");
        }
        private static void RequirementsToBattleInLeagues()
        {
            if(pokemonsInStorage.Length < 3)
            {
                Console.WriteLine($"You need to catch "+(3-pokemonsInStorage.Length)+" more Pokémons to battle");
            }
        }


        /// *** CHOICE CATCH WILD POKEMON ACTIONS *** ///
        class CatchPokemon
        {
            public void CatchWildPokemonIntro()
            {
                Console.WriteLine("\nIt's time to catch some wild Pokémon!");
                Console.WriteLine("Let's walk around and explore this area.");
            }

            // This doesn´t fully work as it should, but i gave it a try
            public void ChoiceCatchWildPokemon()
            {
                CatchWildPokemonIntro();
                Console.ReadKey();

                Random rnd = new Random();
                int foundWildPokemon = rnd.Next(1, 1);
                if (foundWildPokemon == 1)
                {
                    Console.WriteLine("\nYou Encountered A Wild " + GetRandomElementFromArray(spawnRandomPokemon));
                    Console.WriteLine("\nCatch it by pressing 'A' on your keyboard");
                    string buttonPressed = Console.ReadLine();
                    if(buttonPressed == "A".ToLower())
                    {
                        IsCatchSuccessful();

                        if(GetRandomElementFromArray(caughtORNot) == caughtORNot[0])
                        {
                            int i = 0;
                            while (i < 1)
                            {
                                i += 1;
                                Console.WriteLine($"You now have {pokemonsInStorage[1]} Pokémons in your storage");
                            }
                        }
                    }
                }
            }
        }
        private static void IsCatchSuccessful()
        {
            Console.WriteLine(GetRandomElementFromArray(caughtORNot));
        }

        private static string GetRandomElementFromArray(string[] targetArray)
        {
            // Create a Random Object
            Random rnd = new Random();
            // Generate a random index less than the size of the array
            int indexInArray = rnd.Next(targetArray.Length);

            // Display result
            return $"{targetArray[indexInArray]}";
        }

        /// *** BATTLE SYSTEM *** ///
        private static bool GetBattleForBulbasaur()
        {
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
            // THE BATTLE
            if (yourPokemonAtkStat >= opponentsPokemonDefStat)
            {
                Console.WriteLine("You defeated " + rival + "'s Pokémon, GOOD JOB!\n");
                isRunning = true;
                Menu();
                return true;
            }
            else
            {
                Console.WriteLine("YOU LOST!\n");
                return false;
            }
        }

        /// *** BATTLE FUNCTION *** ///
        private static void ChoosenStarter()
        {
            string userInput = Console.ReadLine();
            if (userInput == "Y".ToLower())
            {
                Console.WriteLine(rival + " Threw out " + GetRandomElementFromArray(MistysPokemon));
                Console.WriteLine("\nFIGHT!!!\n");
                while (GetBattleForBulbasaur() == false)
                {
                    Console.WriteLine("Professor Oak healed your Pokémon, take up the battle again. Type 'Y'");
                    userInput = Console.ReadLine();
                }
            } 
        }
    }
}
