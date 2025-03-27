namespace Polis
{
    public class BuildingFactory
    {
        private City city;
        private Building stoa;
        private Building military_academy;
        private Building sheep_farm;
        private Building brewery;
        // you possibly just invalidated the reason why you made this over complicated solution
        // just use inheritance next time
        private List<Building> buildings_list = new List<Building>();

        public BuildingFactory(City _city)
        {
            city = _city;
            stoa = new Building("Stoa", 100, stoaProcess);
            military_academy = new Building("Military Academy", 200, militaryProcess);
            sheep_farm = new Building("Sheep Farm", 500, sheepProcess);
            brewery = new Building("Brewery", 1000, breweryProcess);
            buildings_list.Add(stoa);
            buildings_list.Add(military_academy);
            buildings_list.Add(sheep_farm);
            buildings_list.Add(brewery);
        }

        private void stoaProcess()
        {
            int attractedPop = city.randomGenerator.Next(10, 100);
            city.increasePopulation(attractedPop);
            Console.WriteLine("Your Stoa attracted {0} budding philosophers to study.", attractedPop);
        }

        private void militaryProcess()
        {
            int trainedSoldiers = city.randomGenerator.Next(10, 20);
            city.increaseSoldiers(trainedSoldiers);
            Console.WriteLine("Your Military Academy has produced {0} new fine soldiers ready to serve.", trainedSoldiers);
        }

        private void sheepProcess()
        {
            int goldEarned = city.randomGenerator.Next(100, 250);
            city.increaseGold(goldEarned);
            Console.WriteLine("Your Sheep Farm has earned {0} gold.", goldEarned);
        }

        private void breweryProcess()
        {
            int goldEarned = city.randomGenerator.Next(500, 800);
            city.increaseGold(goldEarned);
            Console.WriteLine("Your Brewery has earned {0} gold.", goldEarned);
        }

        public int requestBuilding(String callerName)
        {
            int choice;

            for (int i = 0; i < buildings_list.Count(); i++)
            {
                Console.WriteLine("Press {0} to build a {1} for {2} gold.",
                                    i + 1, buildings_list[i].getName(), buildings_list[i].getPrice());
            }
            Console.WriteLine("Press 0 to cancel acting with " + callerName + ".");

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 0)
                {
                    return 0;
                }
                else if (choice > buildings_list.Count())
                {
                    throw new Exception();
                }

                if (buildings_list[choice - 1].getPrice() > city.getGold())
                {
                    Console.WriteLine("Not enough gold to build a {0}.", buildings_list[choice - 1].getName());
                    return 0;
                }

                city.addBuilding(buildings_list[choice - 1].clone());
                city.increaseGold(-buildings_list[choice - 1].getPrice());
                Console.WriteLine("Built a {0} for {1} gold.", buildings_list[choice - 1].getName(),
                                    buildings_list[choice - 1].getPrice());
                return 1;
            }
            // so it will stop complaining about the unused exception e which i handled already
#pragma warning disable 0168
            catch (Exception e)
            {
                Console.WriteLine("Invalid input, please try again.");
                return 0;
            }
        }
    }

    public class Building
    {
        private String name;
        private int price;

        public Building(String _name, int _price, Action _process)
        {
            name = _name;
            price = _price;
            process = _process;
        }

        public String getName() { return name; }
        public int getPrice() { return price; }

        public Action process;
        public Building clone()
        {
            return new Building(name, price, process);
        }
    }
}
