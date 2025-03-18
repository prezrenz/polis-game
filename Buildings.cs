namespace Polis
{
    class BuildingFactory
    {
        private City city;
        private Building stoa;
        private Building military_academy;
        private Building sheep_farm;
        private Building brewery;

        BuildingFactory(City _city)
        {
            city = _city;
            stoa = new Building("Stoa", 100, stoaProcess);
            military_academy = new Building("Military Academy", 100, militaryProcess);
            sheep_farm = new Building("Sheep Farm", 100, sheepProcess);
            brewery = new Building("Brewery", 100, breweryProcess);
        }

        private void stoaProcess()
        {

        }

        private void militaryProcess()
        {

        }

        private void sheepProcess()
        {

        }

        private void breweryProcess()
        {

        }
        
        public Building getNewBuilding(String building)
        {
            switch(building.ToLower())
            {
                case "stoa":
                    return stoa.clone();
                case "milacademy":
                    return military_academy.clone();
                case "sheep":
                    return sheep_farm.clone();
                case "brewery":
                    return brewery.clone();
                default:
                    return new Building("ERROR", 0, () => Console.WriteLine("Building Error: should not be possible!")); // default error should be handled some other way instead of using Building like an Exception object
            }
        }
    }

    class Building
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
