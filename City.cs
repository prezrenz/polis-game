namespace Polis
{
    class City
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

        City(String _king_name, String _city_name)
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
            
            win = false;
            lose = false;
            gameEnd = false;
        }

        public void processTurn()
        {

        }

        public void increasePopulation()
        {

        }

        public void increaseFood()
        {

        }

        public void increaseGold()
        {

        }

        public void increaseLandLevel()
        {

        }

        public void addBuilding()
        {

        }

        public void addOfficer()
        {

        }

        public void processInvasion() // could be private
        {

        }

        public bool isWin() { return win; }
        public bool isLose() { return lose; }
        public bool isGameEnd() { return gameEnd; }

        public void checkWinOrLoss()
        {

        }
    }
}
