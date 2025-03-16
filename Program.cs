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
        king_name = Console.ReadLine();

        Console.Write("And of what Polis are you the king of? ");
        city_name = Console.ReadLine();

        Console.WriteLine("Hail to " + king_name + "! The king of " + city_name + "!");

        City city = new City(king_name, city_name);
        city.displayState();
    }
  }
}
