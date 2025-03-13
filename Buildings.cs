namespace Polis
{
    class BuildingFactory
    {
        public Building getNewBuilding(String building)
        {
            switch(building.ToLower())
            {
                case "stoa":
                    return new Stoa();
                case "milacademy":
                    return new MilitaryAcademy();
                case "sheep":
                    return new SheepFarm();
                case "brewery":
                    return new Brewery();
                default:
                    return null; // ill just check errors later
            }
        }
    }

    abstract class Building
    {
        String name;
        int price;
        City city;
        public abstract void process();
        public abstract void removeBuilding();
    }

    class Stoa: Building
    {
        public override void process()
        {

        }

        public override void removeBuilding()
        {

        }
    }

    class MilitaryAcademy: Building
    {
        public override void process()
        {

        }

        public override void removeBuilding()
        {

        }
    }

    class SheepFarm: Building
    {
        public override void process()
        {

        }

        public override void removeBuilding()
        {

        }
    }

    class Brewery: Building
    {
        public override void process()
        {

        }

        public override void removeBuilding()
        {

        }
    }
}
