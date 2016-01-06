using System;

namespace GameLibrary
{
    public class Enemy
    {
        private double startHealth;
        private double startMana;
        private double damage;

        private double currentHealth;
        private double currentMana;
        private Weapon enemyWeapon;
        private Spell enemySpell;

        public Enemy(double health, double mana, double damage)
        {
            startHealth = health;
            startMana = mana;
            this.damage = damage;

            currentHealth = health;
            currentMana = mana;
        }

        public double MaxHealth { get { return startHealth; } }
        public double MaxMana { get { return startMana; } }
        public bool IsEquiped { get; private set; } = false;
        public bool KnowsSpell { get; private set; } = false;

        public double EnemyRow { get; set; }
        public double EnemyCol { get; set; }

        public bool IsAlive()
        {
            if (currentHealth > 0)
                return true;
            else if (currentHealth == 0)
                return false;
            else
                throw new ArgumentException("ERROR: Enemy's health is a negative number.");
        }

        public bool CanCast()
        {
            if (enemySpell.ManaCost > currentMana)
                return false;
            else
                return true;
        }

        public double GetHealth()
        {
            return currentHealth;
        }

        public double GetMana()
        {
            return currentMana;
        }
        
        public double GetDamage()
        {
            return damage;
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

        public void TakeDamage(double damagePoints)
        {
            if (damagePoints >= currentHealth)
                currentHealth = 0;
            else
                currentHealth -= damagePoints;
        }

        public void Equip(Weapon weapon)
        {
            enemyWeapon = weapon;
            IsEquiped = true;
        }

        public void Learn(Spell spell)
        {
            if (spell.ManaCost <= startMana)
            {
                enemySpell = spell;
                KnowsSpell = true;
            }
            else
                throw new ArgumentException("ERROR: Cannot learn a spell that requires more mana than the enemy can have!");
        }

        public void Attack(Hero hero)
        {
            hero.TakeDamage(damage);
            Console.WriteLine("Enemy hits hero for {0} dmg. Hero health is {1}", damage, hero.GetHealth());
        }

        public void Attack(Weapon weapon, Hero hero)
        {
            hero.TakeDamage(weapon.Damage);
            Console.WriteLine("Enemy hits hero for {0} dmg. Hero health is {1}", weapon.Damage, hero.GetHealth());
        }

        public void Attack(Spell spell, Hero hero)
        {
            hero.TakeDamage(spell.Damage);
            if (currentMana - spell.ManaCost < 0)
                currentMana = 0;
            else
                currentMana -= spell.ManaCost;

            Console.WriteLine("Enemy hits hero for {0} dmg. Hero health is {1}", spell.Damage, hero.GetHealth());
        }

        public Weapon GetWeapon()
        {
            return enemyWeapon;
        }

        public Spell GetSpell()
        {
            return enemySpell;
        }
    }
}