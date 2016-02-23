namespace GameLibrary
{
    public class HealthPotion
    {
        private double healthPoints;

        public HealthPotion(double healthPoints)
        {
            this.healthPoints = healthPoints;
        }

        public double HealthPoints { get { return healthPoints; } }
    }
}
