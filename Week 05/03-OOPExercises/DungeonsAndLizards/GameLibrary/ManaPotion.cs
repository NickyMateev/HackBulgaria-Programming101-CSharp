namespace GameLibrary
{
    public class ManaPotion
    {
        private double manaPoints;

        public ManaPotion(double manaPoints)
        {
            this.manaPoints = manaPoints;
        }

        public double ManaPoints { get { return manaPoints; } }
    }
}