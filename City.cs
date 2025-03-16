namespace Polis
{
    public class City
    {
        private String king_name;
        private String city_name;

        private int current_year;
        private int population;
        private int grain;
        private int gold;
        private int land_level;
        private int soldiers;
        private int training_level;

        private int invasion_counter;
        private int invasion_number;
        private int invasion_level;

        private List<Building> buildings; 
        private int max_buildings;

        private List<Citizen> citizen;
        private int max_citizen;

        private bool win;
        private bool lose; // why seperate? i forgot
        private bool gameEnd;

        public City(String _king_name, String _city_name)
        {
            king_name = _king_name;
            city_name = _city_name;

            // initial city parameters
            current_year = 0;
            population = 100;
            grain = 50;
            gold = 100;
            land_level = 10;
            soldiers = 100;
            training_level = 10;

            // initial invasion parameters
            invasion_counter = 5;
            invasion_number = 200;
            invasion_level = 20;

            buildings = new List<Building>();
            max_buildings = 4; // should be const?
            citizen = new List<Citizen>();
            max_citizen = 10;

            citizen.Add(new Leader(this, king_name));
            
            win = false;
            lose = false;
            gameEnd = false;
        }

        public void displayState()
        {
            Console.WriteLine();
            Console.WriteLine("King Name: " + king_name + "\t" + "| Polis Name: " + city_name + "\t" + "| Current Year: " + current_year + "\t" + " A.D.");
            Console.WriteLine("Population: " + population + "\t" + "| Grains: " + grain);
            Console.WriteLine("Gold: " + gold + "\t" + "| Land Level: " + land_level);
            Console.WriteLine("Soldiers: " + soldiers + "\t" + "| Training Level: " + training_level);
            Console.WriteLine("Years before next Invasion: " + invasion_counter);
        }

        public void displayCitizens()
        {
            Console.WriteLine();
            Console.WriteLine("{0,-10} {1, -20} {2, -16} {3, -6} {4, -6}",
                                "Choice", "Name", "Role", "Skill", "Has Acted");
            
            for(int i = 0; i < citizen.Count(); i++)
            {
                Console.WriteLine("{0,-10} {1, -20} {2, -16} {3, -6} {4, -6}",
                                    i+1, citizen[i].getName(), citizen[i].getRole(),
                                    citizen[i].getSkill(), citizen[i].isTired());
            }

            Console.WriteLine();
        }

        public int processTurn() // baaaaaaad, fix this
        { 
            Console.WriteLine("Enter 0 to end your turn.");
            Console.Write("Who shall act next? [1-" + citizen.Count() + "] ");

            try
            {
                
                int choice = Convert.ToInt32(Console.ReadLine());

                if(choice ==  0)
                {
                    return 0;
                }

                if(citizen[choice-1].isTired())
                {
                    Console.WriteLine("That citizen has already acted this turn, please choose a different citizen to act.");
                    return choice;
                }

                Console.Write("Will " + citizen[choice-1].getName() + " " + citizen[choice-1].getAction() + "? [1-yes, 0-no]"); 
                
                choice = Convert.ToInt32(Console.ReadLine());
                if(choice == 0)
                {
                    return 1;
                }
                else if(choice != 1)
                {
                    throw new Exception("Invalid input, please try again.");
                }

                citizen[choice-1].processCommand();
                citizen[choice-1].setTired(true);

                return choice;
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input, please try again.");
                return 1;
            }

        }

        public void updateState()
        {
            current_year += 1;
            invasion_counter -= 1;
            training_level -= 1;
            processInvasion();
            processBuildings();
            gainResources();
        }
        
        private void processInvasion()
        {

        }

        private void processBuildings()
        {
            if(buildings.Count() != 0)
            {
                foreach(Building i in buildings)
                {
                    i.process();
                }
            }
        }

        private void processUpkeep()
        {
            if(citizen.Count() != 0) // should be impossible but you never know
            {
                foreach(Citizen i in citizen)
                {
                    i.upkeep();
                    i.setTired(false);
                }
            }
        }

        private void gainResources()
        {
            if(grain >= population * 2)
            { 
                population += land_level * 2;
                Console.WriteLine("You gained " + (land_level * 2) + " population this turn.");
            }

            if(grain <= 0)
            {
                int loss = (int)((float)population * 0.10f);
                if(loss <= 0) loss = 1;
                population -= loss;
                Console.WriteLine("You lose " + loss + " population this turn.");
            }

            grain += (land_level * 4) - (population/2) - (soldiers);
            Console.WriteLine("You gained " + ((land_level * 4) - (population/2) - (soldiers)) + " grain this turn.");

            if(grain < 0) grain = 0;

            gold += (population/4) - (soldiers/2);
            Console.WriteLine("You gained " + ((population/4) - (soldiers/2)) + " gold this turn.");

            if(gold < 0) gold = 0;
        }

        public void increaseGold(int amount)
        {
            gold += amount;
        }

        public void increaseLandLevel()
        {

        }

        public void addBuilding()
        {

        }

        public void addCitizen(String type)
        {
            switch(type)
            {
                case "Commander":
                     citizen.Add(new Commander(this));
                     break;
                case "Farmer":
                     citizen.Add(new Farmer(this));
                     break;
                case "Developer":
                     citizen.Add(new Developer(this));
                     break;
                case "Merchant":
                     citizen.Add(new Merchant(this));
                     break;
                default:
                    break; // should not be reachable, if it did its your fault
            }
        }

        public bool isWin() { return win; }
        public bool isLose() { return lose; }
        public bool isGameEnd() { return gameEnd; }

        public void checkWinOrLoss()
        {
            if(population <= 0)
            {
                lose = true;
                gameEnd = true;
            }
            else if(population >= 1000)
            {
                win = true;
                gameEnd = true;
            }
        }
    }
}
