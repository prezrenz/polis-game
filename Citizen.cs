namespace Polis
{
    class Citizen
    {
        private String name;
        private bool tired;
        private int skill;
        private City city;
        public Random randomGenerator;

        static readonly String[] GREEK_NAMES = {
            "Odysseus",
            "Telemachus",
            "Agammemnon",
            "Menaleus",
            "Aristotle",
            "Xenophon",
            "Themistocles",
            "Patroklos",
            "Solon",
            "Leonidas",
            "Nestor",
            "Aias",
        };

        public Citizen(City _city)
        {
            randomGenerator = new Random();
            name = generateName();
            int skill = generateSkill();
            tired = false;
            city = _city;
        }
        
        public Citizen(City _city, String _name)
        {
            randomGenerator = new Random();
            name = _name;
            int skill = generateSkill();
            tired = false;
            city = _city;
        }

        public String getName()
        {
            return name;
        }

        public bool isTired()
        {
            return tired;
        }

        public int getSkill()
        {
            return skill;
        }

        public void processCommand()
        {

        }

        public void upkeep()
        {

        }

        public int generateSkill() // for setting skill
        {
            return randomGenerator.Next(20, 100);
        }

        public String generateName() // for setting name
        {
            return GREEK_NAMES[randomGenerator.Next(0, GREEK_NAMES.Length)];
        }
    }

    class Leader: Citizen
    {
        Leader(City _city) : base(_city) { }
        Leader(City _city, String _name) : base(_city, _name) { }
    }

    class Commander: Citizen
    {
        private int charisma;
        Commander(City _city) : base(_city) { charisma = generateCharisma(); }

        public int generateCharisma()
        {
            return randomGenerator.Next(30, 100);
        }

    }

    class Farmer: Citizen
    {
       Farmer(City _city) : base(_city) { } 

    }

    class Developer: Citizen
    {
        Developer(City _city) : base(_city) { }

    }

    class Merchant: Citizen
    {
        Merchant(City _city) : base(_city) { }

    }
}
