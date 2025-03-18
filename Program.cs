namespace Polis
{
  public class Program
  {
    static void Main(string[] args)
    {
        // ask for player name
        // make new city instance
        // generate new leader citizen with name and random skill
        // add new leader citizen to city
        // start while loop
        //  process turn
        //  process command
        // get out

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

        while(!city.isGameEnd())
        {
            int c = 1;
            while(c != 0)
            {
                city.displayState();
                city.displayCitizens();
                c = city.processTurn();
            }

            city.updateState();
            city.checkWinOrLoss();
        }

        if(city.isWin())
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
