namespace GameLibrary
{
    public class Spell
    {
        private string name;
        private double damage;
        private double manaCost;
        private double castRange;

        public Spell(string name, double damage, double manaCost, double castRange)
        {
            this.name = name;
            this.damage = damage;
            this.manaCost = manaCost;
            this.castRange = castRange;
        }

        public string Name { get { return name; } }
        public double Damage { get { return damage; } }
        public double ManaCost { get { return manaCost; } }
        public double CastRange { get { return castRange; } }

        public string SpellInfo()
        {
            return string.Format("{0} - {1} dmg, {2} manaCost, {3} castRange", name, damage, manaCost, castRange);
        }

    }
}