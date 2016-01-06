using System;

namespace GameLibrary
{
    public class Hero
    {
        private string name;
        private string title;
        private double startHealth;
        private double startMana;
        private double manaRegenerationRate;

        private double currentHealth;
        private double currentMana;
        private Weapon heroWeapon = null;
        private Spell heroSpell = null;

        public Hero(string name, string title, double health, double mana, double manaRegenerationRate)
        {
            this.name = name;
            this.title = title;
            startHealth = health;
            startMana = mana;
            this.manaRegenerationRate = manaRegenerationRate;

            currentHealth = health;
            currentMana = mana;
        }

        public string Name { get { return name; } }
        public string Title { get { return title; } }
        public double ManaRegenerationRate { get { return manaRegenerationRate; } }
        public double MaxHealth { get { return startHealth; } }
        public double MaxMana { get { return startMana; } }
        public bool IsEquiped { get; private set; } = false;
        public bool KnowsSpell { get; private set; } = false;

        public string KnownAs()
        {
            return string.Format("{0} the {1}", name, title);
        }

        public bool IsAlive()
        {
            if (currentHealth > 0)
                return true;
            else if (currentHealth == 0)
                return false;
            else
                throw new ArgumentException("ERROR: Hero's health is a negative number!");
        }

        public double GetHealth()
        {
            return currentHealth;
        }

        public double GetMana()
        {
            return currentMana;
        }

        public bool CanCast()
        {
            if (heroSpell.ManaCost > currentMana)
                return false;
            else
                return true;
        }

        public void TakeDamage(double damagePoints) 
        {
            if (damagePoints >= currentHealth)
                currentHealth = 0;
            else
                currentHealth -= damagePoints;
        }  

        public bool TakeHealing(double healingPoints)
        {
            if (currentHealth == 0)
                return false;
            else if (currentHealth + healingPoints > startHealth)
                currentHealth = startHealth;
            else
                currentHealth += healingPoints;

            return true;
        }

        public void TakeMana(double manaPoints)
        {
            if (currentMana + manaPoints > startMana)
                currentMana = startMana;
            else
                currentMana += manaPoints;
        }

        public void Equip(Weapon weapon)
        {
            heroWeapon = weapon;
            IsEquiped = true;
        }

        public void Learn(Spell spell)
        {
            if (spell.ManaCost <= startMana)
            {
                heroSpell = spell;
                KnowsSpell = true;
            }
            else
                throw new ArgumentException("ERROR: Cannot learn a spell that requires more mana than the hero can have!");
        }

        public void Attack(Weapon weapon, Enemy enemy)
        {
            if (weapon == null)
                Console.WriteLine("Hero hits with bare hands for 0 dmg(no weapon). Enemy health is {0}.", enemy.GetHealth());
            else
            {
                enemy.TakeDamage(weapon.Damage);
                Console.WriteLine("Hero hits with {0} for {1} dmg. Enemy health is {2}.", weapon.Name, weapon.Damage, enemy.GetHealth());
            }
        }

        public void Attack(Spell spell, Enemy enemy)
        {
            if (spell == null)
                Console.WriteLine("Hero hits with bare hands for 0 dmg(no spells). Enemy health is {0}.", enemy.GetHealth());
            else
            {
                enemy.TakeDamage(spell.Damage);
                if (currentMana - spell.ManaCost < 0)
                    currentMana = 0;
                else
                    currentMana -= spell.ManaCost;

                Console.WriteLine("Hero casts {0} for {1} dmg. Enemy health is {2}.", spell.Name, spell.Damage, enemy.GetHealth());
            }  
        }

        public Weapon GetWeapon()
        {
            return heroWeapon;
        }

        public Spell GetSpell()
        {
            return heroSpell;
        }
    }
}