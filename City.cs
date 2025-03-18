namespace Polis
// so it will stop complaining about the unused exception e which i handled already
#pragma warning disable 0168
{
    public class City
    {
        public Random randomGenerator = new Random();
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
        private BuildingFactory factory;
        private int max_buildings;

        private List<Citizen> citizen;
        private int max_citizen;

        private bool win;
        private bool lose; // why seperate? i forgot
        private bool gameEnd;
        private int requiredPop;

        public City(String _king_name, String _city_name)
        {
            king_name = _king_name;
            city_name = _city_name;

            // initial city parameters
            current_year = 0;
            population = 1000;
            grain = 500;
            gold = 1000;
            land_level = 10;
            soldiers = 100;
            training_level = 10;

            // initial invasion parameters
            invasion_counter = 5;
            invasion_number = 200;
            invasion_level = 20;

            buildings = new List<Building>();
            factory = new BuildingFactory(this);
            max_buildings = 4; // should be const?
            citizen = new List<Citizen>();
            max_citizen = 10;

            citizen.Add(new Leader(this, king_name));
            
            win = false;
            lose = false;
            gameEnd = false;
            requiredPop = 10000;
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
            Console.WriteLine("Press Control + C to exit.");
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

                Console.Write("Will " + citizen[choice-1].getName() + " " + citizen[choice-1].getAction() + "? [1-yes, 0-no] "); 
                
                int confirm = Convert.ToInt32(Console.ReadLine());
                if(confirm == 0)
                {
                    return 1;
                }
                else if(confirm != 1)
                {
                    throw new Exception("Invalid input, please try again.");
                }

                int result = citizen[choice-1].processCommand();

                if(result != 0) citizen[choice-1].setTired(true);

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
            invasion_counter -= 1; // the processInvasion will reset this counter
            training_level -= 1;
            if(training_level <= 0) training_level = 0;
            processInvasion();
            checkWinOrLoss();
            processBuildings();
            processUpkeep();
            gainResources();
        }
        
        private void processInvasion()
        {
            if(invasion_counter > 0)
            {
                return;
            }

            // Invasion Start!
            Console.WriteLine("A force of {0} soldiers with a training level of {1} has invaded our city! Our {2} soldiers march out to meet them in battle!", invasion_number, invasion_level, soldiers);

            // Resolve Battle
            int cityPower = (soldiers/training_level) + randomGenerator.Next(0, citizen[0].getSkill()/2);
            int invasionPower = (invasion_number/invasion_level) + randomGenerator.Next(0, invasion_level/10);
            if(cityPower >= invasionPower)
            {
                soldiers -= cityPower * 10;
                if(soldiers <= 0) soldiers = 10;
                Console.WriteLine("Our soldiers have successfully repelled the invasion! But we lost soldiers and only have {0} left...", soldiers);
            }
            else
            {
                grain = 0;
                gold = 0;
                population = 0;
                Console.WriteLine("We've failed to repel the invasion, and they pillage and kill our citizens. Everything is burning. They march to us now to take your head...");
            }
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
                    // do i really need upkeep? seems like extra expense
                    // also, it doesnt show in the gains summary
                    // i.upkeep();
                    i.setTired(false);
                }
            }
        }

        private void gainResources()
        {
            if(grain >= population)
            { 
                population += land_level * 2;
                Console.WriteLine("You gained " + (land_level * 2) + " population this turn.");
            }

            int newArrivals = randomGenerator.Next(0, 100);
            population += newArrivals; // passive population
            Console.WriteLine(newArrivals + " new people have come to live to our polis.");

            if(grain <= 0)
            {
                int loss = (int)((float)population * 0.30f);
                if(loss <= 0) loss = 10;
                population -= loss;
                Console.WriteLine("You lost " + loss + " population this turn.");
            }

            grain += (land_level * 4) - (population/2) - (soldiers);
            Console.WriteLine("You gained " + ((land_level * 4) - (population/2) - (soldiers)) + " grain this turn.");

            if(grain < 0) grain = 0;

            gold += (population/4) - (soldiers+(training_level/2)+1);
            Console.WriteLine("You gained " + ((population/2) - (soldiers+(training_level/2)+1)) + " gold this turn.");

            if(gold < 0) gold = 0;
        }

        public void increaseGold(int amount)
        {
            gold += amount;
        }

        public int getGold()
        {
            return gold;
        }

        public void increaseGrain(int amount)
        {
            grain += amount;
        }

        public int getGrain()
        {
            return grain;
        }

        public void increaseTraining(int amount)
        {
            training_level += amount;
            Console.WriteLine("Your training level increased by " + amount);
        }

        public int getTrainingLevel()
        {
            return training_level;
        }

        public void increaseSoldiers(int amount)
        {
            soldiers += amount;
            Console.WriteLine("You managed to draft " + amount + " soldiers.");
        }

        public void increasePopulation(int amount)
        {
            population += amount;
        }

        public int getPopulation()
        {
            return population;
        }

        public int getSoldiers()
        {
            return soldiers;
        }

        public void increaseLandLevel(int amount)
        {
            land_level += amount;
            Console.WriteLine("You increased your land level by " + amount + ".");
        }

        public int getLandLevel()
        {
            return land_level;
        }

        public void addBuilding(Building building)
        {
            buildings.Add(building);
        }

        // why did i do this? the calls are all over the place... fix this later on
        public int requestBuilding() 
        {
            return factory.requestBuilding();
        }

        public bool isAtMaxBuildings()
        {
            return buildings.Count() >= max_buildings;
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
        
        public int removeCitizen() // lots of repetition from processTurn BAAAAAAAAAAD
        {
            displayCitizens();
            Console.WriteLine("Enter 0 to cancel.");
            Console.Write("Who will you remove? [1-" + citizen.Count() + "] ");

            try
            {   
                int choice = Convert.ToInt32(Console.ReadLine());

                if(choice ==  0)
                {
                    return 0;
                }

                if(choice == 1)
                {
                    Console.WriteLine("You can't remove yourself.");
                    return 0;
                }

                Console.Write("Will you remove " + citizen[choice-1].getName() + "? [1-yes, 0-no] "); 
                
                int confirm = Convert.ToInt32(Console.ReadLine());
                if(confirm == 0)
                {
                    return 0;
                }
                else if(confirm != 1)
                {
                    throw new Exception("Invalid input, please try again.");
                }

                citizen.RemoveAt(choice-1);

                return 1;
            }
            catch(Exception e)
            {
                Console.WriteLine("Invalid input, please try again.");
                return 0;
            }

        }

        public bool isAtMaxCitizen()
        {
            return citizen.Count() >= max_citizen;
        }

        public bool isWin() { return win; }
        public bool isLose() { return lose; }
        public bool isGameEnd() { return gameEnd; }

        public void checkWinOrLoss()
        {
            if(population <= 0 || (grain == 0 && gold == 0))
            {
                lose = true;
                gameEnd = true;
            }
            else if(population >= requiredPop)
            {
                win = true;
                gameEnd = true;
            }
        }
    }
}
