using System;

namespace unity_learning.Encapsulation.Ex1
{
    public abstract class Unit : IUnitStats, IUnitReceiveDamage
    {
        public int Health { get; private set; }

        private Weapon _weapon;
        public IWeaponStats WeaponStats => _weapon;

        public bool IsAlive => Health > 0;

        protected Unit(int health, Weapon weapon)
        {
            if (health <= 0)
                throw new ArgumentOutOfRangeException(nameof(health));
            
            if (weapon == null)
                throw new ArgumentNullException(nameof(weapon));
            
            Health = health;
            _weapon = weapon;
        }

        private bool CanReceiveDamage(int damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));
            
            return IsAlive;
        }
        
        public void ReceiveDamage(int damage)
        {
            bool canReceiveDamage = CanReceiveDamage(damage);

            if (canReceiveDamage)
            {
                Health -= damage;
                if (Health <= 0) 
                    Die();
            }
        }
        
        protected void ShotFire(IUnitReceiveDamage unit)
        {
            if (IsAlive)
                _weapon.ShotFire(unit);
        }

        private void Die()
        {
            _weapon = null;
            Health = -1;
        }
    }
    
    public interface IUnitStats
    {
        int Health { get; }
        IWeaponStats WeaponStats { get; }
    }

    public interface IUnitReceiveDamage
    {
        void ReceiveDamage(int damage);
    }
}