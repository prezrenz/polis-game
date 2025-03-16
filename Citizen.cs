namespace Polis
{
    public class Citizen
    {
        private String name;
        private String role;
        private String actionText;
        private bool tired;
        private int skill;
        public City city;
        public Random randomGenerator;

        static readonly String[] GREEK_NAMES = {
            "Odysseus",
            "Polites",
            "Eurylochus",
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

        public Citizen(City _city, String _role, String _actionText)
        {
            randomGenerator = new Random();
            name = generateName();
            skill = generateSkill();
            tired = false;
            city = _city;
            role = _role;
            actionText = _actionText;
        }
        
        public Citizen(City _city, String _name, String _role, String _actionText)
        {
            randomGenerator = new Random();
            name = _name;
            skill = generateSkill();
            tired = false;
            city = _city;
            role = _role;
            actionText = _actionText;
        }

        public String getName()
        {
            return name;
        }

        public String getRole()
        {
            return role;
        }

        public String getAction()
        {
            return actionText;
        }

        public bool isTired()
        {
            return tired;
        }

        public int getSkill()
        {
            return skill;
        }

        public void setTired(bool b)
        {
            tired = b;
        }

        public virtual void processCommand()
        {

        }

        public virtual void upkeep()
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

    public class Leader: Citizen
    {
        public Leader(City _city) : base(_city, "Leader", "hire or dismiss citizens") { }
        public Leader(City _city, String _name) : base(_city, _name, "Leader", "hire or dismiss citizens") { }

        public override void upkeep()
        {
            city.increaseGold(0);
        }
    }

    public class Commander: Citizen
    {
        private int charisma;
        public Commander(City _city) : base(_city, "Commander", "hire or train soldiers") { charisma = generateCharisma(); }

        public int generateCharisma()
        {
            return randomGenerator.Next(30, 100);
        }

        public override void upkeep()
        {
            city.increaseGold(-100);
        }

    }

    public class Farmer: Citizen
    {
       public Farmer(City _city) : base(_city, "Farmer", "develop land") { } 

       public override void upkeep()
       {
           city.increaseGold(-20);
       }

    }

    public class Developer: Citizen
    {
        public Developer(City _city) : base(_city, "Urban Developer", "build") { }

        public override void upkeep()
        {
            city.increaseGold(-50);
        }
    }

    public class Merchant: Citizen
    {
        public Merchant(City _city) : base(_city, "Merchant", "trade") { }

        public override void upkeep()
        {
            city.increaseGold(-50);
        }

    }
}
