namespace Polis
{
    class Citizen
    {
        private String name;
        private int energy;
        private int skill;

        public String getName()
        {
            return name;
        }

        public int getEnergy()
        {
            return energy;
        }

        public int getSkill()
        {
            return skill;
        }

        public void processCommand()
        {

        }

        public void useEnergy()
        {

        }

        public void upkeep()
        {

        }

        public void generateSkill()
        {

        }

        public void generateName()
        {

        }
    }

    class Leader: Citizen
    {

    }

    class Commander: Citizen
    {

    }

    class Farmer: Citizen
    {

    }

    class Developer: Citizen
    {

    }

    class Merchant: Citizen
    {

    }
}
