namespace Polis
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool showcase_mode = true;

            ConsoleKeyInfo response;

            Console.WriteLine();
            Console.Write("Showcase mode? y/n: ");
            response = Console.ReadKey();

            Console.WriteLine();
            if (response.KeyChar == 'n')
            {
                showcase_mode = false;
            }
            else if (response.KeyChar != 'y')
            {
                Console.WriteLine("Invalid response, exiting program...");
            }

            Console.Clear();

            if (showcase_mode)
            {
                // showcase the Citizen Class
                City sparta = new City("Menaleus", "Sparta");

                Citizen citizen = new Citizen(sparta, "Spartan Citizen", "work");
                Console.WriteLine(citizen.getName() + ": " + "I am meant to " + citizen.getAction() + ".");
                Console.Write(citizen.getName() + ": "); citizen.processCommand();
                Console.WriteLine(citizen.getName() + ": " + "I can generate legendary names such as " + citizen.generateName() + "!");
                Console.WriteLine(citizen.getName() + ": " + "I can also generate my skill level: now I have a work skill of {0}!", citizen.generateSkill());

                Console.WriteLine();
                Console.WriteLine("Two Spartan Soldiers approach...");
                Console.WriteLine();

                SpartanSoldier tyndareos = new SpartanSoldier(sparta, "Tyndareos", 70);
                Console.WriteLine("Tyndareos: I shall {0}!", tyndareos.getAction());
                SpartanSoldier orestes = new SpartanSoldier(sparta, "Orestes", 70);
                Console.WriteLine("Orestes: I too shall {0}!", orestes.getAction());

                tyndareos.setOpponent(orestes);
                orestes.setOpponent(tyndareos);

                Console.WriteLine();
                Console.WriteLine("The two combatants take their stances...");
                Console.WriteLine();

                Console.WriteLine("Tyndareos challenges Orestes to single combat!");
                tyndareos.processCommand();
                tyndareos.processCommand();
                tyndareos.processCommand();

                Console.WriteLine();

                Console.WriteLine("Orestes challenges Tyndareos to single combat!");
                orestes.processCommand();
                orestes.processCommand();
                orestes.processCommand();

                Console.WriteLine();
                Console.WriteLine("Thus ends the showcase...");
            }
            else
            {
                String king_name;
                String city_name;

                // generated using https://patorjk.com/software/taag/
                Console.WriteLine(@"  ________  ________  ___       ___  ________      ");
                Console.WriteLine(@" |\   __  \|\   __  \|\  \     |\  \|\   ____\     ");
                Console.WriteLine(@" \ \  \|\  \ \  \|\  \ \  \    \ \  \ \  \___|_    ");
                Console.WriteLine(@"  \ \   ____\ \  \\\  \ \  \    \ \  \ \_____  \   ");
                Console.WriteLine(@"   \ \  \___|\ \  \\\  \ \  \____\ \  \|____|\  \  ");
                Console.WriteLine(@"    \ \__\    \ \_______\ \_______\ \__\____\_\  \ ");
                Console.WriteLine(@"     \|__|     \|_______|\|_______|\|__|\_________\");
                Console.WriteLine(@"                                       \|_________|");
                Console.WriteLine(@"                                                   ");

                Console.WriteLine("Welcome to Polis, a game of city-state management!");
                Console.Write("Please enter your name, o king: ");
                king_name = Console.ReadLine()!; // I trust that this won't be nullable

                Console.Write("And of what Polis are you the king of? ");
                city_name = Console.ReadLine()!; // this too

                Console.WriteLine("Hail to " + king_name + "! The king of " + city_name + "!");

                City city = new City(king_name, city_name);

                city.addCitizen("Commander");
                city.addCitizen("Farmer");
                city.addCitizen("Merchant");

                while (!city.isGameEnd())
                {
                    int c = 1;
                    while (c != 0)
                    {
                        city.displayState();
                        city.displayCitizens();
                        c = city.processTurn();
                    }

                    city.updateState();
                    city.checkWinOrLoss();
                }

                if (city.isWin())
                {
                    Console.WriteLine("Congratulations, King " + king_name + "! Your polis has become prosperous!");
                    city.displayState();
                }
                else
                {
                    Console.WriteLine("Your people have all met their demise and your polis is left in ruin, you have become forgotten and lost in the annals of history...");
                }
            }
        }
    }
}
