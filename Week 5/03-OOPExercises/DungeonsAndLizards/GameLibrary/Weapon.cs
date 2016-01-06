namespace GameLibrary
{
    public class Weapon
    {
        private string name;
        private double damage;

        public Weapon(string name, double damage)
        {
            this.name = name;
            this.damage = damage;
        }

        public string Name { get { return name; } }
        public double Damage { get { return damage; } }

        public string WeaponInfo()
        {
            return string.Format("{0}({1} dmg)", name, damage);
        }

    }
}