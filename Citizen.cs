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

        public virtual int processCommand()
        {
            return 0; // should be fine, it'll use the overriden method anyway... should
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

        public override int processCommand()
        {
            int choice;

            Console.WriteLine("Press 1 to hire a new citizen for 100 gold.");
            Console.WriteLine("Press 2 to dismiss a citizen.");
            Console.WriteLine("Press 0 to cancel acting with " + getName() + ".");

            try
            { 
                choice = Convert.ToInt32(Console.ReadLine());

                if(choice == 1)
                {
                    return hire();
                }
                else if(choice == 2)
                {
                    return dismiss();
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Invalid input, please try again.");
                return 0;
            }
        }

        private int hire()
        {
            int hireNumber = randomGenerator.Next(1, 4);

            if(city.getGold() < 100)
            {
                Console.WriteLine("Not enough to hire another citizen.");
                return 0;
            }

            if(city.isAtMaxCitizen())
            {
                Console.WriteLine("You already have too many citizens!");
                return 0;
            }

            switch(hireNumber)
            {
                case 1:
                    city.addCitizen("Commander");
                    break;
                case 2:
                    city.addCitizen("Farmer");
                    break;
                case 3:
                    city.addCitizen("Developer");
                    break;
                case 4:
                    city.addCitizen("Merchant");
                    break;
                default:
                    return 0;
            }

            city.increaseGold(-100);

            return 1;
        }

        private int dismiss()
        {
            return city.removeCitizen();
        }

        public override void upkeep()
        {
            city.increaseGold(0);
        }
    }

    public class Commander: Citizen
    {
        private int charisma;
        private int draftCost = 100;
        public Commander(City _city) : base(_city, "Commander", "hire or train soldiers") { charisma = generateCharisma(); }

        public int generateCharisma()
        {
            return randomGenerator.Next(30, 100);
        }

        public override int processCommand()
        {                
            int choice;

            Console.WriteLine("Press 1 to draft 50 to " + charisma + " soldiers for 100 gold.");
            Console.WriteLine("Press 2 to increase your training level.");
            Console.WriteLine("Press 0 to cancel acting with " + getName() + ".");

            try
            { 
                choice = Convert.ToInt32(Console.ReadLine());

                if(choice == 1)
                {
                    return draft();
                }
                else if(choice == 2)
                {
                    return train();
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Invalid input, please try again.");
                return 0;
            }
        }
        
        private int draft()
        {
            city.increaseSoldiers(randomGenerator.Next(10, this.charisma)+50);
            city.increaseGold(-draftCost);
            return 1;
        }

        private int train()
        {
            city.increaseTraining(randomGenerator.Next(10, this.getSkill()));
            return 1;
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
